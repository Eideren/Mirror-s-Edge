// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Actor : Object/*
		abstract
		native
		nativereplication
		hidecategories(Navigation)*/{
	public const int TRACEFLAG_Bullet = 1;
	public const int TRACEFLAG_PhysicsVolumes = 2;
	public const int TRACEFLAG_SkipMovers = 4;
	public const int TRACEFLAG_Blocking = 8;
	public const int TRACEFLAG_AIBlocking = 16;
	public const double REP_RBLOCATION_ERROR_TOLERANCE_SQ = 16.0f;
	public const double MINFLOORZ = 0.7;
	public const double ACTORMAXSTEPHEIGHT = 35.0;
	public const double RBSTATE_LINVELSCALE = 10.0;
	public const double RBSTATE_ANGVELSCALE = 1000.0;
	public const int RB_None = 0x00;
	public const int RB_NeedsUpdate = 0x01;
	public const int RB_Sleeping = 0x02;
	
	public enum EPhysics 
	{
		PHYS_None,
		PHYS_Walking,
		PHYS_Falling,
		PHYS_Swimming,
		PHYS_Flying,
		PHYS_Rotating,
		PHYS_Projectile,
		PHYS_Interpolating,
		PHYS_Spider,
		PHYS_Ladder,
		PHYS_RigidBody,
		PHYS_SoftBody,
		PHYS_WallRunning,
		PHYS_WallClimbing,
		PHYS_Unused,
		PHYS_MAX
	};
	
	public enum EMoveDir 
	{
		MD_Stationary,
		MD_Forward,
		MD_Backward,
		MD_Left,
		MD_Right,
		MD_Up,
		MD_Down,
		MD_MAX
	};
	
	public enum ENetRole 
	{
		ROLE_None,
		ROLE_SimulatedProxy,
		ROLE_AutonomousProxy,
		ROLE_Authority,
		ROLE_MAX
	};
	
	public enum ECollisionType 
	{
		COLLIDE_CustomDefault,
		COLLIDE_NoCollision,
		COLLIDE_BlockAll,
		COLLIDE_BlockWeapons,
		COLLIDE_TouchAll,
		COLLIDE_TouchWeapons,
		COLLIDE_BlockAllButWeapons,
		COLLIDE_TouchAllButWeapons,
		COLLIDE_MAX
	};
	
	public enum ETravelType 
	{
		TRAVEL_Absolute,
		TRAVEL_Partial,
		TRAVEL_Relative,
		TRAVEL_MAX
	};
	
	public enum EDoubleClickDir 
	{
		DCLICK_None,
		DCLICK_Left,
		DCLICK_Right,
		DCLICK_Forward,
		DCLICK_Back,
		DCLICK_Active,
		DCLICK_Done,
		DCLICK_MAX
	};
	
	public partial struct /*native */TimerData
	{
		public bool bLoop;
		public name FuncName;
		public float Rate;
		public float Count;
		public Object TimerObj;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024B242
	//		bLoop = false;
	//		FuncName = (name)"None";
	//		Rate = 0.0f;
	//		Count = 0.0f;
	//		TimerObj = default;
	//	}
	};
	
	public partial struct /*native transient */TraceHitInfo
	{
		[init] public Material Material;
		[init] public PhysicalMaterial PhysMaterial;
		[init] public int Item;
		[init] public int LevelIndex;
		[init] public name BoneName;
		[init, export, editinline] public PrimitiveComponent HitComponent;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024B45E
	//		Material = default;
	//		PhysMaterial = default;
	//		Item = 0;
	//		LevelIndex = 0;
	//		BoneName = (name)"None";
	//		HitComponent = default;
	//	}
	};
	
	public partial struct /*native transient */ImpactInfo
	{
		[init] public Actor HitActor;
		[init] public Object.Vector HitLocation;
		[init] public Object.Vector HitNormal;
		[init] public Object.Vector RayDir;
		[init] public Actor.TraceHitInfo HitInfo;
		[init] public float TracedDistance;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024B65E
	//		HitActor = default;
	//		HitLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HitNormal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RayDir = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HitInfo = new Actor.TraceHitInfo
	//		{
	//			Material = default,
	//			PhysMaterial = default,
	//			Item = 0,
	//			LevelIndex = 0,
	//			BoneName = (name)"None",
	//			HitComponent = default,
	//		};
	//		TracedDistance = 0.0f;
	//	}
	};
	
	public partial struct /*native transient */AnimSlotInfo
	{
		[init] public name SlotName;
		[init] public array<float> ChannelWeights;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024B8AE
	//		SlotName = (name)"None";
	//		ChannelWeights = default;
	//	}
	};
	
	public partial struct /*native transient */AnimSlotDesc
	{
		[init] public name SlotName;
		[init] public int NumChannels;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024B97A
	//		SlotName = (name)"None";
	//		NumChannels = 0;
	//	}
	};
	
	public partial struct RigidBodyState
	{
		public Object.Vector Position;
		public Object.Quat Quaternion;
		public Object.Vector LinVel;
		public Object.Vector AngVel;
		public byte bNewData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024BBB3
	//		Position = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Quaternion = new Quat
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		LinVel = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		AngVel = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		bNewData = 0;
	//	}
	};
	
	public partial struct RigidBodyContactInfo
	{
		public Object.Vector ContactPosition;
		public Object.Vector ContactNormal;
		public float ContactPenetration;
		public StaticArray<Object.Vector, Object.Vector>/*[2]*/ ContactVelocity;
		public StaticArray<PhysicalMaterial, PhysicalMaterial>/*[2]*/ PhysMaterial;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024BDFB
	//		ContactPosition = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		ContactNormal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		ContactPenetration = 0.0f;
	//		ContactVelocity = new StaticArray<Object.Vector, Object.Vector>/*[2]*/()
	//		{ 
	//			[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	// 		};
	//		PhysMaterial = new StaticArray<PhysicalMaterial, PhysicalMaterial>/*[2]*/()
	//		{ 
	//			[0] = default,
	//			[1] = default,
	// 		};
	//	}
	};
	
	public partial struct CollisionImpactData
	{
		public array<Actor.RigidBodyContactInfo> ContactInfos;
		public Object.Vector TotalNormalForceVector;
		public Object.Vector TotalFrictionForceVector;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024BFF7
	//		ContactInfos = default;
	//		TotalNormalForceVector = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		TotalFrictionForceVector = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct AsyncLineCheckResult
	{
		public int bCheckStarted;
		public int bCheckCompleted;
		public int bHit;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024C127
	//		bCheckStarted = 0;
	//		bCheckCompleted = 0;
	//		bHit = 0;
	//	}
	};
	
	public partial struct /*native */ReplicatedHitImpulse
	{
		public Object.Vector AppliedImpulse;
		public Object.Vector HitLocation;
		public name BoneName;
		public byte ImpulseCount;
		public bool bRadialImpulse;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024C29B
	//		AppliedImpulse = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HitLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		BoneName = (name)"None";
	//		ImpulseCount = 0;
	//		bRadialImpulse = false;
	//	}
	};
	
	public partial struct /*native */NavReference
	{
		[Category] public NavigationPoint Nav;
		[Category] [Const, editconst] public Object.Guid Guid;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0024C470
	//		Nav = default;
	//		Guid = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//	}
	};
	
	[Category] public bool bExludeHandMoves;
	[Category] public bool bExludeFootMoves;
	[Category] public bool bPhysXMutatable;
	[Const] public bool bStatic;
	[Category("Display")] [Const] public bool bHidden;
	[Const] public bool bNoDelete;
	[Const] public bool bDeleteMe;
	[Const, transient] public bool bTicked;
	[Const] public bool bOnlyOwnerSee;
	public bool bStasis;
	public bool bWorldGeometry;
	public bool bIgnoreRigidBodyPawns;
	public bool bOrientOnSlope;
	[Const] public bool bIgnoreEncroachers;
	public bool bPushedByEncroachers;
	public bool bDestroyedByInterpActor;
	[Const] public bool bRouteBeginPlayEvenIfStatic;
	[Const] public bool bIsMoving;
	public bool bAlwaysEncroachCheck;
	public bool bHasAlternateTargetLocation;
	[Const] public bool bNetTemporary;
	[Const] public bool bOnlyRelevantToOwner;
	[transient] public bool bNetDirty;
	public bool bAlwaysRelevant;
	public bool bReplicateInstigator;
	public bool bReplicateMovement;
	public bool bSkipActorPropertyReplication;
	public bool bUpdateSimulatedPosition;
	public bool bTearOff;
	public bool bOnlyDirtyReplication;
	[transient] public bool bDemoRecording;
	public bool bDemoOwner;
	public bool bForceDemoRelevant;
	[Const] public bool bNetInitialRotation;
	public bool bReplicateRigidBodyLocation;
	public bool bKillDuringLevelTransition;
	[Const] public bool bExchangedRoles;
	[Category("Advanced")] public bool bConsiderAllStaticMeshComponentsForStreaming;
	[Category("AI")] public bool bIgnoreForAITraces;
	[Category("Interaction")] public bool bInteractable;
	[Category("Interaction")] [Const] public bool bLOIObject;
	[Category("Debug")] public bool bDebug;
	public bool bPostRenderIfNotVisible;
	[transient] public bool bForceNetUpdate;
	[Const, transient] public bool bPendingNetUpdate;
	[Category("Attachment")] [Const] public bool bHardAttach;
	[Category("Attachment")] public bool bIgnoreBaseRotation;
	[Category("Attachment")] public bool bShadowParented;
	public bool bCanBeAdheredTo;
	public bool bCanBeFrictionedTo;
	public bool bHurtEntry;
	public bool bGameRelevant;
	[Const] public bool bMovable;
	public bool bDestroyInPainVolume;
	public bool bCanBeDamaged;
	public bool bShouldBaseAtStartup;
	public bool bPendingDelete;
	public bool bCanTeleport;
	[Const] public bool bAlwaysTick;
	[Category("Navigation")] public bool bBlocksNavigation;
	[Category("Collision")] [Const, transient] public bool BlockRigidBody;
	public bool bCollideWhenPlacing;
	[Const] public bool bCollideActors;
	public bool bCollideWorld;
	[Category("Collision")] public bool bCollideComplex;
	public bool bBlockActors;
	public bool bProjTarget;
	public bool bBlocksTeleport;
	[Category("Collision")] public bool bNoEncroachCheck;
	[Category("Collision")] public bool bPhysRigidBodyOutOfWorldCheck;
	[Const] public bool bComponentOutsideWorld;
	public bool bBounce;
	[Const] public bool bJustTeleported;
	[Const] public bool bNetInitial;
	[Const] public bool bNetOwner;
	[Category("Advanced")] [Const] public bool bHiddenEd;
	[Category("Advanced")] [Const] public bool bHiddenEdGroup;
	[Const] public bool bHiddenEdCustom;
	[Category("Advanced")] public bool bEdShouldSnap;
	[Const, transient] public bool bTempEditor;
	[Category("Collision")] public bool bPathColliding;
	[transient] public bool bPathTemp;
	public bool bScriptInitialized;
	[Category("Advanced")] public bool bLockLocation;
	[Const, export, editinline] public/*private*/ array</*export editinline */ActorComponent> Components;
	[Const, export, editinline, transient] public/*private*/ array</*export editinline */ActorComponent> AllComponents;
	[native, Const] public/*private*/ Object.RenderCommandFence DetachFence;
	public float CustomTimeDilation;
	[Category("Movement")] [Const] public Actor.EPhysics Physics;
	public Actor.ENetRole RemoteRole;
	public Actor.ENetRole Role;
	[Category("Collision")] [Const, transient] public Actor.ECollisionType CollisionType;
	[Const] public Object.ETickingGroup TickGroup;
	[Const] public Actor Owner;
	[Category("Attachment")] [Const] public Actor Base;
	[Const] public array<Actor.TimerData> Timers;
	[Const, transient] public int NetTag;
	[Const] public float NetUpdateTime;
	public float NetUpdateFrequency;
	public float NetPriority;
	[Const, transient] public float LastNetUpdateTime;
	public Pawn Instigator;
	[Const, transient] public WorldInfo WorldInfo;
	public float LifeSpan;
	[Const] public float CreationTime;
	[transient] public float LastRenderTime;
	[Category("Object")] public name Tag;
	public name InitialState;
	[Category("Object")] public name Group;
	[Const, transient] public array<Actor> Touching;
	[Const, transient] public array<Actor> Children;
	[Const] public float LatentFloat;
	[Const] public AnimNodeSequence LatentSeqNode;
	[Const, transient] public PhysicsVolume PhysicsVolume;
	[Category("Movement")] [Const] public Object.Vector Location;
	[Category("Movement")] [Const] public Object.Rotator Rotation;
	public Object.Vector Velocity;
	public Object.Vector Acceleration;
	[Const, transient] public Object.Vector AngularVelocity;
	[Category("Attachment")] [export, editinline] public SkeletalMeshComponent BaseSkelComponent;
	[Category("Attachment")] public name BaseBoneName;
	[Const] public array<Actor> Attached;
	[Const] public Object.Vector RelativeLocation;
	[Const] public Object.Rotator RelativeRotation;
	[Category("Display")] [interp, Const] public float DrawScale;
	[Category("Display")] [interp, Const] public Object.Vector DrawScale3D;
	[Category("Display")] [Const] public Object.Vector PrePivot;
	[Category("Collision")] [export, editinline] public PrimitiveComponent CollisionComponent;
	[native] public int OverlapTag;
	[Category("Movement")] public Object.Rotator RotationRate;
	[Category("Movement")] public Object.Rotator DesiredRotation;
	public Actor PendingTouch;
	[Category("Physics")] public float MinDistForNetRBCorrection;
	public Core.ClassT<LocalMessage> MessageClass;
	[Const] public array< Core.ClassT<SequenceEvent> > SupportedEvents;
	[Const] public array<SequenceEvent> GeneratedEvents;
	public array<SeqAct_Latent> LatentActions;
	
	//replication
	//{
	//	 if((((!bSkipActorPropertyReplication || bNetInitial)) && bReplicateMovement) && (((((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/)) && bNetInitial) || ((((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_SimulatedProxy/*1*/)) && (bNetInitial || bUpdateSimulatedPosition)) && ((Base == default) || Base.bWorldGeometry)))
	//		Location, Rotation;
	//
	//	 if((((!bSkipActorPropertyReplication || bNetInitial)) && bReplicateMovement) && ((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_SimulatedProxy/*1*/))
	//		Base;
	//
	//	 if(((((((!bSkipActorPropertyReplication || bNetInitial)) && bReplicateMovement) && (bNetInitial || bUpdateSimulatedPosition)) && ((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_SimulatedProxy/*1*/)) && Base != default) && !Base.bWorldGeometry)
	//		RelativeLocation, RelativeRotation;
	//
	//	 if((((!bSkipActorPropertyReplication || bNetInitial)) && bReplicateMovement) && (((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_SimulatedProxy/*1*/)) && (bNetInitial || bUpdateSimulatedPosition))
	//		Physics, Velocity;
	//
	//	 if(((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bHardAttach;
	//
	//	 if((((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty)
	//		bHidden;
	//
	//	 if(((((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty) && (bCollideActors || bCollideWorld))
	//		bBlockActors, bProjTarget;
	//
	//	 if(((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RemoteRole, Role, 
	//		bNetOwner, bTearOff;
	//
	//	 if(((((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty) && bReplicateInstigator)
	//		Instigator;
	//
	//	 if((((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty)
	//		DrawScale, bCollideActors, 
	//		bCollideWorld;
	//
	//	 if(((bNetOwner && (!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty)
	//		Owner;
	//}
	
	// Export UActor::execForceUpdateComponents(FFrame&, void* const)
	public virtual /*native function */void ForceUpdateComponents(/*optional */bool? _bCollisionUpdate = default, /*optional */bool? _bTransformOnly = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execConsoleCommand(FFrame&, void* const)
	public virtual /*native function */String ConsoleCommand(String Command, /*optional */bool? _bWriteToLog = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSleep(FFrame&, void* const)
	public virtual /*native(256) final latent function */Flow Sleep(float Seconds)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execFinishAnim(FFrame&, void* const)
	public virtual /*native(261) final latent function */Flow FinishAnim(AnimNodeSequence SeqNode)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSetCollision(FFrame&, void* const)
	public virtual /*native(262) final function */void SetCollision(/*optional */bool? _bNewColActors = default, /*optional */bool? _bNewBlockActors = default, /*optional */bool? _bNewIgnoreEncroachers = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetCollisionSize(FFrame&, void* const)
	public virtual /*native(283) final function */void SetCollisionSize(float NewRadius, float NewHeight)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetCollisionType(FFrame&, void* const)
	public virtual /*native final function */void SetCollisionType(Actor.ECollisionType NewCollisionType)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetDrawScale(FFrame&, void* const)
	public virtual /*native final function */void SetDrawScale(float NewScale)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetDrawScale3D(FFrame&, void* const)
	public virtual /*native final function */void SetDrawScale3D(Object.Vector NewScale3D)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execMove(FFrame&, void* const)
	public virtual /*native(266) final function */bool Move(Object.Vector Delta)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	//// Export UActor::execSetLocation(FFrame&, void* const)
	//public virtual /*native(267) final function */bool SetLocation(Object.Vector NewLocation)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export UActor::execSetRotation(FFrame&, void* const)
	//public virtual /*native(299) final function */bool SetRotation(Object.Rotator NewRotation)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UActor::execMovingWhichWay(FFrame&, void* const)
	public virtual /*native function */Actor.EMoveDir MovingWhichWay(ref float Amount)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSetZone(FFrame&, void* const)
	public virtual /*native final function */void SetZone(bool bForceRefresh)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetRelativeRotation(FFrame&, void* const)
	public virtual /*native final function */bool SetRelativeRotation(Object.Rotator NewRotation)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSetRelativeLocation(FFrame&, void* const)
	public virtual /*native final function */bool SetRelativeLocation(Object.Vector NewLocation)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSetHardAttach(FFrame&, void* const)
	public virtual /*native final function */void SetHardAttach(/*optional */bool? _bNewHardAttach = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execMoveSmooth(FFrame&, void* const)
	public virtual /*native(3969) final function */bool MoveSmooth(Object.Vector Delta)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execAutonomousPhysics(FFrame&, void* const)
	public virtual /*native(3971) final function */void AutonomousPhysics(float DeltaSeconds)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execGetTerminalVelocity(FFrame&, void* const)
	public virtual /*native function */float GetTerminalVelocity()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSetBase(FFrame&, void* const)
	public virtual /*native(298) final function */void SetBase(Actor NewBase, /*optional */Object.Vector? _NewFloor = default, /*optional */SkeletalMeshComponent _SkelComp = default, /*optional */name? _AttachName = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetOwner(FFrame&, void* const)
	//public virtual /*native(272) final function */void SetOwner(Actor NewOwner)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UActor::execFindBase(FFrame&, void* const)
	public virtual /*native function */void FindBase()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execIsBasedOn(FFrame&, void* const)
	public virtual /*native final function */bool IsBasedOn(Actor TestActor)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execGetBaseMost(FFrame&, void* const)
	public virtual /*native function */Actor GetBaseMost()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execIsOwnedBy(FFrame&, void* const)
	//public virtual /*native final function */bool IsOwnedBy(Actor TestActor)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public virtual /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	// Export UActor::execSetForcedInitialReplicatedProperty(FFrame&, void* const)
	public virtual /*native final function */void SetForcedInitialReplicatedProperty(Property PropToReplicate, bool bAdd)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execFlushPersistentDebugLines(FFrame&, void* const)
	public /*native final function */static void FlushPersistentDebugLines()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugLine(FFrame&, void* const)
	public /*native final function */static void DrawDebugLine(Object.Vector LineStart, Object.Vector LineEnd, byte R, byte G, byte B, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugLineTime(FFrame&, void* const)
	public /*native final function */static void DrawDebugLineTime(Object.Vector LineStart, Object.Vector LineEnd, byte R, byte G, byte B, /*optional */float? _timeToLive = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugBoxTime(FFrame&, void* const)
	public /*native final function */static void DrawDebugBoxTime(Object.Vector Center, Object.Vector Extent, byte R, byte G, byte B, /*optional */float? _timeToLive = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugBox(FFrame&, void* const)
	public /*native final function */static void DrawDebugBox(Object.Vector Center, Object.Vector Extent, byte R, byte G, byte B, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugCoordinateSystem(FFrame&, void* const)
	public /*native final function */static void DrawDebugCoordinateSystem(Object.Vector AxisLoc, Object.Rotator AxisRot, float Scale, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugSphere(FFrame&, void* const)
	public /*native final function */static void DrawDebugSphere(Object.Vector Center, float Radius, int Segments, byte R, byte G, byte B, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugSphereTime(FFrame&, void* const)
	public /*native final function */static void DrawDebugSphereTime(Object.Vector Center, float Radius, int Segments, byte R, byte G, byte B, /*optional */float? _timeToLive = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugCylinder(FFrame&, void* const)
	public /*native final function */static void DrawDebugCylinder(Object.Vector Start, Object.Vector End, float Radius, int Segments, byte R, byte G, byte B, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugCone(FFrame&, void* const)
	public /*native final function */static void DrawDebugCone(Object.Vector Origin, Object.Vector Direction, float Length, float AngleWidth, float AngleHeight, int NumSides, Object.Color DrawColor, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execDrawDebugArc(FFrame&, void* const)
	public /*native final function */static void DrawDebugArc(Object.Vector Origin, Object.Vector Up, Object.Vector Forward, float Size, int Degrees, int ArcDegreesResolution, byte R, byte G, byte B, /*optional */bool? _bUseDistanceMarker = default, /*optional */bool? _bPersistentLines = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execChartData(FFrame&, void* const)
	public virtual /*native final function */void ChartData(String DataName, float DataValue)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetHidden(FFrame&, void* const)
	public virtual /*native final function */void SetHidden(bool bNewHidden)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execSetOnlyOwnerSee(FFrame&, void* const)
	public virtual /*native final function */void SetOnlyOwnerSee(bool bNewOnlyOwnerSee)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	//// Export UActor::execSetPhysics(FFrame&, void* const)
	//public virtual /*native(3970) final function */void SetPhysics(Actor.EPhysics newPhysics)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UActor::execClock(FFrame&, void* const)
	public virtual /*native final function */void Clock(ref float Time)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execUnClock(FFrame&, void* const)
	public virtual /*native final function */void UnClock(ref float Time)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	//// Export UActor::execAttachComponent(FFrame&, void* const)
	//public virtual /*native final function */void AttachComponent(ActorComponent NewComponent)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	//
	//// Export UActor::execDetachComponent(FFrame&, void* const)
	//public virtual /*native final function */void DetachComponent(ActorComponent ExComponent)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UActor::execSetTickGroup(FFrame&, void* const)
	public virtual /*native final function */void SetTickGroup(Object.ETickingGroup NewTickGroup)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*event */void Destroyed()
	{
	
	}
	
	public virtual /*event */void GainedChild(Actor Other)
	{
	
	}
	
	public virtual /*event */void LostChild(Actor Other)
	{
	
	}
	
	public delegate void Tick_del(float DeltaTime);
	public virtual Tick_del Tick { get => bfield_Tick ?? Actor_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public virtual Tick_del global_Tick => Actor_Tick;
	//public /*event */void Actor_Tick(float DeltaTime)
	//{
	//
	//}
	
	public delegate void Timer_del();
	public virtual Timer_del Timer { get => bfield_Timer ?? Actor_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public virtual Timer_del global_Timer => Actor_Timer;
	public /*event */void Actor_Timer()
	{
	
	}
	
	public virtual /*event */void HitWall(Object.Vector HitNormal, Actor Wall, PrimitiveComponent WallComp)
	{
	
	}
	
	public virtual /*event */void Falling()
	{
	
	}
	
	public delegate void Landed_del(Object.Vector HitNormal, Actor FloorActor);
	public virtual Landed_del Landed { get => bfield_Landed ?? Actor_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public virtual Landed_del global_Landed => Actor_Landed;
	public /*event */void Actor_Landed(Object.Vector HitNormal, Actor FloorActor)
	{
	
	}
	
	public virtual /*event */void PhysicsVolumeChange(PhysicsVolume NewVolume)
	{
	
	}
	
	public delegate void Touch_del(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal);
	public virtual Touch_del Touch { get => bfield_Touch ?? Actor_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public virtual Touch_del global_Touch => Actor_Touch;
	public /*event */void Actor_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public virtual /*event */void PostTouch(Actor Other)
	{
	
	}
	
	public delegate void UnTouch_del(Actor Other);
	public virtual UnTouch_del UnTouch { get => bfield_UnTouch ?? Actor_UnTouch; set => bfield_UnTouch = value; } UnTouch_del bfield_UnTouch;
	public virtual UnTouch_del global_UnTouch => Actor_UnTouch;
	public /*event */void Actor_UnTouch(Actor Other)
	{
	
	}
	
	public virtual /*event */void Bump(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitNormal)
	{
	
	}
	
	public delegate void BaseChange_del();
	public virtual BaseChange_del BaseChange { get => bfield_BaseChange ?? Actor_BaseChange; set => bfield_BaseChange = value; } BaseChange_del bfield_BaseChange;
	public virtual BaseChange_del global_BaseChange => Actor_BaseChange;
	public /*event */void Actor_BaseChange()
	{
	
	}
	
	public virtual /*event */void Attach(Actor Other)
	{
	
	}
	
	public virtual /*event */void Detach(Actor Other)
	{
	
	}
	
	public virtual /*event */Actor SpecialHandling(Pawn Other)
	{
	
		return default;
	}
	
	public virtual /*event */void CollisionChanged()
	{
	
	}
	
	public virtual /*event */bool EncroachingOn(Actor Other)
	{
	
		return default;
	}
	
	public virtual /*event */void EncroachedBy(Actor Other)
	{
	
	}
	
	public virtual /*event */void RanInto(Actor Other)
	{
	
	}
	
	// Export UActor::execClampRotation(FFrame&, void* const)
	public virtual /*native final simulated function */bool ClampRotation(ref Object.Rotator out_Rot, Object.Rotator rBase, Object.Rotator rUpperLimits, Object.Rotator rLowerLimits)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*simulated event */bool OverRotated(ref Object.Rotator out_Desired, ref Object.Rotator out_Actual)
	{
	
		return default;
	}
	
	public virtual /*function */bool UsedBy(Pawn User)
	{
		return TriggerEventClass(ClassT<SeqEvent_Used>(), User, -1, default(bool?), ref/*probably?*/ /*null*/NullRef.array_SequenceEvent_);
	}
	
	public virtual /*simulated function */void VolumeBasedDestroy(PhysicsVolume PV)
	{
		Destroy();
	}
	
	public delegate void FellOutOfWorld_del(Core.ClassT<DamageType> dmgType);
	public virtual FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? Actor_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public virtual FellOutOfWorld_del global_FellOutOfWorld => Actor_FellOutOfWorld;
	public /*simulated event */void Actor_FellOutOfWorld(Core.ClassT<DamageType> dmgType)
	{
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetHidden(true);
		SetCollision(false, false, default(bool?));
		Destroy();
	}
	
	public delegate void OutsideWorldBounds_del();
	public virtual OutsideWorldBounds_del OutsideWorldBounds { get => bfield_OutsideWorldBounds ?? Actor_OutsideWorldBounds; set => bfield_OutsideWorldBounds = value; } OutsideWorldBounds_del bfield_OutsideWorldBounds;
	public virtual OutsideWorldBounds_del global_OutsideWorldBounds => Actor_OutsideWorldBounds;
	public /*simulated event */void Actor_OutsideWorldBounds()
	{
		Destroy();
	}
	
	// Export UActor::execTrace(FFrame&, void* const)
	public virtual /*native(277) final function */Actor Trace(ref Object.Vector HitLocation, ref Object.Vector HitNormal, Object.Vector TraceEnd, /*optional */Object.Vector? _TraceStart/* = default*/, /*optional */bool? _bTraceActors/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */ref Actor.TraceHitInfo HitInfo/* = default*/, /*optional */int? _ExtraTraceFlags = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execTraceComponent(FFrame&, void* const)
	public virtual /*native final function */bool TraceComponent(ref Object.Vector HitLocation, ref Object.Vector HitNormal, PrimitiveComponent InComponent, Object.Vector TraceEnd, /*optional */Object.Vector? _TraceStart/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */ref Actor.TraceHitInfo HitInfo/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execPointCheckComponent(FFrame&, void* const)
	public virtual /*native final function */bool PointCheckComponent(PrimitiveComponent InComponent, Object.Vector PointLocation, Object.Vector PointExtent)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execFastTrace(FFrame&, void* const)
	public virtual /*native(548) final function */bool FastTrace(Object.Vector TraceEnd, /*optional */Object.Vector? _TraceStart = default, /*optional */Object.Vector? _BoxExtent = default, /*optional */bool? _bTraceBullet = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execFindSpot(FFrame&, void* const)
	public virtual /*native final function */bool FindSpot(Object.Vector BoxExtent, ref Object.Vector SpotLocation)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execContainsPoint(FFrame&, void* const)
	public virtual /*native final function */bool ContainsPoint(Object.Vector Spot)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execIsOverlapping(FFrame&, void* const)
	public virtual /*native final function */bool IsOverlapping(Actor A)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execGetComponentsBoundingBox(FFrame&, void* const)
	public virtual /*native final function */void GetComponentsBoundingBox(ref Object.Box ActorBox)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execGetBoundingCylinder(FFrame&, void* const)
	public virtual /*native function */void GetBoundingCylinder(ref float CollisionRadius, ref float CollisionHeight)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	//// Export UActor::execSpawn(FFrame&, void* const)
	//public virtual /*native final function */Actor Spawn(Core.ClassT<Actor> SpawnClass, /*optional */Actor? _SpawnOwner = default, /*optional */name? _SpawnTag = default, /*optional */Object.Vector? _SpawnLocation = default, /*optional */Object.Rotator? _SpawnRotation = default, /*optional */Actor? _ActorTemplate = default, /*optional */bool? _bNoCollisionFail = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export UActor::execDestroy(FFrame&, void* const)
	//public virtual /*native(279) final function */bool Destroy()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public virtual /*event */void TornOff()
	{
	
	}
	
	// Export UActor::execSetTimer(FFrame&, void* const)
	//public virtual /*native(280) final function */void SetTimer(float InRate, /*optional */bool? _inbLoop = default, /*optional */name? _inTimerFunc = default, /*optional */Object _inObj = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UActor::execClearTimer(FFrame&, void* const)
	//public virtual /*native final function */void ClearTimer(/*optional */name? _inTimerFunc = default, /*optional */Object _inObj = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UActor::execIsTimerActive(FFrame&, void* const)
	public virtual /*native final function */bool IsTimerActive(/*optional */name? _inTimerFunc = default, /*optional */Object _inObj = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execGetTimerCount(FFrame&, void* const)
	public virtual /*native final function */float GetTimerCount(/*optional */name? _inTimerFunc = default, /*optional */Object _inObj = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execGetTimerRate(FFrame&, void* const)
	public virtual /*native final function */float GetTimerRate(/*optional */name? _TimerFuncName = default, /*optional */Object _inObj = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execCreateAudioComponent(FFrame&, void* const)
	public virtual /*native final function */AudioComponent CreateAudioComponent(SoundCue InSoundCue, /*optional */bool? _bPlay = default, /*optional */bool? _bStopWhenOwnerDestroyed = default, /*optional */bool? _bUseLocation = default, /*optional */Object.Vector? _SourceLocation = default, /*optional */bool? _bAttachToSelf = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execPlaySound(FFrame&, void* const)
	public virtual /*native final function */void PlaySound(SoundCue InSoundCue, /*optional */bool? _bNotReplicated = default, /*optional */bool? _bNoRepToOwner = default, /*optional */bool? _bStopWhenOwnerDestroyed = default, /*optional */Object.Vector? _SoundLocation = default, /*optional */bool? _bNoRepToRelevant = default, /*optional */bool? _bPlayOnSelf = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execMakeNoise(FFrame&, void* const)
	public virtual /*native(512) final function */void MakeNoise(float Loudness, /*optional */name? _NoiseType = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execPlayerCanSeeMe(FFrame&, void* const)
	public virtual /*native(532) final function */bool PlayerCanSeeMe()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execSuggestTossVelocity(FFrame&, void* const)
	public virtual /*native final function */bool SuggestTossVelocity(ref Object.Vector TossVelocity, Object.Vector Destination, Object.Vector Start, float TossSpeed, /*optional */float? _BaseTossZ = default, /*optional */float? _DesiredZPct = default, /*optional */Object.Vector? _CollisionSize = default, /*optional */float? _TerminalVelocity = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UActor::execGetDestination(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetDestination(Controller C)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*function */bool PreTeleport(Teleporter InTeleporter)
	{
	
		return default;
	}
	
	public virtual /*function */void PostTeleport(Teleporter OutTeleporter)
	{
	
	}
	
	// Export UActor::execGetURLMap(FFrame&, void* const)
	public virtual /*native(547) final function */String GetURLMap()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	//// Export UActor::execAllActors(FFrame&, void* const)
	//public virtual /*native(304) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> AllActors(Core.ClassT<Actor> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execDynamicActors(FFrame&, void* const)
	//public virtual /*native(313) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> DynamicActors(Core.ClassT<Actor> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execChildActors(FFrame&, void* const)
	//public virtual /*native(305) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> ChildActors(Core.ClassT<Actor> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execBasedActors(FFrame&, void* const)
	//public virtual /*native(306) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> BasedActors(Core.ClassT<Actor> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execTouchingActors(FFrame&, void* const)
	//public virtual /*native(307) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> TouchingActors(Core.ClassT<Actor> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execTraceActors(FFrame&, void* const)
	//public virtual /*native(309) final iterator function */System.Collections.Generic.IEnumerable<(Actor/* Actor*/,Object.Vector/* HitLoc*/,Object.Vector/* HitNorm*/,Actor.TraceHitInfo/* HitInfo*/)> TraceActors(Core.ClassT<Actor> BaseClass, Object.Vector End, /*optional */Object.Vector? _Start/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */int? _ExtraTraceFlags = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execVisibleActors(FFrame&, void* const)
	//public virtual /*native(311) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> VisibleActors(Core.ClassT<Actor> BaseClass, /*optional */float? _Radius = default, /*optional */Object.Vector? _Loc = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execVisibleCollidingActors(FFrame&, void* const)
	//public virtual /*native(312) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> VisibleCollidingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bIgnoreHidden = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execCollidingActors(FFrame&, void* const)
	//public virtual /*native(321) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> CollidingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bUseOverlapCheck = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execOverlappingActors(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Actor/* out_Actor*/> OverlappingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bIgnoreHidden = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execComponentList(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* out_Component*/> ComponentList(Class BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execAllOwnedComponents(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* OutComponent*/> AllOwnedComponents(Core.ClassT<Component> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export UActor::execLocalPlayerControllers(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<PlayerController/* PC*/> LocalPlayerControllers(Core.ClassT<PlayerController> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	
	public virtual /*final function */bool FindActorsOfClass(Core.ClassT<Actor> ActorClass, ref array<Actor> out_Actors)
	{
		/*local */Actor TestActor = default;
	
		out_Actors.Length = 0;
		
		// foreach AllActors(ActorClass, ref/*probably?*/ TestActor)
		using var e8 = AllActors(ActorClass).GetEnumerator();
		while(e8.MoveNext() && (TestActor = (Actor)e8.Current) == TestActor)
		{
			out_Actors[out_Actors.Length] = TestActor;		
		}	
		return out_Actors.Length > 0;
	}
	
	public virtual /*event */void PreBeginPlay()
	{
		if(bPhysXMutatable && bStatic)
		{
			if(!WorldInfo.Game.CheckRelevance(this))
			{
				SetHidden(true);
				SetCollisionType(Actor.ECollisionType.COLLIDE_NoCollision/*1*/);
			}		
		}
		else
		{
			if(((bPhysXMutatable || (!bGameRelevant && !bStatic) && ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Client/*3*/))) && !WorldInfo.Game.CheckRelevance(this))
			{
				if(bNoDelete)
				{
					ShutDown();				
				}
				else
				{
					Destroy();
				}
			}
		}
	}
	
	public virtual /*event */void BroadcastLocalizedMessage(Core.ClassT<LocalMessage> InMessageClass, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		var Switch = _Switch ?? default;
		var RelatedPRI_1 = _RelatedPRI_1 ?? default;
		var RelatedPRI_2 = _RelatedPRI_2 ?? default;
		var OptionalObject = _OptionalObject ?? default;
		WorldInfo.Game.BroadcastLocalized(this, InMessageClass, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
	}
	
	public virtual /*event */void BroadcastLocalizedTeamMessage(int TeamIndex, Core.ClassT<LocalMessage> InMessageClass, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		var Switch = _Switch ?? default;
		var RelatedPRI_1 = _RelatedPRI_1 ?? default;
		var RelatedPRI_2 = _RelatedPRI_2 ?? default;
		var OptionalObject = _OptionalObject ?? default;
		WorldInfo.Game.BroadcastLocalizedTeam(TeamIndex, this, InMessageClass, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
	}
	
	public virtual /*event */void PostBeginPlay()
	{
	
	}
	
	public delegate void SetInitialState_del();
	public virtual SetInitialState_del SetInitialState { get => bfield_SetInitialState ?? Actor_SetInitialState; set => bfield_SetInitialState = value; } SetInitialState_del bfield_SetInitialState;
	public virtual SetInitialState_del global_SetInitialState => Actor_SetInitialState;
	public /*simulated event */void Actor_SetInitialState()
	{
		bScriptInitialized = true;
		if(InitialState != "None")
		{
			GotoState(InitialState, default(name?), default(bool?), default(bool?));		
		}
		else
		{
			GotoState("Auto", default(name?), default(bool?), default(bool?));
		}
	}
	
	public virtual /*simulated event */void ConstraintBrokenNotify(Actor ConOwner, RB_ConstraintSetup ConSetup, RB_ConstraintInstance ConInstance)
	{
	
	}
	
	public virtual /*simulated event */void NotifySkelControlBeyondLimit(SkelControlLookAt LookAt)
	{
	
	}
	
	public virtual /*simulated function */bool StopsProjectile(Projectile P)
	{
		return (bProjTarget || bBlockActors);
	}
	
	public virtual /*simulated function */bool HurtRadius(float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, /*optional */Actor _IgnoredActor = default, /*optional */Controller _InstigatedByController = default, /*optional */bool? _bDoFullDamage = default)
	{
		/*local */Actor Victim = default;
		/*local */bool bCausedDamage = default;
	
		var IgnoredActor = _IgnoredActor ?? default;
		var InstigatedByController = _InstigatedByController ?? ((Instigator != default) ? Instigator.Controller : default);
		var bDoFullDamage = _bDoFullDamage ?? default;
		if(bHurtEntry)
		{
			return false;
		}
		bHurtEntry = true;
		bCausedDamage = false;
		
		// foreach VisibleCollidingActors(ClassT<Actor>(), ref/*probably?*/ Victim, DamageRadius, HurtOrigin, default(bool?))
		using var e62 = VisibleCollidingActors(ClassT<Actor>(), DamageRadius, HurtOrigin, default(bool?)).GetEnumerator();
		while(e62.MoveNext() && (Victim = (Actor)e62.Current) == Victim)
		{
			if(((!Victim.bWorldGeometry && Victim != this) && Victim != IgnoredActor) && (Victim.bProjTarget || ((Victim) as NavigationPoint) == default))
			{
				Victim.TakeRadiusDamage(InstigatedByController, BaseDamage, DamageRadius, DamageType, Momentum, HurtOrigin, bDoFullDamage, this);
				bCausedDamage = (bCausedDamage || Victim.bProjTarget);
			}		
		}	
		bHurtEntry = false;
		return bCausedDamage;
	}
	
	public delegate void KilledBy_del(Pawn EventInstigator);
	public virtual KilledBy_del KilledBy { get => bfield_KilledBy ?? Actor_KilledBy; set => bfield_KilledBy = value; } KilledBy_del bfield_KilledBy;
	public virtual KilledBy_del global_KilledBy => Actor_KilledBy;
	public /*function */void Actor_KilledBy(Pawn EventInstigator)
	{
	
	}
	
	public delegate void TakeDamage_del(int DamageAmount, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default);
	public virtual TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? Actor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public virtual TakeDamage_del global_TakeDamage => Actor_TakeDamage;
	public /*event */void Actor_TakeDamage(int DamageAmount, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default)
	{
		/*local */int Idx = default;
		/*local */SeqEvent_TakeDamage dmgEvent = default;
	
		var HitInfo = _HitInfo ?? default;
		var DamageCauser = _DamageCauser ?? default;
		Idx = 0;
		J0x09:{}
		if(Idx < GeneratedEvents.Length)
		{
			dmgEvent = ((GeneratedEvents[Idx]) as SeqEvent_TakeDamage);
			if(dmgEvent != default)
			{
				dmgEvent.HandleDamage(this, EventInstigator, DamageType, DamageAmount);
			}
			++ Idx;
			goto J0x09;
		}
	}
	
	public virtual /*function */bool HealDamage(int Amount, Controller Healer, Core.ClassT<DamageType> DamageType)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void TakeRadiusDamage(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser)
	{
		/*local */float ColRadius = default, ColHeight = default, DamageScale = default, Dist = default;
		/*local */Object.Vector Dir = default;
	
		GetBoundingCylinder(ref/*probably?*/ ColRadius, ref/*probably?*/ ColHeight);
		Dir = Location - HurtOrigin;
		Dist = VSize(Dir);
		Dir = Normal(Dir);
		if(bFullDamage)
		{
			DamageScale = 1.0f;		
		}
		else
		{
			Dist = FClamp(Dist - ColRadius, 0.0f, DamageRadius);
			DamageScale = 1.0f - (Dist / DamageRadius);
		}
		if(DamageScale > 0.0f)
		{
			TakeDamage(((int)(DamageScale * BaseDamage)), InstigatedBy, Location - ((0.50f * (ColHeight + ColRadius)) * Dir), (DamageScale * Momentum) * Dir, DamageType, default(Actor.TraceHitInfo?), DamageCauser);
		}
	}
	
	public virtual /*final simulated function */void CheckHitInfo(ref Actor.TraceHitInfo HitInfo, PrimitiveComponent FallBackComponent, Object.Vector Dir, ref Object.Vector out_HitLocation)
	{
		/*local */Object.Vector out_NewHitLocation = default, out_HitNormal = default, TraceEnd = default, TraceStart = default;
		/*local */Actor.TraceHitInfo newHitInfo = default;
	
		if((((HitInfo.HitComponent) as SkeletalMeshComponent) != default) && HitInfo.BoneName != "None")
		{
			return;
		}
		if(((HitInfo.HitComponent == default) || (((HitInfo.HitComponent) as SkeletalMeshComponent) == default) && ((FallBackComponent) as SkeletalMeshComponent) != default))
		{
			HitInfo.HitComponent = FallBackComponent;
		}
		if((((HitInfo.HitComponent) as SkeletalMeshComponent) != default) && HitInfo.BoneName == "None")
		{
			if(IsZero(Dir))
			{
				Dir = ((Vector)(Rotation));
			}
			if(IsZero(out_HitLocation))
			{
				out_HitLocation = Location;
			}
			TraceStart = out_HitLocation - (((float)(128)) * Normal(Dir));
			TraceEnd = out_HitLocation + (((float)(128)) * Normal(Dir));
			if(TraceComponent(ref/*probably?*/ out_NewHitLocation, ref/*probably?*/ out_HitNormal, HitInfo.HitComponent, TraceEnd, TraceStart, vect(0.0f, 0.0f, 0.0f), ref/*probably?*/ newHitInfo))
			{
				HitInfo.BoneName = newHitInfo.BoneName;
				HitInfo.PhysMaterial = newHitInfo.PhysMaterial;
				out_HitLocation = out_NewHitLocation;
			}
		}
	}
	
	//// Export UActor::execGetGravityZ(FFrame&, void* const)
	//public virtual /*native function */float GetGravityZ()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public virtual /*function */void DebugFreezeGame()
	{
		/*local */PlayerController PC = default;
	
		ScriptTrace();
		
		// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e6 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e6.MoveNext() && (PC = (PlayerController)e6.Current) == PC)
		{
			PC.ConsoleCommand("PlayersOnly", default(bool?));		
			return;		
		}	
	}
	
	public virtual /*function */bool CheckForErrors()
	{
	
		return default;
	}
	
	public virtual /*event */void BecomeViewTarget(PlayerController PC)
	{
	
	}
	
	public virtual /*event */void EndViewTarget(PlayerController PC)
	{
	
	}
	
	public virtual /*simulated function */bool CalcCamera(float fDeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot, ref float out_FOV)
	{
		/*local */Object.Vector HitNormal = default;
		/*local */float Radius = default, Height = default;
	
		GetBoundingCylinder(ref/*probably?*/ Radius, ref/*probably?*/ Height);
		if(Trace(ref/*probably?*/ out_CamLoc, ref/*probably?*/ HitNormal, Location - ((((Vector)(out_CamRot)) * Radius) * ((float)(20))), Location, false, default(Object.Vector?), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, default(int?)) == default)
		{
			out_CamLoc = Location - ((((Vector)(out_CamRot)) * Radius) * ((float)(20)));		
		}
		else
		{
			out_CamLoc = Location + (Height * ((Vector)(Rotation)));
		}
		return false;
	}
	
	public virtual /*simulated function */String GetItemName(String FullName)
	{
		/*local */int pos = default;
	
		pos = InStr(FullName, ".", default(bool?));
		J0x11:{}
		if(pos != -1)
		{
			FullName = Right(FullName, (Len(FullName) - pos) - 1);
			pos = InStr(FullName, ".", default(bool?));
			goto J0x11;
		}
		return FullName;
	}
	
	public virtual /*simulated function */String GetHumanReadableName()
	{
		return GetItemName(((Class)).ToString());
	}
	
	public /*function */static void ReplaceText(ref String Text, String Replace, String With)
	{
		/*local */int I = default;
		/*local */String Input = default;
	
		Input = Text;
		Text = "";
		I = InStr(Input, Replace, default(bool?));
		J0x26:{}
		if(I != -1)
		{
			Text = (Text + Left(Input, I)) + With;
			Input = Mid(Input, I + Len(Replace), default(int?));
			I = InStr(Input, Replace, default(bool?));
			goto J0x26;
		}
		Text = Text + Input;
	}
	
	public /*function */static String GetLocalString(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default)
	{
		var Switch = _Switch ?? default;
		var RelatedPRI_1 = _RelatedPRI_1 ?? default;
		var RelatedPRI_2 = _RelatedPRI_2 ?? default;
		return "";
	}
	
	public delegate void MatchStarting_del();
	public virtual MatchStarting_del MatchStarting { get => bfield_MatchStarting ?? Actor_MatchStarting; set => bfield_MatchStarting = value; } MatchStarting_del bfield_MatchStarting;
	public virtual MatchStarting_del global_MatchStarting => Actor_MatchStarting;
	public /*function */void Actor_MatchStarting()
	{
	
	}
	
	public virtual /*function */void SetGRI(GameReplicationInfo GRI)
	{
	
	}
	
	public virtual /*function */String GetDebugName()
	{
		return GetItemName(((this)).ToString());
	}
	
	public virtual /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */String T = default;
		/*local */Actor A = default;
		/*local */float MyRadius = default, MyHeight = default;
		/*local */Canvas Canvas = default;
	
		Canvas = HUD.Canvas;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.SetDrawColor(255, 0, 0, (byte)default(byte?));
		T = GetDebugName();
		if(bDeleteMe)
		{
			T = T + " DELETED (bDeleteMe == true)";
		}
		if(T != "")
		{
			Canvas.DrawText(T, false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
		Canvas.SetDrawColor(255, 255, 255, (byte)default(byte?));
		if(HUD.ShouldDisplayDebug("net"))
		{
			if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
			{
				T = (((("ROLE:" + " " + ((Role)).ToString()) + " " + "RemoteRole:") + " " + ((RemoteRole)).ToString()) + " " + "NetMode:") + " " + ((WorldInfo.NetMode)).ToString();
				if(bTearOff)
				{
					T = T + " " + "Tear Off";
				}
				Canvas.DrawText(T, false, default(float?), default(float?));
				out_YPos += out_YL;
				Canvas.SetPos(4.0f, out_YPos);
			}
		}
		Canvas.DrawText((("Location:" + " " + ((Location)).ToString()) + " " + "Rotation:") + " " + ((Rotation)).ToString(), false, default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		if(HUD.ShouldDisplayDebug("Physics"))
		{
			T = (((((("Physics" + " " + (GetPhysicsName())) + " " + "in physicsvolume") + " " + (GetItemName(((PhysicsVolume)).ToString()))) + " " + "on base") + " " + (GetItemName(((Base)).ToString()))) + " " + "gravity") + " " + ((GetGravityZ())).ToString();
			if(bBounce)
			{
				T = T + " - will bounce";
			}
			Canvas.DrawText(T, false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText((((((((("bHardAttach:" + " " + ((bHardAttach)).ToString()) + " " + "RelativeLoc:") + " " + ((RelativeLocation)).ToString()) + " " + "RelativeRot:") + " " + ((RelativeRotation)).ToString()) + " " + "SkelComp:") + " " + ((BaseSkelComponent)).ToString()) + " " + "Bone:") + " " + ((BaseBoneName)).ToString(), false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText((((("Velocity:" + " " + ((Velocity)).ToString()) + " " + "Speed:") + " " + ((VSize(Velocity))).ToString()) + " " + "Speed2D:") + " " + ((VSize2D(Velocity))).ToString(), false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText("Acceleration:" + " " + ((Acceleration)).ToString(), false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
		if(HUD.ShouldDisplayDebug("Collision"))
		{
			Canvas.DrawColor.B = 0;
			GetBoundingCylinder(ref/*probably?*/ MyRadius, ref/*probably?*/ MyHeight);
			Canvas.DrawText((("Collision Radius:" + " " + ((MyRadius)).ToString()) + " " + "Height:") + " " + ((MyHeight)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText((((("Collides with Actors:" + " " + ((bCollideActors)).ToString()) + " " + " world:") + " " + ((bCollideWorld)).ToString()) + " " + "proj. target:") + " " + ((bProjTarget)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText("Blocks Actors:" + " " + ((bBlockActors)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			T = "Touching ";
			
			// foreach TouchingActors(ClassT<Actor>(), ref/*probably?*/ A)
			using var e1617 = TouchingActors(ClassT<Actor>()).GetEnumerator();
			while(e1617.MoveNext() && (A = (Actor)e1617.Current) == A)
			{
				T = (T + (GetItemName(((A)).ToString()))) + " ";			
			}		
			if(T == "Touching ")
			{
				T = "Touching nothing";
			}
			Canvas.DrawText(T, false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
		Canvas.DrawColor.B = 255;
		Canvas.DrawText(" STATE:" + " " + ((GetStateName())).ToString(), false, default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText(((" Instigator:" + " " + (GetItemName(((Instigator)).ToString()))) + " " + "Owner:") + " " + (GetItemName(((Owner)).ToString())), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
	}
	
	public virtual /*simulated function */String GetPhysicsName()
	{
		switch(Physics)
		{
			case Actor.EPhysics.PHYS_None/*0*/:
				return "None";
				break;
			case Actor.EPhysics.PHYS_Walking/*1*/:
				return "Walking";
				break;
			case Actor.EPhysics.PHYS_Falling/*2*/:
				return "Falling";
				break;
			case Actor.EPhysics.PHYS_Swimming/*3*/:
				return "Swimming";
				break;
			case Actor.EPhysics.PHYS_Flying/*4*/:
				return "Flying";
				break;
			case Actor.EPhysics.PHYS_Rotating/*5*/:
				return "Rotating";
				break;
			case Actor.EPhysics.PHYS_Projectile/*6*/:
				return "Projectile";
				break;
			case Actor.EPhysics.PHYS_Interpolating/*7*/:
				return "Interpolating";
				break;
			case Actor.EPhysics.PHYS_Spider/*8*/:
				return "Spider";
				break;
			case Actor.EPhysics.PHYS_Ladder/*9*/:
				return "Ladder";
				break;
			case Actor.EPhysics.PHYS_RigidBody/*10*/:
				return "RigidBody";
				break;
			case Actor.EPhysics.PHYS_Unused/*14*/:
				return "Unused";
				break;
			default:
				break;
		}
		return "Unknown";
	}
	
	public virtual /*simulated event */void ModifyHearSoundComponent(AudioComponent AC)
	{
	
	}
	
	public virtual /*simulated event */AudioComponent GetFaceFXAudioComponent()
	{
		return default;
	}
	
	public delegate void Reset_del();
	public virtual Reset_del Reset { get => bfield_Reset ?? Actor_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public virtual Reset_del global_Reset => Actor_Reset;
	public /*event */void Actor_Reset()
	{
	
	}
	
	public virtual /*function */bool IsInVolume(Volume aVolume)
	{
		/*local */Volume V = default;
	
		
		// foreach TouchingActors(ClassT<Volume>(), ref/*probably?*/ V)
		using var e0 = TouchingActors(ClassT<Volume>()).GetEnumerator();
		while(e0.MoveNext() && (V = (Volume)e0.Current) == V)
		{
			if(V == aVolume)
			{			
				return true;
			}		
		}	
		return false;
	}
	
	public virtual /*function */bool IsInPain()
	{
		/*local */PhysicsVolume V = default;
	
		
		// foreach TouchingActors(ClassT<PhysicsVolume>(), ref/*probably?*/ V)
		using var e0 = TouchingActors(ClassT<PhysicsVolume>()).GetEnumerator();
		while(e0.MoveNext() && (V = (PhysicsVolume)e0.Current) == V)
		{
			if(V.bPainCausing && V.DamagePerSec > ((float)(0)))
			{			
				return true;
			}		
		}	
		return false;
	}
	
	public virtual /*function */void PlayTeleportEffect(bool bOut, bool bSound)
	{
	
	}
	
	public virtual /*simulated function */bool CanSplash()
	{
		return false;
	}
	
	public virtual /*simulated function */bool CheckMaxEffectDistance(PlayerController P, Object.Vector SpawnLocation, /*optional */float? _CullDistance = default)
	{
		/*local */float Dist = default;
	
		var CullDistance = _CullDistance ?? default;
		if(P.ViewTarget == default)
		{
			return true;
		}
		if((Dot(((Vector)(P.Rotation)), (SpawnLocation - P.ViewTarget.Location))) < 0.0f)
		{
			return VSize(P.ViewTarget.Location - SpawnLocation) < ((float)(1600));
		}
		Dist = VSize(SpawnLocation - P.ViewTarget.Location);
		if((CullDistance > ((float)(0))) && CullDistance < (Dist * P.LODDistanceFactor))
		{
			return false;
		}
		return !P.BeyondFogDistance(P.ViewTarget.Location, SpawnLocation);
	}
	
	public virtual /*simulated function */bool EffectIsRelevant(Object.Vector SpawnLocation, bool bForceDedicated, /*optional */float? _CullDistance = default)
	{
		/*local */PlayerController P = default;
		/*local */bool bResult = default;
	
		var CullDistance = _CullDistance ?? default;
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
		{
			return bForceDedicated;
		}
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/)) && WorldInfo.Game.NumPlayers > 1)
		{
			if(bForceDedicated)
			{
				return true;
			}
			if(((Instigator != default) && Instigator.IsHumanControlled()) && Instigator.IsLocallyControlled())
			{
				return true;
			}		
		}
		else
		{
			if((Instigator != default) && Instigator.IsHumanControlled())
			{
				return true;
			}
		}
		if(SpawnLocation == Location)
		{
			bResult = (WorldInfo.TimeSeconds - LastRenderTime) < 0.50f;		
		}
		else
		{
			if((Instigator != default) && (WorldInfo.TimeSeconds - Instigator.LastRenderTime) < 1.0f)
			{
				bResult = true;
			}
		}
		if(bResult)
		{
			bResult = false;
			
			// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ P)
			using var e330 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e330.MoveNext() && (P = (PlayerController)e330.Current) == P)
			{
				if(P.ViewTarget != default)
				{
					if((P.Pawn == Instigator) && Instigator != default)
					{					
						return true;
						continue;
					}
					bResult = CheckMaxEffectDistance(P, SpawnLocation, CullDistance);
					break;
				}			
			}		
		}
		return bResult;
	}
	
	public virtual /*final simulated function */float TimeSince(float Time)
	{
		return WorldInfo.TimeSeconds - Time;
	}
	
	public virtual /*simulated function */bool TriggerEventClass(Core.ClassT<SequenceEvent> InEventClass, Actor InInstigator, /*optional */int? _ActivateIndex/* = default*/, /*optional */bool? _bTest/* = default*/, /*optional */ref array<SequenceEvent> ActivatedEvents/* = default*/)
	{
		/*local */array<int> ActivateIndices = default;
	
		var ActivateIndex = _ActivateIndex ?? -1;
		var bTest = _bTest ?? default;
		//var ActivatedEvents = _ActivatedEvents ?? default;
		if(ActivateIndex >= 0)
		{
			ActivateIndices[0] = ActivateIndex;
		}
		return ActivateEventClass(InEventClass, InInstigator, ref/*probably?*/ GeneratedEvents, ref/*probably?*/ ActivateIndices, bTest, ref/*probably?*/ ActivatedEvents);
	}
	
	public virtual /*final simulated function */bool ActivateEventClass(Core.ClassT<SequenceEvent> InClass, Actor InInstigator, /*const */ref array<SequenceEvent> EventList, /*const optional */ref array<int> ActivateIndices/* = default*/, /*optional */bool? _bTest/* = default*/, /*optional */ref array<SequenceEvent> ActivatedEvents/* = default*/)
	{
		/*local */SequenceEvent Evt = default;
	
		//var ActivateIndices = _ActivateIndices ?? default;
		var bTest = _bTest ?? default;
		//var ActivatedEvents = _ActivatedEvents ?? default;
		ActivatedEvents.Length = 0;
		using var v = EventList.GetEnumerator();while(v.MoveNext() && (Evt = (SequenceEvent)v.Current) == Evt)
		{
			if(ClassIsChildOf(Evt.Class, InClass) && Evt.CheckActivate(this, InInstigator, bTest, ref/*probably?*/ ActivateIndices, default(bool?)))
			{
				ActivatedEvents.AddItem(Evt);
			}		
		}	
		return ActivatedEvents.Length > 0;
	}
	
	public virtual /*final simulated function */bool FindEventsOfClass(Core.ClassT<SequenceEvent> EventClass, /*optional */ref array<SequenceEvent> out_EventList/* = default*/, /*optional */bool? _bIncludeDisabled = default)
	{
		/*local */SequenceEvent Evt = default;
		/*local */bool bFoundEvent = default;
	
		//var out_EventList = _out_EventList ?? default;
		var bIncludeDisabled = _bIncludeDisabled ?? default;
		using var v = GeneratedEvents.GetEnumerator();while(v.MoveNext() && (Evt = (SequenceEvent)v.Current) == Evt)
		{
			if((((Evt != default) && (Evt.bEnabled || bIncludeDisabled)) && ClassIsChildOf(Evt.Class, EventClass)) && ((Evt.MaxTriggerCount == 0) || Evt.MaxTriggerCount > Evt.TriggerCount))
			{
				out_EventList.AddItem(Evt);
				bFoundEvent = true;
			}		
		}	
		return bFoundEvent;
	}
	
	public virtual /*final simulated function */void ClearLatentAction(Core.ClassT<SeqAct_Latent> actionClass, /*optional */bool? _bAborted = default, /*optional */SeqAct_Latent _exceptionAction = default)
	{
		/*local */int Idx = default;
	
		var bAborted = _bAborted ?? default;
		var exceptionAction = _exceptionAction ?? default;
		Idx = 0;
		J0x09:{}
		if(Idx < LatentActions.Length)
		{
			if(LatentActions[Idx] == default)
			{
				LatentActions.Remove(-- Idx, 1);
				goto J0xA4;
			}
			if(ClassIsChildOf(LatentActions[Idx].Class, actionClass) && LatentActions[Idx] != exceptionAction)
			{
				if(bAborted)
				{
					LatentActions[Idx].AbortFor(this);
				}
				LatentActions.Remove(-- Idx, 1);
			}
			J0xA4:{}
			++ Idx;
			goto J0x09;
		}
	}
	
	public virtual /*simulated function */void OnDestroy(SeqAct_Destroy Action)
	{
		if((bNoDelete || ((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/)))
		{
			ShutDown();		
		}
		else
		{
			if(!bDeleteMe)
			{
				Destroy();
			}
		}
	}
	
	public virtual /*function */void ForceNetRelevant()
	{
		if(((((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_None/*0*/)) && bNoDelete) && !bStatic)
		{
			RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy/*1*/;
			bAlwaysRelevant = true;
			NetUpdateFrequency = 0.10f;
		}
		bForceNetUpdate = true;
	}
	
	// Export UActor::execSetNetUpdateTime(FFrame&, void* const)
	public virtual /*native final function */void SetNetUpdateTime(float NewUpdateTime)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*simulated event */void ShutDown()
	{
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetCollision(false, false, default(bool?));
		if(CollisionComponent != default)
		{
			CollisionComponent.SetBlockRigidBody(false);
		}
		SetHidden(true);
		bStasis = true;
		ForceNetRelevant();
		if(((int)RemoteRole) != ((int)Actor.ENetRole.ROLE_None/*0*/))
		{
			SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bCollideActors"), bCollideActors == DefaultAs<Actor>().bCollideActors);
			SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bBlockActors"), bBlockActors == DefaultAs<Actor>().bBlockActors);
			SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bHidden"), bHidden == DefaultAs<Actor>().bHidden);
			SetForcedInitialReplicatedProperty(ObjectConst<ByteProperty>("Physics"), ((int)Physics) == ((int)DefaultAs<Actor>().Physics));
		}
		NetUpdateFrequency = 0.10f;
		bForceNetUpdate = true;
	}
	
	public virtual /*simulated function */void OnCauseDamage(SeqAct_CauseDamage Action)
	{
		/*local */Controller InstigatorController = default;
		/*local */Pawn InstigatorPawn = default;
	
		InstigatorController = ((Action.Instigator) as Controller);
		if(InstigatorController == default)
		{
			InstigatorPawn = ((Action.Instigator) as Pawn);
			if(InstigatorPawn != default)
			{
				InstigatorController = InstigatorPawn.Controller;
			}
		}
		TakeDamage(((int)(Action.DamageAmount)), InstigatorController, Location, ((Vector)(Rotation)) * -Action.Momentum, Action.DamageType, default(Actor.TraceHitInfo?), default(Actor));
	}
	
	public virtual /*function */void OnHealDamage(SeqAct_HealDamage Action)
	{
		/*local */Controller InstigatorController = default;
		/*local */Pawn InstigatorPawn = default;
	
		InstigatorController = ((Action.Instigator) as Controller);
		if(InstigatorController == default)
		{
			InstigatorPawn = ((Action.Instigator) as Pawn);
			if(InstigatorPawn != default)
			{
				InstigatorController = InstigatorPawn.Controller;
			}
		}
		HealDamage(Action.HealAmount, InstigatorController, Action.DamageType);
	}
	
	public virtual /*simulated function */void OnTeleport(SeqAct_Teleport Action)
	{
		/*local */array<Object> objVars = default;
		/*local */int Idx = default;
		/*local */Actor destActor = default;
		/*local */Controller C = default;
	
		Action.GetObjectVars(ref/*probably?*/ objVars, "Destination");
		Idx = 0;
		J0x29:{}
		if((Idx < objVars.Length) && destActor == default)
		{
			destActor = ((objVars[Idx]) as Actor);
			C = ((destActor) as Controller);
			if((C != default) && C.Pawn != default)
			{
				destActor = C.Pawn;
			}
			ForceNetRelevant();
			bUpdateSimulatedPosition = true;
			++ Idx;
			goto J0x29;
		}
		if((destActor != default) && SetLocation(destActor.Location))
		{
			PlayTeleportEffect(false, true);
			if(Action.bUpdateRotation)
			{
				SetRotation(destActor.Rotation);
			}
			ForceNetRelevant();
			bUpdateSimulatedPosition = true;		
		}
	}
	
	public virtual /*simulated function */void OnSetBlockRigidBody(SeqAct_SetBlockRigidBody Action)
	{
		if(CollisionComponent != default)
		{
			if(Action.InputLinks[0].bHasImpulse)
			{
				CollisionComponent.SetBlockRigidBody(true);			
			}
			else
			{
				if(Action.InputLinks[1].bHasImpulse)
				{
					CollisionComponent.SetBlockRigidBody(false);
				}
			}
		}
	}
	
	public virtual /*simulated function */void OnSetPhysics(SeqAct_SetPhysics Action)
	{
		ForceNetRelevant();
		SetPhysics(((Actor.EPhysics)Action.newPhysics));
		if(((int)RemoteRole) != ((int)Actor.ENetRole.ROLE_None/*0*/))
		{
			SetForcedInitialReplicatedProperty(ObjectConst<ByteProperty>("Physics"), ((int)Physics) == ((int)DefaultAs<Actor>().Physics));
		}
	}
	
	public virtual /*function */void OnChangeCollision(SeqAct_ChangeCollision Action)
	{
		if(Action.ObjInstanceVersion < Action.ObjClassVersion)
		{
			SetCollision(Action.bCollideActors, Action.bBlockActors, Action.bIgnoreEncroachers);		
		}
		else
		{
			SetCollisionType(((Actor.ECollisionType)Action.CollisionType));
		}
		ForceNetRelevant();
		if(((int)RemoteRole) != ((int)Actor.ENetRole.ROLE_None/*0*/))
		{
			SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bCollideActors"), bCollideActors == DefaultAs<Actor>().bCollideActors);
			SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bBlockActors"), bBlockActors == DefaultAs<Actor>().bBlockActors);
		}
	}
	
	public virtual /*simulated function */void OnToggleHidden(SeqAct_ToggleHidden Action)
	{
		if(Action.InputLinks[0].bHasImpulse)
		{
			SetHidden(true);		
		}
		else
		{
			if(Action.InputLinks[1].bHasImpulse)
			{
				SetHidden(false);			
			}
			else
			{
				SetHidden(!bHidden);
			}
		}
		ForceNetRelevant();
		if(((int)RemoteRole) != ((int)Actor.ENetRole.ROLE_None/*0*/))
		{
			SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bHidden"), bHidden == DefaultAs<Actor>().bHidden);
		}
	}
	
	public virtual /*function */void OnAttachToActor(SeqAct_AttachToActor Action)
	{
		/*local */int Idx = default;
		/*local */Actor Attachment = default;
		/*local */Controller C = default;
		/*local */array<Object> objVars = default;
	
		Action.GetObjectVars(ref/*probably?*/ objVars, "Attachment");
		Idx = 0;
		J0x28:{}
		if((Idx < objVars.Length) && Attachment == default)
		{
			Attachment = ((objVars[Idx]) as Actor);
			C = ((Attachment) as Controller);
			if((C != default) && C.Pawn != default)
			{
				Attachment = C.Pawn;
			}
			if(Attachment != default)
			{
				if(Action.bDetach)
				{
					Attachment.SetBase(default, default(Object.Vector?), default(SkeletalMeshComponent), default(name?));
					goto J0x141;
				}
				C = ((this) as Controller);
				if((C != default) && C.Pawn != default)
				{
					C.Pawn.DoKismetAttachment(Attachment, Action);
					goto J0x141;
				}
				DoKismetAttachment(Attachment, Action);
			}
			J0x141:{}
			++ Idx;
			goto J0x28;
		}
	}
	
	public virtual /*function */void DoKismetAttachment(Actor Attachment, SeqAct_AttachToActor Action)
	{
		/*local */bool bOldCollideActors = default, bOldBlockActors = default;
		/*local */Object.Vector X = default, Y = default, Z = default;
	
		Attachment.SetBase(default, default(Object.Vector?), default(SkeletalMeshComponent), default(name?));
		Attachment.SetHardAttach(Action.bHardAttach);
		if((Action.bUseRelativeOffset || Action.bUseRelativeRotation))
		{
			bOldCollideActors = Attachment.bCollideActors;
			bOldBlockActors = Attachment.bBlockActors;
			Attachment.SetCollision(false, false, default(bool?));
			if(Action.bUseRelativeRotation)
			{
				Attachment.SetRotation(Rotation + Action.RelativeRotation);
			}
			if(Action.bUseRelativeOffset)
			{
				GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
				Attachment.SetLocation(((Location + (Action.RelativeOffset.X * X)) + (Action.RelativeOffset.Y * Y)) + (Action.RelativeOffset.Z * Z));
			}
			Attachment.SetCollision(bOldCollideActors, bOldBlockActors, default(bool?));
		}
		Attachment.SetBase(this, default(Object.Vector?), default(SkeletalMeshComponent), default(name?));
	}
	
	public virtual /*simulated function */void OnMakeNoise(SeqAct_MakeNoise Action)
	{
		MakeNoise(Action.Loudness, "ScriptNoise");
	}
	
	public virtual /*event */void OnAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*event */void OnAnimPlay(AnimNodeSequence SeqNode)
	{
	
	}
	
	public virtual /*event */void BeginAnimControl(array<AnimSet> InAnimSets)
	{
	
	}
	
	public virtual /*event */void SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	{
	
	}
	
	public virtual /*event */void SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	{
	
	}
	
	public virtual /*event */void FinishAnimControl()
	{
	
	}
	
	public virtual /*event */bool PlayActorFaceFXAnim(FaceFXAnimSet AnimSet, String GroupName, String SeqName)
	{
	
		return default;
	}
	
	public virtual /*event */void StopActorFaceFXAnim()
	{
	
	}
	
	public virtual /*event */void SetMorphWeight(name MorphNodeName, float MorphWeight)
	{
	
	}
	
	public virtual /*event */void SetSkelControlScale(name SkelControlName, float Scale)
	{
	
	}
	
	public virtual /*simulated function */bool IsActorPlayingFaceFXAnim()
	{
		return false;
	}
	
	public virtual /*event */FaceFXAsset GetActorFaceFXAsset()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsStationary()
	{
		return true;
	}
	
	public virtual /*simulated event */void GetActorEyesViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
		out_Location = Location;
		out_Rotation = Rotation;
	}
	
	// Export UActor::execIsPlayerOwned(FFrame&, void* const)
	public virtual /*native simulated function */bool IsPlayerOwned()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*function */void PawnBaseDied()
	{
	
	}
	
	// Export UActor::execGetTeamNum(FFrame&, void* const)
	public virtual /*native simulated function */byte GetTeamNum()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*simulated event */byte ScriptGetTeamNum()
	{
		return 255;
	}
	
	public virtual /*simulated function */String GetLocationStringFor(PlayerReplicationInfo PRI)
	{
		return "";
	}
	
	public virtual /*simulated function */void NotifyLocalPlayerTeamReceived()
	{
	
	}
	
	public virtual /*simulated function */void FindGoodEndView(PlayerController PC, ref Object.Rotator GoodRotation)
	{
		GoodRotation = PC.Rotation;
	}
	
	// Export UActor::execGetTargetLocation(FFrame&, void* const)
	public virtual /*native simulated function */Object.Vector GetTargetLocation(/*optional */Actor _RequestedBy = default, /*optional */bool? _bRequestAlternateLoc = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*event */void SpawnedByKismet()
	{
	
	}
	
	public virtual /*function */void PickedUpBy(Pawn P)
	{
	
	}
	
	public virtual /*simulated event */void InterpolationStarted(SeqAct_Interp InterpAction)
	{
	
	}
	
	public virtual /*simulated event */void InterpolationFinished(SeqAct_Interp InterpAction)
	{
	
	}
	
	public virtual /*simulated event */void InterpolationChanged(SeqAct_Interp InterpAction)
	{
	
	}
	
	public delegate void RigidBodyCollision_del(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex);
	public virtual RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? Actor_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public virtual RigidBodyCollision_del global_RigidBodyCollision => Actor_RigidBodyCollision;
	public /*event */void Actor_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
	
	}
	
	public virtual /*event */void OnRanOver(SVehicle Vehicle, PrimitiveComponent RunOverComponent, int WheelIndex)
	{
	
	}
	
	// Export UActor::execSetHUDLocation(FFrame&, void* const)
	public virtual /*native simulated function */void SetHUDLocation(Object.Vector NewHUDLocation)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UActor::execNativePostRenderFor(FFrame&, void* const)
	public virtual /*native simulated function */void NativePostRenderFor(PlayerController PC, Canvas Canvas, Object.Vector CameraPosition, Object.Vector CameraDir)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*simulated event */void PostRenderFor(PlayerController PC, Canvas Canvas, Object.Vector CameraPosition, Object.Vector CameraDir)
	{
	
	}
	
	public virtual /*simulated event */void RootMotionModeChanged(SkeletalMeshComponent SkelComp)
	{
	
	}
	
	public virtual /*simulated event */void RootMotionExtracted(SkeletalMeshComponent SkelComp, ref AnimNode.BoneAtom ExtractedRootMotionDelta)
	{
	
	}
	
	public virtual /*event */void PostInitAnimTree(SkeletalMeshComponent SkelComp)
	{
	
	}
	
	// Export UActor::execGetPackageGuid(FFrame&, void* const)
	public /*native final function */static Object.Guid GetPackageGuid(name PackageName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*function */void InitLOI()
	{
		/*local */PlayerController PC = default;
	
		
		// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			if(PC.bCanSeeLOI)
			{
				AssignPlayerToLOI(PC);
				break;
				continue;
			}		
		}	
	}
	
	public virtual /*function */void AssignPlayerToLOI(Actor Player)
	{
	
	}
	
	public virtual /*event */void ActivateLOI()
	{
	
	}
	
	public virtual /*function */void OnDeactivateLOI(SeqAct_DeactivateLOI Sender)
	{
	
	}
	
	public virtual /*function */void OnActivateLOI(SeqAct_ActivateLOI Sender)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
		Timer = null;
		Landed = null;
		Touch = null;
		UnTouch = null;
		BaseChange = null;
		FellOutOfWorld = null;
		OutsideWorldBounds = null;
		SetInitialState = null;
		KilledBy = null;
		TakeDamage = null;
		MatchStarting = null;
		Reset = null;
		RigidBodyCollision = null;
	
	}
	public Actor()
	{
		// Object Offset:0x002583C0
		bPushedByEncroachers = true;
		bRouteBeginPlayEvenIfStatic = true;
		bReplicateMovement = true;
		bMovable = true;
		bJustTeleported = true;
		CustomTimeDilation = 1.0f;
		Role = Actor.ENetRole.ROLE_Authority;
		NetUpdateFrequency = 100.0f;
		NetPriority = 1.0f;
		DrawScale = 1.0f;
		DrawScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		MessageClass = ClassT<LocalMessage>()/*Ref Class'LocalMessage'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
		};
	}
}
}