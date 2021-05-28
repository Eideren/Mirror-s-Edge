namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTTResult : Object/*
		native*/{
	public bool bIsOnlineResult;
	public bool bBeatWorldRecord;
	public bool bBeatWorldMonthlyRecord;
	public bool bBeatWorldWeeklyRecord;
	public bool bBeatFriendsRecord;
	public bool bBeatPersonalRecord;
	public bool bBeatTargetTime;
	public bool bBeatQualifyerTime;
	public TdTTInput.TTData WorldsBest;
	public TdTTInput.TTData WorldsMonthlyBest;
	public TdTTInput.TTData WorldsWeeklyBest;
	public TdTTInput.TTData FriendsBest;
	public TdTTInput.TTData TargetTime;
	public TdTTInput.TTData CurrentTime;
	public TdTTInput.TTData OldPlayerBest;
	public int UnlockedTTStretch;
	public array<float> TrackSegmentPct;
	
	public virtual /*function */bool WasNewRecord()
	{
	
		return default;
	}
	
	public virtual /*function */bool IncreasedStarRating()
	{
	
		return default;
	}
	
	public virtual /*function */void PrintResult()
	{
	
	}
	
	public TdTTResult()
	{
		// Object Offset:0x0067C855
		WorldsBest = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		WorldsMonthlyBest = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		WorldsWeeklyBest = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		FriendsBest = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		TargetTime = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		CurrentTime = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		OldPlayerBest = new TdTTInput.TTData
		{
			PlayerName = "",
			PlayerId = new OnlineSubsystem.UniqueNetId
			{
				Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
				},
			},
			TotalTime = 3599.990f,
			HasGhost = false,
			GhostTag = 0,
			IntermediateTimes = default,
			TotalRating = 0,
			AverageSpeed = 0.0f,
			DistanceRun = 0.0f,
		};
		UnlockedTTStretch = -1;
	}
}
}