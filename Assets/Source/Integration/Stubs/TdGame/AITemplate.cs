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
	
	[Category] [config] public String ControllerClass;
	[Category] [config] public String PawnClass;
	[Category] [config] public String ProfileName;
	[Category] [config] public StaticArray<String, String>/*[2]*/ AnimationSets;
	[Category] [config] public String SkeletalMesh;
	[Category] [config] public String AdditionalSkeletalMesh;
	[Category] [config] public String ExtraFaithAnimationSet1p;
	[Category] [config] public String ExtraFaithAnimationSet3p;
	[Category] [config] public float LegOffsetWalkFwd;
	[Category] [config] public float LegOffsetWalkLeft60;
	[Category] [config] public float LegOffsetWalkLeftBwd120;
	[Category] [config] public float LegOffsetWalkRight60;
	[Category] [config] public float LegOffsetWalkRightBwd120;
	[Category] [config] public float LegOffsetWalkBack;
	[Category] [config] public float LegOffsetRunFwd;
	[Category] [config] public float LegOffsetRunLeft90;
	[Category] [config] public float LegOffsetRunLeft180;
	[Category] [config] public float LegOffsetRunRight90;
	[Category] [config] public float LegOffsetRunRight180;
	[Category] [config] public bool bLeftFootWalkCycle;
	[Category] [config] public bool bCanDoSpecialMoves;
	[Category] [config] public bool CanRun;
	[Category] [config] public bool bMute;
	[Category] [config] public bool CanUseSuppressionFire;
	[Category] [config] public bool bEnableInverseKinematics;
	[Category] [config] public bool bEnableFootPlacement;
	[Category] [config] public bool bEnableMeleePose;
	[Category] [config] public bool ShouldBlink;
	[Category] [config] public float Dispersion_Max;
	[Category] [config] public float Dispersion_Min;
	[Category] [config] public AITemplate.DistanceBasedValue HorizontalOffset_Max;
	[Category] [config] public float HorizontalOffset_Min;
	[Category] [config] public float VerticalOffset_Max;
	[Category] [config] public float VerticalOffset_Min;
	[Category] [config] public AITemplate.DistanceBasedValue OffsetThreshold;
	[Category] [config] public float MoveSidewaysMultiplier;
	[Category] [config] public float MoveAwayMultiplier;
	[Category] [config] public float MoveTowardMultiplier;
	[Category] [config] public AITemplate.ImprovementRateSettings ImprovementRates_Near;
	[Category] [config] public AITemplate.ImprovementRateSettings ImprovementRates_Medium;
	[Category] [config] public AITemplate.ImprovementRateSettings ImprovementRates_Far;
	[Category] [config] public AITemplate.ImprovementRateSettings ImprovementRates_Near_CHASE;
	[Category] [config] public AITemplate.ImprovementRateSettings ImprovementRates_Medium_CHASE;
	[Category] [config] public AITemplate.ImprovementRateSettings ImprovementRates_Far_CHASE;
	[Category] [Const, config] public AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Dropped_CHASE;
	[Category] [Const, config] public AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Disarmed_CHASE;
	[Category] [config] public float SoftLockStrength_CHASE;
	[Category] [config] public int MeleeAttackLimit_CHASE;
	[Category] [config] public AITemplate.ImprovementRateSettings RegenerationDelay;
	[Category] [config] public float MovementRate_Horizontal;
	[Category] [config] public float MovementRate_Vertical;
	[Category] [config] public float CosHalfAttackAngle;
	[Category] [config] public float DamageMultiplier_Head;
	[Category] [config] public float DamageMultiplier_Body;
	[Category] [config] public float VisionAngle;
	[Category] [config] public float CertainVisionRange;
	[Category] [config] public float UncertainVisionRange;
	[Category] [config] public float HearingRange;
	[Category] public Object.InterpCurveFloat SpeedCurve_HeavyWeapon;
	[Category] public Object.InterpCurveFloat SpeedCurve_LightWeapon;
	[Category] [config] public int RotationSpeed;
	[Category] [config] public String MainWeaponClass;
	[Category] [Const, config] public AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Dropped;
	[Category] [Const, config] public AITemplate.AmmoDropSettings MainWeaponAmmoDrops_Disarmed;
	[Category] [config] public array</*config */String> OtherWeaponClasses;
	[Category] [config] public String DroppedGrenadeClass;
	[Category] [config] public String ShieldClass;
	[Category] [config] public String AimProfileName;
	[Category] [config] public int MaxHealth;
	[Category] [config] public float SuppressionRecoveryTime;
	[Category] [config] public float SuppressionDeclineTime;
	[Category] [config] public float SuppressionDistance;
	[Category] [config] public float SuppressionFactorForDirectHit;
	[Category] [config] public float MeleeRange;
	[Category] [config] public float MeleeRangeSecondAttack;
	[Category] [config] public float DisarmWindow;
	[Category] [config] public/*private*/ float MeleePredictionTimeMin;
	[Category] [config] public/*private*/ float MeleePredictionTimeMax;
	[Category] [config] public int MeleeAttackLimit;
	[Category] [config] public float MeleeLayDownIdleTime;
	[Category] [config] public float SoftLockStrength;
	[Category] [config] public float SuppressionTime;
	[Category] [config] public float YawLimitDrop;
	[Category] [config] public float YawLimitActivate;
	[Category] [config] public float YawLimitMin;
	[Category] [config] public float YawLimitMax;
	[Category] [config] public float PitchLimitMin;
	[Category] [config] public float PitchLimitMax;
	[Category] [config] public float HeadAimScale;
	[Category] [config] public float MaxEyesOffsetUpper;
	[Category] [config] public float MinEyesOffsetUpper;
	[Category] [config] public float MaxEyesOffsetLower;
	[Category] [config] public float MinEyesOffsetLower;
	[Category] [config] public float ClosedEyeOffsetUpper;
	[Category] [config] public float ClosedEyeOffsetLower;
	
	// Export UAITemplate::execGetClassFromName(FFrame&, void* const)
	public virtual /*native final function */Class GetClassFromName(String TheClassName)
	{
		NativeMarkers.MarkUnimplemented();
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