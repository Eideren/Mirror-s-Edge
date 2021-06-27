namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListElementSorter : UIComp_ListComponentBase/* within UIList*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public partial struct /*native transient */UIListSortingParameters
	{
		public /*init */int PrimaryIndex;
		public /*init */int SecondaryIndex;
		public /*init */bool bReversePrimarySorting;
		public /*init */bool bReverseSecondarySorting;
		public /*init */bool bCaseSensitive;
		public /*init */bool bIntSortPrimary;
		public /*init */bool bIntSortSecondary;
		public /*init */bool bFloatSortPrimary;
		public /*init */bool bFloatSortSecondary;
	
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
	
	public/*()*/ bool bAllowCompoundSorting;
	public/*()*/ bool bReversePrimarySorting;
	public/*()*/ bool bReverseSecondarySorting;
	public/*()*/ int InitialSortColumn;
	public/*()*/ int InitialSecondarySortColumn;
	public/*()*/ /*const editconst transient */int PrimarySortColumn;
	public/*()*/ /*const editconst transient */int SecondarySortColumn;
	
	// Export UUIComp_ListElementSorter::execResetSortColumns(FFrame&, void* const)
	public virtual /*native final function */void ResetSortColumns(/*optional */bool? _bResort = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIComp_ListElementSorter::execSortItems(FFrame&, void* const)
	public virtual /*native final function */bool SortItems(int ColumnIndex, /*optional */bool? _bSecondarySort = default, /*optional */bool? _bCaseSensitive = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIComp_ListElementSorter::execResortItems(FFrame&, void* const)
	public virtual /*native final function */bool ResortItems(/*optional */bool? _bCaseSensitive = default)
	{
		 // #warning NATIVE FUNCTION !
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