namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineStatsReadForUI : TdOnlineStatsRead{
	public TdOnlineStatsReadForUI()
	{
		// Object Offset:0x0060865D
		SortColumnId = 20;
		ColumnIds = new array<int>
		{
			20,
			19,
		};
		ColumnTypes = new array<Settings.ESettingsDataType>
		{
			252,
			59,
		};
	}
}
}