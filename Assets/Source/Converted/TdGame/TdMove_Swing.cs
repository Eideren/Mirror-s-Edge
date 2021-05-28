// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Swing : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public TdSwingVolume Volume;
	public float SwingVelocity;
	public float MaxSwingVelocity;
	public /*config */float ExitVelocityModifier;
	public float SwingAngle;
	public Object.Vector SwingDirection;
	public Object.Vector BarDirection;
	public Object.Vector SwingLocation;
	public /*config */float SwingPendulumLength;
	public bool bIsInterpolatingInto;
	public bool bIsShimmying;
	public bool bIsTurning;
	public TdAnimNodeSequence CustomAnimNode;
	public float ShimmyVelocity;
	public float ShimmyTime;
	public /*config */float SwingAngleTimingOffset;
	public /*config */float SwingExitGravityModifier;
	public /*config */float SwingExitGravityModifierTime;
	public /*export editinline */AudioComponent SwingSoundComponent;
	public SoundCue SwingSound;
	
	// Export UTdMove_Swing::execGetPawnLocation(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetPawnLocation(float Angle)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdMove_Swing::execGetPawnAngle(FFrame&, void* const)
	public virtual /*native function */float GetPawnAngle(Object.Vector Location)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdMove_Swing::execUpdateShimmy(FFrame&, void* const)
	public virtual /*native function */void UpdateShimmy(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdMove_Swing::execCanShimmy(FFrame&, void* const)
	public virtual /*native function */bool CanShimmy(float Delta)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdMove_Swing::execCheckForTargetVolume(FFrame&, void* const)
	public virtual /*native function */TdSwingVolume CheckForTargetVolume(Object.Vector Direction)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector GripToPawn = default;
	
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		GripToPawn = PawnOwner.Location - Volume.Location;
		if((Dot(Normal(GripToPawn), ((Vector)(PawnOwner.Rotation)))) >= -0.30f)
		{
			return false;
		}
		if((Dot(Normal(GripToPawn), Normal(PawnOwner.Velocity))) >= 0.0f)
		{
			return false;
		}
		if((Dot(Normal(GripToPawn), vect(0.0f, 0.0f, -1.0f))) < -0.50f)
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		EnableSwingControl();
		PawnOwner.SetRootOffset(vect(0.0f, -50.0f, -32.0f), AnimBlendTime, SkelControlBase.EBoneControlSpace.BCS_BoneSpace/*4*/);
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector VolumeX = default, VolumeY = default, VolumeZ = default, ToGrip = default;
	
		base.StartMove();
		PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);
		PawnOwner.SetRootOffset(vect(0.0f, -50.0f, -32.0f), AnimBlendTime, SkelControlBase.EBoneControlSpace.BCS_BoneSpace/*4*/);
		Volume.GetAxes(Volume.Rotation, ref/*probably?*/ VolumeX, ref/*probably?*/ VolumeY, ref/*probably?*/ VolumeZ);
		PointDistToLine(PawnOwner.Location, VolumeY, Volume.Location, ref/*probably?*/ SwingLocation);
		ToGrip = Normal(Volume.Location - PawnOwner.Location);
		if((Dot(ToGrip, ((Vector)(Volume.Rotation)))) >= 0.0f)
		{
			BarDirection = VolumeY;
			SwingDirection = VolumeX;		
		}
		else
		{
			BarDirection = -VolumeY;
			SwingDirection = -VolumeX;
		}
		SwingAngle = GetPawnAngle(PawnOwner.Location);
		SwingAngle = ((float)(Clamp(((int)(SwingAngle)), ((int)(-1.20f)), ((int)(-0.70f)))));
		SwingVelocity = MaxSwingVelocity * FMin(1.0f, VSize2D(PawnOwner.Velocity) / 500.0f);
		SetPreciseRotation(((Rotator)(SwingDirection)), AnimBlendTime);
		bIsInterpolatingInto = true;
		SetPawnRotation(SwingAngle);
		EnableSwingControl();
		ResetCameraLook(AnimBlendTime);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, AnimBlendTime);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, AnimBlendTime);
		InitSwingSound();
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((Volume.bThickGrip) ? ((name)("SwingHardStartWide")) : ((name)("SwingHardStart"))), 1.0f, AnimBlendTime, 0.20f, default(bool), default(bool));
		SetMoveTimer(AnimBlendTime, false, "StopInterpolating");
	}
	
	public override /*simulated function */void StopReplicatedMove()
	{
		DisableSwingControl();
		PawnOwner.SetRootOffset(vect(0.0f, 0.0f, 0.0f), 0.10f, ((SkelControlBase.EBoneControlSpace)default(SkelControlBase.EBoneControlSpace)));
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		DisableSwingControl();
		StopSwingSound();
		PawnOwner.SetRootOffset(vect(0.0f, 0.0f, 0.0f), 0.10f, ((SkelControlBase.EBoneControlSpace)default(SkelControlBase.EBoneControlSpace)));
		bIsShimmying = false;
		bIsTurning = false;
	}
	
	public virtual /*simulated function */void InitSwingSound()
	{
		if(SwingSoundComponent == default)
		{
			SwingSoundComponent = PawnOwner.CreateAudioComponent(SwingSound, false, true, default(bool), default(Object.Vector), default(bool));
		}
		if(SwingSoundComponent != default)
		{
			SwingSoundComponent.bUseOwnerLocation = true;
			SwingSoundComponent.bAllowSpatialization = true;
			SwingSoundComponent.bAutoDestroy = true;
			PawnOwner.AttachComponent(SwingSoundComponent);
			SwingSoundComponent.FadeIn(0.20f, 1.0f);
		}
	}
	
	public virtual /*simulated function */void StopSwingSound()
	{
		if(SwingSoundComponent != default)
		{
			SwingSoundComponent.FadeOut(0.70f, 0.0f);
		}
	}
	
	public virtual /*simulated function */void EnableSwingControl()
	{
		if(PawnOwner.SwingControl1p != default)
		{
			PawnOwner.SwingControl1p.SetSkelControlStrength(1.0f, AnimBlendTime);
		}
		PawnOwner.SwingControl3p.SetSkelControlStrength(1.0f, AnimBlendTime);
	}
	
	public virtual /*simulated function */void DisableSwingControl()
	{
		if(PawnOwner.SwingControl1p != default)
		{
			PawnOwner.SwingControl1p.SetSkelControlStrength(0.0f, 0.250f);
		}
		PawnOwner.SwingControl3p.SetSkelControlStrength(0.0f, 0.40f);
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		/*local */bool MoveLeft = default, MoveRight = default;
		/*local */float JumpAngle = default;
	
		MoveLeft = (((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) || ((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/);
		MoveRight = (((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyRight/*14*/)) || ((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyRightLong/*15*/);
		if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
		{
			JumpAngle = FMin(3.1415930f / 2.0f, SwingAngle - SwingAngleTimingOffset);
			if(JumpAngle > -3.1415930f / 4.0f)
			{
				JumpOff(JumpAngle);
			}		
		}
		else
		{
			if(!bIsInterpolatingInto && ((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
			{
				LetGo();			
			}
			else
			{
				if(((!bIsInterpolatingInto && !bIsTurning) && !bIsShimmying) && ((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
				{
					bIsTurning = true;				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/))
					{
						JumpAngle = FMin(3.1415930f / 2.0f, SwingAngle - SwingAngleTimingOffset);
						if(JumpAngle > -3.1415930f / 4.0f)
						{
							PawnOwner.SetMove(TdPawn.EMovement.MOVE_MeleeAir/*32*/, false, true);
						}					
					}
					else
					{
						if(((!bIsTurning && !bIsShimmying) && MoveLeft || MoveRight) && !Volume.bSnapToCenter)
						{
							if((Abs(SwingVelocity) < 1.0f) && Abs(SwingAngle) < (3.1415930f / ((float)(8))))
							{
								if(CanShimmy((MoveRight) ? 1.0f : -1.0f))
								{
									bIsShimmying = true;
									ShimmyVelocity = 35.0f * ((MoveRight) ? 1.0f : -1.0f);
									PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("SwingStrafe")), ((MoveRight) ? 1.0f : -1.0f), 0.20f, 0.20f, false, default(bool));
									CustomAnimNode = ((PawnOwner.GetCustomAnimation(TdPawn.CustomNodeType.CNT_FullBody/*2*/)) as TdAnimNodeSequence);
									ShimmyTime = Abs(CustomAnimNode.GetAnimPlaybackLength());
								}
							}
						}
					}
				}
			}
		}
	}
	
	public virtual /*simulated function */void StopInterpolating()
	{
		bIsInterpolatingInto = false;
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.UseRootRotation(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("Swing180")), 1.0f, 0.20f, 0.30f, default(bool), true);
		PawnOwner.SetRotation(((Rotator)(SwingDirection)));
		SwingVelocity = 0.0f;
		SwingAngle = 0.0f;
		SetPawnRotation(SwingAngle);
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		if(bIsTurning)
		{
			bIsTurning = false;
			PawnOwner.UseRootRotation(false);
			SwingDirection = -SwingDirection;
			BarDirection = -BarDirection;
			PawnOwner.SetRotation(((Rotator)(SwingDirection)));
			PawnOwner.Controller.SetRotation(((Rotator)(SwingDirection)));
			SwingVelocity = 0.250f;
		}
	}
	
	public virtual /*simulated function */void JumpOff(float JumpAngle)
	{
		/*local */Object.Vector VelocityDirection = default;
	
		((PawnOwner.Moves[73]) as TdMove_SwingJump).TargetVolume = CheckForTargetVolume(vect(0.0f, 0.0f, 0.0f));
		if(((PawnOwner.Moves[73]) as TdMove_SwingJump).TargetVolume == default)
		{
			VelocityDirection = Cross(BarDirection, Normal(SwingLocation - PawnOwner.Location));
			PawnOwner.Velocity = (VelocityDirection * Cos(JumpAngle)) * ExitVelocityModifier;
			PawnOwner.Acceleration = PawnOwner.Velocity;
			PawnOwner.GravityModifier = SwingExitGravityModifier;
			PawnOwner.GravityModifierTimer = SwingExitGravityModifierTime;
			PawnOwner.AIAimOldMovementState = TdPawn.EMovement.MOVE_Walking/*1*/;
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("SwingJumpOff")), 1.0f, 0.20f, 0.20f, false, default(bool));
		}
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_SwingJump/*73*/, default(bool), default(bool));
	}
	
	public virtual /*simulated function */void LetGo()
	{
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("SwingEnd")), 1.0f, 0.20f, 0.20f, false, default(bool));
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool), default(bool));
	}
	
	public virtual /*simulated event */void SetPawnRotation(float RadAngle)
	{
		/*local */int UnAngle = default;
		/*local */Object.Vector Offset = default;
	
		PawnOwner.CustomSoundInput = 500.0f * Abs(SwingVelocity);
		UnAngle = ((int)((2.0f * (RadAngle / 3.1415930f)) * 16384.0f));
		Offset.X = Sin(RadAngle) * 94.0f;
		Offset.Z = (1.0f - Cos(RadAngle)) * 94.0f;
		if(PawnOwner.SwingControl1p != default)
		{
			PawnOwner.SwingControl1p.BoneRotation.Roll = ((int)(-((float)(UnAngle))));
			PawnOwner.SwingControl1p.BoneTranslation = Offset;
		}
		PawnOwner.SwingControl3p.BoneRotation.Roll = -UnAngle;
		PawnOwner.SwingControl3p.BoneTranslation = Offset;
	}
	
	public virtual /*simulated event */void AbortShimmy()
	{
		bIsShimmying = false;
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.250f);
	}
	
	public override /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
		if(PawnOwner.Moves[2].CanDoMove())
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool), default(bool));
		}
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		return false;
	}
	
	public TdMove_Swing()
	{
		// Object Offset:0x005E748B
		MaxSwingVelocity = 4.250f;
		ExitVelocityModifier = 600.0f;
		SwingPendulumLength = 120.0f;
		SwingAngleTimingOffset = 1.0f;
		SwingExitGravityModifier = 0.750f;
		SwingExitGravityModifierTime = 0.70f;
		SwingSound = LoadAsset<SoundCue>("A_Character_Female_01.Swing.Swing")/*Ref SoundCue'A_Character_Female_01.Swing.Swing'*/;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerGrabbing";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bShouldHolsterWeapon = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 200.0f,
			Medium = 200.0f,
			Hard = 200.0f,
		};
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		FirstPersonDPG = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableLookTime = -1.0f;
		AnimBlendTime = 0.150f;
	}
}
}