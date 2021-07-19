namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameBreakableActor : KActor/*
		native
		placeable*/{
	public partial struct /*native */BreakableStep
	{
		public partial struct /*native */BreakableParticleSystem
		{
			[Category] public ParticleSystem Emitter;
			[Category] public Object.Vector Offset;
	
	//		structdefaultproperties
	//		{
	//			// Object Offset:0x00005A2F
	//			Emitter = default;
	//			Offset = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			};
	//		}
		};
	
		[Category] public float DamageThreshold;
		[Category] public array<GameBreakableActor.BreakableStep.BreakableParticleSystem> ParticleEmitters;
		[Category] public StaticMesh BreakMesh;
		[Category] public Actor.EPhysics Physics;
		[Category] public SoundCue BreakSound;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00005B9B
	//		DamageThreshold = 0.0f;
	//		ParticleEmitters = default;
	//		BreakMesh = default;
	//		Physics = Actor.EPhysics.PHYS_RigidBody;
	//		BreakSound = default;
	//	}
	};
	
	[Category] public array< Core.ClassT<DamageType> > DamageTypes;
	[transient] public Object.Vector ImpactDirection;
	[transient] public Object.Vector ImpactLocation;
	public bool bDestroyed;
	[Category] public bool bParticlesAcceptLights;
	[Category] public bool bParticlesAcceptDynamicLights;
	[Category] public array<GameBreakableActor.BreakableStep> BreakableSteps;
	public int CurrentBreakableStep;
	[Category] public LightComponent.LightingChannelContainer ParticleLightingChannels;
	
	// Export UGameBreakableActor::execGetOffsetToWorld(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetOffsetToWorld(Object.Vector Offset)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UGameBreakableActor::execSetParticlesLighting(FFrame&, void* const)
	public virtual /*native function */void SetParticlesLighting(Emitter Emit)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? GameBreakableActor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => GameBreakableActor_TakeDamage;
	public /*event */void GameBreakableActor_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default)
	{
		// stub
	}
	
	public virtual /*function */void TakeLastDamage(int Damage, Controller EventInstigator, bool bIsBroken, int BrokenStep)
	{
		// stub
	}
	
	public virtual /*function */void TakeStepDamage(int Damage, Controller EventInstigator, bool bIsBroken, int BrokenStep)
	{
		// stub
	}
	
	public virtual /*final function */bool IsValidDamageType(Core.ClassT<DamageType> inDamageType)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void BreakStepApart(int BrokenStep)
	{
		// stub
	}
	
	public virtual /*function */void BreakLastApart(Controller EventInstigator)
	{
		// stub
	}
	
	public virtual /*function */void HideAndDestroy()
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public GameBreakableActor()
	{
		var Default__GameBreakableActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment' */;
		var Default__GameBreakableActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x000093ED
			LightEnvironment = Default__GameBreakableActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment'*/,
		}/* Reference: StaticMeshComponent'Default__GameBreakableActor.StaticMeshComponent0' */;
		// Object Offset:0x00006A96
		StaticMeshComponent = Default__GameBreakableActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__GameBreakableActor.StaticMeshComponent0'*/;
		LightEnvironment = Default__GameBreakableActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__GameBreakableActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment'*/,
			Default__GameBreakableActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__GameBreakableActor.StaticMeshComponent0'*/,
		};
		CollisionType = Actor.ECollisionType.COLLIDE_BlockAll;
		CollisionComponent = Default__GameBreakableActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__GameBreakableActor.StaticMeshComponent0'*/;
	}
}
}