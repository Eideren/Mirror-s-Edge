namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate : Object/*
		abstract
		native
		config(AITemplates)*/{
	public const int AITEMPLATE_MAX_ANIMSETS = 2;
	
	public partial struct /*native */AmmoDropSettings
	{
		public int Easy;
		public int Medium;
		public int Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00486CFE
	//		Easy = 0;
	//		Medium = 0;
	//		Hard = 0;
	//	}
	};
	
	public partial struct /*native */DistanceBasedValue
	{
		public float Near;
		public float Medium;
		public float Far;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00486E0E
	//		Near = 0.0f;
	//		Medium = 0.0f;
	//		Far = 0.0f;
	//	}
	};
	
	public partial struct /*native */ImprovementRateSettings
	{
		public float Easy;
		public float Medium;
		public float Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00486F1E
	//		Easy = 0.0f;
	//		Medium = 0.0f;
	//		Hard = 0.0f;
	//	}
	};
	
	public/*()*/ /*config */String ControllerClass;
	public/*()*/ /*config */String PawnClass;
	public/*()*/ /*config */String ProfileName;
	public/*()*/ /*config */StaticArray<String, String>/*[2]*/ AnimationSets;
	public/*()*/ /*config */String SkeletalMesh;
	public/*()*/ /*config */String AdditionalSkeletalMesh;
	public/*()*/ /*config */String ExtraFaithAnimationSet1p;
	public/*()*/ /*config */String ExtraFaithAnimationSet3p;
	public/*()*/ /*config */float LegOffsetWalkFwd;
	public/*()*/ /*config */float LegOffsetWalkLeft60;
	public/*()*/ /*config */float LegOffsetWalkLeftBwd120;
	public/*()*/ /*config */float LegOffsetWalkRight60;
	public/*()*/ /*config */float LegOffsetWalkRightBwd120;
	public/*()*/ /*config */float LegOffsetWalkBack;
	public/*()*/ /*config */float LegOffsetRunFwd;
	public/*()*/ /*config */float LegOffsetRunLeft90;
	public/*()*/ /*config */float LegOffsetRunLeft180;
	public/*()*/ /*config */float LegOffsetRunRight90;
	public/*()*/ /*config */float LegOffsetRunRight180;
	public/*()*/ /*config */bool bLeftFootWalkCycle;
	public/*()*/ /*config */bool bCanDoSpecialMoves;
	public/*()*/ /*config */bool CanRun;
	public/*()*/ /*config */bool bMute;
	public/*()*/ /*config */bool CanUseSuppressionFire;
	public/*()*/ /*config */bool bEnableInverseKinematics;
	public/*()*/ /*config */bool bEnableFootPlacement;
	public/*()*/ /*config */bool bEnableMeleePose;
	public/*()*/ /*config */bool ShouldBlink;
	public/*()*/ /*config */float Dispersion_Max;
	public/*()*/ /*config */float Dispersion_Min;
	public/*()*/ /*config */AITemplate.DistanceBasedValue HorizontalOffset_Max;
	public/*()*/ /*config */float HorizontalOffset_Min;
	public/*()*/ /*config */float VerticalOffset_Max;
	public/*()*/ /*config */float VerticalOffset_Min;
	public/*()*/ /*config */AITemplate.DistanceBasedValue OffsetThreshold;
	public/*()*/ /*config */float MoveSidewaysMultiplier;
	public/*()*/ /*config */float MoveAwayMultiplier;
	public/*()*/ /*config */float MoveTowardMultiplier;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings ImprovementRates_Near;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings ImprovementRates_Medium;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings ImprovementRates_Far;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings ImprovementRates_Near_CHASE;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings ImprovementRates_Medium_CHASE;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings ImprovementRates_Far_CHASE;
	public/*()*/ /*const config */AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Dropped_CHASE;
	public/*()*/ /*const config */AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Disarmed_CHASE;
	public/*()*/ /*config */float SoftLockStrength_CHASE;
	public/*()*/ /*config */int MeleeAttackLimit_CHASE;
	public/*()*/ /*config */AITemplate.ImprovementRateSettings RegenerationDelay;
	public/*()*/ /*config */float MovementRate_Horizontal;
	public/*()*/ /*config */float MovementRate_Vertical;
	public/*()*/ /*config */float CosHalfAttackAngle;
	public/*()*/ /*config */float DamageMultiplier_Head;
	public/*()*/ /*config */float DamageMultiplier_Body;
	public/*()*/ /*config */float VisionAngle;
	public/*()*/ /*config */float CertainVisionRange;
	public/*()*/ /*config */float UncertainVisionRange;
	public/*()*/ /*config */float HearingRange;
	public/*()*/ Object.InterpCurveFloat SpeedCurve_HeavyWeapon;
	public/*()*/ Object.InterpCurveFloat SpeedCurve_LightWeapon;
	public/*()*/ /*config */int RotationSpeed;
	public/*()*/ /*config */String MainWeaponClass;
	public/*()*/ /*const config */AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Dropped;
	public/*()*/ /*const config */AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Disarmed;
	public/*()*/ /*config */array</*config */String> OtherWeaponClasses;
	public/*()*/ /*config */String DroppedGrenadeClass;
	public/*()*/ /*config */String ShieldClass;
	public/*()*/ /*config */String AimProfileName;
	public/*()*/ /*config */int MaxHealth;
	public/*()*/ /*config */float SuppressionRecoveryTime;
	public/*()*/ /*config */float SuppressionDeclineTime;
	public/*()*/ /*config */float SuppressionDistance;
	public/*()*/ /*config */float SuppressionFactorForDirectHit;
	public/*()*/ /*config */float MeleeRange;
	public/*()*/ /*config */float MeleeRangeSecondAttack;
	public/*()*/ /*config */float DisarmWindow;
	public/*()*/ /*private config */float MeleePredictionTimeMin;
	public/*()*/ /*private config */float MeleePredictionTimeMax;
	public/*()*/ /*config */int MeleeAttackLimit;
	public/*()*/ /*config */float MeleeLayDownIdleTime;
	public/*()*/ /*config */float SoftLockStrength;
	public/*()*/ /*config */float SuppressionTime;
	public/*()*/ /*config */float YawLimitDrop;
	public/*()*/ /*config */float YawLimitActivate;
	public/*()*/ /*config */float YawLimitMin;
	public/*()*/ /*config */float YawLimitMax;
	public/*()*/ /*config */float PitchLimitMin;
	public/*()*/ /*config */float PitchLimitMax;
	public/*()*/ /*config */float HeadAimScale;
	public/*()*/ /*config */float MaxEyesOffsetUpper;
	public/*()*/ /*config */float MinEyesOffsetUpper;
	public/*()*/ /*config */float MaxEyesOffsetLower;
	public/*()*/ /*config */float MinEyesOffsetLower;
	public/*()*/ /*config */float ClosedEyeOffsetUpper;
	public/*()*/ /*config */float ClosedEyeOffsetLower;
	
	// Export UAITemplate::execGetClassFromName(FFrame&, void* const)
	public virtual /*native final function */Class GetClassFromName(String TheClassName)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*function */float GetRandomMeleePredictionTime()
	{
		// stub
		return default;
	}
	
}
}