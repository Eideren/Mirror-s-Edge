namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Falling : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(StickyAim)*/ /*config */float StickyAimAfterAirTime;
	public float AirTime;
	public bool bCloseToGround;
	public TdPawn.EMovement PreviousMove;
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector StandLocation = default;
	
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_SkillRoll/*91*/)) && PawnOwner.Moves[((int)PawnOwner.MovementState)].MoveActiveTime < 0.80f)
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Crouch/*15*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Slide/*16*/))
		{
			StandLocation = PawnOwner.Location;
			StandLocation.Z += 34.0f;
			if(!CanStand(StandLocation, default(bool)))
			{
				return false;
			}
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		Reset();
		base.StartReplicatedMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		Reset();
		base.StartMove();
		PreviousMove = ((TdPawn.EMovement)PawnOwner.OldMovementState);
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			if((Dot(((Vector)(PawnOwner.Rotation)), PawnOwner.Velocity)) < 0.0f)
			{
				if(CanStand(PawnOwner.Location - ((vect(0.0f, 0.0f, 1.0f) * PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight) * 2.0f), true))
				{
					PawnOwner.Velocity.X = 0.0f;
					PawnOwner.Velocity.Y = 0.0f;
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpStill")), 1.0f, 0.30f, 0.20f, default(bool), default(bool));
				}			
			}
			else
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpAir")), 1.0f, 0.30f, 0.20f, default(bool), default(bool));
			}		
		}
		else
		{
			if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallClimbing/*6*/))
			{
				ResetCameraLook(0.50f);			
			}
			else
			{
				if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_DodgeJump/*33*/))
				{
					PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_DodgeJump/*33*/, default(float));
				}
			}
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */TdPlayerController TdPC = default;
	
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		TdPC = ((PawnOwner.Controller) as TdPlayerController);
		if(TdPC != default)
		{
			UpdateMeleeAutoLockOn(TdPC, DeltaTime, out_Rotation, ref/*probably?*/ DeltaRot);
		}
	}
	
	public override /*simulated function */void StopReplicatedMove()
	{
		base.StopReplicatedMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
	}
	
	public override /*simulated function */void StopMove()
	{
		if(((int)PawnOwner.OldMovementState) != ((int)TdPawn.EMovement.MOVE_DodgeJump/*33*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
		}
		base.StopMove();
	}
	
	public virtual /*simulated function */void Reset()
	{
		AirTime = 0.0f;
		bCloseToGround = false;
	}
	
	public virtual /*simulated event */void CloseToGround()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.30f);
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float));
		return base.HandleDeath(Damage);
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_Falling()
	{
		// Object Offset:0x005B6CC6
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckExitToUncontrolledFalling = true;
		bCheckForSoftLanding = true;
		bTwoHandedFullBodyAnimations = true;
		AnimBlendTime = 0.20f;
	}
}
}