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
	public /*transient */String RestoredScenesSerialized;
	public /*transient */String RestoredMenuSerialized;
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
	public virtual /*native function */int GetMapIndexFromFileName(String Filename)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetMapIndexFromMapName(FFrame&, void* const)
	public virtual /*native function */int GetMapIndexFromMapName(String MapName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetFileNameFromMapIndex(FFrame&, void* const)
	public virtual /*native function */String GetFileNameFromMapIndex(int MapIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetMapNameFromMapIndex(FFrame&, void* const)
	public virtual /*native function */String GetMapNameFromMapIndex(int MapIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetTutorialMapIndex(FFrame&, void* const)
	public virtual /*native function */int GetTutorialMapIndex()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRolesList(FFrame&, void* const)
	public virtual /*native function */array<int> GetRolesList(/*optional */int? _Team = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetNumRoles(FFrame&, void* const)
	public virtual /*native function */int GetNumRoles(/*optional */int? _Team = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleIndexFromRoleId(FFrame&, void* const)
	public virtual /*native function */int GetRoleIndexFromRoleId(int RoleId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleIdFromRoleIndex(FFrame&, void* const)
	public virtual /*native function */int GetRoleIdFromRoleIndex(int RoleIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleClassNameFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetRoleClassNameFromIndex(int RoleIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleNameFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetRoleNameFromIndex(int RoleIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetRoleImageMarkupFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetRoleImageMarkupFromIndex(int RoleIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetGameModeClassNameFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetGameModeClassNameFromIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetMapNumCheckpoints(FFrame&, void* const)
	public virtual /*native function */int GetMapNumCheckpoints(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointFriendlyNameFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetCheckpointFriendlyNameFromIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointDescriptionFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetCheckpointDescriptionFromIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointNameFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetCheckpointNameFromIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointNameFromIndexAndMap(FFrame&, void* const)
	public virtual /*native function */String GetCheckpointNameFromIndexAndMap(int MapIndex, int CheckpointIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameData::execGetCheckpointImageMarkupFromIndex(FFrame&, void* const)
	public virtual /*native function */String GetCheckpointImageMarkupFromIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */bool IsElementEnabled(name FieldName, int CollectionIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void StartNewGameWithTutorial(/*optional */bool? _bPlayCutScene = default)
	{
		// stub
	}
	
	public virtual /*function */void StartNewGame(bool bShouldSaveCheckpointProgress, bool bAllowSPLevelAchievements)
	{
		// stub
	}
	
	public virtual /*function */void StartGame(String LevelName, /*optional */String? _CheckpointName = default, /*optional */String? _GameMode = default, /*optional */String? _URL = default, /*optional */bool? _bShouldSaveCheckpointProgress = default, /*optional */bool? _bAllowSPLevelAchievements = default)
	{
		// stub
	}
	
	public virtual /*function */void QuitToMainMenu()
	{
		// stub
	}
	
	public virtual /*function */void RestartFromLastCheckpoint(/*optional */bool? _bShouldSaveCheckpointProgress = default, /*optional */bool? _bAllowSPLevelAchievements = default)
	{
		// stub
	}
	
	public override /*event */void Registered(LocalPlayer PlayerOwner)
	{
		// stub
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