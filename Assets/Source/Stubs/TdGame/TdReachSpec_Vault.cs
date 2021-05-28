namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdReachSpec_Vault : TdMoveReachSpec/*
		native
		config(PathfindingCosts)*/{
	public/*()*/ bool bVaultOnto;
	public/*()*/ bool bHighVault;
	public/*()*/ Object.Vector HandPlantLocation;
	public/*()*/ Object.Vector LandingLocation;
	
	// Export UTdReachSpec_Vault::execGetDefaultCostFor(FFrame&, void* const)
	public override /*native function */int GetDefaultCostFor(TdBotPawn P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}