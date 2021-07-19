namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInitSaveSystem : Object{
	[transient] public TsSystem.ETsResult SaveInitResult;
	[transient] public/*private*/ String SaveErrorMessageBody;
	[transient] public/*private*/ String SaveErrorMessageTitle;
	public /*delegate*/TdInitSaveSystem.OnInitSavefileSystemDone __OnInitSavefileSystemDone__Delegate;
	public /*delegate*/TdInitSaveSystem.OnContinueWithoutSavingDelegate __OnContinueWithoutSavingDelegate__Delegate;
	public /*delegate*/TdInitSaveSystem.OnOverwriteDelegate __OnOverwriteDelegate__Delegate;
	public /*delegate*/TdInitSaveSystem.OnRetryDelegate __OnRetryDelegate__Delegate;
	
	public delegate void OnInitSavefileSystemDone();
	
	public virtual /*function */void InitSavefileSystem(/*optional */bool? _bAutoReplaceCorrupt = default)
	{
		// stub
	}
	
	public virtual /*private final function */void OnSaveSystemInitialized(TsSystem.ETsResult Result)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowSaveSystemErrorBox()
	{
		// stub
	}
	
	public virtual /*private final function */void OnSaveSystemErrorContinueWithoutSaving()
	{
		// stub
	}
	
	public virtual /*private final function */void OnSaveSystemErrorRetry()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowXenonReselectDevice()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowXenonReselectDevice_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowXenonReselectDevice(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowXenonDeviceRemoved()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowXenonDeviceRemoved_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowXenonDeviceRemoved(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowOverwriteCorruptSavefileDialogue()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteSavefileContinueWithoutSaving()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteSavefileOverwrite()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteSavefileRetry()
	{
		// stub
	}
	
	public virtual /*private final function */void FinishInit()
	{
		// stub
	}
	
	public virtual /*private final function */void ReadProfile()
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileReadComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowOverwriteCorruptProfileDialogue()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteProfileContinueWithoutSaving()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteProfileRetryRead()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteProfileOverwrite()
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileWriteComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowProfileWriteRetryDialogue()
	{
		// stub
	}
	
	public virtual /*private final function */void OnOverwriteProfileRetry()
	{
		// stub
	}
	
	public virtual /*function */void FinishReadProfile()
	{
		// stub
	}
	
	public delegate void OnContinueWithoutSavingDelegate();
	
	public delegate void OnOverwriteDelegate();
	
	public delegate void OnRetryDelegate();
	
	public virtual /*private final function */void ShowOverwriteCorruptDialogue(String Body, String Title, /*delegate*/TdInitSaveSystem.OnOverwriteDelegate Overwrite, /*delegate*/TdInitSaveSystem.OnRetryDelegate Retry)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowOverwriteCorruptDialogue_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowOverwriteCorruptDialoguePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowOverwriteCorruptDialogue(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowConfirmOverwriteDialogue()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowConfirmOverwriteDialogue_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowConfirmOverwriteDialoguePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowConfirmOverwriteDialogue(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowRetryContinueWithoutSavingDialogue(String Body, String Title, /*delegate*/TdInitSaveSystem.OnContinueWithoutSavingDelegate ContinueWithoutSaving, /*delegate*/TdInitSaveSystem.OnRetryDelegate Retry)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowRetryContinueWithoutSavingDialogue_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowRetryContinueWithoutSavingDialoguePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnRetryContinueWithoutSavingDialogue(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void ShowBadOwnerMsgBox()
	{
		// stub
	}
	
	public virtual /*private final simulated function */void ShowBadOwnerMsgBox_OnInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*simulated function */void ShowBadOwnerMsgBox_OnAction(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void BlockUIInput(bool bBlock)
	{
		// stub
	}
	
	public virtual /*private final function */TdGameUISceneClient GetSceneClient()
	{
		// stub
		return default;
	}
	
}
}