namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_IntoClimb : TdPhysicsMove/*
		config(PawnMovement)*/{
	public enum EClimbEnterState 
	{
		CES_EnteringAtTop,
		CES_EnteringAtBottom,
		CES_EnteringFalling,
		CES_MAX
	};
	
	public TdMove_IntoClimb.EClimbEnterState ClimbState;
	public TdLadderVolume Ladder;
	public bool AtBottomStep;
	public bool bPlayingImpact;
	public float FirstStepZDistance;
	public /*private */ForceFeedbackWaveform ImpactHardWaveform;
	public /*private */ForceFeedbackWaveform ImpactSoftWaveform;
	
	public override /*function */bool CanDoMove()
	{
		/*local */float Angle = default;
		/*local */bool BehindLadder = default;
		/*local */Object.Vector PawnToLadder2D = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		if(Ladder == default)
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) && ((int)PawnOwner.MoveActionHint) != ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
		{
			return false;
		}
		if(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Down/*4*/))
		{
			return false;
		}
		if(((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Climb/*21*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Cutscene/*93*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_IntoClimb/*22*/))
		{
			return false;
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		Angle = Dot(((Vector)(PawnOwner.Rotation)), ((Vector)(Ladder.Rotation)));
		PawnToLadder2D = Ladder.Location - PawnOwner.Location;
		PawnToLadder2D.Z = 0.0f;
		BehindLadder = (Dot(PawnToLadder2D, ((Vector)(Ladder.Rotation)))) < 0.0f;
		if(PawnOwner.Location.Z > Ladder.GetLadderLocation(Ladder.PawnLadderLocations.Length - 1).Z)
		{
			if((Angle > -0.850f) || ((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/))
			{
				return false;
			}		
		}
		else
		{
			if((Angle < -0.10f) || BehindLadder)
			{
				return false;
			}
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */int CurrentLadderStep = default;
		/*local */float Angle = default;
		/*local */Object.Vector Delta = default;
	
		assert(Ladder != default);
		base.StartMove();
		bPlayingImpact = false;
		PawnOwner.bClimbLeftHand = false;
		PawnOwner.bClimbDownFast = false;
		CurrentLadderStep = Clamp(Ladder.GetClosestStep(PawnOwner.Location.Z), 0, Ladder.GetLastStep());
		AtBottomStep = CurrentLadderStep == 0;
		ResetCameraLook(0.30f);
		Angle = Dot(((Vector)(PawnOwner.Rotation)), ((Vector)(Ladder.Rotation)));
		PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
		PawnOwner.bCollideWorld = false;
		PawnOwner.MoveNormal = Ladder.WallNormal;
		if((((int)Ladder.LadderType) != ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) && (Angle < -0.850f) && Ladder.GetLadderLocation(Ladder.PawnLadderLocations.Length - 1).Z < PawnOwner.Location.Z)
		{
			ClimbState = TdMove_IntoClimb.EClimbEnterState.CES_EnteringAtTop/*0*/;
			PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
			PawnOwner.bCollideWorld = false;
			SetPreciseLocation((Ladder.GetLadderLocation(Ladder.PawnLadderLocations.Length - 1) - (Ladder.WallNormal * 93.50f)) + (Ladder.MoveDirection * 90.0f), TdMove.EPreciseLocationMode.PLM_Fly/*0*/, 500.0f);		
		}
		else
		{
			ClimbState = TdMove_IntoClimb.EClimbEnterState.CES_EnteringFalling/*2*/;
			PlayStartAnimation();
			Delta = Ladder.GetLadderLocation(CurrentLadderStep) - PawnOwner.Location;
			SetPreciseLocation(Ladder.GetLadderLocation(CurrentLadderStep), TdMove.EPreciseLocationMode.PLM_Fly/*0*/, FMax(VSize2D(Delta), 30.0f) / 0.150f);
			SetPreciseRotation(((Rotator)(-Ladder.WallNormal)), 0.150f);
			PawnOwner.FaceRotationTimeLeft = 0.150f;
		}
	}
	
	public virtual /*simulated function */void PlayStartAnimation()
	{
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbHangStartLeft" : "LadderClimbHangStartLeft"), 1.0f, 0.150f, 0.250f, default(bool?), default(bool?));
			bPlayingImpact = true;		
		}
		else
		{
			if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/))
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbHangStartRight" : "LadderClimbHangStartRight"), 1.0f, 0.150f, 0.250f, default(bool?), default(bool?));
				bPlayingImpact = true;			
			}
			else
			{
				if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_GrabTransfer/*31*/))
				{
					if((Dot((Cross(((Vector)(Ladder.Rotation)), vect(0.0f, 0.0f, 1.0f))), ((Vector)(PawnOwner.Rotation)))) > 0.0f)
					{
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbHangStartRight" : "LadderClimbHangStartRight"), 1.0f, 0.150f, 0.250f, default(bool?), default(bool?));					
					}
					else
					{
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbHangStartLeft" : "LadderClimbHangStartLeft"), 1.0f, 0.150f, 0.250f, default(bool?), default(bool?));
					}
					bPlayingImpact = true;				
				}
				else
				{
					if(PawnOwner.Velocity.Z < -800.0f)
					{
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbHangStartHard" : "LadderClimbHangStartHard"), 1.0f, 0.10f, 0.250f, default(bool?), default(bool?));
						PawnOwner.TakeDamage(1, default, PawnOwner.Location, vect(0.0f, 0.0f, 0.0f), ClassT<DmgType_Fell>(), default(Actor.TraceHitInfo?), default(Actor?));
						((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(ImpactHardWaveform);
						bPlayingImpact = true;					
					}
					else
					{
						if((PawnOwner.Velocity.Z < -200.0f) || ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_GrabTransfer/*31*/))
						{
							PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbHangStart" : "LadderClimbHangStart"), 1.0f, 0.10f, 0.250f, default(bool?), default(bool?));
							((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(ImpactSoftWaveform);
							bPlayingImpact = true;						
						}
						else
						{
							if(((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/))
							{
								PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? "PipeClimbStart" : "PipeClimbStart"), 1.0f, 0.150f, 0.250f, default(bool?), default(bool?));
							}
						}
					}
				}
			}
		}
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Climb/*21*/, 0.150f);
	}
	
	public override /*simulated function */void StopMove()
	{
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, 0.20f);
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
		Ladder = default;
		base.StopMove();
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.SetIgnoreMoveInput(-1.0f);
		if(((int)ClimbState) == ((int)TdMove_IntoClimb.EClimbEnterState.CES_EnteringAtTop/*0*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "LadderEnterTop", 1.0f, 0.250f, 0.10f, true, true);
			PawnOwner.UseRootRotation(true);
			PawnOwner.UseRootMotion(true);
			PawnOwner.SetRotation(((Rotator)(Ladder.WallNormal)));
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Climb/*21*/, 0.250f);
			PawnOwner.bClimbLeftHand = true;		
		}
		else
		{
			StartClimbMove();
		}
	}
	
	public virtual /*simulated function */void StartClimbMove()
	{
		/*local */TdAnimNodeSequence AnimSeq1p = default;
	
		PawnOwner.SetRotation(((Rotator)(-Ladder.WallNormal)));
		PawnOwner.SetLocation(Ladder.GetLadderLocation(Ladder.GetClosestStep(PawnOwner.Location.Z)));
		if(PawnOwner.Moves[21].CanDoMove() && Ladder != default)
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Climb/*21*/, default(bool?), default(bool?));
			if(bPlayingImpact)
			{
				AnimSeq1p = ((PawnOwner.CustomFullBodyNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
				PawnOwner.SetIgnoreMoveInput(FMax(0.10f, AnimSeq1p.AnimSeq.SequenceLength - 0.50f));
			}		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		if(((int)ClimbState) == ((int)TdMove_IntoClimb.EClimbEnterState.CES_EnteringAtTop/*0*/))
		{
			StartClimbMove();
		}
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		/*local */int CurrentLadderStep = default;
	
		if((((int)ClimbState) == ((int)TdMove_IntoClimb.EClimbEnterState.CES_EnteringAtTop/*0*/)) || ((int)ClimbState) == ((int)TdMove_IntoClimb.EClimbEnterState.CES_EnteringAtBottom/*1*/))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
			return;
		}
		if(AtBottomStep)
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
			return;
		}
		CurrentLadderStep = Ladder.GetClosestStep(PawnOwner.Location.Z);
		AtBottomStep = CurrentLadderStep == 0;
		SetPreciseLocation(Ladder.GetLadderLocation(CurrentLadderStep), TdMove.EPreciseLocationMode.PLM_Fall/*4*/, FMax(VSize2D(PawnOwner.Velocity), 200.0f));
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		return PawnOwner.Health - 1;
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		return false;
	}
	
	public TdMove_IntoClimb()
	{
		var Default__TdMove_IntoClimb_ImpactHardWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C4BC
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
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_IntoClimb.ImpactHardWaveformObj' */;
		var Default__TdMove_IntoClimb_ImpactSoftWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C58A
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 15,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.40f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_IntoClimb.ImpactSoftWaveformObj' */;
		// Object Offset:0x005C2B95
		FirstStepZDistance = 38.0f;
		ImpactHardWaveform = Default__TdMove_IntoClimb_ImpactHardWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_IntoClimb.ImpactHardWaveformObj'*/;
		ImpactSoftWaveform = Default__TdMove_IntoClimb_ImpactSoftWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_IntoClimb.ImpactSoftWaveformObj'*/;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerWalking";
		bShouldHolsterWeapon = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		FirstPersonDPG = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
		RedoMoveTime = 0.50f;
	}
}
}