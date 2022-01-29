namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIInteraction : Interaction/* within GameViewportClient*//*
		transient
		native
		config(UI)
		hidecategories(Object,UIRoot)*/{
	public const string DEFAULT_UISKIN = "DefaultUISkin.DefaultSkin";
	
	public partial struct /*native transient */UIKeyRepeatData
	{
		[init] public name CurrentRepeatKey;
		[init] public Object.Double NextRepeatTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00441F7C
	//		CurrentRepeatKey = (name)"None";
	//		NextRepeatTime = default;
	//	}
	};
	
	public partial struct /*native transient */UIAxisEmulationData// extends UIKeyRepeatData
	{
		[init] public name CurrentRepeatKey;
		[init] public Object.Double NextRepeatTime;
	
		[init] public bool bEnabled;
			// Object Offset:0x00441F7C
	//		CurrentRepeatKey = (name)"None";
	//		NextRepeatTime = default;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public new GameViewportClient Outer => base.Outer as GameViewportClient;
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FExec;
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FGlobalDataStoreClientManager;
	public Core.ClassT<GameUISceneClient> SceneClientClass;
	[Const, transient] public GameUISceneClient SceneClient;
	[config] public String UISkinName;
	[config] public array</*config */name> UISoundCueNames;
	[transient] public array<name> SupportedDoubleClickKeys;
	[Const, transient] public DataStoreClient DataStoreManager;
	[Const, transient] public UIInputConfiguration UIInputConfig;
	[native, Const, transient] public /*map<0,0>*/map<object, object> WidgetInputAliasLookupTable;
	[Const, transient] public bool bProcessInput;
	[Const, config] public bool bDisableToolTips;
	[Const, config] public bool bFocusOnActive;
	[Const, config] public bool bCaptureUnprocessedInput;
	[Const, config] public bool bFocusedStateRules;
	[Const, transient] public bool bIsUIPrimitiveSceneInitialized;
	[Const, config] public float UIJoystickDeadZone;
	[Const, config] public float UIAxisMultiplier;
	[Const, config] public float AxisRepeatDelay;
	[Const, config] public float MouseButtonRepeatDelay;
	[Const, config] public float DoubleClickTriggerSeconds;
	[Const, config] public int DoubleClickPixelTolerance;
	[Const, config] public float ToolTipInitialDelaySeconds;
	[Const, config] public float ToolTipExpirationSeconds;
	[Const, transient] public UIInteraction.UIKeyRepeatData MouseButtonRepeatInfo;
	[native, Const, transient] public /*map<0,0>*/map<object, object> AxisEmulationDefinitions;
	[transient] public StaticArray<UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData>/*[4]*/ AxisInputEmulation;
	[native, Const, transient] public Object.Pointer CanvasScene;
	
	// Export UUIInteraction::execGetPlayerCount(FFrame&, void* const)
	public /*native final function */static int GetPlayerCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIInteraction::execGetPlayerIndex(FFrame&, void* const)
	public /*native final function */static int GetPlayerIndex(int ControllerId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIInteraction::execGetPlayerControllerId(FFrame&, void* const)
	public /*native final function */static int GetPlayerControllerId(int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIInteraction::execGetDataStoreClient(FFrame&, void* const)
	public /*native final function */static DataStoreClient GetDataStoreClient()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return new DataStoreClient();
	}
	
	// Export UUIInteraction::execIsMenuLevel(FFrame&, void* const)
	public /*native final function */static bool IsMenuLevel(/*optional */String? _MapName = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIInteraction::execPlayUISound(FFrame&, void* const)
	public virtual /*native final function */bool PlayUISound(name SoundCueName, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*function */void NotifyPlayerAdded(int PlayerIndex, LocalPlayer AddedPlayer)
	{
		// stub
	}
	
	public override /*function */void NotifyPlayerRemoved(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
		// stub
	}
	
	// Export UUIInteraction::execCreateTransientWidget(FFrame&, void* const)
	public virtual /*native final function */UIObject CreateTransientWidget(Core.ClassT<UIObject> WidgetClass, name WidgetTag, /*optional */UIObject _Owner = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final function */void SetMousePosition(int NewMouseX, int NewMouseY)
	{
		// stub
	}
	
	public virtual /*final function */UIScene GetTransientScene()
	{
		// stub
		return default;
	}
	
	// Export UUIInteraction::execCreateScene(FFrame&, void* const)
	public virtual /*native final function */UIScene CreateScene(Core.ClassT<UIScene> SceneClass, /*optional */name? _SceneTag = default, /*optional */UIScene _SceneTemplate = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final function */bool OpenScene(UIScene Scene, /*optional */LocalPlayer _SceneOwner/* = default*/, /*optional */ref UIScene OpenedScene/* = default*/)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool MergeScene(UIScene SourceScene, /*optional */UIScene _SceneTarget = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool CloseScene(UIScene Scene)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */UIScene FindSceneByTag(name SceneTag, /*optional */LocalPlayer _SceneOwner = default)
	{
		// stub
		return default;
	}
	
	public /*final event */static OnlineSubsystem.ELoginStatus GetLoginStatus(int ControllerId)
	{
		// stub
		return default;
	}
	
	public /*final event */static bool HasLinkConnection()
	{
		// stub
		return default;
	}
	
	public /*final event */static bool IsLoggedIn(int ControllerId, /*optional */bool? _bRequireOnlineLogin = default)
	{
		// stub
		return default;
	}
	
	public /*final event */static bool CanPlayOnline(int ControllerId)
	{
		// stub
		return default;
	}
	
	public /*final event */static OnlineSubsystem.ENATType GetNATType()
	{
		// stub
		return default;
	}
	
	public override /*function */void NotifyGameSessionEnded()
	{
		// stub
	}
	
	public UIInteraction()
	{
		// Object Offset:0x0044368E
		SceneClientClass = ClassT<GameUISceneClient>()/*Ref Class'GameUISceneClient'*/;
		UISkinName = "UI_Skins.UI_Skins_TDUISkins2";
		UISoundCueNames = new array</*config */name>
		{
			(name)"GenericError",
			(name)"MouseEnter",
			(name)"MouseExit",
			(name)"Clicked",
			(name)"Focused",
			(name)"SceneOpened",
			(name)"SceneClosed",
			(name)"ListSubmit",
			(name)"ListUp",
			(name)"ListDown",
			(name)"SliderIncrement",
			(name)"SliderDecrement",
			(name)"NavigateUp",
			(name)"NavigateDown",
			(name)"NavigateLeft",
			(name)"NavigateRight",
			(name)"CheckboxChecked",
			(name)"CheckboxUnchecked",
			(name)"Accept",
			(name)"Cancel",
			(name)"Default",
			(name)"Dialogue",
			(name)"TabChangeLeft",
			(name)"TabChangeRight",
		};
		bCaptureUnprocessedInput = true;
		UIJoystickDeadZone = 0.90f;
		UIAxisMultiplier = 1.0f;
		AxisRepeatDelay = 0.20f;
		MouseButtonRepeatDelay = 0.150f;
		DoubleClickTriggerSeconds = 0.50f;
		DoubleClickPixelTolerance = 1;
		ToolTipInitialDelaySeconds = 0.250f;
		ToolTipExpirationSeconds = 5.0f;
		AxisInputEmulation = new StaticArray<UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData>/*[4]*/()
		{ 
			[0] = new UIInteraction.UIAxisEmulationData
			{
				bEnabled = true,
				CurrentRepeatKey = (name)"None",
				NextRepeatTime = default,
			},
			[1] = new UIInteraction.UIAxisEmulationData
			{
				bEnabled = true,
				CurrentRepeatKey = (name)"None",
				NextRepeatTime = default,
			},
			[2] = new UIInteraction.UIAxisEmulationData
			{
				bEnabled = true,
				CurrentRepeatKey = (name)"None",
				NextRepeatTime = default,
			},
			[3] = new UIInteraction.UIAxisEmulationData
			{
				bEnabled = true,
				CurrentRepeatKey = (name)"None",
				NextRepeatTime = default,
			},
	 	};
	}
}
}