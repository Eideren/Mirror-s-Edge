namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Stumble : TdMove_StumbleBase/*
		config(PawnMovement)*/{
	public enum EStumbleStage 
	{
		StumbleStage_One,
		StumbleStage_Two,
		StumbleStage_Three,
		StumbleStage_MAX
	};
	
	public TdMove_Stumble.EStumbleStage stage;
	public TdPawn.EWeaponAnimState PrevWeaponAnimState;
	public bool bInAir;
	
	public override /*simulated function */bool CanDoMove()
	{
		if(((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Crouch/*15*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_MeleeCrouch/*63*/)) && CanStand(PawnOwner.Location + vect(0.0f, 0.0f, 30.0f), default(bool)))
		{
			return true;
		}
		if(PawnOwner.Moves[((int)PawnOwner.MovementState)].bUseCustomCollision)
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PlayStumbleAnimation();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		bInAir = false;
		PawnOwner.ClearTimer("UpdateFall", this);
		if(PawnOwner.Controller.IsA("TdPlayerController"))
		{
			((PawnOwner.Controller) as TdPlayerController).TargetingPawnInterp = 0.0f;
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		if(((int)PawnOwner.AnimationMovementState) != ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));		
		}
		else
		{
			if(((int)PawnOwner.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/))
			{
				Landed(vect(0.0f, 0.0f, 1.0f), default(Actor));
			}
		}
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
		if(((int)PawnOwner.AnimationMovementState) == ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
			((PawnOwner.Moves[20]) as TdMove_Landing).bForceLandBack = true;
			base.Landed(aNormal, anActor);
		}
	}
	
	public virtual /*simulated function */void PlayStumbleAnimation()
	{
		/*local */bool StumbleFar = default;
	
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		switch(StumbleState)
		{
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeFrontLeft/*3*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeFrontRight/*4*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBargeFront/*5*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeCrouchFront/*6*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeWallrunRight/*8*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeWallrunLeft/*9*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeSlideFront/*7*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeAirHeadFront/*10*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeAirBodyFront/*11*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitBarbedWireFront/*20*/:
				if(((Instigator != default) && Instigator.IsA("TdBotPawn")) && ((Instigator) as TdBotPawn).ShouldMeleeCauseFall())
				{
					PlayStumbleFall(-((Vector)(PawnOwner.Rotation)));				
				}
				else
				{
					if(bInAir)
					{
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "gethitleft", 1.0f, 0.10f, 0.20f, true, default(bool));
						PawnOwner.Velocity = ((Instigator != default) ? ((Vector)(Instigator.Rotation)) : -((Vector)(PawnOwner.Rotation))) * 300.0f;
						PawnOwner.Velocity.Z = 80.0f;					
					}
					else
					{
						PawnOwner.UseRootMotion(true);
						ResetCameraLook(0.20f);
						StumbleFar = ((Instigator != default) && Instigator.IsA("TdBotPawn")) && ((Instigator) as TdBotPawn).ShouldMeleeCauseStumbleFar();
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((StumbleFar) ? "GetHitStumbleBwdFar" : "GetHitStumbleBwd"), 1.0f, 0.10f, 0.20f, true, default(bool));
						SetTimer(((StumbleFar) ? 0.80f : 0.50f));
						if(PawnOwner.Weapon != default)
						{
							PrevWeaponAnimState = ((TdPawn.EWeaponAnimState)PawnOwner.WeaponAnimState);
							PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);
						}
					}
				}
				break;
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBack/*1*/:
			case TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBackHead/*2*/:
				PawnOwner.UseRootMotion(true);
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "StumbleFwd", 1.0f, 0.30f, 0.20f, true, default(bool));
				break;
			default:
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
				break;
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		/*local */TdAI_Pursuit PursuitAI = default;
	
		PursuitAI = ((((Instigator != default) ? Instigator.Controller : default)) as TdAI_Pursuit);
		if(PawnOwner.Weapon != default)
		{
			PawnOwner.SetWeaponAnimState(((TdPawn.EWeaponAnimState)PrevWeaponAnimState));
		}
		if((CurrentCustomAnimName == "GetHitStumbleBwdFar") || CurrentCustomAnimName == "GetHitStumbleBwd")
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));		
		}
		else
		{
			if(PursuitAI != default)
			{
			}
		}
	}
	
	public override /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default, PawnRotation = default;
	
		if(((int)StumbleState) != ((int)TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBack/*1*/))
		{
			PawnRootLocation = PawnOwner.Location;
			PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
			PawnRotation = Normal(((Vector)(PawnOwner.Rotation)));
			PawnRotation.Z = 0.0f;
			return PawnRootLocation - (PawnRotation * 50.0f);
		}
		return base.GetFocusLocation();
	}
	
	public virtual /*simulated function */void PlayStumbleFall(Object.Vector Direction)
	{
		/*local */Object.Vector LookAtTarget = default;
	
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_180TurnInAir/*25*/, 0.10f);
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.Velocity = Direction;
		PawnOwner.Velocity = (PawnOwner.Velocity + vect(0.0f, 0.0f, 1.0f)) * 450.0f;
		if(((int)StumbleState) == ((int)TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBack/*1*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "GetHitFallbackTurn", 1.0f, 0.10f, 0.10f, true, true);		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "GetHitFallback", 1.0f, 0.10f, 0.10f, true, true);
		}
		LookAtTarget = PawnOwner.Location - (Direction * ((float)(100)));
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		SetLookAtTargetLocation(LookAtTarget, 0.20f, 0.90f);
		PawnOwner.SetTimer(0.10f, true, "UpdateFall", this);
	}
	
	public virtual /*simulated function */void UpdateFall()
	{
		if(((int)PawnOwner.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/))
		{
			Landed(vect(0.0f, 0.0f, 1.0f), default(Actor));
		}
	}
	
	public TdMove_Stumble()
	{
		// Object Offset:0x005E3F62
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		bCheckExitToUncontrolledFalling = true;
		bShouldHolsterWeapon = true;
	}
}
}