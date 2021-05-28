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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameUISceneClient::execGetTransientScene(FFrame&, void* const)
	public virtual /*native final function */UIScene GetTransientScene()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameUISceneClient::execCreateScene(FFrame&, void* const)
	public virtual /*native final function */UIScene CreateScene(Core.ClassT<UIScene> SceneClass, /*optional */name SceneTag = default, /*optional */UIScene SceneTemplate = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameUISceneClient::execCreateTransientWidget(FFrame&, void* const)
	public virtual /*native final function */UIObject CreateTransientWidget(Core.ClassT<UIObject> WidgetClass, name WidgetTag, /*optional */UIObject Owner = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameUISceneClient::execFindSceneByTag(FFrame&, void* const)
	public virtual /*native final function */UIScene FindSceneByTag(name SceneTag, /*optional */LocalPlayer SceneOwner = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameUISceneClient::execRequestInputProcessingUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestInputProcessingUpdate()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UGameUISceneClient::execRequestCursorRenderUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestCursorRenderUpdate()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UGameUISceneClient::execRequestPausedUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestPausedUpdate()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UGameUISceneClient::execCanUnpauseInternalUI(FFrame&, void* const)
	public virtual /*native final function */bool CanUnpauseInternalUI()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UGameUISceneClient::execSetActiveControl(FFrame&, void* const)
	public virtual /*native function */bool SetActiveControl(UIObject NewActiveControl)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void ActivateBGSaturation(bool bActive, int Mask)
	{
	
	}
	
	public virtual /*event */void ConditionalPause(bool bDesiredPauseState)
	{
	
	}
	
	public virtual /*event */bool CanShowToolTips()
	{
	
		return default;
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
	
	public virtual /*function */void NotifyPlayerAdded(int PlayerIndex, LocalPlayer AddedPlayer)
	{
	
	}
	
	public virtual /*function */void NotifyPlayerRemoved(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
	
	}
	
	public override /*function */UIScene GetActiveScene()
	{
	
		return default;
	}
	
	public virtual /*function */void SaveMenuProgression()
	{
	
	}
	
	public virtual /*function */void ClearMenuProgression()
	{
	
	}
	
	public virtual /*function */void RestoreMenuProgression(/*optional */UIScene BaseScene = default)
	{
	
	}
	
	public virtual /*exec function */void ShowDockingStacks()
	{
	
	}
	
	public virtual /*exec function */void ShowRenderBounds()
	{
	
	}
	
	public virtual /*exec function */void ShowMenuStates()
	{
	
	}
	
	public virtual /*exec function */void ToggleDebugInput(/*optional */bool bEnable = default)
	{
	
	}
	
	public virtual /*exec function */void CreateMenu(Core.ClassT<UIScene> SceneClass, /*optional */int PlayerIndex = default)
	{
	
	}
	
	public virtual /*exec function */void OpenMenu(string MenuPath, /*optional */int PlayerIndex = default)
	{
	
	}
	
	public virtual /*exec function */void CloseMenu(name SceneName)
	{
	
	}
	
	public virtual /*exec function */void ShowDataStoreField(string DataStoreMarkup)
	{
	
	}
	
	public virtual /*exec function */void RefreshFormatting()
	{
	
	}
	
	public virtual /*exec function */void ShowDataStores(/*optional */bool bVerbose = default)
	{
	
	}
	
	public virtual /*exec function */void ShowMenuProgression()
	{
	
	}
	
	public virtual /*function */void AnimSubscribe(UIObject Target)
	{
	
	}
	
	public virtual /*function */void AnimUnSubscribe(UIObject Target)
	{
	
	}
	
	public virtual /*function */UIAnimationSeq AnimLookupSequence(name SequenceName)
	{
	
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