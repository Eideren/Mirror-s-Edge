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
	
	public /*const export editinline transient */SkeletalMeshComponent SkelComponent;
	public/*(Controller)*/ name ControlName;
	public/*(Controller)*/ float ControlStrength;
	public/*(Controller)*/ float BlendInTime;
	public/*(Controller)*/ float BlendOutTime;
	public float StrengthTarget;
	public float BlendTimeToGo;
	public/*(Controller)*/ bool bSetStrengthFromAnimNode;
	public /*transient */bool bInitializedCachedNodeList;
	public/*(Controller)*/ bool bPropagateSetActive;
	public/*()*/ bool bIgnoreWhenNotRendered;
	public/*()*/ bool bEnableEaseInOut;
	public/*(Controller)*/ array<name> StrengthAnimNodeNameList;
	public /*transient */array<AnimNode> CachedNodeList;
	public/*(Controller)*/ float BoneScale;
	public int ControlTickTag;
	public/*(Controller)*/ int IgnoreAtOrAboveLOD;
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