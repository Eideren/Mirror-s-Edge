namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlFootPlacement : SkelControlLimb/*
		native
		hidecategories(Object,Effector)*/{
	public/*(FootPlacement)*/ float FootOffset;
	public/*(FootPlacement)*/ Object.EAxis FootUpAxis;
	public/*(FootPlacement)*/ Object.Rotator FootRotOffset;
	public/*(FootPlacement)*/ bool bInvertFootUpAxis;
	public/*(FootPlacement)*/ bool bAlignFootPlacement;
	public/*(FootPlacement)*/ bool bOrientFootToGround;
	public/*(FootPlacement)*/ bool bOnlyEnableForUpAdjustment;
	public /*transient */bool bAdjustFootPlacement;
	public /*transient */bool bAdjustFootRotation;
	public/*(FootPlacement)*/ bool bInterpolateRotation;
	public/*(FootPlacement)*/ bool bInterpolatePosition;
	public /*private transient */bool bResetOnActivated;
	public/*(FootPlacement)*/ float MaxUpAdjustment;
	public/*(FootPlacement)*/ float MaxDownAdjustment;
	public/*(FootPlacement)*/ float MaxFootOrientAdjust;
	public Object.Rotator InterpolatedRotation;
	public/*(FootPlacement)*/ float RotationInterpolationSpeed;
	public float InterpolatedPosition;
	public/*(FootPlacement)*/ float PositionInterpolationSpeed;
	
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