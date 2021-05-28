namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlSingleBone : SkelControlBase/*
		native
		hidecategories(Object)*/{
	public/*(Adjustments)*/ bool bApplyTranslation;
	public/*(Translation)*/ bool bAddTranslation;
	public/*(Adjustments)*/ bool bApplyRotation;
	public/*(Rotation)*/ bool bAddRotation;
	public/*(Translation)*/ Object.Vector BoneTranslation;
	public/*(Translation)*/ SkelControlBase.EBoneControlSpace BoneTranslationSpace;
	public/*(Rotation)*/ SkelControlBase.EBoneControlSpace BoneRotationSpace;
	public/*(Translation)*/ name TranslationSpaceBoneName;
	public/*(Rotation)*/ Object.Rotator BoneRotation;
	public/*(Rotation)*/ name RotationSpaceBoneName;
	
}
}