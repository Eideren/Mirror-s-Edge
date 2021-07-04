namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_BodyInstance : Object/*
		native
		hidecategories(Object)*/{
	public /*const export editinline transient */PrimitiveComponent OwnerComponent;
	public /*const */int BodyIndex;
	public Object.Vector Velocity;
	public Object.Vector PreviousVelocity;
	public /*native const */int SceneIndex;
	public /*native const */Object.Pointer BodyData;
	public /*native const */Object.Pointer BoneSpring;
	public /*native const */Object.Pointer BoneSpringKinActor;
	public/*(BoneSpring)*/ bool bEnableBoneSpringLinear;
	public/*(BoneSpring)*/ bool bEnableBoneSpringAngular;
	public/*(BoneSpring)*/ bool bDisableOnOverextension;
	public/*(BoneSpring)*/ bool bTeleportOnOverextension;
	public/*(BoneSpring)*/ bool bUseKinActorForBoneSpring;
	public/*(BoneSpring)*/ bool bMakeSpringToBaseCollisionComponent;
	public/*(Physics)*/ /*const */bool bOnlyCollideWithPawns;
	public/*(Physics)*/ /*const */bool bEnableCollisionResponse;
	public/*(Physics)*/ /*const */bool bPushBody;
	public/*(BoneSpring)*/ /*const */float BoneLinearSpring;
	public/*(BoneSpring)*/ /*const */float BoneLinearDamping;
	public/*(BoneSpring)*/ /*const */float BoneAngularSpring;
	public/*(BoneSpring)*/ /*const */float BoneAngularDamping;
	public/*(BoneSpring)*/ float OverextensionThreshold;
	public/*()*/ float CustomGravityFactor;
	public /*transient */float LastEffectPlayedTime;
	public/*(Physics)*/ /*const */PhysicalMaterial PhysMaterialOverride;
	
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