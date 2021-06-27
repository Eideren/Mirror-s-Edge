namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlLimb : SkelControlBase/*
		native
		hidecategories(Object)*/{
	public/*(Effector)*/ Object.Vector EffectorLocation;
	public/*(Effector)*/ SkelControlBase.EBoneControlSpace EffectorLocationSpace;
	public/*(Joint)*/ SkelControlBase.EBoneControlSpace JointTargetLocationSpace;
	public/*(Limb)*/ Object.EAxis BoneAxis;
	public/*(Limb)*/ Object.EAxis JointAxis;
	public/*(Effector)*/ name EffectorSpaceBoneName;
	public/*(Joint)*/ Object.Vector JointTargetLocation;
	public/*(Joint)*/ name JointTargetSpaceBoneName;
	public/*(Limb)*/ bool bInvertBoneAxis;
	public/*(Limb)*/ bool bInvertJointAxis;
	public/*(Limb)*/ bool bMaintainEffectorRelRot;
	public/*(Limb)*/ bool bTakeRotationFromEffectorSpace;
	
	public SkelControlLimb()
	{
		// Object Offset:0x003E27E6
		BoneAxis = Object.EAxis.AXIS_X;
		JointAxis = Object.EAxis.AXIS_Y;
	}
}
}