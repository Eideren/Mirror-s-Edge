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
		public /*init */name CurrentRepeatKey;
		public /*init */Object.Double NextRepeatTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00441F7C
	//		CurrentRepeatKey = (name)"None";
	//		NextRepeatTime = default;
	//	}
	};
	
	public partial struct /*native transient */UIAxisEmulationData// extends UIKeyRepeatData
	{
		public /*init */name CurrentRepeatKey;
		public /*init */Object.Double NextRepeatTime;
	
		public /*init */bool bEnabled;
			// Object Offset:0x00441F7C
	//		CurrentRepeatKey = (name)"None";
	//		NextRepeatTime = default;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public new GameViewportClient Outer => base.Outer as GameViewportClient;
	
	public /*private native const noexport */Object.Pointer VfTable_FExec;
	public /*private native const noexport */Object.Pointer VfTable_FGlobalDataStoreClientManager;
	public Core.ClassT<GameUISceneClient> SceneClientClass;
	public /*const transient */GameUISceneClient SceneClient;
	public /*config */String UISkinName;
	public /*config */array</*config */name> UISoundCueNames;
	public /*transient */array<name> SupportedDoubleClickKeys;
	public /*const transient */DataStoreClient DataStoreManager;
	public /*const transient */UIInputConfiguration UIInputConfig;
	public /*native const transient *//*map<0,0>*/map<object, object> WidgetInputAliasLookupTable;
	public /*const transient */bool bProcessInput;
	public /*const config */bool bDisableToolTips;
	public /*const config */bool bFocusOnActive;
	public /*const config */bool bCaptureUnprocessedInput;
	public /*const config */bool bFocusedStateRules;
	public /*const transient */bool bIsUIPrimitiveSceneInitialized;
	public /*const config */float UIJoystickDeadZone;
	public /*const config */float UIAxisMultiplier;
	public /*const config */float AxisRepeatDelay;
	public /*const config */float MouseButtonRepeatDelay;
	public /*const config */float DoubleClickTriggerSeconds;
	public /*const config */int DoubleClickPixelTolerance;
	public /*const config */float ToolTipInitialDelaySeconds;
	public /*const config */float ToolTipExpirationSeconds;
	public /*const transient */UIInteraction.UIKeyRepeatData MouseButtonRepeatInfo;
	public /*native const transient *//*map<0,0>*/map<object, object> AxisEmulationDefinitions;
	public /*transient */StaticArray<UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData, UIInteraction.UIAxisEmulationData>/*[4]*/ AxisInputEmulation;
	public /*native const transient */Object.Pointer CanvasScene;
	
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
		return default;
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