namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_ReactionTime : TdHudEffect/*
		native
		config(HudEffects)*/{
	[transient] public float UsedTargetingDistance;
	[transient] public float NormalizedTargetingDistance;
	[config] public float TargetingDistanceFilter;
	[config] public float DOFMaxNearBlurAmount;
	[config] public float DOFMaxFarBlurAmount;
	[transient] public/*private*/ float PPFadeInTimerCharged;
	[transient] public/*private*/ float PPPeakDurationTimerCharged;
	[transient] public/*private*/ float PPFadeOutTimerCharged;
	[transient] public/*private*/ float PPTargetStrengthCharged;
	[transient] public/*private*/ float PPCurrentStrengthCharged;
	[Category] [editinline, config] public TdHudEffect.PPSettings PPStrengthCharged;
	[transient] public float MaxNearBlurAmountBackUp;
	[transient] public float MaxFarBlurAmountBackUp;
	
	// Export UTdHudEffect_ReactionTime::execActivateCharged(FFrame&, void* const)
	public virtual /*native final function */void ActivateCharged()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void Hide()
	{
		// stub
	}
	
	public TdHudEffect_ReactionTime()
	{
		// Object Offset:0x00570B6D
		UsedTargetingDistance = -1.0f;
		NormalizedTargetingDistance = 1.0f;
		TargetingDistanceFilter = 0.10f;
		PPStrengthCharged = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_ReactionTimeCharged",
			FadeInDuration = 0.50f,
			Duration = 0.50f,
			FadeOutDuration = 0.50f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_ReactionTime",
		};
	}
}
}