namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_OnlineGameSearch : UIDataStore_Remote, 
		UIListElementProvider,UIListElementCellProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */GameSearchCfg
	{
		public Core.ClassT<OnlineGameSearch> GameSearchClass;
		public Core.ClassT<OnlineGameSettings> DefaultGameSettingsClass;
		public Core.ClassT<UIDataProvider_Settings> SearchResultsProviderClass;
		public UIDataProvider_Settings DesiredSettingsProvider;
		public array<UIDataProvider_Settings> SearchResults;
		public OnlineGameSearch Search;
		public name SearchName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00428BC0
	//		GameSearchClass = default;
	//		DefaultGameSettingsClass = default;
	//		SearchResultsProviderClass = default;
	//		DesiredSettingsProvider = default;
	//		SearchResults = default;
	//		Search = default;
	//		SearchName = (name)"None";
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementProvider;
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public /*const */name SearchResultsName;
	public OnlineSubsystem OnlineSub;
	public OnlineGameInterface GameInterface;
	public /*const */array<UIDataStore_OnlineGameSearch.GameSearchCfg> GameSearchCfgList;
	public int SelectedIndex;
	public int ActiveSearchIndex;
	
	public virtual /*event */void Init()
	{
	
	}
	
	public virtual /*function */bool InvalidateCurrentSearchResults()
	{
	
		return default;
	}
	
	public virtual /*event */bool SubmitGameSearch(byte ControllerIndex, /*optional */bool? _bInvalidateExistingSearchResults = default)
	{
	
		return default;
	}
	
	public virtual /*protected function */bool OverrideQuerySubmission(byte ControllerId, OnlineGameSearch Search)
	{
	
		return default;
	}
	
	public virtual /*function */void OnSearchComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*event */bool GetSearchResultFromIndex(int ListIndex, ref OnlineGameSearch.OnlineGameSearchResult Result)
	{
	
		return default;
	}
	
	public virtual /*event */bool ShowHostGamercard(byte ControllerIndex, int ListIndex)
	{
	
		return default;
	}
	
	// Export UUIDataStore_OnlineGameSearch::execBuildSearchResults(FFrame&, void* const)
	public virtual /*native function */void BuildSearchResults()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */OnlineGameSearch GetCurrentGameSearch()
	{
	
		return default;
	}
	
	public virtual /*event */OnlineGameSearch GetActiveGameSearch()
	{
	
		return default;
	}
	
	public virtual /*function */int FindSearchConfigurationIndex(name SearchTag)
	{
	
		return default;
	}
	
	public virtual /*event */void SetCurrentByIndex(int NewIndex, /*optional */bool? _bInvalidateExistingSearchResults = default)
	{
	
	}
	
	public virtual /*event */void SetCurrentByName(name SearchName, /*optional */bool? _bInvalidateExistingSearchResults = default)
	{
	
	}
	
	public virtual /*event */void MoveToNext(/*optional */bool? _bInvalidateExistingSearchResults = default)
	{
	
	}
	
	public virtual /*event */void MoveToPrevious(/*optional */bool? _bInvalidateExistingSearchResults = default)
	{
	
	}
	
	public virtual /*function */void ClearAllSearchResults()
	{
	
	}
	
	public UIDataStore_OnlineGameSearch()
	{
		// Object Offset:0x00429CBE
		SearchResultsName = (name)"SearchResults";
		ActiveSearchIndex = -1;
		Tag = (name)"OnlineGameSearch";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}