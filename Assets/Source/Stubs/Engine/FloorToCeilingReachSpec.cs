namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FloorToCeilingReachSpec : ForcedReachSpec/*
		native*/{
	public FloorToCeilingReachSpec()
	{
		// Object Offset:0x0031D813
		bSkipPrune = true;
		ForcedPathSizeName = (name)"Common";
	}
}
}