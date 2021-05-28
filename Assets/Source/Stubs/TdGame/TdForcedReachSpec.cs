namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdForcedReachSpec : TdReachSpec/*
		native
		config(PathfindingCosts)*/{
	public TdForcedReachSpec()
	{
		// Object Offset:0x0054612D
		ForcedPathSizeName = (name)"Max";
	}
}
}