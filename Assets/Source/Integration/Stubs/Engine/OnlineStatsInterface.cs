namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineStatsInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete __OnReadOnlineStatsComplete__Delegate{ get; }
	public /*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete __OnFlushOnlineStatsComplete__Delegate{ get; }
	public /*delegate*/OnlineStatsInterface.OnRegisterHostStatGuidComplete __OnRegisterHostStatGuidComplete__Delegate{ get; }
	
	public /*function */bool ReadOnlineStats(/*const */ref array<OnlineSubsystem.UniqueNetId> Players, OnlineStatsRead StatsRead);
	
	public /*function */bool ReadOnlineStatsForFriends(byte LocalUserNum, OnlineStatsRead StatsRead);
	
	public /*function */bool ReadOnlineStatsByRank(OnlineStatsRead StatsRead, /*optional */int? _StartIndex = default, /*optional */int? _NumToRead = default);
	
	public /*function */bool ReadOnlineStatsByRankAroundPlayer(byte LocalUserNum, OnlineStatsRead StatsRead, /*optional */int? _NumRows = default);
	
	public /*function */void AddReadOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete ReadOnlineStatsCompleteDelegate);
	
	public /*function */void ClearReadOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete ReadOnlineStatsCompleteDelegate);
	
	public delegate void OnReadOnlineStatsComplete(bool bWasSuccessful);
	
	public /*function */void FreeStats(OnlineStatsRead StatsRead);
	
	public /*function */bool WriteOnlineStats(OnlineSubsystem.UniqueNetId Player, OnlineStatsWrite StatsWrite);
	
	public /*function */bool FlushOnlineStats();
	
	public delegate void OnFlushOnlineStatsComplete(bool bWasSuccessful);
	
	public /*function */void AddFlushOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete FlushOnlineStatsCompleteDelegate);
	
	public /*function */void ClearFlushOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete FlushOnlineStatsCompleteDelegate);
	
	public /*function */bool WriteOnlinePlayerScores(/*const */ref array<OnlineSubsystem.OnlinePlayerScore> PlayerScores);
	
	public /*function */String GetHostStatGuid();
	
	public /*function */bool RegisterHostStatGuid(/*const */ref String HostStatGuid);
	
	public delegate void OnRegisterHostStatGuidComplete(bool bWasSuccessful);
	
	public /*function */void AddRegisterHostStatGuidCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete RegisterHostStatGuidCompleteDelegate);
	
	public /*function */void ClearRegisterHostStatGuidCompleteDelegateDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete RegisterHostStatGuidCompleteDelegate);
	
	public /*function */String GetClientStatGuid();
	
	public /*function */bool RegisterStatGuid(OnlineSubsystem.UniqueNetId PlayerId, /*const */ref String ClientStatGuid);
	
}
}