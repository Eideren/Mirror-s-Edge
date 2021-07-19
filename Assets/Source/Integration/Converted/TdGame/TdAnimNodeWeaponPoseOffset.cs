namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeWeaponPoseOffset : TdAnimNodePoseOffset/*
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */WeaponPoseProfile
	{
		[Category] public name Name;
		[Category] public bool Recursive;
		[Category] public array<name> BoneNames;
		[Category] public array<name> AdditionalBoneNames;
		[Category] public name AnimationPoseName;
		[Category] public AnimSet AnimationSet;
		[Category] public AnimSet WeaponAnimationSet;
		[Category] public SkeletalMesh SkeletalMeshReference;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00508448
	//		Name = (name)"None";
	//		Recursive = false;
	//		BoneNames = new array<name>
	//		{
	//			(name)"Name",
	//		};
	//		AdditionalBoneNames = default;
	//		AnimationPoseName = (name)"None";
	//		AnimationSet = default;
	//		WeaponAnimationSet = default;
	//		SkeletalMeshReference = default;
	//	}
	};
	
	[Category("AnimationSettings")] [editoronly] public array<TdAnimNodeWeaponPoseOffset.WeaponPoseProfile> WeaponPoseProfiles;
	
}
}