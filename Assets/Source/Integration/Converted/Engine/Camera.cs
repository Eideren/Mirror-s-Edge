// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Camera : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public enum EViewTargetBlendFunction 
	{
		VTBlend_Linear,
		VTBlend_Cubic,
		VTBlend_EaseIn,
		VTBlend_EaseOut,
		VTBlend_EaseInOut,
		VTBlend_MAX
	};
	
	public partial struct /*native */TCameraCache
	{
		public float TimeStamp;
		public Object.TPOV POV;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0027AB02
	//		TimeStamp = 0.0f;
	//		POV = new Object.TPOV
	//		{
	//			Location = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			Rotation = new Rotator
	//			{
	//				Pitch=0,
	//				Yaw=0,
	//				Roll=0
	//			},
	//			FOV = 90.0f,
	//		};
	//	}
	};
	
	public partial struct /*native */TViewTarget
	{
		[Category] public Actor Target;
		[Category] public Controller Controller;
		[Category] public Object.TPOV POV;
		[Category] public float AspectRatio;
		[Category] public PlayerReplicationInfo PRI;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0027ACDE
	//		Target = default;
	//		Controller = default;
	//		POV = new Object.TPOV
	//		{
	//			Location = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			Rotation = new Rotator
	//			{
	//				Pitch=0,
	//				Yaw=0,
	//				Roll=0
	//			},
	//			FOV = 90.0f,
	//		};
	//		AspectRatio = 0.0f;
	//		PRI = default;
	//	}
	};
	
	public partial struct /*native */ViewTargetTransitionParams
	{
		[Category] public float BlendTime;
		[Category] public Camera.EViewTargetBlendFunction BlendFunction;
		[Category] public float BlendExp;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0027AEF2
	//		BlendTime = 0.0f;
	//		BlendFunction = Camera.EViewTargetBlendFunction.VTBlend_Cubic;
	//		BlendExp = 2.0f;
	//	}
	};
	
	public PlayerController PCOwner;
	public name CameraStyle;
	public float DefaultFOV;
	public bool bLockedFOV;
	public bool bConstrainAspectRatio;
	public bool bEnableFading;
	public bool bCamOverridePostProcess;
	public bool bEnableColorScaling;
	public bool bEnableColorScaleInterp;
	public float LockedFOV;
	public float ConstrainedAspectRatio;
	public float DefaultAspectRatio;
	public Object.Color FadeColor;
	public float FadeAmount;
	public PostProcessVolume.PostProcessSettings CamPostProcessSettings;
	public Object.Vector ColorScale;
	public Object.Vector DesiredColorScale;
	public Object.Vector OriginalColorScale;
	public float ColorScaleInterpDuration;
	public float ColorScaleInterpStartTime;
	public Camera.TCameraCache CameraCache;
	public Camera.TViewTarget ViewTarget;
	public Camera.TViewTarget PendingViewTarget;
	public float BlendTimeToGo;
	public Camera.ViewTargetTransitionParams BlendParams;
	public array<CameraModifier> ModifierList;
	public float FreeCamDistance;
	public Object.Vector FreeCamOffset;
	
	public virtual /*function */void InitializeFor(PlayerController PC)
	{
		CameraCache.POV.FOV = DefaultFOV;
		PCOwner = PC;
		SetViewTarget(PC.ViewTarget, default(Camera.ViewTargetTransitionParams?));
		SetDesiredColorScale(WorldInfo.DefaultColorScale, 5.0f);
		UpdateCamera(0.0f);
	}
	
	public virtual /*function */float GetFOVAngle()
	{
		if(bLockedFOV)
		{
			return LockedFOV;
		}
		return CameraCache.POV.FOV;
	}
	
	public virtual /*function */void SetFOV(float NewFOV)
	{
		if(((NewFOV < ((float)(1))) || NewFOV > ((float)(170))))
		{
			bLockedFOV = false;
			return;
		}
		bLockedFOV = true;
		LockedFOV = NewFOV;
	}
	
	public virtual /*final function */void GetCameraViewPoint(ref Object.Vector OutCamLoc, ref Object.Rotator OutCamRot)
	{
		OutCamLoc = CameraCache.POV.Location;
		OutCamRot = CameraCache.POV.Rotation;
	}
	
	public virtual /*simulated function */void SetDesiredColorScale(Object.Vector NewColorScale, float InterpTime)
	{
		if(!bEnableColorScaling)
		{
			bEnableColorScaling = true;
			ColorScale.X = 1.0f;
			ColorScale.Y = 1.0f;
			ColorScale.Z = 1.0f;
		}
		if(NewColorScale != ColorScale)
		{
			OriginalColorScale = ColorScale;
			DesiredColorScale = NewColorScale;
			ColorScaleInterpStartTime = WorldInfo.TimeSeconds;
			ColorScaleInterpDuration = InterpTime;
			bEnableColorScaleInterp = true;
		}
	}
	
	public virtual /*simulated event */void UpdateCamera(float DeltaTime)
	{
		/*local */Object.TPOV NewPOV = default;
		/*local */float DurationPct = default, BlendPct = default;
	
		if(bEnableColorScaleInterp)
		{
			BlendPct = FClamp(TimeSince(ColorScaleInterpStartTime) / ColorScaleInterpDuration, 0.0f, 1.0f);
			ColorScale = VLerp(OriginalColorScale, DesiredColorScale, BlendPct);
			if(BlendPct == 1.0f)
			{
				bEnableColorScaleInterp = false;
			}
		}
		bConstrainAspectRatio = true;
		bCamOverridePostProcess = false;
		CheckViewTarget(ref/*probably?*/ ViewTarget);
		UpdateViewTarget(ref/*probably?*/ ViewTarget, DeltaTime);
		NewPOV = ViewTarget.POV;
		ConstrainedAspectRatio = 1.77780f;
		if(PendingViewTarget.Target != default)
		{
			BlendTimeToGo -= DeltaTime;
			CheckViewTarget(ref/*probably?*/ PendingViewTarget);
			UpdateViewTarget(ref/*probably?*/ PendingViewTarget, DeltaTime);
			if(BlendTimeToGo > ((float)(0)))
			{
				DurationPct = 1.0f - (BlendTimeToGo / BlendParams.BlendTime);
				switch(BlendParams.BlendFunction)
				{
					case Camera.EViewTargetBlendFunction.VTBlend_Linear/*0*/:
						BlendPct = Lerp(0.0f, 1.0f, DurationPct);
						break;
					case Camera.EViewTargetBlendFunction.VTBlend_Cubic/*1*/:
						BlendPct = FCubicInterp(0.0f, 0.0f, 1.0f, 0.0f, DurationPct);
						break;
					case Camera.EViewTargetBlendFunction.VTBlend_EaseIn/*2*/:
						BlendPct = FInterpEaseIn(0.0f, 1.0f, DurationPct, BlendParams.BlendExp);
						break;
					case Camera.EViewTargetBlendFunction.VTBlend_EaseOut/*3*/:
						BlendPct = FInterpEaseOut(0.0f, 1.0f, DurationPct, BlendParams.BlendExp);
						break;
					case Camera.EViewTargetBlendFunction.VTBlend_EaseInOut/*4*/:
						BlendPct = FInterpEaseInOut(0.0f, 1.0f, DurationPct, BlendParams.BlendExp);
						break;
					default:
						break;
				}
				NewPOV = BlendViewTargets(ref/*probably?*/ ViewTarget, ref/*probably?*/ PendingViewTarget, BlendPct);
				ConstrainedAspectRatio = Lerp(ViewTarget.AspectRatio, PendingViewTarget.AspectRatio, BlendPct);			
			}
			else
			{
				ViewTarget = PendingViewTarget;
				PendingViewTarget.Target = default;
				PendingViewTarget.Controller = default;
				BlendTimeToGo = 0.0f;
				NewPOV = PendingViewTarget.POV;
				ConstrainedAspectRatio = PendingViewTarget.AspectRatio;
			}
		}
		FillCameraCache(ref/*probably?*/ NewPOV);
	}
	
	public virtual /*final function */Object.TPOV BlendViewTargets(/*const */ref Camera.TViewTarget A, /*const */ref Camera.TViewTarget B, float Alpha)
	{
		/*local */Object.TPOV POV = default;
	
		POV.Location = VLerp(A.POV.Location, B.POV.Location, Alpha);
		POV.FOV = Lerp(A.POV.FOV, B.POV.FOV, Alpha);
		POV.Rotation = RLerp(A.POV.Rotation, B.POV.Rotation, Alpha, true);
		return POV;
	}
	
	public virtual /*final function */void FillCameraCache(/*const */ref Object.TPOV NewPOV)
	{
		CameraCache.TimeStamp = WorldInfo.TimeSeconds;
		CameraCache.POV = NewPOV;
	}
	
	// Export UCamera::execCheckViewTarget(FFrame&, void* const)
	public virtual /*native function */void CheckViewTarget(ref Camera.TViewTarget VT)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*function */void UpdateViewTarget(ref Camera.TViewTarget OutVT, float DeltaTime)
	{
		/*local */Object.Vector Loc = default, pos = default, HitLocation = default, HitNormal = default;
		/*local */Object.Rotator Rot = default;
		/*local */Actor HitActor = default;
		/*local */CameraActor CamActor = default;
		/*local */bool bDoNotApplyModifiers = default;
		/*local */Object.TPOV OrigPOV = default;
	
		OrigPOV = OutVT.POV;
		OutVT.POV.FOV = DefaultFOV;
		CamActor = ((OutVT.Target) as CameraActor);
		if(CamActor != default)
		{
			CamActor.GetCameraView(DeltaTime, ref/*probably?*/ OutVT.POV);
			bConstrainAspectRatio = (bConstrainAspectRatio || CamActor.bConstrainAspectRatio);
			OutVT.AspectRatio = CamActor.AspectRatio;
			bCamOverridePostProcess = CamActor.bCamOverridePostProcess;
			CamPostProcessSettings = CamActor.CamOverridePostProcess;		
		}
		else
		{
			if(((((OutVT.Target) as Pawn) == default) || !((OutVT.Target) as Pawn).CalcCamera(DeltaTime, ref/*probably?*/ OutVT.POV.Location, ref/*probably?*/ OutVT.POV.Rotation, ref/*probably?*/ OutVT.POV.FOV)))
			{
				bDoNotApplyModifiers = true;
				switch(CameraStyle)
				{
					case "Fixed":
						OutVT.POV = OrigPOV;
						break;
					case "ThirdPerson":
					case "FreeCam":
						Loc = OutVT.Target.Location;
						Rot = OutVT.Target.Rotation;
						if(CameraStyle == "FreeCam")
						{
							Rot = PCOwner.Rotation;
						}
						Loc += (/*>>*/ShiftR(FreeCamOffset, Rot));
						pos = Loc - (((Vector)(Rot)) * FreeCamDistance);
						HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, pos, Loc, false, vect(12.0f, 12.0f, 12.0f), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, default(int?));
						OutVT.POV.Location = ((HitActor == default) ? pos : HitLocation);
						OutVT.POV.Rotation = Rot;
						break;
					case "FirstPerson":
					default:
						OutVT.Target.GetActorEyesViewPoint(ref/*probably?*/ OutVT.POV.Location, ref/*probably?*/ OutVT.POV.Rotation);
						break;
						break;
				}
			}
		}
		if(!bDoNotApplyModifiers)
		{
			ApplyCameraModifiers(DeltaTime, ref/*probably?*/ OutVT.POV);
		}
	}
	
	//// Export UCamera::execSetViewTarget(FFrame&, void* const)
	//public virtual /*native final function */void SetViewTarget(Actor NewViewTarget, /*optional */Camera.ViewTargetTransitionParams? _TransitionParams = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	public virtual /*function */void ProcessViewRotation(float DeltaTime, ref Object.Rotator OutViewRotation, ref Object.Rotator OutDeltaRot)
	{
		/*local */int ModifierIdx = default;
	
		ModifierIdx = 0;
		J0x07:{}
		if(ModifierIdx < ModifierList.Length)
		{
			if(ModifierList[ModifierIdx] != default)
			{
				if(ModifierList[ModifierIdx].ProcessViewRotation(ViewTarget.Target, DeltaTime, ref/*probably?*/ OutViewRotation, ref/*probably?*/ OutDeltaRot))
				{
					goto J0x71;
				}
			}
			++ ModifierIdx;
			goto J0x07;
		}
		J0x71:{}
	}
	
	public virtual /*event */void ApplyCameraModifiers(float DeltaTime, ref Object.TPOV OutPOV)
	{
		/*local */int ModifierIdx = default;
	
		ModifierIdx = 0;
		J0x07:{}
		if(ModifierIdx < ModifierList.Length)
		{
			if((ModifierList[ModifierIdx] != default) && !ModifierList[ModifierIdx].IsDisabled())
			{
				if(ModifierList[ModifierIdx].ModifyCamera(this, DeltaTime, ref/*probably?*/ OutPOV))
				{
					goto J0x7E;
				}
			}
			++ ModifierIdx;
			goto J0x07;
		}
		J0x7E:{}
	}
	
	public virtual /*function */bool AllowPawnRotation()
	{
		return true;
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */Object.Vector EyesLoc = default;
		/*local */Object.Rotator EyesRot = default;
		/*local */Canvas Canvas = default;
	
		Canvas = HUD.Canvas;
		Canvas.SetDrawColor(255, 255, 255, (byte)default(byte?));
		Canvas.DrawText((("\\tCamera Style:" + ((CameraStyle)).ToString()) + " " + "main ViewTarget:") + ((ViewTarget.Target)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText((((("   CamLoc:" + ((CameraCache.POV.Location)).ToString()) + " " + "CamRot:") + ((CameraCache.POV.Rotation)).ToString()) + " " + "FOV:") + ((CameraCache.POV.FOV)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("   AspectRatio:" + ((ConstrainedAspectRatio)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		if(ViewTarget.Target != default)
		{
			ViewTarget.Target.GetActorEyesViewPoint(ref/*probably?*/ EyesLoc, ref/*probably?*/ EyesRot);
			Canvas.DrawText((("   EyesLoc:" + ((EyesLoc)).ToString()) + " " + "EyesRot:") + ((EyesRot)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
	}
	
	public Camera()
	{
		// Object Offset:0x00292FF8
		DefaultFOV = 90.0f;
		DefaultAspectRatio = 1.3333330f;
		CamPostProcessSettings = new PostProcessVolume.PostProcessSettings
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
		CameraCache = new Camera.TCameraCache
		{
			TimeStamp = 0.0f,
			POV = new Object.TPOV
			{
				Location = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				Rotation = new Rotator
				{
					Pitch=0,
					Yaw=0,
					Roll=0
				},
				FOV = 90.0f,
			},
		};
		ViewTarget = new Camera.TViewTarget
		{
			Target = default,
			Controller = default,
			POV = new Object.TPOV
			{
				Location = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				Rotation = new Rotator
				{
					Pitch=0,
					Yaw=0,
					Roll=0
				},
				FOV = 90.0f,
			},
			AspectRatio = 0.0f,
			PRI = default,
		};
		PendingViewTarget = new Camera.TViewTarget
		{
			Target = default,
			Controller = default,
			POV = new Object.TPOV
			{
				Location = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				Rotation = new Rotator
				{
					Pitch=0,
					Yaw=0,
					Roll=0
				},
				FOV = 90.0f,
			},
			AspectRatio = 0.0f,
			PRI = default,
		};
		BlendParams = new Camera.ViewTargetTransitionParams
		{
			BlendTime = 0.0f,
			BlendFunction = Camera.EViewTargetBlendFunction.VTBlend_Cubic,
			BlendExp = 2.0f,
		};
		FreeCamDistance = 256.0f;
		bHidden = true;
	}
}
}