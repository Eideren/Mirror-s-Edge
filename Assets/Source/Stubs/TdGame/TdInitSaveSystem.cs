namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInitSaveSystem : Object{
	public /*transient */TsSystem.ETsResult SaveInitResult;
	public /*private transient */string SaveErrorMessageBody;
	public /*private transient */string SaveErrorMessageTitle;
	public /*delegate*/TdInitSaveSystem.OnInitSavefileSystemDone __OnInitSavefileSystemDone__Delegate;
	public /*delegate*/TdInitSaveSystem.OnContinueWithoutSavingDelegate __OnContinueWithoutSavingDelegate__Delegate;
	public /*delegate*/TdInitSaveSystem.OnOverwriteDelegate __OnOverwriteDelegate__Delegate;
	public /*delegate*/TdInitSaveSystem.OnRetryDelegate __OnRetryDelegate__Delegate;
	
	public delegate void OnInitSavefileSystemDone();
	
	public virtual /*function */void InitSavefileSystem(/*optional */bool? _bAutoReplaceCorrupt = default)
	{
	
	}
	
	public virtual /*private final function */void OnSaveSystemInitialized(TsSystem.ETsResult Result)
	{
	
	}
	
	public virtual /*private final function */void ShowSaveSystemErrorBox()
	{
	
	}
	
	public virtual /*private final function */void OnSaveSystemErrorContinueWithoutSaving()
	{
	
	}
	
	public virtual /*private final function */void OnSaveSystemErrorRetry()
	{
	
	}
	
	public virtual /*private final function */void ShowXenonReselectDevice()
	{
	
	}
	
	public virtual /*private final function */void ShowXenonReselectDevice_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowXenonReselectDevice(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowXenonDeviceRemoved()
	{
	
	}
	
	public virtual /*private final function */void ShowXenonDeviceRemoved_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowXenonDeviceRemoved(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowOverwriteCorruptSavefileDialogue()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteSavefileContinueWithoutSaving()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteSavefileOverwrite()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteSavefileRetry()
	{
	
	}
	
	public virtual /*private final function */void FinishInit()
	{
	
	}
	
	public virtual /*private final function */void ReadProfile()
	{
	
	}
	
	public virtual /*private final function */void OnProfileReadComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*private final function */void ShowOverwriteCorruptProfileDialogue()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteProfileContinueWithoutSaving()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteProfileRetryRead()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteProfileOverwrite()
	{
	
	}
	
	public virtual /*private final function */void OnProfileWriteComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*private final function */void ShowProfileWriteRetryDialogue()
	{
	
	}
	
	public virtual /*private final function */void OnOverwriteProfileRetry()
	{
	
	}
	
	public virtual /*function */void FinishReadProfile()
	{
	
	}
	
	public delegate void OnContinueWithoutSavingDelegate();
	
	public delegate void OnOverwriteDelegate();
	
	public delegate void OnRetryDelegate();
	
	public virtual /*private final function */void ShowOverwriteCorruptDialogue(string Body, string Title, /*delegate*/TdInitSaveSystem.OnOverwriteDelegate Overwrite, /*delegate*/TdInitSaveSystem.OnRetryDelegate Retry)
	{
	
	}
	
	public virtual /*private final function */void ShowOverwriteCorruptDialogue_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowOverwriteCorruptDialoguePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnShowOverwriteCorruptDialogue(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowConfirmOverwriteDialogue()
	{
	
	}
	
	public virtual /*private final function */void ShowConfirmOverwriteDialogue_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowConfirmOverwriteDialoguePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnShowConfirmOverwriteDialogue(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowRetryContinueWithoutSavingDialogue(string Body, string Title, /*delegate*/TdInitSaveSystem.OnContinueWithoutSavingDelegate ContinueWithoutSaving, /*delegate*/TdInitSaveSystem.OnRetryDelegate Retry)
	{
	
	}
	
	public virtual /*private final function */void ShowRetryContinueWithoutSavingDialogue_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowRetryContinueWithoutSavingDialoguePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnRetryContinueWithoutSavingDialogue(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final simulated function */void ShowBadOwnerMsgBox()
	{
	
	}
	
	public virtual /*private final simulated function */void ShowBadOwnerMsgBox_OnInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*simulated function */void ShowBadOwnerMsgBox_OnAction(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void BlockUIInput(bool bBlock)
	{
	
	}
	
	public virtual /*private final function */TdGameUISceneClient GetSceneClient()
	{
	
		return default;
	}
	
}
}