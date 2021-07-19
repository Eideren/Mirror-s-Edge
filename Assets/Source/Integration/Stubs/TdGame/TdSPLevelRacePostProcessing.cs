namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPLevelRacePostProcessing : TdSPPostProcessingBase/* within TdSPLevelRace*/{
	public new TdSPLevelRace Outer => base.Outer as TdSPLevelRace;
	
	public/*private*/ float QualifyingTime;
	
	public override /*function */void ProcessRace(TdTTInput RaceInput, int InStretchId, /*delegate*/TdSPPostProcessingBase.OnPostProcessDone PostProcessDone)
	{
		// stub
	}
	
	public virtual /*function */void OnUpdateOnlineStats(UIScene OpenedScene)
	{
		// stub
	}
	
	public override /*protected function */void UpdateDataStoreAndResult(TdTTInput TTInput, bool bSaveSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void UpdateOnlineTTResult(TdTTInput TTOnlineInput, TdTTResult TTOnlineResult)
	{
		// stub
	}
	
	public override /*protected function */void UpdateOfflineStats(TdTTInput TTOfflineInput)
	{
		// stub
	}
	
	public virtual /*private final function */void UpdateOfflineTTResult(TdTTInput TTOfflineInput, TdTTResult TTOfflineResult)
	{
		// stub
	}
	
	public virtual /*private final function */TdTTResult CreateTTResult(TdTTInput TTInput)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void UpdateTTDataStoreInfo(TdTTInput TTInput)
	{
		// stub
	}
	
}
}