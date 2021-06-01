namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Climb : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public enum EClimbState 
	{
		CS_Climbing,
		CS_ExitAtTop,
		CS_ExitAtBottom,
		CS_MAX
	};
	
	public enum EClimbAnimationType 
	{
		CAT_ClimbUpLeftHand,
		CAT_ClimbUpRightHand,
		CAT_ClimbUpFastLeftHand,
		CAT_ClimbUpFastRightHand,
		CAT_ClimbExitAtTopRightHand,
		CAT_ClimbExitAtTopLeftHand,
		CAT_MAX
	};
	
	public TdMove_Climb.EClimbState ClimbState;
	public TdPawn.EMovementAction WantedAction;
	public TdMove_GrabTransfer TransferMove;
	public bool bIsPlayingAnimation;
	public TdLadderVolume Ladder;
	public/*(Climb)*/ /*config */float IdleBlendInTime;
	public/*(Climb)*/ /*config */float ClimbBlendInTime;
	public/*(Climb)*/ /*config */float ClimbDownBlendInTime;
	public/*(Climb)*/ /*config */float ClimbDownFastVelocity;
	public/*(Climb)*/ /*config */float ClimbFastUpPipeAnimRate;
	public array<name> ClimbAnims;
	public /*export editinline */AudioComponent ClimbSoundComponent;
	public SoundCue ClimbDownLadderFastSound;
	public SoundCue ClimbDownPipeFastSound;
	public/*(Climb)*/ /*config */int StartTurningAngle;
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		TransferMove = ((PawnOwner.Moves[31]) as TdMove_GrabTransfer);
		TransferMove.Ladder = Ladder;
		PawnOwner.LadderType = (byte)Ladder.LadderType;
		InitClimbAnimSeqNames();
		ResetCameraLook(0.30f);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		SetCustomCollisionSize(PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius - 5.0f, PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight);
		if(ClimbSoundComponent == default)
		{
			ClimbSoundComponent = PawnOwner.CreateAudioComponent(((((int)PawnOwner.LadderType) == 0) ? ClimbDownLadderFastSound : ClimbDownPipeFastSound), false, true, default(bool?), default(Object.Vector?), default(bool?));
		}
		if(ClimbSoundComponent != default)
		{
			ClimbSoundComponent.Location = PawnOwner.Location;
			ClimbSoundComponent.bUseOwnerLocation = true;
			ClimbSoundComponent.bAllowSpatialization = true;
			ClimbSoundComponent.bAutoDestroy = true;
			PawnOwner.AttachComponent(ClimbSoundComponent);
			ClimbSoundComponent.SoundCue = ((((int)PawnOwner.LadderType) == 0) ? ClimbDownLadderFastSound : ClimbDownPipeFastSound);
			ClimbSoundComponent.FadeIn(0.050f, 0.0f);
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		Reset();
		Ladder = default;
		TransferMove = default;
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
		PawnOwner.FaceRotationTimeLeft = 0.20f;
		PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
		((PawnOwner.Moves[22]) as TdMove_IntoClimb).LastStopMoveTime = PawnOwner.WorldInfo.TimeSeconds;
		if(ClimbSoundComponent != default)
		{
			ClimbSoundComponent.FadeOut(0.10f, 0.0f);
		}
		SetCustomCollisionSize(PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius, PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight);
		base.StopMove();
	}
	
	public virtual /*simulated function */void Reset()
	{
		PawnOwner.bClimbLeftHand = false;
		PawnOwner.bClimbDownFast = false;
		bIsPlayingAnimation = false;
		WantedAction = TdPawn.EMovementAction.MA_None/*0*/;
		ClimbState = TdMove_Climb.EClimbState.CS_Climbing/*0*/;
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		/*local */Object.Rotator LookAtAngle = default;
	
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
		{
			if((((int)ClimbState) != ((int)TdMove_Climb.EClimbState.CS_ExitAtTop/*1*/)) && ((int)ClimbState) != ((int)TdMove_Climb.EClimbState.CS_ExitAtBottom/*2*/))
			{
				LetGo();
				return;
			}
		}
		if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
		{
			LookAtAngle = PawnOwner.Rotation;
			LookAtAngle.Yaw += (((PawnOwner.Controller.Rotation.Yaw - PawnOwner.Rotation.Yaw) > 0) ? 32768 : -32768);
			AbortLookAtTarget();
			SetLookAtTargetAngle(Normalize(LookAtAngle), 0.20f, 1.0f);
		}
		WantedAction = ((TdPawn.EMovementAction)Action);
		if(bIsPlayingAnimation || bUsePreciseLocation)
		{
			AbortLookAtTarget();
			return;
		}
		if(((!PawnOwner.bClimbDownFast && ((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Down/*4*/)) && PawnOwner.bMoveActionMax) && Ladder.GetClosestStep(PawnOwner.Location.Z) > 4)
		{
			PawnOwner.bClimbDownFast = true;
			ResetCameraLook(0.30f);
			PawnOwner.SetIgnoreLookInput(-1.0f);
			if(ClimbSoundComponent != default)
			{
				ClimbSoundComponent.FadeIn(0.050f, 1.0f);
			}
		}
		if((!PawnOwner.bClimbDownFast && ((int)Action) != ((int)TdPawn.EMovementAction.MA_None/*0*/)) && ((int)GetAimMode(true)) == ((int)TdPawn.MoveAimMode.MAM_NoHands/*3*/))
		{
			HandleClimbAction();
		}
	}
	
	public virtual /*function */bool HasFloorBelow()
	{
		/*local */int CurrentStep = default;
		/*local */Object.Vector StartTrace = default, EndTrace = default;
	
		CurrentStep = Ladder.GetClosestStep(PawnOwner.Location.Z);
		StartTrace = Ladder.GetLadderLocation(CurrentStep) - vect(0.0f, 0.0f, 20.0f);
		EndTrace = Ladder.GetLadderLocation(CurrentStep) - vect(0.0f, 0.0f, 20.0f);
		if(MovementTraceForBlocking(EndTrace, StartTrace, vect(0.0f, 0.0f, 0.0f)))
		{
			return true;
		}
		return false;
	}
	
	public virtual /*event */void StopClimbDownFast()
	{
		if(!bUsePreciseLocation)
		{
			if(HasFloorBelow())
			{
				LetGo();
				return;
			}
			SetPreciseLocation(Ladder.GetLadderLocation(Ladder.GetClosestStepDown(PawnOwner.Location.Z)), TdMove.EPreciseLocationMode.PLM_Fly/*0*/, ((float)(Max(100, ((int)(PawnOwner.Velocity.Z))))));
			if(ClimbSoundComponent != default)
			{
				ClimbSoundComponent.FadeOut(0.050f, 0.0f);
			}
		}
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		if((((int)ClimbState) == ((int)TdMove_Climb.EClimbState.CS_ExitAtTop/*1*/)) || ((int)ClimbState) == ((int)TdMove_Climb.EClimbState.CS_ExitAtBottom/*2*/))
		{
			if(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
			{
				PawnOwner.Velocity = ((Vector)(PawnOwner.Rotation)) * 300.0f;
				PawnOwner.Acceleration = Normal(PawnOwner.Velocity);
				((PawnOwner.Controller) as TdPlayerController).AccelerationTime = 0.20f;
			}
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		}
	}
	
	public virtual /*simulated function */void HandleClimbAction()
	{
		/*local */int CurrentStep = default;
	
		CurrentStep = Ladder.GetClosestStep(PawnOwner.Location.Z);
		if((((int)WantedAction) == ((int)TdPawn.EMovementAction.MA_ClimbUp/*7*/)) || ((int)WantedAction) == ((int)TdPawn.EMovementAction.MA_ClimbUpLong/*9*/))
		{
			if(CurrentStep == Ladder.GetLastStep())
			{
				if(Ladder.bCanExitAtTop)
				{
					ExitAtTop(((PawnOwner.bClimbLeftHand) ? 4 : 5));
				}			
			}
			else
			{
				if((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) && (Ladder.GetLastStep() - CurrentStep) > 1)
				{
					Climb(((PawnOwner.bClimbLeftHand) ? 3 : 2), 1.0f, 2);				
				}
				else
				{
					Climb(((PawnOwner.bClimbLeftHand) ? 1 : 0), 1.0f, 1);
				}
			}		
		}
		else
		{
			if((((int)WantedAction) == ((int)TdPawn.EMovementAction.MA_ClimbDown/*8*/)) || ((int)WantedAction) == ((int)TdPawn.EMovementAction.MA_ClimbDownLong/*10*/))
			{
				if(CurrentStep > 1)
				{
					if((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) && CurrentStep > 2)
					{
						Climb(((PawnOwner.bClimbLeftHand) ? 2 : 3), -1.0f, -2);					
					}
					else
					{
						Climb(((PawnOwner.bClimbLeftHand) ? 0 : 1), -1.0f, -1);
					}				
				}
				else
				{
					if(HasFloorBelow())
					{
						LetGo();
					}
				}
			}
		}
	}
	
	public virtual /*simulated function */void Climb(int ClimbAnimIndex, float Rate, int StepCount)
	{
		/*local */Object.Vector TargetLocation = default;
		/*local */float ClimbSpeed = default;
	
		ClimbSpeed = Abs(((float)(StepCount))) * ((((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/)) ? 64.0f : 96.0f);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ClimbAnims[ClimbAnimIndex], Rate, 0.10f, 0.0750f, false, default(bool?));
		bIsPlayingAnimation = true;
		SetTimer(0.10f);
		TargetLocation = Ladder.GetLadderLocation(Ladder.GetClosestStep(PawnOwner.Location.Z) + StepCount);
		SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, ClimbSpeed);
	}
	
	public virtual /*simulated function */void ExitAtTop(int ClimbAnimIndex)
	{
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ClimbAnims[ClimbAnimIndex], 1.0f, 0.10f, 0.10f, true, default(bool?));
		bIsPlayingAnimation = true;
		ResetCameraLook(0.10f);
		PawnOwner.SetIgnoreLookInput(-1.0f);
		PawnOwner.SetTimer(0.90f, false, "StopIgnoreLookInput", default(Object?));
		PawnOwner.UseRootMotion(true);
		ClimbState = TdMove_Climb.EClimbState.CS_ExitAtTop/*1*/;
		PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
		PawnOwner.bCollideWorld = false;
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, 0.50f);
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
		PawnOwner.SetRotation(((Rotator)(-Ladder.WallNormal)));
		bIsPlayingAnimation = false;
		PawnOwner.bClimbDownFast = false;
		PawnOwner.StopIgnoreLookInput();
	}
	
	public override /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		LetGo();
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
		LetGo();
	}
	
	public virtual /*simulated function */void LetGo()
	{
		/*local */Object.Vector TraceStart = default, TraceEnd = default, Extent = default, HitLocation = default, HitNormal = default;
	
		Extent = PawnOwner.GetCollisionExtent();
		Extent.Z = 8.0f;
		TraceStart = PawnOwner.Location;
		TraceStart.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		Extent.Z += 8.0f;
		TraceEnd = TraceStart;
		TraceEnd.Z -= 32.0f;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, Extent, false))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		}
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "PipeExitBottom", 1.0f, 0.10f, 0.40f, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.bClimbLeftHand = !PawnOwner.bClimbLeftHand;
	}
	
	public override /*simulated function */int GetMinLookConstrainPitch()
	{
		/*local */int Delta = default;
	
		Delta = ((int)(Abs(((float)(Normalize(PawnOwner.Controller.Rotation - PawnOwner.Rotation).Yaw)))));
		return ((Delta > StartTurningAngle) ? -11000 : MinLookConstraint.Pitch);
	}
	
	public override /*simulated function */int GetMinLookConstrainYaw()
	{
		if(bIsPlayingAnimation)
		{
			return -StartTurningAngle;
		}
		return base.GetMinLookConstrainYaw();
	}
	
	public override /*simulated function */int GetMaxLookConstrainYaw()
	{
		if(bIsPlayingAnimation)
		{
			return StartTurningAngle;
		}
		return base.GetMaxLookConstrainYaw();
	}
	
	public override /*simulated function */void PostConstrainCamera(Object.Rotator ConstrainAmount, ref Object.Rotator DeltaRot)
	{
		if(Abs(((float)(Normalize(PawnOwner.Controller.Rotation - PawnOwner.Rotation).Yaw))) > ((float)(12000)))
		{
			return;
		}
		if(ConstrainAmount.Pitch < 0)
		{
			if(((float)(PawnOwner.Controller.Rotation.Yaw - PawnOwner.Rotation.Yaw)) > 0.0f)
			{
				if(DeltaRot.Yaw >= 0)
				{
					DeltaRot.Yaw -= ((int)(((float)(ConstrainAmount.Pitch)) * 0.50f));
				}			
			}
			else
			{
				if(DeltaRot.Yaw <= 0)
				{
					DeltaRot.Yaw += ((int)(((float)(ConstrainAmount.Pitch)) * 0.50f));
				}
			}
		}
	}
	
	public virtual /*simulated function */void InitClimbAnimSeqNames()
	{
		if(((int)Ladder.LadderType) == ((int)TdLadderVolume.ELadderType.LT_Pipe/*1*/))
		{
			ClimbAnims[0] = ((name)("PipeClimbUpLeftHand"));
			ClimbAnims[1] = ((name)("PipeClimbUpRightHand"));
			ClimbAnims[2] = ((name)("PipeClimbUpFastLeftHand"));
			ClimbAnims[3] = ((name)("PipeClimbUpFastRightHand"));
			ClimbAnims[5] = ((name)("PipeExitTopLeftHand"));
			ClimbAnims[4] = ((name)("PipeExitTopRightHand"));		
		}
		else
		{
			ClimbAnims[0] = ((name)("LadderClimbUpLeftHand"));
			ClimbAnims[1] = ((name)("LadderClimbUpRightHand"));
			ClimbAnims[2] = ((name)("LadderClimbUpFastLeftHand"));
			ClimbAnims[3] = ((name)("LadderClimbUpFastRightHand"));
			ClimbAnims[5] = ((name)("LadderExitTopLeftHand"));
			ClimbAnims[4] = ((name)("LadderExitTopRightHand"));
		}
	}
	
	public override /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
		LetGo();
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		if(((int)ClimbState) == ((int)TdMove_Climb.EClimbState.CS_ExitAtTop/*1*/))
		{
			return PawnOwner.Health - 1;		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float?));
		}
		return base.HandleDeath(Damage);
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		return false;
	}
	
	public TdMove_Climb()
	{
		// Object Offset:0x005AE95C
		IdleBlendInTime = 0.050f;
		ClimbBlendInTime = 0.050f;
		ClimbDownBlendInTime = 0.50f;
		ClimbDownFastVelocity = 200.0f;
		ClimbFastUpPipeAnimRate = 2.0f;
		ClimbDownLadderFastSound = LoadAsset<SoundCue>("A_Material_Handstep.Metal_Slide.Ladder")/*Ref SoundCue'A_Material_Handstep.Metal_Slide.Ladder'*/;
		ClimbDownPipeFastSound = LoadAsset<SoundCue>("A_Material_Handstep.Metal_Slide.Pipe")/*Ref SoundCue'A_Material_Handstep.Metal_Slide.Pipe'*/;
		StartTurningAngle = 16384;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerGrabbing";
		bShouldHolsterWeapon = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		FirstPersonDPG = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		RedoMoveTime = 0.50f;
		MinLookConstraint = new Rotator
		{
			Pitch=-5000,
			Yaw=-32000,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=10000,
			Yaw=32000,
			Roll=0
		};
		SwanNeckForward = 40.0f;
	}
}
}