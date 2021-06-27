namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlRandom : SkelControlSingleBone/*
		native
		hidecategories(Object)*/{
	public enum RandomAxis 
	{
		RAYaw,
		RAPitch,
		RARoll,
		RandomAxis_MAX
	};
	
	public/*(Random)*/ TdSkelControlRandom.RandomAxis AffectedAxis;
	public/*(Random)*/ int MinAngle;
	public/*(Random)*/ int MaxAngle;
	public/*(Random)*/ float Frequency;
	public/*(Random)*/ float TargetInterpolationTime;
	public/*(Random)*/ bool bAlwaysSwitchSign;
	public/*(Spring)*/ bool bScaleByVelocity;
	public/*(Spring)*/ float MaxVelocity;
	public/*(Spring)*/ float MinVelocity;
	public float TimeToUpdate;
	public int CurrentAngle;
	public int TargetAngle;
	public int LastSign;
	
	public TdSkelControlRandom()
	{
		// Object Offset:0x00657AA8
		MinAngle = -1000;
		MaxAngle = 1000;
		Frequency = 0.50f;
		TargetInterpolationTime = 0.50f;
		bScaleByVelocity = true;
		MaxVelocity = 400.0f;
		LastSign = 1;
	}
}
}