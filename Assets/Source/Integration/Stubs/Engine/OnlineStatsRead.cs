namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineStatsRead : OnlineStats/*
		abstract
		native*/{
	public partial struct /*native */OnlineStatsColumn
	{
		[Const] public int ColumnNo;
		[Const] public Settings.SettingsData StatValue;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0037432D
	//		ColumnNo = 0;
	//		StatValue = new Settings.SettingsData
	//		{
	//			Type = Settings.ESettingsDataType.SDT_Empty,
	//			Value1 = 0,
	//		};
	//	}
	};
	
	public partial struct /*native */OnlineStatsRow
	{
		[Const] public OnlineSubsystem.UniqueNetId PlayerId;
		[Const] public Settings.SettingsData Rank;
		[Const] public String NickName;
		[Const] public array<OnlineStatsRead.OnlineStatsColumn> Columns;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003744D1
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
	//		Rank = new Settings.SettingsData
	//		{
	//			Type = Settings.ESettingsDataType.SDT_Empty,
	//			Value1 = 0,
	//		};
	//		NickName = "";
	//		Columns = default;
	//	}
	};
	
	public partial struct /*native */ColumnMetaData
	{
		[Const] public int Id;
		[Const] public name Name;
		[Const, localized] public String ColumnName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00374945
	//		Id = 0;
	//		Name = (name)"None";
	//		ColumnName = "";
	//	}
	};
	
	[Const] public int ViewId;
	[Const] public int SortColumnId;
	[Const] public array<int> ColumnIds;
	[Const] public int TotalRowsInView;
	[Const] public array<OnlineStatsRead.OnlineStatsRow> Rows;
	[Const] public array<OnlineStatsRead.ColumnMetaData> ColumnMappings;
	[Const] public String ViewName;
	public OnlineStats.StatPeriodFlags PeriodFlags;
	public int PeriodPast;
	public array<Settings.ESettingsDataType> ColumnTypes;
	public bool SortAscending;
	public /*delegate*/OnlineStatsRead.OnStatsReadComplete __OnStatsReadComplete__Delegate;
	
	public delegate void OnStatsReadComplete();
	
}
}