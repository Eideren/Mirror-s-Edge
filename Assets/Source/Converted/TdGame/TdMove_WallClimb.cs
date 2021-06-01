namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallClimb : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(Gameplay)*/ /*config */float WallClimbingVelocityStartLimit;
	public/*(Gameplay)*/ /*config */float WallClimbingVerticalStartAngle;
	public/*(Gameplay)*/ /*config */float WallClimbingVerticalFriction;
	public/*(Gameplay)*/ /*config */float WallClimbingMaxDistance2D;
	public/*(Gameplay)*/ /*config */float AddOnSpeed2DHeight;
	public/*(Gameplay)*/ /*config */float AddOnSpeed2DMaxLimit;
	public/*(Gameplay)*/ /*config */float AddOnSpeedZHeight;
	public/*(Gameplay)*/ /*config */float AddOnSpeedZMaxLimit;
	public/*(Gameplay)*/ /*config */float WallClimbingGravity;
	public/*(Gameplay)*/ /*config */float MinLegdeZNormal;
	public/*(Gameplay)*/ /*config */float MinWallHeight;
	public/*(Gameplay)*/ /*config */float MinUpwardsVelocityToDoubleJump;
	public/*(Gameplay)*/ /*config */float MaxIntoWallClimbVelocityToDoubleJump;
	public bool bHasReachedWall;
	public bool bFoundPossibleHandPlant;
	public /*transient */bool bPerformedDoubleJump;
	public Object.Rotator LookAtEdgeAngle;
	public Object.Vector PossibleEdgeDestination;
	public float IntoWallClimbSpeed;
	public /*transient */float GroundZLoc;
	public /*protected */ForceFeedbackWaveform IntoWallClimbWaveform;
	
	// Export UTdMove_WallClimb::execDetectPossibleHandPlant(FFrame&, void* const)
	public virtual /*native function */bool DetectPossibleHandPlant()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdMove_WallClimb::execCheckDoubleJump(FFrame&, void* const)
	public virtual /*native function */void CheckDoubleJump()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float?));
		return base.HandleDeath(Damage);
	}
	
	public virtual /*simulated event */void FoundPossibleHandPlant()
	{
		LookAtLedge(PossibleEdgeDestination);
		bFoundPossibleHandPlant = true;
	}
	
	public virtual /*simulated function */void LookAtLedge(Object.Vector LedgeLocation)
	{
		/*local */Object.Vector EyeLocation = default;
		/*local */Object.Rotator WallRotation = default;
	
		EyeLocation = PawnOwner.Location;
		EyeLocation.Z += PawnOwner.BaseEyeHeight;
		if(LedgeLocation.Z > EyeLocation.Z)
		{
			WallRotation = Normalize(((Rotator)(-PawnOwner.MoveNormal)));
			LookAtEdgeAngle = PawnOwner.Rotation;
			LookAtEdgeAngle.Pitch = ((Rotator)(Normal(LedgeLocation - EyeLocation))).Pitch;
			if(Abs(((float)(WallRotation.Yaw - PawnOwner.Rotation.Yaw))) > ((float)(4096)))
			{
				LookAtEdgeAngle.Yaw = PawnOwner.Rotation.Yaw;			
			}
			else
			{
				LookAtEdgeAngle.Yaw = WallRotation.Yaw;
			}
			LookAtEdgeAngle = Normalize(LookAtEdgeAngle);
			SetLookAtTargetAngle(LookAtEdgeAngle, 0.20f, default(float?));		
		}
		else
		{
			AbortLookAtTarget();
		}
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector SuckIntoWallSpeed = default;
	
		base.StartMove();
		bHasReachedWall = false;
		bFoundPossibleHandPlant = false;
		bPerformedDoubleJump = false;
		IntoWallClimbSpeed = VSize2D(PawnOwner.Velocity) - ClassT<TdMove_Jump>().DefaultAs<TdMove_Jump>().JumpAddXY;
		LookAtEdgeAngle = PawnOwner.Rotation;
		WallClimbingGravity = Abs(PawnOwner.GetGravityZ());
		PawnOwner.SetBase(PawnOwner.MovementActor, PawnOwner.MoveNormal, default(SkeletalMeshComponent?), default(name?));
		if(DetectPossibleHandPlant())
		{
			FoundPossibleHandPlant();
		}
		PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "WallRunVertical", 0.20f, 0.20f, 0.0f, true, true, false, false);
		GroundZLoc = PawnOwner.LastJumpLocation.Z - PawnOwner.CylinderComponent.CollisionHeight;
		if(IntoWallClimbSpeed < 100.0f)
		{
			SuckIntoWallSpeed = -PawnOwner.MoveNormal * 400.0f;
			PawnOwner.Velocity.X = SuckIntoWallSpeed.X;
			PawnOwner.Velocity.Y = SuckIntoWallSpeed.Y;
		}
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(IntoWallClimbWaveform);
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return true;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.250f);
	}
	
	public override /*simulated function */void ReachedWall()
	{
		/*local */TdAnimNodeSequence AnimNode1p = default, AnimNode3p = default;
		/*local */float InterpValue = default, AddOnHeight = default, DistanceToLedge = default, TimeToLedge = default, AnimPlayRate = default, SqrtValue = default;
	
		InterpValue = ((float)(Max(((int)(IntoWallClimbSpeed - PawnOwner.SpeedMaxBaseVelocity)), 0))) / (AddOnSpeed2DMaxLimit - PawnOwner.SpeedMaxBaseVelocity);
		InterpValue = FClamp(InterpValue, 0.0f, 1.0f);
		AddOnHeight = AddOnSpeed2DHeight * InterpValue;
		InterpValue = PawnOwner.Velocity.Z / AddOnSpeedZMaxLimit;
		InterpValue = FClamp(InterpValue, 0.0f, 1.0f);
		AddOnHeight += (AddOnSpeedZHeight * InterpValue);
		WallClimbingGravity = DefaultAs<TdMove_WallClimb>().WallClimbingGravity;
		SqrtValue = FMax((4.0f * AddOnHeight) * WallClimbingGravity, 0.010f);
		PawnOwner.Velocity.Z = Sqrt(SqrtValue);
		bHasReachedWall = true;
		if(bFoundPossibleHandPlant)
		{
			DistanceToLedge = PossibleEdgeDestination.Z - (PawnOwner.Location.Z + PawnOwner.CylinderComponent.CollisionHeight);
			SqrtValue = FMax((2.0f * DistanceToLedge) / WallClimbingGravity, 0.010f);
			TimeToLedge = Sqrt(SqrtValue);
			if(TimeToLedge > 0.40f)
			{
				AnimPlayRate = FClamp(0.40f / TimeToLedge, 0.10f, 0.850f);			
			}
			else
			{
				AnimPlayRate = 0.30f;
			}		
		}
		else
		{
			TimeToLedge = PawnOwner.Velocity.Z / (2.0f * WallClimbingGravity);
			AnimPlayRate = FClamp(0.40f / TimeToLedge, 0.10f, 1.0f);
		}
		if(PawnOwner.CustomFullBodyNode1p != default)
		{
			AnimNode1p = ((PawnOwner.CustomFullBodyNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			AnimNode1p.Rate = AnimPlayRate;
		}
		if(PawnOwner.CustomFullBodyNode3p != default)
		{
			AnimNode3p = ((PawnOwner.CustomFullBodyNode3p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			AnimNode3p.Rate = AnimPlayRate;
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */Object.Vector DefaultLookTarget = default;
	
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if(bFoundPossibleHandPlant)
		{
			LookAtLedge(PossibleEdgeDestination);		
		}
		else
		{
			DefaultLookTarget = PawnOwner.Location;
			DefaultLookTarget += (-PawnOwner.MoveNormal * PawnOwner.CylinderComponent.CollisionRadius);
			DefaultLookTarget.Z += (PawnOwner.BaseEyeHeight + 100.0f);
			LookAtLedge(DefaultLookTarget);
		}
	}
	
	public virtual /*event */void PerformDoubleJump()
	{
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpSlow")), 1.0f, 0.150f, 0.150f, default(bool?), default(bool?));
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_WallClimb()
	{
		// Object Offset:0x005EB6EE
		WallClimbingVerticalStartAngle = 33.0f;
		WallClimbingVerticalFriction = 6.0f;
		WallClimbingMaxDistance2D = 120.0f;
		AddOnSpeed2DHeight = 60.0f;
		AddOnSpeed2DMaxLimit = 650.0f;
		AddOnSpeedZHeight = 130.0f;
		AddOnSpeedZMaxLimit = 320.0f;
		WallClimbingGravity = 800.0f;
		MinLegdeZNormal = 0.7070f;
		MinWallHeight = 180.0f;
		MinUpwardsVelocityToDoubleJump = 100.0f;
		MaxIntoWallClimbVelocityToDoubleJump = 100.0f;
		IntoWallClimbWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CD6E
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
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_WallClimb.IntoWallClimbWaveformObj' */;
		PawnPhysics = Actor.EPhysics.PHYS_WallClimbing;
		ControllerState = (name)"PlayerWallWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForEdgeInVelDir = true;
		FrictionModifier = 0.30f;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		WeaponInactivePitchAimingLimit = 0;
	}
}
}