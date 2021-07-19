namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineGhostStorageManager : TdGhostStorageManager/*
		native
		config(Game)*/{
	[Const] public/*private*/ String GhostFilePrefix;
	[config] public/*private*/ int MaxFilesInLocker;
	[config] public/*private*/ int MaxGhostsDeletedPerSweep;
	[transient] public/*private*/ OnlineFileLockerInterface LockerIF;
	[transient] public/*private*/ OnlineSubsystem.OnlineFileLockerFile OnlineGhostFileWrite;
	[transient] public/*private*/ int UsedGhostTag;
	[transient] public/*private*/ array<OnlineSubsystem.OnlineFileLockerFileInfo> FileList;
	[transient] public/*private*/ TdOnlineStatsReadAllStretches StatsRead;
	[transient] public/*private*/ OnlineSubsystem.UniqueNetId PlayerId;
	[transient] public/*private*/ OnlineStatsInterface StatsIF;
	[transient] public/*private*/ int StatReadIndex;
	[transient] public/*private*/ int FileDeletionIndex;
	[transient] public/*private*/ array<int> GhostReferences;
	[transient] public/*private*/ array<int> GhostFiletags;
	[transient] public/*private*/ array<int> UnusedTags;
	[transient] public/*private*/ OnlineSubsystem.OnlineFileLockerFile OnlineGhostFileRead;
	
	public override /*function */void OnConnectionLost()
	{
		// stub
	}
	
	public override /*function */bool ReadGhost(TdGhost.TdGhostInfo GhostInfo, /*delegate*/TdGhostStorageManager.OnReadGhostComplete ReadCompleted)
	{
		// stub
		return default;
	}
	
	public override /*function */bool WriteGhost(TdGhost Ghost, OnlineSubsystem.UniqueNetId InPlayerId, /*delegate*/TdGhostStorageManager.OnWriteGhostComplete WriteCompleted)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void FetchLockerCompleteCallbackRead(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void ReadGhostCompleteCallback(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void FetchLockerCompleteCallbackWrite(bool Success)
	{
		// stub
	}
	
	public virtual /*private final function */void CleanLocker()
	{
		// stub
	}
	
	public virtual /*private final function */void RunStatReads()
	{
		// stub
	}
	
	public virtual /*private final function */void OnStatReadDone(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void DeleteUnreferencedFiles()
	{
		// stub
	}
	
	public virtual /*private final function */void RunFileDeletions()
	{
		// stub
	}
	
	public virtual /*private final function */void OnFileDeleted(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void TryWriteFile()
	{
		// stub
	}
	
	public virtual /*private final function */void WriteGhostCompleteCallback(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */int GetNewGhostTag()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void ExtractGhostReferences(TdOnlineStatsRead Stats)
	{
		// stub
	}
	
	// Export UTdOnlineGhostStorageManager::execFindUnusedTags(FFrame&, void* const)
	public virtual /*private native final function */void FindUnusedTags()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdOnlineGhostStorageManager::execGetCachedGhost(FFrame&, void* const)
	public virtual /*private native final function */TdGhost GetCachedGhost(TdGhost.TdGhostInfo GhostInfo)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdOnlineGhostStorageManager::execCacheGhost(FFrame&, void* const)
	public virtual /*private native final function */void CacheGhost(TdGhost.TdGhostInfo GhostInfo, ref array<byte> GhostBytes)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
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