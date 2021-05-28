namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineStatsRead : OnlineStats/*
		abstract
		native*/{
	public partial struct /*native */OnlineStatsColumn
	{
		public /*const */int ColumnNo;
		public /*const */Settings.SettingsData StatValue;
	
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
		public /*const */OnlineSubsystem.UniqueNetId PlayerId;
		public /*const */Settings.SettingsData Rank;
		public /*const */string NickName;
		public /*const */array<OnlineStatsRead.OnlineStatsColumn> Columns;
	
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
		public /*const */int Id;
		public /*const */name Name;
		public /*const localized */string ColumnName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00374945
	//		Id = 0;
	//		Name = (name)"None";
	//		ColumnName = "";
	//	}
	};
	
	public /*const */int ViewId;
	public /*const */int SortColumnId;
	public /*const */array<int> ColumnIds;
	public /*const */int TotalRowsInView;
	public /*const */array<OnlineStatsRead.OnlineStatsRow> Rows;
	public /*const */array<OnlineStatsRead.ColumnMetaData> ColumnMappings;
	public /*const */string ViewName;
	public OnlineStats.StatPeriodFlags PeriodFlags;
	public int PeriodPast;
	public array<Settings.ESettingsDataType> ColumnTypes;
	public bool SortAscending;
	public /*delegate*/OnlineStatsRead.OnStatsReadComplete __OnStatsReadComplete__Delegate;
	
	public delegate void OnStatsReadComplete();
	
}
}