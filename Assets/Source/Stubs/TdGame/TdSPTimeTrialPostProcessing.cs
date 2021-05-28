namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPTimeTrialPostProcessing : TdSPPostProcessingBase/* within TdSPTimeTrialGame*/{
	public new TdSPTimeTrialGame Outer => base.Outer as TdSPTimeTrialGame;
	
	public /*private */bool bSaveGhost;
	
	public override /*function */void ProcessRace(TdTTInput RaceInput, int InStretchId, /*delegate*/TdSPPostProcessingBase.OnPostProcessDone PostProcessDone)
	{
	
	}
	
	public virtual /*function */void OnUpdateOnlineStats(UIScene OpenedScene)
	{
	
	}
	
	public virtual /*private final function */void SaveGhostCompleteCallback(TdGhostStorageManager.EGhostStorageResult Result, int GhostTag)
	{
	
	}
	
	public virtual /*private final function */void UpdateOnlineTTResult(TdTTInput TTOnlineInput, TdTTResult TTOnlineResult)
	{
	
	}
	
	public override /*protected function */void UpdateOfflineStats(TdTTInput TTOfflineInput)
	{
	
	}
	
	public virtual /*private final function */void UpdateOfflineTTResult(TdTTInput TTOfflineInput, TdTTResult TTOfflineResult)
	{
	
	}
	
	public virtual /*private final function */TdTTResult CreateTTResult(TdTTInput TTInput)
	{
	
		return default;
	}
	
	public virtual /*private final function */void UpdateTTDataStoreInfo(TdTTInput TTInput)
	{
	
	}
	
	public override /*protected function */void UpdateDataStoreAndResult(TdTTInput TTInput, bool bSaveSuccess)
	{
	
	}
	
	public override /*function */void PPOnlineConnectionLost()
	{
	
	}
	
}
}