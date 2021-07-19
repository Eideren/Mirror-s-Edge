namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlFootPlacement : SkelControlLimb/*
		native
		hidecategories(Object,Effector)*/{
	[Category("FootPlacement")] public float FootOffset;
	[Category("FootPlacement")] public Object.EAxis FootUpAxis;
	[Category("FootPlacement")] public Object.Rotator FootRotOffset;
	[Category("FootPlacement")] public bool bInvertFootUpAxis;
	[Category("FootPlacement")] public bool bAlignFootPlacement;
	[Category("FootPlacement")] public bool bOrientFootToGround;
	[Category("FootPlacement")] public bool bOnlyEnableForUpAdjustment;
	[transient] public bool bAdjustFootPlacement;
	[transient] public bool bAdjustFootRotation;
	[Category("FootPlacement")] public bool bInterpolateRotation;
	[Category("FootPlacement")] public bool bInterpolatePosition;
	[transient] public/*private*/ bool bResetOnActivated;
	[Category("FootPlacement")] public float MaxUpAdjustment;
	[Category("FootPlacement")] public float MaxDownAdjustment;
	[Category("FootPlacement")] public float MaxFootOrientAdjust;
	public Object.Rotator InterpolatedRotation;
	[Category("FootPlacement")] public float RotationInterpolationSpeed;
	public float InterpolatedPosition;
	[Category("FootPlacement")] public float PositionInterpolationSpeed;
	
	// Export UTdSkelControlFootPlacement::execOnSkelControlActive(FFrame&, void* const)
	public virtual /*native final function */void OnSkelControlActive()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public TdSkelControlFootPlacement()
	{
		// Object Offset:0x00656F31
		FootUpAxis = Object.EAxis.AXIS_X;
		bAlignFootPlacement = true;
		bOrientFootToGround = true;
		bInterpolateRotation = true;
		bInterpolatePosition = true;
		bResetOnActivated = true;
		MaxUpAdjustment = 50.0f;
		MaxFootOrientAdjust = 45.0f;
		RotationInterpolationSpeed = 20.0f;
		PositionInterpolationSpeed = 20.0f;
	}
}
}