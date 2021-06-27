namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SwatTurnReachSpec : ForcedReachSpec/*
		native*/{
	public/*()*/ /*editconst */byte SpecDirection;
	
	public SwatTurnReachSpec()
	{
		// Object Offset:0x003F73AB
		PruneSpecList = new array< Core.ClassT<ReachSpec> >
		{
			ClassT<ReachSpec>(),
		};
		ForcedPathSizeName = (name)"Common";
	}
}
}