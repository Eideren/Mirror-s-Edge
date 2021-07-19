namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlLimb : SkelControlBase/*
		native
		hidecategories(Object)*/{
	[Category("Effector")] public Object.Vector EffectorLocation;
	[Category("Effector")] public SkelControlBase.EBoneControlSpace EffectorLocationSpace;
	[Category("Joint")] public SkelControlBase.EBoneControlSpace JointTargetLocationSpace;
	[Category("Limb")] public Object.EAxis BoneAxis;
	[Category("Limb")] public Object.EAxis JointAxis;
	[Category("Effector")] public name EffectorSpaceBoneName;
	[Category("Joint")] public Object.Vector JointTargetLocation;
	[Category("Joint")] public name JointTargetSpaceBoneName;
	[Category("Limb")] public bool bInvertBoneAxis;
	[Category("Limb")] public bool bInvertJointAxis;
	[Category("Limb")] public bool bMaintainEffectorRelRot;
	[Category("Limb")] public bool bTakeRotationFromEffectorSpace;
	
	public SkelControlLimb()
	{
		// Object Offset:0x003E27E6
		BoneAxis = Object.EAxis.AXIS_X;
		JointAxis = Object.EAxis.AXIS_Y;
	}
}
}