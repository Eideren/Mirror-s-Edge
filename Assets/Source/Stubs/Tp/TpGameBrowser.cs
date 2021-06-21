namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpGameBrowser : TpSystemHandler/*
		abstract
		transient
		native*/{
	public enum TpGameMode 
	{
		kTpGm_Pursuit,
		kTpGm_Possession,
		kTpGm_DeathMatch,
		kTpGm_Any,
		kTpGm_MAX
	};
	
	public enum TpPrefRegion 
	{
		kTpPrr_EU,
		kTpPrr_US,
		kTpPrr_Any,
		kTpPrr_MAX
	};
	
	public partial struct /*native */TpLobbyRef
	{
		public int Value;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003D7F5
	//		Value = 0;
	//	}
	};
	
	public partial struct /*native */TpGameRef
	{
		public int Value;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003D875
	//		Value = 0;
	//	}
	};
	
	public partial struct /*native */TpLobbyListParams
	{
		public byte MinPlayers;
		public bool bFavouritesOnly;
		public bool bNotFull;
		public bool bNotPrivate;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003D97D
	//		MinPlayers = 0;
	//		bFavouritesOnly = false;
	//		bNotFull = false;
	//		bNotPrivate = false;
	//	}
	};
	
	public partial struct /*native */TpLobbyListFavourites
	{
		public /*init */String Players;
		public /*init */String Games;
		public /*init */array</*init */Object.QWord> Uids;
		public /*init */array</*init */String> PersistentIds;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003DB36
	//		Players = "";
	//		Games = "";
	//		Uids = default;
	//		PersistentIds = default;
	//	}
	};
	
	public partial struct /*native */TpGameListParams
	{
		public int MaxGames;
		public int StartingGameId;
		public byte MinPlayers;
		public bool bFavouritesOnly;
		public bool bNotFull;
		public bool bNotPrivate;
		public bool bNotClosed;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003DD16
	//		MaxGames = -1;
	//		StartingGameId = 0;
	//		MinPlayers = 0;
	//		bFavouritesOnly = false;
	//		bNotFull = false;
	//		bNotPrivate = false;
	//		bNotClosed = false;
	//	}
	};
	
	public partial struct /*native */TpGameListFavourites
	{
		public /*init */String Players;
		public /*init */String Games;
		public /*init */array</*init */Object.QWord> Uids;
		public /*init */array</*init */String> PersistentIds;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003DF23
	//		Players = "";
	//		Games = "";
	//		Uids = default;
	//		PersistentIds = default;
	//	}
	};
	
	public partial struct /*native */TpPlayNowJoinGameInfo
	{
		public TpGameBrowser.TpLobbyRef Lobby;
		public TpGameBrowser.TpGameRef Game;
		public float MatchQuality;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003E057
	//		Lobby = new TpGameBrowser.TpLobbyRef
	//		{
	//			Value = 0,
	//		};
	//		Game = new TpGameBrowser.TpGameRef
	//		{
	//			Value = 0,
	//		};
	//		MatchQuality = 0.0f;
	//	}
	};
	
	public partial struct /*native */TpPlayNowCreateGameInfo
	{
		public Object.Pointer NewGameParams;
		public float MatchQuality;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003E18F
	//		NewGameParams = default;
	//		MatchQuality = 0.0f;
	//	}
	};
	
	public partial struct /*native */TpPoolPlayerCountThresholdEntry
	{
		public int Seconds;
		public int Players;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003E263
	//		Seconds = 0;
	//		Players = 0;
	//	}
	};
	
	public partial struct /*native */TpPlayNowParams
	{
		public int PoolPlayerTimeout;
		public int PoolMaxPlayers;
		public array<TpGameBrowser.TpPoolPlayerCountThresholdEntry> PoolPlayerCountThreshold;
		public int HostSetupTimeout;
		public bool bRankedMatch;
		public bool bHeavyWeaponsAllowed;
		public TpGameBrowser.TpGameMode GameMode;
		public TpGameBrowser.TpPrefRegion PrefRegion;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003E4E7
	//		PoolPlayerTimeout = 0;
	//		PoolMaxPlayers = 0;
	//		PoolPlayerCountThreshold = default;
	//		HostSetupTimeout = 0;
	//		bRankedMatch = false;
	//		bHeavyWeaponsAllowed = false;
	//		GameMode = TpGameBrowser.TpGameMode.kTpGm_Pursuit;
	//		PrefRegion = TpGameBrowser.TpPrefRegion.kTpPrr_EU;
	//	}
	};
	
	public /*private transient */TpGameBrowser.TpPlayNowCreateGameInfo PlayNowCreateGameInfo;
	public /*private transient */TpGameBrowser.TpPlayNowJoinGameInfo PlayNowJoinGameInfo;
	public /*delegate*/TpGameBrowser.OnUpdateLobbyList __OnUpdateLobbyList__Delegate;
	public /*delegate*/TpGameBrowser.OnUpdateGameList __OnUpdateGameList__Delegate;
	public /*delegate*/TpGameBrowser.OnPlayNowStarted __OnPlayNowStarted__Delegate;
	public /*delegate*/TpGameBrowser.OnPlayNowMatched __OnPlayNowMatched__Delegate;
	
	// Export UTpGameBrowser::execUpdateLobbyListAsync(FFrame&, void* const)
	public virtual /*native simulated function */void UpdateLobbyListAsync(/*optional */ref TpGameBrowser.TpLobbyListParams InParams/* = default*/, /*optional */ref TpGameBrowser.TpLobbyListFavourites InFavourites/* = default*/)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnUpdateLobbyList(bool bInOk);
	
	// Export UTpGameBrowser::execDropLobbyList(FFrame&, void* const)
	public virtual /*native simulated function */void DropLobbyList()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpGameBrowser::execGetLobbyByIndex(FFrame&, void* const)
	public virtual /*native simulated function */TpGameBrowser.TpLobbyRef GetLobbyByIndex(int InIndex)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTpGameBrowser::execUpdateGameListAsync(FFrame&, void* const)
	public virtual /*native simulated function */void UpdateGameListAsync(TpGameBrowser.TpLobbyRef InLobby, /*optional */ref TpGameBrowser.TpGameListParams InParams/* = default*/, /*optional */ref TpGameBrowser.TpGameListFavourites InFavourites/* = default*/)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnUpdateGameList(bool bInOk);
	
	// Export UTpGameBrowser::execStartQuickMatchAsync(FFrame&, void* const)
	public virtual /*native simulated function */void StartQuickMatchAsync(TpGameBrowser.TpPlayNowParams Params)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnPlayNowStarted();
	
	public delegate void OnPlayNowMatched(bool bIsServer, int InError);
	
	// Export UTpGameBrowser::execFindGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void FindGameAsync(TpGameBrowser.TpPlayNowParams Params)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpGameBrowser::execDropGameList(FFrame&, void* const)
	public virtual /*native simulated function */void DropGameList(TpGameBrowser.TpLobbyRef InLobby)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpGameBrowser::execGetGameByIndex(FFrame&, void* const)
	public virtual /*native simulated function */TpGameBrowser.TpGameRef GetGameByIndex(TpGameBrowser.TpLobbyRef InLobby, int InIndex)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TpGameBrowser.TpPlayNowCreateGameInfo GetPlayNowCreateGameInfo()
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TpGameBrowser.TpPlayNowJoinGameInfo GetPlayNowJoinGameInfo()
	{
		// stub
		return default;
	}
	
}
}