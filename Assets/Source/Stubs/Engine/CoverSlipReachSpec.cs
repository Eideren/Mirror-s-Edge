namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CoverSlipReachSpec : ForcedReachSpec/*
		native*/{
	public/*()*/ /*editconst */byte SpecDirection;
	
	public CoverSlipReachSpec()
	{
		// Object Offset:0x002ECB62
		bSkipPrune = true;
		ForcedPathSizeName = (name)"Common";
	}
}
}