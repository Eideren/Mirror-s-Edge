namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdTimeTrialData : UIDataStore_TdGameResource/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */TTDataLight
	{
		public bool bFilledIn;
		public string PlayerName;
		public float TotalTime;
		public int TotalRating;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006E66B3
	//		bFilledIn = false;
	//		PlayerName = "";
	//		TotalTime = 3599.990f;
	//		TotalRating = 0;
	//	}
	};
	
	public partial struct /*native */TTUIInfo
	{
		public array<UIDataStore_TdTimeTrialData.TTDataLight> PlayerBest;
		public array<UIDataStore_TdTimeTrialData.TTDataLight> WorldsBest;
		public array<UIDataStore_TdTimeTrialData.TTDataLight> FriendsBest;
		public array<float> AllPersonalBestTimes;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006E68D7
	//		PlayerBest = default;
	//		WorldsBest = default;
	//		FriendsBest = default;
	//		AllPersonalBestTimes = default;
	//	}
	};
	
	public UIDataProvider_TdTimeTrialDataHandler TimeTrialDataProvider;
	public /*private */UIDataStore_TdTimeTrialData.TTUIInfo ProviderData;
	public /*private */int CurrentRaceModeId;
	public /*private */int CurrentStretchProviderIndex;
	public /*private */int CurrentStretchId;
	public /*private */int CurrentControllerId;
	public /*const */array<name> StretchIdMapping;
	public /*config */int WeeklyGhostCutoffRank;
	public /*config */int MonthlyGhostCutoffRank;
	public /*transient */TdTTInput TTOfflineInput;
	public /*transient */TdTTInput TTOnlineInput;
	public /*transient */TdTTResult TTOfflineResult;
	public /*transient */TdTTResult TTOnlineResult;
	public /*private */TdGhostStorageManager GhostStorageManager;
	public TdGhost CurrentGhost;
	public TdLeaderboardSettings.ETdTimeFilterSettings LeaderboardEntryPeriod;
	public bool bReadLeaderboardEntry;
	public /*private */bool bReadParamsSet;
	public /*private */bool bOnlineMode;
	public /*transient */bool TdSROM4;
	public OnlineSubsystem.UniqueNetId LeaderboardEntryNetId;
	public string LeaderboardEntryPlayerName;
	public /*private */int CurrentPlasmaStretchId;
	public /*private */TdLeaderboardFullReadSPTT FullStatsRead;
	public /*private */TdLeaderboardReadTotalOnlySPTT TotalTimeOnlyStatsRead;
	public /*private */TdOnlineStatsReadAllStretches AllStretchesStatsRead;
	public /*private */TdOnlineStatsReadForUI ForUIStatsRead;
	public /*private */OnlineSubsystem.UniqueNetId PlayerId;
	public /*private */OnlineSubsystem OnlineSub;
	public /*private */int NextReadRequestIndex;
	public /*private */array< /*delegate*/UIDataStore_TdTimeTrialData.ReadRequest > ReadRequests;
	public /*private */TdOnlineStatsRead CurrentStatsRead;
	public /*delegate*/UIDataStore_TdTimeTrialData.ReadRequest __ReadRequest__Delegate;
	public /*delegate*/UIDataStore_TdTimeTrialData.ReadResultParser __ReadResultParser__Delegate;
	public /*delegate*/UIDataStore_TdTimeTrialData.OnTimeDataReadCompleted __OnTimeDataReadCompleted__Delegate;
	public /*delegate*/UIDataStore_TdTimeTrialData.OnSaveGhostComplete __OnSaveGhostComplete__Delegate;
	public /*delegate*/UIDataStore_TdTimeTrialData.OnOpenGhostComplete __OnOpenGhostComplete__Delegate;
	
	public delegate bool ReadRequest();
	
	public delegate void ReadResultParser(TdOnlineStatsRead StatResult);
	
	public delegate void OnTimeDataReadCompleted(bool bWasSuccessful);
	
	public delegate void OnSaveGhostComplete(TdGhostStorageManager.EGhostStorageResult Result, int GhostTag);
	
	// Export UUIDataStore_TdTimeTrialData::execGetStretchMapFilename(FFrame&, void* const)
	public virtual /*native function */string GetStretchMapFilename(int ProviderIndex, name FieldName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdTimeTrialData::execGetStretchId(FFrame&, void* const)
	public virtual /*native function */int GetStretchId(int ProviderIndex, name FieldName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdTimeTrialData::execGetStretchIdFromName(FFrame&, void* const)
	public virtual /*native function */int GetStretchIdFromName(name StretchName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdTimeTrialData::execGetStretchProviderIndexFromId(FFrame&, void* const)
	public virtual /*native function */int GetStretchProviderIndexFromId(int StretchId, name FieldName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void SetStretchReadParams(int ControllerId, int StretchProviderIndex, name FieldName, /*optional */OnlineSubsystem.UniqueNetId PlayerNetId = default, /*optional */string PlayerName = default, /*optional */TdLeaderboardSettings.ETdTimeFilterSettings TimeFrame = default)
	{
	
	}
	
	public virtual /*function */name GetCurrentWorkingStretchNameId()
	{
	
		return default;
	}
	
	public virtual /*function */int GetCurrentWorkingStretchProviderIndex()
	{
	
		return default;
	}
	
	public virtual /*function */int GetCurrentWorkingStretchId()
	{
	
		return default;
	}
	
	public virtual /*function */void SetRaceModeId(int RaceMode)
	{
	
	}
	
	public virtual /*function */int GetRaceModeId()
	{
	
		return default;
	}
	
	public virtual /*function */void ClearCaches()
	{
	
	}
	
	public virtual /*function */void InitCaches()
	{
	
	}
	
	public virtual /*function */void ReInit(int ControllerId)
	{
	
	}
	
	public override /*event */void Registered(LocalPlayer P)
	{
	
	}
	
	public override /*event */void Unregistered(LocalPlayer P)
	{
	
	}
	
	public virtual /*function */void OnConnectionChange(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus)
	{
	
	}
	
	public virtual /*function */void OnLoginChange()
	{
	
	}
	
	public override /*function */bool NotifyGameSessionEnded()
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadDataForStretch(bool bInReadOnline, /*delegate*/UIDataStore_TdTimeTrialData.OnTimeDataReadCompleted OnReadCompleted)
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadFullDataForStretch(bool bInReadOnline, /*delegate*/UIDataStore_TdTimeTrialData.OnTimeDataReadCompleted OnReadCompleted)
	{
	
		return default;
	}
	
	public virtual /*private final function */bool StartReadDataForStretch(/*delegate*/UIDataStore_TdTimeTrialData.OnTimeDataReadCompleted OnReadCompleted)
	{
	
		return default;
	}
	
	public virtual /*function */void ReadOfflinePlayerBestForAllStretchs()
	{
	
	}
	
	public virtual /*private final function */bool ReadOfflineDataForStretch()
	{
	
		return default;
	}
	
	public virtual /*private final function */void SetStartReadState()
	{
	
	}
	
	public virtual /*private final function */void PrepareReadRequest(TdOnlineStatsRead StatsRead, /*delegate*/UIDataStore_TdTimeTrialData.ReadResultParser ResultParser, bool bIndefinite, bool bMonthly, bool bWeekly)
	{
	
	}
	
	public virtual /*private final function */void RunReadRequests(bool bSuccess)
	{
	
	}
	
	public virtual /*function */void BreakStatsRead()
	{
	
	}
	
	public virtual /*function */void FinishTimeDataRead(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*private final function */bool RequestForMeAndFriendsForUI()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestWorldsBestForUI()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestForMeAndFriends()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestWorldsBest()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestMyWeekly()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestMyMonthly()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestWorldsWeekly()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestWorldsMonthly()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestWeeklyGhostCutoff()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestMonthlyGhostCutoff()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestLeaderboardEntry()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool RequestPlayerTimeAllStretches()
	{
	
		return default;
	}
	
	public virtual /*private final function */void ParseMeAndFriendsDataForUI(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseWorldsBestDataForUI(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseMeAndFriendsData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseWorldsBestData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseMyWeeklyData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseMyMonthlyData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseWorldsWeeklyData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseWorldsMonthlyData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseWeeklyGhostCutoffData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseMonthlyGhostCutoffData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParseLeaderboardEntryData(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ParsePlayerTimeAllStretches(TdOnlineStatsRead StatResult)
	{
	
	}
	
	public virtual /*private final function */void ClearTimeData()
	{
	
	}
	
	public virtual /*function */TdTTInput.TTData GetTargetRaceData()
	{
	
		return default;
	}
	
	public virtual /*function */TdTTResult GetTimeTrialResult()
	{
	
		return default;
	}
	
	public virtual /*function */int CalculateRating(float TotalTime)
	{
	
		return default;
	}
	
	public delegate void OnOpenGhostComplete(TdGhostStorageManager.EGhostStorageResult Result);
	
	public virtual /*function */void OpenGhost(/*delegate*/UIDataStore_TdTimeTrialData.OnOpenGhostComplete OpenComplete)
	{
	
	}
	
	public virtual /*function */void SaveGhost(int StretchId, string PlayerName, float TotalTime, bool bStoreOnline, TdGhostManager InGhostManager, /*delegate*/UIDataStore_TdTimeTrialData.OnSaveGhostComplete SaveComplete)
	{
	
	}
	
	public virtual /*private final function */void SaveGhostComplete(TdGhostStorageManager.EGhostStorageResult Result, int GhostTag)
	{
	
	}
	
	public virtual /*private final function */void OpenGhostComplete(TdGhostStorageManager.EGhostStorageResult Result, TdGhost Ghost)
	{
	
	}
	
	public UIDataStore_TdTimeTrialData()
	{
		// Object Offset:0x006EB9D8
		StretchIdMapping = new array<name>
		{
			(name)"ETTS_None",
			(name)"ETTS_CranesA01",
			(name)"ETTS_CranesB01",
			(name)"ETTS_CranesB02",
			(name)"ETTS_EdgeA01",
			(name)"ETTS_None",
			(name)"ETTS_StormdrainA02",
			(name)"ETTS_StormdrainB01",
			(name)"ETTS_StormdrainB02",
			(name)"ETTS_StormdrainB03",
			(name)"ETTS_ConvoyA01",
			(name)"ETTS_ConvoyA02",
			(name)"ETTS_ConvoyB01",
			(name)"ETTS_ConvoyB02",
			(name)"ETTS_MallA01",
			(name)"ETTS_TutorialA01",
			(name)"ETTS_TutorialA02",
			(name)"ETTS_FactoryA01",
			(name)"ETTS_SkyscraperA01",
			(name)"ETTS_SkyscraperB01",
			(name)"ETTS_CranesC01",
			(name)"ETTS_TutorialA03",
			(name)"ETTS_EscapeA01",
			(name)"ETTS_EscapeB01",
			(name)"ETTS_CranesD01",
			(name)"ELRS_Edge",
			(name)"ELRS_Escape",
			(name)"ELRS_StormDrain",
			(name)"ELRS_Cranes",
			(name)"ELRS_Subway",
			(name)"ELRS_Mall",
			(name)"ELRS_Factory",
			(name)"ELRS_Boat",
			(name)"ELRS_Convoy",
			(name)"ELRS_Scraper",
		};
		WeeklyGhostCutoffRank = 500;
		MonthlyGhostCutoffRank = 500;
		NextReadRequestIndex = -1;
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdTimeTrialStretches",
				ProviderClassName = "TdGame.UIDataProvider_TdTimeTrialStretch",
				ProviderClass = default,
			},
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdLevelRaceStretches",
				ProviderClassName = "TdGame.UIDataProvider_TdLevelRaceStretch",
				ProviderClass = default,
			},
		};
		Tag = (name)"TdTimeTrialData";
	}
}
}