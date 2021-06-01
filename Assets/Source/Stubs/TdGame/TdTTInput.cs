namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTTInput : Object/*
		native*/{
	public partial struct /*native */TTData
	{
		public String PlayerName;
		public OnlineSubsystem.UniqueNetId PlayerId;
		public float TotalTime;
		public bool HasGhost;
		public int GhostTag;
		public array<float> IntermediateTimes;
		public int TotalRating;
		public float AverageSpeed;
		public float DistanceRun;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00665BA9
	//		PlayerName = "";
	//		PlayerId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		TotalTime = 3599.990f;
	//		HasGhost = false;
	//		GhostTag = 0;
	//		IntermediateTimes = default;
	//		TotalRating = 0;
	//		AverageSpeed = 0.0f;
	//		DistanceRun = 0.0f;
	//	}
	};
	
	public bool bIsOnlineInfo;
	public TdTTInput.TTData WorldsBest;
	public TdTTInput.TTData WorldsMonthlyBest;
	public TdTTInput.TTData WorldsWeeklyBest;
	public TdTTInput.TTData FriendsBest;
	public TdTTInput.TTData TargetTime;
	public TdTTInput.TTData PlayerBest;
	public float PlayerWeeklyBest;
	public float PlayerMonthlyBest;
	public array<float> PlayerMonthlyCache;
	public array<float> PlayerWeeklyCache;
	public float WeeklyGhostQualifyingTime;
	public float MonthlyGhostQualifyingTime;
	
	public virtual /*function */void ClearTimeData()
	{
	
	}
	
	public virtual /*function */void ClearTTData(ref TdTTInput.TTData Data)
	{
	
	}
	
	public virtual /*function */void PrintInput()
	{
	
	}
	
	public TdTTInput()
	{
		// Object Offset:0x0067B737
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
		PlayerBest = new TdTTInput.TTData
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
	}
}
}