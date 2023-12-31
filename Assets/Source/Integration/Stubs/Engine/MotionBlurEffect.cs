namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MotionBlurEffect : PostProcessEffect/*
		native
		hidecategories(Object)*/{
	[Category] public float MaxVelocity;
	[Category] public float MotionBlurAmount;
	[Category] public bool FullMotionBlur;
	[Category] public float CameraRotationThreshold;
	[Category] public float CameraTranslationThreshold;
	
	public MotionBlurEffect()
	{
		// Object Offset:0x0035D76E
		MaxVelocity = 1.0f;
		MotionBlurAmount = 0.50f;
		FullMotionBlur = true;
		CameraRotationThreshold = 90.0f;
		CameraTranslationThreshold = 10000.0f;
		bShowInEditor = false;
	}
}
}