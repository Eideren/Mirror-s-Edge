namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FracturedStaticMeshPart : FracturedStaticMeshActor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	[Category] [Const, editconst, export, editinline] public LightEnvironmentComponent LightEnvironment;
	[Category] [Const, editconst, export, editinline] public ParticleSystemComponent ParticleComponent;
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? FracturedStaticMeshPart_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => FracturedStaticMeshPart_RigidBodyCollision;
	public /*event */void FracturedStaticMeshPart_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
		// stub
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? FracturedStaticMeshPart_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => FracturedStaticMeshPart_TakeDamage;
	public /*event */void FracturedStaticMeshPart_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		RigidBodyCollision = null;
		TakeDamage = null;
	
	}
	public FracturedStaticMeshPart()
	{
		var Default__FracturedStaticMeshPart_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment' */;
		var Default__FracturedStaticMeshPart_PartComponent0 = new ParticleSystemComponent
		{
		}/* Reference: ParticleSystemComponent'Default__FracturedStaticMeshPart.PartComponent0' */;
		var Default__FracturedStaticMeshPart_FracturedStaticMeshComponent0 = new FracturedStaticMeshComponent
		{
			// Object Offset:0x0046A483
			bUseVisibleVertsForBounds = true,
			LightEnvironment = Default__FracturedStaticMeshPart_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/,
			bAllowApproximateOcclusion = false,
			bForceDirectLightMap = false,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_EffectPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: FracturedStaticMeshComponent'Default__FracturedStaticMeshPart.FracturedStaticMeshComponent0' */;
		// Object Offset:0x003233BB
		LightEnvironment = Default__FracturedStaticMeshPart_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/;
		ParticleComponent = Default__FracturedStaticMeshPart_PartComponent0/*Ref ParticleSystemComponent'Default__FracturedStaticMeshPart.PartComponent0'*/;
		FracturedStaticMeshComponent = Default__FracturedStaticMeshPart_FracturedStaticMeshComponent0/*Ref FracturedStaticMeshComponent'Default__FracturedStaticMeshPart.FracturedStaticMeshComponent0'*/;
		bNoDelete = false;
		bWorldGeometry = false;
		bNetInitialRotation = true;
		bMovable = true;
		bBlockActors = false;
		bProjTarget = true;
		bNoEncroachCheck = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FracturedStaticMeshPart_FracturedStaticMeshComponent0/*Ref FracturedStaticMeshComponent'Default__FracturedStaticMeshPart.FracturedStaticMeshComponent0'*/,
			Default__FracturedStaticMeshPart_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		LifeSpan = 15.0f;
		CollisionComponent = Default__FracturedStaticMeshPart_FracturedStaticMeshComponent0/*Ref FracturedStaticMeshComponent'Default__FracturedStaticMeshPart.FracturedStaticMeshComponent0'*/;
	}
}
}