namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineStatsRead : OnlineStatsRead/*
		native*/{
	public /*private */int StretchId;
	
	// Export UTdOnlineStatsRead::execGetFloatStat(FFrame&, void* const)
	public virtual /*native function */float GetFloatStat(OnlineSubsystem.UniqueNetId UniqId, int StatId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdOnlineStatsRead::execGetIntStat(FFrame&, void* const)
	public virtual /*native function */int GetIntStat(OnlineSubsystem.UniqueNetId UniqId, int StatId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdOnlineStatsRead::execGetFloatStatFromRow(FFrame&, void* const)
	public virtual /*native function */float GetFloatStatFromRow(int Row, int StatId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdOnlineStatsRead::execGetIntStatFromRow(FFrame&, void* const)
	public virtual /*native function */int GetIntStatFromRow(int Row, int StatId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void SetStretchId(int InStretchId)
	{
	
	}
	
}
}