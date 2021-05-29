namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_GrabJump : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(GrabJump)*/ /*config */float GrabJumpOffZHeight;
	public/*(GrabJump)*/ /*config */float GrabJumpPushAwayMaxSpeed;
	public/*(GrabJump)*/ /*config */float GrabJumpPushAwayMinSpeed;
	public/*(GrabJump)*/ /*config */float GrabAllowedJumpAngle;
	public Object.Vector JumpVelocity;
	public bool TurnedLeft;
	public /*transient */int DeltaJumpYaw;
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Rotator ControllerRotation = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		ControllerRotation = Normalize(PawnOwner.Rotation - PawnOwner.Controller.Rotation);
		if(Abs(((float)(ControllerRotation.Yaw))) < ((((float)(32768)) * GrabAllowedJumpAngle) / 180.0f))
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/)) && ((PawnOwner.Moves[3]) as TdMove_Grab).IsHangingFree())
		{
			return false;
		}
		return (((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Climb/*21*/);
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector camDir = default;
		/*local */float Interp = default, JumpHeight = default, Gravity = default, Speed = default;
		/*local */Object.Vector Start = default, End = default, HitLocation = default, HitNormal = default;
		/*local */Object.Rotator DeltaRot = default;
	
		base.StartMove();
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		camDir = ((Vector)(PawnOwner.Controller.Rotation));
		camDir.Z = 0.0f;
		camDir = Normal(camDir);
		TurnedLeft = Cross(camDir, ((Vector)(PawnOwner.Rotation))).Z > 0.0f;
		Interp = FMax(Dot(camDir, PawnOwner.MoveNormal), 0.0f);
		Interp = (Interp * GrabJumpPushAwayMaxSpeed) + ((((float)(1)) - Interp) * GrabJumpPushAwayMinSpeed);
		JumpHeight = GrabJumpOffZHeight;
		Start = PawnOwner.Location;
		End = Start;
		End.Z += JumpHeight;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, End, Start, PawnOwner.GetCollisionExtent(), default))
		{
			JumpHeight = HitLocation.Z - PawnOwner.Location.Z;
		}
		Gravity = Abs(PawnOwner.GetGravityZ());
		Speed = (Gravity * 2.0f) * Sqrt(JumpHeight / Gravity);
		JumpVelocity = camDir * Interp;
		JumpVelocity.Z = Speed;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("HangTurnJump")), 1.0f, 0.20f, 0.20f, default, default);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Grabbing/*3*/, default);
		bDisableFaceRotation = true;
		SetTimer(0.10f);
		DeltaRot = Normalize(PawnOwner.Controller.Rotation) - Normalize(PawnOwner.Rotation);
		DeltaJumpYaw = NormalizeRotAxis(DeltaRot.Yaw);
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.Velocity = JumpVelocity;
		PawnOwner.FaceRotationTimeLeft = 0.30f;
		PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
		bDisableFaceRotation = false;
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */TdPlayerController PlayerController = default;
	
		if((MoveActiveTime < 0.050f) && ((DeltaRot.Yaw > 300) && DeltaJumpYaw >= 27000) || (DeltaRot.Yaw < -300) && DeltaJumpYaw < -27000)
		{
			PlayerController = ((PawnOwner.Controller) as TdPlayerController);
			if(PlayerController != default)
			{
				PlayerController.bRightThumbStickPassedDeadZone = false;
			}
			DeltaRot.Yaw = 0;
		}
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
	}
	
	public override /*simulated function */void StopMove()
	{
		/*local */TdPlayerController PlayerController = default;
	
		base.StopMove();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PlayerController = ((PawnOwner.Controller) as TdPlayerController);
		if(PlayerController != default)
		{
			PlayerController.bRightThumbStickPassedDeadZone = true;
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_GrabJump()
	{
		// Object Offset:0x005BC58C
		GrabJumpOffZHeight = 160.0f;
		GrabJumpPushAwayMaxSpeed = 400.0f;
		GrabJumpPushAwayMinSpeed = 200.0f;
		GrabAllowedJumpAngle = 45.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckExitToFalling = true;
		bDelayTimeCheckAutoMoves = 0.20f;
		bDisableFaceRotation = true;
	}
}
}