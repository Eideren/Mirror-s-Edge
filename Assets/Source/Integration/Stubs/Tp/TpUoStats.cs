namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoStats : TpSystemHandler, 
		OnlineStatsInterface/*
		transient*/{
	public/*private*/ array< /*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete > __OnReadOnlineStatsComplete__Multicaster;
	public/*private*/ array< /*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete > __OnFlushOnlineStatsComplete__Multicaster;
	public /*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete __OnReadOnlineStatsComplete__Delegate{ get; set; }
	public /*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete __OnFlushOnlineStatsComplete__Delegate{ get; set; }
	public /*delegate*/OnlineStatsInterface.OnRegisterHostStatGuidComplete __OnRegisterHostStatGuidComplete__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	public virtual /*function */bool ReadOnlineStats(/*const */ref array<OnlineSubsystem.UniqueNetId> Players, OnlineStatsRead StatsRead)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ReadOnlineStatsForFriends(byte LocalUserNum, OnlineStatsRead StatsRead)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ReadOnlineStatsByRank(OnlineStatsRead StatsRead, /*optional */int? _StartIndex = default, /*optional */int? _NumToRead = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ReadOnlineStatsByRankAroundPlayer(byte LocalUserNum, OnlineStatsRead StatsRead, /*optional */int? _NumRows = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddReadOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete ReadOnlineStatsCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearReadOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete ReadOnlineStatsCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void Del_OnReadOnlineStatsComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnReadOnlineStatsComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnReadOnlineStatsComplete_Add(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnReadOnlineStatsComplete_Remove(/*delegate*/OnlineStatsInterface.OnReadOnlineStatsComplete D)
	{
		// stub
	}
	
	public virtual /*function */void FreeStats(OnlineStatsRead StatsRead)
	{
		// stub
	}
	
	public virtual /*function */bool WriteOnlineStats(OnlineSubsystem.UniqueNetId Player, OnlineStatsWrite StatsWrite)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool FlushOnlineStats()
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnFlushOnlineStatsComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnFlushOnlineStatsComplete_Add(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnFlushOnlineStatsComplete_Remove(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddFlushOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete FlushOnlineStatsCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearFlushOnlineStatsCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete FlushOnlineStatsCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void Del_OnFlushOnlineStatsComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */bool WriteOnlinePlayerScores(/*const */ref array<OnlineSubsystem.OnlinePlayerScore> PlayerScores)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String GetHostStatGuid()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool RegisterHostStatGuid(/*const */ref String HostStatGuid)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddRegisterHostStatGuidCompleteDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete RegisterHostStatGuidCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearRegisterHostStatGuidCompleteDelegateDelegate(/*delegate*/OnlineStatsInterface.OnFlushOnlineStatsComplete RegisterHostStatGuidCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */String GetClientStatGuid()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool RegisterStatGuid(OnlineSubsystem.UniqueNetId PlayerId, /*const */ref String ClientStatGuid)
	{
		// stub
		return default;
	}
	
}
}