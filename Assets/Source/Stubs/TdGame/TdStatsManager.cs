namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdStatsManager : Object/*
		config(Achievements)*/{
	public /*private transient */array<int> StatsArray;
	public /*transient */float CachedWalkingStateTime;
	public /*transient */float CachedStartWallrunTime;
	public /*transient */float CachedStartBagPickupTime;
	public/*()*/ /*config */int MaxMomentumTimeLimit;
	public/*()*/ /*config */int SPAirMeleeKillsLimit;
	public/*()*/ /*config */int SPDisarmLimit;
	public/*()*/ /*config */int SPMeleeLimit;
	public/*()*/ /*config */int SP180TauntLimit;
	public/*()*/ /*config */int SPLandOnHeadLimit;
	public/*()*/ /*config */int NumberOfBagsToFindForFirstAchievement;
	
	public virtual /*function */void ResetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID Id, TdProfileSettings P)
	{
		// stub
	}
	
	public virtual /*function */void ResetStats(TdProfileSettings P, bool bLevelStats, bool bGameStats, bool bGlobalStats)
	{
		// stub
	}
	
	public virtual /*function */void SaveStatsToProfile(TdProfileSettings P, bool bLevelStats, bool bGameStats, bool bGlobalStats)
	{
		// stub
	}
	
	public virtual /*function */void LoadStatsFromProfile(TdProfileSettings P, bool bLevelStats, bool bGameStats, bool bGlobalStats)
	{
		// stub
	}
	
	public virtual /*function */void ShowAchievementStats(TdProfileSettings P)
	{
		// stub
	}
	
	public virtual /*function */bool RegisterStats(SeqAct_TdRegisterStat.EAchievementStatsID Id, float Time, TdProfileSettings P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetToDefaults(TdProfileSettings P)
	{
		// stub
	}
	
	public virtual /*function */int GetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID Id, TdProfileSettings P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool RegisterFoundBag(int BagIndex, TdProfileSettings P)
	{
		// stub
		return default;
	}
	
	public TdStatsManager()
	{
		// Object Offset:0x006731BC
		CachedWalkingStateTime = 1000000000.0f;
		MaxMomentumTimeLimit = 30;
		SPAirMeleeKillsLimit = 1;
		SPDisarmLimit = 15;
		SPMeleeLimit = 20;
		SP180TauntLimit = 1;
		SPLandOnHeadLimit = 1;
		NumberOfBagsToFindForFirstAchievement = 11;
	}
}
}