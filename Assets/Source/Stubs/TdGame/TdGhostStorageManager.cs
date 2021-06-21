namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGhostStorageManager : Object/*
		native*/{
	public enum EGhostStorageResult 
	{
		EGR_Ok,
		EGR_OkNoGhost,
		EGR_ErrorInconsistentTime,
		EGR_Error,
		EGR_IncompatibleVersion,
		EGR_MAX
	};
	
	public /*protected const */int StorageFormatVersion;
	public /*protected */TdGhost.TdGhostInfo ReadInfo;
	public /*delegate*/TdGhostStorageManager.OnReadGhostComplete __OnReadGhostComplete__Delegate;
	public /*delegate*/TdGhostStorageManager.OnWriteGhostComplete __OnWriteGhostComplete__Delegate;
	
	public delegate void OnReadGhostComplete(TdGhostStorageManager.EGhostStorageResult Result, TdGhost Ghost);
	
	public delegate void OnWriteGhostComplete(TdGhostStorageManager.EGhostStorageResult Result, /*optional */int? _GhostTag = default);
	
	public virtual /*function */void OnConnectionLost()
	{
		// stub
	}
	
	public virtual /*function */bool ReadGhost(TdGhost.TdGhostInfo GhostInfo, /*delegate*/TdGhostStorageManager.OnReadGhostComplete ReadCompleted)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool WriteGhost(TdGhost Ghost, OnlineSubsystem.UniqueNetId PlayerId, /*delegate*/TdGhostStorageManager.OnWriteGhostComplete WriteCompleted)
	{
		// stub
		return default;
	}
	
	public virtual /*protected function */bool InfoIsConsistent(TdGhost.TdGhostInfo Info1, TdGhost.TdGhostInfo Info2)
	{
		// stub
		return default;
	}
	
	// Export UTdGhostStorageManager::execSerializeGhost(FFrame&, void* const)
	public virtual /*protected native function */void SerializeGhost(ref TdGhost Ghost, ref array<byte> Bytes)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdGhostStorageManager::execDeSerializeGhost(FFrame&, void* const)
	public virtual /*protected native function */TdGhostStorageManager.EGhostStorageResult DeSerializeGhost(ref TdGhost Ghost, ref array<byte> Bytes)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public TdGhostStorageManager()
	{
		// Object Offset:0x0054FABF
		StorageFormatVersion = 5;
	}
}
}