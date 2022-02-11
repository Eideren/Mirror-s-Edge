namespace MEdge.Engine
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Core;
    using Source;
    using TdGame;
	using UnityEngine;
	using UnityEngine.Events;
    using UnityEngine.SceneManagement;
    using V3 = UnityEngine.Vector3;
    using Collider = UnityEngine.Collider;
    using Object = Core.Object;
    using static UnityEngine.Debug;
    using String = Core.String;
    using Vector = Core.Object.Vector;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using UINT = System.UInt32;
	using BOOL = System.Boolean;
	using UBOOL = System.Boolean;
	using BYTE = System.Byte;
	using FVector = MEdge.Core.Object.Vector;
	using FRotator = MEdge.Core.Object.Rotator;
	using FQuat = MEdge.Core.Object.Quat;
	using FMatrix = MEdge.Core.Object.Matrix;
	using FCheckResult = MEdge.Source.DecFn.CheckResult;



    public partial class UWorld : UnityEngine.MonoBehaviour, IUWorld
    {
        public static UWorld Instance => GetInstance();
        public bool HasBegunPlay{ get; private set; }
        Actor _defaultOuter;
        public WorldInfo WorldInfo{ get; private set; }
        public ConcurrentQueue<Action> ScheduleInMainLoop = new ConcurrentQueue<Action>();

        Engine _engine = new TdGameEngine();
        SortedList<Actor, Actor> _actorsThisFrame = new SortedList<Actor, Actor>(new ActorTickComparer());

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



        public ulong FrameId{ get; private set; }

        public float GetDeltaSeconds() => WorldInfo.DeltaSeconds;

        class ActorTickComparer : IComparer<Actor>
        {
	        public int Compare(Actor x, Actor y)
	        {
		        if(ReferenceEquals(x, y))
			        return 0;
		        
		        int result = x.TickGroup.CompareTo(y.TickGroup);

		        if (result == 0) // Same tickgroup, compare hashcode instead, possible equality but doesn't really matter
			        result = x.GetHashCode().CompareTo(y.GetHashCode());
		        
		        return result;
	        }
        }

        void Update()
        {
            // See UWorld::Tick
            
            FrameId++;
	        DecFn.CheckResult.Clear();
	        while( ScheduleInMainLoop.TryDequeue( out var a ) )
	        {
		        a();
	        }

	        if(ReferenceEquals( this, _instance ) == false)
                Destroy(this);

            if( this.WorldInfo.TimeDilation != 1f )
                throw new NotImplementedException();
            //UnityEngine.Time.timeScale = this.WorldInfo.TimeDilation;
            var deltaTime = UnityEngine.Time.deltaTime;// * this._worldInfo.TimeDilation;
            deltaTime = deltaTime > 0.4f ? 0.4f : deltaTime < 0.0005f ? 0.0005f : deltaTime;
            this.WorldInfo.RealTimeSeconds = UnityEngine.Time.realtimeSinceStartup;
            this.WorldInfo.DeltaSeconds = deltaTime;
            this.WorldInfo.SavedDeltaSeconds = deltaTime; // no clue for this one
            this.WorldInfo.TimeSeconds += deltaTime;
            this.WorldInfo.AudioTimeSeconds += deltaTime;
            

            _actorsThisFrame.Clear();
            foreach( var actor in WorldInfo._allActors )
                _actorsThisFrame.Add(actor, actor);
            
            foreach( var actor in _actorsThisFrame.Values )
            {
                if( actor is PlayerController pc )
                {
                    #warning debug only
                    SampleInput( pc.PlayerInput as TdPlayerInput, pc as TdPlayerController, deltaTime );
                }
            }

            TickActors(this, deltaTime, ELevelTick.LEVELTICK_All, _actorsThisFrame.Values);

            foreach( var actor in _actorsThisFrame.Values )
                actor.ConditionalUpdateComponents();

            foreach( var actor in _actorsThisFrame.Values )
            {
                if( actor is PlayerController PC && PC.PlayerCamera )
                    PC.PlayerCamera.UpdateCamera(deltaTime);
            }
            
            
            foreach( var actor in _actorsThisFrame.Values )
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
            while( ScheduleInMainLoop.TryDequeue( out var a ) )
            {
	            a();
            }
        }



        void TickActors(UWorld World,FLOAT DeltaSeconds, ELevelTick TickType, IList<Actor> DeferredList/*FDeferredTickList& DeferredList*/)
        {
	        #if STATS
			const DWORD Counter = (DWORD)STAT_PreAsyncTickTime - World->TickGroup;
			SCOPE_CYCLE_COUNTER(Counter);
	        #endif
	        //World->NewlySpawned.Empty();
	        
	        // Use the specified iterator to iterate through the list of actors
	        // that should be ticked (ticking group dependent)
	        for (int i = 0; i < DeferredList.Count; i++)
	        {
		        Actor Actor = DeferredList[i];//*It;
		        // Tick this actor if it isn't dead and it isn't being deferred
		        if (Actor.ActorIsPendingKill() == FALSE/* && DeferredList.ConditionalDefer(Actor) == FALSE*/)
		        {
			        //checkf(!Actor->HasAnyFlags(RF_Unreachable), TEXT("%s"), *Actor->GetFullName());
			        UBOOL bTicked;
			        {
				        //TRACK_DETAILED_TICK_STATS(Actor);
				        bTicked = Actor.Tick(DeltaSeconds*Actor.CustomTimeDilation,TickType);
			        }

			        // If this actor actually ticked, ticks it's components
			        if (bTicked == TRUE)
			        {
				        //debugfSlow(NAME_DevTick,TEXT("Ticked actor (%s) in group (%d)"), Actor.GetName(),(INT)GWorld.TickGroup);
				        #if STATS
						const DWORD Counter2 = (DWORD)STAT_PreAsyncActorsTicked - World->TickGroup;
						INC_DWORD_STAT(Counter2);
				        #endif
				        TickActorComponents(Actor,DeltaSeconds,TickType,DeferredList);
			        }
		        }
	        }

	        // If an actor was spawned during the async work, tick it in the post
	        // async work, so that it doesn't try to interact with the async threads
	        /*if (World->TickGroup == TG_DuringAsyncWork)
	        {
		        DeferNewlySpawned(World,DeferredList);
	        }
	        else
	        {
		        TickNewlySpawned(World,DeltaSeconds,TickType);
	        }*/
        }
        
        
        void TickActorComponents(Actor Actor,FLOAT DeltaSeconds,ELevelTick TickType, IList<Actor> DeferredList/*FDeferredTickList* DeferredList*/)
        {
	        #if STATS
	const DWORD Counter = (DWORD)STAT_PreAsyncComponentTickTime - GWorld->TickGroup;
	SCOPE_CYCLE_COUNTER(Counter);
	        #endif
	        UBOOL bShouldTick = ((TickType != ELevelTick.LEVELTICK_ViewportsOnly) ||
	                                   Actor.PlayerControlled());
	        // Update components. We do this after the position has been updated so 
	        // stuff like animation can update using the new position.
	        for (INT ComponentIndex = 0; ComponentIndex < Actor.AllComponents.Num();
		        ComponentIndex++)
	        {
		        ActorComponent ActorComp = Actor.AllComponents[ComponentIndex];
		        if (ActorComp != null)
		        {
			        if (bShouldTick ||
			            (ActorComp.bTickInEditor && !GWorld.HasBegunPlay))
			        {
				        // Don't tick this component if it was deferred until later
				        if (true/*DeferredList == null ||
				            DeferredList->ConditionalDefer(ActorComp) == FALSE*/)
				        {
					        #if STATS
							const DWORD Counter2 = (DWORD)STAT_PreAsyncComponentsTicked - GWorld->TickGroup;
							INC_DWORD_STAT(Counter2);
					        #endif
					        {
						        //TRACK_DETAILED_TICK_STATS(ActorComp);
						        // Tick the component
						        ActorComp.ConditionalTick(DeltaSeconds);
					        }
					        // Log it for debugging
					        //debugfSlow(NAME_DevTick,TEXT("Ticked component (%s) in group (%d)"), ActorComp.GetName(),(INT)GWorld.TickGroup);
				        }
			        }
		        }
	        }
        }



        public PlayerController SpawnPlayActor(Player Player, Actor.ENetRole RemoteRole,/* const FURL& URL,*/ref String Error, byte InNetPlayerIndex)
        {
            //Error=TEXT("");

            // Get package map.
            /*UPackageMap*    PackageMap = NULL;
            UNetConnection* Conn       = Cast<UNetConnection>( Player );
            if( Conn )
                PackageMap = Conn->PackageMap;*/

            // Make the option string.
            /*FString Options;
            for( INT i=0; i<GameEngine.URL.Op.Num(); i++ )
            {
                Options += TEXT('?');
                Options += GameEngine.URL.Op(i);
            }*/

            // Tell UnrealScript to log in.
            //PlayerController Actor = GetGameInfo().Login( *GameEngine.URL.Portal, Options, Error );
            //
            PlayerController Actor = GetGameInfo().Login( default, "?Character=TdPlayerPawn", ref Error );
            if( !Actor )
            {
                throw new Exception();
                //debugf( NAME_Warning, TEXT("Login failed: %s"), *Error);
                //return NULL;
            }

            // Possess the newly-spawned player.
            Actor.NetPlayerIndex = InNetPlayerIndex;
            Actor.SetPlayer( Player );
            //debugf(TEXT("%s got player %s"), *Actor->GetName(), *Player->GetName());
            Actor.Role       = GameInfo.ENetRole.ROLE_Authority;
            Actor.RemoteRole = RemoteRole;
            GetGameInfo().PostLogin( Actor );

            return Actor;
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
            DecFn.SetWorld(_instance);
            _instance._defaultOuter = new Actor();
            _instance.LevelStartup();
            var player = _classImp<LocalPlayer>.Singleton.New( _instance._engine );
            String error = default;
            _instance.SpawnPlayActor( player, Actor.ENetRole.ROLE_Authority, ref error, 1 );

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



        GameInfo GetGameInfo() => GetWorldInfo().Game;
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
            
            WorldInfo.bStartup = false; // MAYBE ?
        }



        public ConditionalWeakTable<object, UnityEngine.Object> UScriptToUnity => Asset.UScriptToUnity;
        public TClass LoadAsset<TClass>( Core.String assetPath ) where TClass : new() => Asset.LoadAsset<TClass>( assetPath );



        public T SpawnActor<T>( ClassT<T> c ) where T : Actor => E_UWorld_SpawnActor( c, default, default, default, default, default, default, default, default, default );



        public T E_UWorld_SpawnActor<T>( Core.ClassT<T> Class, name InName, Object.Vector Location, Object.Rotator Rotation, Actor Template, bool bNoCollisionFail, int bRemoteOwned, Actor Owner, Pawn Instigator, bool bNoFail ) where T : Actor
        {
            //SCOPE_CYCLE_COUNTER(STAT_SpawnActorTime);

			//check(CurrentLevel);
			//check(GIsEditor || (CurrentLevel == PersistentLevel));
			//check(GWorld == this || GIsCooking);

			// It's not safe to call UWorld accessor functions till the world info has been spawned.
			UBOOL bBegunPlay = HasBegunPlay;

			// Make sure this class is spawnable.
			if( !(Class != null) )
			{
				//debugf( NAME_Warning, TEXT("SpawnActor failed because no class was specified") );
				Break();
				return null;
			}
			/*if( Class.ClassFlags & CLASS_Deprecated )
			{
				//debugf( NAME_Warning, TEXT("SpawnActor failed because class %s is deprecated"), *Class->GetName() );
				Break();
				return null;
			}
			if( Class.ClassFlags & CLASS_Abstract )
			{
				//debugf( NAME_Warning, TEXT("SpawnActor failed because class %s is abstract"), *Class->GetName() );
				Break();
				return null;
			}*/
			else if( /*!Class.IsChildOf(AActor::StaticClass())*/Class.DefaultAs<Actor>() == null )
			{
				//debugf( NAME_Warning, TEXT("SpawnActor failed because %s is not an actor class"), *Class->GetName() );
				Break();
				return null;
			}
			else if( bBegunPlay && (Class.DefaultAs<Actor>().bStatic || Class.DefaultAs<Actor>().bNoDelete) )
			{
				Break();
				//debugf( NAME_Warning, TEXT("SpawnActor failed because class %s has bStatic or bNoDelete"), *Class->GetName() );
				if ( !bNoFail )
					return null;		
			}
			else if (Template != null && Template.Class != Class)
			{
				Break();
				//debugf(NAME_Warning, TEXT("SpawnActor failed because template class (%s) does not match spawn class (%s)"), *Template->GetClass()->GetName(), *Class->GetName());
				if (!bNoFail)
				{
					return null;
				}
			}

		#if !FINAL_RELEASE
			// Check to see if this move is illegal during this tick group
			if (InTick /*&& TickGroup == TG_DuringAsyncWork*/&& false && Class.DefaultAs<Actor>().bBlockActors)
			{
				//debugf(NAME_Error,TEXT("Can't spawn collidable actor (%s) during async work!"),*Class->GetName());
				Break();
			}
		#endif

			// Use class's default actor as a template.
			if( !Template )
			{
				Template = Class.DefaultAs<Actor>();
			}
			//check(Template!=NULL);

			FVector NewLocation = Location;
			// Make sure actor will fit at desired location, and adjust location if necessary.
			if( (Template.bCollideWorld || (Template.bCollideWhenPlacing && (GetNetMode() != WorldInfo.ENetMode.NM_Client))) && !bNoCollisionFail )
			{
				if (!FindSpot(Template.GetCylinderExtent(), ref NewLocation, Template.bCollideComplex))
				{
					//debugfSuppressed( NAME_DevSpawn, TEXT("SpawnActor failed because of collision at the spawn location [%s]"), *Class->GetName() );
					Break();
					return null;
				}
			}

			// Spawn in the same level as the owner if we have one. @warning: this relies on the outer of an actor being the level.
			//ULevel* LevelToSpawnIn = Owner ? CastChecked<ULevel>(Owner->GetOuter()) : CurrentLevel;
			Actor Actor = Class.New();//ConstructObject<AActor>( Class, LevelToSpawnIn, InName, RF_Transactional, Template );
			if( Template != Class.DefaultAs<Actor>() )
				LogError($"{Class} Template ({Template.Name}) not yet implemented");
			//check(Actor);
			/*if ( GUndo )
			{
				GWorld.ModifyLevel( LevelToSpawnIn );
			}
			LevelToSpawnIn.Actors.AddItem( Actor );*/

		#if DEBUG_CHECKCOLLISIONCOMPONENTS || LOOKING_FOR_PERF_ISSUES
			INT numcollisioncomponents = 0;
			for(INT ComponentIndex = 0;ComponentIndex < Actor->Components.Num();ComponentIndex++)
			{
				UActorComponent* ActorComponent = Actor->Components(ComponentIndex);
				if( ActorComponent )
				{
					UPrimitiveComponent *C = Cast<UPrimitiveComponent>( ActorComponent );
					if ( C && C->ShouldCollide() )
					{
						numcollisioncomponents++;
					}
				}

				// most pawns are going to have a CylinderComponent (Unreal Physics) and then they are also
				// going to have a SkeletalMeshComponent (per body hit detection).  So we really care about
				// cases of 3 or more  components with collision.  If we are still lots of spam then we will
				// want to increase the num we are looking for 
				if ( numcollisioncomponents > 2 )
				{
					debugf( NAME_PerfWarning, TEXT("Actor has more 3 or more components which collide: "), *Actor->GetName());

					for(INT ComponentIndex = 0;ComponentIndex < Actor->Components.Num();ComponentIndex++)
					{
						if(Actor->Components(ComponentIndex))
						{
							UPrimitiveComponent *C = Cast<UPrimitiveComponent>(Actor->Components(ComponentIndex));
							if ( C && C->ShouldCollide() )
							{
								debugf( NAME_PerfWarning, TEXT("    -component with collision:  %s"), *C->GetName() );
							}
						}
					}
				}
			}	

			if ( Actor->bCollideActors && !Actor->IsA(AProjectile::StaticClass()) )
			{
				debugf( NAME_PerfWarning, TEXT("%s has bCollideActors set"),*Actor->GetFullName());
			}
		#endif

			// Detect if the actor's collision component is not in the components array, which is invalid.
			if(Actor.CollisionComponent && Actor.Components.Find(Actor.CollisionComponent) == -1)
			{
				Break();
				if ( bBegunPlay )
				{
					//appErrorf(TEXT("Spawned actor %s with a collision component %s that is not in the Components array."),*Actor->GetFullName(),*Actor->CollisionComponent->GetFullName());
				}
				else
				{
					//debugf( NAME_Warning, TEXT("Spawned actor %s with a collision component %s that is not in the Components array."),*Actor->GetFullName(),*Actor->CollisionComponent->GetFullName() );
				}
			}

			// Set base actor properties.
			if (Actor.Tag == default)
			{
				Actor.Tag = Class.Name;
			}
			Actor.bTicked		= !Ticked;
			Actor.CreationTime = GetTimeSeconds();
			Actor.WorldInfo	= GetWorldInfo();

			// Set network role.
			//check(Actor->Role==ROLE_Authority);
			if( bRemoteOwned != default )
			{
				Exchange( ref Actor.Role, ref Actor.RemoteRole );
			}

			// Set the actor's location and rotation.
			Actor.Location = NewLocation;
			Actor.Rotation = Rotation;

			// Initialize the actor's components.
			Actor.ConditionalForceUpdateComponents(FALSE,FALSE);

			// init actor's physics volume
			Actor.PhysicsVolume = GetWorldInfo().PhysicsVolume;

			// Set owner.
			Actor.SetOwner( Owner );

			// Set instigator
			Actor.Instigator = Instigator;

			// Initialise physics if we are in the game.
			if (bBegunPlay)
			{
				Actor.InitRBPhys();
			}

			// Send messages.
			if ( /*!GIsCooking*/true )
			{
				Actor.InitExecution();
				Actor.Spawned();
			}
			if(bBegunPlay)
			{
				Actor.PreBeginPlay();
				
				if( Actor.bDeleteMe && !bNoFail )
				{
					return null;
				}

				for(INT ComponentIndex = 0;ComponentIndex < Actor.Components.Num();ComponentIndex++)
				{
					if(Actor.Components[ComponentIndex])
					{
						Actor.Components[ComponentIndex].ConditionalBeginPlay();
					}
				}
			}

			// Check for encroachment.
			if( !bNoCollisionFail )
			{
				if( CheckEncroachment( Actor, Actor.Location, Actor.Rotation, true ) )
				{
					Break();
					//debugf(NAME_DevSpawn, TEXT("SpawnActor destroyed [%s] after spawning because it was encroaching on another Actor"), *Actor->GetName());
					DestroyActor( Actor );
					return null;
				}
			}
			else if ( Actor.bCollideActors )
			{
				Actor.FindTouchingActors();
				
				if( Actor.bDeleteMe && !bNoFail )
				{
					return null;
				}
			}

			if(bBegunPlay)
			{
				Actor.PostBeginPlay();
				
				if( Actor.bDeleteMe && !bNoFail )
				{
					return null;
				}
			}

			// Success: Return the actor.
			if( InTick )
			{
				NativeMarkers.MarkUnimplemented("Newly spawned will be ticked the next frame, not that important right now");
				//NewlySpawned.AddItem( Actor );
			}

			if ( !bBegunPlay )
			{
				// Set bDeleteMe to true so that when the initial undo record is made,
				// the actor will be treated as destroyed, in that undo an add will
				// actually work
				Actor.bDeleteMe = true;
				//Actor.Modify();
				Actor.bDeleteMe = false;
			}

			_instance.WorldInfo._allActors.Add( Actor );
			return (T)Actor;
		}



        public T E_UWorld_SpawnActor_Old<T>(Core.ClassT<T> SpawnClass, int a3, float a4, Object.Vector SpawnLocation, Object.Rotator SpawnRotation, Actor ActorTemplate, bool bNoCollisionFail, int networkRelatedParam, Actor SpawnOwner, Pawn Instigator, bool bProbablyNoFail) where T : Actor
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
    }
}