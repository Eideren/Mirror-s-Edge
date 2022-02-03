namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicle : Vehicle/*
		abstract
		native
		nativereplication
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public partial struct /*native */VehicleState
	{
		public Actor.RigidBodyState RBState;
		public byte ServerBrake;
		public byte ServerGas;
		public byte ServerSteering;
		public byte ServerRise;
		public bool bServerHandbrake;
		public int ServerView;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003F3320
	//		RBState = new Actor.RigidBodyState
	//		{
	//			Position = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			Quaternion = new Quat
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f,
	//				W=0.0f
	//			},
	//			LinVel = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			AngVel = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			bNewData = 0,
	//		};
	//		ServerBrake = 0;
	//		ServerGas = 0;
	//		ServerSteering = 0;
	//		ServerRise = 0;
	//		bServerHandbrake = false;
	//		ServerView = 0;
	//	}
	};
	
	[Category] [noclear, Const, export, editinline] public SVehicleSimBase SimObj;
	[Category] [export, editinline] public array</*export editinline */SVehicleWheel> Wheels;
	[Category] public Object.Vector COMOffset;
	[Category] public Object.Vector InertiaTensorMultiplier;
	[Category("UprightConstraint")] public bool bStayUpright;
	public bool bUseSuspensionAxis;
	public bool bUpdateWheelShapes;
	[Const] public bool bVehicleOnGround;
	[Const] public bool bVehicleOnWater;
	[Const] public bool bIsInverted;
	[Const] public bool bChassisTouchingGround;
	[Const] public bool bWasChassisTouchingGroundLastTick;
	public bool bCanFlip;
	public bool bFlipRight;
	public bool bIsUprighting;
	public bool bOutputHandbrake;
	public bool bHoldingDownHandbrake;
	[Category("UprightConstraint")] public float StayUprightRollResistAngle;
	[Category("UprightConstraint")] public float StayUprightPitchResistAngle;
	[Category("UprightConstraint")] public float StayUprightStiffness;
	[Category("UprightConstraint")] public float StayUprightDamping;
	[export, editinline] public RB_StayUprightSetup StayUprightConstraintSetup;
	[export, editinline] public RB_ConstraintInstance StayUprightConstraintInstance;
	public float HeavySuspensionShiftPercent;
	[Category] public float MaxSpeed;
	[Category] public float MaxAngularVelocity;
	[Const] public float TimeOffGround;
	[Category("Uprighting")] public float UprightLiftStrength;
	[Category("Uprighting")] public float UprightTorqueStrength;
	[Category("Uprighting")] public float UprightTime;
	public float UprightStartTime;
	[Category("Sounds")] [Const, editconst, export, editinline] public AudioComponent EngineSound;
	[Category("Sounds")] [Const, editconst, export, editinline] public AudioComponent SquealSound;
	[Category("Sounds")] public SoundCue CollisionSound;
	[Category("Sounds")] public SoundCue EnterVehicleSound;
	[Category("Sounds")] public SoundCue ExitVehicleSound;
	[Category("Sounds")] public float CollisionIntervalSecs;
	[Category("Sounds")] [Const] public float SquealThreshold;
	[Category("Sounds")] [Const] public float SquealLatThreshold;
	[Category("Sounds")] [Const] public float LatAngleVolumeMult;
	[Category("Sounds")] [Const] public float EngineStartOffsetSecs;
	[Category("Sounds")] [Const] public float EngineStopOffsetSecs;
	public float LastCollisionSoundTime;
	public float OutputBrake;
	public float OutputGas;
	public float OutputSteering;
	public float OutputRise;
	public float ForwardVel;
	public int NumPoweredWheels;
	[Category] public Object.Vector BaseOffset;
	[Category] public float CamDist;
	public int DriverViewPitch;
	public int DriverViewYaw;
	[native, Const] public SVehicle.VehicleState VState;
	[native, Const] public float AngErrorAccumulator;
	public float RadialImpulseScaling;
	
	//replication
	//{
	//	 if(((int)Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
	//		VState;
	//}
	
	// Export USVehicle::execSetWheelCollision(FFrame&, void* const)
	public virtual /*native final function */void SetWheelCollision(int WheelNum, bool bCollision)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*simulated event */void eventPostBeginPlay()
	{
		// stub
	}
	
	public override /*simulated event */void PostInitAnimTree(SkeletalMeshComponent SkelComp)
	{
		// stub
	}
	
	public override /*simulated event */void Destroyed()
	{
		// stub
	}
	
	public override /*simulated function */void TurnOff()
	{
		// stub
	}
	
	public virtual /*simulated function */void StopVehicleSounds()
	{
		// stub
	}
	
	public override /*simulated function */void TakeRadiusDamage(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser)
	{
		// stub
	}
	
	// Export USVehicle::execInitVehicleRagdoll(FFrame&, void* const)
	public virtual /*native function */void InitVehicleRagdoll(SkeletalMesh RagdollMesh, PhysicsAsset RagdollPhysAsset, Object.Vector ActorMove)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */void AddVelocity(Object.Vector NewVelocity, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		// stub
	}
	
	public override Died_del Died { get => bfield_Died ?? SVehicle_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => SVehicle_Died;
	public /*function */bool SVehicle_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */bool CalcCamera(float fDeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot, ref float out_FOV)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */name GetDefaultCameraMode(PlayerController RequestedBy)
	{
		// stub
		return default;
	}
	
	public override /*function */bool TryToDrive(Pawn P)
	{
		// stub
		return default;
	}
	
	// Export USVehicle::execHasWheelsOnGround(FFrame&, void* const)
	public virtual /*native simulated function */bool HasWheelsOnGround()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*simulated function */void StartEngineSound()
	{
		// stub
	}
	
	public virtual /*simulated function */void StartEngineSoundTimed()
	{
		// stub
	}
	
	public virtual /*simulated function */void StopEngineSound()
	{
		// stub
	}
	
	public virtual /*simulated function */void StopEngineSoundTimed()
	{
		// stub
	}
	
	public virtual /*simulated function */void VehiclePlayEnterSound()
	{
		// stub
	}
	
	public virtual /*simulated function */void VehiclePlayExitSound()
	{
		// stub
	}
	
	public override /*simulated function */void DrivingStatusChanged()
	{
		// stub
	}
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? SVehicle_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => SVehicle_RigidBodyCollision;
	public /*simulated event */void SVehicle_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
		// stub
	}
	
	public virtual /*simulated event */void SuspensionHeavyShift(float Delta)
	{
		// stub
	}
	
	public override /*function */void PostTeleport(Teleporter OutTeleporter)
	{
		// stub
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		// stub
	}
	
	public virtual /*simulated function */void DisplayWheelsDebug(HUD HUD, float YL)
	{
		// stub
	}
	
	public virtual /*simulated function */float HermiteEval(float Slip)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void GetSVehicleDebug(ref array<String> DebugInfo)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Died = null;
		RigidBodyCollision = null;
	
	}
	public SVehicle()
	{
		var Default__SVehicle_MyStayUprightSetup = new RB_StayUprightSetup
		{
		}/* Reference: RB_StayUprightSetup'Default__SVehicle.MyStayUprightSetup' */;
		var Default__SVehicle_MyStayUprightConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__SVehicle.MyStayUprightConstraintInstance' */;
		var Default__SVehicle_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__SVehicle.SceneCaptureCharacterComponent0' */;
		var Default__SVehicle_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__SVehicle.DrawFrust0' */;
		var Default__SVehicle_SVehicleMesh = new SkeletalMeshComponent
		{
			// Object Offset:0x004CEE36
			bUseSingleBodyPhysics = 1,
			bForceDiscardRootMotion = true,
			CollideActors = true,
			BlockActors = true,
			BlockZeroExtent = true,
			BlockNonZeroExtent = true,
			BlockRigidBody = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_Vehicle,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				Vehicle = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
			bNotifyRigidBodyCollision = true,
			ScriptRigidBodyCollisionThreshold = 250.0f,
		}/* Reference: SkeletalMeshComponent'Default__SVehicle.SVehicleMesh' */;
		var Default__SVehicle_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__SVehicle.CollisionCylinder' */;
		// Object Offset:0x003F5B3E
		InertiaTensorMultiplier = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		bCanFlip = true;
		StayUprightConstraintSetup = Default__SVehicle_MyStayUprightSetup/*Ref RB_StayUprightSetup'Default__SVehicle.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = Default__SVehicle_MyStayUprightConstraintInstance/*Ref RB_ConstraintInstance'Default__SVehicle.MyStayUprightConstraintInstance'*/;
		HeavySuspensionShiftPercent = 0.50f;
		MaxSpeed = 2500.0f;
		MaxAngularVelocity = 75000.0f;
		UprightLiftStrength = 225.0f;
		UprightTorqueStrength = 50.0f;
		UprightTime = 1.50f;
		SquealThreshold = 250.0f;
		SquealLatThreshold = 250.0f;
		LatAngleVolumeMult = 1.0f;
		EngineStartOffsetSecs = 2.0f;
		EngineStopOffsetSecs = 1.0f;
		BaseOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=128.0f
		};
		CamDist = 512.0f;
		RadialImpulseScaling = 1.0f;
		SceneCapture = Default__SVehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__SVehicle.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__SVehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__SVehicle.DrawFrust0'*/;
		Mesh = Default__SVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__SVehicle.SVehicleMesh'*/;
		CylinderComponent = Default__SVehicle_CollisionCylinder/*Ref CylinderComponent'Default__SVehicle.CollisionCylinder'*/;
		bNetInitialRotation = true;
		bBlocksTeleport = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SVehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__SVehicle.SceneCaptureCharacterComponent0'*/,
			Default__SVehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__SVehicle.DrawFrust0'*/,
			Default__SVehicle_CollisionCylinder/*Ref CylinderComponent'Default__SVehicle.CollisionCylinder'*/,
			Default__SVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__SVehicle.SVehicleMesh'*/,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		CollisionComponent = Default__SVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__SVehicle.SVehicleMesh'*/;
	}
}
}