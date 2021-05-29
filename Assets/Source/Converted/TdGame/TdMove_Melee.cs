namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Melee : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public enum EMoveMeleeType 
	{
		MT_Normal,
		MT_AtBlockingEnemy,
		MT_AtBentOverEnemy,
		MT_AtComboFinisher,
		MT_MAX
	};
	
	public /*private */bool bLeft;
	public /*private */bool bWindowOpen;
	public /*private */int ComboCounter;
	public /*private */float ComboTimer;
	public /*private */int ComboQueuedActions;
	public /*private */TdMove_Melee.EMoveMeleeType MeleeType;
	public /*config */float SoccerKickDamage;
	public float PreventTime;
	public /*config */float BlendInMissed;
	public /*config */float BlendOutMissed;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		if(PreventTime > PawnOwner.WorldInfo.TimeSeconds)
		{
			return false;
		}
		if(((int)PawnOwner.AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/))
		{
			return false;
		}
		if((PawnOwner.Weapon != default) && ((PawnOwner.Weapon) as TdWeapon_Heavy) != default)
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */float LegsBodyYawDelta = default;
	
		base.StartMove();
		Reset();
		LegsBodyYawDelta = ((float)(NormalizeRotAxis(PawnOwner.LegRotation - PawnOwner.Rotation.Yaw)));
		if((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/)) && Abs(LegsBodyYawDelta) > ((float)(4000)))
		{
			bLeft = LegsBodyYawDelta > ((float)(0));		
		}
		else
		{
			bLeft = !bLeft;
		}
		if(PawnOwner.Weapon != default)
		{
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
		}
		TriggerMove();
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		if((((int)Action) != ((int)TdPawn.EMovementAction.MA_Melee/*3*/)) || !bWindowOpen)
		{
			return;
		}
		if(ComboCounter < 2)
		{
			ComboCounter += 1;
			ComboQueuedActions += 1;
		}
	}
	
	public virtual /*simulated function */void OpenWindow(float delay)
	{
		SetTimer(delay);
		bWindowOpen = true;
	}
	
	public virtual /*simulated function */void CloseWindow()
	{
		ClearTimer();
		bWindowOpen = false;
	}
	
	public override /*simulated function */void OnTimer()
	{
		CloseWindow();
	}
	
	public virtual /*simulated function */void Reset()
	{
		ComboCounter = 0;
		ComboQueuedActions = 0;
		CloseWindow();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		Reset();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.30f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.30f);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		switch(MeleeState)
		{
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/:
				if(PawnOwner.IsLocallyControlled())
				{
					if(TestHit())
					{
						TriggerHit();					
					}
					else
					{
						TriggerMiss();
					}
				}
				break;
			case TdMove_MeleeBase.EMeleeState.MS_MeleeHitNormal/*3*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeHitFinishing/*4*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeMissNormal/*5*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeMissFinishing/*6*/:
				if(ComboQueuedActions > 0)
				{
					StartMove();
					ComboQueuedActions -= 1;
					bLeft = !bLeft;
					TriggerMove();				
				}
				else
				{
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);
				}
				break;
			default:
				break;
		}
	}
	
	public override /*simulated function */void TriggerMove()
	{
		/*local */TdMove_StumbleBase StumbleMove = default;
	
		base.TriggerMove();
		OpenWindow(0.330f);
		bTargeting = true;
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Camera/*6*/, 0.050f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default);
		if(TargetPawn != default)
		{
			StumbleMove = ((TargetPawn.Moves[35]) as TdMove_StumbleBase);
		}
		if((((TargetPawn != default) && ((int)TargetPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Stumble/*35*/)) && TargetPawn.IsA("TdBotPawn_Assault") || TargetPawn.IsA("TdBotPawn_PatrolCop")) && (((int)StumbleMove.StumbleState) == ((int)TdMove_StumbleBase.EStumbleState.ESS_HitMeleeAirBodyFront/*11*/)) || ((int)StumbleMove.StumbleState) == ((int)TdMove_StumbleBase.EStumbleState.ESS_HitMeleeSlideFront/*7*/))
		{
			ResetCameraLook(0.40f);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeBentOverStart", 1.0f, 0.10f, -1.0f, default, default);
			HitDetectionBone = "RightFoot";
			bLeft = false;
			MeleeType = TdMove_Melee.EMoveMeleeType.MT_AtBentOverEnemy/*2*/;
			if(((TargetPawn) as TdBotPawn) != default)
			{
				((TargetPawn) as TdBotPawn).ActiveDeathAnimType = TdBotPawn.DeathAnimType.DAT_DeathLeft/*8*/;
			}		
		}
		else
		{
			if((ComboQueuedActions == 0) && ComboCounter == 2)
			{
				MeleeType = TdMove_Melee.EMoveMeleeType.MT_AtComboFinisher/*3*/;
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, "MeleeStartShove", 1.0f, 0.10f, -1.0f, default, default);
				PawnOwner.SetIgnoreMoveInput(1.0f);
				if(((TargetPawn) as TdBotPawn) != default)
				{
					((TargetPawn) as TdBotPawn).ActiveDeathAnimType = TdBotPawn.DeathAnimType.DAT_RagdollHard/*1*/;
				}			
			}
			else
			{
				MeleeType = TdMove_Melee.EMoveMeleeType.MT_Normal/*0*/;
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((bLeft) ? "MeleeStartLeft" : "MeleeStartRight"), 1.50f, 0.10f, -1.0f, default, default);
				if(((TargetPawn) as TdBotPawn) != default)
				{
					((TargetPawn) as TdBotPawn).ActiveDeathAnimType = ((TdBotPawn.DeathAnimType)((bLeft) ? 8 : 6));
				}
			}
			HitDetectionBone = ((bLeft) ? "LeftHand" : "RightHand");
		}
		UpdateTargetPawn();
	}
	
	public override /*simulated function */void TriggerMiss()
	{
		bTargeting = false;
		base.TriggerMiss();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default);
		switch(MeleeType)
		{
			case TdMove_Melee.EMoveMeleeType.MT_Normal/*0*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((bLeft) ? "MeleeMissedLeft" : "MeleeMissedRight"), 1.50f, BlendInMissed, ((ComboQueuedActions > 0) ? 0.60f : BlendOutMissed), default, default);
				break;
			case TdMove_Melee.EMoveMeleeType.MT_AtBlockingEnemy/*1*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((bLeft) ? "MeleeMissed2Left" : "MeleeMissed2Right"), 1.50f, BlendInMissed, ((ComboQueuedActions > 0) ? 0.60f : BlendOutMissed), default, default);
				break;
			case TdMove_Melee.EMoveMeleeType.MT_AtBentOverEnemy/*2*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeBentOverFinish", 1.0f, 0.10f, 0.10f, default, default);
				break;
			case TdMove_Melee.EMoveMeleeType.MT_AtComboFinisher/*3*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, "MeleeHitShove", 1.0f, 0.0f, 0.10f, default, default);
				Reset();
				break;
			default:
				break;
		}
		MeleeState = ((TdMove_MeleeBase.EMeleeState)((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/)) ? 5 : 6));
	}
	
	public override /*simulated function */void TriggerHit()
	{
		bTargeting = false;
		base.TriggerHit();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default);
		switch(MeleeType)
		{
			case TdMove_Melee.EMoveMeleeType.MT_Normal/*0*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((bLeft) ? "MeleeHitLeft" : "MeleeHitRight"), 1.50f, 0.20f, ((ComboQueuedActions > 0) ? 0.30f : 0.10f), default, default);
				break;
			case TdMove_Melee.EMoveMeleeType.MT_AtBlockingEnemy/*1*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((bLeft) ? "MeleeHit2Left" : "MeleeHit2Right"), 1.50f, 0.20f, ((ComboQueuedActions > 0) ? 0.30f : 0.10f), default, default);
				break;
			case TdMove_Melee.EMoveMeleeType.MT_AtBentOverEnemy/*2*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeBentOverFinish", 1.0f, 0.10f, 0.150f, default, default);
				break;
			case TdMove_Melee.EMoveMeleeType.MT_AtComboFinisher/*3*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, "MeleeHitShove", 1.0f, 0.0f, 0.10f, default, default);
				Reset();
				break;
			default:
				break;
		}
		MeleeState = ((TdMove_MeleeBase.EMeleeState)((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/)) ? 3 : 4));
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		return ((((int)MeleeType) == ((int)TdMove_Melee.EMoveMeleeType.MT_AtBentOverEnemy/*2*/)) ? ClassT<TdDmgType_MeleeSoccerKick>() : ((bLeft) ? ClassT<TdDmgType_MeleeLeft>() : ClassT<TdDmgType_MeleeRight>()));
	}
	
	public virtual /*function */bool TestHit()
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector ToTarget = default, ToTarget2d = default, HitLocation = default, ImpactMomentum = default;
		/*local */Core.ClassT<TdDamageType> DamageType = default;
	
		if(TargetPawn == default)
		{
			return false;
		}
		ToTarget = TargetPawn.Location - PawnOwner.Location;
		ToTarget2d = ToTarget;
		ToTarget2d.Z = 0.0f;
		if(((Dot(Normal(ToTarget2d), ((Vector)(PawnOwner.Rotation)))) > 0.80f) && VSize(ToTarget) < 170.0f)
		{
			ImpactMomentum = ((Vector)(PawnOwner.Rotation)) * 150.0f;
			DamageType = ((bLeft) ? ClassT<TdDmgType_MeleeLeft>() : ClassT<TdDmgType_MeleeRight>());
			Damage = MeleeDamage;
			HitLocation = PawnOwner.Mesh1p.GetBoneLocation(((bLeft) ? "LeftHand" : "RightHand"), default);
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone("Neck");
			Hit.BoneName = "Neck";
			Hit.HitComponent = TargetPawn.Mesh3p;
			switch(MeleeType)
			{
				case TdMove_Melee.EMoveMeleeType.MT_AtBentOverEnemy/*2*/:
					ImpactMomentum = ((((Vector)(PawnOwner.Rotation)) + vect(0.0f, 0.0f, 0.50f)) * 200.0f) + (VRand() * 100.0f);
					DamageType = ClassT<TdDmgType_MeleeSoccerKick>();
					Damage += 20.0f;
					break;
				case TdMove_Melee.EMoveMeleeType.MT_AtComboFinisher/*3*/:
					ImpactMomentum = ((((Vector)(PawnOwner.Rotation)) + vect(0.0f, 0.0f, 0.50f)) * 200.0f) + (VRand() * 100.0f);
					DamageType = ClassT<TdDmgType_MeleeSoccerKick>();
					Damage += 10.0f;
					break;
				default:
					break;
			}
			DeliverDamage(Damage, HitLocation, ImpactMomentum, DamageType, Hit);
			return true;
		}
		return false;
	}
	
	public TdMove_Melee()
	{
		// Object Offset:0x005CDA2D
		BlendInMissed = 0.080f;
		BlendOutMissed = 0.10f;
		TraceExtent = new Vector
		{
			X=12.0f,
			Y=12.0f,
			Z=12.0f
		};
		MeleeDamage = 33.50f;
		MeleeWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C892
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_Melee.MeleeWaveformObj' */;
		bConstrainLook = true;
		bUseCameraCollision = true;
		AimMode = TdPawn.MoveAimMode.MAM_TwoHanded;
		MinLookConstraint = new Rotator
		{
			Pitch=-10000,
			Yaw=-32768,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=10000,
			Yaw=32768,
			Roll=32768
		};
	}
}
}