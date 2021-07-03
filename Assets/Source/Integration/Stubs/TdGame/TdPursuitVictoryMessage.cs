namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitVictoryMessage : TdVictoryMessage{
	public /*const localized */String RoundWon;
	public /*const localized */String MathcWon;
	public /*const localized */String CopWonRoundReason;
	public /*const localized */String RunnerWonRoundReason;
	public /*const localized */String DrawRoundReason;
	
	public /*function */static String GetMacthVictoryMessage(/*optional */PlayerReplicationInfo _Winner = default)
	{
		// stub
		return default;
	}
	
	public /*function */static String GetRoundVictoryMessage(/*optional */PlayerReplicationInfo _Winner = default)
	{
		// stub
		return default;
	}
	
	public /*function */static String GetRoundVictoryReason(/*optional */PlayerReplicationInfo _Winner = default)
	{
		// stub
		return default;
	}
	
}
}