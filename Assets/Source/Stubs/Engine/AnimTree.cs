namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimTree : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public partial struct /*native */AnimGroup
	{
		public /*const transient */array<AnimNodeSequence> SeqNodes;
		public /*const transient */AnimNodeSequence SynchMaster;
		public /*const transient */AnimNodeSequence NotifyMaster;
		public/*()*/ /*const */name GroupName;
		public/*()*/ /*const */float RateScale;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A1156
	//		SeqNodes = default;
	//		SynchMaster = default;
	//		NotifyMaster = default;
	//		GroupName = (name)"None";
	//		RateScale = 1.0f;
	//	}
	};
	
	public partial struct /*native */SkelControlListHead
	{
		public name BoneName;
		public /*export editinline */SkelControlBase ControlHead;
		public int DrawY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A15F6
	//		BoneName = (name)"None";
	//		ControlHead = default;
	//		DrawY = 0;
	//	}
	};
	
	public/*()*/ array<AnimTree.AnimGroup> AnimGroups;
	public/*()*/ array<name> PrioritizedSkelBranches;
	public array<byte> PriorityList;
	public /*export editinline */array</*export editinline */MorphNodeBase> RootMorphNodes;
	public /*export editinline */array</*export editinline */AnimTree.SkelControlListHead> SkelControlLists;
	public int MorphConnDrawY;
	public /*transient */bool bBeingEdited;
	public/*()*/ float PreviewPlayRate;
	public/*()*/ /*editoronly */SkeletalMesh PreviewSkelMesh;
	public/*()*/ /*editoronly */array<SkeletalMesh> SocketSkelMesh;
	public/*()*/ /*editoronly */array<StaticMesh> SocketStaticMesh;
	public/*()*/ array<name> SocketName;
	public/*()*/ /*editoronly */array<AnimSet> PreviewAnimSets;
	public/*()*/ /*editoronly */array<MorphTargetSet> PreviewMorphSets;
	public Object.Vector PreviewCamPos;
	public Object.Rotator PreviewCamRot;
	public Object.Vector PreviewFloorPos;
	public int PreviewFloorYaw;
	
	// Export UAnimTree::execFindSkelControl(FFrame&, void* const)
	public virtual /*native final function */SkelControlBase FindSkelControl(name InControlName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimTree::execFindMorphNode(FFrame&, void* const)
	public virtual /*native final function */MorphNodeBase FindMorphNode(name InNodeName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimTree::execSetAnimGroupForNode(FFrame&, void* const)
	public virtual /*native final function */bool SetAnimGroupForNode(AnimNodeSequence SeqNode, name GroupName, /*optional */bool? _bCreateIfNotFound = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimTree::execGetGroupSynchMaster(FFrame&, void* const)
	public virtual /*native final function */AnimNodeSequence GetGroupSynchMaster(name GroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimTree::execGetGroupNotifyMaster(FFrame&, void* const)
	public virtual /*native final function */AnimNodeSequence GetGroupNotifyMaster(name GroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimTree::execForceGroupRelativePosition(FFrame&, void* const)
	public virtual /*native final function */void ForceGroupRelativePosition(name GroupName, float RelativePosition)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAnimTree::execGetGroupRelativePosition(FFrame&, void* const)
	public virtual /*native final function */float GetGroupRelativePosition(name GroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimTree::execSetGroupRateScale(FFrame&, void* const)
	public virtual /*native final function */void SetGroupRateScale(name GroupName, float NewRateScale)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAnimTree::execGetGroupIndex(FFrame&, void* const)
	public virtual /*native final function */int GetGroupIndex(name GroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public AnimTree()
	{
		// Object Offset:0x002A1C70
		PreviewPlayRate = 1.0f;
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Child",
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