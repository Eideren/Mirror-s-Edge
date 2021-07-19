namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintInstance : Object/*
		native
		hidecategories(Object)*/{
	[Const, transient] public Actor Owner;
	[Const, export, editinline, transient] public PrimitiveComponent OwnerComponent;
	[Const] public int ConstraintIndex;
	[native, Const] public int SceneIndex;
	[native, Const] public bool bInHardware;
	[Category("Linear")] [Const] public bool bLinearXPositionDrive;
	[Category("Linear")] [Const] public bool bLinearXVelocityDrive;
	[Category("Linear")] [Const] public bool bLinearYPositionDrive;
	[Category("Linear")] [Const] public bool bLinearYVelocityDrive;
	[Category("Linear")] [Const] public bool bLinearZPositionDrive;
	[Category("Linear")] [Const] public bool bLinearZVelocityDrive;
	[Category("Angular")] [Const] public bool bSwingPositionDrive;
	[Category("Angular")] [Const] public bool bSwingVelocityDrive;
	[Category("Angular")] [Const] public bool bTwistPositionDrive;
	[Category("Angular")] [Const] public bool bTwistVelocityDrive;
	[Category("Angular")] [Const] public bool bAngularSlerpDrive;
	public bool bTerminated;
	[native, Const] public Object.Pointer ConstraintData;
	[Category("Linear")] [Const] public Object.Vector LinearPositionTarget;
	[Category("Linear")] [Const] public Object.Vector LinearVelocityTarget;
	[Category("Linear")] [Const] public float LinearDriveSpring;
	[Category("Linear")] [Const] public float LinearDriveDamping;
	[Category("Linear")] [Const] public float LinearDriveForceLimit;
	[Category("Angular")] [Const] public Object.Quat AngularPositionTarget;
	[Category("Angular")] [Const] public Object.Vector AngularVelocityTarget;
	[Category("Angular")] [Const] public float AngularDriveSpring;
	[Category("Angular")] [Const] public float AngularDriveDamping;
	[Category("Angular")] [Const] public float AngularDriveForceLimit;
	[native, Const] public/*private*/ Object.Pointer DummyKinActor;
	
	// Export URB_ConstraintInstance::execInitConstraint(FFrame&, void* const)
	public virtual /*native final function */void InitConstraint(PrimitiveComponent PrimComp1, PrimitiveComponent PrimComp2, RB_ConstraintSetup Setup, float Scale, Actor inOwner, PrimitiveComponent InPrimComp, bool bMakeKinForBody1)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execTermConstraint(FFrame&, void* const)
	public virtual /*native final function */void TermConstraint()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execGetConstraintLocation(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetConstraintLocation()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export URB_ConstraintInstance::execSetLinearPositionDrive(FFrame&, void* const)
	public virtual /*native final function */void SetLinearPositionDrive(bool bEnableXDrive, bool bEnableYDrive, bool bEnableZDrive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearVelocityDrive(FFrame&, void* const)
	public virtual /*native final function */void SetLinearVelocityDrive(bool bEnableXDrive, bool bEnableYDrive, bool bEnableZDrive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularPositionDrive(FFrame&, void* const)
	public virtual /*native final function */void SetAngularPositionDrive(bool bEnableSwingDrive, bool bEnableTwistDrive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularVelocityDrive(FFrame&, void* const)
	public virtual /*native final function */void SetAngularVelocityDrive(bool bEnableSwingDrive, bool bEnableTwistDrive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearPositionTarget(FFrame&, void* const)
	public virtual /*native final function */void SetLinearPositionTarget(Object.Vector InPosTarget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearVelocityTarget(FFrame&, void* const)
	public virtual /*native final function */void SetLinearVelocityTarget(Object.Vector InVelTarget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearDriveParams(FFrame&, void* const)
	public virtual /*native final function */void SetLinearDriveParams(float InSpring, float InDamping, float InForceLimit)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularPositionTarget(FFrame&, void* const)
	public virtual /*native final function */void SetAngularPositionTarget(Object.Quat InPosTarget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularVelocityTarget(FFrame&, void* const)
	public virtual /*native final function */void SetAngularVelocityTarget(Object.Vector InVelTarget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularDriveParams(FFrame&, void* const)
	public virtual /*native final function */void SetAngularDriveParams(float InSpring, float InDamping, float InForceLimit)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetAngularDOFLimitScale(FFrame&, void* const)
	public virtual /*native final function */void SetAngularDOFLimitScale(float InSwing1LimitScale, float InSwing2LimitScale, float InTwistLimitScale, RB_ConstraintSetup InSetup)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execSetLinearLimitSize(FFrame&, void* const)
	public virtual /*native final function */void SetLinearLimitSize(float NewLimitSize)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintInstance::execMoveKinActorTransform(FFrame&, void* const)
	public virtual /*native final function */void MoveKinActorTransform(ref Object.Matrix NewTM)
	{
		NativeMarkers.MarkUnimplemented();
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