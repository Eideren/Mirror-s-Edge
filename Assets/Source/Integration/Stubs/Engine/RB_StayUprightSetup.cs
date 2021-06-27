namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_StayUprightSetup : RB_ConstraintSetup/*
		native
		hidecategories(Object)*/{
	public RB_StayUprightSetup()
	{
		// Object Offset:0x003AFEF2
		bLinearLimitSoft = true;
		bSwingLimited = true;
		bSwingLimitSoft = true;
		LinearXSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 0,
		};
		LinearYSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 0,
		};
		LinearZSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 0,
		};
	}
}
}