namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallClimbDodgeJump : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(WallClimbDodgeJump)*/ /*config */float BaseJumpZ;
	public/*(WallClimbDodgeJump)*/ /*config */float JumpAddXY;
	public/*(WallClimbDodgeJump)*/ /*config */float DodgeJumpInertiaConservation;
	public/*(WallClimbDodgeJump)*/ /*config */float JumpBlendInTime;
	public/*(WallClimbDodgeJump)*/ /*config */float JumpBlendOutTime;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallClimbing/*6*/)) && (((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Right/*2*/)) || ((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/))
		{
			return true;
		}
		return false;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector DodgeDirection = default;
	
		base.StartMove();
		if(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/))
		{
			DodgeDirection = (((float)(-1)) * JumpAddXY) * Normal(Cross(vect(0.0f, 0.0f, 1.0f), ((Vector)(PawnOwner.Rotation))));		
		}
		else
		{
			DodgeDirection = JumpAddXY * Normal(Cross(vect(0.0f, 0.0f, 1.0f), ((Vector)(PawnOwner.Rotation))));
		}
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpSlow")), 1.0f, JumpBlendInTime, JumpBlendOutTime, default(bool), default(bool));
		SetLookAtTargetAngle(((Rotator)(DodgeDirection)), 0.10f, 1.0f);
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		PawnOwner.Velocity = DodgeDirection + (DodgeJumpInertiaConservation * PawnOwner.Velocity);
		PawnOwner.Velocity.Z = BaseJumpZ;
		if(((PawnOwner.Base != default) && !PawnOwner.Base.bWorldGeometry) && PawnOwner.Base.Velocity.Z > 0.0f)
		{
			PawnOwner.Velocity.Z += PawnOwner.Base.Velocity.Z;
		}
		bCheckForGrab = false;
		bCheckForVaultOver = false;
		bCheckForWallClimb = false;
		SetTimer(0.50f);
	}
	
	public override /*simulated function */void OnTimer()
	{
		bCheckForGrab = DefaultAs<TdPhysicsMove>().bCheckForGrab;
		bCheckForVaultOver = DefaultAs<TdPhysicsMove>().bCheckForVaultOver;
		bCheckForWallClimb = DefaultAs<TdPhysicsMove>().bCheckForWallClimb;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
	}
	
	public TdMove_WallClimbDodgeJump()
	{
		// Object Offset:0x005ECB7A
		BaseJumpZ = 700.0f;
		JumpAddXY = 150.0f;
		DodgeJumpInertiaConservation = 1.0f;
		JumpBlendInTime = 0.20f;
		JumpBlendOutTime = 0.20f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bCheckExitToFalling = true;
		bTriggersCompliment = true;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 75.0f,
			Medium = 75.0f,
			Hard = 75.0f,
		};
		AimMode = TdPawn.MoveAimMode.MAM_Right;
	}
}
}