namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdVehicle : SVehicle/*
		abstract
		native
		nativereplication
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct /*native */VehicleSeat
	{
		[Category] [editinline] public Pawn StoragePawn;
		[Category] [editinline] public Vehicle SeatPawn;
		[Category] public Core.ClassT<Vehicle> SeatPawnClass;
		[Category] public name CharacterSeatSocket;
		[Category] public name CharacterSeatBone;
		[Category] public name CameraSeatSocket;
		[Category] public float CameraOffset;
		[Category] public float CameraEyeHeight;
		[Category] public float ViewPitchMin;
		[Category] public float ViewPitchMax;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006BCE41
	//		StoragePawn = default;
	//		SeatPawn = default;
	//		SeatPawnClass = default;
	//		CharacterSeatSocket = (name)"None";
	//		CharacterSeatBone = (name)"None";
	//		CameraSeatSocket = (name)"None";
	//		CameraOffset = 0.0f;
	//		CameraEyeHeight = 0.0f;
	//		ViewPitchMin = 0.0f;
	//		ViewPitchMax = 0.0f;
	//	}
	};
	
	public partial struct /*native */TimePosition
	{
		public Object.Vector Position;
		public float Time;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006BD1C3
	//		Position = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Time = 0.0f;
	//	}
	};
	
	[Category("Seats")] public float SeatCameraScale;
	public array<TdVehicle.TimePosition> OldPositions;
	public float CameraLag;
	public Object.Vector CameraOffset;
	public float LookForwardDist;
	public float MinCameraDistSq;
	public float CameraSmoothingFactor;
	[repnotify] public bool bDeadVehicle;
	public PhysicsAsset RagdollAsset;
	[Category("Seats")] public array<TdVehicle.VehicleSeat> Seats;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bDeadVehicle;
	//}
	
	public override /*simulated function */void eventPostBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */void InitializeSeats()
	{
		// stub
	}
	
	public virtual /*function */bool SeatAvailable(int seatIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */int GetSeatIndexForController(Controller ControllerToMove)
	{
		// stub
		return default;
	}
	
	public virtual /*function */Controller GetControllerForSeatIndex(int seatIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*reliable server function */void ServerChangeSeat(int RequestedSeat)
	{
		// stub
	}
	
	public override /*simulated function */bool CalcCamera(float DeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot, ref float out_FOV)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void VehicleCalcCamera(float DeltaTime, int seatIndex, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot, /*optional */Pawn _P = default)
	{
		// stub
	}
	
	public virtual /*simulated function */Object.Vector GetCameraStart(int seatIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ChangeSeat(Controller ControllerToMove, int RequestedSeat)
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetFirstAvailableSeat()
	{
		// stub
		return default;
	}
	
	public override /*function */bool TryToDrive(Pawn P)
	{
		// stub
		return default;
	}
	
	public override /*function */bool CanEnterVehicle(Pawn P)
	{
		// stub
		return default;
	}
	
	public override /*function */bool DriverEnter(Pawn P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool PassengerEnter(Pawn P, int seatIndex)
	{
		// stub
		return default;
	}
	
	public override /*event */bool DriverLeave(bool bForceLeave)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PassengerLeave(Pawn P, int seatIndex)
	{
		// stub
	}
	
	public TdVehicle()
	{
		var Default__TdVehicle_MyStayUprightSetup = new RB_StayUprightSetup
		{
		}/* Reference: RB_StayUprightSetup'Default__TdVehicle.MyStayUprightSetup' */;
		var Default__TdVehicle_MyStayUprightConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__TdVehicle.MyStayUprightConstraintInstance' */;
		var Default__TdVehicle_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdVehicle.SceneCaptureCharacterComponent0' */;
		var Default__TdVehicle_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdVehicle.DrawFrust0' */;
		var Default__TdVehicle_SVehicleMesh = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BF52
			bCastDynamicShadow = false,
		}/* Reference: SkeletalMeshComponent'Default__TdVehicle.SVehicleMesh' */;
		var Default__TdVehicle_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4FF2
			CollideActors = false,
			BlockActors = false,
			BlockZeroExtent = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdVehicle.CollisionCylinder' */;
		// Object Offset:0x006BE6C1
		StayUprightConstraintSetup = Default__TdVehicle_MyStayUprightSetup/*Ref RB_StayUprightSetup'Default__TdVehicle.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = Default__TdVehicle_MyStayUprightConstraintInstance/*Ref RB_ConstraintInstance'Default__TdVehicle.MyStayUprightConstraintInstance'*/;
		bDriverIsVisible = true;
		MomentumMult = 2.0f;
		MinCrushSpeed = 100.0f;
		SceneCapture = Default__TdVehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdVehicle.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdVehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__TdVehicle.DrawFrust0'*/;
		Mesh = Default__TdVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__TdVehicle.SVehicleMesh'*/;
		CylinderComponent = Default__TdVehicle_CollisionCylinder/*Ref CylinderComponent'Default__TdVehicle.CollisionCylinder'*/;
		InventoryManagerClass = ClassT<TdInventoryManager>()/*Ref Class'TdInventoryManager'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdVehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdVehicle.SceneCaptureCharacterComponent0'*/,
			Default__TdVehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__TdVehicle.DrawFrust0'*/,
			Default__TdVehicle_CollisionCylinder/*Ref CylinderComponent'Default__TdVehicle.CollisionCylinder'*/,
			Default__TdVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__TdVehicle.SVehicleMesh'*/,
		};
		CollisionComponent = Default__TdVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__TdVehicle.SVehicleMesh'*/;
	}
}
}