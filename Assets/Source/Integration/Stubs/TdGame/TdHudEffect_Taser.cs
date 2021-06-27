namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_Taser : TdHudEffect/*
		native
		config(HudEffects)*/{
	public /*config */TdHudEffect.PPSettings PPInstantShock;
	public /*transient */float PPIFadeInTimer;
	public /*transient */float PPIFadeInStart;
	public /*transient */float PPIPeakDurationTimer;
	public /*transient */float PPIFadeOutTimer;
	public /*transient */float PPITargetStrength;
	public /*transient */float PPICurrentStrength;
	
	public TdHudEffect_Taser()
	{
		// Object Offset:0x0056FA04
		PPInstantShock = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_TaserAfterShockDamage",
			FadeInDuration = 0.10f,
			Duration = 0.10f,
			FadeOutDuration = 0.30f,
		};
		Blur = new TdHudEffect.BlurSettings
		{
			FadeOutDuration = 2.50f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_TaserDamage",
			Duration = 2.30f,
			FadeOutDuration = 1.0f,
		};
		Particles = LoadAsset<ParticleSystem>("FX_FirstPEffects.Effects.PS_FX_FullScreenFX_TaserFlare_01")/*Ref ParticleSystem'FX_FirstPEffects.Effects.PS_FX_FullScreenFX_TaserFlare_01'*/;
	}
}
}