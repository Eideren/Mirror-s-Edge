namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineAccountInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineAccountInterface.OnCreateOnlineAccountCompleted __OnCreateOnlineAccountCompleted__Delegate{ get; }
	
	public /*function */bool CreateOnlineAccount(String UserName, String Password, String EmailAddress, /*optional */String? _ProductKey = default);
	
	public delegate void OnCreateOnlineAccountCompleted(OnlineSubsystem.EOnlineAccountCreateStatus ErrorStatus);
	
	public /*function */void AddCreateOnlineAccountCompletedDelegate(/*delegate*/OnlineAccountInterface.OnCreateOnlineAccountCompleted AccountCreateDelegate);
	
	public /*function */void ClearCreateOnlineAccountCompletedDelegate(/*delegate*/OnlineAccountInterface.OnCreateOnlineAccountCompleted AccountCreateDelegate);
	
	public /*function */bool CreateLocalAccount(String UserName, /*optional */String? _Password = default);
	
	public /*function */bool RenameLocalAccount(String NewUserName, String OldUserName, /*optional */String? _Password = default);
	
	public /*function */bool DeleteLocalAccount(String UserName, /*optional */String? _Password = default);
	
	public /*function */bool GetLocalAccountNames(ref array<String> Accounts);
	
}
}