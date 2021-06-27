namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Vehicle : Pawn/*
		abstract
		native
		nativereplication
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public /*repnotify */Pawn Driver;
	public /*repnotify */bool bDriving;
	public bool bDriverIsVisible;
	public bool bAttachDriver;
	public bool bTurnInPlace;
	public bool bSeparateTurretFocus;
	public bool bFollowLookDir;
	public bool bHasHandbrake;
	public bool bScriptedRise;
	public bool bAvoidReversing;
	public bool bRetryPathfindingWithDriver;
	public/*()*/ bool bIgnoreStallZ;
	public bool bDoExtraNetRelevancyTraces;
	public/*()*/ array<Object.Vector> ExitPositions;
	public float ExitRadius;
	public Object.Vector ExitOffset;
	public/*()*/ float Steering;
	public/*()*/ float Throttle;
	public/*()*/ float Rise;
	public Object.Vector TargetLocationAdjustment;
	public float DriverDamageMult;
	public/*()*/ float MomentumMult;
	public Core.ClassT<DamageType> CrushedDamageType;
	public float MinCrushSpeed;
	public float ForceCrushPenetration;
	public byte StuckCount;
	public float ThrottleTime;
	public float StuckTime;
	public float OldSteering;
	public float OnlySteeringStartTime;
	public float OldThrottle;
	public /*const */float AIMoveCheckTime;
	public float VehicleMovingTime;
	public float TurnTime;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bDriving;
	//
	//	 if((bNetDirty && (((bNetOwner || Driver == default)) || !Driver.bHidden)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Driver;
	//}
	
	public override /*simulated function */void NotifyTeamChanged()
	{
		// stub
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		// stub
	}
	
	public override /*function */void Suicide()
	{
		// stub
	}
	
	// Export UVehicle::execGetTargetLocation(FFrame&, void* const)
	public override /*native simulated function */Object.Vector GetTargetLocation(/*optional */Actor? _RequestedBy = default, /*optional */bool? _bRequestAlternateLoc = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*simulated function */void TakeRadiusDamage(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser)
	{
		// stub
	}
	
	public virtual /*function */void DriverRadiusDamage(float DamageAmount, float DamageRadius, Controller EventInstigator, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HitLocation, Actor DamageCauser)
	{
		// stub
	}
	
	public override /*function */void PlayerChangedTeam()
	{
		// stub
	}
	
	public override /*simulated function */void SetBaseEyeheight()
	{
		// stub
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*function */bool CheatWalk()
	{
		// stub
		return default;
	}
	
	public override /*function */bool CheatGhost()
	{
		// stub
		return default;
	}
	
	public override /*function */bool CheatFly()
	{
		// stub
		return default;
	}
	
	public override /*simulated event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*simulated function */void Destroyed_HandleDriver()
	{
		// stub
	}
	
	public virtual /*function */bool CanEnterVehicle(Pawn P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AnySeatAvailable()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool TryToDrive(Pawn P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool DriverEnter(Pawn P)
	{
		// stub
		return default;
	}
	
	public override /*function */void PossessedBy(Controller C, bool bVehicleTransition)
	{
		// stub
	}
	
	public virtual /*function */void EntryAnnouncement(Controller C)
	{
		// stub
	}
	
	public virtual /*simulated function */void AttachDriver(Pawn P)
	{
		// stub
	}
	
	public virtual /*simulated function */void DetachDriver(Pawn P)
	{
		// stub
	}
	
	public virtual /*event */bool ContinueOnFoot()
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool DriverLeave(bool bForceLeave)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void SetInputs(float InForward, float InStrafe, float InUp)
	{
		// stub
	}
	
	public virtual /*function */void DriverLeft()
	{
		// stub
	}
	
	public virtual /*function */bool PlaceExitingDriver(/*optional */Pawn? _ExitingDriver = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool FindAutoExit(Pawn ExitingDriver)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool TryExitPos(Pawn ExitingDriver, Object.Vector ExitPos, bool bMustFindGround)
	{
		// stub
		return default;
	}
	
	public override /*function */void UnPossessed()
	{
		// stub
	}
	
	public override /*function */Controller SetKillInstigator(Controller InstigatedBy, Core.ClassT<DamageType> DamageType)
	{
		// stub
		return default;
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? Vehicle_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => Vehicle_TakeDamage;
	public /*event */void Vehicle_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
		// stub
	}
	
	public virtual /*function */void AdjustDriverDamage(ref int Damage, Controller InstigatedBy, Object.Vector HitLocation, ref Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
		// stub
	}
	
	public override /*function */void ThrowActiveWeapon(/*optional */Core.ClassT<DamageType>? _DamageType = default)
	{
		// stub
	}
	
	public override Died_del Died { get => bfield_Died ?? Vehicle_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => Vehicle_Died;
	public /*function */bool Vehicle_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void DriverDied()
	{
		// stub
	}
	
	public override /*simulated function */void PlayDying(Core.ClassT<DamageType> DamageType, Object.Vector HitLoc)
	{
		// stub
	}
	
	public override /*simulated function */name GetDefaultCameraMode(PlayerController RequestedBy)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void FaceRotation(Object.Rotator NewRotation, float DeltaTime)
	{
		// stub
	}
	
	public override /*event */void EncroachedBy(Actor Other)
	{
		// stub
	}
	
	public virtual /*function */Controller GetCollisionDamageInstigator()
	{
		// stub
		return default;
	}
	
	public override /*event */bool EncroachingOn(Actor Other)
	{
		// stub
		return default;
	}
	
	public override /*function */void CrushedBy(Pawn OtherPawn)
	{
		// stub
	}
	
	public virtual /*simulated function */Object.Vector GetEntryLocation()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void SetDriving(bool B)
	{
		// stub
	}
	
	public virtual /*function */void HandleDeadVehicleDriver()
	{
		// stub
	}
	
	public virtual /*simulated function */void DrivingStatusChanged()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*function */void NotifyDriverTakeHit(Controller InstigatedBy, Object.Vector HitLocation, int Damage, Core.ClassT<DamageType> DamageType, Object.Vector Momentum)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
		Died = null;
	
	}
	public Vehicle()
	{
		var Default__Vehicle_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Vehicle.SceneCaptureCharacterComponent0' */;
		var Default__Vehicle_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Vehicle.DrawFrust0' */;
		var Default__Vehicle_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Vehicle.CollisionCylinder' */;
		// Object Offset:0x003F2257
		bAttachDriver = true;
		bRetryPathfindingWithDriver = true;
		bDoExtraNetRelevancyTraces = true;
		MomentumMult = 1.0f;
		CrushedDamageType = ClassT<DmgType_Crushed>()/*Ref Class'DmgType_Crushed'*/;
		MinCrushSpeed = 20.0f;
		ForceCrushPenetration = 10.0f;
		TurnTime = 2.0f;
		bCanBeBaseForPawns = true;
		bDontPossess = true;
		bPathfindsAsVehicle = true;
		SceneCapture = Default__Vehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Vehicle.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Vehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__Vehicle.DrawFrust0'*/;
		LandMovementState = (name)"PlayerDriving";
		CylinderComponent = Default__Vehicle_CollisionCylinder/*Ref CylinderComponent'Default__Vehicle.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Vehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Vehicle.SceneCaptureCharacterComponent0'*/,
			Default__Vehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__Vehicle.DrawFrust0'*/,
			Default__Vehicle_CollisionCylinder/*Ref CylinderComponent'Default__Vehicle.CollisionCylinder'*/,
		};
		CollisionComponent = Default__Vehicle_CollisionCylinder/*Ref CylinderComponent'Default__Vehicle.CollisionCylinder'*/;
	}
}
}