namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTimeTrialRaceLauncher : Object/* within TdUIScene*/{
	public new TdUIScene Outer => base.Outer as TdUIScene;
	
	public/*private*/ UIDataStore_TdTimeTrialData TimeTrialData;
	public/*private*/ TdUIScene_LoadIndicator LoadIndicator;
	public/*private*/ bool bDataReadCorrectly;
	public/*private*/ bool bStartOnlineMode;
	public/*private*/ TdGhostStorageManager.EGhostStorageResult GhostReadResult;
	public/*private*/ String ErrorTitle;
	public/*private*/ String ErrorMessage;
	public/*private*/ int RaceModeId;
	[transient] public LocalPlayer PlayerOwner;
	public /*delegate*/TdTimeTrialRaceLauncher.OnLoadMessageDone __OnLoadMessageDone__Delegate;
	public /*delegate*/TdTimeTrialRaceLauncher.OnRaceLauncherFinished __OnRaceLauncherFinished__Delegate;
	
	public delegate void OnLoadMessageDone();
	
	public delegate void OnRaceLauncherFinished(int Result);
	
	public virtual /*function */void StartStretch(int InRaceModeId, bool bOnlineMode, LocalPlayer Player, /*delegate*/TdTimeTrialRaceLauncher.OnRaceLauncherFinished OnFinish)
	{
		// stub
	}
	
	public virtual /*function */void OnTransitionDoneStartStretch(UIScene OpenedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void OnStretchDataReadComplete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void OnOpenGhostComplete(TdGhostStorageManager.EGhostStorageResult Result)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowLoadMessage(/*delegate*/TdUIScene.OnSceneFullyOpened SceneDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowLoadMessage_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadMessageClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void CloseLoadMessage()
	{
		// stub
	}
	
	public virtual /*private final function */void OnStartStretch()
	{
		// stub
	}
	
	public virtual /*function */void OnDataReadFailed_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnGhostReadFailed_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnGhostLoadMsgBoxPreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnGhostLoadFailedAccept(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadFailedQuitToMain(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void SetErrorMessage(String Title, String Message)
	{
		// stub
	}
	
}
}