namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineAccountInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineAccountInterface.OnCreateOnlineAccountCompleted __OnCreateOnlineAccountCompleted__Delegate{ get; }
	
	public /*function */bool CreateOnlineAccount(string UserName, string Password, string EmailAddress, /*optional */string? _ProductKey = default);
	
	public delegate void OnCreateOnlineAccountCompleted(OnlineSubsystem.EOnlineAccountCreateStatus ErrorStatus);
	
	public /*function */void AddCreateOnlineAccountCompletedDelegate(/*delegate*/OnlineAccountInterface.OnCreateOnlineAccountCompleted AccountCreateDelegate);
	
	public /*function */void ClearCreateOnlineAccountCompletedDelegate(/*delegate*/OnlineAccountInterface.OnCreateOnlineAccountCompleted AccountCreateDelegate);
	
	public /*function */bool CreateLocalAccount(string UserName, /*optional */string? _Password = default);
	
	public /*function */bool RenameLocalAccount(string NewUserName, string OldUserName, /*optional */string? _Password = default);
	
	public /*function */bool DeleteLocalAccount(string UserName, /*optional */string? _Password = default);
	
	public /*function */bool GetLocalAccountNames(ref array<string> Accounts);
	
}
}