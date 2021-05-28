namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitVictoryMessage : TdVictoryMessage{
	public /*const localized */string RoundWon;
	public /*const localized */string MathcWon;
	public /*const localized */string CopWonRoundReason;
	public /*const localized */string RunnerWonRoundReason;
	public /*const localized */string DrawRoundReason;
	
	public /*function */static string GetMacthVictoryMessage(/*optional */PlayerReplicationInfo Winner = default)
	{
	
		return default;
	}
	
	public /*function */static string GetRoundVictoryMessage(/*optional */PlayerReplicationInfo Winner = default)
	{
	
		return default;
	}
	
	public /*function */static string GetRoundVictoryReason(/*optional */PlayerReplicationInfo Winner = default)
	{
	
		return default;
	}
	
}
}