namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintInstance : Object/*
		native
		hidecategories(Object)*/{
	public /*const transient */Actor Owner;
	public /*const export editinline transient */PrimitiveComponent OwnerComponent;
	public /*const */int ConstraintIndex;
	public /*native const */int SceneIndex;
	public /*native const */bool bInHardware;
	public/*(Linear)*/ /*const */bool bLinearXPositionDrive;
	public/*(Linear)*/ /*const */bool bLinearXVelocityDrive;
	public/*(Linear)*/ /*const */bool bLinearYPositionDrive;
	public/*(Linear)*/ /*const */bool bLinearYVelocityDrive;
	public/*(Linear)*/ /*const */bool bLinearZPositionDrive;
	public/*(Linear)*/ /*const */bool bLinearZVelocityDrive;
	public/*(Angular)*/ /*const */bool bSwingPositionDrive;
	public/*(Angular)*/ /*const */bool bSwingVelocityDrive;
	public/*(Angular)*/ /*const */bool bTwistPositionDrive;
	public/*(Angular)*/ /*const */bool bTwistVelocityDrive;
	public/*(Angular)*/ /*const */bool bAngularSlerpDrive;
	public bool bTerminated;
	public /*native const */Object.Pointer ConstraintData;
	public/*(Linear)*/ /*const */Object.Vector LinearPositionTarget;
	public/*(Linear)*/ /*const */Object.Vector LinearVelocityTarget;
	public/*(Linear)*/ /*const */float LinearDriveSpring;
	public/*(Linear)*/ /*const */float LinearDriveDamping;
	public/*(Linear)*/ /*const */float LinearDriveForceLimit;
	public/*(Angular)*/ /*const */Object.Quat AngularPositionTarget;
	public/*(Angular)*/ /*const */Object.Vector AngularVelocityTarget;
	public/*(Angular)*/ /*const */float AngularDriveSpring;
	public/*(Angular)*/ /*const */float AngularDriveDamping;
	public/*(Angular)*/ /*const */float AngularDriveForceLimit;
	public /*private native const */Object.Pointer DummyKinActor;
	
	// Export URB_ConstraintInstance::execInitConstraint(FFrame&, void* const)
	public virtual /*native final function */void InitConstraint(PrimitiveComponent PrimComp1, PrimitiveComponent PrimComp2, RB_ConstraintSetup Setup, float Scale, Actor inOwner, PrimitiveComponent InPrimComp, bool bMakeKinForBody1)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execTermConstraint(FFrame&, void* const)
	public virtual /*native final function */void TermConstraint()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execGetConstraintLocation(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetConstraintLocation()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export URB_ConstraintInstance::execSetLinearPositionDrive(FFrame&, void* const)
	public virtual /*native final function */void SetLinearPositionDrive(bool bEnableXDrive, bool bEnableYDrive, bool bEnableZDrive)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearVelocityDrive(FFrame&, void* const)
	public virtual /*native final function */void SetLinearVelocityDrive(bool bEnableXDrive, bool bEnableYDrive, bool bEnableZDrive)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularPositionDrive(FFrame&, void* const)
	public virtual /*native final function */void SetAngularPositionDrive(bool bEnableSwingDrive, bool bEnableTwistDrive)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularVelocityDrive(FFrame&, void* const)
	public virtual /*native final function */void SetAngularVelocityDrive(bool bEnableSwingDrive, bool bEnableTwistDrive)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearPositionTarget(FFrame&, void* const)
	public virtual /*native final function */void SetLinearPositionTarget(Object.Vector InPosTarget)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearVelocityTarget(FFrame&, void* const)
	public virtual /*native final function */void SetLinearVelocityTarget(Object.Vector InVelTarget)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearDriveParams(FFrame&, void* const)
	public virtual /*native final function */void SetLinearDriveParams(float InSpring, float InDamping, float InForceLimit)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularPositionTarget(FFrame&, void* const)
	public virtual /*native final function */void SetAngularPositionTarget(Object.Quat InPosTarget)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularVelocityTarget(FFrame&, void* const)
	public virtual /*native final function */void SetAngularVelocityTarget(Object.Vector InVelTarget)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularDriveParams(FFrame&, void* const)
	public virtual /*native final function */void SetAngularDriveParams(float InSpring, float InDamping, float InForceLimit)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularDOFLimitScale(FFrame&, void* const)
	public virtual /*native final function */void SetAngularDOFLimitScale(float InSwing1LimitScale, float InSwing2LimitScale, float InTwistLimitScale, RB_ConstraintSetup InSetup)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearLimitSize(FFrame&, void* const)
	public virtual /*native final function */void SetLinearLimitSize(float NewLimitSize)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_ConstraintInstance::execMoveKinActorTransform(FFrame&, void* const)
	public virtual /*native final function */void MoveKinActorTransform(ref Object.Matrix NewTM)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public RB_ConstraintInstance()
	{
		// Object Offset:0x003ABB47
		LinearDriveSpring = 50.0f;
		LinearDriveDamping = 1.0f;
		AngularPositionTarget = new Quat
		{
			X=0.0f,
			Y=0.0f,
			Z=0.0f,
			W=1.0f
		};
		AngularDriveSpring = 50.0f;
		AngularDriveDamping = 1.0f;
	}
}
}