namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoStats : TpSystemHandler, 
		OnlineStatsInterface/*
		transient*/{
	public /*private */array< /*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete > __OnReadOnlineStatsComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete > __OnFlushOnlineStatsComplete__Multicaster;
	public /*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete __OnReadOnlineStatsComplete__Delegate{ get; set; }
	public /*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete __OnFlushOnlineStatsComplete__Delegate{ get; set; }
	public /*delegate*/OnlineStatsInterface.OnRegisterHostStatGuidComplete __OnRegisterHostStatGuidComplete__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
	
	}
	
	public virtual /*function */bool ReadOnlineStats(/*const */ref array<OnlineSubsystem.UniqueNetId> Players, OnlineStatsRead StatsRead)
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadOnlineStatsForFriends(byte LocalUserNum, OnlineStatsRead StatsRead)
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadOnlineStatsByRank(OnlineStatsRead StatsRead, /*optional */int? _StartIndex = default, /*optional */int? _NumToRead = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadOnlineStatsByRankAroundPlayer(byte LocalUserNum, OnlineStatsRead StatsRead, /*optional */int? _NumRows = default)
	{
	
		return default;
	}
	
	public virtual /*function */void AddReadOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete ReadOnlineStatsCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearReadOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete ReadOnlineStatsCompleteDelegate)
	{
	
	}
	
	public virtual /*private final function */void Del_OnReadOnlineStatsComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadOnlineStatsComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadOnlineStatsComplete_Add(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadOnlineStatsComplete_Remove(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete D)
	{
	
	}
	
	public virtual /*function */void FreeStats(OnlineStatsRead StatsRead)
	{
	
	}
	
	public virtual /*function */bool WriteOnlineStats(OnlineSubsystem.UniqueNetId Player, OnlineStatsWrite StatsWrite)
	{
	
		return default;
	}
	
	public virtual /*function */bool FlushOnlineStats()
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnFlushOnlineStatsComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnFlushOnlineStatsComplete_Add(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnFlushOnlineStatsComplete_Remove(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete D)
	{
	
	}
	
	public virtual /*function */void AddFlushOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete FlushOnlineStatsCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearFlushOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete FlushOnlineStatsCompleteDelegate)
	{
	
	}
	
	public virtual /*private final function */void Del_OnFlushOnlineStatsComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */bool WriteOnlinePlayerScores(/*const */ref array<OnlineSubsystem.OnlinePlayerScore> PlayerScores)
	{
	
		return default;
	}
	
	public virtual /*function */string GetHostStatGuid()
	{
	
		return default;
	}
	
	public virtual /*function */bool RegisterHostStatGuid(/*const */ref string HostStatGuid)
	{
	
		return default;
	}
	
	public virtual /*function */void AddRegisterHostStatGuidCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete RegisterHostStatGuidCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearRegisterHostStatGuidCompleteDelegateDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete RegisterHostStatGuidCompleteDelegate)
	{
	
	}
	
	public virtual /*function */string GetClientStatGuid()
	{
	
		return default;
	}
	
	public virtual /*function */bool RegisterStatGuid(OnlineSubsystem.UniqueNetId PlayerId, /*const */ref string ClientStatGuid)
	{
	
		return default;
	}
	
}
}