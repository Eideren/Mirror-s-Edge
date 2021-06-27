namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlWheel : SkelControlSingleBone/*
		native
		hidecategories(Object,Translation,Rotation)*/{
	public/*(Wheel)*/ /*transient */float WheelDisplacement;
	public/*(Wheel)*/ float WheelMaxRenderDisplacement;
	public/*(Wheel)*/ /*transient */float WheelRoll;
	public/*(Wheel)*/ Object.EAxis WheelRollAxis;
	public/*(Wheel)*/ Object.EAxis WheelSteeringAxis;
	public/*(Wheel)*/ /*transient */float WheelSteering;
	public/*(Wheel)*/ bool bInvertWheelRoll;
	public/*(Wheel)*/ bool bInvertWheelSteering;
	
	public SkelControlWheel()
	{
		// Object Offset:0x003E3D8C
		WheelMaxRenderDisplacement = 50.0f;
		WheelRollAxis = Object.EAxis.AXIS_X;
		WheelSteeringAxis = Object.EAxis.AXIS_Z;
		bApplyTranslation = true;
		bAddTranslation = true;
		bApplyRotation = true;
		bAddRotation = true;
		BoneTranslationSpace = SkelControlBase.EBoneControlSpace.BCS_BoneSpace;
		BoneRotationSpace = SkelControlBase.EBoneControlSpace.BCS_BoneSpace;
		bIgnoreWhenNotRendered = true;
	}
}
}