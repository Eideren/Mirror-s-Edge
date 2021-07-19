namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintSetup : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */LinearDOFSetup
	{
		[Category] public byte bLimited;
		[Category] public float LimitSize;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003ACA6A
	//		bLimited = 1;
	//		LimitSize = 0.0f;
	//	}
	};
	
	[Category] [Const] public name JointName;
	[Category] public name ConstraintBone1;
	[Category] public name ConstraintBone2;
	public Object.Vector Pos1;
	public Object.Vector PriAxis1;
	public Object.Vector SecAxis1;
	public Object.Vector Pos2;
	public Object.Vector PriAxis2;
	public Object.Vector SecAxis2;
	public Object.Vector PulleyPivot1;
	public Object.Vector PulleyPivot2;
	[Category] public bool bEnableProjection;
	[Category("Linear")] public bool bLinearLimitSoft;
	[Category("Linear")] public bool bLinearBreakable;
	[Category("Angular")] public bool bSwingLimited;
	[Category("Angular")] public bool bTwistLimited;
	[Category("Angular")] public bool bSwingLimitSoft;
	[Category("Angular")] public bool bTwistLimitSoft;
	[Category("Angular")] public bool bAngularBreakable;
	[Category("Pulley")] public bool bIsPulley;
	[Category("Pulley")] public bool bMaintainMinDistance;
	[Category("Linear")] public RB_ConstraintSetup.LinearDOFSetup LinearXSetup;
	[Category("Linear")] public RB_ConstraintSetup.LinearDOFSetup LinearYSetup;
	[Category("Linear")] public RB_ConstraintSetup.LinearDOFSetup LinearZSetup;
	[Category("Linear")] public float LinearLimitStiffness;
	[Category("Linear")] public float LinearLimitDamping;
	[Category("Linear")] public float LinearBreakThreshold;
	[Category("Angular")] public float Swing1LimitAngle;
	[Category("Angular")] public float Swing2LimitAngle;
	[Category("Angular")] public float TwistLimitAngle;
	[Category("Angular")] public float SwingLimitStiffness;
	[Category("Angular")] public float SwingLimitDamping;
	[Category("Angular")] public float TwistLimitStiffness;
	[Category("Angular")] public float TwistLimitDamping;
	[Category("Angular")] public float AngularBreakThreshold;
	[Category("Pulley")] public float PulleyRatio;
	
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