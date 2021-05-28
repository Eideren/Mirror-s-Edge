namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_SkillRoll : TdPhysicsMove/*
		config(PawnMovement)*/{
	public /*private */ForceFeedbackWaveform ImpactSkilledWaveform;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		return ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Landing/*20*/);
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PawnOwner.UseRootMotion(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("fallinglandroll")), 1.0f, 0.20f, 0.20f, true, default(bool));
		PawnOwner.SetIgnoreMoveInput(-1.0f);
		PawnOwner.SetIgnoreLookInput(-1.0f);
		ResetCameraLook(0.20f);
		SetMoveTimer(0.20f, false, "DisableSwanneck");
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(ImpactSkilledWaveform);
		PawnOwner.OnTutorialEvent(1);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, 0.20f);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = PawnOwner.Velocity;
	}
	
	public virtual /*simulated function */void DisableSwanneck()
	{
		SetSwanNeckConstraints(0, 0.0f, 0.0f);
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return true;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		AimMode = TdPawn.MoveAimMode.MAM_Right/*1*/;
		PawnOwner.UseRootMotion(false);
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		PawnOwner.StopIgnoreLookInput();
		PawnOwner.StopIgnoreMoveInput();
		PawnOwner.Acceleration = Normal(PawnOwner.Velocity);
		PawnOwner.UseRootMotion(false);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		return false;
	}
	
	public TdMove_SkillRoll()
	{
		// Object Offset:0x005D85CA
		ImpactSkilledWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CB18
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.30f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_SkillRoll.ImpactSkilledWaveformObj' */;
		ControllerState = (name)"PlayerGrabbing";
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bAvoidLedges = false;
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		AimMode = TdPawn.MoveAimMode.MAM_Right;
		MinLookConstraint = new Rotator
		{
			Pitch=-2000,
			Yaw=-5000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=32768,
			Yaw=5000,
			Roll=32768
		};
	}
}
}