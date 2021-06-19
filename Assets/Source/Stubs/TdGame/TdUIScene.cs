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
	public /*private */bool bCurrentlyPlayingMovie;
	public /*private */bool bIsBlockingInputDuringMovie;
	public /*private transient */bool bShowingScene;
	public /*private transient */bool bHidingScene;
	public /*private transient */bool bHasBeenShown;
	public/*()*/ TdUIScene.ESaturationOptions SaturateBackground;
	public /*private transient */UIScene.ESceneTransitionAnim SceneTransitionAnim;
	public/*(Sound)*/ name TdSceneOpenedCue;
	public/*(Sound)*/ name TdSceneClosedCue;
	public /*transient */UIScene MiniMenuScene;
	public /*transient */UIScene SendMessageScene;
	public /*transient */UIScene FriendsScene;
	public /*transient */TdUIScene_MessageBox LoadingGamerCardMessageBox;
	public /*transient */OnlineSubsystem.UniqueNetId GamerCardNetId;
	public /*transient */TdUIButtonBar ButtonBar;
	public /*private */String CurrentPlayingMovieName;
	public /*private transient */String SimpleMessageBox_Message;
	public /*private transient */String SimpleMessageBox_Title;
	public /*private transient */UIScene PendingOpenScene;
	public /*private transient */UIScene PendingCloseScene;
	public /*private transient */float SceneAnimStepPos;
	public /*private config */float SceneAnimDuration;
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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execConvertUnicodeCharsToReadable(FFrame&, void* const)
	public virtual /*native function */void ConvertUnicodeCharsToReadable(ref String Str)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execActivateLevelEvent(FFrame&, void* const)
	public virtual /*native function */bool ActivateLevelEvent(name EventName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execGetTdPlayerController(FFrame&, void* const)
	public virtual /*native function */TdPlayerController GetTdPlayerController(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execSetScreenResolution(FFrame&, void* const)
	public virtual /*native function */void SetScreenResolution(int ResX, int ResY, bool bFullscreen)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execGetPossibleScreenResolutions(FFrame&, void* const)
	public virtual /*native function */void GetPossibleScreenResolutions(ref array<String> OutResults)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execGetPossibleAudioDevices(FFrame&, void* const)
	public virtual /*native function */void GetPossibleAudioDevices(ref array<String> OutResults)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execGetCurrentAudioDevice(FFrame&, void* const)
	public virtual /*native function */String GetCurrentAudioDevice()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execSetAudioDeviceToUse(FFrame&, void* const)
	public virtual /*native function */void SetAudioDeviceToUse(String InAudioDevice)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execSetVideoSettingValue(FFrame&, void* const)
	public virtual /*native function */void SetVideoSettingValue(TdUIScene.EPossibleVideoSettings Setting, int Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execSetVideoSettingValueArray(FFrame&, void* const)
	public virtual /*native function */void SetVideoSettingValueArray(array<TdUIScene.EPossibleVideoSettings> Settings, array<int> Values)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execGetVideoSettingValue(FFrame&, void* const)
	public virtual /*native function */int GetVideoSettingValue(TdUIScene.EPossibleVideoSettings Setting)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execStartMovie(FFrame&, void* const)
	public virtual /*native function */void StartMovie(String MovieName, /*optional */bool? _bForceSkippable = default, /*optional */bool? _bBlockInput = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execStopMovie(FFrame&, void* const)
	public virtual /*native function */void StopMovie()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execUpdateMovieStatus(FFrame&, void* const)
	public virtual /*native function */void UpdateMovieStatus()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIScene::execIsPlayingMovie(FFrame&, void* const)
	public virtual /*native function */bool IsPlayingMovie()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execIsStreamingLevels(FFrame&, void* const)
	public virtual /*native function */bool IsStreamingLevels()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene::execTextureFullyStreamed(FFrame&, void* const)
	public virtual /*native function */bool TextureFullyStreamed(Texture2D Image)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
	
	}
	
	public override /*event */void SceneDeactivated()
	{
	
	}
	
	public virtual /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
	
	}
	
	public virtual /*function */void TopSceneChanged(UIScene NewTopScene)
	{
	
	}
	
	public virtual /*protected final function */int GetPlayerIndex()
	{
	
		return default;
	}
	
	public virtual /*protected final function */TdUIInteraction GetTdInteraction()
	{
	
		return default;
	}
	
	public virtual /*protected final function */TdHUD GetTdHUD()
	{
	
		return default;
	}
	
	public virtual /*event */void PreventClose()
	{
	
	}
	
	public virtual /*event */void OnPreTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public virtual /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public virtual /*function */void ConsoleCommand(String Cmd)
	{
	
	}
	
	public virtual /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */String TrimWhitespace(String InString)
	{
	
		return default;
	}
	
	public virtual /*function */String FormatTime(float Seconds)
	{
	
		return default;
	}
	
	public virtual /*function */void OpenSceneByName(String SceneToOpen, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated? _SceneDelegate = default)
	{
	
	}
	
	public override /*function */UIScene OpenScene(UIScene SceneToOpen, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated? _SceneDelegate = default)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCurrentScene_HideAnimationEnded()
	{
	
	}
	
	public virtual /*function */UIScene FinishOpenScene(UIScene SceneToOpen)
	{
	
		return default;
	}
	
	public override /*function */bool CloseScene(UIScene SceneToClose, /*optional */bool? _bSkipKismetNotify = default, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
		return default;
	}
	
	public virtual /*function */void OnPendingCloseScene_HideAnimationEnded()
	{
	
	}
	
	public virtual /*function */void FinishCloseScene(UIScene SceneToClose)
	{
	
	}
	
	public virtual /*final function */bool BeginShowAnimation(/*optional */bool? _bInitialActivation = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool BeginHideAnimation(/*optional */bool? _bClosingScene = default)
	{
	
		return default;
	}
	
	public override /*function */void AnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq)
	{
	
	}
	
	public virtual /*function */void SceneAnimEnded()
	{
	
	}
	
	public virtual /*function */void UpdateSceneAnimVis()
	{
	
	}
	
	public virtual /*function */void SetAnimatingScene(bool bShowing)
	{
	
	}
	
	public virtual /*function */bool IsAnimatingScene()
	{
	
		return default;
	}
	
	public virtual /*function */String ParseOption(String Options, String InKey)
	{
	
		return default;
	}
	
	public virtual /*function */void OpenMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenTinyMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenImageMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenMiniMenu(/*delegate*/UIScene.OnSceneActivated MiniMenuInit)
	{
	
	}
	
	public virtual /*function */void OpenAddFriend(/*delegate*/UIScene.OnSceneActivated AddFriendInit)
	{
	
	}
	
	public virtual /*function */void DisplaySimpleMessageBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene.OnMessageBoxClosedCallback? _OnMessageBoxClosed = default)
	{
	
	}
	
	public virtual /*function */void SimpleMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void SimpleMessageBox_Callback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void ShowFriendsScene(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OnInitMessageBox_ShowFriendsScene(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OpenFriendsScene(/*delegate*/UIScene.OnSceneActivated FriendsInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void ViewGamerCard(OnlineSubsystem.UniqueNetId TargetPlayerId)
	{
	
	}
	
	public virtual /*function */void OnViewGamerCardMessageBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnViewGamerCardMessageBoxFullyOpened(UIScene OpenedScene)
	{
	
	}
	
	public virtual /*private final function */void OnViewGamerCard(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*private final function */void OnViewGamerCardMessageBoxPressed(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowGamerCardFailedMessage()
	{
	
	}
	
	public virtual /*private final function */void ShowGamerCardFailedMessage_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void ViewXBoxAchievements()
	{
	
	}
	
	public virtual /*function */void OnViewXBoxAchievements_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */UIDataStore FindDataStore(name DataStoreTag, /*optional */LocalPlayer? _InPlayerOwner = default)
	{
	
		return default;
	}
	
	public virtual /*function */UIDataStore_TdGameData GetGameDataStore()
	{
	
		return default;
	}
	
	public virtual /*function */OnlineSubsystem GetOnlineSubsystem()
	{
	
		return default;
	}
	
	public virtual /*function */OnlinePlayerInterface GetPlayerInterface()
	{
	
		return default;
	}
	
	public virtual /*function */OnlinePlayerInterfaceEx GetPlayerInterfaceEx()
	{
	
		return default;
	}
	
	public virtual /*function */OnlineStatsInterface GetStatsInterface()
	{
	
		return default;
	}
	
	public virtual /*function */TdProfileSettings GetProfileSettings(/*optional */int? _PlayerIndex = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool IsControllerInput(name KeyName)
	{
	
		return default;
	}
	
	public virtual /*function */int GetPlayerControllerId(int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*function */void NotifyOnlineServiceStatusChanged(OnlineSubsystem.EOnlineServerConnectionStatus NewConnectionStatus)
	{
	
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