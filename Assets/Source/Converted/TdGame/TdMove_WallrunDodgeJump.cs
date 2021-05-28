namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallrunDodgeJump : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(WallRunDodgeJump)*/ /*config */float BaseJumpZ;
	public/*(WallRunDodgeJump)*/ /*config */float JumpAddXY;
	public/*(WallRunDodgeJump)*/ /*config */float DodgeJumpInertiaConservation;
	public/*(WallRunDodgeJump)*/ /*config */float JumpBlendInTime;
	public/*(WallRunDodgeJump)*/ /*config */float JumpBlendOutTime;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		if(((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/)) && ((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Right/*2*/)) || (((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/)) && ((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/))
		{
			return true;
		}
		return false;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector DodgeDirection = default;
	
		base.StartMove();
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		DodgeDirection = (((((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/)) ? -1.0f : 1.0f) * JumpAddXY) * Normal(Cross(vect(0.0f, 0.0f, 1.0f), ((Vector)(PawnOwner.Rotation))));
		PawnOwner.Velocity = DodgeDirection + (DodgeJumpInertiaConservation * PawnOwner.Velocity);
		PawnOwner.Velocity.Z = BaseJumpZ;
		if(((PawnOwner.Base != default) && !PawnOwner.Base.bWorldGeometry) && PawnOwner.Base.Velocity.Z > 0.0f)
		{
			PawnOwner.Velocity.Z += PawnOwner.Base.Velocity.Z;
		}
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/)) ? ((name)("dodgejumpleft")) : ((name)("dodgejumpright"))), 1.0f, 0.20f, 0.20f, default(bool), default(bool));
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
	}
	
	public TdMove_WallrunDodgeJump()
	{
		// Object Offset:0x005F05B7
		BaseJumpZ = 300.0f;
		JumpAddXY = 600.0f;
		DodgeJumpInertiaConservation = 0.30f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckExitToFalling = true;
		bTriggersCompliment = true;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 75.0f,
			Medium = 75.0f,
			Hard = 75.0f,
		};
	}
}
}