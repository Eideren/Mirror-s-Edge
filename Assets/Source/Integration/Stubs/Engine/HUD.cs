namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class HUD : Actor/*
		transient
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct /*native */ConsoleMessage
	{
		public String Text;
		public Object.Color TextColor;
		public float MessageLife;
		public PlayerReplicationInfo PRI;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002FA980
	//		Text = "";
	//		TextColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		MessageLife = 0.0f;
	//		PRI = default;
	//	}
	};
	
	public partial struct /*native */HudLocalizedMessage
	{
		public Core.ClassT<LocalMessage> Message;
		public String StringMessage;
		public int Switch;
		public float EndOfLife;
		public float Lifetime;
		public float PosY;
		public Object.Color DrawColor;
		public int FontSize;
		public Font StringFont;
		public float DX;
		public float DY;
		public bool Drawn;
		public int Count;
		public Object OptionalObject;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002FACAC
	//		Message = default;
	//		StringMessage = "";
	//		Switch = 0;
	//		EndOfLife = 0.0f;
	//		Lifetime = 0.0f;
	//		PosY = 0.0f;
	//		DrawColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		FontSize = 0;
	//		StringFont = default;
	//		DX = 0.0f;
	//		DY = 0.0f;
	//		Drawn = false;
	//		Count = 0;
	//		OptionalObject = default;
	//	}
	};
	
	public /*const */Object.Color WhiteColor;
	public /*const */Object.Color GreenColor;
	public /*const */Object.Color RedColor;
	public PlayerController PlayerOwner;
	public HUD HudOwner;
	public PlayerReplicationInfo ViewedInfo;
	public float ProgressFadeTime;
	public Object.Color MOTDColor;
	public ScoreBoard ScoreBoard;
	public /*transient */bool LostFocusPaused;
	public /*config */bool bShowHUD;
	public bool bShowScores;
	public bool bShowDebugInfo;
	public/*()*/ bool bShowBadConnectionAlert;
	public /*globalconfig */bool bMessageBeep;
	public /*globalconfig */float HudCanvasScale;
	public array<HUD.ConsoleMessage> ConsoleMessages;
	public /*const */Object.Color ConsoleColor;
	public /*globalconfig */int ConsoleMessageCount;
	public /*globalconfig */int ConsoleFontSize;
	public /*globalconfig */int MessageFontOffset;
	public int MaxHUDAreaMessageCount;
	public/*()*/ /*transient */StaticArray<HUD.HudLocalizedMessage, HUD.HudLocalizedMessage, HUD.HudLocalizedMessage, HUD.HudLocalizedMessage, HUD.HudLocalizedMessage, HUD.HudLocalizedMessage, HUD.HudLocalizedMessage, HUD.HudLocalizedMessage>/*[8]*/ LocalMessages;
	public/*()*/ float ConsoleMessagePosX;
	public/*()*/ float ConsoleMessagePosY;
	public Canvas Canvas;
	public /*transient */float LastHUDRenderTime;
	public /*transient */float RenderDelta;
	public /*transient */float SizeX;
	public /*transient */float SizeY;
	public /*transient */float CenterX;
	public /*transient */float CenterY;
	public /*transient */float RatioX;
	public /*transient */float RatioY;
	public /*globalconfig */array</*config */name> DebugDisplay;
	
	// Export UHUD::execDraw3DLine(FFrame&, void* const)
	public virtual /*native final function */void Draw3DLine(Object.Vector Start, Object.Vector End, Object.Color LineColor)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UHUD::execDraw2DLine(FFrame&, void* const)
	public virtual /*native final function */void Draw2DLine(int X1, int Y1, int X2, int Y2, Object.Color LineColor)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */void SpawnScoreBoard(Core.ClassT<ScoreBoard> ScoringType)
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleHUD()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowHUD()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowScores()
	{
		// stub
	}
	
	public virtual /*exec function */void SetShowScores(bool bNewValue)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowDebug(/*optional */name? _DebugType = default)
	{
		// stub
	}
	
	public virtual /*function */bool ShouldDisplayDebug(name DebugType)
	{
		// stub
		return default;
	}
	
	public virtual /*exec function */void FXPlay(Core.ClassT<Pawn> aClass, String FXAnimPath)
	{
		// stub
	}
	
	public virtual /*exec function */void FXStop(Core.ClassT<Pawn> aClass)
	{
		// stub
	}
	
	public virtual /*function */void DrawRoute(Pawn Target)
	{
		// stub
	}
	
	public virtual /*function */void PreCalcValues()
	{
		// stub
	}
	
	public virtual /*event */void PostRender()
	{
		// stub
	}
	
	public virtual /*function */void DrawHUD()
	{
		// stub
	}
	
	public virtual /*function */void DrawDemoHUD()
	{
		// stub
	}
	
	public virtual /*function */void DrawEngineHUD()
	{
		// stub
	}
	
	public virtual /*function */void DisplayProgressMessage()
	{
		// stub
	}
	
	public virtual /*function */void DisplayBadConnectionAlert()
	{
		// stub
	}
	
	public virtual /*function */void ClearMessage(ref HUD.HudLocalizedMessage M)
	{
		// stub
	}
	
	public virtual /*function */void Message(PlayerReplicationInfo PRI, /*coerce */String msg, name MsgType, /*optional */float? _Lifetime = default)
	{
		// stub
	}
	
	public virtual /*function */void DisplayConsoleMessages()
	{
		// stub
	}
	
	public virtual /*function */void AddConsoleMessage(String M, Core.ClassT<LocalMessage> InMessageClass, PlayerReplicationInfo PRI, /*optional */float? _Lifetime = default)
	{
		// stub
	}
	
	public virtual /*function */void LocalizedMessage(Core.ClassT<LocalMessage> InMessageClass, PlayerReplicationInfo RelatedPRI_1, String CriticalString, int Switch, float Position, float Lifetime, int FontSize, Object.Color DrawColor, /*optional */Object _OptionalObject = default)
	{
		// stub
	}
	
	public virtual /*function */void AddLocalizedMessage(int Index, Core.ClassT<LocalMessage> InMessageClass, String CriticalString, int Switch, float Position, float Lifetime, int FontSize, Object.Color DrawColor, /*optional */int? _MessageCount = default, /*optional */Object _OptionalObject = default)
	{
		// stub
	}
	
	public virtual /*function */void GetScreenCoords(float PosY, ref float ScreenX, ref float ScreenY, ref HUD.HudLocalizedMessage InMessage)
	{
		// stub
	}
	
	public virtual /*function */void DrawMessage(int I, float PosY, ref float DX, ref float DY)
	{
		// stub
	}
	
	public virtual /*function */void DrawMessageText(HUD.HudLocalizedMessage LocalMessage, float ScreenX, float ScreenY)
	{
		// stub
	}
	
	public virtual /*function */void DisplayLocalMessages()
	{
		// stub
	}
	
	public /*function */static Font GetFontSizeIndex(int FontSize)
	{
		// stub
		return default;
	}
	
	public /*function */static Object.Color GetRYGColorRamp(float Pct)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PlayerOwnerDied()
	{
		// stub
	}
	
	public virtual /*event */void OnLostFocusPause(bool Enable)
	{
		// stub
	}
	
	public HUD()
	{
		// Object Offset:0x002FEFF6
		WhiteColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		GreenColor = new Color
		{
			R=0,
			G=255,
			B=0,
			A=255
		};
		RedColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		ProgressFadeTime = 1.0f;
		MOTDColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		bShowHUD = true;
		bMessageBeep = true;
		HudCanvasScale = 0.950f;
		ConsoleColor = new Color
		{
			R=153,
			G=216,
			B=253,
			A=255
		};
		ConsoleMessageCount = 16;
		ConsoleFontSize = 5;
		MaxHUDAreaMessageCount = 3;
		ConsoleMessagePosY = 0.80f;
		DebugDisplay = new array</*config */name>
		{
			(name)"AI",
		};
		bHidden = true;
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}