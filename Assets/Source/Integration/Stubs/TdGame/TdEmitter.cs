namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdEmitter : Emitter/*
		native
		placeable
		hidecategories(Navigation)*/{
	public virtual /*simulated function */void KillProjectile()
	{
		// stub
	}
	
	public TdEmitter()
	{
		var Default__TdEmitter_ParticleSystemComponent0 = new ParticleSystemComponent
		{
			// Object Offset:0x01D7500F
			bOverrideLODMethod = true,
			SecondsBeforeInactive = 0.0f,
			LODMethod = ParticleSystem.ParticleSystemLODMethod.PARTICLESYSTEMLODMETHOD_DirectSet,
		}/* Reference: ParticleSystemComponent'Default__TdEmitter.ParticleSystemComponent0' */;
		var Default__TdEmitter_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdEmitter.Sprite' */;
		var Default__TdEmitter_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdEmitter.ArrowComponent0' */;
		// Object Offset:0x00544290
		ParticleSystemComponent = Default__TdEmitter_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__TdEmitter.ParticleSystemComponent0'*/;
		bDestroyOnSystemFinish = true;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdEmitter_Sprite/*Ref SpriteComponent'Default__TdEmitter.Sprite'*/,
			Default__TdEmitter_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__TdEmitter.ParticleSystemComponent0'*/,
			Default__TdEmitter_ArrowComponent0/*Ref ArrowComponent'Default__TdEmitter.ArrowComponent0'*/,
		};
		LifeSpan = 7.0f;
	}
}
}