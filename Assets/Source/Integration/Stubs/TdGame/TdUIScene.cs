namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene : UIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public enum EPossibleVideoSettings 
	{
		PVS_VSyncValue,
		PVS_TextureDetail,
		PVS_WorldDetail,
		PVS_Antialiasing,
		PVS_PhysXSupport,
		PVS_MAX
	};
	
	public enum ESaturationOptions 
	{
		SATURATION_Inherit,
		SATURATION_On,
		SATURATION_ForceOff,
		SATURATION_MAX
	};
	
	public bool bPreventCloseScene;
	public/*private*/ bool bCurrentlyPlayingMovie;
	public/*private*/ bool bIsBlockingInputDuringMovie;
	[transient] public/*private*/ bool bShowingScene;
	[transient] public/*private*/ bool bHidingScene;
	[transient] public/*private*/ bool bHasBeenShown;
	[Category] public TdUIScene.ESaturationOptions SaturateBackground;
	[transient] public/*private*/ UIScene.ESceneTransitionAnim SceneTransitionAnim;
	[Category("Sound")] public name TdSceneOpenedCue;
	[Category("Sound")] public name TdSceneClosedCue;
	[transient] public UIScene MiniMenuScene;
	[transient] public UIScene SendMessageScene;
	[transient] public UIScene FriendsScene;
	[transient] public TdUIScene_MessageBox LoadingGamerCardMessageBox;
	[transient] public OnlineSubsystem.UniqueNetId GamerCardNetId;
	[transient] public TdUIButtonBar ButtonBar;
	public/*private*/ String CurrentPlayingMovieName;
	[transient] public/*private*/ String SimpleMessageBox_Message;
	[transient] public/*private*/ String SimpleMessageBox_Title;
	[transient] public/*private*/ UIScene PendingOpenScene;
	[transient] public/*private*/ UIScene PendingCloseScene;
	[transient] public/*private*/ float SceneAnimStepPos;
	[config] public/*private*/ float SceneAnimDuration;
	public /*delegate*/TdUIScene.OnMessageBoxClosedCallback __OnMessageBoxClosedCallback__Delegate;
	public /*delegate*/TdUIScene.PrivateOnShowAnimationEnded __PrivateOnShowAnimationEnded__Delegate;
	public /*delegate*/TdUIScene.PrivateOnHideAnimationEnded __PrivateOnHideAnimationEnded__Delegate;
	public /*delegate*/TdUIScene.OnSceneOpened __OnSceneOpened__Delegate;
	public /*delegate*/TdUIScene.OnSceneFullyOpened __OnSceneFullyOpened__Delegate;
	public /*delegate*/TdUIScene.OnRawPreInputKey __OnRawPreInputKey__Delegate;
	
	public /*private final */delegate void OnMessageBoxClosedCallback();
	
	public /*private final */delegate void PrivateOnShowAnimationEnded();
	
	public /*private final */delegate void PrivateOnHideAnimationEnded();
	
	public delegate void OnSceneOpened(UIScene OpenedScene, bool bInitialActivation);
	
	public delegate void OnSceneFullyOpened(UIScene OpenedScene);
	
	public delegate bool OnRawPreInputKey(/*const */ref UIRoot.InputEventParameters EventParms);
	
	// Export UTdUIScene::execIsGame(FFrame&, void* const)
	public virtual /*native function */bool IsGame()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execConvertUnicodeCharsToReadable(FFrame&, void* const)
	public virtual /*native function */void ConvertUnicodeCharsToReadable(ref String Str)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execActivateLevelEvent(FFrame&, void* const)
	public virtual /*native function */bool ActivateLevelEvent(name EventName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execGetTdPlayerController(FFrame&, void* const)
	public virtual /*native function */TdPlayerController GetTdPlayerController(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execSetScreenResolution(FFrame&, void* const)
	public virtual /*native function */void SetScreenResolution(int ResX, int ResY, bool bFullscreen)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execGetPossibleScreenResolutions(FFrame&, void* const)
	public virtual /*native function */void GetPossibleScreenResolutions(ref array<String> OutResults)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execGetPossibleAudioDevices(FFrame&, void* const)
	public virtual /*native function */void GetPossibleAudioDevices(ref array<String> OutResults)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execGetCurrentAudioDevice(FFrame&, void* const)
	public virtual /*native function */String GetCurrentAudioDevice()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execSetAudioDeviceToUse(FFrame&, void* const)
	public virtual /*native function */void SetAudioDeviceToUse(String InAudioDevice)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execSetVideoSettingValue(FFrame&, void* const)
	public virtual /*native function */void SetVideoSettingValue(TdUIScene.EPossibleVideoSettings Setting, int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execSetVideoSettingValueArray(FFrame&, void* const)
	public virtual /*native function */void SetVideoSettingValueArray(array<TdUIScene.EPossibleVideoSettings> Settings, array<int> Values)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execGetVideoSettingValue(FFrame&, void* const)
	public virtual /*native function */int GetVideoSettingValue(TdUIScene.EPossibleVideoSettings Setting)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execStartMovie(FFrame&, void* const)
	public virtual /*native function */void StartMovie(String MovieName, /*optional */bool? _bForceSkippable = default, /*optional */bool? _bBlockInput = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execStopMovie(FFrame&, void* const)
	public virtual /*native function */void StopMovie()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execUpdateMovieStatus(FFrame&, void* const)
	public virtual /*native function */void UpdateMovieStatus()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdUIScene::execIsPlayingMovie(FFrame&, void* const)
	public virtual /*native function */bool IsPlayingMovie()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execIsStreamingLevels(FFrame&, void* const)
	public virtual /*native function */bool IsStreamingLevels()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene::execTextureFullyStreamed(FFrame&, void* const)
	public virtual /*native function */bool TextureFullyStreamed(Texture2D Image)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public override /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public virtual /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
		// stub
	}
	
	public virtual /*function */void TopSceneChanged(UIScene NewTopScene)
	{
		// stub
	}
	
	public virtual /*protected final function */int GetPlayerIndex()
	{
		// stub
		return default;
	}
	
	public virtual /*protected final function */TdUIInteraction GetTdInteraction()
	{
		// stub
		return default;
	}
	
	public virtual /*protected final function */TdHUD GetTdHUD()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void PreventClose()
	{
		// stub
	}
	
	public virtual /*event */void OnPreTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*function */void ConsoleCommand(String Cmd)
	{
		// stub
	}
	
	public virtual /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */String TrimWhitespace(String InString)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String FormatTime(float Seconds)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OpenSceneByName(String SceneToOpen, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated _SceneDelegate = default)
	{
		// stub
	}
	
	public override /*function */UIScene OpenScene(UIScene SceneToOpen, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated _SceneDelegate = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCurrentScene_HideAnimationEnded()
	{
		// stub
	}
	
	public virtual /*function */UIScene FinishOpenScene(UIScene SceneToOpen)
	{
		// stub
		return default;
	}
	
	public override /*function */bool CloseScene(UIScene SceneToClose, /*optional */bool? _bSkipKismetNotify = default, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnPendingCloseScene_HideAnimationEnded()
	{
		// stub
	}
	
	public virtual /*function */void FinishCloseScene(UIScene SceneToClose)
	{
		// stub
	}
	
	public virtual /*final function */bool BeginShowAnimation(/*optional */bool? _bInitialActivation = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool BeginHideAnimation(/*optional */bool? _bClosingScene = default)
	{
		// stub
		return default;
	}
	
	public override /*function */void AnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq)
	{
		// stub
	}
	
	public virtual /*function */void SceneAnimEnded()
	{
		// stub
	}
	
	public virtual /*function */void UpdateSceneAnimVis()
	{
		// stub
	}
	
	public virtual /*function */void SetAnimatingScene(bool bShowing)
	{
		// stub
	}
	
	public virtual /*function */bool IsAnimatingScene()
	{
		// stub
		return default;
	}
	
	public virtual /*function */String ParseOption(String Options, String InKey)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OpenMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenTinyMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenImageMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenMiniMenu(/*delegate*/UIScene.OnSceneActivated MiniMenuInit)
	{
		// stub
	}
	
	public virtual /*function */void OpenAddFriend(/*delegate*/UIScene.OnSceneActivated AddFriendInit)
	{
		// stub
	}
	
	public virtual /*function */void DisplaySimpleMessageBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene.OnMessageBoxClosedCallback _OnMessageBoxClosed = default)
	{
		// stub
	}
	
	public virtual /*function */void SimpleMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void SimpleMessageBox_Callback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void ShowFriendsScene(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OnInitMessageBox_ShowFriendsScene(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OpenFriendsScene(/*delegate*/UIScene.OnSceneActivated FriendsInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void ViewGamerCard(OnlineSubsystem.UniqueNetId TargetPlayerId)
	{
		// stub
	}
	
	public virtual /*function */void OnViewGamerCardMessageBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnViewGamerCardMessageBoxFullyOpened(UIScene OpenedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void OnViewGamerCard(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*private final function */void OnViewGamerCardMessageBoxPressed(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowGamerCardFailedMessage()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowGamerCardFailedMessage_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void ViewXBoxAchievements()
	{
		// stub
	}
	
	public virtual /*function */void OnViewXBoxAchievements_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */UIDataStore FindDataStore(name DataStoreTag, /*optional */LocalPlayer _InPlayerOwner = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */UIDataStore_TdGameData GetGameDataStore()
	{
		// stub
		return default;
	}
	
	public virtual /*function */OnlineSubsystem GetOnlineSubsystem()
	{
		// stub
		return default;
	}
	
	public virtual /*function */OnlinePlayerInterface GetPlayerInterface()
	{
		// stub
		return default;
	}
	
	public virtual /*function */OnlinePlayerInterfaceEx GetPlayerInterfaceEx()
	{
		// stub
		return default;
	}
	
	public virtual /*function */OnlineStatsInterface GetStatsInterface()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdProfileSettings GetProfileSettings(/*optional */int? _PlayerIndex = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool IsControllerInput(name KeyName)
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetPlayerControllerId(int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*function */void NotifyOnlineServiceStatusChanged(OnlineSubsystem.EOnlineServerConnectionStatus NewConnectionStatus)
	{
		// stub
	}
	
	public TdUIScene()
	{
		var Default__TdUIScene_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene.SceneEventComponent' */;
		// Object Offset:0x0055B07E
		SceneAnimDuration = 0.250f;
		EventProvider = Default__TdUIScene_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene.SceneEventComponent'*/;
	}
}
}