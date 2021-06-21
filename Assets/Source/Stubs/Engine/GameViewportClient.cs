namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameViewportClient : Object/* within Engine*//*
		transient
		native
		config(Game)*/{
	public enum ESplitScreenType 
	{
		eSST_NONE,
		eSST_2P_HORIZONTAL,
		eSST_2P_VERTICAL,
		eSST_3P_FAVOR_TOP,
		eSST_3P_FAVOR_BOTTOM,
		eSST_4P,
		eSST_COUNT,
		eSST_NOVALUE,
		eSST_MAX
	};
	
	public enum ESafeZoneType 
	{
		eSZ_TOP,
		eSZ_BOTTOM,
		eSZ_LEFT,
		eSZ_RIGHT,
		eSZ_MAX
	};
	
	public partial struct /*native */TitleSafeZoneArea
	{
		public float MaxPercentX;
		public float MaxPercentY;
		public float RecommendedPercentX;
		public float RecommendedPercentY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0033913F
	//		MaxPercentX = 0.0f;
	//		MaxPercentY = 0.0f;
	//		RecommendedPercentX = 0.0f;
	//		RecommendedPercentY = 0.0f;
	//	}
	};
	
	public partial struct /*native */PerPlayerSplitscreenData
	{
		public float SizeX;
		public float SizeY;
		public float OriginX;
		public float OriginY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00339337
	//		SizeX = 0.0f;
	//		SizeY = 0.0f;
	//		OriginX = 0.0f;
	//		OriginY = 0.0f;
	//	}
	};
	
	public partial struct /*native */SplitscreenData
	{
		public array<GameViewportClient.PerPlayerSplitscreenData> PlayerData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0033943F
	//		PlayerData = default;
	//	}
	};
	
	public new Engine Outer => base.Outer as Engine;
	
	public /*private native const noexport */Object.Pointer VfTable_FViewportClient;
	public /*private native const noexport */Object.Pointer VfTable_FExec;
	public /*const */Object.Pointer Viewport;
	public /*const */Object.Pointer ViewportFrame;
	public /*init */array</*init */Interaction> GlobalInteractions;
	public Core.ClassT<UIInteraction> UIControllerClass;
	public UIInteraction UIController;
	public Console ViewportConsole;
	public /*const */Object.QWord ShowFlags;
	public /*const localized */String LoadingMessage;
	public /*const localized */String SavingMessage;
	public /*const localized */String ConnectingMessage;
	public /*const localized */String PausedMessage;
	public /*const localized */String PrecachingMessage;
	public bool bShowTitleSafeZone;
	public /*transient */bool bDisplayingUIMouseCursor;
	public /*transient */bool bUIMouseCaptureOverride;
	public bool bDisableWorldRendering;
	public GameViewportClient.TitleSafeZoneArea TitleSafeZone;
	public array<GameViewportClient.SplitscreenData> SplitscreenInfo;
	public GameViewportClient.ESplitScreenType SplitscreenType;
	public /*const */GameViewportClient.ESplitScreenType Default2PSplitType;
	public /*const */GameViewportClient.ESplitScreenType Default3PSplitType;
	public /*config */Object.Vector2D SubtitleMinRegion;
	public /*config */Object.Vector2D SubtitleMaxRegion;
	public /*delegate*/GameViewportClient.HandleInputKey __HandleInputKey__Delegate;
	public /*delegate*/GameViewportClient.HandleInputAxis __HandleInputAxis__Delegate;
	public /*delegate*/GameViewportClient.HandleInputChar __HandleInputChar__Delegate;
	
	public delegate bool HandleInputKey(int ControllerId, name Key, Object.EInputEvent EventType, float AmountDepressed, /*optional */bool? _bGamepad = default);
	
	public delegate bool HandleInputAxis(int ControllerId, name Key, float Delta, float DeltaTime, bool bGamepad);
	
	public delegate bool HandleInputChar(int ControllerId, String Unicode);
	
	// Export UGameViewportClient::execConsoleCommand(FFrame&, void* const)
	public virtual /*native function */String ConsoleCommand(String Command)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameViewportClient::execGetViewportSize(FFrame&, void* const)
	public virtual /*native final function */void GetViewportSize(ref Object.Vector2D out_ViewportSize)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UGameViewportClient::execIsFullScreenViewport(FFrame&, void* const)
	public virtual /*native final function */bool IsFullScreenViewport()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*event */LocalPlayer CreatePlayer(int ControllerId, ref String OutError, bool bSpawnActor)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool RemovePlayer(LocalPlayer ExPlayer)
	{
		// stub
		return default;
	}
	
	public virtual /*final event */LocalPlayer FindPlayerByControllerId(int ControllerId)
	{
		// stub
		return default;
	}
	
	public virtual /*exec function */void DebugCreatePlayer(int ControllerId)
	{
		// stub
	}
	
	public virtual /*exec function */void SSSwapControllers()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugRemovePlayer(int ControllerId)
	{
		// stub
	}
	
	public virtual /*exec function */void SetSplit(int Mode)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowTitleSafeArea()
	{
		// stub
	}
	
	public virtual /*exec function */void SetConsoleTarget(int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*event */bool Init(ref String OutError)
	{
		// stub
		return default;
	}
	
	public virtual /*event */int InsertInteraction(Interaction NewInteraction, /*optional */int? _InIndex = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */void GameSessionEnded()
	{
		// stub
	}
	
	public virtual /*function */void SetSplitscreenConfiguration(GameViewportClient.ESplitScreenType SplitType)
	{
		// stub
	}
	
	public virtual /*event */void LayoutPlayers()
	{
		// stub
	}
	
	public virtual /*event */bool GetSubtitleRegion(ref Object.Vector2D MinPos, ref Object.Vector2D MaxPos)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */int ConvertLocalPlayerToGamePlayerIndex(LocalPlayer LPlayer)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool HasTopSafeZone(int LocalPlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool HasBottomSafeZone(int LocalPlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool HasLeftSafeZone(int LocalPlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool HasRightSafeZone(int LocalPlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void GetPixelSizeOfScreen(ref float out_Width, ref float out_Height, Canvas Canvas, int LocalPlayerIndex)
	{
		// stub
	}
	
	public virtual /*final function */void CalculateSafeZoneValues(ref float out_Horizontal, ref float out_Vertical, Canvas Canvas, int LocalPlayerIndex, bool bUseMaxPercent)
	{
		// stub
	}
	
	public virtual /*final function */float CalculateDeadZone(LocalPlayer LPlayer, GameViewportClient.ESafeZoneType SZType, Canvas Canvas, /*optional */bool? _bUseMaxPercent = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void CalculatePixelCenter(ref float out_CenterX, ref float out_CenterY, LocalPlayer LPlayer, Canvas Canvas, /*optional */bool? _bUseMaxPercent = default)
	{
		// stub
	}
	
	public virtual /*event */void Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void DrawTitleSafeArea(Canvas Canvas)
	{
		// stub
	}
	
	public virtual /*event */void PostRender(Canvas Canvas)
	{
		// stub
	}
	
	public virtual /*function */void DrawTransition(Canvas Canvas)
	{
		// stub
	}
	
	public virtual /*function */void DrawTransitionMessage(Canvas Canvas, String Message)
	{
		// stub
	}
	
	public virtual /*final function */void NotifyPlayerAdded(int PlayerIndex, LocalPlayer AddedPlayer)
	{
		// stub
	}
	
	public virtual /*final function */void NotifyPlayerRemoved(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
		// stub
	}
	
	public virtual /*private final function */void AddLocalPlayer(LocalPlayer NewPlayer)
	{
		// stub
	}
	
	public virtual /*private final function */void RemoveLocalPlayer(LocalPlayer ExistingPlayer)
	{
		// stub
	}
	
	public GameViewportClient()
	{
		// Object Offset:0x0033C642
		UIControllerClass = ClassT<UIInteraction>()/*Ref Class'UIInteraction'*/;
		ShowFlags = default;
		LoadingMessage = "LOADING";
		SavingMessage = "SAVING";
		ConnectingMessage = "CONNECTING";
		PausedMessage = "PAUSED";
		PrecachingMessage = "PRECACHING";
		TitleSafeZone = new GameViewportClient.TitleSafeZoneArea
		{
			MaxPercentX = 0.90f,
			MaxPercentY = 0.90f,
			RecommendedPercentX = 0.80f,
			RecommendedPercentY = 0.80f,
		};
		SplitscreenInfo = new array<GameViewportClient.SplitscreenData>
		{
			new GameViewportClient.SplitscreenData
			{
				PlayerData = new array<GameViewportClient.PerPlayerSplitscreenData>
				{
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 1.0f,
						SizeY = 1.0f,
						OriginX = 0.0f,
						OriginY = 0.0f,
					},
				},
			},
			new GameViewportClient.SplitscreenData
			{
				PlayerData = new array<GameViewportClient.PerPlayerSplitscreenData>
				{
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 1.0f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 1.0f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.50f,
					},
				},
			},
			new GameViewportClient.SplitscreenData
			{
				PlayerData = new array<GameViewportClient.PerPlayerSplitscreenData>
				{
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 1.0f,
						OriginX = 0.0f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 1.0f,
						OriginX = 0.50f,
						OriginY = 0.0f,
					},
				},
			},
			new GameViewportClient.SplitscreenData
			{
				PlayerData = new array<GameViewportClient.PerPlayerSplitscreenData>
				{
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 1.0f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.50f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.50f,
						OriginY = 0.50f,
					},
				},
			},
			new GameViewportClient.SplitscreenData
			{
				PlayerData = new array<GameViewportClient.PerPlayerSplitscreenData>
				{
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.50f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 1.0f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.50f,
					},
				},
			},
			new GameViewportClient.SplitscreenData
			{
				PlayerData = new array<GameViewportClient.PerPlayerSplitscreenData>
				{
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.50f,
						OriginY = 0.0f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.0f,
						OriginY = 0.50f,
					},
					new GameViewportClient.PerPlayerSplitscreenData
					{
						SizeX = 0.50f,
						SizeY = 0.50f,
						OriginX = 0.50f,
						OriginY = 0.50f,
					},
				},
			},
		};
		SplitscreenType = GameViewportClient.ESplitScreenType.eSST_NOVALUE;
		Default2PSplitType = GameViewportClient.ESplitScreenType.eSST_2P_HORIZONTAL;
		Default3PSplitType = GameViewportClient.ESplitScreenType.eSST_3P_FAVOR_TOP;
		SubtitleMinRegion = new Vector2D
		{
			X=0.0f,
			Y=0.150f
		};
		SubtitleMaxRegion = new Vector2D
		{
			X=1.0f,
			Y=0.850f
		};
	}
}
}