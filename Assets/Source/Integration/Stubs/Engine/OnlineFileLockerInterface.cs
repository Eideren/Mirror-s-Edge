namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineFileLockerInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete __OnFetchLockerComplete__Delegate{ get; }
	public /*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete __OnReadFileFromLockerComplete__Delegate{ get; }
	public /*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete __OnWriteFileToLockerComplete__Delegate{ get; }
	public /*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete __OnDeleteFileFromLockerComplete__Delegate{ get; }
	
	public /*function */bool FetchLocker(String UserName);
	
	public delegate void OnFetchLockerComplete(bool bWasSuccessful);
	
	public /*function */void AddOnFetchLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete FetchLockerDelegate);
	
	public /*function */void ClearOnFetchLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete FetchLockerDelegate);
	
	public /*function */bool ReadFileFromLocker(ref OnlineSubsystem.OnlineFileLockerFile File);
	
	public delegate void OnReadFileFromLockerComplete(bool bWasSuccessful);
	
	public /*function */void AddOnReadFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete ReadFileFromLockerDelegate);
	
	public /*function */void ClearOnReadFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete ReadFileFromLockerDelegate);
	
	public /*function */bool WriteFileToLocker(ref OnlineSubsystem.OnlineFileLockerFile File);
	
	public delegate void OnWriteFileToLockerComplete(bool bWasSuccessful);
	
	public /*function */void AddOnWriteFileToLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete WriteFileToLockerDelegate);
	
	public /*function */void ClearOnWriteFileToLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete WriteFileToLockerDelegate);
	
	public /*function */bool DeleteFileFromLocker(ref OnlineSubsystem.OnlineFileLockerFile File);
	
	public delegate void OnDeleteFileFromLockerComplete(bool bWasSuccessful);
	
	public /*function */void AddOnDeleteFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete DeleteFileFromLockerDelegate);
	
	public /*function */void ClearOnDeleteFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete DeleteFileFromLockerDelegate);
	
	public /*function */array<OnlineSubsystem.OnlineFileLockerFileInfo> ListFileLocker();
	
}
}