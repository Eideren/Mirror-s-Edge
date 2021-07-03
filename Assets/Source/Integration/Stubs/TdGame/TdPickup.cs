namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPickup : DroppedPickup/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public /*native const */Actor.RigidBodyState RBState;
	public /*native const */float AngErrorAccumulator;
	public /*transient */SoundCue CollisionSnd;
	public /*private transient */int AmmoCount;
	public /*private transient */int ClipCount;
	public /*export editinline */SkeletalMeshComponent PickMesh;
	public /*private export editinline transient */DynamicLightEnvironmentComponent MeshLightEnvironment;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RBState;
	//}
	
	public delegate bool CanBePickedUpBy_del(Pawn P);
	public virtual CanBePickedUpBy_del CanBePickedUpBy { get => bfield_CanBePickedUpBy ?? TdPickup_CanBePickedUpBy; set => bfield_CanBePickedUpBy = value; } CanBePickedUpBy_del bfield_CanBePickedUpBy;
	public virtual CanBePickedUpBy_del global_CanBePickedUpBy => TdPickup_CanBePickedUpBy;
	public /*simulated function */bool TdPickup_CanBePickedUpBy(Pawn P)
	{
		// stub
		return default;
	}
	
	public virtual /*event */void SetAmmoCountByDifficulty(int AmmoEasy, int AmmoMedium, int AmmoHard)
	{
		// stub
	}
	
	public override /*simulated event */void SetPickupMesh(PrimitiveComponent PickupMesh)
	{
		// stub
	}
	
	public virtual /*function */void TurnOffSkelUpdate()
	{
		// stub
	}
	
	public virtual /*function */void SetAmmoCount(int Count)
	{
		// stub
	}
	
	public virtual /*function */void SetClipCount(int Count)
	{
		// stub
	}
	
	public virtual /*function */int GetAmmoCount()
	{
		// stub
		return default;
	}
	
	public override /*function */void GiveTo(Pawn P)
	{
		// stub
	}
	
	public override Landed_del Landed { get => bfield_Landed ?? TdPickup_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public override Landed_del global_Landed => TdPickup_Landed;
	public /*event */void TdPickup_Landed(Object.Vector HitNormal, Actor FloorActor)
	{
		// stub
	}
	
	public virtual /*simulated function */void CheckForRigidBodySleepState()
	{
		// stub
	}
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? TdPickup_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => TdPickup_RigidBodyCollision;
	public /*event */void TdPickup_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
		// stub
	}
	
	public delegate void CoolDownTimer_del();
	public virtual CoolDownTimer_del CoolDownTimer { get => bfield_CoolDownTimer ?? (()=>{}); set => bfield_CoolDownTimer = value; } CoolDownTimer_del bfield_CoolDownTimer;
	public virtual CoolDownTimer_del global_CoolDownTimer => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		CanBePickedUpBy = null;
		Landed = null;
		RigidBodyCollision = null;
	
	}
	
	protected /*function */void TdPickup_CoolDown_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdPickup_CoolDown_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdPickup_CoolDown_CoolDownTimer()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) CoolDown()/*auto state CoolDown*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */bool TdPickup_Pickup_CanBePickedUpBy(Pawn P)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool TdPickup_Pickup_ValidTouch(Pawn Other)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */void TdPickup_Pickup_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdPickup_Pickup_Timer()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Pickup()/*state Pickup*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void TdPickup_FadeOut_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*event */void TdPickup_FadeOut_Tick(float DeltaTime)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) FadeOut()/*state FadeOut*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "CoolDown": return CoolDown();
			case "Pickup": return Pickup();
			case "FadeOut": return FadeOut();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return CoolDown();
	}
	public TdPickup()
	{
		var Default__TdPickup_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x01B686EA
			LightDistance = 8.0f,
			ShadowFilterQuality = LightComponent.EShadowFilterQuality.SFQ_High,
			BouncedLightingIntensity = 0.20f,
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdPickup.MyLightEnvironment' */;
		var Default__TdPickup_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdPickup.Sprite' */;
		var Default__TdPickup_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4CDE
			CollisionHeight = 64.0f,
			CollisionRadius = 300.0f,
		}/* Reference: CylinderComponent'Default__TdPickup.CollisionCylinder' */;
		// Object Offset:0x0060D6F5
		AmmoCount = -1;
		ClipCount = -1;
		MeshLightEnvironment = Default__TdPickup_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPickup.MyLightEnvironment'*/;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = false;
		bKillDuringLevelTransition = true;
		bCollideWorld = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPickup_Sprite/*Ref SpriteComponent'Default__TdPickup.Sprite'*/,
			Default__TdPickup_CollisionCylinder/*Ref CylinderComponent'Default__TdPickup.CollisionCylinder'*/,
			Default__TdPickup_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPickup.MyLightEnvironment'*/,
		};
		LifeSpan = 10.0f;
		CollisionComponent = Default__TdPickup_CollisionCylinder/*Ref CylinderComponent'Default__TdPickup.CollisionCylinder'*/;
	}
}
}