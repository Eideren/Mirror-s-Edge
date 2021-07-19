namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdUnlockAchievement : SequenceAction/*
		hidecategories(Object)*/{
	public enum ETdAchievements 
	{
		ETA_Invalid_Achievement,
		ETA_Level_1_Complete,
		ETA_Level_2_Complete,
		ETA_Level_3_Complete,
		ETA_Level_4_Complete,
		ETA_Level_5_Complete,
		ETA_Level_6_Complete,
		ETA_Level_7_Complete,
		ETA_Level_8_Complete,
		ETA_Level_9_Complete,
		ETA_Complete_Time_Trial,
		ETA_Tutorial_Complete,
		ETA_Unlock_All_Time_Trial_Stretches,
		ETA_SkillRating_20,
		ETA_SkillRating_35,
		ETA_SkillRating_50,
		ETA_SpeedRun_1_Complete,
		ETA_SpeedRun_2_Complete,
		ETA_SpeedRun_3_Complete,
		ETA_SpeedRun_4_Complete,
		ETA_SpeedRun_5_Complete,
		ETA_SpeedRun_6_Complete,
		ETA_SpeedRun_7_Complete,
		ETA_SpeedRun_8_Complete,
		ETA_SpeedRun_9_Complete,
		ETA_SpeedRun_10_Complete,
		ETA_SP_Complete,
		ETA_SP_On_Hard_Complete,
		ETA_Beat_Level_Without_Getting_Shot,
		ETA_Beat_Level_Without_Heavy_Landing,
		ETA_Complete_Level_Without_Shooting,
		ETA_Complete_Game_Without_Bullet_Hurting,
		ETA_Full_Momentum_For_X_Seconds,
		ETA_Perform_Air_Melee_Kill,
		ETA_Perform_X_Disarms,
		ETA_Perform_X_Melee_Kills,
		ETA_180_Taunt,
		ETA_Land_On_Enemy_Head,
		ETA_StringJumpCoilSlide,
		ETA_StringWallrunJumpSV,
		ETA_StringWallrun90JumpWC180Jump,
		ETA_StringWallrunJumpCoilSkillroll,
		ETA_All_PackagesFound,
		ETA_All_PackagesInLevelFound,
		ETA_X_PackagesFound,
		ETA_MAX
	};
	
	[Category] public SeqAct_TdUnlockAchievement.ETdAchievements AchievementId;
	[transient] public TdPlayerController PlayerController;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdUnlockAchievement()
	{
		// Object Offset:0x004A5EDA
		ObjName = "Unlock Achievement";
		ObjCategory = "Td Achievements";
	}
}
}