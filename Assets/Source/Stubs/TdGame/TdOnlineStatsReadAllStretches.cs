namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineStatsReadAllStretches : TdOnlineStatsRead/*
		native*/{
	// Export UTdOnlineStatsReadAllStretches::execSetStatId(FFrame&, void* const)
	public virtual /*native function */void SetStatId(int InStatId, Settings.ESettingsDataType InDataType)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public override /*function */void SetStretchId(int InStretchId)
	{
		// stub
	}
	
	public TdOnlineStatsReadAllStretches()
	{
		// Object Offset:0x006085BA
		SortColumnId = -1;
	}
}
}