namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineGhostStorageManager : TdGhostStorageManager/*
		native
		config(Game)*/{
	public /*private const */String GhostFilePrefix;
	public /*private config */int MaxFilesInLocker;
	public /*private config */int MaxGhostsDeletedPerSweep;
	public /*private transient */OnlineFileLockerInterface LockerIF;
	public /*private transient */OnlineSubsystem.OnlineFileLockerFile OnlineGhostFileWrite;
	public /*private transient */int UsedGhostTag;
	public /*private transient */array<OnlineSubsystem.OnlineFileLockerFileInfo> FileList;
	public /*private transient */TdOnlineStatsReadAllStretches StatsRead;
	public /*private transient */OnlineSubsystem.UniqueNetId PlayerId;
	public /*private transient */OnlineStatsInterface StatsIF;
	public /*private transient */int StatReadIndex;
	public /*private transient */int FileDeletionIndex;
	public /*private transient */array<int> GhostReferences;
	public /*private transient */array<int> GhostFiletags;
	public /*private transient */array<int> UnusedTags;
	public /*private transient */OnlineSubsystem.OnlineFileLockerFile OnlineGhostFileRead;
	
	public override /*function */void OnConnectionLost()
	{
	
	}
	
	public override /*function */bool ReadGhost(TdGhost.TdGhostInfo GhostInfo, /*delegate*/TdGhostStorageManager.OnReadGhostComplete ReadCompleted)
	{
	
		return default;
	}
	
	public override /*function */bool WriteGhost(TdGhost Ghost, OnlineSubsystem.UniqueNetId InPlayerId, /*delegate*/TdGhostStorageManager.OnWriteGhostComplete WriteCompleted)
	{
	
		return default;
	}
	
	public virtual /*private final function */void FetchLockerCompleteCallbackRead(bool bSuccess)
	{
	
	}
	
	public virtual /*private final function */void ReadGhostCompleteCallback(bool bSuccess)
	{
	
	}
	
	public virtual /*private final function */void FetchLockerCompleteCallbackWrite(bool Success)
	{
	
	}
	
	public virtual /*private final function */void CleanLocker()
	{
	
	}
	
	public virtual /*private final function */void RunStatReads()
	{
	
	}
	
	public virtual /*private final function */void OnStatReadDone(bool bSuccess)
	{
	
	}
	
	public virtual /*private final function */void DeleteUnreferencedFiles()
	{
	
	}
	
	public virtual /*private final function */void RunFileDeletions()
	{
	
	}
	
	public virtual /*private final function */void OnFileDeleted(bool bSuccess)
	{
	
	}
	
	public virtual /*private final function */void TryWriteFile()
	{
	
	}
	
	public virtual /*private final function */void WriteGhostCompleteCallback(bool bSuccess)
	{
	
	}
	
	public virtual /*private final function */int GetNewGhostTag()
	{
	
		return default;
	}
	
	public virtual /*private final function */void ExtractGhostReferences(TdOnlineStatsRead Stats)
	{
	
	}
	
	// Export UTdOnlineGhostStorageManager::execFindUnusedTags(FFrame&, void* const)
	public virtual /*private native final function */void FindUnusedTags()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdOnlineGhostStorageManager::execGetCachedGhost(FFrame&, void* const)
	public virtual /*private native final function */TdGhost GetCachedGhost(TdGhost.TdGhostInfo GhostInfo)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdOnlineGhostStorageManager::execCacheGhost(FFrame&, void* const)
	public virtual /*private native final function */void CacheGhost(TdGhost.TdGhostInfo GhostInfo, ref array<byte> GhostBytes)
	{
		#warning NATIVE FUNCTION !
	}
	
	public TdOnlineGhostStorageManager()
	{
		// Object Offset:0x006026C6
		GhostFilePrefix = "tdttghost_";
		MaxFilesInLocker = 150;
		MaxGhostsDeletedPerSweep = 10;
		UsedGhostTag = -1;
	}
}
}