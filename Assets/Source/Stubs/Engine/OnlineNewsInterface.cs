namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineNewsInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineNewsInterface.OnReadGameNewsCompleted __OnReadGameNewsCompleted__Delegate{ get; }
	public /*delegate*/OnlineNewsInterface.OnReadContentAnnouncementsCompleted __OnReadContentAnnouncementsCompleted__Delegate{ get; }
	
	public /*function */bool ReadGameNews(byte LocalUserNum);
	
	public delegate void OnReadGameNewsCompleted(bool bWasSuccessful);
	
	public /*function */void AddReadGameNewsCompletedDelegate(/*delegate*/OnlineNewsInterface.OnReadGameNewsCompleted ReadGameNewsDelegate);
	
	public /*function */void ClearReadGameNewsCompletedDelegate(/*delegate*/OnlineNewsInterface.OnReadGameNewsCompleted ReadGameNewsDelegate);
	
	public /*function */string GetGameNews(byte LocalUserNum);
	
	public /*function */bool ReadContentAnnouncements(byte LocalUserNum);
	
	public delegate void OnReadContentAnnouncementsCompleted(bool bWasSuccessful);
	
	public /*function */void AddReadContentAnnouncementsCompletedDelegate(/*delegate*/OnlineNewsInterface.OnReadContentAnnouncementsCompleted ReadContentAnnouncementsDelegate);
	
	public /*function */void ClearReadContentAnnouncementsCompletedDelegate(/*delegate*/OnlineNewsInterface.OnReadContentAnnouncementsCompleted ReadContentAnnouncementsDelegate);
	
	public /*function */string GetContentAnnouncements(byte LocalUserNum);
	
}
}