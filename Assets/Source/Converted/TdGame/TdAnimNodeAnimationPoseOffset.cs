namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeAnimationPoseOffset : TdAnimNodePoseOffset/*
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */AnimationPoseProfile
	{
		public/*()*/ name Name;
		public/*()*/ bool Recursive;
		public/*()*/ array<name> BoneNames;
		public/*()*/ array<name> AdditionalBoneNames;
		public/*()*/ AnimSet AnimationSet;
		public/*()*/ name AnimationPoseName;
		public/*()*/ name OffsetAnimationPoseName;
		public/*()*/ SkeletalMesh SkeletalMeshReference;
	
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
	
	public/*(AnimationSettings)*/ /*editoronly */array<TdAnimNodeAnimationPoseOffset.AnimationPoseProfile> AnimationPoseProfiles;
	
}
}