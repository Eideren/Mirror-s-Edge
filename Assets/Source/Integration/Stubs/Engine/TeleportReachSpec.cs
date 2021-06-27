namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TeleportReachSpec : ReachSpec/*
		native*/{
	public TeleportReachSpec()
	{
		// Object Offset:0x003FA591
		Distance = 100;
		bAddToNavigationOctree = false;
		bCheckForObstructions = false;
	}
}
}