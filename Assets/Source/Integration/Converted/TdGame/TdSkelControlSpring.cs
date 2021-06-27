namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlSpring : SkelControlSingleBone/*
		native
		config(Animation)
		hidecategories(Object)*/{
	public/*()*/ /*config */bool EnableVelocityDependedTranslationSpring;
	public/*()*/ /*config */bool EnableOnSpecificWeaponType;
	public/*()*/ bool bInvertYaw;
	public/*()*/ bool bInvertPitch;
	public/*()*/ bool bInvertRoll;
	public bool bInitialized;
	public bool bLag;
	public bool bOverlap;
	public/*()*/ /*config */bool EnableAccelerationBased;
	public/*()*/ /*config */bool bIsAppliedToWrist;
	public bool HasReachedTargetVelocity;
	public bool bDeltaIsIncreasing;
	public/*()*/ TdPawn.EWeaponType SpringWeaponType;
	public/*()*/ /*config */float SpringYawInterpVel;
	public/*()*/ /*config */float SpringPitchInterpVel;
	public/*()*/ /*config */float SpringRollInterpVel;
	public/*()*/ /*config */float TimeBetweenSpringUpdates;
	public float PreviousYaw;
	public float PreviousPitch;
	public float YawTargetDiff;
	public float PitchTargetDiff;
	public float RollTargetDiff;
	public float CurrentYawInterp;
	public float CurrentPitchInterp;
	public float CurrentRollInterp;
	public float CurrentYawInterpVel;
	public float YawDeltaTarget;
	public float YawTargetSpeed;
	public/*()*/ /*config */float MaxPitchDeltaOffset;
	public/*()*/ /*config */float MaxYawDeltaOffset;
	public/*()*/ /*config */float MaxRollDeltaOffset;
	public float CurrTime;
	public Object.Rotator PreviousPlayerControllerRotation;
	public Object.Vector PreviousLinearVelocity;
	public Object.Vector PreviousAngularVelocity;
	public Object.Vector PreviousAngularAcceleration;
	public Object.Rotator PreviousDeltaRotation;
	public Object.Rotator PreviousDeltaInterpolation;
	public Object.Rotator TargetRotator;
	public Object.Rotator InterpolatedRotator;
	public Object.Rotator AngularRotationLimiter;
	public Object.Rotator PreviousInterpolatedRotator;
	public Object.Vector VelocityIncrement;
	public Object.Vector InterpolationVelocity;
	public Object.Vector TargetInterpolationVelocity;
	public Object.Vector VelocityInterpolationSpeed;
	public/*(Lag)*/ /*config */Object.Vector DefaultInterpolationVelocity;
	public/*(Lag)*/ /*config */Object.Vector DefaultVelocityIncrement;
	public/*(Lag)*/ /*config */Object.Vector DefaultVelocityDecrement;
	public/*(Lag)*/ /*config */Object.Rotator DefaultAngularRotationLimiter;
	public/*(Lag)*/ /*config */Object.Vector AngularVelocityTargetMuliplier;
	public/*(Lag)*/ /*config */Object.Vector AngularVelocityLowerThresholdMuliplier;
	public/*(Lag)*/ /*config */Object.Vector AngularVelocityDecreaseInterpSpeed;
	public Object.Rotator OverlapRotator;
	public Object.Rotator InterpolatedOverlapRotator;
	public Object.Rotator TargetOverlapRotator;
	public Object.Vector OverlapVelocity;
	public/*(Overlap)*/ /*config */Object.Vector OverlapVelocityIncrement;
	public/*(Overlap)*/ /*config */Object.Vector ThresholdSmall;
	public/*(Overlap)*/ /*config */Object.Vector ThresholdMedium;
	public/*(Overlap)*/ /*config */Object.Vector ThresholdLarge;
	public/*(Overlap)*/ /*config */Object.Vector VelocitySmall;
	public/*(Overlap)*/ /*config */Object.Vector VelocityMedium;
	public/*(Overlap)*/ /*config */Object.Vector VelocityLarge;
	public/*(Overlap)*/ /*config */Object.Rotator RotatorSmall;
	public/*(Overlap)*/ /*config */Object.Rotator RotatorMedium;
	public/*(Overlap)*/ /*config */Object.Rotator RotatorLarge;
	public float ControllerTime;
	public/*()*/ /*config */float ControllerTimeLimit;
	public Object.Rotator ZeroRotator;
	public Object.Vector ZeroVector;
	
	public TdSkelControlSpring()
	{
		// Object Offset:0x00658E8A
		EnableOnSpecificWeaponType = true;
		bInvertPitch = true;
		bLag = true;
		bOverlap = true;
		SpringWeaponType = TdPawn.EWeaponType.EWT_Light;
		SpringYawInterpVel = 5.0f;
		SpringPitchInterpVel = 10.0f;
		SpringRollInterpVel = 5.0f;
		TimeBetweenSpringUpdates = 0.040f;
		YawTargetSpeed = 0.010f;
		MaxPitchDeltaOffset = 45.0f;
		MaxYawDeltaOffset = 45.0f;
		MaxRollDeltaOffset = 45.0f;
		DefaultInterpolationVelocity = new Vector
		{
			X=10.0f,
			Y=75.0f,
			Z=0.0f
		};
		DefaultVelocityIncrement = new Vector
		{
			X=5.0f,
			Y=20.0f,
			Z=0.0f
		};
		DefaultVelocityDecrement = new Vector
		{
			X=0.0f,
			Y=-4.250f,
			Z=0.0f
		};
		DefaultAngularRotationLimiter = new Rotator
		{
			Pitch=7282,
			Yaw=4551,
			Roll=4551
		};
		AngularVelocityTargetMuliplier = new Vector
		{
			X=0.0f,
			Y=1.150f,
			Z=0.0f
		};
		AngularVelocityLowerThresholdMuliplier = new Vector
		{
			X=0.0f,
			Y=1.050f,
			Z=0.0f
		};
		AngularVelocityDecreaseInterpSpeed = new Vector
		{
			X=0.0f,
			Y=25.0f,
			Z=0.0f
		};
		OverlapVelocityIncrement = new Vector
		{
			X=5.0f,
			Y=15.0f,
			Z=0.0f
		};
		ThresholdSmall = new Vector
		{
			X=0.0f,
			Y=20.0f,
			Z=0.0f
		};
		ThresholdMedium = new Vector
		{
			X=0.0f,
			Y=40.0f,
			Z=0.0f
		};
		ThresholdLarge = new Vector
		{
			X=0.0f,
			Y=90.0f,
			Z=0.0f
		};
		VelocitySmall = new Vector
		{
			X=0.0f,
			Y=5.0f,
			Z=0.0f
		};
		VelocityMedium = new Vector
		{
			X=0.0f,
			Y=25.0f,
			Z=0.0f
		};
		VelocityLarge = new Vector
		{
			X=0.0f,
			Y=80.0f,
			Z=0.0f
		};
		RotatorSmall = new Rotator
		{
			Pitch=0,
			Yaw=455,
			Roll=0
		};
		RotatorMedium = new Rotator
		{
			Pitch=0,
			Yaw=910,
			Roll=0
		};
		RotatorLarge = new Rotator
		{
			Pitch=0,
			Yaw=1365,
			Roll=0
		};
		ControllerTimeLimit = 0.150f;
	}
}
}