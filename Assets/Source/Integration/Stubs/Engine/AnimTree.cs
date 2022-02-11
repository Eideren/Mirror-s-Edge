// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimTree : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public partial struct /*native */AnimGroup
	{
		[Const, transient] public array<AnimNodeSequence> SeqNodes;
		[Const, transient] public AnimNodeSequence SynchMaster;
		[Const, transient] public AnimNodeSequence NotifyMaster;
		[Category] [Const] public name GroupName;
		[Category] [Const] public float RateScale;
	
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
		[export, editinline] public SkelControlBase ControlHead;
		public int DrawY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A15F6
	//		BoneName = (name)"None";
	//		ControlHead = default;
	//		DrawY = 0;
	//	}
	};
	
	[Category] public array<AnimTree.AnimGroup> AnimGroups;
	[Category] public array<name> PrioritizedSkelBranches;
	public array<byte> PriorityList;
	[export, editinline] public array</*export editinline */MorphNodeBase> RootMorphNodes;
	[export, editinline] public array</*export editinline */AnimTree.SkelControlListHead> SkelControlLists;
	public int MorphConnDrawY;
	[transient] public bool bBeingEdited;
	[Category] public float PreviewPlayRate;
	[Category] [editoronly] public SkeletalMesh PreviewSkelMesh;
	[Category] [editoronly] public array<SkeletalMesh> SocketSkelMesh;
	[Category] [editoronly] public array<StaticMesh> SocketStaticMesh;
	[Category] public array<name> SocketName;
	[Category] [editoronly] public array<AnimSet> PreviewAnimSets;
	[Category] [editoronly] public array<MorphTargetSet> PreviewMorphSets;
	public Object.Vector PreviewCamPos;
	public Object.Rotator PreviewCamRot;
	public Object.Vector PreviewFloorPos;
	public int PreviewFloorYaw;
	
	// Export UAnimTree::execFindSkelControl(FFrame&, void* const)
	//public virtual /*native final function */SkelControlBase FindSkelControl(name InControlName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	// stub
	//	return default;
	//}
	
	// Export UAnimTree::execSetAnimGroupForNode(FFrame&, void* const)
	public virtual /*native final function */bool SetAnimGroupForNode(AnimNodeSequence SeqNode, name GroupName, /*optional */bool? _bCreateIfNotFound = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
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
				bHasRootMotion = false,
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