namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlBase : Object/*
		abstract
		native
		hidecategories(Object)*/{
	public enum EBoneControlSpace 
	{
		BCS_WorldSpace,
		BCS_ActorSpace,
		BCS_ComponentSpace,
		BCS_ParentBoneSpace,
		BCS_BoneSpace,
		BCS_OtherBoneSpace,
		BCS_MAX
	};
	
	[Const, export, editinline, transient] public SkeletalMeshComponent SkelComponent;
	[Category("Controller")] public name ControlName;
	[Category("Controller")] public float ControlStrength;
	[Category("Controller")] public float BlendInTime;
	[Category("Controller")] public float BlendOutTime;
	public float StrengthTarget;
	public float BlendTimeToGo;
	[Category("Controller")] public bool bSetStrengthFromAnimNode;
	[transient] public bool bInitializedCachedNodeList;
	[Category("Controller")] public bool bPropagateSetActive;
	[Category] public bool bIgnoreWhenNotRendered;
	[Category] public bool bEnableEaseInOut;
	[Category("Controller")] public array<name> StrengthAnimNodeNameList;
	[transient] public array<AnimNode> CachedNodeList;
	[Category("Controller")] public float BoneScale;
	public int ControlTickTag;
	[Category("Controller")] public int IgnoreAtOrAboveLOD;
	public SkelControlBase NextControl;
	public int ControlPosX;
	public int ControlPosY;
	public int DrawWidth;
	
	// Export USkelControlBase::execSetSkelControlActive(FFrame&, void* const)
	public virtual /*native final function */void SetSkelControlActive(bool bInActive)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkelControlBase::execSetSkelControlStrength(FFrame&, void* const)
	public virtual /*native final function */void SetSkelControlStrength(float NewStrength, float InBlendTime)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public SkelControlBase()
	{
		// Object Offset:0x003E2487
		ControlStrength = 1.0f;
		BlendInTime = 0.20f;
		BlendOutTime = 0.20f;
		StrengthTarget = 1.0f;
		BoneScale = 1.0f;
		IgnoreAtOrAboveLOD = 1000;
	}
}
}