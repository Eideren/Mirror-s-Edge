namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDirectionalFlareEmitter : TdFlareEmitter/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] public Actor Light;
	[Category] public float Cone;
	[Category] public float MaxScale;
	public float FlareScale;
	public float ConePlusOne;
	public float OneMinusConeInv;
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public TdDirectionalFlareEmitter()
	{
		var Default__TdDirectionalFlareEmitter_TdParticleSystemComponent0 = new TdParticleSystemComponent
		{
		}/* Reference: TdParticleSystemComponent'Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0' */;
		var Default__TdDirectionalFlareEmitter_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdDirectionalFlareEmitter.Sprite' */;
		var Default__TdDirectionalFlareEmitter_ParticleSystemComponent0 = new ParticleSystemComponent
		{
		}/* Reference: ParticleSystemComponent'Default__TdDirectionalFlareEmitter.ParticleSystemComponent0' */;
		var Default__TdDirectionalFlareEmitter_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdDirectionalFlareEmitter.ArrowComponent0' */;
		// Object Offset:0x00541E67
		Cone = 200.0f;
		MaxScale = 1.0f;
		ImpactEffect = LoadAsset<ParticleSystem>("TdSpecialEffects.SpecFlare")/*Ref ParticleSystem'TdSpecialEffects.SpecFlare'*/;
		ParticleSystemComponent = Default__TdDirectionalFlareEmitter_TdParticleSystemComponent0/*Ref TdParticleSystemComponent'Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdDirectionalFlareEmitter_Sprite/*Ref SpriteComponent'Default__TdDirectionalFlareEmitter.Sprite'*/,
			Default__TdDirectionalFlareEmitter_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__TdDirectionalFlareEmitter.ParticleSystemComponent0'*/,
			Default__TdDirectionalFlareEmitter_ArrowComponent0/*Ref ArrowComponent'Default__TdDirectionalFlareEmitter.ArrowComponent0'*/,
			Default__TdDirectionalFlareEmitter_TdParticleSystemComponent0/*Ref TdParticleSystemComponent'Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0'*/,
		};
	}
}
}