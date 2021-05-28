namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeBlendMultiBone : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public partial struct /*native */ChildBoneBlendInfo
	{
		public array<float> TargetPerBoneWeight;
		public/*()*/ name InitTargetStartBone;
		public/*()*/ float InitPerBoneIncrease;
		public /*const */name OldStartBone;
		public /*const */float OldBoneIncrease;
		public /*transient */array<byte> TargetRequiredBones;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029A75D
	//		TargetPerBoneWeight = default;
	//		InitTargetStartBone = (name)"None";
	//		InitPerBoneIncrease = 1.0f;
	//		OldStartBone = (name)"None";
	//		OldBoneIncrease = 0.0f;
	//		TargetRequiredBones = default;
	//	}
	};
	
	public/*()*/ array<AnimNodeBlendMultiBone.ChildBoneBlendInfo> BlendTargetList;
	public /*transient */array<byte> SourceRequiredBones;
	
	// Export UAnimNodeBlendMultiBone::execSetTargetStartBone(FFrame&, void* const)
	public virtual /*native final function */void SetTargetStartBone(int TargetIdx, name StartBoneName, /*optional */float PerBoneIncrease = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public AnimNodeBlendMultiBone()
	{
		// Object Offset:0x0029A975
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Source",
				Anim = default,
				Weight = 1.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Target",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
		};
	}
}
}