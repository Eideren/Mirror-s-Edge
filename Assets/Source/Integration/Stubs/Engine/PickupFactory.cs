namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PickupFactory : NavigationPoint/*
		abstract
		native
		nativereplication
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public bool bOnlyReplicateHidden;
	public /*repnotify */bool bPickupHidden;
	public bool bPredictRespawns;
	public bool bIsSuperItem;
	public /*repnotify */Core.ClassT<Inventory> InventoryType;
	public float RespawnEffectTime;
	public float MaxDesireability;
	public /*export editinline transient */PrimitiveComponent PickupMesh;
	public PickupFactory ReplacementFactory;
	public PickupFactory OriginalFactory;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bPickupHidden;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		InventoryType;
	//}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public override /*simulated event */void PreBeginPlay()
	{
		// stub
	}
	
	public virtual /*simulated function */void InitializePickup()
	{
		// stub
	}
	
	public override SetInitialState_del SetInitialState { get => bfield_SetInitialState ?? PickupFactory_SetInitialState; set => bfield_SetInitialState = value; } SetInitialState_del bfield_SetInitialState;
	public override SetInitialState_del global_SetInitialState => PickupFactory_SetInitialState;
	public /*simulated event */void PickupFactory_SetInitialState()
	{
		// stub
	}
	
	public override /*simulated function */void ShutDown()
	{
		// stub
	}
	
	public virtual /*simulated function */void SetPickupMesh()
	{
		// stub
	}
	
	public /*function */static void StaticPrecache(WorldInfo W)
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? PickupFactory_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => PickupFactory_Reset;
	public /*function */void PickupFactory_Reset()
	{
		// stub
	}
	
	public override /*function */bool CheckForErrors()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetRespawn()
	{
		// stub
	}
	
	public delegate void StartSleeping_del();
	public virtual StartSleeping_del StartSleeping { get => bfield_StartSleeping ?? PickupFactory_StartSleeping; set => bfield_StartSleeping = value; } StartSleeping_del bfield_StartSleeping;
	public virtual StartSleeping_del global_StartSleeping => PickupFactory_StartSleeping;
	public /*function */void PickupFactory_StartSleeping()
	{
		// stub
	}
	
	public override DetourWeight_del DetourWeight { get => bfield_DetourWeight ?? PickupFactory_DetourWeight; set => bfield_DetourWeight = value; } DetourWeight_del bfield_DetourWeight;
	public override DetourWeight_del global_DetourWeight => PickupFactory_DetourWeight;
	public /*event */float PickupFactory_DetourWeight(Pawn Other, float PathWeight)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SpawnCopyFor(Pawn Recipient)
	{
		// stub
	}
	
	public delegate bool ReadyToPickup_del(float MaxWait);
	public virtual ReadyToPickup_del ReadyToPickup { get => bfield_ReadyToPickup ?? PickupFactory_ReadyToPickup; set => bfield_ReadyToPickup = value; } ReadyToPickup_del bfield_ReadyToPickup;
	public virtual ReadyToPickup_del global_ReadyToPickup => PickupFactory_ReadyToPickup;
	public /*function */bool PickupFactory_ReadyToPickup(float MaxWait)
	{
		// stub
		return default;
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
	public virtual RecheckValidTouch_del RecheckValidTouch { get => bfield_RecheckValidTouch ?? PickupFactory_RecheckValidTouch; set => bfield_RecheckValidTouch = value; } RecheckValidTouch_del bfield_RecheckValidTouch;
	public virtual RecheckValidTouch_del global_RecheckValidTouch => PickupFactory_RecheckValidTouch;
	public /*function */void PickupFactory_RecheckValidTouch()
	{
		// stub
	}
	
	public virtual /*function */float GetRespawnTime()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void RespawnEffect()
	{
		// stub
	}
	
	public virtual /*simulated function */void SetPickupHidden()
	{
		// stub
	}
	
	public virtual /*simulated function */void SetPickupVisible()
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*function */bool ShouldRespawn()
	{
		// stub
		return default;
	}
	
	public delegate bool ValidTouch_del(Pawn Other);
	public virtual ValidTouch_del ValidTouch { get => bfield_ValidTouch ?? ((_a)=>default); set => bfield_ValidTouch = value; } ValidTouch_del bfield_ValidTouch;
	public virtual ValidTouch_del global_ValidTouch => (_a)=>default;
	
	public delegate void CheckTouching_del();
	public virtual CheckTouching_del CheckTouching { get => bfield_CheckTouching ?? (()=>{}); set => bfield_CheckTouching = value; } CheckTouching_del bfield_CheckTouching;
	public virtual CheckTouching_del global_CheckTouching => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		SetInitialState = null;
		Reset = null;
		StartSleeping = null;
		DetourWeight = null;
		ReadyToPickup = null;
		RecheckValidTouch = null;
	
	}
	
	protected /*event */float PickupFactory_Pickup_DetourWeight(Pawn Other, float PathWeight)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool PickupFactory_Pickup_ReadyToPickup(float MaxWait)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool PickupFactory_Pickup_ValidTouch(Pawn Other)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */void PickupFactory_Pickup_RecheckValidTouch()// state function
	{
		// stub
	}
	
	protected /*event */void PickupFactory_Pickup_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
		// stub
	}
	
	protected /*function */void PickupFactory_Pickup_CheckTouching()// state function
	{
		// stub
	}
	
	protected /*event */void PickupFactory_Pickup_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Pickup()/*auto state Pickup*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void PickupFactory_WaitingForMatch_MatchStarting()// state function
	{
		// stub
	}
	
	protected /*event */void PickupFactory_WaitingForMatch_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WaitingForMatch()/*state WaitingForMatch*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool PickupFactory_Sleeping_ReadyToPickup(float MaxWait)// state function
	{
		// stub
		return default;
	}
	
	protected /*event */void PickupFactory_Sleeping_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*event */void PickupFactory_Sleeping_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Sleeping()/*state Sleeping*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool PickupFactory_Disabled_ReadyToPickup(float MaxWait)// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */void PickupFactory_Disabled_SetInitialState()// state function
	{
		// stub
	}
	
	protected /*simulated event */void PickupFactory_Disabled_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Disabled()/*state Disabled*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Pickup": return Pickup();
			case "WaitingForMatch": return WaitingForMatch();
			case "Sleeping": return Sleeping();
			case "Disabled": return Disabled();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Pickup();
	}
	public PickupFactory()
	{
		var Default__PickupFactory_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x004666B3
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__PickupFactory.CollisionCylinder' */;
		var Default__PickupFactory_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PickupFactory.Sprite' */;
		var Default__PickupFactory_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PickupFactory.Sprite2' */;
		var Default__PickupFactory_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__PickupFactory.Arrow' */;
		var Default__PickupFactory_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__PickupFactory.PathRenderer' */;
		// Object Offset:0x0039E8ED
		bOnlyReplicateHidden = true;
		CylinderComponent = Default__PickupFactory_CollisionCylinder/*Ref CylinderComponent'Default__PickupFactory.CollisionCylinder'*/;
		GoodSprite = Default__PickupFactory_Sprite/*Ref SpriteComponent'Default__PickupFactory.Sprite'*/;
		BadSprite = Default__PickupFactory_Sprite2/*Ref SpriteComponent'Default__PickupFactory.Sprite2'*/;
		bStatic = false;
		bIgnoreEncroachers = true;
		bAlwaysRelevant = true;
		bCollideWhenPlacing = false;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PickupFactory_Sprite/*Ref SpriteComponent'Default__PickupFactory.Sprite'*/,
			Default__PickupFactory_Sprite2/*Ref SpriteComponent'Default__PickupFactory.Sprite2'*/,
			Default__PickupFactory_Arrow/*Ref ArrowComponent'Default__PickupFactory.Arrow'*/,
			Default__PickupFactory_CollisionCylinder/*Ref CylinderComponent'Default__PickupFactory.CollisionCylinder'*/,
			Default__PickupFactory_PathRenderer/*Ref PathRenderingComponent'Default__PickupFactory.PathRenderer'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 1.0f;
		CollisionComponent = Default__PickupFactory_CollisionCylinder/*Ref CylinderComponent'Default__PickupFactory.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_PickupStatusChange>(),
		};
	}
}
}