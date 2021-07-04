namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_OnlineStats : UIDataStore_Remote, 
		UIListElementProvider,UIListElementCellProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public enum EStatsFetchType 
	{
		SFT_Player,
		SFT_CenteredOnPlayer,
		SFT_Friends,
		SFT_TopRankings,
		SFT_MAX
	};
	
	public partial struct /*native */PlayerNickMetaData
	{
		public /*const */name PlayerNickName;
		public /*const localized */String PlayerNickColumnName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0042B969
	//		PlayerNickName = (name)"None";
	//		PlayerNickColumnName = "";
	//	}
	};
	
	public partial struct /*native */RankMetaData
	{
		public /*const */name RankName;
		public /*const localized */String RankColumnName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0042BA35
	//		RankName = (name)"None";
	//		RankColumnName = "";
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementProvider;
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public array< Core.ClassT<OnlineStatsRead> > StatsReadClasses;
	public /*const */name StatsReadName;
	public /*const */UIDataStore_OnlineStats.PlayerNickMetaData PlayerNickData;
	public /*const */UIDataStore_OnlineStats.RankMetaData RankNameMetaData;
	public /*const */name TotalRowsName;
	public array<OnlineStatsRead> StatsReadObjects;
	public OnlineStatsRead StatsRead;
	public UIDataStore_OnlineStats.EStatsFetchType CurrentReadType;
	public OnlineStatsInterface StatsInterface;
	public OnlinePlayerInterface PlayerInterface;
	
	public virtual /*event */void Init()
	{
		// stub
	}
	
	public virtual /*function */void SetStatsReadInfo()
	{
		// stub
	}
	
	public virtual /*event */bool RefreshStats(byte ControllerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool ShowGamercard(byte ConrollerIndex, int ListIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnReadComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	// Export UUIDataStore_OnlineStats::execSortResultsByRank(FFrame&, void* const)
	public virtual /*native function */void SortResultsByRank()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public UIDataStore_OnlineStats()
	{
		// Object Offset:0x0042C14B
		StatsReadName = (name)"StatsReadResults";
		PlayerNickData = new UIDataStore_OnlineStats.PlayerNickMetaData
		{
			PlayerNickName = (name)"Player Nick",
			PlayerNickColumnName = "Player Nick",
		};
		RankNameMetaData = new UIDataStore_OnlineStats.RankMetaData
		{
			RankName = (name)"Rank",
			RankColumnName = "Rank",
		};
		TotalRowsName = (name)"TotalRows";
		Tag = (name)"OnlineStats";
	}
}
}