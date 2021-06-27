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
	
	public/*(Spring)*/ TdSkelControlLazySpring.SpringAxis AffectedAxis;
	public/*(Spring)*/ TdSkelControlLazySpring.SpringAxis SourceAxis;
	public/*(Spring)*/ int MaxAngle;
	public/*(Spring)*/ int MinAngle;
	public/*(Spring)*/ float InterpolateTime;
	public/*(Spring)*/ float SpringMultiplier;
	public/*(Spring)*/ bool bScaleByVelocity;
	public/*(Spring)*/ bool bIgnoreSlomo;
	public/*(Spring)*/ bool bOnlyPositiveInput;
	public/*(Spring)*/ float MaxVelocity;
	public/*(Spring)*/ float MinVelocity;
	public/*(Spring)*/ float HeavyWeaponModifier;
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