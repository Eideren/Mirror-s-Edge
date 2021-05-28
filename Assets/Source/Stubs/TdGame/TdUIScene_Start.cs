namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Start : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public UIScene MainMenuScene;
	public /*transient */UILabel PressStartLabel;
	public /*transient */UISafeRegionPanel SafeRegionPanel;
	public /*transient */byte StoredLocalUserNum;
	public /*transient */TsSystem.ETsResult SaveInitResult;
	public /*transient */float TimeElapsed;
	public /*config transient */string MovieName;
	public /*config transient */float TimeTillAttractMovie;
	public /*transient */bool bBlockAttractMode;
	public /*transient */bool bSkippedfirstTick;
	public /*config */bool bGoToLoadGame;
	public /*transient */float TimeElapsedInScene;
	public /*config transient */float TimeTillStartButton;
	public /*transient */TdInitSaveSystem InitSaveSystem;
	public /*transient */TdUIScene_MessageBox ModalInitSavefileMessageBox;
	public /*private transient */string SaveErrorMessageBody;
	public /*private transient */string SaveErrorMessageTitle;
	public /*transient */UIScene LoadLevelScene;
	
	// Export UTdUIScene_Start::execStopMovie(FFrame&, void* const)
	public override /*native function */void StopMovie()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void RebootReasonSigninChangeTitle_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnRebootErrorMessageCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public virtual /*private final function */void CheckProfile()
	{
	
	}
	
	public virtual /*private final function */void OnUIChanged(bool bIsOpening)
	{
	
	}
	
	public virtual /*private final function */void ShowNoProfileErrorBox()
	{
	
	}
	
	public virtual /*private final function */void ShowNoProfileErrorBox_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowNoProfileErrorBox(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowSaveInfoBox()
	{
	
	}
	
	public virtual /*private final function */void ShowSaveInfoBox_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowSaveInfoBox(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void InitSavefileSystem(/*optional */bool bAutoReplaceCorrupt = default)
	{
	
	}
	
	public virtual /*private final function */void OnInitSavefileSystemDone()
	{
	
	}
	
	public virtual /*private final function */void StartGameNoSave()
	{
	
	}
	
	public virtual /*private final function */void StartGame()
	{
	
	}
	
	public TdUIScene_Start()
	{
		// Object Offset:0x006AECBC
		MovieName = "Attract_Movie";
		TimeTillAttractMovie = 90.0f;
		TimeTillStartButton = 4.0f;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_Start.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_Start.SceneEventComponent'*/;
	}
}
}