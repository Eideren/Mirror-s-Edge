namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListElementSorter : UIComp_ListComponentBase/* within UIList*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public partial struct /*native transient */UIListSortingParameters
	{
		[init] public int PrimaryIndex;
		[init] public int SecondaryIndex;
		[init] public bool bReversePrimarySorting;
		[init] public bool bReverseSecondarySorting;
		[init] public bool bCaseSensitive;
		[init] public bool bIntSortPrimary;
		[init] public bool bIntSortSecondary;
		[init] public bool bFloatSortPrimary;
		[init] public bool bFloatSortSecondary;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041DCC7
	//		PrimaryIndex = 0;
	//		SecondaryIndex = 0;
	//		bReversePrimarySorting = false;
	//		bReverseSecondarySorting = false;
	//		bCaseSensitive = false;
	//		bIntSortPrimary = false;
	//		bIntSortSecondary = false;
	//		bFloatSortPrimary = false;
	//		bFloatSortSecondary = false;
	//	}
	};
	
	public new UIList Outer => base.Outer as UIList;
	
	[Category] public bool bAllowCompoundSorting;
	[Category] public bool bReversePrimarySorting;
	[Category] public bool bReverseSecondarySorting;
	[Category] public int InitialSortColumn;
	[Category] public int InitialSecondarySortColumn;
	[Category] [Const, editconst, transient] public int PrimarySortColumn;
	[Category] [Const, editconst, transient] public int SecondarySortColumn;
	
	// Export UUIComp_ListElementSorter::execResetSortColumns(FFrame&, void* const)
	public virtual /*native final function */void ResetSortColumns(/*optional */bool? _bResort = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_ListElementSorter::execSortItems(FFrame&, void* const)
	public virtual /*native final function */bool SortItems(int ColumnIndex, /*optional */bool? _bSecondarySort = default, /*optional */bool? _bCaseSensitive = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_ListElementSorter::execResortItems(FFrame&, void* const)
	public virtual /*native final function */bool ResortItems(/*optional */bool? _bCaseSensitive = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public UIComp_ListElementSorter()
	{
		// Object Offset:0x0041E133
		bAllowCompoundSorting = true;
		InitialSortColumn = -1;
		InitialSecondarySortColumn = -1;
		PrimarySortColumn = -1;
		SecondarySortColumn = -1;
	}
}
}