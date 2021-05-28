namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodePoseOffset : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */PoseProfile
	{
		public name Name;
		public bool bIsValid;
		public array<int> BoneIndices;
		public array<Object.Matrix> MatrixTransforms;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004FD5AB
	//		Name = (name)"None";
	//		bIsValid = false;
	//		BoneIndices = default;
	//		MatrixTransforms = default;
	//	}
	};
	
	public array<TdAnimNodePoseOffset.PoseProfile> Profiles;
	public TdAnimNodePoseOffset.PoseProfile ActivePoseProfile;
	public/*(GeneralSettings)*/ /*transient */bool bDisable;
	public/*(EditorSettings)*/ /*transient */bool BuildPoseOffsets;
	public/*(EditorSettings)*/ /*editoronly */int ActivePoseProfileIndex;
	
	public override /*event */void EditorProfileUpdated(name ProfileName)
	{
		SetActiveProfileByName(ProfileName);
	}
	
	public virtual /*simulated function */void SetActiveProfileByName(name ProfileName)
	{
		/*local */int Index = default;
		/*local */bool bFound = default;
	
		bFound = false;
		Index = 0;
		J0x0F:{}
		if(Index < Profiles.Length)
		{
			if(Profiles[Index].Name == ProfileName)
			{
				bFound = true;
				ActivePoseProfileIndex = Index;
				ActivePoseProfile = Profiles[Index];
				goto J0x70;
			}
			++ Index;
			goto J0x0F;
		}
		J0x70:{}
		if(!bFound)
		{
			ActivePoseProfileIndex = 0;
			ActivePoseProfile = Profiles[0];
		}
	}
	
	public TdAnimNodePoseOffset()
	{
		// Object Offset:0x004FD905
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Input",
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
		};
		bFixNumChildren = true;
	}
}
}