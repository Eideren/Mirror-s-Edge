namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDirectionalFlareEmitter : TdFlareEmitter/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ Actor Light;
	public/*()*/ float Cone;
	public/*()*/ float MaxScale;
	public float FlareScale;
	public float ConePlusOne;
	public float OneMinusConeInv;
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public TdDirectionalFlareEmitter()
	{
		// Object Offset:0x00541E67
		Cone = 200.0f;
		MaxScale = 1.0f;
		ImpactEffect = LoadAsset<ParticleSystem>("TdSpecialEffects.SpecFlare")/*Ref ParticleSystem'TdSpecialEffects.SpecFlare'*/;
		ParticleSystemComponent = LoadAsset<TdParticleSystemComponent>("Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0")/*Ref TdParticleSystemComponent'Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdDirectionalFlareEmitter.Sprite")/*Ref SpriteComponent'Default__TdDirectionalFlareEmitter.Sprite'*/,
			LoadAsset<ParticleSystemComponent>("Default__TdDirectionalFlareEmitter.ParticleSystemComponent0")/*Ref ParticleSystemComponent'Default__TdDirectionalFlareEmitter.ParticleSystemComponent0'*/,
			LoadAsset<ArrowComponent>("Default__TdDirectionalFlareEmitter.ArrowComponent0")/*Ref ArrowComponent'Default__TdDirectionalFlareEmitter.ArrowComponent0'*/,
			LoadAsset<TdParticleSystemComponent>("Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0")/*Ref TdParticleSystemComponent'Default__TdDirectionalFlareEmitter.TdParticleSystemComponent0'*/,
		};
	}
}
}