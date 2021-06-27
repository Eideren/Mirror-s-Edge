namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintSetup : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */LinearDOFSetup
	{
		public/*()*/ byte bLimited;
		public/*()*/ float LimitSize;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003ACA6A
	//		bLimited = 1;
	//		LimitSize = 0.0f;
	//	}
	};
	
	public/*()*/ /*const */name JointName;
	public/*()*/ name ConstraintBone1;
	public/*()*/ name ConstraintBone2;
	public Object.Vector Pos1;
	public Object.Vector PriAxis1;
	public Object.Vector SecAxis1;
	public Object.Vector Pos2;
	public Object.Vector PriAxis2;
	public Object.Vector SecAxis2;
	public Object.Vector PulleyPivot1;
	public Object.Vector PulleyPivot2;
	public/*()*/ bool bEnableProjection;
	public/*(Linear)*/ bool bLinearLimitSoft;
	public/*(Linear)*/ bool bLinearBreakable;
	public/*(Angular)*/ bool bSwingLimited;
	public/*(Angular)*/ bool bTwistLimited;
	public/*(Angular)*/ bool bSwingLimitSoft;
	public/*(Angular)*/ bool bTwistLimitSoft;
	public/*(Angular)*/ bool bAngularBreakable;
	public/*(Pulley)*/ bool bIsPulley;
	public/*(Pulley)*/ bool bMaintainMinDistance;
	public/*(Linear)*/ RB_ConstraintSetup.LinearDOFSetup LinearXSetup;
	public/*(Linear)*/ RB_ConstraintSetup.LinearDOFSetup LinearYSetup;
	public/*(Linear)*/ RB_ConstraintSetup.LinearDOFSetup LinearZSetup;
	public/*(Linear)*/ float LinearLimitStiffness;
	public/*(Linear)*/ float LinearLimitDamping;
	public/*(Linear)*/ float LinearBreakThreshold;
	public/*(Angular)*/ float Swing1LimitAngle;
	public/*(Angular)*/ float Swing2LimitAngle;
	public/*(Angular)*/ float TwistLimitAngle;
	public/*(Angular)*/ float SwingLimitStiffness;
	public/*(Angular)*/ float SwingLimitDamping;
	public/*(Angular)*/ float TwistLimitStiffness;
	public/*(Angular)*/ float TwistLimitDamping;
	public/*(Angular)*/ float AngularBreakThreshold;
	public/*(Pulley)*/ float PulleyRatio;
	
	public RB_ConstraintSetup()
	{
		// Object Offset:0x003ACAD7
		PriAxis1 = new Vector
		{
			X=1.0f,
			Y=0.0f,
			Z=0.0f
		};
		SecAxis1 = new Vector
		{
			X=0.0f,
			Y=1.0f,
			Z=0.0f
		};
		PriAxis2 = new Vector
		{
			X=1.0f,
			Y=0.0f,
			Z=0.0f
		};
		SecAxis2 = new Vector
		{
			X=0.0f,
			Y=1.0f,
			Z=0.0f
		};
		LinearXSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 1,
			LimitSize = 0.0f,
		};
		LinearYSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 1,
			LimitSize = 0.0f,
		};
		LinearZSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 1,
			LimitSize = 0.0f,
		};
		LinearBreakThreshold = 300.0f;
		AngularBreakThreshold = 500.0f;
		PulleyRatio = 1.0f;
	}
}
}