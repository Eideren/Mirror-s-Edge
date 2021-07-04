namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpPresenceManager : TpSystemHandler/*
		abstract
		transient
		native
		config(Presence)*/{
	public partial struct /*native */PresBind
	{
		public /*config */String LevelName;
		public /*config */int PresenceId;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x000413AB
	//		LevelName = "";
	//		PresenceId = 0;
	//	}
	};
	
	public /*config */array</*config */TpPresenceManager.PresBind> PresenceBindings;
	public /*delegate*/TpPresenceManager.OnPresenceUpdated __OnPresenceUpdated__Delegate;
	
	// Export UTpPresenceManager::execGetPresence(FFrame&, void* const)
	public virtual /*native simulated function */TpSystemBase.TpPresence GetPresence(OnlineSubsystem.UniqueNetId User)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpPresenceManager::execGetLocalPresence(FFrame&, void* const)
	public virtual /*native simulated function */TpSystemBase.TpPresence GetLocalPresence()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpPresenceManager::execSetPresence(FFrame&, void* const)
	public virtual /*native simulated function */void SetPresence(byte LocalUserNum, int StatusId, int ContextId, int ContextValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnPresenceUpdated();
	
	public TpPresenceManager()
	{
		// Object Offset:0x00041931
		PresenceBindings = new array</*config */TpPresenceManager.PresBind>
		{
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CRANESA01_P",
				PresenceId = 1,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CRANESB01_P",
				PresenceId = 2,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CRANESC01_P",
				PresenceId = 3,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CRANESB02_P",
				PresenceId = 4,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_EDGEA01_P",
				PresenceId = 5,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_STORMDRAINA01_P",
				PresenceId = 6,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_STORMDRAINA02_P",
				PresenceId = 7,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_STORMDRAINB01_P",
				PresenceId = 8,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_STORMDRAINB02_P",
				PresenceId = 9,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_STORMDRAINB03_P",
				PresenceId = 10,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CONVOYA01_P",
				PresenceId = 11,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CONVOYA02_P",
				PresenceId = 12,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CONVOYB01_P",
				PresenceId = 13,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CONVOYB02_P",
				PresenceId = 14,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_MALLA01_P",
				PresenceId = 15,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_TUTORIALA01_P",
				PresenceId = 16,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_TUTORIALA02_P",
				PresenceId = 17,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_TUTORIALA03_P",
				PresenceId = 18,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_FACTORYA01_P",
				PresenceId = 19,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_SCRAPERA01_P",
				PresenceId = 20,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_SCRAPERB01_P",
				PresenceId = 21,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_ESCAPEA01_P",
				PresenceId = 22,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_ESCAPEB01_P",
				PresenceId = 23,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TT_CRANESD01_P",
				PresenceId = 24,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "EDGE_P",
				PresenceId = 10,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "ESCAPE_P",
				PresenceId = 1,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "STORMDRAIN_P",
				PresenceId = 2,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "CRANES_P",
				PresenceId = 3,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "SUBWAY_P",
				PresenceId = 4,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "MALL_P",
				PresenceId = 5,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "FACTORY_P",
				PresenceId = 6,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "BOAT_P",
				PresenceId = 7,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "CONVOY_P",
				PresenceId = 8,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "SCRAPER_P",
				PresenceId = 9,
			},
			new TpPresenceManager.PresBind
			{
				LevelName = "TUTORIAL_P",
				PresenceId = 11,
			},
		};
	}
}
}