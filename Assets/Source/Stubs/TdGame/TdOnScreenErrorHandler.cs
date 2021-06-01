namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnScreenErrorHandler : TpOnScreenErrorHandler{
	public /*transient */OnlineSubsystem OnlineSub;
	public /*transient */TsSystem SaveSystem;
	public /*transient */TdUIScene_MessageBox GeneralErrorMessageBox;
	public /*transient */bool IgnoreStorageChanges;
	public /*transient */TdInitSaveSystem InitSaveSystem;
	public /*private transient */String TitleErrStr;
	public /*private transient */String MessageErrStr;
	public /*private transient */int PendingConnectionChangeTicks;
	
	public override /*function */void Tick(float DeltaSeconds)
	{
	
	}
	
	public override /*function */void Initialize()
	{
	
	}
	
	public override /*function */void Finalize()
	{
	
	}
	
	public virtual /*function */void OnConnectionChange(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus)
	{
	
	}
	
	public virtual /*function */void HandleConnectionLost()
	{
	
	}
	
	public virtual /*function */void OnConnectionChange_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnLoginChange()
	{
	
	}
	
	public /*function */static void CheckRestartGame(UIDataStore_TdGameData.RebootReasonType Reason)
	{
	
	}
	
	public virtual /*function */void ShowCriticalErrorMessageBox(String UnLoc_Message)
	{
	
	}
	
	public virtual /*function */void OnShowCriticalErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnCriticalErrorMessageBoxDone(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void ShowErrorMessageBox(String UnLoc_Title, String UnLoc_Message)
	{
	
	}
	
	public virtual /*function */void OnGeneralErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
}
}