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
	
	public/*()*/ name SceneTag;
	public /*const transient */UISceneClient SceneClient;
	public /*const export editinline */SceneDataStore SceneData;
	public /*const transient */LocalPlayer PlayerOwner;
	public /*private const transient */UIToolTip ActiveToolTip;
	public /*private const transient */UIToolTip StandardToolTip;
	public/*(Overlays)*/ /*const */Core.ClassT<UIToolTip> DefaultToolTipClass;
	public /*private const transient */UIContextMenu ActiveContextMenu;
	public /*private const transient */UIContextMenu StandardContextMenu;
	public/*(Overlays)*/ /*const */Core.ClassT<UIContextMenu> DefaultContextMenuClass;
	public /*private native const transient */array<UIRoot.UIDockingNode> DockingStack;
	public /*private const transient */array<UIObject> RenderStack;
	public /*native const transient */Object.Map_Mirror InputSubscriptions;
	public /*transient */int LastPlayerIndex;
	public /*transient */bool bUpdateDockingStack;
	public /*transient */bool bUpdateScenePositions;
	public /*transient */bool bUpdateNavigationLinks;
	public /*transient */bool bUpdatePrimitiveUsage;
	public /*transient */bool bRefreshWidgetStyles;
	public /*transient */bool bRefreshStringFormatting;
	public /*transient */bool bIssuedPreRenderCallback;
	public /*const transient */bool bResolvingScenePositions;
	public /*const transient */bool bUsesPrimitives;
	public/*(Flags)*/ bool bDisplayCursor;
	public/*(Flags)*/ bool bRenderParentScenes;
	public/*(Flags)*/ bool bAlwaysRenderScene;
	public/*(Flags)*/ bool bPauseGameWhileActive;
	public/*(Flags)*/ bool bExemptFromAutoClose;
	public/*(Flags)*/ bool bCloseOnLevelChange;
	public/*(Flags)*/ bool bSaveSceneValuesOnClose;
	public/*(Flags)*/ bool bEnableScenePostProcessing;
	public/*(Flags)*/ bool bEnableSceneDepthTesting;
	public/*(Flags)*/ bool bRequiresNetwork;
	public/*(Flags)*/ bool bRequiresOnlineService;
	public/*(Flags)*/ bool bMenuLevelRestoresScene;
	public/*(Flags)*/ bool bFlushPlayerInput;
	public/*(Flags)*/ bool bDisableWorldRendering;
	public /*editoronly */Texture2D ScenePreview;
	public/*(Splitscreen)*/ UIRoot.EScreenInputMode SceneInputMode;
	public/*(Splitscreen)*/ UIRoot.ESplitscreenRenderMode SceneRenderMode;
	public Object.Vector2D CurrentViewportSize;
	public/*(Sound)*/ name SceneOpenedCue;
	public/*(Sound)*/ name SceneClosedCue;
	public /*private editoronly const transient */UILayerBase SceneLayerRoot;
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
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execRebuildDockingStack(FFrame&, void* const)
	public virtual /*native final function */void RebuildDockingStack()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execResolveScenePositions(FFrame&, void* const)
	public virtual /*native final function */void ResolveScenePositions()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execGetSceneDataStore(FFrame&, void* const)
	public virtual /*native final function */SceneDataStore GetSceneDataStore()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execLoadSceneDataValues(FFrame&, void* const)
	public virtual /*native final function */void LoadSceneDataValues()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execSaveSceneDataValues(FFrame&, void* const)
	public virtual /*native final function */void SaveSceneDataValues(/*optional */bool bUnbindSubscribers = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execUnbindSubscribers(FFrame&, void* const)
	public virtual /*native final function */void UnbindSubscribers()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execResolveDataStore(FFrame&, void* const)
	public virtual /*native final function */UIDataStore ResolveDataStore(name DataStoreTag, /*optional */LocalPlayer InPlayerOwner = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execGetPreviousScene(FFrame&, void* const)
	public virtual /*native final function */UIScene GetPreviousScene(/*optional */bool bRequireMatchingPlayerOwner = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execSetSceneInputMode(FFrame&, void* const)
	public virtual /*native final function */void SetSceneInputMode(UIRoot.EScreenInputMode NewInputMode)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScene::execGetWorldInfo(FFrame&, void* const)
	public virtual /*native function */WorldInfo GetWorldInfo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execIsSceneActive(FFrame&, void* const)
	public virtual /*native final function */bool IsSceneActive(/*optional */bool bTopmostScene = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execGetDefaultToolTip(FFrame&, void* const)
	public virtual /*native final function */UIToolTip GetDefaultToolTip()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execGetDefaultContextMenu(FFrame&, void* const)
	public virtual /*native final function */UIContextMenu GetDefaultContextMenu()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execGetActiveToolTip(FFrame&, void* const)
	public virtual /*native final function */UIToolTip GetActiveToolTip()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execSetActiveToolTip(FFrame&, void* const)
	public virtual /*native final function */bool SetActiveToolTip(UIToolTip NewToolTip)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execGetActiveContextMenu(FFrame&, void* const)
	public virtual /*native final function */UIContextMenu GetActiveContextMenu()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScene::execSetActiveContextMenu(FFrame&, void* const)
	public virtual /*native final function */bool SetActiveContextMenu(UIContextMenu NewContextMenu, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void SceneActivated(bool bInitialActivation)
	{
	
	}
	
	public virtual /*event */void SceneDeactivated()
	{
	
	}
	
	public virtual /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public virtual /*function */void SceneRestored()
	{
	
	}
	
	public virtual /*function */void SceneSavedForRestore()
	{
	
	}
	
	public virtual /*final event */void CalculateInputMask()
	{
	
	}
	
	public override /*event */void SetInputMask(byte NewInputMask, /*optional */bool bRecurse = default)
	{
	
	}
	
	public override /*event */void SetVisibility(bool bIsVisible)
	{
	
	}
	
	public virtual /*function */void SceneCreated(UIScene CreatedScene)
	{
	
	}
	
	public virtual /*function */void NotifyGameSessionEnded()
	{
	
	}
	
	public virtual /*function */void NotifyOnlineServiceStatusChanged(OnlineSubsystem.EOnlineServerConnectionStatus NewConnectionStatus)
	{
	
	}
	
	public virtual /*function */void NotifyLinkStatusChanged(bool bConnected)
	{
	
	}
	
	public virtual /*function */UIScene OpenScene(UIScene SceneToOpen, /*optional */UIScene.ESceneTransitionAnim SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated SceneDelegate = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool CloseScene(UIScene SceneToClose, /*optional */bool bSkipKismetNotify = default, /*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
		return default;
	}
	
	public virtual /*event */void LogDockingStack()
	{
	
	}
	
	public virtual /*function */void LogRenderBounds(int Indent)
	{
	
	}
	
	public override /*function */void LogCurrentState(int Indent)
	{
	
	}
	
	public virtual /*function */void AnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq)
	{
	
	}
	
	public UIScene()
	{
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
		EventProvider = new UIComp_Event
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
	}
}
}