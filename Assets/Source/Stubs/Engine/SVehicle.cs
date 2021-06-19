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
	
	public/*()*/ /*noclear const export editinline */SVehicleSimBase SimObj;
	public/*()*/ /*export editinline */array</*export editinline */SVehicleWheel> Wheels;
	public/*()*/ Object.Vector COMOffset;
	public/*()*/ Object.Vector InertiaTensorMultiplier;
	public/*(UprightConstraint)*/ bool bStayUpright;
	public bool bUseSuspensionAxis;
	public bool bUpdateWheelShapes;
	public /*const */bool bVehicleOnGround;
	public /*const */bool bVehicleOnWater;
	public /*const */bool bIsInverted;
	public /*const */bool bChassisTouchingGround;
	public /*const */bool bWasChassisTouchingGroundLastTick;
	public bool bCanFlip;
	public bool bFlipRight;
	public bool bIsUprighting;
	public bool bOutputHandbrake;
	public bool bHoldingDownHandbrake;
	public/*(UprightConstraint)*/ float StayUprightRollResistAngle;
	public/*(UprightConstraint)*/ float StayUprightPitchResistAngle;
	public/*(UprightConstraint)*/ float StayUprightStiffness;
	public/*(UprightConstraint)*/ float StayUprightDamping;
	public /*export editinline */RB_StayUprightSetup StayUprightConstraintSetup;
	public /*export editinline */RB_ConstraintInstance StayUprightConstraintInstance;
	public float HeavySuspensionShiftPercent;
	public/*()*/ float MaxSpeed;
	public/*()*/ float MaxAngularVelocity;
	public /*const */float TimeOffGround;
	public/*(Uprighting)*/ float UprightLiftStrength;
	public/*(Uprighting)*/ float UprightTorqueStrength;
	public/*(Uprighting)*/ float UprightTime;
	public float UprightStartTime;
	public/*(Sounds)*/ /*const editconst export editinline */AudioComponent EngineSound;
	public/*(Sounds)*/ /*const editconst export editinline */AudioComponent SquealSound;
	public/*(Sounds)*/ SoundCue CollisionSound;
	public/*(Sounds)*/ SoundCue EnterVehicleSound;
	public/*(Sounds)*/ SoundCue ExitVehicleSound;
	public/*(Sounds)*/ float CollisionIntervalSecs;
	public/*(Sounds)*/ /*const */float SquealThreshold;
	public/*(Sounds)*/ /*const */float SquealLatThreshold;
	public/*(Sounds)*/ /*const */float LatAngleVolumeMult;
	public/*(Sounds)*/ /*const */float EngineStartOffsetSecs;
	public/*(Sounds)*/ /*const */float EngineStopOffsetSecs;
	public float LastCollisionSoundTime;
	public float OutputBrake;
	public float OutputGas;
	public float OutputSteering;
	public float OutputRise;
	public float ForwardVel;
	public int NumPoweredWheels;
	public/*()*/ Object.Vector BaseOffset;
	public/*()*/ float CamDist;
	public int DriverViewPitch;
	public int DriverViewYaw;
	public /*native const */SVehicle.VehicleState VState;
	public /*native const */float AngErrorAccumulator;
	public float RadialImpulseScaling;
	
	//replication
	//{
	//	 if(((int)Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
	//		VState;
	//}
	
	// Export USVehicle::execSetWheelCollision(FFrame&, void* const)
	public virtual /*native final function */void SetWheelCollision(int WheelNum, bool bCollision)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void PostInitAnimTree(SkeletalMeshComponent SkelComp)
	{
	
	}
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public override /*simulated function */void TurnOff()
	{
	
	}
	
	public virtual /*simulated function */void StopVehicleSounds()
	{
	
	}
	
	public override /*simulated function */void TakeRadiusDamage(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser)
	{
	
	}
	
	// Export USVehicle::execInitVehicleRagdoll(FFrame&, void* const)
	public virtual /*native function */void InitVehicleRagdoll(SkeletalMesh RagdollMesh, PhysicsAsset RagdollPhysAsset, Object.Vector ActorMove)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*function */void AddVelocity(Object.Vector NewVelocity, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
	
	}
	
	public override Died_del Died { get => bfield_Died ?? SVehicle_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => SVehicle_Died;
	public /*function */bool SVehicle_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
	
		return default;
	}
	
	public override /*simulated function */bool CalcCamera(float fDeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot, ref float out_FOV)
	{
	
		return default;
	}
	
	public override /*simulated function */name GetDefaultCameraMode(PlayerController RequestedBy)
	{
	
		return default;
	}
	
	public override /*function */bool TryToDrive(Pawn P)
	{
	
		return default;
	}
	
	// Export USVehicle::execHasWheelsOnGround(FFrame&, void* const)
	public virtual /*native simulated function */bool HasWheelsOnGround()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */void StartEngineSound()
	{
	
	}
	
	public virtual /*simulated function */void StartEngineSoundTimed()
	{
	
	}
	
	public virtual /*simulated function */void StopEngineSound()
	{
	
	}
	
	public virtual /*simulated function */void StopEngineSoundTimed()
	{
	
	}
	
	public virtual /*simulated function */void VehiclePlayEnterSound()
	{
	
	}
	
	public virtual /*simulated function */void VehiclePlayExitSound()
	{
	
	}
	
	public override /*simulated function */void DrivingStatusChanged()
	{
	
	}
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? SVehicle_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => SVehicle_RigidBodyCollision;
	public /*simulated event */void SVehicle_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
	
	}
	
	public virtual /*simulated event */void SuspensionHeavyShift(float Delta)
	{
	
	}
	
	public override /*function */void PostTeleport(Teleporter OutTeleporter)
	{
	
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*simulated function */void DisplayWheelsDebug(HUD HUD, float YL)
	{
	
	}
	
	public virtual /*simulated function */float HermiteEval(float Slip)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void GetSVehicleDebug(ref array<String> DebugInfo)
	{
	
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