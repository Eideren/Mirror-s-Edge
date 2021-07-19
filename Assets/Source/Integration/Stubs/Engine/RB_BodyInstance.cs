namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_BodyInstance : Object/*
		native
		hidecategories(Object)*/{
	[Const, export, editinline, transient] public PrimitiveComponent OwnerComponent;
	[Const] public int BodyIndex;
	public Object.Vector Velocity;
	public Object.Vector PreviousVelocity;
	[native, Const] public int SceneIndex;
	[native, Const] public Object.Pointer BodyData;
	[native, Const] public Object.Pointer BoneSpring;
	[native, Const] public Object.Pointer BoneSpringKinActor;
	[Category("BoneSpring")] public bool bEnableBoneSpringLinear;
	[Category("BoneSpring")] public bool bEnableBoneSpringAngular;
	[Category("BoneSpring")] public bool bDisableOnOverextension;
	[Category("BoneSpring")] public bool bTeleportOnOverextension;
	[Category("BoneSpring")] public bool bUseKinActorForBoneSpring;
	[Category("BoneSpring")] public bool bMakeSpringToBaseCollisionComponent;
	[Category("Physics")] [Const] public bool bOnlyCollideWithPawns;
	[Category("Physics")] [Const] public bool bEnableCollisionResponse;
	[Category("Physics")] [Const] public bool bPushBody;
	[Category("BoneSpring")] [Const] public float BoneLinearSpring;
	[Category("BoneSpring")] [Const] public float BoneLinearDamping;
	[Category("BoneSpring")] [Const] public float BoneAngularSpring;
	[Category("BoneSpring")] [Const] public float BoneAngularDamping;
	[Category("BoneSpring")] public float OverextensionThreshold;
	[Category] public float CustomGravityFactor;
	[transient] public float LastEffectPlayedTime;
	[Category("Physics")] [Const] public PhysicalMaterial PhysMaterialOverride;
	
	// Export URB_BodyInstance::execSetFixed(FFrame&, void* const)
	public virtual /*native final function */void SetFixed(bool bNewFixed)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_BodyInstance::execIsFixed(FFrame&, void* const)
	public virtual /*native final function */bool IsFixed()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export URB_BodyInstance::execIsValidBodyInstance(FFrame&, void* const)
	public virtual /*native final function */bool IsValidBodyInstance()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export URB_BodyInstance::execGetUnrealWorldTM(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetUnrealWorldTM()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export URB_BodyInstance::execGetUnrealWorldVelocity(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetUnrealWorldVelocity()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export URB_BodyInstance::execGetUnrealWorldAngularVelocity(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetUnrealWorldAngularVelocity()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export URB_BodyInstance::execEnableBoneSpring(FFrame&, void* const)
	public virtual /*native final function */void EnableBoneSpring(bool bInEnableLinear, bool bInEnableAngular, /*const */ref Object.Matrix InBoneTarget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_BodyInstance::execSetBoneSpringParams(FFrame&, void* const)
	public virtual /*native final function */void SetBoneSpringParams(float InLinearSpring, float InLinearDamping, float InAngularSpring, float InAngularDamping)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_BodyInstance::execSetBoneSpringTarget(FFrame&, void* const)
	public virtual /*native final function */void SetBoneSpringTarget(/*const */ref Object.Matrix InBoneTarget, bool bTeleport)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_BodyInstance::execSetBlockRigidBody(FFrame&, void* const)
	public virtual /*native final function */void SetBlockRigidBody(bool bNewBlockRigidBody)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_BodyInstance::execSetPhysMaterialOverride(FFrame&, void* const)
	public virtual /*native final function */void SetPhysMaterialOverride(PhysicalMaterial NewPhysMaterial)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_BodyInstance::execEnableCollisionResponse(FFrame&, void* const)
	public virtual /*native final function */void EnableCollisionResponse(bool bEnableResponse)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public RB_BodyInstance()
	{
		// Object Offset:0x003AA3C9
		bEnableCollisionResponse = true;
		BoneLinearSpring = 10.0f;
		BoneLinearDamping = 0.10f;
		BoneAngularSpring = 1.0f;
		BoneAngularDamping = 0.10f;
		CustomGravityFactor = 1.0f;
	}
}
}