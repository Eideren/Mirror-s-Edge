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
	
	[Category("Random")] public TdSkelControlRandom.RandomAxis AffectedAxis;
	[Category("Random")] public int MinAngle;
	[Category("Random")] public int MaxAngle;
	[Category("Random")] public float Frequency;
	[Category("Random")] public float TargetInterpolationTime;
	[Category("Random")] public bool bAlwaysSwitchSign;
	[Category("Spring")] public bool bScaleByVelocity;
	[Category("Spring")] public float MaxVelocity;
	[Category("Spring")] public float MinVelocity;
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