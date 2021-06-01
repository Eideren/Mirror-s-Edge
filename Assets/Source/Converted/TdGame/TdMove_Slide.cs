namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Slide : TdMove/*
		native
		config(PawnMovement)*/{
	public/*(Slide)*/ /*config */float SlideAbortSpeed;
	public/*(Slide)*/ /*config */float SlideAbortTime;
	public/*(Slide)*/ /*config */float MaxFloorInclineZ;
	public int SlideAngleTarget;
	public bool bGoingInto;
	public bool bRequestUncrouch;
	public /*private */ForceFeedbackWaveform SlideWaveform;
	
	// Export UTdMove_Slide::execFloorDeclineTooSteep(FFrame&, void* const)
	public virtual /*native function */bool FloorDeclineTooSteep()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector VelDir2D = default, SlopeDir = default;
		/*local */float FloorInclineZ = default, VelDotFloor = default;
		/*local */TdPlayerController PC = default;
	
		if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_SkillRoll/*91*/))
		{
			return false;
		}
		if((Dot(PawnOwner.Velocity, ((Vector)(PawnOwner.Rotation)))) < 350.0f)
		{
			return false;
		}
		VelDir2D = PawnOwner.Velocity;
		VelDir2D.Z = 0.0f;
		VelDir2D = Normal(VelDir2D);
		SlopeDir = -PawnOwner.Floor;
		SlopeDir.Z = 0.0f;
		SlopeDir = Normal(SlopeDir);
		VelDotFloor = Dot(VelDir2D, SlopeDir);
		FloorInclineZ = Sqrt(1.0f - FClamp(Square(PawnOwner.Floor.Z), 0.0f, 1.0f));
		FloorInclineZ *= VelDotFloor;
		if(FloorInclineZ > MaxFloorInclineZ)
		{
			return false;
		}
		PC = ((PawnOwner.Controller) as TdPlayerController);
		if(((PC != default) && PawnOwner.Weapon != default) && PawnOwner.MyWeapon.IsZoomingOrZoomed())
		{
			return false;
		}
		return true;
	}
	
	public override /*function */bool CanStopMove()
	{
		bRequestUncrouch = true;
		if(bGoingInto)
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.10f);
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, 0.0f);
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, 0.40f);
		}
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("CrouchSlide")), 1.0f, 0.40f, 0.40f, default(bool?), default(bool?));
		bGoingInto = true;
		bRequestUncrouch = false;
		PawnOwner.StartSlideEffect();
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(SlideWaveform);
		SetTimer(0.50f);
		EnableSwingControl();
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return AreWeSlidingUnderSomething();
	}
	
	public virtual /*simulated function */bool AreWeSlidingUnderSomething()
	{
		/*local */Object.Vector TraceStart = default, TraceEnd = default, TraceExtent = default;
		/*local */bool Result = default;
	
		TraceExtent = PawnOwner.GetCollisionExtent();
		TraceExtent *= 0.50f;
		TraceStart = PawnOwner.Location;
		TraceStart.Z -= TraceExtent.Z;
		TraceEnd = TraceStart;
		TraceEnd += (PawnOwner.Velocity * 0.60f);
		Result = !MovementTraceForBlocking(TraceEnd, TraceStart, TraceExtent);
		if(Result)
		{
			TraceStart.Z += (TraceExtent.Z * 1.80f);
			TraceEnd = TraceStart;
			TraceEnd += (PawnOwner.Velocity * 0.60f);
			Result = MovementTraceForBlocking(TraceEnd, TraceStart, TraceExtent);
		}
		return Result;
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		base.StartReplicatedMove();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PawnOwner.Velocity = PawnOwner.Velocity / 2.0f;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("CrouchSlideToCrouch")), 1.0f, 0.10f, 0.20f, default(bool?), default(bool?));
		PawnOwner.FaceRotationTimeLeft = 0.40f;
		PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
		PawnOwner.StopSlideEffect();
		DisableSwingControl();
		((PawnOwner.Controller) as TdPlayerController).ClientStopForceFeedbackWaveform(SlideWaveform);
	}
	
	public override /*simulated function */void StopReplicatedMove()
	{
		base.StopReplicatedMove();
	}
	
	public virtual /*simulated function */void EnableSwingControl()
	{
		if(PawnOwner.SwingControl1p != default)
		{
			PawnOwner.SwingControl1p.SetSkelControlStrength(1.0f, 0.250f);
			PawnOwner.SwingControl1p.BoneRotation.Roll = 0;
			PawnOwner.SwingControl1p.BoneTranslation = vect(0.0f, 0.0f, 0.0f);
		}
		PawnOwner.SwingControl3p.SetSkelControlStrength(1.0f, 0.250f);
		PawnOwner.SwingControl3p.BoneRotation.Roll = 0;
		PawnOwner.SwingControl3p.BoneTranslation = vect(0.0f, 0.0f, 0.0f);
	}
	
	public virtual /*simulated function */void DisableSwingControl()
	{
		if(PawnOwner.SwingControl1p != default)
		{
			PawnOwner.SwingControl1p.SetSkelControlStrength(0.0f, 0.250f);
		}
		PawnOwner.SwingControl3p.SetSkelControlStrength(0.0f, 0.250f);
	}
	
	public virtual /*event */void AbortMove()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnTimer()
	{
		bGoingInto = false;
		if(bRequestUncrouch)
		{
			AbortMove();
		}
	}
	
	public override /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default, PawnRotation = default;
	
		PawnRootLocation = PawnOwner.Location;
		PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		PawnRotation = Normal(((Vector)(PawnOwner.Rotation)));
		PawnRotation.Z = 0.0f;
		return PawnRootLocation - (PawnRotation * 50.0f);
	}
	
	public override /*function */void CheckForCameraCollision(Object.Vector CameraLocation, Object.Rotator CameraRotation)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default, TraceEnd = default, TraceStart = default, TraceExtent = default, MeshOffset = default;
	
		if(MoveActiveTime < 0.20f)
		{
			TraceStart = CameraLocation - (((Vector)(PawnOwner.Rotation)) * 5.0f);
			TraceEnd = CameraLocation + (((Vector)(PawnOwner.Rotation)) * 15.0f);
			TraceEnd.Z += 5.0f;
			TraceExtent = vect(2.0f, 2.0f, 2.0f);
			if(MovementTraceForBlockingEx(TraceEnd, TraceStart, TraceExtent, ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal))
			{
				MeshOffset.X = -VSize2D(TraceEnd - HitLocation) - 1.0f;
				PawnOwner.OffsetMeshXY(MeshOffset, false);
			}
		}
	}
	
	public TdMove_Slide()
	{
		// Object Offset:0x005D9908
		SlideAbortSpeed = 250.0f;
		SlideAbortTime = 2.0f;
		MaxFloorInclineZ = 0.50f;
		SlideWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CBE6
			bIsLooping = true,
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 0,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.0f,
				},
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Sin90to180,
					Duration = 1.0f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_Slide.SlideWaveformObj' */;
		FrictionModifier = 0.10f;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bAvoidLedges = false;
		bUseCustomCollision = true;
		bUseCameraCollision = true;
		bAllowPickup = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.70f,
			Medium = 0.80f,
			Hard = 0.90f,
		};
		DisableMovementTime = -1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-10000,
			Yaw=-10000,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=10000,
			Yaw=10000,
			Roll=0
		};
		AnimBlendTime = 0.50f;
	}
}
}