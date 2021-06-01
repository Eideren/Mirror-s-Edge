namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPPostProcessingBase : Object/* within TdSPGame*//*
		abstract*/{
	public new TdSPGame Outer => base.Outer as TdSPGame;
	
	public /*private transient */TdUIScene_LoadIndicator LoadIndicator;
	public /*private transient */TdUIScene_MessageBox ErrorMessageBox;
	public /*protected */String PlayerName;
	public /*protected */OnlineSubsystem.UniqueNetId PlayerId;
	public /*protected */float TotalTime;
	public /*protected */array<float> IntermediateTimes;
	public /*protected */int DistanceRun;
	public /*protected */float AverageSpeed;
	public /*protected */int TotalRating;
	public /*protected */int UnlockedStretch;
	public /*protected */int StretchId;
	public /*protected */int ControllerId;
	public /*private transient */bool bError;
	public /*private transient */String ErrorTitle;
	public /*private transient */String ErrorMessage;
	public /*protected transient */TdTTInput InputToProcess;
	public /*protected transient */TdTTResult TTResult;
	public /*protected */UIDataStore_TdTimeTrialData TTDataStore;
	public /*delegate*/TdSPPostProcessingBase.OnPostProcessDone __OnPostProcessDone__Delegate;
	public /*delegate*/TdSPPostProcessingBase.OnClosed __OnClosed__Delegate;
	
	public delegate void OnPostProcessDone(TdTTResult PostProcessingResult);
	
	public delegate void OnClosed();
	
	public virtual /*function */void ProcessRace(TdTTInput RaceInput, int InStretchId, /*delegate*/TdSPPostProcessingBase.OnPostProcessDone PostProcessDone)
	{
	
	}
	
	public virtual /*protected function */void UpdateOnlineStats(TdTTInput TTOnlineInput, bool bOnlyAllTime, /*optional */int? _InGhostTag = default)
	{
	
	}
	
	public virtual /*private final function */void WriteOnlineStatsCompletedCallback(bool bSuccess)
	{
	
	}
	
	public virtual /*protected function */void UpdateOfflineStats(TdTTInput TTOfflineInput)
	{
	
	}
	
	public virtual /*private final function */void OnProfileWriteComplete(bool bSuccess)
	{
	
	}
	
	public virtual /*protected function */void UpdateDataStoreAndResult(TdTTInput TTInput, bool bSaveSuccess)
	{
	
	}
	
	public virtual /*protected final function */void FinishPostProcessing()
	{
	
	}
	
	public virtual /*protected function */bool WasNewRecord(float TimeToBeat, float MyTime)
	{
	
		return default;
	}
	
	public virtual /*protected function */float RoundTime(float N)
	{
	
		return default;
	}
	
	public virtual /*protected function */void ShowLoadScene(/*delegate*/TdUIScene.OnSceneFullyOpened SceneFullyOpened)
	{
	
	}
	
	public virtual /*private final function */void OnShowLoadScene_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*protected function */void CloseLoadScene()
	{
	
	}
	
	public virtual /*protected function */void SetError(String Title, String Message)
	{
	
	}
	
	public virtual /*private final function */void OnLoadSceneClosed(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*private final function */void ShowErrorMessageBox()
	{
	
	}
	
	public virtual /*private final function */void OnShowErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnErrorMessageBoxClosed(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void PPOnlineConnectionLost()
	{
	
	}
	
}
}