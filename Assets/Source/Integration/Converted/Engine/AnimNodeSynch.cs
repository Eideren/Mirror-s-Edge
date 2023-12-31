namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeSynch : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */SynchGroup
	{
		public array<AnimNodeSequence> SeqNodes;
		[transient] public AnimNodeSequence MasterNode;
		[Category] public name GroupName;
		[Category] public bool bFireSlaveNotifies;
		[Category] public float RateScale;
		[Category] public bool bUseSharedMasterControlNode;
		public float SharedMasterRelativePosition;
		public float SharedMasterMoveDelta;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029F30A
	//		SeqNodes = default;
	//		MasterNode = default;
	//		GroupName = (name)"None";
	//		bFireSlaveNotifies = false;
	//		RateScale = 1.0f;
	//		bUseSharedMasterControlNode = false;
	//		SharedMasterRelativePosition = 0.0f;
	//		SharedMasterMoveDelta = 0.0f;
	//	}
	};
	
	[Category] public array<AnimNodeSynch.SynchGroup> Groups;
	
	// Export UAnimNodeSynch::execAddNodeToGroup(FFrame&, void* const)
	public virtual /*native final function */void AddNodeToGroup(AnimNodeSequence SeqNode, name GroupName)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UAnimNodeSynch::execRemoveNodeFromGroup(FFrame&, void* const)
	public virtual /*native final function */void RemoveNodeFromGroup(AnimNodeSequence SeqNode, name GroupName)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public AnimNodeSynch()
	{
		// Object Offset:0x0029F812
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Input",
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