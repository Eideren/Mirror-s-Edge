namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdRegisterStat : SequenceAction/*
		hidecategories(Object)*/{
	public enum EAchievementStatsID 
	{
		EASID_ShotsFired,
		EASID_MeleeKills,
		EASID_SPMeleeAirKills,
		EASID_SPMeleeDisarmKills,
		EASID_HitByEnemyWeapon,
		EASID_HittingEnemyWithWeapon,
		EASID_StartFullMomentum,
		EASID_EndFullMomentum,
		EASID_HeavyLanding,
		EASID_LandingOnEnemyHead,
		EASID_180Taunt,
		EASID_PackageFound_0a,
		EASID_PackageFound_0b,
		EASID_PackageFound_0c,
		EASID_PackageFound_1a,
		EASID_PackageFound_1b,
		EASID_PackageFound_1c,
		EASID_PackageFound_2a,
		EASID_PackageFound_2b,
		EASID_PackageFound_2c,
		EASID_PackageFound_3a,
		EASID_PackageFound_3b,
		EASID_PackageFound_3c,
		EASID_PackageFound_4a,
		EASID_PackageFound_4b,
		EASID_PackageFound_4c,
		EASID_PackageFound_5a,
		EASID_PackageFound_5b,
		EASID_PackageFound_5c,
		EASID_PackageFound_6a,
		EASID_PackageFound_6b,
		EASID_PackageFound_6c,
		EASID_PackageFound_7a,
		EASID_PackageFound_7b,
		EASID_PackageFound_7c,
		EASID_PackageFound_8a,
		EASID_PackageFound_8b,
		EASID_PackageFound_8c,
		EASID_PackageFound_9a,
		EASID_PackageFound_9b,
		EASID_PackageFound_9c,
		EASID_NumberOfEASIDs,
		EASID_MAX
	};
	
	public/*()*/ SeqAct_TdRegisterStat.EAchievementStatsID StatId;
	public /*transient */TdPlayerController PlayerController;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdRegisterStat()
	{
		// Object Offset:0x0049E9C2
		ObjName = "Register Stat";
		ObjCategory = "Td Achievements";
	}
}
}