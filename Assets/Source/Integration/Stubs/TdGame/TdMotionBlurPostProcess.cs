namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMotionBlurPostProcess : PostProcessEffect/*
		native
		hidecategories(Object)*/{
	public/*()*/ float TdMotionBlurAmount;
	public/*()*/ float TdMotionBlurStartPlayerSpeed;
	public/*()*/ bool TdMotionBlurEnabled;
	public/*()*/ bool TdMotionBlurUseDirection;
	public/*()*/ bool TdMotionBlurForce;
	public/*()*/ Object.Vector TdMotionBlurForcedDirection;
	public/*()*/ float TdMotionBlurForcedAmount;
	
	public TdMotionBlurPostProcess()
	{
		// Object Offset:0x0059139B
		TdMotionBlurAmount = 0.50f;
		TdMotionBlurStartPlayerSpeed = 400.0f;
		TdMotionBlurEnabled = true;
		TdMotionBlurUseDirection = true;
		TdMotionBlurForcedAmount = 0.50f;
	}
}
}