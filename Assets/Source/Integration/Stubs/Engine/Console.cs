namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Console : Interaction/* within GameViewportClient*//*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public const int MaxHistory = 16;
	
	public new GameViewportClient Outer => base.Outer as GameViewportClient;
	
	public LocalPlayer ConsoleTargetPlayer;
	public UIScene LargeConsoleScene;
	public UIScene MiniConsoleScene;
	public UILabel ConsoleBufferText;
	public ConsoleEntry MiniConsoleInput;
	public ConsoleEntry LargeConsoleInput;
	public Texture2D DefaultTexture_Black;
	public Texture2D DefaultTexture_White;
	[globalconfig] public name ConsoleKey;
	[globalconfig] public name TypeKey;
	[globalconfig] public int MaxScrollbackSize;
	public array<String> Scrollback;
	public int SBHead;
	public int SBPos;
	[config] public int HistoryTop;
	[config] public int HistoryBot;
	[config] public int HistoryCur;
	[config] public StaticArray<String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String>/*[16]*/ History;
	public String TypedStr;
	public int TypedStrPos;
	[transient] public bool bCaptureKeyInput;
	public bool bCtrl;
	[config] public bool bEnableUI;
	
	public override /*function */void Initialized()
	{
		// stub
	}
	
	public virtual /*function */void SetInputText(String Text)
	{
		// stub
	}
	
	public virtual /*function */void SetCursorPos(int Position)
	{
		// stub
	}
	
	public virtual /*function */void PurgeCommandFromHistory(String Command)
	{
		// stub
	}
	
	public virtual /*function */void ConsoleCommand(String Command)
	{
		// stub
	}
	
	public virtual /*function */void ClearOutput()
	{
		// stub
	}
	
	public virtual /*function */void OutputTextLine(/*coerce */String Text)
	{
		// stub
	}
	
	public virtual /*event */void OutputText(/*coerce */String Text)
	{
		// stub
	}
	
	public virtual /*function */void StartTyping(/*coerce */String Text)
	{
		// stub
	}
	
	public delegate void PostRender_Console_del(Canvas Canvas);
	public virtual PostRender_Console_del PostRender_Console { get => bfield_PostRender_Console ?? Console_PostRender_Console; set => bfield_PostRender_Console = value; } PostRender_Console_del bfield_PostRender_Console;
	public virtual PostRender_Console_del global_PostRender_Console => Console_PostRender_Console;
	public /*function */void Console_PostRender_Console(Canvas Canvas)
	{
		// stub
	}
	
	public delegate bool InputKey_del(int ControllerId, name Key, Object.EInputEvent Event, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default);
	public virtual InputKey_del InputKey { get => bfield_InputKey ?? Console_InputKey; set => bfield_InputKey = value; } InputKey_del bfield_InputKey;
	public virtual InputKey_del global_InputKey => Console_InputKey;
	public /*function */bool Console_InputKey(int ControllerId, name Key, Object.EInputEvent Event, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default)
	{
		// stub
		return default;
	}
	
	public delegate bool InputChar_del(int ControllerId, String Unicode);
	public virtual InputChar_del InputChar { get => bfield_InputChar ?? Console_InputChar; set => bfield_InputChar = value; } InputChar_del bfield_InputChar;
	public virtual InputChar_del global_InputChar => Console_InputChar;
	public /*function */bool Console_InputChar(int ControllerId, String Unicode)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsUIConsoleOpen()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsUIMiniConsoleOpen()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void FlushPlayerInput()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		PostRender_Console = null;
		InputKey = null;
		InputChar = null;
	
	}
	
	protected /*function */bool Console_Typing_InputChar(int ControllerId, String Unicode)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool Console_Typing_InputKey(int ControllerId, name Key, Object.EInputEvent Event, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default)// state function
	{
		// stub
		return default;
	}
	
	protected /*event */void Console_Typing_PostRender_Console(Canvas Canvas)// state function
	{
		// stub
	}
	
	protected /*event */void Console_Typing_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*event */void Console_Typing_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Typing()/*state Typing*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool Console_Open_InputChar(int ControllerId, String Unicode)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool Console_Open_InputKey(int ControllerId, name Key, Object.EInputEvent Event, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default)// state function
	{
		// stub
		return default;
	}
	
	protected /*event */void Console_Open_PostRender_Console(Canvas Canvas)// state function
	{
		// stub
	}
	
	protected /*event */void Console_Open_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*event */void Console_Open_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Open()/*state Open*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Typing": return Typing();
			case "Open": return Open();
			default: return base.FindState(stateName);
		}
	}
	public Console()
	{
		// Object Offset:0x002CC0C4
		DefaultTexture_Black = LoadAsset<Texture2D>("EngineResources.Black")/*Ref Texture2D'EngineResources.Black'*/;
		DefaultTexture_White = LoadAsset<Texture2D>("EngineResources.White")/*Ref Texture2D'EngineResources.White'*/;
		ConsoleKey = (name)"Tilde";
		MaxScrollbackSize = 1024;
		HistoryBot = -1;
		__OnReceivedNativeInputKey__Delegate = (ControllerId, Key, EventType, AmountDepressed, bGamepad) => InputKey(ControllerId, Key, EventType, AmountDepressed, bGamepad);
		__OnReceivedNativeInputChar__Delegate = (ControllerId, Unicode) => InputChar(ControllerId, Unicode);
	}
}
}