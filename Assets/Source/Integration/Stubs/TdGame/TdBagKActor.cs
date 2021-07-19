namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagKActor : KActor, 
		TdCarriableActorProxy/*
		placeable*/{
	[transient] public/*protected*/ TdCarriableMediator Mediator;
	[transient] public/*private*/ Pawn LastCarrierPawn;
	public String InventoryClassName;
	public bool bTouchedGround;
	[export, editinline] public CylinderComponent ActorCylinderComponent;
	
	public virtual /*function */void Initialize(TdCarriableMediator InMediator)
	{
		// stub
	}
	
	public virtual /*function */void SetUnreachableTimer(float TimeToRespawn)
	{
		// stub
	}
	
	public virtual /*function */void ClearUnreachableTimer()
	{
		// stub
	}
	
	public virtual /*function */void Unreachable()
	{
		// stub
	}
	
	public virtual /*function */void WakeRigidBody()
	{
		// stub
	}
	
	public virtual /*function */void Finalize()
	{
		// stub
	}
	
	public virtual /*function */Actor GetCarriableActor()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void TimeEnableReTouch()
	{
		// stub
	}
	
	public virtual /*function */void SetFreeze()
	{
		// stub
	}
	
	public virtual /*function */void SetCarried(Pawn CarrierPawn, name InBone, Object.Rotator InRotation, Object.Vector InOffset)
	{
		// stub
	}
	
	public virtual /*function */void SetDropped(Pawn CarrierPawn, Object.Vector StartLocation, Object.Rotator StartRotation, Object.Vector WithForce)
	{
		// stub
	}
	
	public virtual /*function */bool IsCarried()
	{
		// stub
		return default;
	}
	
	public virtual /*protected function */void Resurrect()
	{
		// stub
	}
	
	public virtual /*function */void EquipInvetoryPlaceHolderFor(Pawn P)
	{
		// stub
	}
	
	public virtual /*private final function */Inventory SpawnInventoryFor(Pawn P)
	{
		// stub
		return default;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdBagKActor_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdBagKActor_Touch;
	public /*singular event */void TdBagKActor_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public override BaseChange_del BaseChange { get => bfield_BaseChange ?? TdBagKActor_BaseChange; set => bfield_BaseChange = value; } BaseChange_del bfield_BaseChange;
	public override BaseChange_del global_BaseChange => TdBagKActor_BaseChange;
	public /*singular event */void TdBagKActor_BaseChange()
	{
		// stub
	}
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? TdBagKActor_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => TdBagKActor_RigidBodyCollision;
	public /*event */void TdBagKActor_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
		// stub
	}
	
	public virtual /*simulated function */void DelayedFellOutOfWorld()
	{
		// stub
	}
	
	public override FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? TdBagKActor_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public override FellOutOfWorld_del global_FellOutOfWorld => TdBagKActor_FellOutOfWorld;
	public /*simulated event */void TdBagKActor_FellOutOfWorld(Core.ClassT<DamageType> Damage)
	{
		// stub
	}
	
	public override OutsideWorldBounds_del OutsideWorldBounds { get => bfield_OutsideWorldBounds ?? TdBagKActor_OutsideWorldBounds; set => bfield_OutsideWorldBounds = value; } OutsideWorldBounds_del bfield_OutsideWorldBounds;
	public override OutsideWorldBounds_del global_OutsideWorldBounds => TdBagKActor_OutsideWorldBounds;
	public /*simulated event */void TdBagKActor_OutsideWorldBounds()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
		BaseChange = null;
		RigidBodyCollision = null;
		FellOutOfWorld = null;
		OutsideWorldBounds = null;
	
	}
	public TdBagKActor()
	{
		var Default__TdBagKActor_ActorCollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB48C6
			CollisionHeight = 200.0f,
			CollisionRadius = 200.0f,
			CollideActors = true,
			BlockZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdBagKActor.ActorCollisionCylinder' */;
		var Default__TdBagKActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBagKActor.MyLightEnvironment' */;
		var Default__TdBagKActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x02EA6C03
			LightEnvironment = Default__TdBagKActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActor.MyLightEnvironment'*/,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				EffectPhysics = false,
			},
			bNotifyRigidBodyCollision = true,
			Scale = 3.0f,
			ScriptRigidBodyCollisionThreshold = 50.0f,
		}/* Reference: StaticMeshComponent'Default__TdBagKActor.StaticMeshComponent0' */;
		// Object Offset:0x0050C075
		InventoryClassName = "TdMpContent.TdWeapon_Bag";
		ActorCylinderComponent = Default__TdBagKActor_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBagKActor.ActorCollisionCylinder'*/;
		StaticMeshComponent = Default__TdBagKActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActor.StaticMeshComponent0'*/;
		LightEnvironment = Default__TdBagKActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActor.MyLightEnvironment'*/;
		bNoDelete = false;
		bHardAttach = true;
		bCollideWorld = true;
		bBlockActors = false;
		bNoEncroachCheck = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBagKActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActor.MyLightEnvironment'*/,
			Default__TdBagKActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActor.StaticMeshComponent0'*/,
			Default__TdBagKActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActor.StaticMeshComponent0'*/,
			Default__TdBagKActor_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBagKActor.ActorCollisionCylinder'*/,
		};
		Physics = Actor.EPhysics.PHYS_None;
		NetPriority = 3.0f;
		CollisionComponent = Default__TdBagKActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActor.StaticMeshComponent0'*/;
	}
}
}