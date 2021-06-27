namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_RumpSlide : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public /*private */ForceFeedbackWaveform SlideWaveform;
	public float TimeFalling;
	public /*config */float MaxSlideSpeed;
	public /*config */float SideControl;
	public /*config */float GravityModifier;
	public /*config */float InitialSpeedLoss;
	public /*config */float MinSlideFloorZ;
	public float OldFloorZ;
	public bool bTouchedFallHeightVolume;
	
	public override /*function */bool CanDoMove()
	{
		if(PawnOwner.UncontrolledSlideNormal.Z >= MinSlideFloorZ)
		{
			return false;
		}
		if(PawnOwner.UncontrolledSlideNormal.Z < 0.60f)
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		TimeFalling = 0.0f;
		PawnOwner.GravityModifier = GravityModifier;
		PawnOwner.Velocity = ((Cross((Cross(PawnOwner.UncontrolledSlideNormal, vect(0.0f, 0.0f, -1.0f))), PawnOwner.UncontrolledSlideNormal)) * VSize(PawnOwner.Velocity)) * InitialSpeedLoss;
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default(float?));
		SetTimer(0.0f);
		OldFloorZ = PawnOwner.WalkableFloorZ;
		PawnOwner.WalkableFloorZ = MinSlideFloorZ;
		PawnOwner.StreakEffectOverride = 1.0f;
		bTouchedFallHeightVolume = false;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.WalkableFloorZ = OldFloorZ;
		PawnOwner.GravityModifier = 1.0f;
		PawnOwner.LastFootstepMaterial = default;
		PawnOwner.StopSlideEffect();
		PawnOwner.StreakEffectOverride = 0.0f;
		((PawnOwner.Controller) as TdPlayerController).ClientStopForceFeedbackWaveform(SlideWaveform);
	}
	
	public override /*simulated function */void TouchedFallHeightVolume()
	{
		bTouchedFallHeightVolume = true;
	}
	
	public override /*simulated function */void OnTimer()
	{
		StartSliding();
	}
	
	public virtual /*simulated function */void StartSliding()
	{
		/*local */Object.Vector Side = default, Surface = default;
	
		Side = Cross(PawnOwner.UncontrolledSlideNormal, vect(0.0f, 0.0f, 1.0f));
		Surface = Cross(PawnOwner.UncontrolledSlideNormal, Side);
		SetPreciseRotation(((Rotator)(Surface)), AnimBlendTime);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float?));
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "crouchslideintoend45", 1.0f, 0.150f, 0.20f, false, default(bool?));
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(SlideWaveform);
		PawnOwner.StartSlideEffect();
	}
	
	public TdMove_RumpSlide()
	{
		var Default__TdMove_RumpSlide_SlideWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CA2E
			bIsLooping = true,
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Sin90to180,
					Duration = 1.0f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_RumpSlide.SlideWaveformObj' */;
		// Object Offset:0x005D7C21
		SlideWaveform = Default__TdMove_RumpSlide_SlideWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_RumpSlide.SlideWaveformObj'*/;
		MaxSlideSpeed = 1000.0f;
		SideControl = 350.0f;
		GravityModifier = 0.50f;
		InitialSpeedLoss = 0.750f;
		MinSlideFloorZ = 0.90f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.010f,
			Medium = 0.040f,
			Hard = 0.10f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 200.0f,
			Medium = 200.0f,
			Hard = 200.0f,
		};
		DisableMovementTime = -1.0f;
		RedoMoveTime = 1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-5000,
			Yaw=-5000,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=5000,
			Yaw=5000,
			Roll=0
		};
		RootOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=20.0f
		};
		AnimBlendTime = 0.50f;
	}
}
}