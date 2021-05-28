namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdReachSpec : ReachSpec/*
		native
		config(PathfindingCosts)*/{
	public /*config */float ExposureWeight;
	public /*config */float CanSeeWeight;
	public /*config */float ExposureDistanceLimit;
	public /*config */bool bSquaredExposureDistance;
	public/*()*/ bool bIsSkippable;
	public /*config */float UsageCost;
	public /*config */int WalkToNodeCost;
	public /*config */int CostFor90DegTurn;
	public /*config */int CostForHeightDiff;
	public /*config */int CostForJumpSpecs;
	public /*config */int CostForDirectionSwitch;
	public/*()*/ int FlagsHack;
	public/*()*/ /*editconst */float DropOffDistance;
	public/*()*/ /*editconst */float NeededSpeed;
	
	// Export UTdReachSpec::execGetCostFor(FFrame&, void* const)
	public virtual /*native function */int GetCostFor(Pawn P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdReachSpec::execGetDefaultCostFor(FFrame&, void* const)
	public virtual /*native function */int GetDefaultCostFor(TdBotPawn P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdReachSpec::execAdjustedCostFor(FFrame&, void* const)
	public virtual /*native function */int AdjustedCostFor(Pawn P, NavigationPoint Anchor, NavigationPoint Goal, int Cost)
	{
		#warning NATIVE FUNCTION !
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