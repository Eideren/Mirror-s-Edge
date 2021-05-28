namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DOFEffect : PostProcessEffect/*
		abstract
		native
		hidecategories(Object)*/{
	public enum EFocusType 
	{
		FOCUS_Distance,
		FOCUS_Position,
		FOCUS_MAX
	};
	
	public/*()*/ float FalloffExponent;
	public/*()*/ float BlurKernelSize;
	public/*()*/ float MaxNearBlurAmount;
	public/*()*/ float MaxFarBlurAmount;
	public/*()*/ Object.Color ModulateBlurColor;
	public/*()*/ bool bAutofocus;
	public/*()*/ float AutofocusSpeedUp;
	public/*()*/ float AutofocusSpeedDown;
	public/*()*/ float AutofocusMaxDistance;
	public/*()*/ DOFEffect.EFocusType FocusType;
	public/*()*/ float FocusInnerRadius;
	public/*()*/ float FocusDistance;
	public/*()*/ Object.Vector FocusPosition;
	
	public DOFEffect()
	{
		// Object Offset:0x0030F1B0
		FalloffExponent = 2.0f;
		BlurKernelSize = 2.0f;
		MaxNearBlurAmount = 1.0f;
		MaxFarBlurAmount = 1.0f;
		ModulateBlurColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		bAutofocus = true;
		AutofocusSpeedUp = 0.50f;
		AutofocusSpeedDown = 1.50f;
		AutofocusMaxDistance = 400.0f;
		FocusInnerRadius = 400.0f;
		FocusDistance = 800.0f;
	}
}
}