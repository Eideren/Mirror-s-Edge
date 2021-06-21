namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpFileLockerService : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*delegate*/TpFileLockerService.OnFetchLockerComplete __OnFetchLockerComplete__Delegate;
	public /*delegate*/TpFileLockerService.OnReadFileFromLockerComplete __OnReadFileFromLockerComplete__Delegate;
	public /*delegate*/TpFileLockerService.OnWriteFileToLockerComplete __OnWriteFileToLockerComplete__Delegate;
	public /*delegate*/TpFileLockerService.OnDeleteFileFromLockerComplete __OnDeleteFileFromLockerComplete__Delegate;
	
	// Export UTpFileLockerService::execUpdate(FFrame&, void* const)
	public virtual /*native simulated function */void Update(float DeltaSeconds)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpFileLockerService::execFetchLocker(FFrame&, void* const)
	public virtual /*native function */bool FetchLocker(String UserName)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public delegate void OnFetchLockerComplete(bool bWasSuccessful);
	
	// Export UTpFileLockerService::execReadFileFromLocker(FFrame&, void* const)
	public virtual /*native function */bool ReadFileFromLocker(ref OnlineSubsystem.OnlineFileLockerFile File)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public delegate void OnReadFileFromLockerComplete(bool bWasSuccessful);
	
	// Export UTpFileLockerService::execWriteFileToLocker(FFrame&, void* const)
	public virtual /*native function */bool WriteFileToLocker(ref OnlineSubsystem.OnlineFileLockerFile File)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public delegate void OnWriteFileToLockerComplete(bool bWasSuccessful);
	
	// Export UTpFileLockerService::execDeleteFileFromLocker(FFrame&, void* const)
	public virtual /*native function */bool DeleteFileFromLocker(ref OnlineSubsystem.OnlineFileLockerFile FileInfo)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public delegate void OnDeleteFileFromLockerComplete(bool bWasSuccessful);
	
	// Export UTpFileLockerService::execListFileLocker(FFrame&, void* const)
	public virtual /*native function */array<OnlineSubsystem.OnlineFileLockerFileInfo> ListFileLocker()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
}
}