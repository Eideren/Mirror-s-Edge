namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdFlareEmitter : Emitter/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ ParticleSystem ImpactEffect;
	
	public override /*simulated function */void PostBeginPlay()
	{
	
	}
	
	public TdFlareEmitter()
	{
		var Default__TdFlareEmitter_TdParticleSystemComponent0 = new TdParticleSystemComponent
		{
			// Object Offset:0x00541C9A
			bOverrideLODMethod = true,
			LODMethod = ParticleSystem.ParticleSystemLODMethod.PARTICLESYSTEMLODMETHOD_DirectSet,
		}/* Reference: TdParticleSystemComponent'Default__TdFlareEmitter.TdParticleSystemComponent0' */;
		// Object Offset:0x00541B57
		ParticleSystemComponent = Default__TdFlareEmitter_TdParticleSystemComponent0;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdFlareEmitter.Sprite")/*Ref SpriteComponent'Default__TdFlareEmitter.Sprite'*/,
			LoadAsset<ParticleSystemComponent>("Default__TdFlareEmitter.ParticleSystemComponent0")/*Ref ParticleSystemComponent'Default__TdFlareEmitter.ParticleSystemComponent0'*/,
			LoadAsset<ArrowComponent>("Default__TdFlareEmitter.ArrowComponent0")/*Ref ArrowComponent'Default__TdFlareEmitter.ArrowComponent0'*/,
			Default__TdFlareEmitter_TdParticleSystemComponent0,
		};
	}
}
}