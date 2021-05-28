namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_FallDamage : TdHudEffect/*
		native
		config(HudEffects)*/{
	public /*config */TdHudEffect.PPSettings PPDistortion;
	public /*config */float DurationWhenDying;
	public /*config */float FadeInWhenDying;
	public /*transient */float PPDFadeInTimer;
	public /*transient */float PPDFadeInStart;
	public /*transient */float PPDPeakDurationTimer;
	public /*transient */float PPDFadeOutTimer;
	public /*transient */float PPDTargetStrength;
	public /*transient */float PPDCurrentStrength;
	public /*private */name DirectionName;
	
	public override /*function */void ResetPP()
	{
	
	}
	
	public TdHudEffect_FallDamage()
	{
		// Object Offset:0x0056FFDF
		PPDistortion = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_FallDistortionSpeed",
			FadeInDuration = 0.10f,
			Duration = 0.10f,
			FadeOutDuration = 0.30f,
		};
		DurationWhenDying = 2.50f;
		DirectionName = (name)"FXFScreen_FallDirection";
		Blur = new TdHudEffect.BlurSettings
		{
			Duration = 0.120f,
			FadeOutDuration = 0.750f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_FallDamage",
			FadeInDuration = 0.030f,
			Duration = 0.120f,
			FadeOutDuration = 0.750f,
		};
	}
}
}