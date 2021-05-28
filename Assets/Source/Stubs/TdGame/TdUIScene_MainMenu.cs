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
	
	public /*transient */UISafeRegionPanel SafeRegionPanel;
	public /*transient */UISafeRegionPanel ScreenRegionPanel;
	public StaticArray<name, name, name, name>/*[4]*/ PanelNames;
	public StaticArray<name, name, name, name>/*[4]*/ PanelBgNames;
	public StaticArray<name, name, name, name>/*[4]*/ CaptionNames;
	public StaticArray<name, name, name, name>/*[4]*/ BigCaptionNames;
	public /*transient */TdOnlineLoginHandler LoginHandler;
	public bool bIsAnimatingPanel;
	public /*private */bool bIsInitialTick;
	public /*config */bool bShowDownloadsButton;
	public /*transient */UIObject LastFocusedObject;
	public StaticArray<TdUIScene_MainMenu.TdMainMenuPanelStruct, TdUIScene_MainMenu.TdMainMenuPanelStruct, TdUIScene_MainMenu.TdMainMenuPanelStruct, TdUIScene_MainMenu.TdMainMenuPanelStruct>/*[4]*/ PanelData;
	public int CurrentPanelIndex;
	public int LastPanelIndex;
	public float DefaultStickWidth;
	public /*transient */UILabel DescriptionLabel;
	public /*transient */float TimeToFadeStart;
	public /*transient */float FadeTime;
	public /*transient */float FadeTimer;
	public /*transient */TdMenuPostProcesWrapper PanelBGRenderer;
	public /*transient */UIButton ButtonFromSceneRestored;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void InitializeWidgetsData()
	{
	
	}
	
	public virtual /*function */void ButtonStateChange(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState PreviouslyActiveState = default)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*private final function */void UpdateButtonBar(bool bAcceptVisible)
	{
	
	}
	
	public virtual /*function */void UpdateGamepadSettingVis(bool bIsVisible)
	{
	
	}
	
	public override /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_ShowFriends(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_QuitGame(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnPanelButton_Clicked(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void ConnectionLost_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnRebootErrorMessageCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public override /*event */void SceneDeactivated()
	{
	
	}
	
	public override /*function */void SceneSavedForRestore()
	{
	
	}
	
	public override /*function */void SceneRestored()
	{
	
	}
	
	public virtual /*function */bool HandleButtonClicked(UILabelButton InButton)
	{
	
		return default;
	}
	
	public virtual /*function */void OnStartGame()
	{
	
	}
	
	public virtual /*private final function */void OnStartGame_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnNewGameWarning_PreCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnNewGameWarning_Callback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OpenNewGameScene(bool bSkipPrevSceneAnim)
	{
	
	}
	
	public virtual /*function */void OnLoadLevel()
	{
	
	}
	
	public virtual /*function */void OnLoadSaveGame()
	{
	
	}
	
	public virtual /*function */bool CanContinueGame()
	{
	
		return default;
	}
	
	public virtual /*function */void OnTimeTrialRace()
	{
	
	}
	
	public virtual /*function */void OnLevelRace()
	{
	
	}
	
	public virtual /*function */void OnTimeTrialLeaderboard()
	{
	
	}
	
	public virtual /*function */void OnShowFriends()
	{
	
	}
	
	public virtual /*function */void OnShowFriendsScene_Callback(UIScene.ESceneTransitionAnim SceneAnim)
	{
	
	}
	
	public virtual /*function */void OnControlsSettings()
	{
	
	}
	
	public virtual /*function */void OnAudioSettings()
	{
	
	}
	
	public virtual /*function */void OnVideoSettings()
	{
	
	}
	
	public virtual /*function */void OnGameSettings()
	{
	
	}
	
	public virtual /*function */void OnGamepadSettings()
	{
	
	}
	
	public virtual /*function */void OnDownloads()
	{
	
	}
	
	public virtual /*function */void OnDownloads_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnAchievements()
	{
	
	}
	
	public virtual /*function */void OnCredits()
	{
	
	}
	
	public virtual /*function */void OnUnlocks()
	{
	
	}
	
	public virtual /*function */void OpenTimeTrialSceneCallback(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenTimeTrialOfflineSceneCallback(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenLevelRaceSceneCallback(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenLevelRaceOfflineSceneCallback(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenLeaderboardSceneCallback(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
	}
	
	public virtual /*function */bool OnButtonClicked_Panel0(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonClicked_Panel1(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonClicked_Panel2(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonClicked_Panel3(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*event */void Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void UpdateSelectionField()
	{
	
	}
	
	public virtual /*function */void ReadInitialWidgetValues()
	{
	
	}
	
	public virtual /*event */void SetInitialWidgetValues()
	{
	
	}
	
	public virtual /*function */void OnQuitGame()
	{
	
	}
	
	public virtual /*private final function */void OnQuitConfirm_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnQuitConfirmed(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void SwitchTab(int Dir)
	{
	
	}
	
	public virtual /*function */void SetActivePanel(int PanelIndex, /*optional */bool Silent = default)
	{
	
	}
	
	public virtual /*function */void PanelAnimFinished(int FinishedPanelIndex, bool bPanelActive)
	{
	
	}
	
	public virtual /*private final function */void SetPanelVisibility(int PanelIndex, bool bVisible)
	{
	
	}
	
	public virtual /*private final function */void SetCaptionVisibility(int PanelIndex, bool bVisible)
	{
	
	}
	
	public virtual /*function */void OnActivated(UIScene ActivatedScene, bool bInitialActivation)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_MainMenu()
	{
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
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_MainMenu.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_MainMenu.SceneEventComponent'*/;
	}
}
}