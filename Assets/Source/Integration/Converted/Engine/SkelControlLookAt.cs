namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlLookAt : SkelControlBase/*
		native
		hidecategories(Object)*/{
	[Category("LookAt")] public Object.Vector TargetLocation;
	[Category("LookAt")] public SkelControlBase.EBoneControlSpace TargetLocationSpace;
	[Category("LookAt")] public Object.EAxis LookAtAxis;
	[Category("LookAt")] public Object.EAxis UpAxis;
	[Category("Limit")] public SkelControlBase.EBoneControlSpace AllowRotationSpace;
	[Category("LookAt")] public name TargetSpaceBoneName;
	[Category("LookAt")] public bool bInvertLookAtAxis;
	[Category("LookAt")] public bool bDefineUpAxis;
	[Category("LookAt")] public bool bInvertUpAxis;
	[Category("Limit")] public bool bEnableLimit;
	[Category("Limit")] public bool bLimitBasedOnRefPose;
	[Category("Limit")] public bool bDisableBeyondLimit;
	[Category("Limit")] public bool bNotifyBeyondLimit;
	[Category("Limit")] public bool bShowLimit;
	[Category("Limit")] public bool bAllowRotationX;
	[Category("Limit")] public bool bAllowRotationY;
	[Category("Limit")] public bool bAllowRotationZ;
	[Category("LookAt")] public float TargetLocationInterpSpeed;
	public Object.Vector DesiredTargetLocation;
	[Category("Limit")] public float MaxAngle;
	[Category("Limit")] public float DeadZoneAngle;
	[Category("Limit")] public name AllowRotationOtherBoneName;
	[Const, transient] public float LookAtAlpha;
	[Const, transient] public float LookAtAlphaTarget;
	[Const, transient] public float LookAtAlphaBlendTimeToGo;
	[Const, transient] public Object.Vector LimitLookDir;
	[Const, transient] public Object.Vector BaseLookDir;
	[Const, transient] public Object.Vector BaseBonePos;
	[Const, transient] public float LastCalcTime;
	
	public virtual /*function */void SetTargetLocation(Object.Vector NewTargetLocation)
	{
		DesiredTargetLocation = NewTargetLocation;
		if((ControlStrength * LookAtAlpha) < 0.000010f)
		{
			TargetLocation = NewTargetLocation;
		}
	}
	
	public virtual /*simulated function */void InterpolateTargetLocation(float DeltaTime)
	{
		TargetLocation = VInterpTo(TargetLocation, DesiredTargetLocation, DeltaTime, TargetLocationInterpSpeed);
	}
	
	// Export USkelControlLookAt::execSetLookAtAlpha(FFrame&, void* const)
	public virtual /*native final function */void SetLookAtAlpha(float DesiredAlpha, float DesiredBlendTime)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkelControlLookAt::execCanLookAtPoint(FFrame&, void* const)
	public virtual /*native final function */bool CanLookAtPoint(Object.Vector PointLoc, /*optional */bool? _bDrawDebugInfo = default, /*optional */bool? _bDebugUsePersistentLines = default, /*optional */bool? _bDebugFlushLinesFirst = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public SkelControlLookAt()
	{
		// Object Offset:0x003E3338
		LookAtAxis = Object.EAxis.AXIS_X;
		UpAxis = Object.EAxis.AXIS_Z;
		AllowRotationSpace = SkelControlBase.EBoneControlSpace.BCS_BoneSpace;
		bLimitBasedOnRefPose = true;
		bShowLimit = true;
		bAllowRotationX = true;
		bAllowRotationY = true;
		bAllowRotationZ = true;
		TargetLocationInterpSpeed = 10.0f;
		LookAtAlpha = 1.0f;
		LookAtAlphaTarget = 1.0f;
	}
}
}