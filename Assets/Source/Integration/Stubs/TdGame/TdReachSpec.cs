namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdReachSpec : ReachSpec/*
		native
		config(PathfindingCosts)*/{
	[config] public float ExposureWeight;
	[config] public float CanSeeWeight;
	[config] public float ExposureDistanceLimit;
	[config] public bool bSquaredExposureDistance;
	[Category] public bool bIsSkippable;
	[config] public float UsageCost;
	[config] public int WalkToNodeCost;
	[config] public int CostFor90DegTurn;
	[config] public int CostForHeightDiff;
	[config] public int CostForJumpSpecs;
	[config] public int CostForDirectionSwitch;
	[Category] public int FlagsHack;
	[Category] [editconst] public float DropOffDistance;
	[Category] [editconst] public float NeededSpeed;
	
	// Export UTdReachSpec::execGetCostFor(FFrame&, void* const)
	public virtual /*native function */int GetCostFor(Pawn P)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdReachSpec::execGetDefaultCostFor(FFrame&, void* const)
	public virtual /*native function */int GetDefaultCostFor(TdBotPawn P)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdReachSpec::execAdjustedCostFor(FFrame&, void* const)
	public virtual /*native function */int AdjustedCostFor(Pawn P, NavigationPoint Anchor, NavigationPoint Goal, int Cost)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TdReachSpec()
	{
		// Object Offset:0x00545F66
		ExposureWeight = 1.0f;
		CanSeeWeight = 3.0f;
		ExposureDistanceLimit = 3000.0f;
		bSquaredExposureDistance = true;
		bIsSkippable = true;
		UsageCost = 4.0f;
		WalkToNodeCost = 1200;
		CostFor90DegTurn = 400;
		CostForHeightDiff = 2000;
		CostForJumpSpecs = 1000;
		CostForDirectionSwitch = 4500;
	}
}
}