namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlSingleBone : SkelControlBase/*
		native
		hidecategories(Object)*/{
	[Category("Adjustments")] public bool bApplyTranslation;
	[Category("Translation")] public bool bAddTranslation;
	[Category("Adjustments")] public bool bApplyRotation;
	[Category("Rotation")] public bool bAddRotation;
	[Category("Translation")] public Object.Vector BoneTranslation;
	[Category("Translation")] public SkelControlBase.EBoneControlSpace BoneTranslationSpace;
	[Category("Rotation")] public SkelControlBase.EBoneControlSpace BoneRotationSpace;
	[Category("Translation")] public name TranslationSpaceBoneName;
	[Category("Rotation")] public Object.Rotator BoneRotation;
	[Category("Rotation")] public name RotationSpaceBoneName;
	
}
}