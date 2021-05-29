namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlLookAt : SkelControlBase/*
		native
		hidecategories(Object)*/{
	public/*(LookAt)*/ Object.Vector TargetLocation;
	public/*(LookAt)*/ SkelControlBase.EBoneControlSpace TargetLocationSpace;
	public/*(LookAt)*/ Object.EAxis LookAtAxis;
	public/*(LookAt)*/ Object.EAxis UpAxis;
	public/*(Limit)*/ SkelControlBase.EBoneControlSpace AllowRotationSpace;
	public/*(LookAt)*/ name TargetSpaceBoneName;
	public/*(LookAt)*/ bool bInvertLookAtAxis;
	public/*(LookAt)*/ bool bDefineUpAxis;
	public/*(LookAt)*/ bool bInvertUpAxis;
	public/*(Limit)*/ bool bEnableLimit;
	public/*(Limit)*/ bool bLimitBasedOnRefPose;
	public/*(Limit)*/ bool bDisableBeyondLimit;
	public/*(Limit)*/ bool bNotifyBeyondLimit;
	public/*(Limit)*/ bool bShowLimit;
	public/*(Limit)*/ bool bAllowRotationX;
	public/*(Limit)*/ bool bAllowRotationY;
	public/*(Limit)*/ bool bAllowRotationZ;
	public/*(LookAt)*/ float TargetLocationInterpSpeed;
	public Object.Vector DesiredTargetLocation;
	public/*(Limit)*/ float MaxAngle;
	public/*(Limit)*/ float DeadZoneAngle;
	public/*(Limit)*/ name AllowRotationOtherBoneName;
	public /*const transient */float LookAtAlpha;
	public /*const transient */float LookAtAlphaTarget;
	public /*const transient */float LookAtAlphaBlendTimeToGo;
	public /*const transient */Object.Vector LimitLookDir;
	public /*const transient */Object.Vector BaseLookDir;
	public /*const transient */Object.Vector BaseBonePos;
	public /*const transient */float LastCalcTime;
	
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
		#warning NATIVE FUNCTION !
	}
	
	// Export USkelControlLookAt::execCanLookAtPoint(FFrame&, void* const)
	public virtual /*native final function */bool CanLookAtPoint(Object.Vector PointLoc, /*optional */bool? _bDrawDebugInfo = default, /*optional */bool? _bDebugUsePersistentLines = default, /*optional */bool? _bDebugFlushLinesFirst = default)
	{
		#warning NATIVE FUNCTION !
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