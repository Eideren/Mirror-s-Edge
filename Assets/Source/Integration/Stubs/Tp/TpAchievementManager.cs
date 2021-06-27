namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpAchievementManager : TpSystemHandler/*
		abstract
		transient
		native
		config(Achievements)*/{
	public partial struct /*native */AchBind
	{
		public /*config */int Id;
		public /*config */String AchCode;
		public /*config */int XboxId;
		public /*config */int TrophyId;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00037D91
	//		Id = 0;
	//		AchCode = "";
	//		XboxId = 0;
	//		TrophyId = 0;
	//	}
	};
	
	public /*config */array</*config */TpAchievementManager.AchBind> AchievementBindings;
	public /*delegate*/TpAchievementManager.OnGrantAward __OnGrantAward__Delegate;
	
	// Export UTpAchievementManager::execGrantAward(FFrame&, void* const)
	public virtual /*native simulated function */void GrantAward(ref TpAchievementManager.AchBind Award)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnGrantAward();
	
	// Export UTpAchievementManager::execShowXBOXAchievementsUI(FFrame&, void* const)
	public virtual /*native simulated function */bool ShowXBOXAchievementsUI(byte LocalUserNum)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public TpAchievementManager()
	{
		// Object Offset:0x00037FEB
		AchievementBindings = new array</*config */TpAchievementManager.AchBind>
		{
			new TpAchievementManager.AchBind
			{
				Id = 1,
				AchCode = "Level_1_Complete",
				XboxId = 42,
				TrophyId = 2,
			},
			new TpAchievementManager.AchBind
			{
				Id = 2,
				AchCode = "Level_2_Complete",
				XboxId = 44,
				TrophyId = 3,
			},
			new TpAchievementManager.AchBind
			{
				Id = 3,
				AchCode = "Level_3_Complete",
				XboxId = 45,
				TrophyId = 4,
			},
			new TpAchievementManager.AchBind
			{
				Id = 4,
				AchCode = "Level_4_Complete",
				XboxId = 46,
				TrophyId = 5,
			},
			new TpAchievementManager.AchBind
			{
				Id = 5,
				AchCode = "Level_5_Complete",
				XboxId = 47,
				TrophyId = 6,
			},
			new TpAchievementManager.AchBind
			{
				Id = 6,
				AchCode = "Level_6_Complete",
				XboxId = 48,
				TrophyId = 7,
			},
			new TpAchievementManager.AchBind
			{
				Id = 7,
				AchCode = "Level_7_Complete",
				XboxId = 49,
				TrophyId = 8,
			},
			new TpAchievementManager.AchBind
			{
				Id = 8,
				AchCode = "Level_8_Complete",
				XboxId = 50,
				TrophyId = 9,
			},
			new TpAchievementManager.AchBind
			{
				Id = 9,
				AchCode = "Level_9_Complete",
				XboxId = 51,
				TrophyId = 10,
			},
			new TpAchievementManager.AchBind
			{
				Id = 10,
				AchCode = "Complete_Time_Trial",
				XboxId = 56,
				TrophyId = 16,
			},
			new TpAchievementManager.AchBind
			{
				Id = 11,
				AchCode = "Complete_Tutorial",
				XboxId = 37,
				TrophyId = 1,
			},
			new TpAchievementManager.AchBind
			{
				Id = 12,
				AchCode = "Unlock_All_Time_Trial_Stretches",
				XboxId = 12,
				TrophyId = 17,
			},
			new TpAchievementManager.AchBind
			{
				Id = 13,
				AchCode = "TT_SkillRating_20",
				XboxId = 57,
				TrophyId = 18,
			},
			new TpAchievementManager.AchBind
			{
				Id = 14,
				AchCode = "TT_SkillRating_35",
				XboxId = 58,
				TrophyId = 19,
			},
			new TpAchievementManager.AchBind
			{
				Id = 15,
				AchCode = "TT_SkillRating_50",
				XboxId = 59,
				TrophyId = 20,
			},
			new TpAchievementManager.AchBind
			{
				Id = 16,
				AchCode = "SpeedRun_1_Complete",
				XboxId = 60,
				TrophyId = 21,
			},
			new TpAchievementManager.AchBind
			{
				Id = 17,
				AchCode = "SpeedRun_2_Complete",
				XboxId = 61,
				TrophyId = 22,
			},
			new TpAchievementManager.AchBind
			{
				Id = 18,
				AchCode = "SpeedRun_3_Complete",
				XboxId = 62,
				TrophyId = 23,
			},
			new TpAchievementManager.AchBind
			{
				Id = 19,
				AchCode = "SpeedRun_4_Complete",
				XboxId = 63,
				TrophyId = 24,
			},
			new TpAchievementManager.AchBind
			{
				Id = 20,
				AchCode = "SpeedRun_5_Complete",
				XboxId = 64,
				TrophyId = 25,
			},
			new TpAchievementManager.AchBind
			{
				Id = 21,
				AchCode = "SpeedRun_6_Complete",
				XboxId = 65,
				TrophyId = 26,
			},
			new TpAchievementManager.AchBind
			{
				Id = 22,
				AchCode = "SpeedRun_7_Complete",
				XboxId = 66,
				TrophyId = 27,
			},
			new TpAchievementManager.AchBind
			{
				Id = 23,
				AchCode = "SpeedRun_8_Complete",
				XboxId = 67,
				TrophyId = 28,
			},
			new TpAchievementManager.AchBind
			{
				Id = 24,
				AchCode = "SpeedRun_9_Complete",
				XboxId = 68,
				TrophyId = 29,
			},
			new TpAchievementManager.AchBind
			{
				Id = 25,
				AchCode = "SpeedRun_10_Complete",
				XboxId = 69,
				TrophyId = 30,
			},
			new TpAchievementManager.AchBind
			{
				Id = 26,
				AchCode = "Complete_SP",
				XboxId = 52,
				TrophyId = 11,
			},
			new TpAchievementManager.AchBind
			{
				Id = 27,
				AchCode = "Complete_SP_On_Hard",
				XboxId = 54,
				TrophyId = 12,
			},
			new TpAchievementManager.AchBind
			{
				Id = 28,
				AchCode = "Beat_Level_Without_Getting_Shot",
				XboxId = 76,
				TrophyId = 37,
			},
			new TpAchievementManager.AchBind
			{
				Id = 29,
				AchCode = "Beat_Level_Without_Heavy_Landing",
				XboxId = 75,
				TrophyId = 36,
			},
			new TpAchievementManager.AchBind
			{
				Id = 30,
				AchCode = "Beat_Level_Without_Shooting",
				XboxId = 77,
				TrophyId = 38,
			},
			new TpAchievementManager.AchBind
			{
				Id = 31,
				AchCode = "Beat_Game_Without_Bullet_Hurting",
				XboxId = 78,
				TrophyId = 39,
			},
			new TpAchievementManager.AchBind
			{
				Id = 32,
				AchCode = "Full_Momentum_For_X_Seconds",
				XboxId = 70,
				TrophyId = 31,
			},
			new TpAchievementManager.AchBind
			{
				Id = 33,
				AchCode = "Perform_Air_Melee_Kill",
				XboxId = 79,
				TrophyId = 40,
			},
			new TpAchievementManager.AchBind
			{
				Id = 34,
				AchCode = "Perform_X_Disarms",
				XboxId = 22,
				TrophyId = 41,
			},
			new TpAchievementManager.AchBind
			{
				Id = 35,
				AchCode = "Perform_X_Melee_Kills",
				XboxId = 20,
				TrophyId = 42,
			},
			new TpAchievementManager.AchBind
			{
				Id = 36,
				AchCode = "180_Taunt",
				XboxId = 81,
				TrophyId = 43,
			},
			new TpAchievementManager.AchBind
			{
				Id = 37,
				AchCode = "Land_On_Enemy_Head",
				XboxId = 80,
				TrophyId = 44,
			},
			new TpAchievementManager.AchBind
			{
				Id = 38,
				AchCode = "StringJumpCoilSlide",
				XboxId = 71,
				TrophyId = 32,
			},
			new TpAchievementManager.AchBind
			{
				Id = 39,
				AchCode = "StringWallrunJumpSV",
				XboxId = 72,
				TrophyId = 33,
			},
			new TpAchievementManager.AchBind
			{
				Id = 40,
				AchCode = "StringWallrun90JumpWC180Jump",
				XboxId = 73,
				TrophyId = 34,
			},
			new TpAchievementManager.AchBind
			{
				Id = 41,
				AchCode = "StringWallrunJumpCoilSkillroll",
				XboxId = 74,
				TrophyId = 35,
			},
			new TpAchievementManager.AchBind
			{
				Id = 42,
				AchCode = "All_PackagesFound",
				XboxId = 23,
				TrophyId = 15,
			},
			new TpAchievementManager.AchBind
			{
				Id = 43,
				AchCode = "AllPackagesInLevelFound",
				XboxId = 53,
				TrophyId = 13,
			},
			new TpAchievementManager.AchBind
			{
				Id = 44,
				AchCode = "X_PackagesFound",
				XboxId = 55,
				TrophyId = 14,
			},
		};
	}
}
}