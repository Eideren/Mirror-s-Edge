namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdOnlineStats : UIDataStore_OnlineStats/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public const double TT_UNDEFINEDTIME = 3599.99;
	
	public enum ETdOnlineStatsReadState 
	{
		TDSR_NONE,
		TDSR_INIT,
		TDSR_PLAYER,
		TDSR_LEADERBOARD,
		TDSR_MAX
	};
	
	public UIDataStore_TdOnlineStats.ETdOnlineStatsReadState CurrentReadState;
	public /*private */byte CurrentControllerIndex;
	public Core.ClassT<TdLeaderboardSettings> LeaderboardSettingsClass;
	public TdLeaderboardSettings LeaderboardSettings;
	public UIDataProvider_Settings SettingsProvider;
	public /*const */name PlayerStatsReadName;
	public OnlineStatsRead PlayerStatsRead;
	public /*private */int CurrentStretchId;
	public /*private */int PlayerStatsReadIndex;
	public /*private */array<OnlineStatsRead> PlayerStatsReadCache;
	public /*private */int StatsReadIndex;
	public /*private */array<OnlineStatsRead> StatsReadCache;
	public /*const localized */String PlayerNickColumnNameXbox;
	public /*const localized */String PlayerNickColumnNamePS3;
	public /*delegate*/UIDataStore_TdOnlineStats.StatsReadComplete __StatsReadComplete__Delegate;
	
	public delegate void StatsReadComplete(bool bSuccess);
	
	public override /*event */void Init()
	{
	
	}
	
	public virtual /*function */void SetCurrentStretchId(int StretchId)
	{
	
	}
	
	public virtual /*event */OnlineStatsRead GetStatsReadObject(name FieldName)
	{
	
		return default;
	}
	
	public override /*function */void SetStatsReadInfo()
	{
	
	}
	
	public virtual /*function */void InitCaches()
	{
	
	}
	
	public virtual /*function */void ClearCaches()
	{
	
	}
	
	public override /*event */bool RefreshStats(byte ControllerIndex)
	{
	
		return default;
	}
	
	public override /*function */void OnReadComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */bool ReadPlayerStats()
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadLeaderboardStats()
	{
	
		return default;
	}
	
	// Export UUIDataStore_TdOnlineStats::execGetPlayerRank(FFrame&, void* const)
	public virtual /*native function */int GetPlayerRank(int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */int FindLocalPlayerIndex()
	{
	
		return default;
	}
	
	public UIDataStore_TdOnlineStats()
	{
		// Object Offset:0x006DFF22
		LeaderboardSettingsClass = ClassT<TdLeaderboardSettings>()/*Ref Class'TdLeaderboardSettings'*/;
		PlayerStatsReadName = (name)"PlayerStatsReadResults";
		PlayerNickColumnNameXbox = "GAMERTAG";
		PlayerNickColumnNamePS3 = "ONLINE ID";
		StatsReadClasses = new array< Core.ClassT<OnlineStatsRead> >
		{
			ClassT<TdLeaderboardReadSPTT>(),
		};
		PlayerNickData = new UIDataStore_OnlineStats.PlayerNickMetaData
		{
			PlayerNickColumnName = "PLAYER",
		};
		Tag = (name)"TdLeaderboardsData";
	}
}
}