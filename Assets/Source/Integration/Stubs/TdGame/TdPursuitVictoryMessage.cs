namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitVictoryMessage : TdVictoryMessage{
	[Const, localized] public String RoundWon;
	[Const, localized] public String MathcWon;
	[Const, localized] public String CopWonRoundReason;
	[Const, localized] public String RunnerWonRoundReason;
	[Const, localized] public String DrawRoundReason;
	
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