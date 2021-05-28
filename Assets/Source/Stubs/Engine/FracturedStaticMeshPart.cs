namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FracturedStaticMeshPart : FracturedStaticMeshActor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */LightEnvironmentComponent LightEnvironment;
	public/*()*/ /*const editconst export editinline */ParticleSystemComponent ParticleComponent;
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? FracturedStaticMeshPart_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => FracturedStaticMeshPart_RigidBodyCollision;
	public /*event */void FracturedStaticMeshPart_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
	
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? FracturedStaticMeshPart_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => FracturedStaticMeshPart_TakeDamage;
	public /*event */void FracturedStaticMeshPart_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo HitInfo = default, /*optional */Actor DamageCauser = default)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		RigidBodyCollision = null;
		TakeDamage = null;
	
	}
	public FracturedStaticMeshPart()
	{
		// Object Offset:0x003233BB
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__FracturedStaticMeshPart.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/;
		ParticleComponent = LoadAsset<ParticleSystemComponent>("Default__FracturedStaticMeshPart.PartComponent0")/*Ref ParticleSystemComponent'Default__FracturedStaticMeshPart.PartComponent0'*/;
		FracturedStaticMeshComponent = new FracturedStaticMeshComponent
		{
			// Object Offset:0x0046A483
			bUseVisibleVertsForBounds = true,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__FracturedStaticMeshPart.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/,
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
		bNoDelete = false;
		bWorldGeometry = false;
		bNetInitialRotation = true;
		bMovable = true;
		bBlockActors = false;
		bProjTarget = true;
		bNoEncroachCheck = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new FracturedStaticMeshComponent
			{
				// Object Offset:0x0046A483
				bUseVisibleVertsForBounds = true,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__FracturedStaticMeshPart.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/,
				bAllowApproximateOcclusion = false,
				bForceDirectLightMap = false,
				RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_EffectPhysics,
				RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
				{
					Default = true,
					GameplayPhysics = true,
					EffectPhysics = true,
				},
			}/* Reference: FracturedStaticMeshComponent'Default__FracturedStaticMeshPart.FracturedStaticMeshComponent0' */,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__FracturedStaticMeshPart.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		LifeSpan = 15.0f;
		CollisionComponent = new FracturedStaticMeshComponent
		{
			// Object Offset:0x0046A483
			bUseVisibleVertsForBounds = true,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__FracturedStaticMeshPart.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__FracturedStaticMeshPart.MyLightEnvironment'*/,
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
	}
}
}