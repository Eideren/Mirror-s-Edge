namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Landing : TdMove/*
		native
		config(PawnMovement)*/{
	public /*config */float HardLandingDamage;
	public /*config */float LandingSpeedReduction;
	public /*config */float HardLandingHeight;
	public /*config */float SkillRollLandingHeight;
	public /*config */float SoftLandingHeight;
	public /*private */ForceFeedbackWaveform ImpactHeavyWaveform;
	public /*private */ForceFeedbackWaveform ImpactMediumWaveform;
	public bool bForceLandBack;
	public /*private transient */bool bLastLandingWasOnSoftObject;
	public /*private */MaterialInstance SoftLandingMaterialInstance;
	public /*private transient */ParticleSystem SoftLandingEffect;
	
	// Export UTdMove_Landing::execIsLandingOnSoftObject(FFrame&, void* const)
	public virtual /*native function */bool IsLandingOnSoftObject()
	{
		 // #warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		if(((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Balance/*29*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_SkillRoll/*91*/)))
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		base.StartReplicatedMove();
		LandNormal(0.50f);
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */bool bMovingBackwards = default;
		/*local */float DotHeadingAndVel = default;
		/*local */bool bLandedOnSoftSurface = default, bHardLanding = default, bSkillRollLanding = default;
		/*local */float FallingHeight = default;
		/*local */TdMove_SoftLanding SoftLandingMove = default;
		/*local */TdMove_RumpSlide RumpSlideMove = default;
		/*local */bool bCameFrom180InAir = default;
	
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/))
		{
			if(((PawnOwner.Controller) as TdPlayerController) != default)
			{
				((PawnOwner.Controller) as TdPlayerController).SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/, default(float?), true, default(float?));
			}
		}
		base.StartMove();
		RumpSlideMove = ((PawnOwner.Moves[38]) as TdMove_RumpSlide);
		SoftLandingMove = ((PawnOwner.Moves[78]) as TdMove_SoftLanding);
		bCameFrom180InAir = ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/);
		FallingHeight = PawnOwner.EnterFallingHeight - PawnOwner.Location.Z;
		bHardLanding = FallingHeight >= HardLandingHeight;
		bLandedOnSoftSurface = bHardLanding && bLastLandingWasOnSoftObject;
		DotHeadingAndVel = Dot(Normal(((Vector)(PawnOwner.Rotation))), Normal(PawnOwner.Velocity));
		bSkillRollLanding = !bLandedOnSoftSurface && (FallingHeight >= SkillRollLandingHeight) && PawnOwner.CanSkillRoll();
		bMovingBackwards = (((((DotHeadingAndVel < -0.30f) && ((int)PawnOwner.CurrentWalkingState) >= ((int)TdPawn.WalkingState.WAS_Run/*4*/)) || bCameFrom180InAir)) || (((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_SoftLanding/*78*/)) && SoftLandingMove.bMovingBackwards);
		if(bSkillRollLanding && !bMovingBackwards)
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_SkillRoll/*91*/, default(bool?), default(bool?));		
		}
		else
		{
			if((((((((bCameFrom180InAir || ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_LayOnGround/*26*/))) || bHardLanding && bMovingBackwards)) || bLastLandingWasOnSoftObject && bMovingBackwards)) || bForceLandBack))
			{
				LandBackwards();			
			}
			else
			{
				if(bLandedOnSoftSurface)
				{
					LandOnSoftObject();				
				}
				else
				{
					if(bHardLanding && (!PawnOwner.bUncontrolledSlide || (((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_RumpSlide/*38*/)) && RumpSlideMove.bTouchedFallHeightVolume))
					{
						LandHard();					
					}
					else
					{
						LandNormal(GetLandingAmount());
						EndLanding();
					}
				}
			}
		}
		bForceLandBack = false;
		bLastLandingWasOnSoftObject = false;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(SoftLandingMaterialInstance != default)
		{
			SoftLandingMaterialInstance.SetScalarParameterValue("FXM_SoftlandingWaves_01", 0.0f);
			SoftLandingMaterialInstance = default;
		}
	}
	
	public virtual /*function */void PlaySoftLandingEffect()
	{
		/*local *//*editinline */ParticleSystemComponent PSC = default;
		/*local */Object.Vector SpawnLocation = default;
	
		SpawnLocation = PawnOwner.Location;
		SpawnLocation.Z -= 90.0f;
		PSC = PawnOwner.WorldInfo.MyEmitterPool.SpawnEmitter(SoftLandingEffect, SpawnLocation, PawnOwner.Rotation, default(Actor?));
		PSC.ActivateSystem(default(bool?));
	}
	
	public virtual /*simulated function */void SubtractLandingSpeed()
	{
		/*local */TdMove_Jump JumpMove = default;
		/*local */TdMove_Falling FallMove = default;
		/*local */Object.Vector NewVelocity = default;
		/*local */bool bShouldSubtract = default;
	
		FallMove = ((PawnOwner.Moves[2]) as TdMove_Falling);
		bShouldSubtract = (((((((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Falling/*2*/)) && ((((int)FallMove.PreviousMove) == ((int)TdPawn.EMovement.MOVE_Jump/*11*/)) || ((int)FallMove.PreviousMove) == ((int)TdPawn.EMovement.MOVE_MeleeAir/*32*/))) || ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Coil/*61*/))) || ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_MeleeAir/*32*/));
		if(bShouldSubtract && ((int)PawnOwner.GetWeaponType()) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			JumpMove = ((PawnOwner.Moves[11]) as TdMove_Jump);
			if((JumpMove.PreJumpMomentum - LandingSpeedReduction) < VSize2D(PawnOwner.Velocity))
			{
				NewVelocity = PawnOwner.Velocity;
				NewVelocity.Z = 0.0f;
				NewVelocity = Normal(NewVelocity) * (JumpMove.PreJumpMomentum - LandingSpeedReduction);
				NewVelocity.Z = PawnOwner.Velocity.Z;
				PawnOwner.Velocity = NewVelocity;
			}
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if(PawnOwner.Controller.IsA("TdPlayerController"))
		{
			UpdateMeleeAutoLockOn(((PawnOwner.Controller) as TdPlayerController), DeltaTime, out_Rotation, ref/*probably?*/ DeltaRot);
		}
	}
	
	public virtual /*simulated function */float GetLandingAmount()
	{
		/*local */float Amount = default, FallHeight = default;
	
		FallHeight = PawnOwner.EnterFallingHeight - PawnOwner.Location.Z;
		Amount = FMax(0.0f, (FallHeight - SoftLandingHeight) / (HardLandingHeight - SoftLandingHeight));
		return FClamp(Amount, 0.20f, 1.0f);
	}
	
	public virtual /*simulated function */void LandNormal(float LandingAmount)
	{
		if(((((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/)) && PawnOwner.IsHumanControlled()) && ((int)PawnOwner.GetWeaponType()) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			PawnOwner.bForceMaxAccelOneFrame = true;
		}
		if(((int)PawnOwner.OldMovementState) != ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/))
		{
			SubtractLandingSpeed();
		}
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Coil/*61*/))
		{
			LandingAmount = 0.70f;
		}
		if(PawnOwner.LandNode1p != default)
		{
			PawnOwner.LandNode1p.Landed = LandingAmount;
		}
		if(PawnOwner.LandNode3p != default)
		{
			PawnOwner.LandNode3p.Landed = LandingAmount;
		}
		if(PawnOwner.Mesh1p != default)
		{
			((PawnOwner.Mesh1p.FindAnimNode("LandingRun")) as TdAnimNodeCustomBlend).Activate(LandingAmount, 0.60f * LandingAmount, 0.150f, 0.40f);
		}
		((PawnOwner.Mesh3p.FindAnimNode("LandingRun")) as TdAnimNodeCustomBlend).Activate(LandingAmount, 0.60f * LandingAmount, 0.150f, 0.40f);
		PawnOwner.PlayFootStepSound(((PawnOwner.Velocity.Z < -1000.0f) ? 9 : 8));
	}
	
	public virtual /*simulated function */void EndLanding()
	{
		if(CanStand(PawnOwner.Location, default(bool?)))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default(bool?), default(bool?));
		}
	}
	
	public virtual /*simulated function */void LandHard()
	{
		/*local */TdPlayerController PC = default;
	
		if(((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) || FRand() < 0.50f))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("FallingLandHard")), 1.0f, 0.050f, 0.20f, false, default(bool?));		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("FallingLandHard2")), 1.0f, 0.050f, 0.20f, false, default(bool?));
		}
		PawnOwner.SetIgnoreMoveInput(-1.0f);
		PawnOwner.SetIgnoreLookInput(-1.0f);
		PC = ((PawnOwner.Controller) as TdPlayerController);
		PC.ClientPlayForceFeedbackWaveform(ImpactHeavyWaveform);
		PC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_HeavyLanding/*8*/);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = PawnOwner.Velocity;
		ResetCameraLook(((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) ? 0.10f : 0.30f));
	}
	
	public virtual /*simulated function */void LandOnSoftObject()
	{
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("FallingLandSoftLanding")), 1.0f, 0.10f, 0.10f, false, default(bool?));
		PawnOwner.SetIgnoreMoveInput(-1.0f);
		PawnOwner.SetIgnoreLookInput(-1.0f);
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(ImpactMediumWaveform);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = PawnOwner.Velocity;
		ResetCameraLook(0.30f);
		PlaySoftLandingEffect();
	}
	
	public virtual /*simulated function */void LandBackwards()
	{
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpTurnLanding")), 1.0f, 0.10f, 0.10f, false, default(bool?));
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_LayOnGround/*26*/, default(bool?), default(bool?));
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(ImpactMediumWaveform);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = PawnOwner.Velocity;
		ResetCameraLook(0.30f);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		PawnOwner.StopIgnoreLookInput();
		PawnOwner.StopIgnoreMoveInput();
		PawnOwner.Acceleration = Normal(PawnOwner.Velocity);
		PawnOwner.UseRootMotion(false);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_Landing()
	{
		var Default__TdMove_Landing_ImpactHeavyWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C658
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 70,
					RightAmplitude = 50,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 50,
					RightAmplitude = 30,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.30f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_Landing.ImpactHeavyWaveformObj' */;
		var Default__TdMove_Landing_ImpactMediumWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C7C4
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.40f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_Landing.ImpactMediumWaveformObj' */;
		// Object Offset:0x005C97CF
		HardLandingDamage = 15.0f;
		LandingSpeedReduction = 65.0f;
		HardLandingHeight = 530.0f;
		SkillRollLandingHeight = 200.0f;
		SoftLandingHeight = 300.0f;
		ImpactHeavyWaveform = Default__TdMove_Landing_ImpactHeavyWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_Landing.ImpactHeavyWaveformObj'*/;
		ImpactMediumWaveform = Default__TdMove_Landing_ImpactMediumWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_Landing.ImpactMediumWaveformObj'*/;
		SoftLandingEffect = LoadAsset<ParticleSystem>("FX_InteractionEffects.Effects.PS_FX_Landing_SoftObject_01")/*Ref ParticleSystem'FX_InteractionEffects.Effects.PS_FX_Landing_SoftObject_01'*/;
	}
}
}