namespace MEdge.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Core;
    using Source;
    using TdGame;
    using Tp;
    using UnityEngine.Events;
    using UnityEngine.SceneManagement;
    using V3 = UnityEngine.Vector3;
    using Collider = UnityEngine.Collider;
    using Object = Core.Object;
    using static UnityEngine.Debug;
    using String = Core.String;
    using Vector = Core.Object.Vector;
    using FVector = Core.Object.Vector;



    public partial class UWorld : UnityEngine.MonoBehaviour, IUWorld
    {
        public static UWorld Instance => GetInstance();
        public bool HasBegunPlay{ get; private set; }
        Actor _defaultOuter;
        public WorldInfo WorldInfo{ get; private set; }

        Engine _engine = new TdGameEngine();
        UnityEngine.BoxCollider _cacheCollider = new UnityEngine.BoxCollider();
        List<Actor> _actorsThisFrame = new List<Actor>();

        static UWorld _instance;
        static UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> _onSceneLoadedCached;
        static ConditionalWeakTable<Actor, IProcessor> Processors = new ConditionalWeakTable<Actor, IProcessor>();



        static UWorld()
        {
            UWorldBridge.GetUWorld = () => Instance;
        }



        interface IProcessor
        {
            void Update( float deltaTime );
            void OnDestroy();
        }



        void Update()
        {
            if(ReferenceEquals( this, _instance ) == false)
                Destroy(this);

            UnityEngine.Time.timeScale = this.WorldInfo.TimeDilation;
            var deltaTime = UnityEngine.Time.deltaTime;// * this._worldInfo.TimeDilation;
            deltaTime = deltaTime > 0.4f ? 0.4f : deltaTime < 0.0005f ? 0.0005f : deltaTime;
            this.WorldInfo.RealTimeSeconds = UnityEngine.Time.realtimeSinceStartup;
            this.WorldInfo.DeltaSeconds = deltaTime;
            this.WorldInfo.SavedDeltaSeconds = deltaTime; // no clue for this one
            this.WorldInfo.TimeSeconds += deltaTime;
            this.WorldInfo.AudioTimeSeconds += deltaTime;
            

            _actorsThisFrame.Clear();
            foreach( var actor in WorldInfo._allActors )
                _actorsThisFrame.Add(actor);
            
            foreach( var actor in _actorsThisFrame )
            {
                if( actor is PlayerController pc )
                {
                    #warning debug only
                    SampleInput( pc.PlayerInput as TdPlayerInput, pc as TdPlayerController, deltaTime );
                    pc.PlayerInput.Tick( deltaTime );
                    pc.PlayerTick( deltaTime );
                }
            }
            
            foreach( var actor in _actorsThisFrame )
                if( actor.TickGroup == Object.ETickingGroup.TG_PreAsyncWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in _actorsThisFrame )
                if( actor.TickGroup == Object.ETickingGroup.TG_DuringAsyncWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in _actorsThisFrame )
                if( actor.TickGroup == Object.ETickingGroup.TG_PostAsyncWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in _actorsThisFrame )
                if( actor.TickGroup == Object.ETickingGroup.TG_PostUpdateWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            
            foreach( var actor in _actorsThisFrame )
            {
                IProcessor p;
                if( Processors.TryGetValue( actor, out p ) == false )
                {
                    p = actor switch
                    {
                        TdPawn pawn => new PawnLink{ Pawn = pawn },
                        _ => null
                    };
                    
                    if( p != null )
                        Processors.Add( actor, p );
                }
                p?.Update(deltaTime);
            }
            
            _actorsThisFrame.Clear();
        }



        void OnDestroy()
        {
            var actors = WorldInfo._allActors;
            foreach( var actor in actors )
            {
                if( Processors.TryGetValue( actor, out IProcessor p ) )
                {
                    p?.OnDestroy();
                }
            }
        }



        public static void EnsureStart()
        {
            var v = Instance;
        }



        static UWorld GetInstance()
        {
            if( _instance != null && _instance.gameObject != null )
            {
                _instance.transform.parent = null;
                return _instance;
            }

            var go = new UnityEngine.GameObject( nameof( UWorld ) );
            DontDestroyOnLoad( go );
            _instance = go.AddComponent<UWorld>();
            _instance._defaultOuter = new Actor();
            _instance.LevelStartup();
            _instance.PlayerLogIn();

            if(_onSceneLoadedCached != null)
                SceneManager.sceneLoaded -= _onSceneLoadedCached;
            SceneManager.sceneLoaded += _onSceneLoadedCached = OnSceneLoaded;
            return _instance;
        }



        static void SetCollisionType(Actor a)
        {
            // Accuracy of this has not been verified
            if( a.bCollideActors && a.bBlockActors )
                a.CollisionType = Actor.ECollisionType.COLLIDE_BlockAll;
            else if( a.bCollideActors && a.bBlockActors == false )
                a.CollisionType = Actor.ECollisionType.COLLIDE_TouchAll;
            else 
                a.CollisionType = Actor.ECollisionType.COLLIDE_NoCollision;
        }



        static void OnSceneLoaded( UnityEngine.SceneManagement.Scene arg0, LoadSceneMode arg1 )
        {
            #warning not implemented yet
        }



        void LevelStartup()
        {
            // https://wiki.beyondunreal.com/Legacy:Chain_Of_Events_At_Level_Startup
			
            var gameInfo = new TdSPGame();
            gameInfo.WorldInfo = WorldInfo = new WorldInfo
            {
                PhysicsVolume = new DefaultPhysicsVolume(),
                Game = gameInfo,
            };

            HasBegunPlay = true;
            WorldInfo.bBegunPlay = true;
            WorldInfo.bStartup = true;
            
            String errorString = "";
            gameInfo.InitGame("", ref errorString);

            List<(Actor, UnityEngine.GameObject)> actors = new List<(Actor, UnityEngine.GameObject)> { (gameInfo, gameObject) };
            for( int i = 0; i < SceneManager.sceneCount; i++ )
            {
                var scene = SceneManager.GetSceneAt( i );
                foreach( var comp in 
                    from r in scene.GetRootGameObjects()
                    from c in r.GetComponentsInChildren<UnityEngine.Component>()
                    select c)
                {
                    if( comp is IUObject uObject )
                    {
                        if(uObject.GetUObject() is Actor a)
                            actors.Add( ( a, comp.gameObject ) );
                    }
                }
            }

            foreach( var (actor, _) in actors )
                _instance.WorldInfo._allActors.Add( actor );

            foreach( var (actor, go) in actors )
            {
                if( actor.Tag == default )
                    actor.Tag = actor.Class.Name;

                actor.CreationTime = UnityEngine.Time.time;
                actor.WorldInfo = WorldInfo;
                actor.Location = go.transform.position.ToUnrealPos();
                actor.Rotation = (Object.Rotator)go.transform.rotation;
                actor.PhysicsVolume = WorldInfo.PhysicsVolume ?? throw new System.NullReferenceException();
            }
            
            foreach( var (actor, _) in actors )
                SetCollisionType( actor );

            foreach( var (actor, _) in actors )
                actor.PreBeginPlay();

            foreach( var (actor, _) in actors )
                actor.PostBeginPlay();
            
            foreach( var (actor, _) in actors )
                actor.SetInitialState();
            
            WorldInfo.bStartup = false; // MAYBE ?
        }



        void PlayerLogIn()
        {
            // https://wiki.beyondunreal.com/Legacy:Chain_Of_Events_When_A_Player_Logs_In
            String err = default;
            WorldInfo.Game.PreLogin( default, default, ref err );
            var controller = WorldInfo.Game.Login( default, "?Character=TdPlayerPawn", ref err );
            var player = _classImp<LocalPlayer>.Singleton.New( _engine );
            // Controller SetPlayer()
            {
                controller.Player = player;
                controller.InitInputSystem();
                controller.ReceivedPlayer();
                // Hacks for now
                controller.OnlinePlayerData ??= new UIDataStore_OnlinePlayerData{ ProfileProvider = new UIDataProvider_OnlineProfileSettings{ Profile = new TdProfileSettings() } };
                ( controller as TdPlayerController ).StatsManager ??= new TdStatsManager();
                controller.OnlineSub = new OnlineSubsystem{ PlayerInterface = new TpUoPlayer() };
            }
            WorldInfo.Game.PostLogin( controller );
        }

        bool FindSpot(Object.Vector extent, ref Object.Vector position, bool bComplex)
        {
            Collider[] colliders = new Collider[ 1 ];
            int iterations = 0;
            _cacheCollider.size = extent.ToUnityPos();
            while(UnityEngine.Physics.OverlapBoxNonAlloc( position.ToUnityPos(), extent.ToUnityPos() / 2f, colliders ) > 0)
            {
                var otherCollider = colliders[ 0 ];
                if( false == UnityEngine.Physics.ComputePenetration( _cacheCollider, position.ToUnityPos(), default,
                    otherCollider, otherCollider.transform.position, otherCollider.transform.rotation,
                    out var direction, out var distance ) )
                {
                    return true;
                }

                position += (direction * distance).ToUnrealPos();
                
                if( iterations++ > 8 )
                    return false;
            }

            return true;
        }



        public ConditionalWeakTable<object, object> UScriptToUnity => Asset.UScriptToUnity;
        public TClass LoadAsset<TClass>( Core.String assetPath ) where TClass : new() => Asset.LoadAsset<TClass>( assetPath );



        public T E_UWorld_SpawnActor<T>(Core.ClassT<T> SpawnClass, int a3, float a4, Object.Vector SpawnLocation, Object.Rotator SpawnRotation, Actor ActorTemplate, bool bNoCollisionFail, int networkRelatedParam, Actor SpawnOwner, Pawn Instigator, bool bProbablyNoFail) where T : Actor
		{
            #warning implement this maybe
            bool bUWorldHasBegunPlay = this.HasBegunPlay;
            var bUWorldHasBegunPlay2 = bUWorldHasBegunPlay;
            bool bUWorldHasBegunPlay3 = bUWorldHasBegunPlay;
            var SpawnClassCopy = SpawnClass;
            if( SpawnClass == null )
                return null;
            /*
            v16 = *(_DWORD *)&SpawnClass->_E_struct_UState::UnknownData00[72];
            if ( ((unsigned int)&dword_2000000 & v16) != 0 )
                return 0;
            if ( (v16 & 1) != 0 )
                return 0;
            privateStaticClass = E_AActor_ReturnPrivateStaticClass();
            if ( !E_maybe_IsThisClassBeforeComparand(SpawnClassCopy, privateStaticClass) )
                return 0;*/
            var networkRelatedBool = !bUWorldHasBegunPlay2;
            var actorTemplateCopy = ActorTemplate;
            //if ( !networkRelatedBool && ((E_UClass_GetDefaultObject(SpawnClassCopy, 0)->bExludeHandMoves & bStatic) != 0 || (E_UClass_GetDefaultObject(SpawnClassCopy, 0)->bExludeHandMoves & bNoDelete) != 0) )
            if ( !networkRelatedBool && ((SpawnClassCopy.DefaultAs<Actor>().bStatic != false || SpawnClassCopy.DefaultAs<Actor>().bNoDelete != false) ))
            {
                if ( !bProbablyNoFail )
                    return null;
            }
            if ( actorTemplateCopy != null )
            {
                if( actorTemplateCopy.Class != SpawnClassCopy && !bProbablyNoFail )
                    return null;
            }
            else
            {
                actorTemplateCopy = SpawnClassCopy.DefaultAs<Actor>();
            }
            /*v21 = SpawnLocation->Y;
            v22 = SpawnLocation->Z;
            spawnLocation2.X = SpawnLocation->X;
            spawnLocation2.Y = v21;
            spawnLocation2.Z = v22;
            v23 = actorTemplateCopy->bForceDemoRelevant;
            if ( (v23 < 0 || (v23 & bCollideWhenPlacing) != 0 && E_maybe_UWorld_GetNetMode(thisUWorldCopy) != 3) && !bNoCollisionFail )*/
            if ( (actorTemplateCopy.bCollideWhenPlacing != false && WorldInfo.NetMode != (WorldInfo.ENetMode)3) && !bNoCollisionFail )
            {
                Object.Vector extent;
                if( actorTemplateCopy.CollisionComponent is CylinderComponent cc )
                {
                    extent = new Object.Vector( cc.CollisionRadius, cc.CollisionRadius, cc.CollisionHeight );
                }
                else// if ( actorTemplateCopy.CollisionComponent is BrushComponent bc )
                {
                    extent = default;
                    LogWarning( $"Attempted to spawn actor with unimplemented bounds getter for collision component '{actorTemplateCopy.CollisionComponent.GetType()}'" );
                }

                if( ! FindSpot( extent, ref SpawnLocation, actorTemplateCopy.bCollideComplex ) )
                {
                    LogWarning( $"Could not {nameof(FindSpot)} @ {SpawnLocation} to spawn {actorTemplateCopy}" );
                    return null;
                }
            }
            //spawnOwnerCopy = SpawnOwner;
            Actor newOuter;
            if( SpawnOwner != null )
                newOuter = (Actor) SpawnOwner.Outer;
            else // Need to verify how that works
                newOuter = _defaultOuter;// *(_E_struct_AActor **)&thisUWorldCopy->UnknownData_[24];
            // Need to verify this as well
            var constructedActor = SpawnClassCopy.New( newOuter );////E_UObject_StaticConstructObject(SpawnClassCopy, newOuter, a3, SLODWORD(a4), 0, 1, actorTemplateCopy, 0, 0);

            // Not sure where this is supposed to trigger, not sure that it matters anyway
            foreach( var component in constructedActor.Components )
            {
                component.Owner = constructedActor;
            }
            
            /*constructedActorCopy = constructedActor;
            if ( dword_2018700 )
                sub_B81580(newOuter);
            sub_806170((int *)&newOuter->bExludeHandMoves, &constructedActorCopy);
            refToConstructedActorTag = &constructedActor->Tag;
            a3 = 0;
            a4 = 0.0;*/
            //if ( E_mabye_CompFNameEquality(&constructedActor->Tag, (_E_struct_FName *)&a3) )// Is the constructed actor tag not yet set
            if( constructedActor.Tag == default )
            {
                /*if ( SpawnClassCopy->ObjectInternalInteger == -1 )
                    name = (_E_struct_FName *)sub_1117920(&a3, (int)refToConstructedActorTag, (wchar_t *)L"<uninitialized>", 1, 1);
                else*/
                    var name = SpawnClassCopy.Name;
                constructedActor.Tag = name;
                //refToConstructedActorTag->Index = name->Index;
                //constructedActor->Tag.Number = name->Number;
            }
            //constructedActor->bExludeHandMoves ^= (constructedActor->bExludeHandMoves ^ ((*(_DWORD *)&this->UnknownData_[252] == 0) << 7)) & bTicked;
            #warning Ticked setter not quite figured out yet
            constructedActor.bTicked = false/*!Ticked*/;
            constructedActor.CreationTime = UnityEngine.Time.time;//E_UWorld_GetTimeSeconds(this);
            //ptrToSomeKindOfWorldInfo = E_GetSomeKindOfPtrToWorldInfo(this);
            networkRelatedBool = networkRelatedParam == 0;
            constructedActor.WorldInfo = WorldInfo;
            if ( !networkRelatedBool )
            {
                var v31 = constructedActor.Role;
                constructedActor.Role = constructedActor.RemoteRole;
                constructedActor.RemoteRole = v31;
            }
            constructedActor.Location = SpawnLocation;
            constructedActor.Rotation = SpawnRotation;
            // .text:00C18C00 ConditionalForceUpdateComponents
            #warning ConditionalForceUpdateComponents
            //(*(void (__thiscall **)(_E_struct_AActor *, _DWORD, _DWORD))(constructedActor->VfTableObject.Dummy + 760))(constructedActor, 0, 0);
            constructedActor.PhysicsVolume = WorldInfo.PhysicsVolume ?? throw new System.NullReferenceException();
            constructedActor.SetOwner(SpawnOwner);
            constructedActor.Instigator = Instigator;



            if( bUWorldHasBegunPlay3 )
            {
                #warning InitRBPhys
                // .text:00EA1DF0 InitRBPhys
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 568))(constructedActor);
            }

            //if ( !dword_2027FC0 )
            {
                #warning InitExecution and SetDefaultCollisionType
                // .text:01105300, InitExecution?
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 260))(constructedActor);
                SetCollisionType( constructedActor );
                // .text:00BA6D80, AActor_Spawned -> inlined E_AActor_SetDefaultCollisionType
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 380))(constructedActor);
            }
            
            if ( bUWorldHasBegunPlay3 )
            {
                // .text:00C10830, PreBeginPlay
                constructedActor.PreBeginPlay();
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 472))(constructedActor);
                if ( (constructedActor.bDeleteMe) != false && !bProbablyNoFail )
                    return null;
                for ( int i = 0; i < constructedActor.Components.Length; ++i )
                {
                    var v34 = constructedActor.Components;
                    networkRelatedBool = v34[i] == null;
                    var v35 = v34[i] as ActorComponent;
                    if( ! networkRelatedBool )
                    {
                        #warning maybe start component state here ?
                        //E_UActorComponent_ConditionalBeginPlay(*v35);
                    }
                }
            }
            if ( bNoCollisionFail )
            {
                if ( (constructedActor.bCollideActors) != false )
                {
                    LogWarning( "FindTouchingActors not implemented yet!" );
                    //E_AActor_FindTouchingActors(constructedActor);
                    if ( (constructedActor.bDeleteMe) != false && !bProbablyNoFail )
                        return null;
                }
            }
            #warning no CheckEncroachment
            /*else if ( E_UWorld_CheckEncroachment(this, constructedActor, constructedActor->Location.X, constructedActor->Location.Y, constructedActor->Location.Z, constructedActor->Rotation.Pitch, constructedActor->Rotation.Yaw, constructedActor->Rotation.Roll, 1) )
            {
                E_UWorld_DestroyActor(this, constructedActor, 0, 1);
                return null;
            }*/
            if ( bUWorldHasBegunPlay3 )
            {
                // .text:00C10790 E_AActor_PostBeginPlay
                constructedActor.PostBeginPlay();
                constructedActor.SetInitialState();
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 476))(constructedActor);
                if ( (constructedActor.bDeleteMe) != false && !bProbablyNoFail )
                    return null;
            }
            /*if ( *(_DWORD *)&this->UnknownData_[248] )
                E_TArray_AddItem((_E_struct_TArray *)&this->UnknownData_[236], &constructedActorCopy);*/
            /* Not sure what this is about
            if ( !bUWorldHasBegunPlay3 )
            {
                constructedActor->bExludeHandMoves |= bDeleteMe;
                (*(void (__thiscall **)(_E_struct_AActor *, _DWORD))(constructedActor->VfTableObject.Dummy + 24))(constructedActor, 0);// .text:01104B00
                constructedActor->bExludeHandMoves &= 0xFFFFFFBF;
            }*/
            
            _instance.WorldInfo._allActors.Add( constructedActor );
            return constructedActor;
		}
        
        public struct FCheckResult// : public FIteratorActorList
        {
	        public Actor Actor;
	        // Variables.
	        public Object.Vector						Location;	// Location of the hit in coordinate system of the returner.
	        public Object.Vector						Normal;		// Normal vector in coordinate system of the returner. Zero=none.
	        public float						Time;		// Time until hit, if line check.
	        public int							Item;		// Primitive data item which was hit, INDEX_NONE=none.
	        public MaterialInterface			Material;	// Material of the item which was hit.
	        public PhysicalMaterial	PhysMaterial; // Physical material that was hit
	        public PrimitiveComponent	Component;	// PrimitiveComponent that the check hit.
	        public name						BoneName;	// Name of bone we hit (for skeletal meshes).
	        public Level				Level;		// Level that was hit in case of BSPLineCheck
			public int							LevelIndex; // Index of the level that was hit in the case of BSP checks.

	        /** This line check started penetrating the primitive. */
	        public bool						bStartPenetrating;

	        // Functions.
	        /*FCheckResult()
		        : Location	(0,0,0)
		        , Normal	(0,0,0)
		        , Time		(0.0f)
		        , Item		(INDEX_NONE)
		        , Material	(NULL)
		        , PhysMaterial( NULL)
		        , Component	(NULL)
		        , BoneName	(NAME_None)
		        , Level		(NULL)
		        , LevelIndex	(INDEX_NONE)
		        , bStartPenetrating	(FALSE)
	        {}


	        FCheckResult( FLOAT InTime, FCheckResult* InNext=NULL )
		        :	FIteratorActorList( InNext, NULL )
		        ,	Location	(0,0,0)
		        ,	Normal		(0,0,0)
		        ,	Time		(InTime)
		        ,	Item		(INDEX_NONE)
		        ,	Material	(NULL)
		        ,   PhysMaterial( NULL)
		        ,	Component	(NULL)
		        ,	BoneName	(NAME_None)
		        ,	Level		(NULL)
		        ,	LevelIndex	(INDEX_NONE)
		        ,	bStartPenetrating	(FALSE)
	        {}


	        FCheckResult*& GetNext() const
	        { 
		        return *(FCheckResult**)&Next; 
	        }


	        static QSORT_RETURN CDECL CompareHits( const FCheckResult* A, const FCheckResult* B )
	        { 
		        return A->Time<B->Time ? -1 : A->Time>B->Time ? 1 : 0; 
	        }*/
        }
        
        const int MOVE_IgnoreBases		= 0x00001; // ignore collisions with things the Actor is based on
        const int MOVE_NoFail				= 0x00002; // ignore conditions that would normally cause MoveActor() to abort (such as encroachment)
        const int MOVE_TraceHitMaterial	= 0x00004; // figure out material was hit for any collisions
        
	    const int TRACE_Pawns					= 0x00001; // Check collision with pawns.
		const int TRACE_Movers				= 0x00002; // Check collision with movers.
		const int TRACE_Level					= 0x00004; // Check collision with BSP level geometry.
		const int TRACE_Volumes				= 0x00008; // Check collision with soft volume boundaries.
		const int TRACE_Others				= 0x00010; // Check collision with all other kinds of actors.
		const int TRACE_OnlyProjActor			= 0x00020; // Check collision with other actors only if they are projectile targets
		const int TRACE_Blocking				= 0x00040; // Check collision with other actors only if they block the check actor
		const int TRACE_LevelGeometry			= 0x00080; // Check collision with other actors which are static level geometry
		const int TRACE_ShadowCast			= 0x00100; // Check collision with shadow casting actors
		const int TRACE_StopAtAnyHit			= 0x00200; // Stop when find any collision (for visibility checks)
		const int TRACE_SingleResult			= 0x00400; // Stop when find guaranteed first nearest collision (for SingleLineCheck)
		const int TRACE_Material				= 0x00800; // Request that Hit.Material return the material the trace hit.
		const int TRACE_Visible				= 0x01000;
		const int TRACE_Terrain				= 0x02000; // Check collision with terrain
		const int TRACE_Tesselation			= 0x04000; // Check collision against highest tessellation level (not valid for box checks)  (no longer used)
		const int TRACE_PhysicsVolumes		= 0x08000; // Check collision with physics volumes
		const int TRACE_TerrainIgnoreHoles	= 0x10000; // Ignore terrain holes when checking collision
		const int TRACE_ComplexCollision		= 0x20000; // Ignore simple collision on static meshes and always do per poly
		const int TRACE_AllComponents			= 0x40000; // Don't discard collision results of actors that have already been tagged.  Currently adhered to only by ActorOverlapCheck.

		// Combinations.
		const int TRACE_Hash					= TRACE_Pawns	|	TRACE_Movers |	TRACE_Volumes	|	TRACE_Others			|	TRACE_Terrain	|	TRACE_LevelGeometry;
		const int TRACE_Actors				= TRACE_Pawns	|	TRACE_Movers |	TRACE_Others	|	TRACE_LevelGeometry		|	TRACE_Terrain;
		const int TRACE_World					= TRACE_Level	|	TRACE_Movers |	TRACE_Terrain	|	TRACE_LevelGeometry;
		const int TRACE_AllColliding			= TRACE_Level	|	TRACE_Actors |	TRACE_Volumes;
		const int TRACE_ProjTargets			= TRACE_AllColliding	| TRACE_OnlyProjActor;
		const int TRACE_AllBlocking			= TRACE_Blocking		| TRACE_AllColliding;
        
        /// <summary>
		/// Tries to move the actor by a movement vector.  If no collision occurs, this function
		/// just does a Location+=Move.
		/// 
		/// Assumes that the actor's Location is valid and that the actor
		/// does fit in its current Location. Assumes that the level's
		/// Dynamics member is locked, which will always be the case during
		/// a call to UWorld::Tick; if not locked, no actor-actor collision
		/// checking is performed.
		/// 
		/// If bCollideWorld, checks collision with the world.
		/// 
		/// For every actor-actor collision pair:
		/// 
		/// If both have bCollideActors and bBlocksActors, performs collision
		///    rebound, and dispatches Touch messages to touched-and-rebounded
		///    actors.
		/// 
		/// If both have bCollideActors but either one doesn't have bBlocksActors,
		///    checks collision with other actors (but lets this actor
		///    interpenetrate), and dispatches Touch and UnTouch messages.
		/// 
		/// Returns 1 if some movement occured, 0 if no movement occured.
		/// 
		/// Updates actor's Zone and PhysicsVolume.
		/// </summary>
        /// <param name="Actor"></param>
        /// <param name="???"></param>
        /// <returns></returns>
		public bool MoveActor
		(
			Actor			Actor,
			Object.Vector	Delta,
			Object.Rotator	NewRotation,
			int			MoveFlags,
			out FCheckResult Hit
		)
		{
			NativeMarkers.MarkUnimplemented();
			Actor.Location += Delta;
			Actor.Rotation = NewRotation;
			Hit = default;
			return true;
			#if false
			Hit = default;
			
			//SCOPE_CYCLE_COUNTER(STAT_MoveActorTime);

			//check(Actor!=NULL);

		#if false//defined(SHOW_MOVEACTOR_TAKING_LONG_TIME) || LOOKING_FOR_PERF_ISSUES
			DWORD MoveActorTakingLongTime = 0;
			CLOCK_CYCLES(MoveActorTakingLongTime);
		#endif
			if ( Actor.bDeleteMe )
			{
				//debugf(TEXT("%s deleted move physics %d"),*Actor.GetName(),Actor.Physics);
				return false;
			}
			if( (Actor.bStatic || !Actor.bMovable) && HasBegunPlay() )
				return false;

			// Init CheckResult
			Hit.Actor = null;
			Hit.Time = 1f;

		#if false//!FINAL_RELEASE
			// Check to see if this move is illegal during this tick group
			if (InTick && TickGroup == TG_DuringAsyncWork && Actor.bBlockActors)
			{
				debugf(NAME_Error,TEXT("Can't move collidable actor (%s) during async work!"),*Actor.GetName());
			}
		#endif

			// Set up.
			float DeltaSize;
			Vector DeltaDir;
			if( Delta.IsZero() )
			{
				// Skip if no vector or rotation.
				if( NewRotation==Actor.Rotation && !Actor.bAlwaysEncroachCheck )
				{
					return true;
				}
				DeltaSize = 0f;
				DeltaDir = Delta;
			}
			else
			{
				DeltaSize = Delta.Size();
				DeltaDir = Delta/DeltaSize;
			}

			UBOOL bNoFail = MoveFlags & MOVE_NoFail;
			UBOOL bIgnoreBases = MoveFlags & MOVE_IgnoreBases;

			FMemMark Mark(GMem);
			INT     MaybeTouched = 0;
			FCheckResult* FirstHit = NULL;
			FVector FinalDelta = Delta;
			FRotator OldRotation = Actor.Rotation;
			UBOOL bMovementOccurred = TRUE;

			if ( Actor.IsEncroacher() )
			{
				if( Actor.bNoEncroachCheck || !Actor.bCollideActors || bNoFail )
				{
					// Update the location.
					Actor.Location += FinalDelta;
					Actor.Rotation = NewRotation;

					// Update any collision components.  If we are in the Tick phase, only upgrade components with collision.
					// This is done before moving attached actors so they can test for encroachment based on the correct mover position.
					// It is done before touch so that components are correctly up-to-date when we call Touch events. Things like
					// Kismet's touch event do an IsOverlapping - which requires the component to be in the right location.
					// This will not fix all problems with components being out of date though - for example, attachments of an Actor are not 
					// updated at this point.
					Actor.ForceUpdateComponents( GWorld.InTick );
				}
				else if( CheckEncroachment( Actor, Actor.Location + FinalDelta, NewRotation, 1 ) )
				{
					// Abort if encroachment declined.
					Mark.Pop();
					return false;
				}
				// if checkencroachment() doesn't fail, collision components will have been updated
			}
			else
			{
				// Perform movement collision checking if needed for this actor.
				if( (Actor.bCollideActors || Actor.bCollideWorld) &&
					Actor.CollisionComponent &&
					(DeltaSize != 0f) )
				{
					// Check collision along the line.
					int TraceFlags = 0;
					if( MoveFlags & MOVE_TraceHitMaterial )
					{
						TraceFlags |= TRACE_Material;
					}
					
					if( Actor.bCollideActors )
					{
						TraceFlags |= TRACE_Pawns | TRACE_Others | TRACE_Volumes;
					}

					if( Actor.bCollideWorld )
					{
						TraceFlags |= TRACE_World;
					}

					if( Actor.bCollideComplex )
					{
						TraceFlags |= TRACE_ComplexCollision;
					}

					FVector ColCenter;

					if( Actor.CollisionComponent.IsValidComponent() )
					{
						if( !Actor.CollisionComponent.IsAttached() )
						{
							appErrorf(TEXT("%s collisioncomponent %s not initialized deleteme %d"),*Actor.GetName(), *Actor.CollisionComponent.GetName(), Actor.bDeleteMe);
						}
						ColCenter = Actor.CollisionComponent.Bounds.Origin;
					}
					else
					{
						ColCenter = Actor.Location;
					}

					FirstHit = MultiLineCheck
					(
						GMem,
						ColCenter + Delta,
						ColCenter,
						Actor.GetCylinderExtent(),
						TraceFlags,
						Actor
					);

					// Handle first blocking actor.
					if( Actor.bCollideWorld || Actor.bBlockActors )
					{
						Hit = FCheckResult(1.f);
						for( FCheckResult* Test = FirstHit; Test; Test = Test.GetNext() )
						{
							if( (!bIgnoreBases || !Actor.IsBasedOn(Test.Actor)) && !Test.Actor.IsBasedOn(Actor) )
							{
								MaybeTouched = 1;
								if( Actor.IsBlockedBy(Test.Actor,Test.Component) )
								{
									Hit = *Test;
									break;
								}
							}
						}
						/* logging for stuck in collision
						if ( Hit.bStartPenetrating && Actor.GetAPawn() )
						{
							if ( Hit.Actor )
								debugf(TEXT("Started penetrating %s time %f dot %f"), *Hit.Actor.GetName(), Hit.Time, (Delta.SafeNormal() | Hit.Normal));
							else
								debugf(TEXT("Started penetrating no actor time %f dot %f"), Hit.Time, (Delta.SafeNormal() | Hit.Normal));
						}
						*/
						FinalDelta = Delta * Hit.Time;
					}
				}

				if ( bMovementOccurred )
				{
					// Update the location.
					Actor.Location += FinalDelta;
					Actor.Rotation = NewRotation;

					// Update any collision components.  If we are in the Tick phase (and not in the final component update phase), only upgrade components with collision.
					// This is done before moving attached actors so they can test for encroachment based on the correct mover position.
					// It is done before touch so that components are correctly up-to-date when we call Touch events. Things like
					// Kismet's touch event do an IsOverlapping - which requires the component to be in the right location.
					// This will not fix all problems with components being out of date though - for example, attachments of an Actor are not 
					// updated at this point.
					Actor.ForceUpdateComponents( GWorld.InTick && !GWorld.bPostTickComponentUpdate );
				}
			}

			// Move the based actors (after encroachment checking).
			if( (Actor.Attached.Num() > 0) && bMovementOccurred )
			{
				// Move base.
				FRotator ReducedRotation(0,0,0);

				FMatrix OldMatrix = FRotationMatrix( OldRotation ).Transpose();
				FMatrix NewMatrix = FRotationMatrix( NewRotation );
				UBOOL bRotationChanged = (OldRotation != Actor.Rotation);
				if( bRotationChanged )
				{
					ReducedRotation = FRotator( ReduceAngle(Actor.Rotation.Pitch)	- ReduceAngle(OldRotation.Pitch),
												ReduceAngle(Actor.Rotation.Yaw)	- ReduceAngle(OldRotation.Yaw)	,
												ReduceAngle(Actor.Rotation.Roll)	- ReduceAngle(OldRotation.Roll) );
				}

				// Calculate new transform matrix of base actor (ignoring scale).
				FMatrix BaseTM = FRotationTranslationMatrix(Actor.Rotation, Actor.Location);

				FSavedPosition* SavedPositions = NULL;

				for( INT i = 0; i<Actor.Attached.Num(); i++ )
				{
					// For non-skeletal based actors. Skeletal-based actors are handled inside USkeletalMeshComponent::Update
					AActor* Other = Actor.Attached(i);
					if ( Other && !Other.BaseSkelComponent )
					{
						SavedPositions = new(GMem) FSavedPosition(Other, Other.Location, Other.Rotation, SavedPositions);

						FVector   RotMotion( 0, 0, 0 );
						FCheckResult OtherHit(1.f);
						UBOOL bMoveFailed = FALSE;
						if( Other.Physics == PHYS_Interpolating || (Other.bHardAttach && !Other.bBlockActors) )
						{
							FRotationTranslationMatrix HardRelMatrix(Other.RelativeRotation, Other.RelativeLocation);
							FMatrix NewWorldTM = HardRelMatrix * BaseTM;
							FVector NewWorldPos = NewWorldTM.GetOrigin();
							FRotator NewWorldRot = NewWorldTM.Rotator();
							MoveActor( Other, NewWorldPos - Other.Location, NewWorldRot, MOVE_IgnoreBases, OtherHit );
							bMoveFailed = (OtherHit.Time < 1.f) || (NewWorldRot != Other.Rotation);
						}
						else if ( Other.bIgnoreBaseRotation )
						{
							// move attached actor, ignoring effects of any changes in its base's rotation.
							MoveActor( Other, FinalDelta, Other.Rotation, MOVE_IgnoreBases, OtherHit );
						}
						else
						{
							FRotator finalRotation = Other.Rotation + ReducedRotation;

							if( bRotationChanged )
							{
								Other.UpdateBasedRotation(finalRotation, ReducedRotation);

								// Handle rotation-induced motion.
								RotMotion = NewMatrix.TransformFVector( OldMatrix.TransformFVector( Other.RelativeLocation ) ) - Other.RelativeLocation;
							}
							// move attached actor
							MoveActor( Other, FinalDelta + RotMotion, finalRotation, MOVE_IgnoreBases, OtherHit );
						}

						if( !bNoFail && !bMoveFailed &&
							// If neither actor should check for encroachment, skip overlapping test
						   ((!Actor.bNoEncroachCheck || !Other.bNoEncroachCheck ) &&
							 Other.IsBlockedBy( Actor, Actor.CollisionComponent )) )
						{
							// check if encroached
							// IsOverlapping() returns false for based actors, so temporarily clear the base.
							UBOOL bStillBased = (Other.Base == Actor);
							if ( bStillBased )
								Other.Base = NULL;
							UBOOL bStillEncroaching = Other.IsOverlapping(Actor);
							if ( bStillBased )
								Other.Base = Actor;
							// if encroachment declined, move back to old location
							if ( bStillEncroaching && Actor.eventEncroachingOn(Other) )
							{
								bMoveFailed = TRUE;
							}
						}
						if ( bMoveFailed )
						{
							Actor.Location -= FinalDelta;
							Actor.Rotation = OldRotation;
							Actor.ForceUpdateComponents( GWorld.InTick );
							for( FSavedPosition* Pos = SavedPositions; Pos!=NULL; Pos = Pos.GetNext() )
							{
								if ( Pos.Actor && !Pos.Actor.bDeleteMe )
								{
									MoveActor( Pos.Actor, Pos.OldLocation - Pos.Actor.Location, Pos.OldRotation, MOVE_IgnoreBases, OtherHit );
									if (bRotationChanged)
									{
										Pos.Actor.ReverseBasedRotation();
									}
								}
							}
							Mark.Pop();
							return 0;
						}
					}
				}
			}

			// update relative location of this actor
			if( Actor.Base && !Actor.bHardAttach && Actor.Physics != PHYS_Interpolating && !Actor.BaseSkelComponent )
			{
				Actor.RelativeLocation = Actor.Location - Actor.Base.Location;
				
				if( !Actor.Base.bWorldGeometry && (OldRotation != Actor.Rotation) )
				{
					Actor.UpdateRelativeRotation();
				}
			}

			// Handle bump and touch notifications.
			if( Hit.Actor )
			{
				// Notification that Actor has bumped against the level.
				if( Hit.Actor.bWorldGeometry )
				{
					Actor.NotifyBumpLevel(Hit.Location, Hit.Normal);
				}
				// Notify first bumped actor unless it's the level or the actor's base.
				else if( !Actor.IsBasedOn(Hit.Actor) )
				{
					// Notify both actors of the bump.
					Hit.Actor.NotifyBump(Actor, Actor.CollisionComponent, Hit.Normal);
					Actor.NotifyBump(Hit.Actor, Hit.Component, Hit.Normal);
				}
			}

			// Handle Touch notifications.
			if( MaybeTouched || (!Actor.bBlockActors && !Actor.bCollideWorld && Actor.bCollideActors) )
			{
				for( FCheckResult* Test = FirstHit; Test && Test.Time<Hit.Time; Test = Test.GetNext() )
				{
					if ( (!bIgnoreBases || !Actor.IsBasedOn(Test.Actor)) &&
						(!Actor.IsBlockedBy(Test.Actor,Test.Component)) && Actor != Test.Actor)
					{
						Actor.BeginTouch(Test.Actor, Test.Component, Test.Location, Test.Normal);
					}
				}
			}

			// UnTouch notifications.
			Actor.UnTouchActors();

			// Set actor zone.
			Actor.SetZone(FALSE,FALSE);
			Mark.Pop();

			// Update physics 'pushing' body.
			Actor.UpdatePushBody();

		#if false//defined(SHOW_MOVEACTOR_TAKING_LONG_TIME) || LOOKING_FOR_PERF_ISSUES
			UNCLOCK_CYCLES(MoveActorTakingLongTime);
			FLOAT MSec = MoveActorTakingLongTime * GSecondsPerCycle * 1000.f;
			if( MSec > SHOW_MOVEACTOR_TAKING_LONG_TIME_AMOUNT )
			{
				debugf( NAME_PerfWarning, TEXT("%10f executing MoveActor for %s"), MSec, *Actor->GetFullName() );
			}
		#endif

			// Return whether we moved at all.
			return Hit.Time>0f;
			#endif
		}
    }
}