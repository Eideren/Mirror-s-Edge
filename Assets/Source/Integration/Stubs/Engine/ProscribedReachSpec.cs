namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ProscribedReachSpec : ReachSpec/*
		native*/{
	public ProscribedReachSpec()
	{
		// Object Offset:0x003A986D
		bAddToNavigationOctree = false;
		bCanCutCorners = false;
	}
}
}