namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineGameSearch : Settings/*
		native*/{
	public enum EOnlineGameSearchEntryType 
	{
		OGSET_Property,
		OGSET_LocalizedSetting,
		OGSET_ObjectProperty,
		OGSET_MAX
	};
	
	public enum EOnlineGameSearchComparisonType 
	{
		OGSCT_Equals,
		OGSCT_NotEquals,
		OGSCT_GreaterThan,
		OGSCT_GreaterThanEquals,
		OGSCT_LessThan,
		OGSCT_LessThanEquals,
		OGSCT_MAX
	};
	
	public enum EOnlineGameSearchSortType 
	{
		OGSSO_Ascending,
		OGSSO_Descending,
		OGSSO_MAX
	};
	
	public partial struct /*native */OnlineGameSearchResult
	{
		[Const] public OnlineGameSettings GameSettings;
		[native, Const] public Object.Pointer PlatformData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00362219
	//		GameSettings = default;
	//	}
	};
	
	public partial struct /*native */NamedObjectProperty
	{
		public name ObjectPropertyName;
		public String ObjectPropertyValue;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00361925
	//		ObjectPropertyName = (name)"None";
	//		ObjectPropertyValue = "";
	//	}
	};
	
	public partial struct /*native */OnlineGameSearchParameter
	{
		public int EntryId;
		public name ObjectPropertyName;
		public OnlineGameSearch.EOnlineGameSearchEntryType EntryType;
		public OnlineGameSearch.EOnlineGameSearchComparisonType ComparisonType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00361AD9
	//		EntryId = 0;
	//		ObjectPropertyName = (name)"None";
	//		EntryType = OnlineGameSearch.EOnlineGameSearchEntryType.OGSET_Property;
	//		ComparisonType = OnlineGameSearch.EOnlineGameSearchComparisonType.OGSCT_Equals;
	//	}
	};
	
	public partial struct /*native */OnlineGameSearchSortClause
	{
		public int EntryId;
		public name ObjectPropertyName;
		public OnlineGameSearch.EOnlineGameSearchEntryType EntryType;
		public OnlineGameSearch.EOnlineGameSearchSortType SortType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00361C75
	//		EntryId = 0;
	//		ObjectPropertyName = (name)"None";
	//		EntryType = OnlineGameSearch.EOnlineGameSearchEntryType.OGSET_Property;
	//		SortType = OnlineGameSearch.EOnlineGameSearchSortType.OGSSO_Ascending;
	//	}
	};
	
	public partial struct /*native */OnlineGameSearchORClause
	{
		public array<OnlineGameSearch.OnlineGameSearchParameter> OrParams;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00361D89
	//		OrParams = default;
	//	}
	};
	
	public partial struct /*native */OnlineGameSearchQuery
	{
		public array<OnlineGameSearch.OnlineGameSearchORClause> OrClauses;
		public array<OnlineGameSearch.OnlineGameSearchSortClause> SortClauses;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00361E9D
	//		OrClauses = default;
	//		SortClauses = default;
	//	}
	};
	
	public int MaxSearchResults;
	public Settings.LocalizedStringSetting Query;
	[databinding] public bool bIsLanQuery;
	[databinding] public bool bIsListPlayQuery;
	[databinding] public bool bUsesArbitration;
	[Const] public bool bIsSearchInProgress;
	[Const] public bool bIsListPlaySearchInProgress;
	[databinding] public int NumListPlayServersAvailable;
	[databinding] public int NumGoldOnlyListPlayServersAvailable;
	[databinding] public int NumJoinableListPlayServersAvailable;
	public Core.ClassT<OnlineGameSettings> GameSettingsClass;
	[Const] public array<OnlineGameSearch.OnlineGameSearchResult> Results;
	public array<OnlineGameSearch.NamedObjectProperty> NamedProperties;
	[Const] public OnlineGameSearch.OnlineGameSearchQuery FilterQuery;
	public String AdditionalSearchCriteria;
	
	public OnlineGameSearch()
	{
		// Object Offset:0x003667BD
		MaxSearchResults = 25;
		GameSettingsClass = ClassT<OnlineGameSettings>()/*Ref Class'OnlineGameSettings'*/;
	}
}
}