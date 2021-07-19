namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Start : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public UIScene MainMenuScene;
	[transient] public UILabel PressStartLabel;
	[transient] public UISafeRegionPanel SafeRegionPanel;
	[transient] public byte StoredLocalUserNum;
	[transient] public TsSystem.ETsResult SaveInitResult;
	[transient] public float TimeElapsed;
	[config, transient] public String MovieName;
	[config, transient] public float TimeTillAttractMovie;
	[transient] public bool bBlockAttractMode;
	[transient] public bool bSkippedfirstTick;
	[config] public bool bGoToLoadGame;
	[transient] public float TimeElapsedInScene;
	[config, transient] public float TimeTillStartButton;
	[transient] public TdInitSaveSystem InitSaveSystem;
	[transient] public TdUIScene_MessageBox ModalInitSavefileMessageBox;
	[transient] public/*private*/ String SaveErrorMessageBody;
	[transient] public/*private*/ String SaveErrorMessageTitle;
	[transient] public UIScene LoadLevelScene;
	
	// Export UTdUIScene_Start::execStopMovie(FFrame&, void* const)
	public override /*native function */void StopMovie()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void RebootReasonSigninChangeTitle_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnRebootErrorMessageCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void CheckProfile()
	{
		// stub
	}
	
	public virtual /*private final function */void OnUIChanged(bool bIsOpening)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowNoProfileErrorBox()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowNoProfileErrorBox_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowNoProfileErrorBox(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowSaveInfoBox()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowSaveInfoBox_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowSaveInfoBox(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void InitSavefileSystem(/*optional */bool? _bAutoReplaceCorrupt = default)
	{
		// stub
	}
	
	public virtual /*private final function */void OnInitSavefileSystemDone()
	{
		// stub
	}
	
	public virtual /*private final function */void StartGameNoSave()
	{
		// stub
	}
	
	public virtual /*private final function */void StartGame()
	{
		// stub
	}
	
	public TdUIScene_Start()
	{
		var Default__TdUIScene_Start_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Start.SceneEventComponent' */;
		// Object Offset:0x006AECBC
		MovieName = "Attract_Movie";
		TimeTillAttractMovie = 90.0f;
		TimeTillStartButton = 4.0f;
		EventProvider = Default__TdUIScene_Start_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Start.SceneEventComponent'*/;
	}
}
}