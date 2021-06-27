namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlFootPlacement : SkelControlLimb/*
		native
		hidecategories(Object,Effector)*/{
	public/*(FootPlacement)*/ float FootOffset;
	public/*(FootPlacement)*/ Object.EAxis FootUpAxis;
	public/*(FootPlacement)*/ Object.Rotator FootRotOffset;
	public/*(FootPlacement)*/ bool bInvertFootUpAxis;
	public/*(FootPlacement)*/ bool bOrientFootToGround;
	public/*(FootPlacement)*/ bool bOnlyEnableForUpAdjustment;
	public/*(FootPlacement)*/ float MaxUpAdjustment;
	public/*(FootPlacement)*/ float MaxDownAdjustment;
	public/*(FootPlacement)*/ float MaxFootOrientAdjust;
	
	public SkelControlFootPlacement()
	{
		// Object Offset:0x003E2A31
		FootUpAxis = Object.EAxis.AXIS_X;
		bOrientFootToGround = true;
		MaxUpAdjustment = 50.0f;
		MaxFootOrientAdjust = 45.0f;
	}
}
}