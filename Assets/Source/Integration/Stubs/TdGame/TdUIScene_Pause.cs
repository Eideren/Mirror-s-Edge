namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Pause : TdUIScene/*
		abstract
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public TdMenuPostProcesWrapper PanelBGRenderer;
	[transient] public UIPanel ContentPanel;
	[transient] public UISafeRegionPanel SafeRegionPanel;
	[transient] public UISafeRegionPanel ScreenRegionPanel;
	[transient] public/*private*/ UILabel TitleLabel;
	[transient] public UIImage PanelBgImage;
	[transient] public array<UILabelButton> OptionButtons;
	public UIObject LastFocusedObject;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*private final function */bool NoClickDuringSave(name buttonname)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void UpdateNoClickDuringSave()
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
	
	public override /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
		// stub
	}
	
	public override /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnBack()
	{
		// stub
	}
	
	public virtual /*function */bool OnOptionButtonClicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void Quit_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void NotifyQuitMsgBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnQuit_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */bool OnResumeGameButton(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnResumeGame()
	{
		// stub
	}
	
	public override /*function */bool CloseScene(UIScene SceneToClose, /*optional */bool? _bSkipKismetNotify = default, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnOpenOptions()
	{
		// stub
	}
	
	public virtual /*function */void OnQuitToMainMenu()
	{
		// stub
	}
	
	public virtual /*function */void SetTitleLabel(String Text)
	{
		// stub
	}
	
	public virtual /*function */void OpenPanel()
	{
		// stub
	}
	
	public virtual /*function */void PanelAnimFinished(int FinishedPanelIndex, bool bPanelActive)
	{
		// stub
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*function */void UpdateSelectionField()
	{
		// stub
	}
	
	public virtual /*function */void PlayClosingAnim()
	{
		// stub
	}
	
	public override /*function */bool IsAnimatingScene()
	{
		// stub
		return default;
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_Pause()
	{
		var Default__TdUIScene_Pause_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Pause.SceneEventComponent' */;
		// Object Offset:0x0055E824
		EventProvider = Default__TdUIScene_Pause_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Pause.SceneEventComponent'*/;
	}
}
}