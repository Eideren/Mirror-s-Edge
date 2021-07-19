namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PostProcessVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public partial struct /*native */CurveInfo
	{
		[Category] [editinline] public StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/ Ms;
		[Category] [editinline] public StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/ Bs;
		public array<Object.Vector2D> ControlPointsR;
		public array<Object.Vector2D> ControlPointsG;
		public array<Object.Vector2D> ControlPointsB;
		public array<Object.Vector2D> ControlPointsA;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00278516
	//		Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//		{ 
	//			[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[2] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[3] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[4] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[5] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[6] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[7] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[8] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[9] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[10] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[11] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[12] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[13] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[14] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[15] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	// 		};
	//		Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//		{ 
	//			[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[2] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[3] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[4] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[5] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[6] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[7] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[8] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[9] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[10] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[11] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[12] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[13] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[14] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			[15] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	// 		};
	//		ControlPointsR = default;
	//		ControlPointsG = default;
	//		ControlPointsB = default;
	//		ControlPointsA = default;
	//	}
	};
	
	public partial struct /*native */PostProcessSettings
	{
		[Category] public bool bEnableBloom;
		[Category] public bool bEnableDOF;
		[Category] public bool bEnableMotionBlur;
		[Category] public bool bEnableSceneEffect;
		[Category] [interp] public float Bloom_Scale;
		[Category] public float Bloom_InterpolationDuration;
		[Category] [interp] public float DOF_FalloffExponent;
		[Category] [interp] public float DOF_BlurKernelSize;
		[Category] [interp] public float DOF_MaxNearBlurAmount;
		[Category] [interp] public float DOF_MaxFarBlurAmount;
		[Category] public Object.Color DOF_ModulateBlurColor;
		[Category] public DOFEffect.EFocusType DOF_FocusType;
		[Category] [interp] public float DOF_FocusInnerRadius;
		[Category] [interp] public float DOF_FocusDistance;
		[Category] public Object.Vector DOF_FocusPosition;
		[Category] public float DOF_InterpolationDuration;
		[Category] public bool DOF_Autofocus;
		[Category] public float DOF_AutofocusMaxDistance;
		[Category] public float DOF_AutofocusSpeed;
		[Category] [interp] public float MotionBlur_MaxVelocity;
		[Category] [interp] public float MotionBlur_Amount;
		[Category] public bool MotionBlur_FullMotionBlur;
		[Category] [interp] public float MotionBlur_CameraRotationThreshold;
		[Category] [interp] public float MotionBlur_CameraTranslationThreshold;
		[Category] public float MotionBlur_InterpolationDuration;
		[Category] [interp] public float Scene_Desaturation;
		[Category] [interp] public Object.Vector Scene_HighLights;
		[Category] [interp] public Object.Vector Scene_MidTones;
		[Category] [interp] public Object.Vector Scene_Shadows;
		[Category] public float Scene_InterpolationDuration;
		[Category] [interp] public Object.Vector HazeColor;
		[Category] [interp] public float HazeAngleCurve;
		[Category] [interp] public float HazeAngleStart;
		[Category] [interp] public float HazeDistanceCurve;
		[Category] [interp] public float HazeDistanceDivider;
		[Category] [interp] public float HazeAngleClampHigh;
		[Category] [interp] public float HazeTotalClampCloseHigh;
		[Category] [interp] public float HazeTotalClampFarHigh;
		[Category] [interp] public float HazeTotalClampFarDistance;
		[Category] [interp] public float HazeMultiplier;
		[Category] [interp] public float HazeTotalClampLow;
		[Category] public bool HazeEnabled;
		[Category] public Object.Vector HazeSunLocation;
		[Category] [interp] public float Scene_ExposureManual;
		[Category] [interp] public float Scene_ExposureSpeedUp;
		[Category] [interp] public float Scene_ExposureSpeedDown;
		[Category] [interp] public float Scene_ExposureHigh;
		[Category] [interp] public float Scene_ExposureLow;
		public bool Scene_ExposureReset;
		[Category] [interp] public float TdMotionBlurAmount;
		[Category] [interp] public float TdMotionBlurStartPlayerSpeed;
		[Category] public bool TdMotionBlurEnabled;
		[Category] public bool TdMotionBlurUseDistance;
		[Category] public bool TdMotionBlurUseDirection;
		[Category] public bool TdMotionBlurForce;
		[Category] public Object.Vector TdMotionBlurForcedDirection;
		[Category] public float TdMotionBlurForcedAmount;
		[Category] public Texture2D TdMotionBlurMask;
		[Category] public Texture2D SaturationMask;
		[Category] [editinline] public PostProcessVolume.CurveInfo Curves;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00279836
	//		bEnableBloom = true;
	//		bEnableDOF = false;
	//		bEnableMotionBlur = false;
	//		bEnableSceneEffect = true;
	//		Bloom_Scale = 1.0f;
	//		Bloom_InterpolationDuration = 1.0f;
	//		DOF_FalloffExponent = 4.0f;
	//		DOF_BlurKernelSize = 16.0f;
	//		DOF_MaxNearBlurAmount = 0.0f;
	//		DOF_MaxFarBlurAmount = 0.0f;
	//		DOF_ModulateBlurColor = new Color
	//		{
	//			R=255,
	//			G=255,
	//			B=255,
	//			A=255
	//		};
	//		DOF_FocusType = DOFEffect.EFocusType.FOCUS_Distance;
	//		DOF_FocusInnerRadius = 2000.0f;
	//		DOF_FocusDistance = 1600.0f;
	//		DOF_FocusPosition = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		DOF_InterpolationDuration = 1.0f;
	//		DOF_Autofocus = true;
	//		DOF_AutofocusMaxDistance = 150.0f;
	//		DOF_AutofocusSpeed = 1.0f;
	//		MotionBlur_MaxVelocity = 1.0f;
	//		MotionBlur_Amount = 0.50f;
	//		MotionBlur_FullMotionBlur = true;
	//		MotionBlur_CameraRotationThreshold = 45.0f;
	//		MotionBlur_CameraTranslationThreshold = 10000.0f;
	//		MotionBlur_InterpolationDuration = 1.0f;
	//		Scene_Desaturation = 0.0f;
	//		Scene_HighLights = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=1.0f
	//		};
	//		Scene_MidTones = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=1.0f
	//		};
	//		Scene_Shadows = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Scene_InterpolationDuration = 1.0f;
	//		HazeColor = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=0.80f
	//		};
	//		HazeAngleCurve = 5.0f;
	//		HazeAngleStart = 0.50f;
	//		HazeDistanceCurve = 1.50f;
	//		HazeDistanceDivider = 7500.0f;
	//		HazeAngleClampHigh = 2.0f;
	//		HazeTotalClampCloseHigh = 10.0f;
	//		HazeTotalClampFarHigh = 10.0f;
	//		HazeTotalClampFarDistance = 1.0f;
	//		HazeMultiplier = 1.0f;
	//		HazeTotalClampLow = 0.0f;
	//		HazeEnabled = false;
	//		HazeSunLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Scene_ExposureManual = 1.0f;
	//		Scene_ExposureSpeedUp = 3.50f;
	//		Scene_ExposureSpeedDown = 4.50f;
	//		Scene_ExposureHigh = 1.650f;
	//		Scene_ExposureLow = 0.850f;
	//		Scene_ExposureReset = true;
	//		TdMotionBlurAmount = 0.50f;
	//		TdMotionBlurStartPlayerSpeed = 400.0f;
	//		TdMotionBlurEnabled = true;
	//		TdMotionBlurUseDistance = false;
	//		TdMotionBlurUseDirection = true;
	//		TdMotionBlurForce = false;
	//		TdMotionBlurForcedDirection = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		TdMotionBlurForcedAmount = 0.0f;
	//		TdMotionBlurMask = default;
	//		SaturationMask = default;
	//		Curves = new PostProcessVolume.CurveInfo
	//		{
	//			Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//			{
	//				[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[2] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[3] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[4] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[5] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[6] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[7] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[8] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[9] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[10] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[11] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[12] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[13] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[14] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[15] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			},
	//			Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//			{
	//				[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[2] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[3] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[4] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[5] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[6] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[7] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[8] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[9] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[10] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[11] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[12] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[13] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[14] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[15] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			},
	//			ControlPointsR = default,
	//			ControlPointsG = default,
	//			ControlPointsB = default,
	//			ControlPointsA = default,
	//		};
	//	}
	};
	
	public partial struct /*native */TdPostProcessModifier
	{
		[Category] public float Bloom_Scale;
		[Category] public float DOF_FalloffExponent;
		[Category] public float DOF_BlurKernelSize;
		[Category] public float DOF_MaxNearBlurAmount;
		[Category] public float DOF_MaxFarBlurAmount;
		[Category] public float DOF_FocusInnerRadius;
		[Category] public float DOF_FocusDistance;
		[Category] public float DOF_AutofocusMaxDistance;
		[Category] public float DOF_AutofocusSpeed;
		[Category] public float MotionBlur_MaxVelocity;
		[Category] public float MotionBlur_Amount;
		[Category] public float MotionBlur_CameraRotationThreshold;
		[Category] public float MotionBlur_CameraTranslationThreshold;
		[Category] public float Scene_Desaturation;
		[Category] public Object.Vector Scene_HighLights;
		[Category] public Object.Vector Scene_MidTones;
		[Category] public Object.Vector Scene_Shadows;
		[Category] public Object.Vector HazeColor;
		[Category] public float HazeAngleCurve;
		[Category] public float HazeAngleStart;
		[Category] public float HazeDistanceCurve;
		[Category] public float HazeDistanceDivider;
		[Category] public float HazeAngleClampHigh;
		[Category] public float HazeTotalClampCloseHigh;
		[Category] public float HazeTotalClampFarHigh;
		[Category] public float HazeTotalClampFarDistance;
		[Category] public float HazeMultiplier;
		[Category] public float HazeTotalClampLow;
		[Category] public float Scene_ExposureManual;
		[Category] public float Scene_ExposureSpeedUp;
		[Category] public float Scene_ExposureSpeedDown;
		[Category] public float Scene_ExposureHigh;
		[Category] public float Scene_ExposureLow;
		[Category] public float TdMotionBlurAmount;
		[Category] public float TdMotionBlurStartPlayerSpeed;
		[Category] [editinline] public PostProcessVolume.CurveInfo Curves;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C4E31
	//		Bloom_Scale = 0.0f;
	//		DOF_FalloffExponent = 0.0f;
	//		DOF_BlurKernelSize = 0.0f;
	//		DOF_MaxNearBlurAmount = 0.0f;
	//		DOF_MaxFarBlurAmount = 0.0f;
	//		DOF_FocusInnerRadius = 0.0f;
	//		DOF_FocusDistance = 0.0f;
	//		DOF_AutofocusMaxDistance = 0.0f;
	//		DOF_AutofocusSpeed = 0.0f;
	//		MotionBlur_MaxVelocity = 0.0f;
	//		MotionBlur_Amount = 0.0f;
	//		MotionBlur_CameraRotationThreshold = 0.0f;
	//		MotionBlur_CameraTranslationThreshold = 0.0f;
	//		Scene_Desaturation = 0.0f;
	//		Scene_HighLights = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Scene_MidTones = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Scene_Shadows = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HazeColor = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HazeAngleCurve = 0.0f;
	//		HazeAngleStart = 0.0f;
	//		HazeDistanceCurve = 0.0f;
	//		HazeDistanceDivider = 0.0f;
	//		HazeAngleClampHigh = 0.0f;
	//		HazeTotalClampCloseHigh = 0.0f;
	//		HazeTotalClampFarHigh = 0.0f;
	//		HazeTotalClampFarDistance = 0.0f;
	//		HazeMultiplier = 0.0f;
	//		HazeTotalClampLow = 0.0f;
	//		Scene_ExposureManual = 0.0f;
	//		Scene_ExposureSpeedUp = 0.0f;
	//		Scene_ExposureSpeedDown = 0.0f;
	//		Scene_ExposureHigh = 0.0f;
	//		Scene_ExposureLow = 0.0f;
	//		TdMotionBlurAmount = 0.0f;
	//		TdMotionBlurStartPlayerSpeed = 0.0f;
	//		Curves = new PostProcessVolume.CurveInfo
	//		{
	//			Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//			{
	//				[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[2] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[3] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[4] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[5] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[6] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[7] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[8] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[9] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[10] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[11] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[12] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[13] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[14] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[15] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			},
	//			Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//			{
	//				[0] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[1] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[2] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[3] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[4] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[5] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[6] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[7] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[8] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[9] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[10] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[11] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[12] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[13] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[14] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//				[15] = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			},
	//			ControlPointsR = default,
	//			ControlPointsG = default,
	//			ControlPointsB = default,
	//			ControlPointsA = default,
	//		};
	//	}
	};
	
	[Category] public float Priority;
	[Category] public PostProcessVolume.PostProcessSettings Settings;
	[Category] public bool bOverrideSKUSpecificCurveModifier;
	[Category] public bool bEnabled;
	[Category] public PostProcessVolume.TdPostProcessModifier PostProcessSettingsModifierXbox360;
	[Category] public PostProcessVolume.TdPostProcessModifier PostProcessSettingsModifierPS3;
	[Category] public PostProcessVolume.TdPostProcessModifier PostProcessSettingsModifierPC;
	[noimport, Const, transient] public PostProcessVolume NextLowerPriorityVolume;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		bEnabled;
	//}
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public PostProcessVolume()
	{
		var Default__PostProcessVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x00466213
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__PostProcessVolume.BrushComponent0' */;
		// Object Offset:0x003A4928
		Settings = new PostProcessVolume.PostProcessSettings
		{
			bEnableBloom = true,
			bEnableDOF = false,
			bEnableMotionBlur = false,
			bEnableSceneEffect = true,
			Bloom_Scale = 1.0f,
			Bloom_InterpolationDuration = 1.0f,
			DOF_FalloffExponent = 4.0f,
			DOF_BlurKernelSize = 16.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_ModulateBlurColor = new Color
			{
				R=255,
				G=255,
				B=255,
				A=255
			},
			DOF_FocusType = DOFEffect.EFocusType.FOCUS_Distance,
			DOF_FocusInnerRadius = 2000.0f,
			DOF_FocusDistance = 1600.0f,
			DOF_FocusPosition = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			DOF_InterpolationDuration = 1.0f,
			DOF_Autofocus = true,
			DOF_AutofocusMaxDistance = 150.0f,
			DOF_AutofocusSpeed = 1.0f,
			MotionBlur_MaxVelocity = 1.0f,
			MotionBlur_Amount = 0.50f,
			MotionBlur_FullMotionBlur = true,
			MotionBlur_CameraRotationThreshold = 45.0f,
			MotionBlur_CameraTranslationThreshold = 10000.0f,
			MotionBlur_InterpolationDuration = 1.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			Scene_MidTones = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_InterpolationDuration = 1.0f,
			HazeColor = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=0.80f
			},
			HazeAngleCurve = 5.0f,
			HazeAngleStart = 0.50f,
			HazeDistanceCurve = 1.50f,
			HazeDistanceDivider = 7500.0f,
			HazeAngleClampHigh = 2.0f,
			HazeTotalClampCloseHigh = 10.0f,
			HazeTotalClampFarHigh = 10.0f,
			HazeTotalClampFarDistance = 1.0f,
			HazeMultiplier = 1.0f,
			HazeTotalClampLow = 0.0f,
			HazeEnabled = false,
			HazeSunLocation = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_ExposureManual = 1.0f,
			Scene_ExposureSpeedUp = 3.50f,
			Scene_ExposureSpeedDown = 4.50f,
			Scene_ExposureHigh = 1.650f,
			Scene_ExposureLow = 0.850f,
			Scene_ExposureReset = true,
			TdMotionBlurAmount = 0.50f,
			TdMotionBlurStartPlayerSpeed = 400.0f,
			TdMotionBlurEnabled = true,
			TdMotionBlurUseDistance = false,
			TdMotionBlurUseDirection = true,
			TdMotionBlurForce = false,
			TdMotionBlurForcedDirection = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			TdMotionBlurForcedAmount = 0.0f,
			TdMotionBlurMask = default,
			SaturationMask = default,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		bEnabled = true;
		PostProcessSettingsModifierXbox360 = new PostProcessVolume.TdPostProcessModifier
		{
			Bloom_Scale = 0.0f,
			DOF_FalloffExponent = 0.0f,
			DOF_BlurKernelSize = 0.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_FocusInnerRadius = 0.0f,
			DOF_FocusDistance = 0.0f,
			DOF_AutofocusMaxDistance = 0.0f,
			DOF_AutofocusSpeed = 0.0f,
			MotionBlur_MaxVelocity = 0.0f,
			MotionBlur_Amount = 0.0f,
			MotionBlur_CameraRotationThreshold = 0.0f,
			MotionBlur_CameraTranslationThreshold = 0.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_MidTones = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeColor = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeAngleCurve = 0.0f,
			HazeAngleStart = 0.0f,
			HazeDistanceCurve = 0.0f,
			HazeDistanceDivider = 0.0f,
			HazeAngleClampHigh = 0.0f,
			HazeTotalClampCloseHigh = 0.0f,
			HazeTotalClampFarHigh = 0.0f,
			HazeTotalClampFarDistance = 0.0f,
			HazeMultiplier = 0.0f,
			HazeTotalClampLow = 0.0f,
			Scene_ExposureManual = 0.0f,
			Scene_ExposureSpeedUp = 0.0f,
			Scene_ExposureSpeedDown = 0.0f,
			Scene_ExposureHigh = 0.0f,
			Scene_ExposureLow = 0.0f,
			TdMotionBlurAmount = 0.0f,
			TdMotionBlurStartPlayerSpeed = 0.0f,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[1] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[2] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[3] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[4] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[5] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[6] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[7] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[8] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[9] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[10] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[11] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[12] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[13] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[14] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[15] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		PostProcessSettingsModifierPS3 = new PostProcessVolume.TdPostProcessModifier
		{
			Bloom_Scale = 0.0f,
			DOF_FalloffExponent = 0.0f,
			DOF_BlurKernelSize = 0.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_FocusInnerRadius = 0.0f,
			DOF_FocusDistance = 0.0f,
			DOF_AutofocusMaxDistance = 0.0f,
			DOF_AutofocusSpeed = 0.0f,
			MotionBlur_MaxVelocity = 0.0f,
			MotionBlur_Amount = 0.0f,
			MotionBlur_CameraRotationThreshold = 0.0f,
			MotionBlur_CameraTranslationThreshold = 0.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_MidTones = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeColor = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeAngleCurve = 0.0f,
			HazeAngleStart = 0.0f,
			HazeDistanceCurve = 0.0f,
			HazeDistanceDivider = 0.0f,
			HazeAngleClampHigh = 0.0f,
			HazeTotalClampCloseHigh = 0.0f,
			HazeTotalClampFarHigh = 0.0f,
			HazeTotalClampFarDistance = 0.0f,
			HazeMultiplier = 0.0f,
			HazeTotalClampLow = 0.0f,
			Scene_ExposureManual = 0.0f,
			Scene_ExposureSpeedUp = 0.0f,
			Scene_ExposureSpeedDown = 0.0f,
			Scene_ExposureHigh = 0.0f,
			Scene_ExposureLow = 0.0f,
			TdMotionBlurAmount = 0.0f,
			TdMotionBlurStartPlayerSpeed = 0.0f,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[1] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[2] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[3] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[4] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[5] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[6] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[7] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[8] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[9] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[10] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[11] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[12] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[13] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[14] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[15] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		PostProcessSettingsModifierPC = new PostProcessVolume.TdPostProcessModifier
		{
			Bloom_Scale = 0.0f,
			DOF_FalloffExponent = 0.0f,
			DOF_BlurKernelSize = 0.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_FocusInnerRadius = 0.0f,
			DOF_FocusDistance = 0.0f,
			DOF_AutofocusMaxDistance = 0.0f,
			DOF_AutofocusSpeed = 0.0f,
			MotionBlur_MaxVelocity = 0.0f,
			MotionBlur_Amount = 0.0f,
			MotionBlur_CameraRotationThreshold = 0.0f,
			MotionBlur_CameraTranslationThreshold = 0.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_MidTones = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeColor = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeAngleCurve = 0.0f,
			HazeAngleStart = 0.0f,
			HazeDistanceCurve = 0.0f,
			HazeDistanceDivider = 0.0f,
			HazeAngleClampHigh = 0.0f,
			HazeTotalClampCloseHigh = 0.0f,
			HazeTotalClampFarHigh = 0.0f,
			HazeTotalClampFarDistance = 0.0f,
			HazeMultiplier = 0.0f,
			HazeTotalClampLow = 0.0f,
			Scene_ExposureManual = 0.0f,
			Scene_ExposureSpeedUp = 0.0f,
			Scene_ExposureSpeedDown = 0.0f,
			Scene_ExposureHigh = 0.0f,
			Scene_ExposureLow = 0.0f,
			TdMotionBlurAmount = 0.0f,
			TdMotionBlurStartPlayerSpeed = 0.0f,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[1] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[2] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[3] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[4] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[5] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[6] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[7] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[8] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[9] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[10] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[11] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[12] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[13] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[14] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[15] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		BrushComponent = Default__PostProcessVolume_BrushComponent0/*Ref BrushComponent'Default__PostProcessVolume.BrushComponent0'*/;
		bStatic = false;
		bStasis = true;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PostProcessVolume_BrushComponent0/*Ref BrushComponent'Default__PostProcessVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__PostProcessVolume_BrushComponent0/*Ref BrushComponent'Default__PostProcessVolume.BrushComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
		};
	}
}
}