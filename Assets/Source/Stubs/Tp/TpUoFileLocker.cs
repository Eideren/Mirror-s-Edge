namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoFileLocker : TpSystemHandler, 
		OnlineFileLockerInterface/*
		transient*/{
	public /*private */array< /*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete > __OnFetchLockerComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete > __OnReadFileFromLockerComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete > __OnWriteFileToLockerComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete > __OnDeleteFileFromLockerComplete__Multicaster;
	public /*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete __OnFetchLockerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete __OnReadFileFromLockerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete __OnWriteFileToLockerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete __OnDeleteFileFromLockerComplete__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	public virtual /*function */bool FetchLocker(String UserName)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnFetchLockerComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnFetchLockerComplete_Add(/*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnFetchLockerComplete_Remove(/*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddOnFetchLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete FetchLockerDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void Del_OnFetchLockerComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void ClearOnFetchLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnFetchLockerComplete FetchLockerDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool ReadFileFromLocker(ref OnlineSubsystem.OnlineFileLockerFile File)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnReadFileFromLockerComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnReadFileFromLockerComplete_Add(/*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnReadFileFromLockerComplete_Remove(/*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddOnReadFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete ReadFileFromLockerDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void Del_OnReadFileFromLockerComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void ClearOnReadFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnReadFileFromLockerComplete ReadFileFromLockerDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool WriteFileToLocker(ref OnlineSubsystem.OnlineFileLockerFile File)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnWriteFileToLockerComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnWriteFileToLockerComplete_Add(/*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnWriteFileToLockerComplete_Remove(/*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddOnWriteFileToLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete WriteFileToLockerDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void Del_OnWriteFileToLockerComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void ClearOnWriteFileToLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnWriteFileToLockerComplete WriteFileToLockerDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool DeleteFileFromLocker(ref OnlineSubsystem.OnlineFileLockerFile File)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnDeleteFileFromLockerComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnDeleteFileFromLockerComplete_Add(/*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnDeleteFileFromLockerComplete_Remove(/*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddOnDeleteFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete DeleteFileFromLockerDelegate)
	{
		// stub
	}
	
	public virtual /*private final function */void Del_OnDeleteFileFromLockerComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void ClearOnDeleteFileFromLockerCompleteDelegate(/*delegate*/OnlineFileLockerInterface.OnDeleteFileFromLockerComplete DeleteFileFromLockerDelegate)
	{
		// stub
	}
	
	public virtual /*function */array<OnlineSubsystem.OnlineFileLockerFileInfo> ListFileLocker()
	{
		// stub
		return default;
	}
	
}
}