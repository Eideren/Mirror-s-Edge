namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_HingeSetup : RB_ConstraintSetup/*
		native
		hidecategories(Object)*/{
	public RB_HingeSetup()
	{
		// Object Offset:0x003AE12C
		bSwingLimited = true;
		TwistLimitAngle = 45.0f;
	}
}
}