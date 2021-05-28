namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineStatsWrite : OnlineStatsWrite/*
		native*/{
	public /*private */int StretchId;
	
	public virtual /*function */void WriteStats(OnlineSubsystem.UniqueNetId UniqId, Info StatInfo, OnlineStatsInterface StatsInterface)
	{
	
	}
	
	public virtual /*function */void SetStretchId(int InStretchId)
	{
	
	}
	
}
}