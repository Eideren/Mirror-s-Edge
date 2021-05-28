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
		public string Text;
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
		public string StringMessage;
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
		#warning NATIVE FUNCTION !
	}
	
	// Export UHUD::execDraw2DLine(FFrame&, void* const)
	public virtual /*native final function */void Draw2DLine(int X1, int Y1, int X2, int Y2, Object.Color LineColor)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*function */void SpawnScoreBoard(Core.ClassT<ScoreBoard> ScoringType)
	{
	
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public virtual /*exec function */void ToggleHUD()
	{
	
	}
	
	public virtual /*exec function */void ShowHUD()
	{
	
	}
	
	public virtual /*exec function */void ShowScores()
	{
	
	}
	
	public virtual /*exec function */void SetShowScores(bool bNewValue)
	{
	
	}
	
	public virtual /*exec function */void ShowDebug(/*optional */name DebugType = default)
	{
	
	}
	
	public virtual /*function */bool ShouldDisplayDebug(name DebugType)
	{
	
		return default;
	}
	
	public virtual /*exec function */void FXPlay(Core.ClassT<Pawn> aClass, string FXAnimPath)
	{
	
	}
	
	public virtual /*exec function */void FXStop(Core.ClassT<Pawn> aClass)
	{
	
	}
	
	public virtual /*function */void DrawRoute(Pawn Target)
	{
	
	}
	
	public virtual /*function */void PreCalcValues()
	{
	
	}
	
	public virtual /*event */void PostRender()
	{
	
	}
	
	public virtual /*function */void DrawHUD()
	{
	
	}
	
	public virtual /*function */void DrawDemoHUD()
	{
	
	}
	
	public virtual /*function */void DrawEngineHUD()
	{
	
	}
	
	public virtual /*function */void DisplayProgressMessage()
	{
	
	}
	
	public virtual /*function */void DisplayBadConnectionAlert()
	{
	
	}
	
	public virtual /*function */void ClearMessage(ref HUD.HudLocalizedMessage M)
	{
	
	}
	
	public virtual /*function */void Message(PlayerReplicationInfo PRI, /*coerce */string msg, name MsgType, /*optional */float Lifetime = default)
	{
	
	}
	
	public virtual /*function */void DisplayConsoleMessages()
	{
	
	}
	
	public virtual /*function */void AddConsoleMessage(string M, Core.ClassT<LocalMessage> InMessageClass, PlayerReplicationInfo PRI, /*optional */float Lifetime = default)
	{
	
	}
	
	public virtual /*function */void LocalizedMessage(Core.ClassT<LocalMessage> InMessageClass, PlayerReplicationInfo RelatedPRI_1, string CriticalString, int Switch, float Position, float Lifetime, int FontSize, Object.Color DrawColor, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public virtual /*function */void AddLocalizedMessage(int Index, Core.ClassT<LocalMessage> InMessageClass, string CriticalString, int Switch, float Position, float Lifetime, int FontSize, Object.Color DrawColor, /*optional */int MessageCount = default, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public virtual /*function */void GetScreenCoords(float PosY, ref float ScreenX, ref float ScreenY, ref HUD.HudLocalizedMessage InMessage)
	{
	
	}
	
	public virtual /*function */void DrawMessage(int I, float PosY, ref float DX, ref float DY)
	{
	
	}
	
	public virtual /*function */void DrawMessageText(HUD.HudLocalizedMessage LocalMessage, float ScreenX, float ScreenY)
	{
	
	}
	
	public virtual /*function */void DisplayLocalMessages()
	{
	
	}
	
	public /*function */static Font GetFontSizeIndex(int FontSize)
	{
	
		return default;
	}
	
	public /*function */static Object.Color GetRYGColorRamp(float Pct)
	{
	
		return default;
	}
	
	public virtual /*function */void PlayerOwnerDied()
	{
	
	}
	
	public virtual /*event */void OnLostFocusPause(bool Enable)
	{
	
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