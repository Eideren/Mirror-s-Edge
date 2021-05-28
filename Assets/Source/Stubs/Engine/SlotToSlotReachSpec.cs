namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SlotToSlotReachSpec : ForcedReachSpec/*
		native*/{
	public/*()*/ /*editconst */byte SpecDirection;
	
	public SlotToSlotReachSpec()
	{
		// Object Offset:0x003E87C9
		PruneSpecList = new array< Core.ClassT<ReachSpec> >
		{
			ClassT<ReachSpec>(),
		};
		ForcedPathSizeName = (name)"Common";
	}
}
}