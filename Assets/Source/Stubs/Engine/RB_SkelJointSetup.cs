namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_SkelJointSetup : RB_ConstraintSetup/*
		native
		hidecategories(Object)*/{
	public RB_SkelJointSetup()
	{
		// Object Offset:0x003AF7CC
		bSwingLimited = true;
		bTwistLimited = true;
		Swing1LimitAngle = 45.0f;
		Swing2LimitAngle = 45.0f;
		TwistLimitAngle = 15.0f;
	}
}
}