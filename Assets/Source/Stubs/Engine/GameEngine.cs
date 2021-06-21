namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameEngine : Engine/*
		transient
		native
		config(Engine)*/{
	public enum EFullyLoadPackageType 
	{
		FULLYLOAD_Map,
		FULLYLOAD_Game_PreLoadClass,
		FULLYLOAD_Game_PostLoadClass,
		FULLYLOAD_Always,
		FULLYLOAD_MAX
	};
	
	public partial struct /*native transient */URL
	{
		public /*init */String Protocol;
		public /*init */String Host;
		public /*init */int Port;
		public /*init */String Map;
		public /*init */array<String> Op;
		public /*init */String Portal;
		public /*init */int Valid;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0032389E
	//		Protocol = "";
	//		Host = "";
	//		Port = 0;
	//		Map = "";
	//		Op = default;
	//		Portal = "";
	//		Valid = 0;
	//	}
	};
	
	public partial struct /*native */LevelStreamingStatus
	{
		public name PackageName;
		public bool bShouldBeLoaded;
		public bool bShouldBeVisible;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00323DE6
	//		PackageName = (name)"None";
	//		bShouldBeLoaded = false;
	//		bShouldBeVisible = false;
	//	}
	};
	
	public partial struct /*native */FullyLoadedPackagesInfo
	{
		public GameEngine.EFullyLoadPackageType FullyLoadType;
		public String Tag;
		public array<name> PackagesToLoad;
		public array<Object> LoadedObjects;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00323FCE
	//		FullyLoadType = GameEngine.EFullyLoadPackageType.FULLYLOAD_Map;
	//		Tag = "";
	//		PackagesToLoad = default;
	//		LoadedObjects = default;
	//	}
	};
	
	public PendingLevel GPendingLevel;
	public GameEngine.URL LastURL;
	public GameEngine.URL LastRemoteURL;
	public /*config */array</*config */String> ServerActors;
	public String TravelURL;
	public byte TravelType;
	public /*transient */bool bWorldWasLoadedThisTick;
	public /*const */bool bShouldCommitPendingMapChange;
	public /*const */bool bShouldSkipLevelStartupEventOnMapCommit;
	public /*const */bool bShouldSkipLevelBeginningEventOnMapCommit;
	public /*config */bool bSmoothFrameRate;
	public /*config */bool bClearAnimSetLinkupCachesOnLoadMap;
	public OnlineSubsystem OnlineSubsystem;
	public /*const */array<name> LevelsToLoadForPendingMapChange;
	public /*const */array<Level> LoadedLevelsForPendingMapChange;
	public /*const */String PendingMapChangeFailureDescription;
	public /*config */float MaxSmoothedFrameRate;
	public /*config */float MinSmoothedFrameRate;
	public /*const */array<GameEngine.LevelStreamingStatus> PendingLevelStreamingStatusUpdates;
	public /*const */array<ObjectReferencer> ObjectReferencers;
	public array<GameEngine.FullyLoadedPackagesInfo> PackagesToFullyLoad;
	
	// Export UGameEngine::execGetOnlineSubsystem(FFrame&, void* const)
	public /*native final function */static OnlineSubsystem GetOnlineSubsystem()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*event */void DispatchExternalUIChange(bool bIsOpening)
	{
		// stub
	}
	
	public GameEngine()
	{
		// Object Offset:0x003241B2
		LastURL = new GameEngine.URL
		{
			Protocol = "",
			Host = "",
			Port = 0,
			Map = "",
			Op = default,
			Portal = "",
			Valid = 1,
		};
		LastRemoteURL = new GameEngine.URL
		{
			Protocol = "",
			Host = "",
			Port = 0,
			Map = "",
			Op = default,
			Portal = "",
			Valid = 1,
		};
		bSmoothFrameRate = true;
		MaxSmoothedFrameRate = 62.0f;
		MinSmoothedFrameRate = 22.0f;
	}
}
}