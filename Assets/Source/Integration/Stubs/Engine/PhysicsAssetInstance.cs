namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysicsAssetInstance : Object/*
		native
		hidecategories(Object)*/{
	public /*const transient */Actor Owner;
	public /*const transient */int RootBodyIndex;
	public /*const export editinline */array</*export editinline */RB_BodyInstance> Bodies;
	public /*const export editinline */array</*export editinline */RB_ConstraintInstance> Constraints;
	public /*native const */Object.Map_Mirror CollisionDisableTable;
	public /*const */float LinearSpringScale;
	public /*const */float LinearDampingScale;
	public /*const */float LinearForceLimitScale;
	public /*const */float AngularSpringScale;
	public /*const */float AngularDampingScale;
	public /*const */float AngularForceLimitScale;
	
	// Export UPhysicsAssetInstance::execSetLinearDriveScale(FFrame&, void* const)
	public virtual /*native final function */void SetLinearDriveScale(float InLinearSpringScale, float InLinearDampingScale, float InLinearForceLimitScale)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetAngularDriveScale(FFrame&, void* const)
	public virtual /*native final function */void SetAngularDriveScale(float InAngularSpringScale, float InAngularDampingScale, float InAngularForceLimitScale)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetAllMotorsAngularDriveStrength(FFrame&, void* const)
	public virtual /*native final function */void SetAllMotorsAngularDriveStrength(float InAngularSpringStrength, float InAngularDampingStrength, float InAngularForceLimitStrength, SkeletalMeshComponent SkelMeshComp)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execGetTotalMassBelowBone(FFrame&, void* const)
	public virtual /*native final function */float GetTotalMassBelowBone(name InBoneName, PhysicsAsset InAsset, SkeletalMesh InSkelMesh)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UPhysicsAssetInstance::execSetAllBodiesFixed(FFrame&, void* const)
	public virtual /*native final function */void SetAllBodiesFixed(bool bNewFixed)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetNamedBodiesFixed(FFrame&, void* const)
	public virtual /*native final function */void SetNamedBodiesFixed(bool bNewFixed, array<name> BoneNames, SkeletalMeshComponent SkelMesh, /*optional */bool? _bSetOtherBodiesToComplement = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetAllMotorsAngularPositionDrive(FFrame&, void* const)
	public virtual /*native final function */void SetAllMotorsAngularPositionDrive(bool bEnableSwingDrive, bool bEnableTwistDrive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetNamedMotorsAngularPositionDrive(FFrame&, void* const)
	public virtual /*native final function */void SetNamedMotorsAngularPositionDrive(bool bEnableSwingDrive, bool bEnableTwistDrive, array<name> BoneNames, SkeletalMeshComponent SkelMeshComp, /*optional */bool? _bSetOtherBodiesToComplement = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetAllMotorsAngularDriveParams(FFrame&, void* const)
	public virtual /*native final function */void SetAllMotorsAngularDriveParams(float InSpring, float InDamping, float InForceLimit)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetNamedRBBoneSprings(FFrame&, void* const)
	public virtual /*native final function */void SetNamedRBBoneSprings(bool bEnable, array<name> BoneNames, float InBoneLinearSpring, float InBoneAngularSpring, SkeletalMeshComponent SkelMeshComp)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetNamedBodiesBlockRigidBody(FFrame&, void* const)
	public virtual /*native final function */void SetNamedBodiesBlockRigidBody(bool bNewBlockRigidBody, array<name> BoneNames, SkeletalMeshComponent SkelMesh)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execSetFullAnimWeightBonesFixed(FFrame&, void* const)
	public virtual /*native final function */void SetFullAnimWeightBonesFixed(bool bNewFixed, SkeletalMeshComponent SkelMesh)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UPhysicsAssetInstance::execFindBodyInstance(FFrame&, void* const)
	public virtual /*native final function */RB_BodyInstance FindBodyInstance(name BodyName, PhysicsAsset InAsset)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UPhysicsAssetInstance::execFindConstraintInstance(FFrame&, void* const)
	public virtual /*native final function */RB_ConstraintInstance FindConstraintInstance(name ConName, PhysicsAsset InAsset)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public PhysicsAssetInstance()
	{
		// Object Offset:0x0039C2DF
		LinearSpringScale = 1.0f;
		LinearDampingScale = 1.0f;
		LinearForceLimitScale = 1.0f;
		AngularSpringScale = 1.0f;
		AngularDampingScale = 1.0f;
		AngularForceLimitScale = 1.0f;
	}
}
}