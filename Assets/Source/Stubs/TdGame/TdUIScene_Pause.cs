namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Pause : TdUIScene/*
		abstract
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */TdMenuPostProcesWrapper PanelBGRenderer;
	public /*transient */UIPanel ContentPanel;
	public /*transient */UISafeRegionPanel SafeRegionPanel;
	public /*transient */UISafeRegionPanel ScreenRegionPanel;
	public /*private transient */UILabel TitleLabel;
	public /*transient */UIImage PanelBgImage;
	public /*transient */array<UILabelButton> OptionButtons;
	public UIObject LastFocusedObject;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*private final function */bool NoClickDuringSave(name buttonname)
	{
	
		return default;
	}
	
	public virtual /*private final function */void UpdateNoClickDuringSave()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*private final function */void UpdateButtonBar(bool bAcceptVisible)
	{
	
	}
	
	public override /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
	
	}
	
	public override /*event */void SceneDeactivated()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnBack()
	{
	
	}
	
	public virtual /*function */bool OnOptionButtonClicked(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
	
		return default;
	}
	
	public virtual /*private final function */void Quit_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void NotifyQuitMsgBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnQuit_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */bool OnResumeGameButton(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnResumeGame()
	{
	
	}
	
	public override /*function */bool CloseScene(UIScene SceneToClose, /*optional */bool bSkipKismetNotify = default, /*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
		return default;
	}
	
	public virtual /*function */void OnOpenOptions()
	{
	
	}
	
	public virtual /*function */void OnQuitToMainMenu()
	{
	
	}
	
	public virtual /*function */void SetTitleLabel(string Text)
	{
	
	}
	
	public virtual /*function */void OpenPanel()
	{
	
	}
	
	public virtual /*function */void PanelAnimFinished(int FinishedPanelIndex, bool bPanelActive)
	{
	
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public virtual /*function */void UpdateSelectionField()
	{
	
	}
	
	public virtual /*function */void PlayClosingAnim()
	{
	
	}
	
	public override /*function */bool IsAnimatingScene()
	{
	
		return default;
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_Pause()
	{
		// Object Offset:0x0055E824
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_Pause.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_Pause.SceneEventComponent'*/;
	}
}
}