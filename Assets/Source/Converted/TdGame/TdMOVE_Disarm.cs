namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMOVE_Disarm : TdPhysicsMove/*
		config(PawnMovement)*/{
	public TdPawn DisarmedPawn;
	public TdAIController.EDisarmState DisarmState;
	public Core.ClassT<Inventory> WeaponClass;
	public TdWeapon DisarmedWeapon;
	public float DisarmOffset;
	public name DisarmAnim;
	public Object.Vector TargetLocation;
	public Object.Rotator TargetRotation;
	public bool bMoveEnemy;
	public bool bForceMiss;
	public /*protected */ForceFeedbackWaveform DisarmWaveform;
	
	public override /*function */bool CanDoMove()
	{
		/*local */TdPlayerController myController = default;
		/*local */TdAIController DisarmedController = default;
	
		myController = ((PawnOwner.Controller) as TdPlayerController);
		if((((!base.CanDoMove() || PawnOwner.Weapon != default)) || myController == default))
		{
			return false;
		}
		if(bForceMiss)
		{
			return true;
		}
		if(((myController.TargetPawn == default) || myController.TargetPawn.Controller == default))
		{
			return false;
		}
		DisarmedPawn = myController.TargetPawn;
		DisarmedController = ((DisarmedPawn.Controller) as TdAIController);
		if(Abs(DisarmedPawn.Location.Z - PawnOwner.Location.Z) > 70.0f)
		{
			return false;
		}
		if(MovementTraceForBlockingBetweenActors(DisarmedPawn.Location, PawnOwner.Location))
		{
			return false;
		}
		if(DisarmedController == default)
		{
			return false;
		}
		DisarmState = ((TdAIController.EDisarmState)DisarmedController.QueryDisarmState(PawnOwner));
		return ((int)DisarmState) != ((int)TdAIController.EDisarmState.DS_NotPossible/*0*/);
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector ToDisarmedPawn = default;
		/*local */Object.Rotator YawOffset = default;
	
		base.StartMove();
		if((bForceMiss || ((int)DisarmState) == ((int)TdAIController.EDisarmState.DS_Miss/*1*/)))
		{
			TargetLocation = PawnOwner.Location;
			TargetRotation = PawnOwner.Rotation;
			StartMiss();
			ForceMiss(false);
			return;
		}
		if(PawnOwner.Controller.IsA("TdPlayerController"))
		{
			((PawnOwner.Controller) as TdPlayerController).TargetingPawn = DisarmedPawn;
		}
		PawnOwner.StopPhysicsBodyImpact();
		ResetCameraLook(0.20f);
		PawnOwner.WeaponPoseOffset1p.bDisable = true;
		ToDisarmedPawn = DisarmedPawn.Location - PawnOwner.Location;
		ToDisarmedPawn.Z = 0.0f;
		ToDisarmedPawn = Normal(ToDisarmedPawn);
		YawOffset.Yaw = Normalize(DisarmedPawn.Rotation - ((Rotator)(ToDisarmedPawn))).Yaw;
		ChooseDisarmType(ref/*probably?*/ YawOffset);
		if(!((DisarmedPawn.Controller) as TdAIController).StartCannedMove(36))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
			return;
		}
		bMoveEnemy = false;
		TargetLocation = DisarmedPawn.Location - (ToDisarmedPawn * DisarmOffset);
		TargetRotation = ((Rotator)(ToDisarmedPawn));
		TargetRotation.Pitch = 0;
		if(Abs(TargetLocation.Z - PawnOwner.Location.Z) > 3.0f)
		{
			HandleHeightDifference(YawOffset);		
		}
		else
		{
			if(MovementTraceForBlocking(PawnOwner.Location + (vect(0.0f, 0.0f, 1.0f) * PawnOwner.MaxStepHeight), TargetLocation + (vect(0.0f, 0.0f, 1.0f) * PawnOwner.MaxStepHeight), PawnOwner.GetCollisionExtent()))
			{
				HandlePlayerUnableToMove(YawOffset);			
			}
			else
			{
				AlignPawn();
				((DisarmedPawn.Moves[36]) as TdMove_Disarmed).SetLookAtDirection(Normalize(TargetRotation + YawOffset));
			}
		}
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		DisarmedPawn.Velocity = vect(0.0f, 0.0f, 0.0f);
		DisarmedPawn.Acceleration = vect(0.0f, 0.0f, 0.0f);
		if(DisarmAnim != "SnatchBack")
		{
			PawnOwner.OnTutorialEvent(23);
		}
		PlayDisarmStart();
	}
	
	public virtual /*function */void HandlePlayerUnableToMove(Object.Rotator YawOffset)
	{
		/*local */TdMove_Disarmed DisarmedMove = default;
		/*local */Object.Vector DisarmedTargetLocation = default;
	
		DisarmedMove = ((DisarmedPawn.Moves[36]) as TdMove_Disarmed);
		if(DisarmedMove != default)
		{
			bMoveEnemy = true;
			DisarmedTargetLocation = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * DisarmOffset);
			DisarmedMove.SetPreciseLocation(DisarmedTargetLocation, TdMove.EPreciseLocationMode.PLM_Walk/*1*/, 300.0f);
			DisarmedMove.SetLookAtDirection(Normalize(TargetRotation + YawOffset));
		}
	}
	
	public virtual /*function */void HandleHeightDifference(Object.Rotator YawOffset)
	{
		/*local */TdMove_Disarmed DisarmedMove = default;
		/*local */Object.Vector DisarmedTargetLocation = default;
	
		DisarmedMove = ((DisarmedPawn.Moves[36]) as TdMove_Disarmed);
		if(DisarmedPawn.Location.Z > PawnOwner.Location.Z)
		{
			TargetLocation = DisarmedPawn.Location - (((Vector)(DisarmedPawn.Rotation + YawOffset)) * DisarmOffset);
			PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
			SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, 300.0f);		
		}
		else
		{
			bMoveEnemy = true;
			DisarmedTargetLocation = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * DisarmOffset);
			DisarmedMove.SetPreciseLocation(DisarmedTargetLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, 300.0f);
			DisarmedMove.SetLookAtDirection(Normalize(TargetRotation + YawOffset));
		}
	}
	
	public virtual /*function */void AlignPawn()
	{
		SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Walk/*1*/, ((float)(Max(400, ((int)(VSize2D(PawnOwner.Velocity)))))));
	}
	
	public virtual /*function */void ForceMiss(bool bMiss)
	{
		bForceMiss = bMiss;
	}
	
	public virtual /*function */void StartMiss()
	{
		/*local */TdPlayerPawn PlayerPawn = default;
	
		PlayerPawn = ((PawnOwner) as TdPlayerPawn);
		if(PlayerPawn != default)
		{
			PlayerPawn.SetFirstPersonDPG(Scene.ESceneDepthPriorityGroup.SDPG_Foreground/*3*/);
		}
		PawnOwner.UseRootMotion(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "SnatchFail", 1.0f, 0.10f, 0.40f, true, default(bool?));
	}
	
	public virtual /*function */void ChooseDisarmType(ref Object.Rotator YawOffset)
	{
		if((Dot(((Vector)(PawnOwner.Rotation)), ((Vector)(DisarmedPawn.Rotation)))) <= 0.0f)
		{
			YawOffset.Yaw = 32768;
			DisarmOffset = 125.8990f;
			if(DisarmedPawn.IsA("TdBotPawn_PatrolCop") && DisarmedPawn.Weapon.IsA("TdWeapon_Light"))
			{
				if(DisarmedPawn.Weapon.IsA("TdWeapon_SMG_SteyrTMP"))
				{
					switch(Rand(2))
					{
						case 0:
							DisarmAnim = "SnatchFwd2";
							break;
						case 1:
							DisarmAnim = "SnatchFwd3";
							break;
						default:
							break;
					}				
				}
				else
				{
					switch(Rand(3))
					{
						case 0:
							DisarmAnim = "SnatchFwd";
							break;
						case 1:
							DisarmAnim = "SnatchFwd2";
							break;
						case 2:
							DisarmAnim = "SnatchFwd3";
							break;
						default:
							break;
					}
				}			
			}
			else
			{
				DisarmAnim = "SnatchFwd";
			}		
		}
		else
		{
			YawOffset.Yaw = 0;
			DisarmOffset = 125.8990f;
			DisarmAnim = "SnatchBack";
		}
	}
	
	public virtual /*function */void TakeDisarmedPawnsWeapon()
	{
		WeaponClass = DisarmedPawn.Weapon.Class;
		if(WeaponClass != default)
		{
			if(((WeaponClass) as ClassT<TdWeapon_Pistol_Taser>) != default)
			{
				DisarmedWeapon = DisarmedPawn.MyWeapon;			
			}
			else
			{
				DisarmedWeapon = ((PawnOwner.InvManager.CreateInventory(WeaponClass, true)) as TdWeapon);
				DisarmedWeapon.ClipCount = 0;
				DisarmedWeapon.AmmoCount = ((DisarmedPawn) as TdBotPawn).MainWeaponAmmo_Disarmed;
			}
			PawnOwner.UpdateAnimSets(DisarmedWeapon);
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(((DisarmedWeapon != default) && ((int)DisarmState) != ((int)TdAIController.EDisarmState.DS_Miss/*1*/)) && ((WeaponClass) as ClassT<TdWeapon_Pistol_Taser>) == default)
		{
			((PawnOwner.InvManager) as TdInventoryManager).SetCurrentWeapon(DisarmedWeapon);
			if(!DisarmedWeapon.IsA("TdWeapon_Shotgun_Remington870") && !DisarmedWeapon.IsA("TdWeapon_Shotgun_Neostead"))
			{
				PawnOwner.AttachWeaponToHand(DisarmedWeapon);
			}
		}
		if(((WeaponClass) as ClassT<TdWeapon_Pistol_Taser>) != default)
		{
			PawnOwner.UpdateAnimSets(default(TdWeapon?));
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);
		}
		PawnOwner.WeaponPoseOffset1p.bDisable = false;
		DisarmedPawn = default;
		DisarmedWeapon = default;
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if(PawnOwner.Controller.IsA("TdPlayerController"))
		{
			UpdateMeleeAutoLockOn(((PawnOwner.Controller) as TdPlayerController), DeltaTime, out_Rotation, ref/*probably?*/ DeltaRot);
		}
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.SetLocation(TargetLocation);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		return;
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		AbortDisarm();
	}
	
	public virtual /*function */void PlayDisarmStart()
	{
		TakeDisarmedPawnsWeapon();
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, DisarmAnim, 1.0f, 0.10f, ((DisarmedWeapon == default) ? 0.20f : 0.0f), default(bool?), default(bool?));
		((DisarmedPawn.Controller) as TdAIController).TriggerCannedAnim(36, DisarmAnim);
		if((DisarmedWeapon != default) && DisarmedWeapon.IsA("TdWeapon_Shotgun_Remington870"))
		{
			SetTimer(0.80f);
		}
		if((DisarmedWeapon != default) && DisarmedWeapon.IsA("TdWeapon_Shotgun_Neostead"))
		{
			SetTimer(1.40f);
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.AttachWeaponToHand(DisarmedWeapon);
	}
	
	public virtual /*function */void AbortDisarm()
	{
		((DisarmedPawn.Moves[36]) as TdMove_Disarmed).AbortDisarm();
		PawnOwner.RemoveWeaponAfterDrop();
		DisarmedWeapon = default;
		PawnOwner.UpdateAnimSets(default);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, 0.20f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void MoveRumbleNotify()
	{
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(DisarmWaveform);
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMOVE_Disarm()
	{
		var Default__TdMOVE_Disarm_DisarmWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C3EE
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 40,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMOVE_Disarm.DisarmWaveformObj' */;
		// Object Offset:0x005B228D
		DisarmOffset = 109.9020f;
		DisarmWaveform = Default__TdMOVE_Disarm_DisarmWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMOVE_Disarm.DisarmWaveformObj'*/;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.010f,
			Medium = 0.080f,
			Hard = 0.30f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 200.0f,
			Medium = 200.0f,
			Hard = 200.0f,
		};
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		FirstPersonDPG = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
		RedoMoveTime = 0.20f;
	}
}
}