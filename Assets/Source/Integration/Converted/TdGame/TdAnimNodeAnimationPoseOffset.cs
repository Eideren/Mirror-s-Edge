namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeAnimationPoseOffset : TdAnimNodePoseOffset/*
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */AnimationPoseProfile
	{
		[Category] public name Name;
		[Category] public bool Recursive;
		[Category] public array<name> BoneNames;
		[Category] public array<name> AdditionalBoneNames;
		[Category] public AnimSet AnimationSet;
		[Category] public name AnimationPoseName;
		[Category] public name OffsetAnimationPoseName;
		[Category] public SkeletalMesh SkeletalMeshReference;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004FDD3C
	//		Name = (name)"None";
	//		Recursive = false;
	//		BoneNames = default;
	//		AdditionalBoneNames = default;
	//		AnimationSet = default;
	//		AnimationPoseName = (name)"None";
	//		OffsetAnimationPoseName = (name)"None";
	//		SkeletalMeshReference = default;
	//	}
	};
	
	[Category("AnimationSettings")] [editoronly] public array<TdAnimNodeAnimationPoseOffset.AnimationPoseProfile> AnimationPoseProfiles;
	
}
}