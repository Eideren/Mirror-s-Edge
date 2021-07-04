namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallRun : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(Gameplay)*/ /*config */float WallRunningForwardCheckDistance;
	public/*(Gameplay)*/ /*config */float WallRunningStrafeCheckDistance;
	public/*(Gameplay)*/ /*config */float WallRunningVerticalCheckDistance;
	public/*(Gameplay)*/ /*config */float WallRunningMinWallHeight;
	public/*(Gameplay)*/ /*config */float WallRunningMinSpeed;
	public/*(Gameplay)*/ /*config */float WallRunningVelocityStartLimit;
	public/*(Gameplay)*/ /*config */float WallRunningVelocityStopLimit;
	public/*(Gameplay)*/ /*config */float WallRunningForwardMinStartAngle;
	public/*(Gameplay)*/ /*config */float WallRunningForwardMaxStartAngle;
	public/*(Gameplay)*/ /*config */float WallRunningStrafeStartAngle;
	public/*(Gameplay)*/ /*config */float WallRunningHorisontalFriction;
	public/*(Gameplay)*/ /*config */float WallRunningHorisontalInitialZHeight;
	public/*(Gameplay)*/ /*config */float WallRunningHorisontalAcceleration;
	public/*(Gameplay)*/ /*config */float WallRunningHorisontalDeceleration;
	public/*(Gameplay)*/ /*config */float WallRunningHorisontalAlignSpeed;
	public/*(Animation)*/ /*config */float WallRunningIntoWallrunBlendInTime;
	public/*(Animation)*/ /*config */float WallRunningIntoWallrunBlendOutTime;
	public/*(Animation)*/ /*config */bool PlayCameraHitWallEffect;
	public bool bHasReachedWall;
	public bool bStartMovingIntoWall;
	public bool bTurned90FromWall;
	public /*private */bool bChangedConstraints;
	public/*(Animation)*/ /*config */float WallRunningDelayPawnRotationTime;
	public/*(Animation)*/ /*config */float WallRunningDistanceForIntoWall;
	public/*(Animation)*/ /*config */float WallRunningRotatePawnAlongWallTime;
	public/*(Animation)*/ /*config */float WallRunningMoveToIntoPositionDegreeThreshold;
	public/*(Animation)*/ /*config */float MinimumVelocityIntoWall;
	public/*(Animation)*/ /*config */float MaximumVelocityIntoWall;
	public/*(Animation)*/ /*config */float WallrunStartUpperBodyAnimPlayRate;
	public/*(Animation)*/ /*config */float LookAlongWallInterpolationTime;
	public float WallRunningBeginSpeed;
	public TdPawn.EMovement NextMove;
	public Object.Vector WallNormal;
	public Object.Vector PredictedWallHitLocation;
	public Object.Vector IntoWallrunLocationTarget;
	public int ConsequtiveWallruns;
	public /*protected */ForceFeedbackWaveform IntoWallrunWaveform;
	public /*private */int MinContraintWorld;
	public /*private */int MaxContraintWorld;
	
	// Export UTdMove_WallRun::execFindWallForward(FFrame&, void* const)
	public virtual /*native function */TdPawn.EMovement FindWallForward(ref TdPawn.LedgeHitInfo out_LedgeHit)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove_WallRun::execFindWallSide(FFrame&, void* const)
	public virtual /*native function */bool FindWallSide(TdPawn.EMovement WallRunSide, ref TdPawn.LedgeHitInfo out_LedgeHit)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		/*local */TdPawn.LedgeHitInfo WallRunHit = default;
		/*local */TdMovementExclusionVolume EMVolume = default;
		/*local */TdPawn.EMovement WantedMove = default;
		/*local */float LastJumpLocationDelta = default;
		/*local */Object.Vector StartTrace = default, EndTrace = default, Extent = default;
		/*local */float HalfVel2DSize = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		if(VSizeSq2D(PawnOwner.Velocity) < Square(WallRunningMinSpeed))
		{
			return false;
		}
		if((Dot(PawnOwner.Velocity, ((Vector)(PawnOwner.Rotation)))) < 0.0f)
		{
			return false;
		}
		LastJumpLocationDelta = VSize(PawnOwner.Location - PawnOwner.LastJumpLocation);
		WantedMove = TdPawn.EMovement.MOVE_None/*0*/;
		if(LastJumpLocationDelta < 30.0f)
		{
			if(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Right/*2*/))
			{
				WantedMove = TdPawn.EMovement.MOVE_WallRunningRight/*4*/;			
			}
			else
			{
				if(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/))
				{
					WantedMove = TdPawn.EMovement.MOVE_WallRunningLeft/*5*/;
				}
			}
		}
		if((((int)WantedMove) != ((int)TdPawn.EMovement.MOVE_None/*0*/)) && FindWallSide(((TdPawn.EMovement)WantedMove), ref/*probably?*/ WallRunHit))
		{
			NextMove = ((TdPawn.EMovement)WantedMove);		
		}
		else
		{
			NextMove = ((TdPawn.EMovement)FindWallForward(ref/*probably?*/ WallRunHit));
		}
		if(((int)NextMove) == ((int)TdPawn.EMovement.MOVE_None/*0*/))
		{
			return false;
		}
		if(WallRunHit.FeetExcluded)
		{
			return false;
		}
		EMVolume = GetMovementExclusionVolume(WallRunHit.LedgeLocation);
		if((EMVolume != default) && EMVolume.bExcludeFootMoves)
		{
			return false;
		}
		if((Dot(PawnOwner.Velocity, WallRunHit.MoveNormal)) >= 0.0f)
		{
			return false;
		}
		if(PawnOwner.Velocity.Z < 0.0f)
		{
			StartTrace = WallRunHit.LedgeLocation + (WallRunHit.MoveNormal * PawnOwner.CylinderComponent.CollisionRadius);
			StartTrace.Z -= (PawnOwner.CylinderComponent.CollisionHeight * 2.0f);
			HalfVel2DSize = VSize2D(PawnOwner.Velocity) * 0.50f;
			if(((int)NextMove) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/))
			{
				EndTrace = (Cross(WallRunHit.MoveNormal, vect(0.0f, 0.0f, -1.0f))) * HalfVel2DSize;			
			}
			else
			{
				EndTrace = (Cross(WallRunHit.MoveNormal, vect(0.0f, 0.0f, 1.0f))) * HalfVel2DSize;
			}
			EndTrace.Z -= 45.0f;
			EndTrace += StartTrace;
			Extent.X = 1.0f;
			Extent.Y = 1.0f;
			if(MovementTraceForBlocking(EndTrace, StartTrace, Extent))
			{
				return false;
			}
		}
		PawnOwner.MovementActor = WallRunHit.MoveActor;
		PawnOwner.bFoundLedgeExcludesFootMoves = WallRunHit.FeetExcluded;
		PawnOwner.bFoundLedgeExcludesHandMoves = WallRunHit.HandsExcluded;
		PawnOwner.MoveNormal = WallRunHit.MoveNormal;
		WallNormal = WallRunHit.MoveNormal;
		PredictedWallHitLocation = WallRunHit.LedgeLocation;
		return true;
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float?));
		return base.HandleDeath(Damage);
	}
	
	public override /*simulated function */void ReachedWall()
	{
		/*local */Object.Vector Velocity2D = default;
	
		Velocity2D = PawnOwner.Velocity;
		Velocity2D.Z = 0.0f;
		Velocity2D = WallRunningBeginSpeed * Normal(Velocity2D);
		PawnOwner.Velocity.X = Velocity2D.X;
		PawnOwner.Velocity.Y = Velocity2D.Y;
		if(PlayCameraHitWallEffect)
		{
			if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/))
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_Camera/*6*/, "wallrunimpactright", 1.0f, 0.150f, 0.150f, default(bool?), default(bool?));			
			}
			else
			{
				if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/))
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_Camera/*6*/, "wallrunimpactleft", 1.0f, 0.150f, 0.150f, default(bool?), default(bool?));
				}
			}
		}
		bHasReachedWall = true;
		bDisableFaceRotation = true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector WallrunDir = default, HitLocation = default, HitNormal = default, Start = default, End = default, Extent = default;
	
		/*local */float Grav = default, Speed = default, WallRunHeight = default, AnimPlayRate = default;
	
		base.StartMove();
		bHasReachedWall = false;
		bStartMovingIntoWall = true;
		bChangedConstraints = false;
		bTurned90FromWall = false;
		WallRunningBeginSpeed = VSize2D(PawnOwner.Velocity);
		if(PawnOwner.Velocity.Z > 0.0f)
		{
			WallRunningBeginSpeed = FMax(WallRunningBeginSpeed, WallRunningVelocityStartLimit);
		}
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunJump/*12*/))
		{
			++ ConsequtiveWallruns;
			WallRunningHorisontalDeceleration = DefaultAs<TdMove_WallRun>().WallRunningHorisontalDeceleration * ((float)(1 + ConsequtiveWallruns));
			WallRunningHorisontalAcceleration = DefaultAs<TdMove_WallRun>().WallRunningHorisontalAcceleration * ((float)(1 + ConsequtiveWallruns));		
		}
		else
		{
			ConsequtiveWallruns = 0;
			WallRunningHorisontalDeceleration = DefaultAs<TdMove_WallRun>().WallRunningHorisontalDeceleration;
			WallRunningHorisontalAcceleration = DefaultAs<TdMove_WallRun>().WallRunningHorisontalAcceleration;
		}
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_WallRunning/*12*/);
		bHasReachedWall = false;
		bStartMovingIntoWall = false;
		WallrunDir = ((Vector)(PawnOwner.Rotation));
		WallrunDir -= ((Dot(WallrunDir, WallNormal)) * WallNormal);
		WallrunDir.Z = 0.0f;
		WallrunDir = Normal(WallrunDir);
		Start = PawnOwner.Location;
		End = Start;
		End.Z += WallRunningHorisontalInitialZHeight;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, End, Start, PawnOwner.GetCollisionExtent(), default(bool?)))
		{
			WallRunHeight = HitLocation.Z - PawnOwner.Location.Z;		
		}
		else
		{
			WallRunHeight = WallRunningHorisontalInitialZHeight;
		}
		WallRunHeight -= (PawnOwner.Location.Z - PawnOwner.LastJumpLocation.Z);
		WallRunHeight = ((float)(Max(((int)(WallRunHeight)), 0)));
		Grav = WallRunningHorisontalAcceleration;
		Speed = Sqrt((2.0f * WallRunHeight) * Grav);
		if((PawnOwner.Velocity.Z > 0.0f) && ((int)PawnOwner.OldMovementState) != ((int)TdPawn.EMovement.MOVE_WallRunJump/*12*/))
		{
			PawnOwner.Velocity.Z = Speed;
		}
		PawnOwner.SetBase(PawnOwner.MovementActor, WallNormal, default(SkeletalMeshComponent), default(name?));
		SetTimer(WallRunningDelayPawnRotationTime);
		Extent.X = PawnOwner.CylinderComponent.CollisionRadius;
		Extent.Y = PawnOwner.CylinderComponent.CollisionRadius;
		Extent.Z = 10.0f;
		Start = PredictedWallHitLocation;
		Start.Z += ((PawnOwner.CylinderComponent.CollisionHeight + 30.0f) + Extent.Z);
		End = Start + (-WallNormal * WallRunningStrafeCheckDistance);
		AnimPlayRate = WallrunStartUpperBodyAnimPlayRate;
		if(!MovementTraceForBlocking(End, Start, Extent))
		{
			AnimPlayRate = 1.0f;
		}
		if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "wallrunrightstart", AnimPlayRate, WallRunningIntoWallrunBlendInTime, WallRunningIntoWallrunBlendOutTime, default(bool?), default(bool?));
			MinContraintWorld = NormalizeRotAxis(((Rotator)(WallNormal)).Yaw);
			MaxContraintWorld = NormalizeRotAxis(((Rotator)(WallNormal)).Yaw + 16384);		
		}
		else
		{
			if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/))
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "wallrunleftstart", AnimPlayRate, WallRunningIntoWallrunBlendInTime, WallRunningIntoWallrunBlendOutTime, default(bool?), default(bool?));
				MinContraintWorld = NormalizeRotAxis(((Rotator)(WallNormal)).Yaw - 16384);
				MaxContraintWorld = NormalizeRotAxis(((Rotator)(WallNormal)).Yaw);
			}
		}
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(IntoWallrunWaveform);
	}
	
	public override /*simulated function */void OnTimer()
	{
		FacePawnAlongWall();
	}
	
	public virtual /*simulated function */void FacePawnAlongWall()
	{
		/*local */Object.Rotator NewRotation = default;
	
		NewRotation = ((Rotator)(WallNormal));
		NewRotation.Yaw += ((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/)) ? 16384 : -16384);
		PawnOwner.MoveNormal = WallNormal;
		SetPreciseRotation(NewRotation, WallRunningRotatePawnAlongWallTime);
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		/*local */Object.Rotator WantedRotation = default;
		/*local */Controller C = default;
		/*local */TdPlayerPawn PlayerPawn = default;
	
		if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
		{
			if(!bTurned90FromWall)
			{
				PlayerPawn = ((PawnOwner) as TdPlayerPawn);
				if(PlayerPawn != default)
				{
					PlayerPawn.StartStringableMove(Class);
				}
			}
			C = PawnOwner.Controller;
			WantedRotation = ((Rotator)(PawnOwner.Floor));
			if(C != default)
			{
				WantedRotation.Pitch = C.Rotation.Pitch;
			}
			bDisableControllerFacingPawnYawRotation = true;
			SetLookAtTargetAngle(WantedRotation, 0.150f, 1.50f);
			bTurned90FromWall = true;
		}
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return true;
	}
	
	public override /*simulated function */void StopMove()
	{
		NextMove = TdPawn.EMovement.MOVE_None/*0*/;
		if(!bTurned90FromWall)
		{
			PawnOwner.FaceRotationTimeLeft = 0.30f;
			PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
		}
		base.StopMove();
	}
	
	public override /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
		if(PawnOwner.Moves[2].CanDoMove())
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */int GetMinLookConstrainYaw()
	{
		return MinContraintWorld;
	}
	
	public override /*simulated function */int GetMaxLookConstrainYaw()
	{
		return MaxContraintWorld;
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_WallRun()
	{
		var Default__TdMove_WallRun_IntoWallrunWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CE3C
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 30,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.40f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_WallRun.IntoWallrunWaveformObj' */;
		// Object Offset:0x005EF165
		WallRunningForwardCheckDistance = 50.0f;
		WallRunningStrafeCheckDistance = 50.0f;
		WallRunningMinWallHeight = 192.0f;
		WallRunningMinSpeed = 200.0f;
		WallRunningVelocityStartLimit = 300.0f;
		WallRunningVelocityStopLimit = -500.0f;
		WallRunningForwardMaxStartAngle = 57.0f;
		WallRunningStrafeStartAngle = 60.0f;
		WallRunningHorisontalFriction = 0.050f;
		WallRunningHorisontalInitialZHeight = 170.0f;
		WallRunningHorisontalAcceleration = 820.0f;
		WallRunningHorisontalDeceleration = 500.0f;
		WallRunningHorisontalAlignSpeed = 700.0f;
		WallRunningIntoWallrunBlendInTime = 0.20f;
		WallRunningIntoWallrunBlendOutTime = 0.20f;
		PlayCameraHitWallEffect = true;
		WallRunningDelayPawnRotationTime = 0.010f;
		WallRunningDistanceForIntoWall = 180.0f;
		WallRunningRotatePawnAlongWallTime = 0.40f;
		WallRunningMoveToIntoPositionDegreeThreshold = 70.0f;
		MinimumVelocityIntoWall = 600.0f;
		MaximumVelocityIntoWall = 700.0f;
		WallrunStartUpperBodyAnimPlayRate = 0.60f;
		LookAlongWallInterpolationTime = 0.20f;
		IntoWallrunWaveform = Default__TdMove_WallRun_IntoWallrunWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_WallRun.IntoWallrunWaveformObj'*/;
		ControllerState = (name)"PlayerWallWalking";
		bConstrainLook = true;
		bUseAbsoluteYawConstraint = true;
		bDisableControllerFacingPawnYawRotation = true;
		bUseCameraCollision = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		RedoMoveTime = 0.150f;
		MinLookConstraint = new Rotator
		{
			Pitch=-13000,
			Yaw=-16384,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=13000,
			Yaw=16384,
			Roll=32768
		};
		AnimBlendTime = 0.20f;
		StickyAngle = 4000;
		StickyAimedModifier = 1.0f;
	}
}
}