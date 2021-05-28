namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOfflineGhostStorageManager : TdGhostStorageManager{
	public /*private */TsSystem.TsSaveData WriteData;
	
	public override /*function */bool ReadGhost(TdGhost.TdGhostInfo GhostInfo, /*delegate*/TdGhostStorageManager.OnReadGhostComplete ReadCompleted)
	{
	
		return default;
	}
	
	public virtual /*private final function */void LocalReadComplete(TsSystem.ETsResult Result, array<byte> ReadBuffer)
	{
	
	}
	
	public override /*function */bool WriteGhost(TdGhost Ghost, OnlineSubsystem.UniqueNetId PlayerId, /*delegate*/TdGhostStorageManager.OnWriteGhostComplete WriteCompleted)
	{
	
		return default;
	}
	
	public virtual /*private final function */void LocalWriteComplete(TsSystem.ETsResult Result)
	{
	
	}
	
}
}