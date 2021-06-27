namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_Bullet : TdHudEffect/*
		native
		config(HudEffects)*/{
	public TdHudEffect_Bullet()
	{
		// Object Offset:0x0056F7A9
		Blur = new TdHudEffect.BlurSettings
		{
			FadeInDuration = 0.030f,
			Duration = 0.250f,
			FadeOutDuration = 0.150f,
			MaxFarBlurAmount = 0.950f,
		};
		Particles = LoadAsset<ParticleSystem>("FX_FirstPEffects.Effects.PS_FX_FullScreenFX_BulletHit_01")/*Ref ParticleSystem'FX_FirstPEffects.Effects.PS_FX_FullScreenFX_BulletHit_01'*/;
	}
}
}