namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineStatsWrite : OnlineStats/*
		abstract
		native*/{
	public /*const */array<Settings.StringIdToStringMapping> StatMappings;
	public /*const */array<Settings.SettingsProperty> Properties;
	public /*const */array<int> ViewIds;
	public /*const */array<int> ArbitratedViewIds;
	public /*const */int RatingId;
	public OnlineStats.StatPeriodFlags PeriodFlags;
	public /*delegate*/OnlineStatsWrite.OnStatsWriteComplete __OnStatsWriteComplete__Delegate;
	
	public delegate void OnStatsWriteComplete();
	
	// Export UOnlineStatsWrite::execGetStatId(FFrame&, void* const)
	public virtual /*native function */bool GetStatId(name StatName, ref int StatId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UOnlineStatsWrite::execGetStatName(FFrame&, void* const)
	public virtual /*native function */name GetStatName(int StatId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UOnlineStatsWrite::execSetFloatStat(FFrame&, void* const)
	public virtual /*native function */void SetFloatStat(int StatId, float Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UOnlineStatsWrite::execSetIntStat(FFrame&, void* const)
	public virtual /*native function */void SetIntStat(int StatId, int Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UOnlineStatsWrite::execIncrementFloatStat(FFrame&, void* const)
	public virtual /*native function */void IncrementFloatStat(int StatId, /*optional */float IncBy = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UOnlineStatsWrite::execIncrementIntStat(FFrame&, void* const)
	public virtual /*native function */void IncrementIntStat(int StatId, /*optional */int IncBy = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UOnlineStatsWrite::execDecrementFloatStat(FFrame&, void* const)
	public virtual /*native function */void DecrementFloatStat(int StatId, /*optional */float DecBy = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UOnlineStatsWrite::execDecrementIntStat(FFrame&, void* const)
	public virtual /*native function */void DecrementIntStat(int StatId, /*optional */int DecBy = default)
	{
		#warning NATIVE FUNCTION !
	}
	
}
}