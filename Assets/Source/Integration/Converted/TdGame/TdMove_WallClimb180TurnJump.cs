namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallClimb180TurnJump : TdPhysicsMove/*
		config(PawnMovement)*/{
	public/*(Gameplay)*/ /*config */float JumpOffZHeight;
	public/*(Gameplay)*/ /*config */float JumpPushAwaySpeed;
	public/*(Gameplay)*/ /*config */float JumpTimeWindow;
	public bool bJumpingFromWall;
	public Object.Vector WantedJumpDir;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		return ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallClimbing/*6*/);
	}
	
	public override /*simulated function */void StartMove()
	{
		WantedJumpDir = PawnOwner.Floor;
		WantedJumpDir.Z = 0.0f;
		WantedJumpDir = Normal(WantedJumpDir);
		base.StartMove();
		bJumpingFromWall = false;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "wallrunvertical180turn", 1.0f, 0.20f, 0.10f, false, true);
		PawnOwner.UseRootRotation(true);
		ResetCameraLook(0.20f);
		bCheckForGrab = false;
		bCheckForVaultOver = false;
		bCheckForWallClimb = false;
		SetTimer(JumpTimeWindow);
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.UseRootRotation(false);
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		if(((((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/)) && !bJumpingFromWall) && MoveActiveTime < JumpTimeWindow)
		{
			JumpFromWall();
		}
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return true;
	}
	
	public virtual /*simulated function */void JumpFromWall()
	{
		/*local */float JumpHeight = default, Gravity = default;
		/*local */Object.Vector Start = default, End = default, HitLocation = default, HitNormal = default;
		/*local */TdPlayerPawn PlayerPawn = default;
	
		PlayerPawn = ((PawnOwner) as TdPlayerPawn);
		if(PlayerPawn != default)
		{
			PlayerPawn.StartStringableMove(Class);
		}
		bJumpingFromWall = true;
		ResetCameraLook(0.20f);
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		JumpHeight = JumpOffZHeight;
		Start = PawnOwner.Location + (WantedJumpDir * 2.0f);
		End = Start;
		End.Z += JumpHeight;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, End, Start, PawnOwner.GetCollisionExtent(), default(bool?)))
		{
			JumpHeight = HitLocation.Z - PawnOwner.Location.Z;
		}
		Gravity = Abs(PawnOwner.GetGravityZ());
		PawnOwner.Velocity = WantedJumpDir * JumpPushAwaySpeed;
		PawnOwner.Velocity.Z = (Gravity * 2.0f) * Sqrt(JumpHeight / Gravity);
	}
	
	public override /*simulated function */void OnTimer()
	{
		/*local */Object.Rotator JumpRotation = default;
	
		if(bJumpingFromWall)
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "WallrunJumpLeft", 1.0f, 0.10f, 0.20f, default(bool?), default(bool?));
		}
		PawnOwner.UseRootRotation(false);
		JumpRotation.Pitch = PawnOwner.Controller.Rotation.Pitch;
		JumpRotation.Yaw = ((Rotator)(WantedJumpDir)).Yaw;
		SetLookAtTargetAngle(JumpRotation, 0.20f, default(float?));
		SetPreciseRotation(JumpRotation, 0.10f);
	}
	
	public override /*simulated function */void ReachedPreciseRotation()
	{
		if(bJumpingFromWall)
		{
			bCheckForGrab = DefaultAs<TdPhysicsMove>().bCheckForGrab;
			bCheckForVaultOver = DefaultAs<TdPhysicsMove>().bCheckForVaultOver;
			bCheckForWallClimb = DefaultAs<TdPhysicsMove>().bCheckForWallClimb;
		}
		PawnOwner.StopIgnoreMoveInput();
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public TdMove_WallClimb180TurnJump()
	{
		// Object Offset:0x005EC35C
		JumpOffZHeight = 250.0f;
		JumpPushAwaySpeed = 400.0f;
		JumpTimeWindow = 0.60f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bCheckExitToFalling = true;
		ExitToFallingZSpeed = -800.0f;
		bTriggersCompliment = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.60f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 100.0f,
			Medium = 100.0f,
			Hard = 100.0f,
		};
		AimMode = TdPawn.MoveAimMode.MAM_Right;
		DisableMovementTime = 0.40f;
		RedoMoveTime = 1.0f;
	}
}
}