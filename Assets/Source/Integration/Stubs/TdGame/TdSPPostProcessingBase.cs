namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPPostProcessingBase : Object/* within TdSPGame*//*
		abstract*/{
	public new TdSPGame Outer => base.Outer as TdSPGame;
	
	[transient] public/*private*/ TdUIScene_LoadIndicator LoadIndicator;
	[transient] public/*private*/ TdUIScene_MessageBox ErrorMessageBox;
	public/*protected*/ String PlayerName;
	public/*protected*/ OnlineSubsystem.UniqueNetId PlayerId;
	public/*protected*/ float TotalTime;
	public/*protected*/ array<float> IntermediateTimes;
	public/*protected*/ int DistanceRun;
	public/*protected*/ float AverageSpeed;
	public/*protected*/ int TotalRating;
	public/*protected*/ int UnlockedStretch;
	public/*protected*/ int StretchId;
	public/*protected*/ int ControllerId;
	[transient] public/*private*/ bool bError;
	[transient] public/*private*/ String ErrorTitle;
	[transient] public/*private*/ String ErrorMessage;
	[transient] public/*protected*/ TdTTInput InputToProcess;
	[transient] public/*protected*/ TdTTResult TTResult;
	public/*protected*/ UIDataStore_TdTimeTrialData TTDataStore;
	public /*delegate*/TdSPPostProcessingBase.OnPostProcessDone __OnPostProcessDone__Delegate;
	public /*delegate*/TdSPPostProcessingBase.OnClosed __OnClosed__Delegate;
	
	public delegate void OnPostProcessDone(TdTTResult PostProcessingResult);
	
	public delegate void OnClosed();
	
	public virtual /*function */void ProcessRace(TdTTInput RaceInput, int InStretchId, /*delegate*/TdSPPostProcessingBase.OnPostProcessDone PostProcessDone)
	{
		// stub
	}
	
	public virtual /*protected function */void UpdateOnlineStats(TdTTInput TTOnlineInput, bool bOnlyAllTime, /*optional */int? _InGhostTag = default)
	{
		// stub
	}
	
	public virtual /*private final function */void WriteOnlineStatsCompletedCallback(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*protected function */void UpdateOfflineStats(TdTTInput TTOfflineInput)
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileWriteComplete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*protected function */void UpdateDataStoreAndResult(TdTTInput TTInput, bool bSaveSuccess)
	{
		// stub
	}
	
	public virtual /*protected final function */void FinishPostProcessing()
	{
		// stub
	}
	
	public virtual /*protected function */bool WasNewRecord(float TimeToBeat, float MyTime)
	{
		// stub
		return default;
	}
	
	public virtual /*protected function */float RoundTime(float N)
	{
		// stub
		return default;
	}
	
	public virtual /*protected function */void ShowLoadScene(/*delegate*/TdUIScene.OnSceneFullyOpened SceneFullyOpened)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowLoadScene_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*protected function */void CloseLoadScene()
	{
		// stub
	}
	
	public virtual /*protected function */void SetError(String Title, String Message)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadSceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowErrorMessageBox()
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnErrorMessageBoxClosed(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void PPOnlineConnectionLost()
	{
		// stub
	}
	
}
}