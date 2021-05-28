namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MantleReachSpec : ForcedReachSpec/*
		native*/{
	public MantleReachSpec()
	{
		// Object Offset:0x003557D3
		bSkipPrune = true;
		ForcedPathSizeName = (name)"Common";
	}
}
}