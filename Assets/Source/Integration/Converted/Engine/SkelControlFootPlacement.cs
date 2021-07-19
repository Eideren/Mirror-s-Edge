namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlFootPlacement : SkelControlLimb/*
		native
		hidecategories(Object,Effector)*/{
	[Category("FootPlacement")] public float FootOffset;
	[Category("FootPlacement")] public Object.EAxis FootUpAxis;
	[Category("FootPlacement")] public Object.Rotator FootRotOffset;
	[Category("FootPlacement")] public bool bInvertFootUpAxis;
	[Category("FootPlacement")] public bool bOrientFootToGround;
	[Category("FootPlacement")] public bool bOnlyEnableForUpAdjustment;
	[Category("FootPlacement")] public float MaxUpAdjustment;
	[Category("FootPlacement")] public float MaxDownAdjustment;
	[Category("FootPlacement")] public float MaxFootOrientAdjust;
	
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