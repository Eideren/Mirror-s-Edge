namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineContentInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineContentInterface.OnContentChange __OnContentChange__Delegate{ get; }
	public /*delegate*/OnlineContentInterface.OnReadContentComplete __OnReadContentComplete__Delegate{ get; }
	public /*delegate*/OnlineContentInterface.OnQueryAvailableDownloadsComplete __OnQueryAvailableDownloadsComplete__Delegate{ get; }
	
	public delegate void OnContentChange();
	
	public /*function */void AddContentChangeDelegate(/*delegate*/OnlineContentInterface.OnContentChange ContentDelegate, /*optional */byte? _LocalUserNum = default);
	
	public /*function */void ClearContentChangeDelegate(/*delegate*/OnlineContentInterface.OnContentChange ContentDelegate, /*optional */byte? _LocalUserNum = default);
	
	public delegate void OnReadContentComplete(bool bWasSuccessful);
	
	public /*function */void AddReadContentComplete(byte LocalUserNum, /*delegate*/OnlineContentInterface.OnReadContentComplete ReadContentCompleteDelegate);
	
	public /*function */void ClearReadContentComplete(byte LocalUserNum, /*delegate*/OnlineContentInterface.OnReadContentComplete ReadContentCompleteDelegate);
	
	public /*function */bool ReadContentList(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EOnlineEnumerationReadState GetContentList(byte LocalUserNum, ref array<OnlineSubsystem.OnlineContent> ContentList);
	
	public /*function */bool QueryAvailableDownloads(byte LocalUserNum);
	
	public delegate void OnQueryAvailableDownloadsComplete(bool bWasSuccessful);
	
	public /*function */void AddQueryAvailableDownloadsComplete(byte LocalUserNum, /*delegate*/OnlineContentInterface.OnQueryAvailableDownloadsComplete QueryDownloadsDelegate);
	
	public /*function */void ClearQueryAvailableDownloadsComplete(byte LocalUserNum, /*delegate*/OnlineContentInterface.OnQueryAvailableDownloadsComplete QueryDownloadsDelegate);
	
	public /*function */void GetAvailableDownloadCounts(byte LocalUserNum, ref int NewDownloads, ref int TotalDownloads);
	
}
}