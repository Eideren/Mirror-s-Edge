namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DroppedPickup : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public Inventory Inventory;
	public /*repnotify */Core.ClassT<Inventory> InventoryClass;
	public NavigationPoint PickupCache;
	public /*repnotify */bool bFadeOut;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		InventoryClass, bFadeOut;
	//}
	
	// Export UDroppedPickup::execAddToNavigation(FFrame&, void* const)
	public virtual /*native final function */void AddToNavigation()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UDroppedPickup::execRemoveFromNavigation(FFrame&, void* const)
	public virtual /*native final function */void RemoveFromNavigation()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? DroppedPickup_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => DroppedPickup_Reset;
	public /*function */void DroppedPickup_Reset()
	{
		// stub
	}
	
	public virtual /*simulated event */void SetPickupMesh(PrimitiveComponent PickupMesh)
	{
		// stub
	}
	
	public virtual /*simulated event */void SetPickupParticles(ParticleSystemComponent PickupParticles)
	{
		// stub
	}
	
	public override /*event */void EncroachedBy(Actor Other)
	{
		// stub
	}
	
	public virtual /*function */float DetourWeight(Pawn Other, float PathWeight)
	{
		// stub
		return default;
	}
	
	public override Landed_del Landed { get => bfield_Landed ?? DroppedPickup_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public override Landed_del global_Landed => DroppedPickup_Landed;
	public /*event */void DroppedPickup_Landed(Object.Vector HitNormal, Actor FloorActor)
	{
		// stub
	}
	
	public virtual /*function */void GiveTo(Pawn P)
	{
		// stub
	}
	
	public override /*function */void PickedUpBy(Pawn P)
	{
		// stub
	}
	
	public delegate void RecheckValidTouch_del();
	public virtual RecheckValidTouch_del RecheckValidTouch { get => bfield_RecheckValidTouch ?? DroppedPickup_RecheckValidTouch; set => bfield_RecheckValidTouch = value; } RecheckValidTouch_del bfield_RecheckValidTouch;
	public virtual RecheckValidTouch_del global_RecheckValidTouch => DroppedPickup_RecheckValidTouch;
	public /*function */void DroppedPickup_RecheckValidTouch()
	{
		// stub
	}
	
	public delegate bool ValidTouch_del(Pawn Other);
	public virtual ValidTouch_del ValidTouch { get => bfield_ValidTouch ?? ((_a)=>default); set => bfield_ValidTouch = value; } ValidTouch_del bfield_ValidTouch;
	public virtual ValidTouch_del global_ValidTouch => (_a)=>default;
	
	public delegate void CheckTouching_del();
	public virtual CheckTouching_del CheckTouching { get => bfield_CheckTouching ?? (()=>{}); set => bfield_CheckTouching = value; } CheckTouching_del bfield_CheckTouching;
	public virtual CheckTouching_del global_CheckTouching => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Landed = null;
		RecheckValidTouch = null;
	
	}
	
	protected /*function */bool DroppedPickup_Pickup_ValidTouch(Pawn Other)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */void DroppedPickup_Pickup_RecheckValidTouch()// state function
	{
		// stub
	}
	
	protected /*event */void DroppedPickup_Pickup_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
		// stub
	}
	
	protected /*event */void DroppedPickup_Pickup_Timer()// state function
	{
		// stub
	}
	
	protected /*function */void DroppedPickup_Pickup_CheckTouching()// state function
	{
		// stub
	}
	
	protected /*event */void DroppedPickup_Pickup_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*event */void DroppedPickup_Pickup_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Pickup()/*auto state Pickup*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void DroppedPickup_FadeOut_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) FadeOut()/*state FadeOut extends Pickup*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Pickup": return Pickup();
			case "FadeOut": return FadeOut();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Pickup();
	}
	public DroppedPickup()
	{
		var Default__DroppedPickup_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CF9A6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Inventory")/*Ref Texture2D'EngineResources.S_Inventory'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__DroppedPickup.Sprite' */;
		var Default__DroppedPickup_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00466597
			CollisionHeight = 20.0f,
			CollisionRadius = 30.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__DroppedPickup.CollisionCylinder' */;
		// Object Offset:0x00311AA3
		bIgnoreRigidBodyPawns = true;
		bOrientOnSlope = true;
		bUpdateSimulatedPosition = true;
		bOnlyDirtyReplication = true;
		bShouldBaseAtStartup = true;
		bCollideActors = true;
		bCollideWorld = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DroppedPickup_Sprite/*Ref SpriteComponent'Default__DroppedPickup.Sprite'*/,
			Default__DroppedPickup_CollisionCylinder/*Ref CylinderComponent'Default__DroppedPickup.CollisionCylinder'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 8.0f;
		NetPriority = 1.40f;
		LifeSpan = 16.0f;
		CollisionComponent = Default__DroppedPickup_CollisionCylinder/*Ref CylinderComponent'Default__DroppedPickup.CollisionCylinder'*/;
		RotationRate = new Rotator
		{
			Pitch=0,
			Yaw=5000,
			Roll=0
		};
		DesiredRotation = new Rotator
		{
			Pitch=0,
			Yaw=30000,
			Roll=0
		};
	}
}
}