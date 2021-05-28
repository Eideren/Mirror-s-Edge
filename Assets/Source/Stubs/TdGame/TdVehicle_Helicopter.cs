namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdVehicle_Helicopter : SVehicle/*
		native
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public partial struct /*native */GunnerSeat
	{
		public/*()*/ /*editinline */Pawn StoragePawn;
		public/*()*/ name CharacterSeatSocket;
		public/*()*/ name CharacterSeatBone;
		public/*()*/ Object.Vector LocOffset;
		public/*()*/ float YawOffset;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006BED79
	//		StoragePawn = default;
	//		CharacterSeatSocket = (name)"None";
	//		CharacterSeatBone = (name)"None";
	//		LocOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		YawOffset = 0.0f;
	//	}
	};
	
	public/*()*/ float MaxAcceleration;
	public/*()*/ float Force;
	public/*()*/ float MaxVelocity;
	public Object.Vector WantedPosition;
	public Object.Rotator RotationVelocity;
	public Object.Rotator HoveringNoiceDirection;
	public TdAI_HeliController.EHeliAttackSide AimWithThisSide;
	public Object.Vector AimAtPoint;
	public bool bHovering;
	public bool bIsHeliDustEffectActive;
	public /*private */int NumberOfGunners;
	public /*export editinline */TdSkeletalMeshComponent HelicopterSkeletalMesh;
	public TdAI_HeliController myController;
	public/*(Seats)*/ array<TdVehicle_Helicopter.GunnerSeat> Seats;
	public /*transient */Emitter HeliDustEffectEmitter;
	
	public virtual /*function */void Initialize(TdAI_HeliController C)
	{
	
	}
	
	public virtual /*event */int AddGunner(Pawn Pawn)
	{
	
		return default;
	}
	
	public virtual /*function */Pawn GetGunner(int Index)
	{
	
		return default;
	}
	
	public virtual /*function */int GetNumberOfGunners()
	{
	
		return default;
	}
	
	public virtual /*function */void StartDustEffect()
	{
	
	}
	
	public TdVehicle_Helicopter()
	{
		// Object Offset:0x006BF365
		MaxAcceleration = 1000.0f;
		Force = 500.0f;
		MaxVelocity = 2000.0f;
		AimWithThisSide = TdAI_HeliController.EHeliAttackSide.ESide_None;
		HelicopterSkeletalMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x03128372
			CastShadow = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdVehicle_Helicopter.HelicopterSkeletalMeshObject' */;
		Seats = new array<TdVehicle_Helicopter.GunnerSeat>
		{
			new TdVehicle_Helicopter.GunnerSeat
			{
				StoragePawn = default,
				CharacterSeatSocket = (name)"DriverSeat",
				CharacterSeatBone = (name)"Chassis",
				LocOffset = new Vector
				{
					X=75.0f,
					Y=-100.0f,
					Z=190.0f
				},
				YawOffset = -16384.0f,
			},
			new TdVehicle_Helicopter.GunnerSeat
			{
				StoragePawn = default,
				CharacterSeatSocket = (name)"FrontPassSeat",
				CharacterSeatBone = (name)"Chassis",
				LocOffset = new Vector
				{
					X=75.0f,
					Y=100.0f,
					Z=190.0f
				},
				YawOffset = 16384.0f,
			},
		};
		bStayUpright = true;
		StayUprightRollResistAngle = 6.0f;
		StayUprightPitchResistAngle = 6.0f;
		StayUprightStiffness = 200.0f;
		StayUprightDamping = 40.0f;
		StayUprightConstraintSetup = LoadAsset<RB_StayUprightSetup>("Default__TdVehicle_Helicopter.MyStayUprightSetup")/*Ref RB_StayUprightSetup'Default__TdVehicle_Helicopter.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__TdVehicle_Helicopter.MyStayUprightConstraintInstance")/*Ref RB_ConstraintInstance'Default__TdVehicle_Helicopter.MyStayUprightConstraintInstance'*/;
		UprightLiftStrength = 30.0f;
		UprightTorqueStrength = 40.0f;
		bTurnInPlace = true;
		bFollowLookDir = true;
		MomentumMult = 2.0f;
		bCanFly = true;
		bCanStrafe = true;
		PeripheralVision = -1.0f;
		GroundSpeed = 1500.0f;
		AirSpeed = 1500.0f;
		BaseEyeHeight = 50.0f;
		EyeHeight = 50.0f;
		Health = 300;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdVehicle_Helicopter.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdVehicle_Helicopter.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdVehicle_Helicopter.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdVehicle_Helicopter.DrawFrust0'*/;
		Mesh = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BF86
			SkeletalMesh = LoadAsset<SkeletalMesh>("VH_Common.SK_Helicopter_Placeholder")/*Ref SkeletalMesh'VH_Common.SK_Helicopter_Placeholder'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("VH_Common.PA_Helicopter_Placeholder")/*Ref PhysicsAsset'VH_Common.PA_Helicopter_Placeholder'*/,
			HiddenGame = true,
			bOwnerNoSee = true,
		}/* Reference: SkeletalMeshComponent'Default__TdVehicle_Helicopter.SVehicleMesh' */;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x01AB507A
			CollisionHeight = 1.0f,
			CollisionRadius = 1.0f,
			Translation = new Vector
			{
				X=-25.0f,
				Y=0.0f,
				Z=0.0f
			},
		}/* Reference: CylinderComponent'Default__TdVehicle_Helicopter.CollisionCylinder' */;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdVehicle_Helicopter.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdVehicle_Helicopter.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdVehicle_Helicopter.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdVehicle_Helicopter.DrawFrust0'*/,
			//Components[2]=
			new CylinderComponent
			{
				// Object Offset:0x01AB507A
				CollisionHeight = 1.0f,
				CollisionRadius = 1.0f,
				Translation = new Vector
				{
					X=-25.0f,
					Y=0.0f,
					Z=0.0f
				},
			}/* Reference: CylinderComponent'Default__TdVehicle_Helicopter.CollisionCylinder' */,
			//Components[3]=
			new SkeletalMeshComponent
			{
				// Object Offset:0x0279BF86
				SkeletalMesh = LoadAsset<SkeletalMesh>("VH_Common.SK_Helicopter_Placeholder")/*Ref SkeletalMesh'VH_Common.SK_Helicopter_Placeholder'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("VH_Common.PA_Helicopter_Placeholder")/*Ref PhysicsAsset'VH_Common.PA_Helicopter_Placeholder'*/,
				HiddenGame = true,
				bOwnerNoSee = true,
			}/* Reference: SkeletalMeshComponent'Default__TdVehicle_Helicopter.SVehicleMesh' */,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x01AB507A
			CollisionHeight = 1.0f,
			CollisionRadius = 1.0f,
			Translation = new Vector
			{
				X=-25.0f,
				Y=0.0f,
				Z=0.0f
			},
		}/* Reference: CylinderComponent'Default__TdVehicle_Helicopter.CollisionCylinder' */;
	}
}
}