namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_MainMenu : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public enum ETdMainMenuPanel 
	{
		TDMMP_STORY,
		TDMMP_TIMETRIAL,
		TDMMP_OPTIONS,
		TDMMP_EXTRAS,
		TDMMP_MAX
	};
	
	public partial struct /*native */TdMainMenuPanelStruct
	{
		public UIPanel Panel;
		public UIImage BgImage;
		public UIButton PanelCaptionButton;
		public UIButton BigPanelCaptionButton;
		public bool bIsFocusedPanel;
		public float AnimTime;
		public float DefaultCaptionYPos;
		public float DefaultCaptionWidth;
		public float StickPosX;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0069DAB7
	//		Panel = default;
	//		BgImage = default;
	//		PanelCaptionButton = default;
	//		BigPanelCaptionButton = default;
	//		bIsFocusedPanel = false;
	//		AnimTime = 0.0f;
	//		DefaultCaptionYPos = 0.0f;
	//		DefaultCaptionWidth = 0.0f;
	//		StickPosX = 0.0f;
	//	}
	};
	
	[transient] public UISafeRegionPanel SafeRegionPanel;
	[transient] public UISafeRegionPanel ScreenRegionPanel;
	public StaticArray<name, name, name, name>/*[4]*/ PanelNames;
	public StaticArray<name, name, name, name>/*[4]*/ PanelBgNames;
	public StaticArray<name, name, name, name>/*[4]*/ CaptionNames;
	public StaticArray<name, name, name, name>/*[4]*/ BigCaptionNames;
	[transient] public TdOnlineLoginHandler LoginHandler;
	public bool bIsAnimatingPanel;
	public/*private*/ bool bIsInitialTick;
	[config] public bool bShowDownloadsButton;
	[transient] public UIObject LastFocusedObject;
	public StaticArray<TdUIScene_MainMenu.TdMainMenuPanelStruct, TdUIScene_MainMenu.TdMainMenuPanelStruct, TdUIScene_MainMenu.TdMainMenuPanelStruct, TdUIScene_MainMenu.TdMainMenuPanelStruct>/*[4]*/ PanelData;
	public int CurrentPanelIndex;
	public int LastPanelIndex;
	public float DefaultStickWidth;
	[transient] public UILabel DescriptionLabel;
	[transient] public float TimeToFadeStart;
	[transient] public float FadeTime;
	[transient] public float FadeTimer;
	[transient] public TdMenuPostProcesWrapper PanelBGRenderer;
	[transient] public UIButton ButtonFromSceneRestored;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void InitializeWidgetsData()
	{
		// stub
	}
	
	public virtual /*function */void ButtonStateChange(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*private final function */void UpdateButtonBar(bool bAcceptVisible)
	{
		// stub
	}
	
	public virtual /*function */void UpdateGamepadSettingVis(bool bIsVisible)
	{
		// stub
	}
	
	public override /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_ShowFriends(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_QuitGame(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnPanelButton_Clicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void ConnectionLost_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnRebootErrorMessageCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public override /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public override /*function */void SceneSavedForRestore()
	{
		// stub
	}
	
	public override /*function */void SceneRestored()
	{
		// stub
	}
	
	public virtual /*function */bool HandleButtonClicked(UILabelButton InButton)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnStartGame()
	{
		// stub
	}
	
	public virtual /*private final function */void OnStartGame_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnNewGameWarning_PreCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnNewGameWarning_Callback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OpenNewGameScene(bool bSkipPrevSceneAnim)
	{
		// stub
	}
	
	public virtual /*function */void OnLoadLevel()
	{
		// stub
	}
	
	public virtual /*function */void OnLoadSaveGame()
	{
		// stub
	}
	
	public virtual /*function */bool CanContinueGame()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnTimeTrialRace()
	{
		// stub
	}
	
	public virtual /*function */void OnLevelRace()
	{
		// stub
	}
	
	public virtual /*function */void OnTimeTrialLeaderboard()
	{
		// stub
	}
	
	public virtual /*function */void OnShowFriends()
	{
		// stub
	}
	
	public virtual /*function */void OnShowFriendsScene_Callback(UIScene.ESceneTransitionAnim SceneAnim)
	{
		// stub
	}
	
	public virtual /*function */void OnControlsSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnAudioSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnVideoSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnGameSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnGamepadSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnDownloads()
	{
		// stub
	}
	
	public virtual /*function */void OnDownloads_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnAchievements()
	{
		// stub
	}
	
	public virtual /*function */void OnCredits()
	{
		// stub
	}
	
	public virtual /*function */void OnUnlocks()
	{
		// stub
	}
	
	public virtual /*function */void OpenTimeTrialSceneCallback(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenTimeTrialOfflineSceneCallback(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenLevelRaceSceneCallback(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenLevelRaceOfflineSceneCallback(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OpenLeaderboardSceneCallback(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonClicked_Panel0(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonClicked_Panel1(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonClicked_Panel2(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonClicked_Panel3(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*event */void Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void UpdateSelectionField()
	{
		// stub
	}
	
	public virtual /*function */void ReadInitialWidgetValues()
	{
		// stub
	}
	
	public virtual /*event */void SetInitialWidgetValues()
	{
		// stub
	}
	
	public virtual /*function */void OnQuitGame()
	{
		// stub
	}
	
	public virtual /*private final function */void OnQuitConfirm_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnQuitConfirmed(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void SwitchTab(int Dir)
	{
		// stub
	}
	
	public virtual /*function */void SetActivePanel(int PanelIndex, /*optional */bool? _Silent = default)
	{
		// stub
	}
	
	public virtual /*function */void PanelAnimFinished(int FinishedPanelIndex, bool bPanelActive)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPanelVisibility(int PanelIndex, bool bVisible)
	{
		// stub
	}
	
	public virtual /*private final function */void SetCaptionVisibility(int PanelIndex, bool bVisible)
	{
		// stub
	}
	
	public virtual /*function */void OnActivated(UIScene ActivatedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_MainMenu()
	{
		var Default__TdUIScene_MainMenu_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_MainMenu.SceneEventComponent' */;
		// Object Offset:0x006A204B
		PanelNames = new StaticArray<name, name, name, name>/*[4]*/()
		{ 
			[0] = (name)"StoryPanel",
			[1] = (name)"TimeTrialPanel",
			[2] = (name)"OptionsPanel",
			[3] = (name)"ExtrasPanel",
	 	};
		PanelBgNames = new StaticArray<name, name, name, name>/*[4]*/()
		{ 
			[0] = (name)"StoryPanelBGImage",
			[1] = (name)"TimeTrialPanelBGImage",
			[2] = (name)"OptionsPanelBGImage",
			[3] = (name)"ExtrasPanelBGImage",
	 	};
		CaptionNames = new StaticArray<name, name, name, name>/*[4]*/()
		{ 
			[0] = (name)"StoryCaptionButton",
			[1] = (name)"TimeTrialCaptionButton",
			[2] = (name)"OptionsCaptionButton",
			[3] = (name)"ExtrasCaptionButton",
	 	};
		BigCaptionNames = new StaticArray<name, name, name, name>/*[4]*/()
		{ 
			[0] = (name)"BigStoryCaptionButton",
			[1] = (name)"BigTimeTrialCaptionButton",
			[2] = (name)"BigOptionsCaptionButton",
			[3] = (name)"BigExtrasCaptionButton",
	 	};
		bIsInitialTick = true;
		bShowDownloadsButton = true;
		DefaultStickWidth = 0.050f;
		TimeToFadeStart = 2.0f;
		FadeTime = 1.0f;
		EventProvider = Default__TdUIScene_MainMenu_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_MainMenu.SceneEventComponent'*/;
	}
}
}