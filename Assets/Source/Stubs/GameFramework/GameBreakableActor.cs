namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameBreakableActor : KActor/*
		native
		placeable*/{
	public partial struct /*native */BreakableStep
	{
		public partial struct /*native */BreakableParticleSystem
		{
			public/*()*/ ParticleSystem Emitter;
			public/*()*/ Object.Vector Offset;
	
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
	
		public/*()*/ float DamageThreshold;
		public/*()*/ array<GameBreakableActor.BreakableStep.BreakableParticleSystem> ParticleEmitters;
		public/*()*/ StaticMesh BreakMesh;
		public/*()*/ Actor.EPhysics Physics;
		public/*()*/ SoundCue BreakSound;
	
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
	
	public/*()*/ array< Core.ClassT<DamageType> > DamageTypes;
	public /*transient */Object.Vector ImpactDirection;
	public /*transient */Object.Vector ImpactLocation;
	public bool bDestroyed;
	public/*()*/ bool bParticlesAcceptLights;
	public/*()*/ bool bParticlesAcceptDynamicLights;
	public/*()*/ array<GameBreakableActor.BreakableStep> BreakableSteps;
	public int CurrentBreakableStep;
	public/*()*/ LightComponent.LightingChannelContainer ParticleLightingChannels;
	
	// Export UGameBreakableActor::execGetOffsetToWorld(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetOffsetToWorld(Object.Vector Offset)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameBreakableActor::execSetParticlesLighting(FFrame&, void* const)
	public virtual /*native function */void SetParticlesLighting(Emitter Emit)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? GameBreakableActor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => GameBreakableActor_TakeDamage;
	public /*event */void GameBreakableActor_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public virtual /*function */void TakeLastDamage(int Damage, Controller EventInstigator, bool bIsBroken, int BrokenStep)
	{
	
	}
	
	public virtual /*function */void TakeStepDamage(int Damage, Controller EventInstigator, bool bIsBroken, int BrokenStep)
	{
	
	}
	
	public virtual /*final function */bool IsValidDamageType(Core.ClassT<DamageType> inDamageType)
	{
	
		return default;
	}
	
	public virtual /*function */void BreakStepApart(int BrokenStep)
	{
	
	}
	
	public virtual /*function */void BreakLastApart(Controller EventInstigator)
	{
	
	}
	
	public virtual /*function */void HideAndDestroy()
	{
	
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public GameBreakableActor()
	{
		var Default__GameBreakableActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x000093ED
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__GameBreakableActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment'*/,
		}/* Reference: StaticMeshComponent'Default__GameBreakableActor.StaticMeshComponent0' */;
		// Object Offset:0x00006A96
		StaticMeshComponent = Default__GameBreakableActor_StaticMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__GameBreakableActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__GameBreakableActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__GameBreakableActor.MyLightEnvironment'*/,
			Default__GameBreakableActor_StaticMeshComponent0,
		};
		CollisionType = Actor.ECollisionType.COLLIDE_BlockAll;
		CollisionComponent = Default__GameBreakableActor_StaticMeshComponent0;
	}
}
}