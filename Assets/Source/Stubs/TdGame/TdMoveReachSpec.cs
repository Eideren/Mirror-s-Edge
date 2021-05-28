namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveReachSpec : TdReachSpec/*
		native
		config(PathfindingCosts)*/{
	public/*()*/ bool NetworkLinker;
	public/*()*/ bool MustJump;
	
	// Export UTdMoveReachSpec::execGetDefaultCostFor(FFrame&, void* const)
	public override /*native function */int GetDefaultCostFor(TdBotPawn P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdMoveReachSpec()
	{
		// Object Offset:0x005F4167
		bIsSkippable = false;
	}
}
}