namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_Melee : TdHudEffect/*
		native
		config(HudEffects)*/{
	public/*private*/ name DirectionName;
	
	public TdHudEffect_Melee()
	{
		// Object Offset:0x005706DD
		DirectionName = (name)"FXFScreen_MeleeHitDirection";
		Blur = new TdHudEffect.BlurSettings
		{
			FadeInDuration = 0.060f,
			Duration = 0.30f,
			FadeOutDuration = 0.850f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_MeleeDamage",
			FadeInDuration = 0.060f,
			Duration = 0.060f,
			FadeOutDuration = 0.40f,
		};
		Particles = LoadAsset<ParticleSystem>("FX_FirstPEffects.Effects.PS_FX_FullScreenFX_MeeleTrail_01")/*Ref ParticleSystem'FX_FirstPEffects.Effects.PS_FX_FullScreenFX_MeeleTrail_01'*/;
	}
}
}