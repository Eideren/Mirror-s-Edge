namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PostProcessVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public partial struct /*native */CurveInfo
	{
		public/*()*/ /*editinline */StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/ Ms;
		public/*()*/ /*editinline */StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/ Bs;
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
		public/*()*/ bool bEnableBloom;
		public/*()*/ bool bEnableDOF;
		public/*()*/ bool bEnableMotionBlur;
		public/*()*/ bool bEnableSceneEffect;
		public/*()*/ /*interp */float Bloom_Scale;
		public/*()*/ float Bloom_InterpolationDuration;
		public/*()*/ /*interp */float DOF_FalloffExponent;
		public/*()*/ /*interp */float DOF_BlurKernelSize;
		public/*()*/ /*interp */float DOF_MaxNearBlurAmount;
		public/*()*/ /*interp */float DOF_MaxFarBlurAmount;
		public/*()*/ Object.Color DOF_ModulateBlurColor;
		public/*()*/ DOFEffect.EFocusType DOF_FocusType;
		public/*()*/ /*interp */float DOF_FocusInnerRadius;
		public/*()*/ /*interp */float DOF_FocusDistance;
		public/*()*/ Object.Vector DOF_FocusPosition;
		public/*()*/ float DOF_InterpolationDuration;
		public/*()*/ bool DOF_Autofocus;
		public/*()*/ float DOF_AutofocusMaxDistance;
		public/*()*/ float DOF_AutofocusSpeed;
		public/*()*/ /*interp */float MotionBlur_MaxVelocity;
		public/*()*/ /*interp */float MotionBlur_Amount;
		public/*()*/ bool MotionBlur_FullMotionBlur;
		public/*()*/ /*interp */float MotionBlur_CameraRotationThreshold;
		public/*()*/ /*interp */float MotionBlur_CameraTranslationThreshold;
		public/*()*/ float MotionBlur_InterpolationDuration;
		public/*()*/ /*interp */float Scene_Desaturation;
		public/*()*/ /*interp */Object.Vector Scene_HighLights;
		public/*()*/ /*interp */Object.Vector Scene_MidTones;
		public/*()*/ /*interp */Object.Vector Scene_Shadows;
		public/*()*/ float Scene_InterpolationDuration;
		public/*()*/ /*interp */Object.Vector HazeColor;
		public/*()*/ /*interp */float HazeAngleCurve;
		public/*()*/ /*interp */float HazeAngleStart;
		public/*()*/ /*interp */float HazeDistanceCurve;
		public/*()*/ /*interp */float HazeDistanceDivider;
		public/*()*/ /*interp */float HazeAngleClampHigh;
		public/*()*/ /*interp */float HazeTotalClampCloseHigh;
		public/*()*/ /*interp */float HazeTotalClampFarHigh;
		public/*()*/ /*interp */float HazeTotalClampFarDistance;
		public/*()*/ /*interp */float HazeMultiplier;
		public/*()*/ /*interp */float HazeTotalClampLow;
		public/*()*/ bool HazeEnabled;
		public/*()*/ Object.Vector HazeSunLocation;
		public/*()*/ /*interp */float Scene_ExposureManual;
		public/*()*/ /*interp */float Scene_ExposureSpeedUp;
		public/*()*/ /*interp */float Scene_ExposureSpeedDown;
		public/*()*/ /*interp */float Scene_ExposureHigh;
		public/*()*/ /*interp */float Scene_ExposureLow;
		public bool Scene_ExposureReset;
		public/*()*/ /*interp */float TdMotionBlurAmount;
		public/*()*/ /*interp */float TdMotionBlurStartPlayerSpeed;
		public/*()*/ bool TdMotionBlurEnabled;
		public/*()*/ bool TdMotionBlurUseDistance;
		public/*()*/ bool TdMotionBlurUseDirection;
		public/*()*/ bool TdMotionBlurForce;
		public/*()*/ Object.Vector TdMotionBlurForcedDirection;
		public/*()*/ float TdMotionBlurForcedAmount;
		public/*()*/ Texture2D TdMotionBlurMask;
		public/*()*/ Texture2D SaturationMask;
		public/*()*/ /*editinline */PostProcessVolume.CurveInfo Curves;
	
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
		public/*()*/ float Bloom_Scale;
		public/*()*/ float DOF_FalloffExponent;
		public/*()*/ float DOF_BlurKernelSize;
		public/*()*/ float DOF_MaxNearBlurAmount;
		public/*()*/ float DOF_MaxFarBlurAmount;
		public/*()*/ float DOF_FocusInnerRadius;
		public/*()*/ float DOF_FocusDistance;
		public/*()*/ float DOF_AutofocusMaxDistance;
		public/*()*/ float DOF_AutofocusSpeed;
		public/*()*/ float MotionBlur_MaxVelocity;
		public/*()*/ float MotionBlur_Amount;
		public/*()*/ float MotionBlur_CameraRotationThreshold;
		public/*()*/ float MotionBlur_CameraTranslationThreshold;
		public/*()*/ float Scene_Desaturation;
		public/*()*/ Object.Vector Scene_HighLights;
		public/*()*/ Object.Vector Scene_MidTones;
		public/*()*/ Object.Vector Scene_Shadows;
		public/*()*/ Object.Vector HazeColor;
		public/*()*/ float HazeAngleCurve;
		public/*()*/ float HazeAngleStart;
		public/*()*/ float HazeDistanceCurve;
		public/*()*/ float HazeDistanceDivider;
		public/*()*/ float HazeAngleClampHigh;
		public/*()*/ float HazeTotalClampCloseHigh;
		public/*()*/ float HazeTotalClampFarHigh;
		public/*()*/ float HazeTotalClampFarDistance;
		public/*()*/ float HazeMultiplier;
		public/*()*/ float HazeTotalClampLow;
		public/*()*/ float Scene_ExposureManual;
		public/*()*/ float Scene_ExposureSpeedUp;
		public/*()*/ float Scene_ExposureSpeedDown;
		public/*()*/ float Scene_ExposureHigh;
		public/*()*/ float Scene_ExposureLow;
		public/*()*/ float TdMotionBlurAmount;
		public/*()*/ float TdMotionBlurStartPlayerSpeed;
		public/*()*/ /*editinline */PostProcessVolume.CurveInfo Curves;
	
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
	
	public/*()*/ float Priority;
	public/*()*/ PostProcessVolume.PostProcessSettings Settings;
	public/*()*/ bool bOverrideSKUSpecificCurveModifier;
	public/*()*/ bool bEnabled;
	public/*()*/ PostProcessVolume.TdPostProcessModifier PostProcessSettingsModifierXbox360;
	public/*()*/ PostProcessVolume.TdPostProcessModifier PostProcessSettingsModifierPS3;
	public/*()*/ PostProcessVolume.TdPostProcessModifier PostProcessSettingsModifierPC;
	public /*noimport const transient */PostProcessVolume NextLowerPriorityVolume;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		bEnabled;
	//}
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public PostProcessVolume()
	{
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
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x00466213
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__PostProcessVolume.BrushComponent0' */;
		bStatic = false;
		bStasis = true;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new BrushComponent
			{
				// Object Offset:0x00466213
				CollideActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: BrushComponent'Default__PostProcessVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x00466213
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__PostProcessVolume.BrushComponent0' */;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
		};
	}
}
}