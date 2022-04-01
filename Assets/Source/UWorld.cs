namespace MEdge.Engine
{
	using System;
	using System.Collections.Generic;
    using Core;
    using Source;
    using TdGame;
    using Object = Core.Object;
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



    public partial class UWorld : IUWorld
    {
        public bool HasBegunPlay{ get; private set; }
        public WorldInfo WorldInfo{ get; private set; }

        Engine _engine = new TdGameEngine();



        public float GetDeltaSeconds() => WorldInfo.DeltaSeconds;
        GameInfo GetGameInfo() => GetWorldInfo().Game;

        static UWorld()
        {
            UWorldBridge.GetUWorld = () => Instance;
        }

        static void InitWorld()
        {
	        _instance.LevelStartup();
	        var player = _classImp<LocalPlayer>.Singleton.New( _instance._engine );
	        Core.String error = default;
	        _instance.SpawnPlayActor( player, Actor.ENetRole.ROLE_Authority, ref error, 0 );
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

            var actors = new List<(Actor, Vector, Object.Rotator)>{ (gameInfo, default, default) };
            LoadDataFromEngine( actors );
            
            foreach( var (actor, _, _) in actors )
                _instance.WorldInfo._allActors.Add( actor );

            foreach( var (actor, loc, rot) in actors )
            {
                if( actor.Tag == default )
                    actor.Tag = actor.Class.Name;

                actor.CreationTime = 0f;
                actor.WorldInfo = WorldInfo;
                actor.Location = loc;
                actor.Rotation = rot;
                actor.PhysicsVolume = WorldInfo.PhysicsVolume ?? throw new System.NullReferenceException();
            }
            
            foreach( var (actor, _, _) in actors )
                actor.SetDefaultCollisionType();

            foreach( var (actor, _, _) in actors )
                actor.PreBeginPlay();

            foreach( var (actor, _, _) in actors )
                actor.PostBeginPlay();
            
            WorldInfo.bStartup = false; // MAYBE ?
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



        public TClass LoadAsset<TClass>( Core.String assetPath ) where TClass : new() => Asset.LoadAsset<TClass>( assetPath );

        
        
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
			if( Class == null )
			{
				//debugf( NAME_Warning, TEXT("SpawnActor failed because no class was specified") );
				LogError("SpawnActor failed because no class was specified");
				System.Diagnostics.Debugger.Break();
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
			}
			else if( Class is ClassT<Actor> == false )
			{
				//debugf( NAME_Warning, TEXT("SpawnActor failed because %s is not an actor class"), *Class->GetName() );
				System.Diagnostics.Debugger.Break();
				return null;
			}*/
			else if( bBegunPlay && (Class.DefaultAs<Actor>().bStatic || Class.DefaultAs<Actor>().bNoDelete) )
			{
				System.Diagnostics.Debugger.Break();
				//debugf( NAME_Warning, TEXT("SpawnActor failed because class %s has bStatic or bNoDelete"), *Class->GetName() );
				LogError($"SpawnActor failed because class {Class.Name} has bStatic or bNoDelete");
				if ( !bNoFail )
					return null;		
			}
			else if (Template != null && Template.Class != Class)
			{
				System.Diagnostics.Debugger.Break();
				//debugf(NAME_Warning, TEXT("SpawnActor failed because template class (%s) does not match spawn class (%s)"), *Template->GetClass()->GetName(), *Class->GetName());
				LogError($"SpawnActor failed because template class ({Template.Class.Name}) does not match spawn class ({Class.Name})");
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
				LogError($"Can't spawn collidable actor ({Class.Name}) during async work!");
				System.Diagnostics.Debugger.Break();
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
					LogError($"SpawnActor failed because of collision at the spawn location [{Class.Name}]");
					System.Diagnostics.Debugger.Break();
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
				System.Diagnostics.Debugger.Break();
				if ( bBegunPlay )
				{
					//appErrorf(TEXT("Spawned actor %s with a collision component %s that is not in the Components array."),*Actor->GetFullName(),*Actor->CollisionComponent->GetFullName());
					LogError($"Spawned actor {Actor.Name} with a collision component {Actor.CollisionComponent.Name} that is not in the Components array.");
				}
				else
				{
					//debugf( NAME_Warning, TEXT("Spawned actor %s with a collision component %s that is not in the Components array."),*Actor->GetFullName(),*Actor->CollisionComponent->GetFullName() );
					LogError($"Spawned actor {Actor.Name} with a collision component {Actor.CollisionComponent.Name} that is not in the Components array.");
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
				DecFn.Exchange( ref Actor.Role, ref Actor.RemoteRole );
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
					System.Diagnostics.Debugger.Break();
					//debugf(NAME_DevSpawn, TEXT("SpawnActor destroyed [%s] after spawning because it was encroaching on another Actor"), *Actor->GetName());
					LogError($"SpawnActor destroyed {Actor.Name} after spawning because it was encroaching on another Actor");
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
		
		
		interface IProcessor
		{
			void Update( float deltaTime );
			void OnDestroy();
		}
    }
}