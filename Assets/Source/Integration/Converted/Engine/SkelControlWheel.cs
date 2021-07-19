namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlWheel : SkelControlSingleBone/*
		native
		hidecategories(Object,Translation,Rotation)*/{
	[Category("Wheel")] [transient] public float WheelDisplacement;
	[Category("Wheel")] public float WheelMaxRenderDisplacement;
	[Category("Wheel")] [transient] public float WheelRoll;
	[Category("Wheel")] public Object.EAxis WheelRollAxis;
	[Category("Wheel")] public Object.EAxis WheelSteeringAxis;
	[Category("Wheel")] [transient] public float WheelSteering;
	[Category("Wheel")] public bool bInvertWheelRoll;
	[Category("Wheel")] public bool bInvertWheelSteering;
	
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