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
		// stub
		return default;
	}
	
	// Export UGameBreakableActor::execSetParticlesLighting(FFrame&, void* const)
	public virtual /*native function */void SetParticlesLighting(Emitter Emit)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? GameBreakableActor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => GameBreakableActor_TakeDamage;
	public /*event */void GameBreakableActor_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
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