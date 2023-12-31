namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdFadeEffect : SequenceAction/*
		native
		hidecategories(Object)*/{
	public enum FadeEffectType 
	{
		FadeIn,
		FadeOut,
		FadeEffectType_MAX
	};
	
	[transient] public/*private*/ bool bFadeCompleted;
	[Category] public bool bFadeSound2;
	[transient] public/*private*/ TdHUD TargetDisplay;
	[transient] public/*private*/ TdPlayerPawn PlayerPawn;
	[Category] public float FadeTime;
	[Category] public Object.Color FadeColor;
	[Category] public SeqAct_TdFadeEffect.FadeEffectType FadeEffect;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public virtual /*function */void FadeCompleted()
	{
		// stub
	}
	
	public virtual /*function */void ActivateFadeOutEffect()
	{
		// stub
	}
	
	public virtual /*function */void ActivateFadeInEffect()
	{
		// stub
	}
	
	public SeqAct_TdFadeEffect()
	{
		// Object Offset:0x00499A9C
		FadeTime = 0.50f;
		bLatentExecution = true;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Completed",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Fade Effect";
		ObjCategory = "Takedown";
	}
}
}