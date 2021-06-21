namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpSystemBase : OnlineSubsystem/*
		abstract
		transient
		native*/{
	public enum TpArea 
	{
		kTpArea_Lan,
		kTpArea_Wan,
		kTpArea_MAX
	};
	
	public enum TpEnv 
	{
		kTpEnv_Stest,
		kTpEnv_Prod,
		kTpEnv_MAX
	};
	
	public enum TpPresenceStatus 
	{
		kTpPs_Offline,
		kTpPs_Chat,
		kTpPs_Away,
		kTpPs_Xa,
		kTpPs_Dnd,
		kTpPs_Game,
		kTpPs_Unknown,
		kTpPs_MAX
	};
	
	public enum TpPresenceFlags 
	{
		kTpPf_None,
		kTpPf_GameJoinable,
		kTpPf_MAX
	};
	
	public partial struct /*native */TpPresence
	{
		public TpSystemBase.TpPresenceStatus Status;
		public TpSystemBase.TpPresenceFlags Flags;
		public TpSystemBase.TpPresenceFlags __filler1__;
		public TpSystemBase.TpPresenceFlags __filler2__;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x000416C9
	//		Status = TpSystemBase.TpPresenceStatus.kTpPs_Offline;
	//		Flags = TpSystemBase.TpPresenceFlags.kTpPf_None;
	//		__filler1__ = TpSystemBase.TpPresenceFlags.kTpPf_None;
	//		__filler2__ = TpSystemBase.TpPresenceFlags.kTpPf_None;
	//	}
	};
	
	public partial struct /*native */TpInitializeParams
	{
		public TpSystemBase.TpEnv Env;
		public String Sku;
		public String Version;
		public String ClientString360;
		public String ClientStringPS3;
		public String ClientStringPC;
		public int FeslPort360;
		public int FeslPortPS3;
		public int FeslPortPC;
		public String Ps3TitleId;
		public String Ps3CommId;
		public String Ps3Spid;
		public int MaxPlayers;
		public String ClientType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0004325F
	//		Env = TpSystemBase.TpEnv.kTpEnv_Prod;
	//		Sku = "TAKEDOWN";
	//		Version = "1.0.0";
	//		ClientString360 = "takedown-360";
	//		ClientStringPS3 = "takedown-ps3";
	//		ClientStringPC = "takedown-pc";
	//		FeslPort360 = 18690;
	//		FeslPortPS3 = 18700;
	//		FeslPortPC = 18680;
	//		Ps3TitleId = "BLUS30179_00";
	//		Ps3CommId = "NPWR00499";
	//		Ps3Spid = "UP0006";
	//		MaxPlayers = 12;
	//		ClientType = "client-noreg";
	//	}
	};
	
	public partial struct /*native */TpSystemInitializer
	{
		public /*private native transient */bool bInitialized;
	};
	
	public partial struct /*native */TpErrorInfo
	{
		public int ErrorCode;
		public String LocErrorString;
		public bool bRestartNeeded;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0004356B
	//		ErrorCode = 0;
	//		LocErrorString = "";
	//		bRestartNeeded = false;
	//	}
	};
	
	public partial struct /*native */TpNpEvent
	{
		public int Event;
		public int RetCode;
		public int ReqId;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0004367B
	//		Event = 0;
	//		RetCode = 0;
	//		ReqId = 0;
	//	}
	};
	
	public /*protected transient */TpDebugger __Debugger;
	public /*private */TpSystemBase.TpSystemInitializer Initializer;
	public /*protected const transient */bool UseMultiplayer;
	public /*transient */bool TdSROM6;
	public /*private */TpSystemBase.TpErrorInfo LatestOnlineError;
	public /*private */TpOnScreenErrorHandler ErrorHandler;
	public /*private */array<TpSystemBase.TpNpEvent> EventQueue;
	public /*native transient */int TrophyContext;
	public /*native transient */int TrophyHandle;
	
	// Export UTpSystemBase::execGet(FFrame&, void* const)
	public /*native simulated function */static TpSystemBase Get()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTpSystemBase::execInitialize(FFrame&, void* const)
	public virtual /*protected native simulated function */void Initialize(TpSystemBase.TpInitializeParams InParams)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpSystemBase::execEnd(FFrame&, void* const)
	public virtual /*protected native simulated function */void End()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpSystemBase::execNpEventLoopControl(FFrame&, void* const)
	public virtual /*protected native simulated function */void NpEventLoopControl(int Op)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void ProcessTick_del(float DeltaSeconds);
	public virtual ProcessTick_del ProcessTick { get => bfield_ProcessTick ?? TpSystemBase_ProcessTick; set => bfield_ProcessTick = value; } ProcessTick_del bfield_ProcessTick;
	public virtual ProcessTick_del global_ProcessTick => TpSystemBase_ProcessTick;
	public /*protected simulated event */void TpSystemBase_ProcessTick(float DeltaSeconds)
	{
		// stub
	}
	
	public delegate TpAssociationManager GetAssociationManager_del();
	public virtual GetAssociationManager_del GetAssociationManager { get => bfield_GetAssociationManager ?? TpSystemBase_GetAssociationManager; set => bfield_GetAssociationManager = value; } GetAssociationManager_del bfield_GetAssociationManager;
	public virtual GetAssociationManager_del global_GetAssociationManager => TpSystemBase_GetAssociationManager;
	public /*simulated event */TpAssociationManager TpSystemBase_GetAssociationManager()
	{
		// stub
		return default;
	}
	
	public delegate TpPlayGroupManager GetPlayGroupManager_del();
	public virtual GetPlayGroupManager_del GetPlayGroupManager { get => bfield_GetPlayGroupManager ?? TpSystemBase_GetPlayGroupManager; set => bfield_GetPlayGroupManager = value; } GetPlayGroupManager_del bfield_GetPlayGroupManager;
	public virtual GetPlayGroupManager_del global_GetPlayGroupManager => TpSystemBase_GetPlayGroupManager;
	public /*simulated event */TpPlayGroupManager TpSystemBase_GetPlayGroupManager()
	{
		// stub
		return default;
	}
	
	public delegate TpRankingService GetRankingService_del();
	public virtual GetRankingService_del GetRankingService { get => bfield_GetRankingService ?? TpSystemBase_GetRankingService; set => bfield_GetRankingService = value; } GetRankingService_del bfield_GetRankingService;
	public virtual GetRankingService_del global_GetRankingService => TpSystemBase_GetRankingService;
	public /*simulated event */TpRankingService TpSystemBase_GetRankingService()
	{
		// stub
		return default;
	}
	
	public delegate TpPresenceManager GetPresenceManager_del();
	public virtual GetPresenceManager_del GetPresenceManager { get => bfield_GetPresenceManager ?? TpSystemBase_GetPresenceManager; set => bfield_GetPresenceManager = value; } GetPresenceManager_del bfield_GetPresenceManager;
	public virtual GetPresenceManager_del global_GetPresenceManager => TpSystemBase_GetPresenceManager;
	public /*simulated event */TpPresenceManager TpSystemBase_GetPresenceManager()
	{
		// stub
		return default;
	}
	
	public delegate TpUserManager GetUserManager_del();
	public virtual GetUserManager_del GetUserManager { get => bfield_GetUserManager ?? TpSystemBase_GetUserManager; set => bfield_GetUserManager = value; } GetUserManager_del bfield_GetUserManager;
	public virtual GetUserManager_del global_GetUserManager => TpSystemBase_GetUserManager;
	public /*simulated event */TpUserManager TpSystemBase_GetUserManager()
	{
		// stub
		return default;
	}
	
	public delegate TpConnection GetConnection_del();
	public virtual GetConnection_del GetConnection { get => bfield_GetConnection ?? TpSystemBase_GetConnection; set => bfield_GetConnection = value; } GetConnection_del bfield_GetConnection;
	public virtual GetConnection_del global_GetConnection => TpSystemBase_GetConnection;
	public /*simulated event */TpConnection TpSystemBase_GetConnection()
	{
		// stub
		return default;
	}
	
	public delegate TpGameBrowser GetGameBrowser_del();
	public virtual GetGameBrowser_del GetGameBrowser { get => bfield_GetGameBrowser ?? TpSystemBase_GetGameBrowser; set => bfield_GetGameBrowser = value; } GetGameBrowser_del bfield_GetGameBrowser;
	public virtual GetGameBrowser_del global_GetGameBrowser => TpSystemBase_GetGameBrowser;
	public /*simulated event */TpGameBrowser TpSystemBase_GetGameBrowser()
	{
		// stub
		return default;
	}
	
	public delegate TpGameManager GetGameManager_del();
	public virtual GetGameManager_del GetGameManager { get => bfield_GetGameManager ?? TpSystemBase_GetGameManager; set => bfield_GetGameManager = value; } GetGameManager_del bfield_GetGameManager;
	public virtual GetGameManager_del global_GetGameManager => TpSystemBase_GetGameManager;
	public /*simulated event */TpGameManager TpSystemBase_GetGameManager()
	{
		// stub
		return default;
	}
	
	public delegate TpMessageService GetMessageService_del();
	public virtual GetMessageService_del GetMessageService { get => bfield_GetMessageService ?? TpSystemBase_GetMessageService; set => bfield_GetMessageService = value; } GetMessageService_del bfield_GetMessageService;
	public virtual GetMessageService_del global_GetMessageService => TpSystemBase_GetMessageService;
	public /*simulated event */TpMessageService TpSystemBase_GetMessageService()
	{
		// stub
		return default;
	}
	
	public delegate TpAchievementManager GetAchievementManager_del();
	public virtual GetAchievementManager_del GetAchievementManager { get => bfield_GetAchievementManager ?? TpSystemBase_GetAchievementManager; set => bfield_GetAchievementManager = value; } GetAchievementManager_del bfield_GetAchievementManager;
	public virtual GetAchievementManager_del global_GetAchievementManager => TpSystemBase_GetAchievementManager;
	public /*simulated event */TpAchievementManager TpSystemBase_GetAchievementManager()
	{
		// stub
		return default;
	}
	
	public delegate TpFileLockerService GetFileLockerService_del();
	public virtual GetFileLockerService_del GetFileLockerService { get => bfield_GetFileLockerService ?? TpSystemBase_GetFileLockerService; set => bfield_GetFileLockerService = value; } GetFileLockerService_del bfield_GetFileLockerService;
	public virtual GetFileLockerService_del global_GetFileLockerService => TpSystemBase_GetFileLockerService;
	public /*simulated event */TpFileLockerService TpSystemBase_GetFileLockerService()
	{
		// stub
		return default;
	}
	
	public delegate TpProtoHTTP GetProtoHTTP_del();
	public virtual GetProtoHTTP_del GetProtoHTTP { get => bfield_GetProtoHTTP ?? TpSystemBase_GetProtoHTTP; set => bfield_GetProtoHTTP = value; } GetProtoHTTP_del bfield_GetProtoHTTP;
	public virtual GetProtoHTTP_del global_GetProtoHTTP => TpSystemBase_GetProtoHTTP;
	public /*simulated event */TpProtoHTTP TpSystemBase_GetProtoHTTP()
	{
		// stub
		return default;
	}
	
	public delegate void ImpelConnected_del();
	public virtual ImpelConnected_del ImpelConnected { get => bfield_ImpelConnected ?? TpSystemBase_ImpelConnected; set => bfield_ImpelConnected = value; } ImpelConnected_del bfield_ImpelConnected;
	public virtual ImpelConnected_del global_ImpelConnected => TpSystemBase_ImpelConnected;
	public /*protected simulated event */void TpSystemBase_ImpelConnected()
	{
		// stub
	}
	
	public delegate void ImpelDisconnected_del();
	public virtual ImpelDisconnected_del ImpelDisconnected { get => bfield_ImpelDisconnected ?? TpSystemBase_ImpelDisconnected; set => bfield_ImpelDisconnected = value; } ImpelDisconnected_del bfield_ImpelDisconnected;
	public virtual ImpelDisconnected_del global_ImpelDisconnected => TpSystemBase_ImpelDisconnected;
	public /*protected simulated event */void TpSystemBase_ImpelDisconnected()
	{
		// stub
	}
	
	public delegate void ImpelGameCreated_del();
	public virtual ImpelGameCreated_del ImpelGameCreated { get => bfield_ImpelGameCreated ?? TpSystemBase_ImpelGameCreated; set => bfield_ImpelGameCreated = value; } ImpelGameCreated_del bfield_ImpelGameCreated;
	public virtual ImpelGameCreated_del global_ImpelGameCreated => TpSystemBase_ImpelGameCreated;
	public /*protected simulated event */void TpSystemBase_ImpelGameCreated()
	{
		// stub
	}
	
	public delegate void ImpelGameDestroyed_del();
	public virtual ImpelGameDestroyed_del ImpelGameDestroyed { get => bfield_ImpelGameDestroyed ?? TpSystemBase_ImpelGameDestroyed; set => bfield_ImpelGameDestroyed = value; } ImpelGameDestroyed_del bfield_ImpelGameDestroyed;
	public virtual ImpelGameDestroyed_del global_ImpelGameDestroyed => TpSystemBase_ImpelGameDestroyed;
	public /*protected simulated event */void TpSystemBase_ImpelGameDestroyed()
	{
		// stub
	}
	
	public delegate void ImpelGameJoined_del();
	public virtual ImpelGameJoined_del ImpelGameJoined { get => bfield_ImpelGameJoined ?? TpSystemBase_ImpelGameJoined; set => bfield_ImpelGameJoined = value; } ImpelGameJoined_del bfield_ImpelGameJoined;
	public virtual ImpelGameJoined_del global_ImpelGameJoined => TpSystemBase_ImpelGameJoined;
	public /*protected simulated event */void TpSystemBase_ImpelGameJoined()
	{
		// stub
	}
	
	public virtual /*simulated event */void RegisterLatestError(TpSystemBase.TpErrorInfo LatestError)
	{
		// stub
	}
	
	public virtual /*simulated function */TpSystemBase.TpErrorInfo GetLatestError()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void SetOnScreenHandler(TpOnScreenErrorHandler Handler)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		ProcessTick = null;
		GetAssociationManager = null;
		GetPlayGroupManager = null;
		GetRankingService = null;
		GetPresenceManager = null;
		GetUserManager = null;
		GetConnection = null;
		GetGameBrowser = null;
		GetGameManager = null;
		GetMessageService = null;
		GetAchievementManager = null;
		GetFileLockerService = null;
		GetProtoHTTP = null;
		ImpelConnected = null;
		ImpelDisconnected = null;
		ImpelGameCreated = null;
		ImpelGameDestroyed = null;
		ImpelGameJoined = null;
	
	}
}
}