namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScene : UIScreenObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public enum ESceneTransitionAnim 
	{
		ANIM_All,
		ANIM_Self,
		ANIM_Target,
		ANIM_None,
		ANIM_MAX
	};
	
	[Category] public name SceneTag;
	[Const, transient] public UISceneClient SceneClient;
	[Const, export, editinline] public SceneDataStore SceneData;
	[Const, transient] public LocalPlayer PlayerOwner;
	[Const, transient] public/*private*/ UIToolTip ActiveToolTip;
	[Const, transient] public/*private*/ UIToolTip StandardToolTip;
	[Category("Overlays")] [Const] public Core.ClassT<UIToolTip> DefaultToolTipClass;
	[Const, transient] public/*private*/ UIContextMenu ActiveContextMenu;
	[Const, transient] public/*private*/ UIContextMenu StandardContextMenu;
	[Category("Overlays")] [Const] public Core.ClassT<UIContextMenu> DefaultContextMenuClass;
	[native, Const, transient] public/*private*/ array<UIRoot.UIDockingNode> DockingStack;
	[Const, transient] public/*private*/ array<UIObject> RenderStack;
	[native, Const, transient] public Object.Map_Mirror InputSubscriptions;
	[transient] public int LastPlayerIndex;
	[transient] public bool bUpdateDockingStack;
	[transient] public bool bUpdateScenePositions;
	[transient] public bool bUpdateNavigationLinks;
	[transient] public bool bUpdatePrimitiveUsage;
	[transient] public bool bRefreshWidgetStyles;
	[transient] public bool bRefreshStringFormatting;
	[transient] public bool bIssuedPreRenderCallback;
	[Const, transient] public bool bResolvingScenePositions;
	[Const, transient] public bool bUsesPrimitives;
	[Category("Flags")] public bool bDisplayCursor;
	[Category("Flags")] public bool bRenderParentScenes;
	[Category("Flags")] public bool bAlwaysRenderScene;
	[Category("Flags")] public bool bPauseGameWhileActive;
	[Category("Flags")] public bool bExemptFromAutoClose;
	[Category("Flags")] public bool bCloseOnLevelChange;
	[Category("Flags")] public bool bSaveSceneValuesOnClose;
	[Category("Flags")] public bool bEnableScenePostProcessing;
	[Category("Flags")] public bool bEnableSceneDepthTesting;
	[Category("Flags")] public bool bRequiresNetwork;
	[Category("Flags")] public bool bRequiresOnlineService;
	[Category("Flags")] public bool bMenuLevelRestoresScene;
	[Category("Flags")] public bool bFlushPlayerInput;
	[Category("Flags")] public bool bDisableWorldRendering;
	[editoronly] public Texture2D ScenePreview;
	[Category("Splitscreen")] public UIRoot.EScreenInputMode SceneInputMode;
	[Category("Splitscreen")] public UIRoot.ESplitscreenRenderMode SceneRenderMode;
	public Object.Vector2D CurrentViewportSize;
	[Category("Sound")] public name SceneOpenedCue;
	[Category("Sound")] public name SceneClosedCue;
	[editoronly, Const, transient] public/*private*/ UILayerBase SceneLayerRoot;
	public /*delegate*/UIScene.GetSceneInputMode __GetSceneInputMode__Delegate;
	public /*delegate*/UIScene.OnSceneActivated __OnSceneActivated__Delegate;
	public /*delegate*/UIScene.OnSceneDeactivated __OnSceneDeactivated__Delegate;
	public /*delegate*/UIScene.OnTopSceneChanged __OnTopSceneChanged__Delegate;
	public /*delegate*/UIScene.ShouldModulateBackgroundAlpha __ShouldModulateBackgroundAlpha__Delegate;
	
	public delegate UIRoot.EScreenInputMode GetSceneInputMode();
	
	public delegate void OnSceneActivated(UIScene ActivatedScene, bool bInitialActivation);
	
	public delegate void OnSceneDeactivated(UIScene DeactivatedScene);
	
	public delegate void OnTopSceneChanged(UIScene NewTopScene);
	
	public delegate bool ShouldModulateBackgroundAlpha(ref float AlphaModulationPercent);
	
	// Export UUIScene::execForceImmediateSceneUpdate(FFrame&, void* const)
	public virtual /*native final function */void ForceImmediateSceneUpdate()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execRebuildDockingStack(FFrame&, void* const)
	public virtual /*native final function */void RebuildDockingStack()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execResolveScenePositions(FFrame&, void* const)
	public virtual /*native final function */void ResolveScenePositions()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execGetSceneDataStore(FFrame&, void* const)
	public virtual /*native final function */SceneDataStore GetSceneDataStore()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execLoadSceneDataValues(FFrame&, void* const)
	public virtual /*native final function */void LoadSceneDataValues()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execSaveSceneDataValues(FFrame&, void* const)
	public virtual /*native final function */void SaveSceneDataValues(/*optional */bool? _bUnbindSubscribers = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execUnbindSubscribers(FFrame&, void* const)
	public virtual /*native final function */void UnbindSubscribers()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execResolveDataStore(FFrame&, void* const)
	public virtual /*native final function */UIDataStore ResolveDataStore(name DataStoreTag, /*optional */LocalPlayer _InPlayerOwner = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execGetPreviousScene(FFrame&, void* const)
	public virtual /*native final function */UIScene GetPreviousScene(/*optional */bool? _bRequireMatchingPlayerOwner = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execSetSceneInputMode(FFrame&, void* const)
	public virtual /*native final function */void SetSceneInputMode(UIRoot.EScreenInputMode NewInputMode)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScene::execGetWorldInfo(FFrame&, void* const)
	public virtual /*native function */WorldInfo GetWorldInfo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execIsSceneActive(FFrame&, void* const)
	public virtual /*native final function */bool IsSceneActive(/*optional */bool? _bTopmostScene = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execGetDefaultToolTip(FFrame&, void* const)
	public virtual /*native final function */UIToolTip GetDefaultToolTip()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execGetDefaultContextMenu(FFrame&, void* const)
	public virtual /*native final function */UIContextMenu GetDefaultContextMenu()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execGetActiveToolTip(FFrame&, void* const)
	public virtual /*native final function */UIToolTip GetActiveToolTip()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execSetActiveToolTip(FFrame&, void* const)
	public virtual /*native final function */bool SetActiveToolTip(UIToolTip NewToolTip)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execGetActiveContextMenu(FFrame&, void* const)
	public virtual /*native final function */UIContextMenu GetActiveContextMenu()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScene::execSetActiveContextMenu(FFrame&, void* const)
	public virtual /*native final function */bool SetActiveContextMenu(UIContextMenu NewContextMenu, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public virtual /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SceneRestored()
	{
		// stub
	}
	
	public virtual /*function */void SceneSavedForRestore()
	{
		// stub
	}
	
	public virtual /*final event */void CalculateInputMask()
	{
		// stub
	}
	
	public override /*event */void SetInputMask(byte NewInputMask, /*optional */bool? _bRecurse = default)
	{
		// stub
	}
	
	public override /*event */void SetVisibility(bool bIsVisible)
	{
		// stub
	}
	
	public virtual /*function */void SceneCreated(UIScene CreatedScene)
	{
		// stub
	}
	
	public virtual /*function */void NotifyGameSessionEnded()
	{
		// stub
	}
	
	public virtual /*function */void NotifyOnlineServiceStatusChanged(OnlineSubsystem.EOnlineServerConnectionStatus NewConnectionStatus)
	{
		// stub
	}
	
	public virtual /*function */void NotifyLinkStatusChanged(bool bConnected)
	{
		// stub
	}
	
	public virtual /*function */UIScene OpenScene(UIScene SceneToOpen, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated _SceneDelegate = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CloseScene(UIScene SceneToClose, /*optional */bool? _bSkipKismetNotify = default, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */void LogDockingStack()
	{
		// stub
	}
	
	public virtual /*function */void LogRenderBounds(int Indent)
	{
		// stub
	}
	
	public override /*function */void LogCurrentState(int Indent)
	{
		// stub
	}
	
	public virtual /*function */void AnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq)
	{
		// stub
	}
	
	public UIScene()
	{
		var Default__UIScene_SceneInitializedEvent = new UIEvent_Initialized
		{
			// Object Offset:0x005D2AF5
			OutputLinks = new array<SequenceOp.SeqOpOutputLink>
			{
				new SequenceOp.SeqOpOutputLink
				{
					Links = default,
					LinkDesc = "Output",
					bHasImpulse = false,
					bDisabled = false,
					bDisabledPIE = false,
					LinkedOp = default,
					ActivateDelay = 0.0f,
					DrawY = 0,
					bHidden = false,
				},
			},
			ObjClassVersion = 4,
		}/* Reference: UIEvent_Initialized'Default__UIScene.SceneInitializedEvent' */;
		var Default__UIScene_SceneActivatedEvent = new UIEvent_SceneActivated
		{
			// Object Offset:0x005D2C68
			OutputLinks = new array<SequenceOp.SeqOpOutputLink>
			{
				new SequenceOp.SeqOpOutputLink
				{
					Links = default,
					LinkDesc = "Output",
					bHasImpulse = false,
					bDisabled = false,
					bDisabledPIE = false,
					LinkedOp = default,
					ActivateDelay = 0.0f,
					DrawY = 0,
					bHidden = false,
				},
			},
			ObjClassVersion = 5,
		}/* Reference: UIEvent_SceneActivated'Default__UIScene.SceneActivatedEvent' */;
		var Default__UIScene_SceneDeactivatedEvent = new UIEvent_SceneDeactivated
		{
			// Object Offset:0x005D2DB7
			OutputLinks = new array<SequenceOp.SeqOpOutputLink>
			{
				new SequenceOp.SeqOpOutputLink
				{
					Links = default,
					LinkDesc = "Output",
					bHasImpulse = false,
					bDisabled = false,
					bDisabledPIE = false,
					LinkedOp = default,
					ActivateDelay = 0.0f,
					DrawY = 0,
					bHidden = false,
				},
			},
			ObjClassVersion = 5,
		}/* Reference: UIEvent_SceneDeactivated'Default__UIScene.SceneDeactivatedEvent' */;
		var Default__UIScene_EnteredStateEvent = new UIEvent_OnEnterState
		{
		}/* Reference: UIEvent_OnEnterState'Default__UIScene.EnteredStateEvent' */;
		var Default__UIScene_LeftStateEvent = new UIEvent_OnLeaveState
		{
		}/* Reference: UIEvent_OnLeaveState'Default__UIScene.LeftStateEvent' */;
		var Default__UIScene_SceneEventComponent = new UIComp_Event
		{
			// Object Offset:0x0044AF9E
			DefaultEvents = new array<UIRoot.DefaultEventSpecification>
			{
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_Initialized>("Default__UIScene.SceneInitializedEvent")/*Ref UIEvent_Initialized'Default__UIScene.SceneInitializedEvent'*/,
					EventState = default,
				},
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_SceneActivated>("Default__UIScene.SceneActivatedEvent")/*Ref UIEvent_SceneActivated'Default__UIScene.SceneActivatedEvent'*/,
					EventState = default,
				},
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_SceneDeactivated>("Default__UIScene.SceneDeactivatedEvent")/*Ref UIEvent_SceneDeactivated'Default__UIScene.SceneDeactivatedEvent'*/,
					EventState = default,
				},
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_OnEnterState>("Default__UIScene.EnteredStateEvent")/*Ref UIEvent_OnEnterState'Default__UIScene.EnteredStateEvent'*/,
					EventState = default,
				},
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_OnLeaveState>("Default__UIScene.LeftStateEvent")/*Ref UIEvent_OnLeaveState'Default__UIScene.LeftStateEvent'*/,
					EventState = default,
				},
			},
		}/* Reference: UIComp_Event'Default__UIScene.SceneEventComponent' */;
		// Object Offset:0x0044AAC3
		DefaultToolTipClass = ClassT<UIToolTip>()/*Ref Class'UIToolTip'*/;
		DefaultContextMenuClass = ClassT<UIContextMenu>()/*Ref Class'UIContextMenu'*/;
		LastPlayerIndex = -1;
		bUpdateDockingStack = true;
		bUpdateScenePositions = true;
		bUpdateNavigationLinks = true;
		bUpdatePrimitiveUsage = true;
		bDisplayCursor = true;
		bPauseGameWhileActive = true;
		bCloseOnLevelChange = true;
		bSaveSceneValuesOnClose = true;
		bEnableScenePostProcessing = true;
		bFlushPlayerInput = true;
		SceneInputMode = UIRoot.EScreenInputMode.INPUTMODE_Locked;
		SceneRenderMode = UIRoot.ESplitscreenRenderMode.SPLITRENDER_PlayerOwner;
		CurrentViewportSize = new Vector2D
		{
			X=1024.0f,
			Y=768.0f
		};
		SceneOpenedCue = (name)"SceneOpened";
		SceneClosedCue = (name)"SceneClosed";
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
		};
		EventProvider = Default__UIScene_SceneEventComponent/*Ref UIComp_Event'Default__UIScene.SceneEventComponent'*/;
	}
}
}