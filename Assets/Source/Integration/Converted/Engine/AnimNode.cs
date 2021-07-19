namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNode : Object/*
		abstract
		native
		hidecategories(Object)*/{
	public enum ESliderType 
	{
		ST_1D,
		ST_2D,
		ST_MAX
	};
	
	public partial struct BoneAtom
	{
		public Object.Quat Rotation;
		public Object.Vector Translation;
		public float Scale;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00257F33
	//		Rotation = new Quat
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		Translation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Scale = 0.0f;
	//	}
	};
	
	[Category("ClassProperties")] [editconst] public name ClassName;
	[export, editinline, transient] public SkeletalMeshComponent SkelComponent;
	[transient] public array<AnimNodeBlendBase> ParentNodes;
	[Category] public name NodeName;
	[transient] public array<AnimNode.BoneAtom> CachedBoneAtoms;
	[transient] public AnimNode.BoneAtom CachedRootMotionDelta;
	[transient] public int bCachedHasRootMotion;
	[Const, transient] public bool bRelevant;
	[Const, transient] public bool bJustBecameRelevant;
	[Category] public bool bSkipTickWhenZeroWeight;
	[Category] public bool bTickDuringPausedAnims;
	[Const, transient] public int NodeTickTag;
	[Const, transient] public int NodeCachedAtomsTag;
	[Const] public float NodeTotalWeight;
	[Const, transient] public float TotalWeightAccumulator;
	public int DrawWidth;
	public int DrawHeight;
	public int NodePosX;
	public int NodePosY;
	public int OutDrawY;
	[Const] public int InstanceVersionNumber;
	[Const, transient] public/*protected*/ int SearchTag;
	
	public virtual /*event */void OnInit()
	{
	
	}
	
	public virtual /*event */void OnBecomeRelevant()
	{
	
	}
	
	public virtual /*event */void OnCeaseRelevant()
	{
	
	}
	
	public virtual /*event */void EditorProfileUpdated(name ProfileName)
	{
	
	}
	
	// Export UAnimNode::execFindAnimNode(FFrame&, void* const)
	public virtual /*native final function */AnimNode FindAnimNode(name InNodeName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UAnimNode::execPlayAnim(FFrame&, void* const)
	public virtual /*native function */void PlayAnim(/*optional */bool? _bLoop = default, /*optional */float? _Rate = default, /*optional */float? _StartTime = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UAnimNode::execStopAnim(FFrame&, void* const)
	public virtual /*native function */void StopAnim()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
}
}