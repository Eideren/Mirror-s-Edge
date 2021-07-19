namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdGameObjectivesData : UIDataStore_TdGameResource/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */ObjectiveMappingStruct
	{
		[config] public name MappingName;
		[config] public name SubObjectiveName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006DBACC
	//		MappingName = (name)"None";
	//		SubObjectiveName = (name)"None";
	//	}
	};
	
	[config] public array</*config */UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct> ObjectiveMappings;
	[transient] public/*private*/ int CurrentObjectiveIndex;
	[transient] public/*private*/ int LastReachedChallengeIndex;
	
	// Export UUIDataStore_TdGameObjectivesData::execGetNumFinishedObjectives(FFrame&, void* const)
	public virtual /*native function */int GetNumFinishedObjectives(name FieldName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameObjectivesData::execUpdateObjectives(FFrame&, void* const)
	public virtual /*native function */void UpdateObjectives(name FieldName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdGameObjectivesData::execGetSubObjectives(FFrame&, void* const)
	public virtual /*native function */bool GetSubObjectives(name FieldName, ref array<UIDataProvider_TdGameObjectiveProvider.SubObjectiveStruct> Objectives, /*optional */bool? _bFilter = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameObjectivesData::execGetActiveSubObjective(FFrame&, void* const)
	public virtual /*native function */bool GetActiveSubObjective(name FieldName, ref UIDataProvider_TdGameObjectiveProvider.SubObjectiveStruct CurrentObjective)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameObjectivesData::execSetActiveSubObjective(FFrame&, void* const)
	public virtual /*native function */void SetActiveSubObjective(name FieldName, name SubObjectiveTag, /*optional */bool? _bOnlyHigher = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */bool ResolveSubObjectiveMapping(name MappingName, ref name SubObjectiveName)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool IsElementEnabled(name FieldName, int CollectionIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ResolveAndSetCheckpointObjective(name ObjectiveGameType, name CheckpointName, /*optional */bool? _bOnlyHigher = default)
	{
		// stub
	}
	
	public virtual /*function */void ClearCurrentSubObjective()
	{
		// stub
	}
	
	public UIDataStore_TdGameObjectivesData()
	{
		// Object Offset:0x006DC36C
		ObjectiveMappings = new array</*config */UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct>
		{
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Edge_Start",
				SubObjectiveName = (name)"Obj0ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"After_Intro",
				SubObjectiveName = (name)"Obj0ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Rooftop_Action",
				SubObjectiveName = (name)"Obj0ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SWAT_Response",
				SubObjectiveName = (name)"Obj0ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SWAT_Response2",
				SubObjectiveName = (name)"Obj0ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"After_Intro_flight",
				SubObjectiveName = (name)"Obj1ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"RPA_Lower",
				SubObjectiveName = (name)"Obj1ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Office",
				SubObjectiveName = (name)"Obj1ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Office_AfterCS",
				SubObjectiveName = (name)"Obj1ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Chase",
				SubObjectiveName = (name)"Obj1BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Avenue",
				SubObjectiveName = (name)"Obj1BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Plaza",
				SubObjectiveName = (name)"Obj1BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Canals",
				SubObjectiveName = (name)"Obj2ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Container",
				SubObjectiveName = (name)"Obj2ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Gate1",
				SubObjectiveName = (name)"Obj2ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"PillarRoom_Savepoint",
				SubObjectiveName = (name)"Obj2ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Chute2",
				SubObjectiveName = (name)"Obj2BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"construction",
				SubObjectiveName = (name)"Obj2BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"ChaseJK",
				SubObjectiveName = (name)"Obj2BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"JKfight",
				SubObjectiveName = (name)"Obj2BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SP03_Start",
				SubObjectiveName = (name)"Obj3ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"First_sluice",
				SubObjectiveName = (name)"Obj3ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SP03_Office_01",
				SubObjectiveName = (name)"Obj3ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SP03_Rooftop_01",
				SubObjectiveName = (name)"Obj3BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SP03_Rooftop_02",
				SubObjectiveName = (name)"Obj3BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SP03_Rooftop_before_swats",
				SubObjectiveName = (name)"Obj3BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"SP03_Plaza_01",
				SubObjectiveName = (name)"Obj3BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Start_point_subway",
				SubObjectiveName = (name)"Obj4ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"renco_after_cs",
				SubObjectiveName = (name)"Obj4ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Subway_bossfight",
				SubObjectiveName = (name)"Obj4ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"boss_fight_no_cs",
				SubObjectiveName = (name)"Obj4ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Renovation_fight",
				SubObjectiveName = (name)"Obj4ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Subway_Station",
				SubObjectiveName = (name)"Obj4BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Platform_fight",
				SubObjectiveName = (name)"Obj4BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Subway_Tunnels",
				SubObjectiveName = (name)"Obj4BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Train_Ride",
				SubObjectiveName = (name)"Obj4BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"LevelStart",
				SubObjectiveName = (name)"Obj5ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"CombatRooftops",
				SubObjectiveName = (name)"Obj5ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Stretch",
				SubObjectiveName = (name)"Obj5ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Mall",
				SubObjectiveName = (name)"Obj5ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Mall_Ambush",
				SubObjectiveName = (name)"Obj5BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"After_Ambush",
				SubObjectiveName = (name)"Obj5BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Blue_Vent",
				SubObjectiveName = (name)"Obj5BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"After_fan",
				SubObjectiveName = (name)"Obj5BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"CP_afterSWAT",
				SubObjectiveName = (name)"Obj5BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Start_point",
				SubObjectiveName = (name)"Obj6ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Loading_bay",
				SubObjectiveName = (name)"Obj6ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Loading_bay_2",
				SubObjectiveName = (name)"Obj6ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Loading_bay_2b",
				SubObjectiveName = (name)"Obj6ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Loading_bay_after",
				SubObjectiveName = (name)"Obj6ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Conveyor_puzzle",
				SubObjectiveName = (name)"Obj6ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Training_area",
				SubObjectiveName = (name)"Obj6BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Pursuit_chase",
				SubObjectiveName = (name)"Obj6BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Pursuit_chase",
				SubObjectiveName = (name)"Obj6BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Start",
				SubObjectiveName = (name)"Obj7ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"CarDeck",
				SubObjectiveName = (name)"Obj7ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Ventilation",
				SubObjectiveName = (name)"Obj7ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"TopBoat",
				SubObjectiveName = (name)"Obj7BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Celeste_Chase",
				SubObjectiveName = (name)"Obj7BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Celeste",
				SubObjectiveName = (name)"Obj7BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Kates_convoy",
				SubObjectiveName = (name)"Obj8ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Start_chasing",
				SubObjectiveName = (name)"Obj8ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Stretch2",
				SubObjectiveName = (name)"Obj8ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"combat_3",
				SubObjectiveName = (name)"Obj8BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Sniper",
				SubObjectiveName = (name)"Obj8BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Atrium2",
				SubObjectiveName = (name)"Obj8BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Scraper_Start",
				SubObjectiveName = (name)"Obj9ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Lobby",
				SubObjectiveName = (name)"Obj9ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Elevator_shaft",
				SubObjectiveName = (name)"Obj9ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Rooftops",
				SubObjectiveName = (name)"Obj9BSub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Server_room",
				SubObjectiveName = (name)"Obj9BSub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"Scraper_Mill-Main_Slc",
				SubObjectiveName = (name)"Obj9BSub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_ButtonTest",
				SubObjectiveName = (name)"TutObj1ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_JumpTimingOne",
				SubObjectiveName = (name)"TutObj1ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_SlideOne",
				SubObjectiveName = (name)"TutObj1ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_JumpTimingTwo",
				SubObjectiveName = (name)"TutObj1ASub4",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_VaultOver",
				SubObjectiveName = (name)"TutObj2ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_HorizontalWallrun",
				SubObjectiveName = (name)"TutObj2ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_SpeedVault",
				SubObjectiveName = (name)"TutObj2ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_Barge",
				SubObjectiveName = (name)"TutObj2ASub4",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_BalanceWalk",
				SubObjectiveName = (name)"TutObj3ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_VerticalWallrun",
				SubObjectiveName = (name)"TutObj4ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_Swing",
				SubObjectiveName = (name)"TutObj4ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_Climb",
				SubObjectiveName = (name)"TutObj4ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_Turn180",
				SubObjectiveName = (name)"TutObj4ASub4",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_JumpToGrab",
				SubObjectiveName = (name)"TutObj5ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_LedgeWalk",
				SubObjectiveName = (name)"TutObj5ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_ZipLine",
				SubObjectiveName = (name)"TutObj6ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_SoftLanding",
				SubObjectiveName = (name)"TutObj6ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_CoilJump",
				SubObjectiveName = (name)"TutObj7ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_BackToStart",
				SubObjectiveName = (name)"TutObj7ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_SpringBoard",
				SubObjectiveName = (name)"TutObj7ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_MeleeAttack",
				SubObjectiveName = (name)"TutObj8ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_LowMeleeAttack",
				SubObjectiveName = (name)"TutObj8ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_JumpKickAttack",
				SubObjectiveName = (name)"TutObj8ASub3",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_SlideKickAttack",
				SubObjectiveName = (name)"TutObj8ASub4",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_RearDisarm",
				SubObjectiveName = (name)"TutObj9ASub1",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_FrontDisarm",
				SubObjectiveName = (name)"TutObj9ASub2",
			},
			new UIDataStore_TdGameObjectivesData.ObjectiveMappingStruct
			{
				MappingName = (name)"EMC_FrontalDisarmRT",
				SubObjectiveName = (name)"TutObj9ASub3",
			},
		};
		CurrentObjectiveIndex = -1;
		LastReachedChallengeIndex = -1;
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"Objectives",
				ProviderClassName = "TdGame.UIDataProvider_TdGameObjectiveProvider",
				ProviderClass = default,
			},
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"Challenges",
				ProviderClassName = "TdGame.UIDataProvider_TdChallengeObjectiveProvider",
				ProviderClass = default,
			},
		};
		Tag = (name)"TdGameObjectivesData";
	}
}
}