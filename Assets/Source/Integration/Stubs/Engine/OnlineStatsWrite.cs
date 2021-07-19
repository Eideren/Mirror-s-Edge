namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineStatsWrite : OnlineStats/*
		abstract
		native*/{
	[Const] public array<Settings.StringIdToStringMapping> StatMappings;
	[Const] public array<Settings.SettingsProperty> Properties;
	[Const] public array<int> ViewIds;
	[Const] public array<int> ArbitratedViewIds;
	[Const] public int RatingId;
	public OnlineStats.StatPeriodFlags PeriodFlags;
	public /*delegate*/OnlineStatsWrite.OnStatsWriteComplete __OnStatsWriteComplete__Delegate;
	
	public delegate void OnStatsWriteComplete();
	
	// Export UOnlineStatsWrite::execGetStatId(FFrame&, void* const)
	public virtual /*native function */bool GetStatId(name StatName, ref int StatId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineStatsWrite::execGetStatName(FFrame&, void* const)
	public virtual /*native function */name GetStatName(int StatId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineStatsWrite::execSetFloatStat(FFrame&, void* const)
	public virtual /*native function */void SetFloatStat(int StatId, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineStatsWrite::execSetIntStat(FFrame&, void* const)
	public virtual /*native function */void SetIntStat(int StatId, int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineStatsWrite::execIncrementFloatStat(FFrame&, void* const)
	public virtual /*native function */void IncrementFloatStat(int StatId, /*optional */float? _IncBy = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineStatsWrite::execIncrementIntStat(FFrame&, void* const)
	public virtual /*native function */void IncrementIntStat(int StatId, /*optional */int? _IncBy = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineStatsWrite::execDecrementFloatStat(FFrame&, void* const)
	public virtual /*native function */void DecrementFloatStat(int StatId, /*optional */float? _DecBy = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineStatsWrite::execDecrementIntStat(FFrame&, void* const)
	public virtual /*native function */void DecrementIntStat(int StatId, /*optional */int? _DecBy = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}