namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdGameData : UIDataStore_TdGameResource, 
		UIListElementCellProvider/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public enum RebootReasonType 
	{
		RR_NoReason,
		RR_Signout,
		RR_Signin,
		RR_ConnectionLost,
		RR_MAX
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public /*transient */UIDataStore_TdGameData.RebootReasonType RebootReason;
	public /*transient */bool bSkipRestoreScenes;
	public bool bViewGhost;
	public /*transient */string RestoredScenesSerialized;
	public /*transient */string RestoredMenuSerialized;
	public /*transient */int CurrentMap;
	public /*transient */int SkipTitleScreen;
	public /*transient */array<int> MapCycle;
	public /*transient */int CurrentGameMode;
	public /*transient */TdCheckpointManager CheckpointManager;
	public array<byte> CheckpointDataArray;
	public int CurrentMapForCheckpoints;
	public float TimeAttackClock;
	public float TimeAttackDistance;
	
	// Export UUIDataStore_TdGameData::execGetMapIndexFromFileName(FFrame&, void* const)
	public virtual /*native function */int GetMapIndexFromFileName(string Filename)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetMapIndexFromMapName(FFrame&, void* const)
	public virtual /*native function */int GetMapIndexFromMapName(string MapName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetFileNameFromMapIndex(FFrame&, void* const)
	public virtual /*native function */string GetFileNameFromMapIndex(int MapIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetMapNameFromMapIndex(FFrame&, void* const)
	public virtual /*native function */string GetMapNameFromMapIndex(int MapIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetTutorialMapIndex(FFrame&, void* const)
	public virtual /*native function */int GetTutorialMapIndex()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRolesList(FFrame&, void* const)
	public virtual /*native function */array<int> GetRolesList(/*optional */int Team = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetNumRoles(FFrame&, void* const)
	public virtual /*native function */int GetNumRoles(/*optional */int Team = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleIndexFromRoleId(FFrame&, void* const)
	public virtual /*native function */int GetRoleIndexFromRoleId(int RoleId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleIdFromRoleIndex(FFrame&, void* const)
	public virtual /*native function */int GetRoleIdFromRoleIndex(int RoleIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleClassNameFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetRoleClassNameFromIndex(int RoleIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleNameFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetRoleNameFromIndex(int RoleIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleImageMarkupFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetRoleImageMarkupFromIndex(int RoleIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetGameModeClassNameFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetGameModeClassNameFromIndex(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetMapNumCheckpoints(FFrame&, void* const)
	public virtual /*native function */int GetMapNumCheckpoints(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointFriendlyNameFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetCheckpointFriendlyNameFromIndex(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointDescriptionFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetCheckpointDescriptionFromIndex(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointNameFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetCheckpointNameFromIndex(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointNameFromIndexAndMap(FFrame&, void* const)
	public virtual /*native function */string GetCheckpointNameFromIndexAndMap(int MapIndex, int CheckpointIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointImageMarkupFromIndex(FFrame&, void* const)
	public virtual /*native function */string GetCheckpointImageMarkupFromIndex(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */bool IsElementEnabled(name FieldName, int CollectionIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void StartNewGameWithTutorial(/*optional */bool bPlayCutScene = default)
	{
	
	}
	
	public virtual /*function */void StartNewGame(bool bShouldSaveCheckpointProgress, bool bAllowSPLevelAchievements)
	{
	
	}
	
	public virtual /*function */void StartGame(string LevelName, /*optional */string CheckpointName = default, /*optional */string GameMode = default, /*optional */string URL = default, /*optional */bool bShouldSaveCheckpointProgress = default, /*optional */bool bAllowSPLevelAchievements = default)
	{
	
	}
	
	public virtual /*function */void QuitToMainMenu()
	{
	
	}
	
	public virtual /*function */void RestartFromLastCheckpoint(/*optional */bool bShouldSaveCheckpointProgress = default, /*optional */bool bAllowSPLevelAchievements = default)
	{
	
	}
	
	public override /*event */void Registered(LocalPlayer PlayerOwner)
	{
	
	}
	
	public UIDataStore_TdGameData()
	{
		// Object Offset:0x006DB790
		bViewGhost = true;
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdMaps",
				ProviderClassName = "TdGame.UIDataProvider_TdMaps",
				ProviderClass = default,
			},
		};
		Tag = (name)"TdGameData";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}