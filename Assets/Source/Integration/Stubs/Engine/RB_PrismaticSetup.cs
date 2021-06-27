namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_PrismaticSetup : RB_ConstraintSetup/*
		native
		hidecategories(Object)*/{
	public RB_PrismaticSetup()
	{
		// Object Offset:0x003AE729
		bSwingLimited = true;
		bTwistLimited = true;
		LinearXSetup = new RB_ConstraintSetup.LinearDOFSetup
		{
			bLimited = 0,
		};
	}
}
}