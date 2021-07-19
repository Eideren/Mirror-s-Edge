namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect : Object/*
		native
		config(HudEffects)*/{
	public partial struct /*native */BlurSettings
	{
		public float FadeInDuration;
		public float Duration;
		public float FadeOutDuration;
		public float FocusDistance;
		public float MaxFarBlurAmount;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0056EF17
	//		FadeInDuration = 0.0f;
	//		Duration = 0.0f;
	//		FadeOutDuration = 0.0f;
	//		FocusDistance = 0.0f;
	//		MaxFarBlurAmount = 0.0f;
	//	}
	};
	
	public partial struct /*native */PPSettings
	{
		public name ParameterName;
		public float FadeInDuration;
		public float Duration;
		public float FadeOutDuration;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0056F08B
	//		ParameterName = (name)"None";
	//		FadeInDuration = 0.0f;
	//		Duration = 0.0f;
	//		FadeOutDuration = 0.0f;
	//	}
	};
	
	[Category] [config] public TdHudEffect.BlurSettings Blur;
	[Category] [config] public TdHudEffect.PPSettings PPStrength;
	public ParticleSystem Particles;
	[config] public Object.Vector ParticleOrigin;
	[transient] public bool bIsActive;
	[Category] public bool bEnablePPEffect;
	[Category] [config] public bool bDebugEffect;
	[transient] public float PPFadeInTimer;
	[transient] public float PPFadeInStart;
	[transient] public float PPPeakDurationTimer;
	[transient] public float PPFadeOutTimer;
	[transient] public float PPTargetStrength;
	[transient] public float PPCurrentStrength;
	public MaterialEffect Effect;
	[transient] public MaterialInstanceConstant MaterialInstance;
	
	public virtual /*function */void InitializePP(PostProcessEffect PPE)
	{
		// stub
	}
	
	public virtual /*function */void ResetPP()
	{
		// stub
	}
	
	public TdHudEffect()
	{
		// Object Offset:0x0056F58A
		Blur = new TdHudEffect.BlurSettings
		{
			FadeInDuration = 0.20f,
			Duration = 0.70f,
			FadeOutDuration = 2.0f,
			FocusDistance = -500.0f,
			MaxFarBlurAmount = 1.0f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"Strength",
			FadeInDuration = 0.10f,
			Duration = 0.50f,
			FadeOutDuration = 1.50f,
		};
		ParticleOrigin = new Vector
		{
			X=40.0f,
			Y=40.0f,
			Z=23.0f
		};
		bEnablePPEffect = true;
	}
}
}