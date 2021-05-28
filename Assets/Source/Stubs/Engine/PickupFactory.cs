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
	
	}
	
	public override /*simulated event */void PreBeginPlay()
	{
	
	}
	
	public virtual /*simulated function */void InitializePickup()
	{
	
	}
	
	public override SetInitialState_del SetInitialState { get => bfield_SetInitialState ?? PickupFactory_SetInitialState; set => bfield_SetInitialState = value; } SetInitialState_del bfield_SetInitialState;
	public override SetInitialState_del global_SetInitialState => PickupFactory_SetInitialState;
	public /*simulated event */void PickupFactory_SetInitialState()
	{
	
	}
	
	public override /*simulated function */void ShutDown()
	{
	
	}
	
	public virtual /*simulated function */void SetPickupMesh()
	{
	
	}
	
	public /*function */static void StaticPrecache(WorldInfo W)
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? PickupFactory_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => PickupFactory_Reset;
	public /*function */void PickupFactory_Reset()
	{
	
	}
	
	public override /*function */bool CheckForErrors()
	{
	
		return default;
	}
	
	public virtual /*function */void SetRespawn()
	{
	
	}
	
	public delegate void StartSleeping_del();
	public virtual StartSleeping_del StartSleeping { get => bfield_StartSleeping ?? PickupFactory_StartSleeping; set => bfield_StartSleeping = value; } StartSleeping_del bfield_StartSleeping;
	public virtual StartSleeping_del global_StartSleeping => PickupFactory_StartSleeping;
	public /*function */void PickupFactory_StartSleeping()
	{
	
	}
	
	public override DetourWeight_del DetourWeight { get => bfield_DetourWeight ?? PickupFactory_DetourWeight; set => bfield_DetourWeight = value; } DetourWeight_del bfield_DetourWeight;
	public override DetourWeight_del global_DetourWeight => PickupFactory_DetourWeight;
	public /*event */float PickupFactory_DetourWeight(Pawn Other, float PathWeight)
	{
	
		return default;
	}
	
	public virtual /*function */void SpawnCopyFor(Pawn Recipient)
	{
	
	}
	
	public delegate bool ReadyToPickup_del(float MaxWait);
	public virtual ReadyToPickup_del ReadyToPickup { get => bfield_ReadyToPickup ?? PickupFactory_ReadyToPickup; set => bfield_ReadyToPickup = value; } ReadyToPickup_del bfield_ReadyToPickup;
	public virtual ReadyToPickup_del global_ReadyToPickup => PickupFactory_ReadyToPickup;
	public /*function */bool PickupFactory_ReadyToPickup(float MaxWait)
	{
	
		return default;
	}
	
	public virtual /*function */void GiveTo(Pawn P)
	{
	
	}
	
	public override /*function */void PickedUpBy(Pawn P)
	{
	
	}
	
	public delegate void RecheckValidTouch_del();
	public virtual RecheckValidTouch_del RecheckValidTouch { get => bfield_RecheckValidTouch ?? PickupFactory_RecheckValidTouch; set => bfield_RecheckValidTouch = value; } RecheckValidTouch_del bfield_RecheckValidTouch;
	public virtual RecheckValidTouch_del global_RecheckValidTouch => PickupFactory_RecheckValidTouch;
	public /*function */void PickupFactory_RecheckValidTouch()
	{
	
	}
	
	public virtual /*function */float GetRespawnTime()
	{
	
		return default;
	}
	
	public virtual /*function */void RespawnEffect()
	{
	
	}
	
	public virtual /*simulated function */void SetPickupHidden()
	{
	
	}
	
	public virtual /*simulated function */void SetPickupVisible()
	{
	
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public virtual /*function */bool ShouldRespawn()
	{
	
		return default;
	}
	
	public delegate bool ValidTouch_del(Pawn Other);
	public virtual ValidTouch_del ValidTouch { get => bfield_ValidTouch ?? ((_)=>default); set => bfield_ValidTouch = value; } ValidTouch_del bfield_ValidTouch;
	public virtual ValidTouch_del global_ValidTouch => (_)=>default;
	
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
	
		return default;
	}
	
	protected /*function */bool PickupFactory_Pickup_ReadyToPickup(float MaxWait)// state function
	{
	
		return default;
	}
	
	protected /*function */bool PickupFactory_Pickup_ValidTouch(Pawn Other)// state function
	{
	
		return default;
	}
	
	protected /*function */void PickupFactory_Pickup_RecheckValidTouch()// state function
	{
	
	}
	
	protected /*event */void PickupFactory_Pickup_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
	
	}
	
	protected /*function */void PickupFactory_Pickup_CheckTouching()// state function
	{
	
	}
	
	protected /*event */void PickupFactory_Pickup_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Pickup()/*auto state Pickup*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void PickupFactory_WaitingForMatch_MatchStarting()// state function
	{
	
	}
	
	protected /*event */void PickupFactory_WaitingForMatch_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WaitingForMatch()/*state WaitingForMatch*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool PickupFactory_Sleeping_ReadyToPickup(float MaxWait)// state function
	{
	
		return default;
	}
	
	protected /*event */void PickupFactory_Sleeping_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*event */void PickupFactory_Sleeping_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Sleeping()/*state Sleeping*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool PickupFactory_Disabled_ReadyToPickup(float MaxWait)// state function
	{
	
		return default;
	}
	
	protected /*simulated event */void PickupFactory_Disabled_SetInitialState()// state function
	{
	
	}
	
	protected /*simulated event */void PickupFactory_Disabled_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Disabled()/*state Disabled*/
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
		// Object Offset:0x0039E8ED
		bOnlyReplicateHidden = true;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x004666B3
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__PickupFactory.CollisionCylinder' */;
		GoodSprite = LoadAsset<SpriteComponent>("Default__PickupFactory.Sprite")/*Ref SpriteComponent'Default__PickupFactory.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__PickupFactory.Sprite2")/*Ref SpriteComponent'Default__PickupFactory.Sprite2'*/;
		bStatic = false;
		bIgnoreEncroachers = true;
		bAlwaysRelevant = true;
		bCollideWhenPlacing = false;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__PickupFactory.Sprite")/*Ref SpriteComponent'Default__PickupFactory.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__PickupFactory.Sprite2")/*Ref SpriteComponent'Default__PickupFactory.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__PickupFactory.Arrow")/*Ref ArrowComponent'Default__PickupFactory.Arrow'*/,
			//Components[3]=
			new CylinderComponent
			{
				// Object Offset:0x004666B3
				CollisionHeight = 80.0f,
				CollisionRadius = 40.0f,
				CollideActors = true,
			}/* Reference: CylinderComponent'Default__PickupFactory.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__PickupFactory.PathRenderer")/*Ref PathRenderingComponent'Default__PickupFactory.PathRenderer'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 1.0f;
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x004666B3
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__PickupFactory.CollisionCylinder' */;
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