namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_Flashbang : TdHudEffect/*
		native
		config(HudEffects)*/{
	public enum EFlash_Type 
	{
		EFlash_Normal,
		EFlash_Heavy,
		EFlash_MAX
	};
	
	public /*private transient */float PPFadeInTimerHeavy;
	public /*private transient */float PPFadeInStartHeavy;
	public /*private transient */float PPPeakDurationTimerHeavy;
	public /*private transient */float PPFadeOutTimerHeavy;
	public /*private transient */float PPTargetStrengthHeavy;
	public /*private transient */float PPCurrentStrengthHeavy;
	public /*private */TdHudEffect_Flashbang.EFlash_Type Type;
	public/*()*/ /*editinline config */TdHudEffect.BlurSettings BlurHeavy;
	public/*()*/ /*editinline config */TdHudEffect.PPSettings PPStrengthHeavy;
	
	public TdHudEffect_Flashbang()
	{
		// Object Offset:0x005703F6
		BlurHeavy = new TdHudEffect.BlurSettings
		{
			FadeInDuration = 1.20f,
			Duration = 3.0f,
			FadeOutDuration = 5.0f,
			FocusDistance = -500.0f,
			MaxFarBlurAmount = 1.0f,
		};
		PPStrengthHeavy = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_FlashBangOutlineStrength",
			FadeInDuration = 0.060f,
			Duration = 0.0f,
			FadeOutDuration = 15.0f,
		};
		Blur = new TdHudEffect.BlurSettings
		{
			Duration = 1.50f,
			FadeOutDuration = 3.0f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_FlashBangOutlineStrength",
			FadeInDuration = 0.060f,
			Duration = 0.250f,
			FadeOutDuration = 1.0f,
		};
	}
}
}