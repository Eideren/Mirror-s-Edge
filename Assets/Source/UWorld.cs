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



    public partial class UWorld : UnityEngine.MonoBehaviour, IUWorld
    {
        public static UWorld Instance => GetInstance();
        public bool HasBegunPlay{ get; private set; }
        Actor _defaultOuter;
        WorldInfo _worldInfo;
        
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

            UnityEngine.Time.timeScale = this._worldInfo.TimeDilation;
            var deltaTime = UnityEngine.Time.deltaTime;// * this._worldInfo.TimeDilation;
            deltaTime = deltaTime > 0.4f ? 0.4f : deltaTime < 0.0005f ? 0.0005f : deltaTime;
            this._worldInfo.RealTimeSeconds = UnityEngine.Time.realtimeSinceStartup;
            this._worldInfo.DeltaSeconds = deltaTime;
            this._worldInfo.SavedDeltaSeconds = deltaTime; // no clue for this one
            this._worldInfo.TimeSeconds += deltaTime;
            this._worldInfo.AudioTimeSeconds += deltaTime;
            

            _actorsThisFrame.Clear();
            foreach( var actor in _worldInfo._allActors )
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
            var actors = _worldInfo._allActors;
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
            gameInfo.WorldInfo = _worldInfo = new WorldInfo
            {
                PhysicsVolume = new DefaultPhysicsVolume(),
                Game = gameInfo,
            };

            HasBegunPlay = true;
            _worldInfo.bBegunPlay = true;
            _worldInfo.bStartup = true;
            
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
                _instance._worldInfo._allActors.Add( actor );

            foreach( var (actor, go) in actors )
            {
                if( actor.Tag == default )
                    actor.Tag = actor.Class.Name;

                actor.CreationTime = UnityEngine.Time.time;
                actor.WorldInfo = _worldInfo;
                actor.Location = go.transform.position.ToUnrealPos();
                actor.Rotation = (Object.Rotator)go.transform.rotation;
                actor.PhysicsVolume = _worldInfo.PhysicsVolume ?? throw new System.NullReferenceException();
            }
            
            foreach( var (actor, _) in actors )
                SetCollisionType( actor );

            foreach( var (actor, _) in actors )
                actor.PreBeginPlay();

            foreach( var (actor, _) in actors )
                actor.PostBeginPlay();
            
            foreach( var (actor, _) in actors )
                actor.SetInitialState();
            
            _worldInfo.bStartup = false; // MAYBE ?
        }



        void PlayerLogIn()
        {
            // https://wiki.beyondunreal.com/Legacy:Chain_Of_Events_When_A_Player_Logs_In
            String err = default;
            _worldInfo.Game.PreLogin( default, default, ref err );
            var controller = _worldInfo.Game.Login( default, "?Character=TdPlayerPawn", ref err );
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
            _worldInfo.Game.PostLogin( controller );
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
            if ( (actorTemplateCopy.bCollideWhenPlacing != false && _worldInfo.NetMode != (WorldInfo.ENetMode)3) && !bNoCollisionFail )
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
            constructedActor.WorldInfo = _worldInfo;
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
            constructedActor.PhysicsVolume = _worldInfo.PhysicsVolume ?? throw new System.NullReferenceException();
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
            
            _instance._worldInfo._allActors.Add( constructedActor );
            return constructedActor;
		}
    }
}