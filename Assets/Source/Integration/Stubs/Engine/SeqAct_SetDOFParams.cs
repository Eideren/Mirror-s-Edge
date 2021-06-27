namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetDOFParams : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public/*()*/ float FalloffExponent;
	public/*()*/ float BlurKernelSize;
	public/*()*/ float MaxNearBlurAmount;
	public/*()*/ float MaxFarBlurAmount;
	public/*()*/ Object.Color ModulateBlurColor;
	public/*()*/ float FocusInnerRadius;
	public/*()*/ float FocusDistance;
	public/*()*/ Object.Vector FocusPosition;
	public/*()*/ float InterpolateSeconds;
	public float InterpolateElapsed;
	public float OldFalloffExponent;
	public float OldBlurKernelSize;
	public float OldMaxNearBlurAmount;
	public float OldMaxFarBlurAmount;
	public Object.Color OldModulateBlurColor;
	public float OldFocusInnerRadius;
	public float OldFocusDistance;
	public Object.Vector OldFocusPosition;
	
	public SeqAct_SetDOFParams()
	{
		// Object Offset:0x003CCF21
		FalloffExponent = 4.0f;
		BlurKernelSize = 5.0f;
		MaxNearBlurAmount = 1.0f;
		MaxFarBlurAmount = 1.0f;
		ModulateBlurColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		FocusInnerRadius = 600.0f;
		FocusDistance = 600.0f;
		InterpolateSeconds = 2.0f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Enable",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Disable",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Depth Of Field";
		ObjCategory = "Camera";
	}
}
}