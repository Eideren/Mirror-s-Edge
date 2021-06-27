namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameUISceneClient : UISceneClient/* within UIInteraction*//*
		transient
		native
		config(UI)
		hidecategories(Object,UIRoot)*/{
	public new UIInteraction Outer => base.Outer as UIInteraction;
	
	public /*const transient */array<UIScene> ActiveScenes;
	public /*const transient */UITexture CurrentMouseCursor;
	public /*const transient */bool bRenderCursor;
	public /*const transient */bool bUpdateInputProcessingStatus;
	public /*const transient */bool bUpdateCursorRenderStatus;
	public /*config */bool bEnableDebugInput;
	public /*const transient */bool bUpdatePausedStatus;
	public /*config */bool bRenderDebugInfo;
	public /*globalconfig */bool bRenderDebugInfoAtTop;
	public /*globalconfig */bool bRenderActiveControlInfo;
	public /*globalconfig */bool bRenderFocusedControlInfo;
	public /*globalconfig */bool bRenderTargetControlInfo;
	public /*globalconfig */bool bSelectVisibleTargetsOnly;
	public /*globalconfig */bool bInteractiveMode;
	public /*globalconfig */bool bDisplayFullPaths;
	public /*globalconfig */bool bShowWidgetPath;
	public /*globalconfig */bool bShowRenderBounds;
	public /*globalconfig */bool bShowCurrentState;
	public /*globalconfig */bool bShowMousePos;
	public /*transient */bool bInputIntercepted;
	public /*globalconfig */bool bIgnoreInputIntercepted;
	public /*config */bool bRestrictActiveControlToFocusedScene;
	public /*transient */bool bKillRestoreMenuProgression;
	public /*const transient */float LatestDeltaTime;
	public /*const transient */Object.Double DoubleClickStartTime;
	public /*const transient */Object.IntPoint DoubleClickStartPosition;
	public /*const transient */StaticArray<Texture, Texture, Texture>/*[UIRoot.EUIDefaultPenColor.UIPEN_MAX]*/ DefaultUITexture;
	public /*native const transient */Object.Map_Mirror InitialPressedKeys;
	public /*config */float OverlaySceneAlphaModulation;
	public /*const transient */UIScreenObject DebugTarget;
	public /*transient */array<UIAnimationSeq> AnimSequencePool;
	public /*transient */array<UIObject> AnimSubscribers;
	
	// Export UGameUISceneClient::execGetCurrentNetMode(FFrame&, void* const)
	public /*native final function */static WorldInfo.ENetMode GetCurrentNetMode()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameUISceneClient::execGetTransientScene(FFrame&, void* const)
	public virtual /*native final function */UIScene GetTransientScene()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameUISceneClient::execCreateScene(FFrame&, void* const)
	public virtual /*native final function */UIScene CreateScene(Core.ClassT<UIScene> SceneClass, /*optional */name? _SceneTag = default, /*optional */UIScene? _SceneTemplate = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameUISceneClient::execCreateTransientWidget(FFrame&, void* const)
	public virtual /*native final function */UIObject CreateTransientWidget(Core.ClassT<UIObject> WidgetClass, name WidgetTag, /*optional */UIObject? _Owner = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameUISceneClient::execFindSceneByTag(FFrame&, void* const)
	public virtual /*native final function */UIScene FindSceneByTag(name SceneTag, /*optional */LocalPlayer? _SceneOwner = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameUISceneClient::execRequestInputProcessingUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestInputProcessingUpdate()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UGameUISceneClient::execRequestCursorRenderUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestCursorRenderUpdate()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UGameUISceneClient::execRequestPausedUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestPausedUpdate()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UGameUISceneClient::execCanUnpauseInternalUI(FFrame&, void* const)
	public virtual /*native final function */bool CanUnpauseInternalUI()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UGameUISceneClient::execSetActiveControl(FFrame&, void* const)
	public virtual /*native function */bool SetActiveControl(UIObject NewActiveControl)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*event */void ActivateBGSaturation(bool bActive, int Mask)
	{
		// stub
	}
	
	public virtual /*event */void ConditionalPause(bool bDesiredPauseState)
	{
		// stub
	}
	
	public virtual /*event */bool CanShowToolTips()
	{
		// stub
		return default;
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
	
	public virtual /*function */void NotifyPlayerAdded(int PlayerIndex, LocalPlayer AddedPlayer)
	{
		// stub
	}
	
	public virtual /*function */void NotifyPlayerRemoved(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
		// stub
	}
	
	public override /*function */UIScene GetActiveScene()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SaveMenuProgression()
	{
		// stub
	}
	
	public virtual /*function */void ClearMenuProgression()
	{
		// stub
	}
	
	public virtual /*function */void RestoreMenuProgression(/*optional */UIScene? _BaseScene = default)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowDockingStacks()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowRenderBounds()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowMenuStates()
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleDebugInput(/*optional */bool? _bEnable = default)
	{
		// stub
	}
	
	public virtual /*exec function */void CreateMenu(Core.ClassT<UIScene> SceneClass, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*exec function */void OpenMenu(String MenuPath, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*exec function */void CloseMenu(name SceneName)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowDataStoreField(String DataStoreMarkup)
	{
		// stub
	}
	
	public virtual /*exec function */void RefreshFormatting()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowDataStores(/*optional */bool? _bVerbose = default)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowMenuProgression()
	{
		// stub
	}
	
	public virtual /*function */void AnimSubscribe(UIObject Target)
	{
		// stub
	}
	
	public virtual /*function */void AnimUnSubscribe(UIObject Target)
	{
		// stub
	}
	
	public virtual /*function */UIAnimationSeq AnimLookupSequence(name SequenceName)
	{
		// stub
		return default;
	}
	
	public GameUISceneClient()
	{
		// Object Offset:0x00338714
		bEnableDebugInput = true;
		bRenderDebugInfoAtTop = true;
		bRenderActiveControlInfo = true;
		bRenderFocusedControlInfo = true;
		bRenderTargetControlInfo = true;
		bSelectVisibleTargetsOnly = true;
		bDisplayFullPaths = true;
		bShowWidgetPath = true;
		bShowRenderBounds = true;
		bShowCurrentState = true;
		bShowMousePos = true;
		bRestrictActiveControlToFocusedScene = true;
		DefaultUITexture = new StaticArray<Texture, Texture, Texture>/*[UIRoot.EUIDefaultPenColor.UIPEN_MAX]*/()
		{ 
			[0] = LoadAsset<Texture2D>("EngineResources.White")/*Ref Texture2D'EngineResources.White'*/,
			[1] = LoadAsset<Texture2D>("EngineResources.Black")/*Ref Texture2D'EngineResources.Black'*/,
			[2] = LoadAsset<Texture2D>("EngineResources.Gray")/*Ref Texture2D'EngineResources.Gray'*/,
	 	};
		OverlaySceneAlphaModulation = 0.250f;
	}
}
}