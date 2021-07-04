namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCheckpointManager : Object/*
		native*/{
	public partial struct /*native */CheckpointInformation
	{
		public String MapName;
		public array<String> Checkpoints;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00534578
	//		MapName = "";
	//		Checkpoints = default;
	//	}
	};
	
	public /*private transient */String ActiveCheckpoint;
	public /*private transient */String ActiveMap;
	public /*private transient */int ActiveCheckpointWeight;
	public /*private transient */String LastSavedMap;
	public /*private transient */String LastSavedCheckpoint;
	public /*private transient */int NumProfileSaveTries;
	public /*private transient */TdPlayerController ActivePlayerController;
	public /*private transient */array<TdCheckpointManager.CheckpointInformation> CachedCheckpointInformation;
	public /*private transient */UIDataStore_TdGameData GameData;
	public bool bDebugCheckpoints;
	
	// Export UTdCheckpointManager::execFindCurrentCheckpoint(FFrame&, void* const)
	public virtual /*native final function */TdCheckpoint FindCurrentCheckpoint()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */void Initialize(UIDataStore_TdGameData TdGameData)
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileReadComplete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*function */void OnLoginChange()
	{
		// stub
	}
	
	public virtual /*function */bool CanContinueGame()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool GetContinueGame(ref String Map, ref String Checkpoint)
	{
		// stub
		return default;
	}
	
	public virtual /*event */String GetActiveCheckpoint()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetActiveCheckpoint(String NewCheckpoint)
	{
		// stub
	}
	
	public virtual /*event */String GetActiveMap()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void SetNewCheckpoint(TdCheckpoint NewCheckpoint, TdPlayerController PC, /*optional */bool? _skipSaveToDisk = default)
	{
		// stub
	}
	
	public virtual /*function */void TryWriteProfile()
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileWriteComplete(bool bSuccess)
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
	
	public virtual /*function */void ClearGameProgress()
	{
		// stub
	}
	
	public virtual /*private final event */void GetMapAndCheckpointIndex(String MapName, String CheckpointName, ref int MapIndex, ref int CheckpointIndex)
	{
		// stub
	}
	
	public virtual /*function */void CacheCheckpointInformation(UIDataStore_TdGameData TdGameData)
	{
		// stub
	}
	
}
}