namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_LayOnGround : TdPhysicsMove/*
		config(PawnMovement)*/{
	public bool bIsGettingUpFromGround;
	public bool bIsDoingBackRoll;
	
	public override /*function */bool CanDoMove()
	{
		return base.CanDoMove();
	}
	
	public virtual /*function */bool IsGettingUp()
	{
		return bIsGettingUpFromGround;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		bIsGettingUpFromGround = false;
		bIsDoingBackRoll = false;
		if(((((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Down/*4*/)) && ((int)PawnOwner.GetWeaponType()) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && !((PawnOwner) as TdPlayerPawn).bStuckOnGround)
		{
			GetUpBack();
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		AimMode = TdPawn.MoveAimMode.MAM_Right/*1*/;
		PawnOwner.UseRootMotion(false);
		bIsGettingUpFromGround = false;
		bIsDoingBackRoll = false;
		MovementGroup = ((TdMove.EMovementGroup)ClassT<TdMove_LayOnGround>().DefaultAs<TdMove>().MovementGroup);
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		if(IsGettingUp())
		{
			return PawnOwner.Health - 1;
		}
		return base.HandleDeath(Damage);
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		if(((PawnOwner.TaserDamageLevel > 0.0f) || ((PawnOwner) as TdPlayerPawn).bStuckOnGround))
		{
			return;
		}
		if(((((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/)) || ((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/)))
		{
			if(CanStand(PawnOwner.Location + vect(0.0f, 0.0f, 30.0f), default(bool?)))
			{
				GetUp();			
			}
			else
			{
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default(bool?), default(bool?));
				return;
			}		
		}
		else
		{
			if((((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Down/*4*/)) && ((int)PawnOwner.GetWeaponType()) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
			{
				GetUpBack();
			}
		}
	}
	
	public virtual /*simulated function */void GetUp()
	{
		if(!bIsGettingUpFromGround)
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpTurnLandingStand")), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, 0.20f);
			bIsGettingUpFromGround = true;
			ResetCameraLook(1.0f);
			StopWeaponHandling();
		}
	}
	
	public virtual /*simulated function */void GetUpBack()
	{
		/*local */Object.Vector LookAtPoint = default;
		/*local */TdPlayerPawn TdPP = default;
	
		if(!bIsGettingUpFromGround)
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("EvadeRoll")), 1.0f, 0.20f, 0.20f, true, default(bool?));
			PawnOwner.UseRootMotion(true);
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, 0.20f);
			bIsGettingUpFromGround = true;
			bIsDoingBackRoll = true;
			ResetCameraLook(1.0f);
			StopWeaponHandling();
			LookAtPoint = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * ((float)(1000)));
			LookAtPoint.Z -= ((float)(300));
			SetLookAtTargetLocation(LookAtPoint, 0.40f, default(float?));
			TdPP = ((PawnOwner) as TdPlayerPawn);
			if(TdPP != default)
			{
				TdPP.StartStringableMove(Class);
			}
		}
	}
	
	public virtual /*simulated function */void StopWeaponHandling()
	{
		/*local */TdPlayerController PlayerController = default;
	
		AimMode = TdPawn.MoveAimMode.MAM_NoHands/*3*/;
		PlayerController = ((PawnOwner.Controller) as TdPlayerController);
		if(PlayerController != default)
		{
			PlayerController.StopFire(default(byte?));
		}
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy/*2*/;
		PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		if(bIsGettingUpFromGround)
		{
			bIsGettingUpFromGround = false;
			if(CanStand(PawnOwner.Location + vect(0.0f, 0.0f, 30.0f), default(bool?)))
			{
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));			
			}
			else
			{
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default(bool?), default(bool?));
			}
		}
	}
	
	public override /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default, PawnRotation = default;
	
		PawnRootLocation = PawnOwner.Location;
		PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		PawnRotation = Normal(((Vector)(PawnOwner.Rotation)));
		PawnRotation.Z = 0.0f;
		return PawnRootLocation - (PawnRotation * 50.0f);
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		if(bIsGettingUpFromGround)
		{
			return false;
		}
		return true;
	}
	
	public TdMove_LayOnGround()
	{
		// Object Offset:0x005CA4EE
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerGrabbing";
		FrictionModifier = 0.150f;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bAvoidLedges = false;
		bUseCustomCollision = true;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
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
		SwanNeckEnableAtPitch = 0;
		SwanNeckForward = 0.0f;
		SwanNeckDown = 0.0f;
	}
}
}