﻿namespace MEdge.Engine
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



    public class UWorld : UnityEngine.MonoBehaviour, IUWorld
    {
        public static UWorld Instance => GetInstance();
        public bool HasBegunPlay{ get; private set; }
        Actor _defaultOuter;
        WorldInfo _worldInfo;
        
        Engine _engine = new TdGameEngine();
        UnityEngine.BoxCollider _cacheCollider = new UnityEngine.BoxCollider();

        static UWorld _instance;
        static UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> _onSceneLoadedCached;
        static ConditionalWeakTable<TdPawn, PawnLink> Links = new ConditionalWeakTable<TdPawn, PawnLink>();



        static UWorld()
        {
            UWorldBridge.GetUWorld = () => Instance;
        }



        class PawnLink
        {
            public TdPawn Pawn;
            //AnimationPlayer _player;



            public void Update(float deltaTime)
            {
                ComputeVelocity_Stub(Pawn, deltaTime, Pawn.GroundSpeed, Pawn.PhysicsVolume.GroundFriction, 0, true );
                // Not exactly like this, depends on more stuff, but good approximation
                Pawn.Location += (Pawn.Velocity + Pawn.PhysicsVolume.ZoneVelocity * 25f) * deltaTime;
                
                /*_player ??= new AnimationPlayer( Clips, Asset.Get_AS_C1P_Unarmed,  (AnimNode) _window.LoadFile( File ) );
                _player.Sample( Pawn, Time.deltaTime, gameObject );
                Pawn.Mesh1p.Animations.*/
            }




            void ComputeVelocity_Stub( TdPawn p, float likelyTimeDelta, float mod_param_speed, float param_friction, int param_bStdDeceleration, bool bFixedTimeDeceleration )
            {
                var mod_currentMove__PawnMobility = p.GetMobilityMultiplier() * ( p.Moves[ (int) p.MovementState ]?.SpeedModifier ?? 1f );
                var mod_currentMove__PawnMobility__paramSpeed = mod_currentMove__PawnMobility * mod_param_speed;
                if ( bFixedTimeDeceleration && p.Acceleration.X == 0.0 && p.Acceleration.Y == 0.0 && p.Acceleration.Z == 0.0 )
                {                                       // 
                                                        // deceleration == true && acceleration == 0
                                                        // 
                    var remainingTime = likelyTimeDelta;    // Apply deceleration logic, also runs when idle
                    var velocityBeforeDeceleration = p.Velocity;
                    var velocityAfterDeceleration = new Object.Vector();
                    if ( likelyTimeDelta > 0.0 )
                    {
                        var brakingFrictionStrength = p.BrakingFrictionStrength;
                        while ( true )
                        {                               // 
                                                        // Every loop reduce by 0.0299999 until 'loop*0.0299999' >= 'someVectorMult' at which point reduce by the rest and stop loop
                                                        // This might be because decelerating using just the deltatime might diverge widely based on the deltatime value
                                                        // 
                            var timeSlice = 0.029999999f;
                            if ( remainingTime <= 0.029999999f )
                                timeSlice = remainingTime;// 
                                                        // Take the minimum between 0.0299... and remainingTime
                                                        // 
                            var tempVelY2 = p.Velocity.Y;
                            var reductionLeft = remainingTime - timeSlice;// 
                                                        // 
                                                        // 
                            var tempVelX = (float)((float)((float)(p.Velocity.X * 2.0) * timeSlice) * param_friction) * brakingFrictionStrength;
                            var miscUtility3Float = (float)((float)((float)(p.Velocity.Z * 2.0) * timeSlice) * param_friction) * brakingFrictionStrength;
                            var tempVelY = p.Velocity.Y - (float)((float)((float)((float)(tempVelY2 * 2.0) * timeSlice) * param_friction) * brakingFrictionStrength);
                            var tempVelZ2 = p.Velocity.Z - miscUtility3Float;
                            p.Velocity.X = p.Velocity.X - tempVelX;
                            p.Velocity.Y = tempVelY;
                            p.Velocity.Z = tempVelZ2;// 
                                                        // 
                                                        // p.Velocity -= p.Velocity * 2.0 * timeSlice * anotherVectorMult * brakingFrictionStrength
                                                        // 
                                                        // 
                            if ( (float)((float)((float)(p.Velocity.Y * velocityBeforeDeceleration.Y) + (float)(p.Velocity.Z * velocityBeforeDeceleration.Z)) + (float)(p.Velocity.X * velocityBeforeDeceleration.X)) > 0.0 )
                            {                           // 
                                                        // That's a dot comp, if previous velocity and current are in the same direction:
                                var scaledVelZ = 0.0;
                                velocityAfterDeceleration.X = (float)((float)(p.Velocity.X * timeSlice) * (float)(1.0 / likelyTimeDelta)) + velocityAfterDeceleration.X;
                                velocityAfterDeceleration.Y = (float)((float)(p.Velocity.Y * timeSlice) * (float)(1.0 / likelyTimeDelta)) + velocityAfterDeceleration.Y;
                                velocityAfterDeceleration.Z = (float)((float)(p.Velocity.Z * timeSlice) * (float)(1.0 / likelyTimeDelta)) + velocityAfterDeceleration.Z;// 
                                                        // velocityAfterDeceleration += (p.Velocity * timeSlice) * (1.0 / likelyTimeDelta);
                                                        // 
                            }
                            if ( reductionLeft <= 0.0 )
                                break;
                            remainingTime = reductionLeft;
                        }
                    }
                    p.Velocity = velocityAfterDeceleration;
                    if ( (float)((float)((float)(p.Velocity.Y * velocityBeforeDeceleration.Y) + (float)(p.Velocity.Z * velocityBeforeDeceleration.Z)) + (float)(p.Velocity.X * velocityBeforeDeceleration.X)) < 0.0
                      || (float)((float)((float)(p.Velocity.X * p.Velocity.X) + (float)(p.Velocity.Y * p.Velocity.Y)) + (float)(p.Velocity.Z * p.Velocity.Z)) < 100.0 )
                    {                                   // 
                                                        // velocity flipped direction or is lower than 100
                                                        // => set velocity to zero
                        p.Velocity.X = 0.0f;
                        p.Velocity.Y = 0.0f;
                        p.Velocity.Z = 0.0f;
                    }
                }
                p.Velocity *= 1.0f - (param_bStdDeceleration * likelyTimeDelta * param_friction);
                p.Velocity += p.Acceleration * likelyTimeDelta;
                if( (float) ( (float) ( (float) ( p.Velocity.X * p.Velocity.X ) + (float) ( p.Velocity.Y * p.Velocity.Y ) ) + (float) ( p.Velocity.Z * p.Velocity.Z ) ) > (float) ( mod_currentMove__PawnMobility__paramSpeed * mod_currentMove__PawnMobility__paramSpeed ) )
                {
                    p.Velocity = p.Velocity.SafeNormal() * mod_currentMove__PawnMobility__paramSpeed;
                }
            }
        }



        void Update()
        {
            if(ReferenceEquals( this, _instance ) == false)
                Destroy(this);

            var actors = _worldInfo._allActors;
            UnityEngine.Time.timeScale = this._worldInfo.TimeDilation;
            var deltaTime = UnityEngine.Time.deltaTime;// * this._worldInfo.TimeDilation;
            deltaTime = deltaTime > 0.4f ? 0.4f : deltaTime < 0.0005f ? 0.0005f : deltaTime;
            this._worldInfo.RealTimeSeconds = UnityEngine.Time.realtimeSinceStartup;
            this._worldInfo.DeltaSeconds = deltaTime;
            this._worldInfo.SavedDeltaSeconds = deltaTime; // no clue for this one
            this._worldInfo.TimeSeconds += deltaTime;
            this._worldInfo.AudioTimeSeconds += deltaTime;
            

            foreach( var actor in actors )
            {
                if( actor is PlayerController pc )
                {
                    pc.PlayerInput.Tick( deltaTime );
                    pc.PlayerTick( deltaTime );
                    #warning debug only
                    pc.PlayerInput.aBaseY = 1.0f;
                }
            }


            foreach( var actor in actors )
                if( actor.TickGroup == Object.ETickingGroup.TG_PreAsyncWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in actors )
                if( actor.TickGroup == Object.ETickingGroup.TG_DuringAsyncWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in actors )
                if( actor.TickGroup == Object.ETickingGroup.TG_PostAsyncWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in actors )
                if( actor.TickGroup == Object.ETickingGroup.TG_PostUpdateWork )
                    actor.Tick(deltaTime*actor.CustomTimeDilation);
            foreach( var actor in actors )
                if( actor is PlayerController pc )
                    pc.PlayerCamera?.UpdateCamera(deltaTime);
            
            foreach( var actor in actors )
            {
                if( actor is TdPawn pawn )
                {
                    if(Links.TryGetValue( pawn, out var link ) == false)
                        Links.Add( pawn, link = new PawnLink(){ Pawn = pawn } );
                    link.Update( deltaTime );
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
            
            var playerPawn = ( controller.Pawn as TdPlayerPawn );
            if( Asset.UScriptToUnity.TryGetValue( playerPawn.Mesh1p.SkeletalMesh, out var _smr ) )
            {
                UnityEngine.SkinnedMeshRenderer smr = (UnityEngine.SkinnedMeshRenderer) _smr;
                smr.transform.parent.gameObject.AddComponent<ActorDrivenTransform>().Actor = controller.Pawn;
            }
            if( Asset.UScriptToUnity.TryGetValue( playerPawn.Mesh3p.SkeletalMesh, out var _smr2 ) )
            {
                UnityEngine.SkinnedMeshRenderer smr = (UnityEngine.SkinnedMeshRenderer) _smr2;
                smr.transform.parent.gameObject.AddComponent<ActorDrivenTransform>().Actor = controller.Pawn;
            }
            if( Asset.UScriptToUnity.TryGetValue( playerPawn.Mesh1pLowerBody.SkeletalMesh, out var _smr3 ) )
            {
                UnityEngine.SkinnedMeshRenderer smr = (UnityEngine.SkinnedMeshRenderer) _smr3;
                smr.transform.parent.gameObject.AddComponent<ActorDrivenTransform>().Actor = controller.Pawn;
            }
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