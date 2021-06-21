namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_ReactionTime : TdHudEffect/*
		native
		config(HudEffects)*/{
	public /*transient */float UsedTargetingDistance;
	public /*transient */float NormalizedTargetingDistance;
	public /*config */float TargetingDistanceFilter;
	public /*config */float DOFMaxNearBlurAmount;
	public /*config */float DOFMaxFarBlurAmount;
	public /*private transient */float PPFadeInTimerCharged;
	public /*private transient */float PPPeakDurationTimerCharged;
	public /*private transient */float PPFadeOutTimerCharged;
	public /*private transient */float PPTargetStrengthCharged;
	public /*private transient */float PPCurrentStrengthCharged;
	public/*()*/ /*editinline config */TdHudEffect.PPSettings PPStrengthCharged;
	public /*transient */float MaxNearBlurAmountBackUp;
	public /*transient */float MaxFarBlurAmountBackUp;
	
	// Export UTdHudEffect_ReactionTime::execActivateCharged(FFrame&, void* const)
	public virtual /*native final function */void ActivateCharged()
	{
		#warning NATIVE FUNCTION !
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