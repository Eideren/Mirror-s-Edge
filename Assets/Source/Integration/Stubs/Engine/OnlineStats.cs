namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineStats : Object/*
		abstract
		native*/{
	public partial struct /*native */StatPeriodFlags
	{
		public bool bIndefinite;
		public bool bDaily;
		public bool bWeekly;
		public bool bBiweekly;
		public bool bMonthly;
		public bool bQuarterly;
		public bool bYearly;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00372EC2
	//		bIndefinite = false;
	//		bDaily = false;
	//		bWeekly = false;
	//		bBiweekly = false;
	//		bMonthly = false;
	//		bQuarterly = false;
	//		bYearly = false;
	//	}
	};
	
	public partial struct /*native */IdToStatKeyMapping
	{
		public int StatId;
		public String StatKey;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00373016
	//		StatId = 0;
	//		StatKey = "";
	//	}
	};
	
	public /*const */array<Settings.StringIdToStringMapping> ViewIdMappings;
	public array<OnlineStats.IdToStatKeyMapping> IdToStatKeyMappings;
	
	// Export UOnlineStats::execGetViewId(FFrame&, void* const)
	public virtual /*native function */bool GetViewId(name ViewName, ref int ViewId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineStats::execGetViewName(FFrame&, void* const)
	public virtual /*native function */name GetViewName(int ViewId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */String GetStatKey(int Id)
	{
		// stub
		return default;
	}
	
}
}