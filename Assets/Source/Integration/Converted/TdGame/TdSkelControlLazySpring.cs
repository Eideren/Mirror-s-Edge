namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlLazySpring : SkelControlSingleBone/*
		native
		hidecategories(Object)*/{
	public enum SpringAxis 
	{
		SAYaw,
		SAPitch,
		SARoll,
		SpringAxis_MAX
	};
	
	[Category("Spring")] public TdSkelControlLazySpring.SpringAxis AffectedAxis;
	[Category("Spring")] public TdSkelControlLazySpring.SpringAxis SourceAxis;
	[Category("Spring")] public int MaxAngle;
	[Category("Spring")] public int MinAngle;
	[Category("Spring")] public float InterpolateTime;
	[Category("Spring")] public float SpringMultiplier;
	[Category("Spring")] public bool bScaleByVelocity;
	[Category("Spring")] public bool bIgnoreSlomo;
	[Category("Spring")] public bool bOnlyPositiveInput;
	[Category("Spring")] public float MaxVelocity;
	[Category("Spring")] public float MinVelocity;
	[Category("Spring")] public float HeavyWeaponModifier;
	public int LazyRotation;
	
	public TdSkelControlLazySpring()
	{
		// Object Offset:0x006573CB
		MaxAngle = 8192;
		MinAngle = -8192;
		InterpolateTime = 0.10f;
		SpringMultiplier = 1.0f;
		bScaleByVelocity = true;
		bIgnoreSlomo = true;
		MaxVelocity = 400.0f;
		MinVelocity = 100.0f;
		HeavyWeaponModifier = 0.50f;
		bApplyRotation = true;
		BoneRotationSpace = SkelControlBase.EBoneControlSpace.BCS_BoneSpace;
	}
}
}