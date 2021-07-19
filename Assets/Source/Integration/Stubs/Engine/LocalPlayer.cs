namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LocalPlayer : Player/* within Engine*//*
		transient
		native
		config(Engine)*/{
	public partial struct SynchronizedActorVisibilityHistory
	{
		public Object.Pointer State;
		public Object.Pointer CriticalSection;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003523D7
	//		State = default;
	//		CriticalSection = default;
	//	}
	};
	
	public partial struct /*native */CurrentPostProcessVolumeInfo
	{
		public PostProcessVolume.PostProcessSettings LastSettings;
		public PostProcessVolume LastVolumeUsed;
		public float BlendStartTime;
		public float LastBlendTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00352517
	//		LastSettings = new PostProcessVolume.PostProcessSettings
	//		{
	//			bEnableBloom = true,
	//			bEnableDOF = false,
	//			bEnableMotionBlur = false,
	//			bEnableSceneEffect = true,
	//			Bloom_Scale = 1.0f,
	//			Bloom_InterpolationDuration = 1.0f,
	//			DOF_FalloffExponent = 4.0f,
	//			DOF_BlurKernelSize = 16.0f,
	//			DOF_MaxNearBlurAmount = 0.0f,
	//			DOF_MaxFarBlurAmount = 0.0f,
	//			DOF_ModulateBlurColor = new Color
	//			{
	//				R=255,
	//				G=255,
	//				B=255,
	//				A=255
	//			},
	//			DOF_FocusType = DOFEffect.EFocusType.FOCUS_Distance,
	//			DOF_FocusInnerRadius = 2000.0f,
	//			DOF_FocusDistance = 1600.0f,
	//			DOF_FocusPosition = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			DOF_InterpolationDuration = 1.0f,
	//			DOF_Autofocus = true,
	//			DOF_AutofocusMaxDistance = 150.0f,
	//			DOF_AutofocusSpeed = 1.0f,
	//			MotionBlur_MaxVelocity = 1.0f,
	//			MotionBlur_Amount = 0.50f,
	//			MotionBlur_FullMotionBlur = true,
	//			MotionBlur_CameraRotationThreshold = 45.0f,
	//			MotionBlur_CameraTranslationThreshold = 10000.0f,
	//			MotionBlur_InterpolationDuration = 1.0f,
	//			Scene_Desaturation = 0.0f,
	//			Scene_HighLights = new Vector
	//			{
	//				X=1.0f,
	//				Y=1.0f,
	//				Z=1.0f
	//			},
	//			Scene_MidTones = new Vector
	//			{
	//				X=1.0f,
	//				Y=1.0f,
	//				Z=1.0f
	//			},
	//			Scene_Shadows = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			Scene_InterpolationDuration = 1.0f,
	//			HazeColor = new Vector
	//			{
	//				X=1.0f,
	//				Y=1.0f,
	//				Z=0.80f
	//			},
	//			HazeAngleCurve = 5.0f,
	//			HazeAngleStart = 0.50f,
	//			HazeDistanceCurve = 1.50f,
	//			HazeDistanceDivider = 7500.0f,
	//			HazeAngleClampHigh = 2.0f,
	//			HazeTotalClampCloseHigh = 10.0f,
	//			HazeTotalClampFarHigh = 10.0f,
	//			HazeTotalClampFarDistance = 1.0f,
	//			HazeMultiplier = 1.0f,
	//			HazeTotalClampLow = 0.0f,
	//			HazeEnabled = false,
	//			HazeSunLocation = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			Scene_ExposureManual = 1.0f,
	//			Scene_ExposureSpeedUp = 3.50f,
	//			Scene_ExposureSpeedDown = 4.50f,
	//			Scene_ExposureHigh = 1.650f,
	//			Scene_ExposureLow = 0.850f,
	//			Scene_ExposureReset = true,
	//			TdMotionBlurAmount = 0.50f,
	//			TdMotionBlurStartPlayerSpeed = 400.0f,
	//			TdMotionBlurEnabled = true,
	//			TdMotionBlurUseDistance = false,
	//			TdMotionBlurUseDirection = true,
	//			TdMotionBlurForce = false,
	//			TdMotionBlurForcedDirection = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			TdMotionBlurForcedAmount = 0.0f,
	//			TdMotionBlurMask = default,
	//			SaturationMask = default,
	//			Curves = new PostProcessVolume.CurveInfo
	//			{
	//				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//				{
	//					[0] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[1] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[2] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[3] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[4] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[5] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[6] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[7] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[8] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[9] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[10] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[11] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[12] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[13] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[14] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[15] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//				},
	//				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
	//				{
	//					[0] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[1] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[2] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[3] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[4] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[5] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[6] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[7] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[8] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[9] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[10] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[11] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[12] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[13] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[14] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//					[15] = new Vector
	//				{
	//					X=0.0f,
	//					Y=0.0f,
	//					Z=0.0f
	//				},
	//				},
	//				ControlPointsR = default,
	//				ControlPointsG = default,
	//				ControlPointsB = default,
	//				ControlPointsA = default,
	//			},
	//		};
	//		LastVolumeUsed = default;
	//		BlendStartTime = 0.0f;
	//		LastBlendTime = 0.0f;
	//	}
	};
	
	public new Engine Outer => base.Outer as Engine;
	
	public int ControllerId;
	public GameViewportClient ViewportClient;
	public Object.Vector2D Origin;
	public Object.Vector2D Size;
	[Const] public PostProcessChain PlayerPostProcess;
	[Const] public array<PostProcessChain> PlayerPostProcessChains;
	[native, Const] public/*private*/ Object.Pointer ViewState;
	[native, Const, transient] public/*private*/ LocalPlayer.SynchronizedActorVisibilityHistory ActorVisibilityHistory;
	[transient] public Object.Vector LastViewLocation;
	[noimport, Const, transient] public LocalPlayer.CurrentPostProcessVolumeInfo CurrentPPInfo;
	public bool bOverridePostProcessSettings;
	[Const, editconst, transient] public bool bSentSplitJoin;
	public PostProcessVolume.PostProcessSettings PostProcessSettingsOverride;
	public float PPSettingsOverrideStartBlend;
	
	// Export ULocalPlayer::execSpawnPlayActor(FFrame&, void* const)
	public virtual /*native final function */bool SpawnPlayActor(String URL, ref String OutError)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULocalPlayer::execSendSplitJoin(FFrame&, void* const)
	public virtual /*native final function */void SendSplitJoin()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export ULocalPlayer::execGetActorVisibility(FFrame&, void* const)
	public virtual /*native final function */bool GetActorVisibility(Actor TestActor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*simulated function */void OverridePostProcessSettings(PostProcessVolume.PostProcessSettings OverrideSettings, float StartBlendTime)
	{
		// stub
	}
	
	public virtual /*simulated function */void UpdateOverridePostProcessSettings(PostProcessVolume.PostProcessSettings OverrideSettings)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearPostProcessSettingsOverride()
	{
		// stub
	}
	
	public virtual /*final function */void SetControllerId(int NewControllerId)
	{
		// stub
	}
	
	// Export ULocalPlayer::execInsertPostProcessingChain(FFrame&, void* const)
	public virtual /*native function */bool InsertPostProcessingChain(PostProcessChain InChain, int InIndex, bool bInClone)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULocalPlayer::execRemovePostProcessingChain(FFrame&, void* const)
	public virtual /*native function */bool RemovePostProcessingChain(int InIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULocalPlayer::execRemoveAllPostProcessingChains(FFrame&, void* const)
	public virtual /*native function */bool RemoveAllPostProcessingChains()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULocalPlayer::execGetPostProcessChain(FFrame&, void* const)
	public virtual /*native function */PostProcessChain GetPostProcessChain(int InIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULocalPlayer::execTouchPlayerPostProcessChain(FFrame&, void* const)
	public virtual /*native function */void TouchPlayerPostProcessChain()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public LocalPlayer()
	{
		// Object Offset:0x00353A3D
		CurrentPPInfo = new LocalPlayer.CurrentPostProcessVolumeInfo
		{
			LastSettings = new PostProcessVolume.PostProcessSettings
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
			},
			LastVolumeUsed = default,
			BlendStartTime = 0.0f,
			LastBlendTime = 0.0f,
		};
		PostProcessSettingsOverride = new PostProcessVolume.PostProcessSettings
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
	}
}
}