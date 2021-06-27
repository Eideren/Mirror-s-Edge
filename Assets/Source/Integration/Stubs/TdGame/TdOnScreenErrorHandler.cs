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
		// stub
	}
	
	public override /*function */void Initialize()
	{
		// stub
	}
	
	public override /*function */void Finalize()
	{
		// stub
	}
	
	public virtual /*function */void OnConnectionChange(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus)
	{
		// stub
	}
	
	public virtual /*function */void HandleConnectionLost()
	{
		// stub
	}
	
	public virtual /*function */void OnConnectionChange_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnLoginChange()
	{
		// stub
	}
	
	public /*function */static void CheckRestartGame(UIDataStore_TdGameData.RebootReasonType Reason)
	{
		// stub
	}
	
	public virtual /*function */void ShowCriticalErrorMessageBox(String UnLoc_Message)
	{
		// stub
	}
	
	public virtual /*function */void OnShowCriticalErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnCriticalErrorMessageBoxDone(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void ShowErrorMessageBox(String UnLoc_Title, String UnLoc_Message)
	{
		// stub
	}
	
	public virtual /*function */void OnGeneralErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
}
}