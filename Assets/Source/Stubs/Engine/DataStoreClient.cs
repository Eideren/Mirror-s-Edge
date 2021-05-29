namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DataStoreClient : UIRoot/*
		native
		config(Engine)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native transient */PlayerDataStoreGroup
	{
		public /*init const transient */LocalPlayer PlayerOwner;
		public /*init const transient */array<UIDataStore> DataStores;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002F8BFE
	//		PlayerOwner = default;
	//		DataStores = default;
	//	}
	};
	
	public /*config */array</*config */string> GlobalDataStoreClasses;
	public /*const */array<UIDataStore> GlobalDataStores;
	public /*config */array</*config */string> PlayerDataStoreClassNames;
	public /*private const */array< Core.ClassT<UIDataStore> > PlayerDataStoreClasses;
	public /*const */array<DataStoreClient.PlayerDataStoreGroup> PlayerDataStores;
	
	// Export UDataStoreClient::execFindDataStore(FFrame&, void* const)
	public virtual /*native final function */UIDataStore FindDataStore(name DataStoreTag, /*optional */LocalPlayer? _PlayerOwner = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UDataStoreClient::execCreateDataStore(FFrame&, void* const)
	public virtual /*native final function */UIDataStore CreateDataStore(Core.ClassT<UIDataStore> DataStoreClass)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UDataStoreClient::execRegisterDataStore(FFrame&, void* const)
	public virtual /*native final function */bool RegisterDataStore(UIDataStore DataStore, /*optional */LocalPlayer? _PlayerOwner = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UDataStoreClient::execUnregisterDataStore(FFrame&, void* const)
	public virtual /*native final function */bool UnregisterDataStore(UIDataStore DataStore)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UDataStoreClient::execGetAvailableDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetAvailableDataStores(UIScene CurrentScene, ref array<UIDataStore> out_DataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UDataStoreClient::execFindPlayerDataStoreIndex(FFrame&, void* const)
	public virtual /*native final function */int FindPlayerDataStoreIndex(LocalPlayer PlayerOwner)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */Core.ClassT<UIDataStore> FindDataStoreClass(Core.ClassT<UIDataStore> RequiredMetaClass)
	{
	
		return default;
	}
	
	public virtual /*final event */void NotifyGameSessionEnded()
	{
	
	}
	
	public virtual /*final function */void DebugDumpDataStoreInfo(bool bVerbose)
	{
	
	}
	
	public DataStoreClient()
	{
		// Object Offset:0x002F95CC
		GlobalDataStoreClasses = new array</*config */string>
		{
			"Engine.UIDataStore_Strings",
			"Engine.UIDataStore_Images",
			"Engine.UIDataStore_GameResource",
			"Engine.CurrentGameDataStore",
			"Engine.UIDataStore_SessionSettings",
			"Engine.UIDataStore_Fonts",
			"Engine.UIDataStore_Color",
			"Engine.UIDataStore_Gamma",
			"Engine.UIDataStore_Registry",
			"TdGame.UIDataStore_TdMPData",
			"TdGame.UIDataStore_TdGameData",
			"TdGame.UIDataStore_TdMiniMenuData",
			"TdGame.UIDataStore_TdGameSearch_Pursuit",
			"TdGame.UIDataStore_TdMenuItems",
			"TdGame.UIDataStore_TdOnlineStats",
			"TdGame.UIDataStore_TdTimeTrialData",
			"TdGame.UIDataStore_TdLoginData",
			"TdGame.UIDataStore_TdStringAliasMap",
			"TdGame.UIDataStore_TdStringList",
			"TdGame.UIDataStore_TdGameObjectivesData",
			"TdGame.UIDataStore_TdUnlocksData",
		};
		PlayerDataStoreClassNames = new array</*config */string>
		{
			"Engine.PlayerOwnerDataStore",
			"Engine.UIDataStore_PlayerSettings",
			"TdGame.UIDataStore_TdTutorialData",
			"Engine.UIDataStore_OnlinePlayerData",
			"TdGame.UIDataStore_TdStringAliasBindingsMap",
		};
	}
}
}