namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallrunJump : TdPhysicsMove/*
		config(PawnMovement)*/{
	[Category("WallRunJump")] [config] public float WallRunningPushAwaySpeedNoob;
	[Category("WallRunJump")] [config] public float WallRunningPushAwaySpeedProAdd;
	[Category("WallRunJump")] [config] public float WallRunningPushForwardSpeedMin;
	[Category("WallRunJump")] [config] public float WallRunningJumpOffZHeightForward;
	[Category("WallRunJump")] [config] public float WallRunningJumpOffZHeightMaxAddTurned;
	public float WallRunningJumpOffZSpeed;
	public int MinContraintWorld;
	public int MaxContraintWorld;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector WallProjVelocity = default, SavedFloor = default, wallRunDir2D = default, camrotDir2D = default, Start = default, End = default,
			HitLocation = default, HitNormal = default;
	
		/*local */float PushSpeed = default, Gravity = default, Speed = default, JumpHeight = default;
		/*local */Object.Rotator WallNormal = default;
	
		SavedFloor = PawnOwner.Floor;
		WallNormal = ((Rotator)(PawnOwner.Floor));
		PawnOwner.bIllegalLedgeTimer = 2.0f;
		PawnOwner.IllegalLedgeNormal = PawnOwner.Floor;
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/))
		{
			MinContraintWorld = NormalizeRotAxis(WallNormal.Yaw - 16000);
			MaxContraintWorld = NormalizeRotAxis(WallNormal.Yaw + 10000);		
		}
		else
		{
			MinContraintWorld = NormalizeRotAxis(WallNormal.Yaw - 10000);
			MaxContraintWorld = NormalizeRotAxis(WallNormal.Yaw + 16000);
		}
		base.StartMove();
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		WallProjVelocity = PawnOwner.Velocity - (SavedFloor * (Dot(PawnOwner.Velocity, SavedFloor)));
		WallProjVelocity.Z = 0.0f;
		wallRunDir2D = SavedFloor;
		wallRunDir2D.Z = 0.0f;
		wallRunDir2D = Normal(wallRunDir2D);
		if(((PawnOwner.Moves[40]) as TdMove_WallRun).bTurned90FromWall)
		{
			camrotDir2D = SavedFloor;
			PawnOwner.FaceRotationTimeLeft = 0.10f;
			PawnOwner.LegRotation = WallNormal.Yaw;
			SetLookAtTargetAngle(WallNormal, 0.10f, default(float?));
			SetPreciseRotation(WallNormal, 0.10f);
			bDisableControllerFacingPawnYawRotation = true;		
		}
		else
		{
			camrotDir2D = ((Vector)(PawnOwner.Controller.Rotation));
		}
		camrotDir2D.Z = 0.0f;
		camrotDir2D = Normal(camrotDir2D);
		PushSpeed = Dot(wallRunDir2D, camrotDir2D);
		FMax(0.0f, PushSpeed);
		JumpHeight = WallRunningJumpOffZHeightForward + (PushSpeed * WallRunningJumpOffZHeightMaxAddTurned);
		Start = PawnOwner.Location;
		End = Start;
		End.Z += JumpHeight;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, End, Start, PawnOwner.GetCollisionExtent(), default(bool)))
		{
			JumpHeight = HitLocation.Z - PawnOwner.Location.Z;
		}
		Gravity = Abs(PawnOwner.GetGravityZ());
		Speed = (Gravity * 2.0f) * Sqrt(JumpHeight / Gravity);
		Speed *= (1.0f / ((float)(1 + ((PawnOwner.Moves[40]) as TdMove_WallRun).ConsequtiveWallruns)));
		WallRunningJumpOffZSpeed = FMax(Speed, 10.0f);
		PawnOwner.Velocity.Z = Speed;
		PawnOwner.Velocity.X = SavedFloor.X * (WallRunningPushAwaySpeedNoob + (WallRunningPushAwaySpeedProAdd * PushSpeed));
		PawnOwner.Velocity.Y = SavedFloor.Y * (WallRunningPushAwaySpeedNoob + (WallRunningPushAwaySpeedProAdd * PushSpeed));
		PawnOwner.Velocity += (WallProjVelocity * (WallRunningPushForwardSpeedMin + ((((float)(1)) - WallRunningPushForwardSpeedMin) * (((float)(1)) - PushSpeed))));
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		if(PushSpeed > 0.60f)
		{
			if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/))
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("WallrunJumpLeft")), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));			
			}
			else
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("WallrunJumpRight")), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
			}		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpSlow")), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
		}
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Jump/*11*/, default(float?));
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return true;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if((((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_Falling/*2*/)) && ((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
		}
	}
	
	public override /*simulated function */int GetMinLookConstrainYaw()
	{
		return MinContraintWorld;
	}
	
	public override /*simulated function */int GetMaxLookConstrainYaw()
	{
		return MaxContraintWorld;
	}
	
	public TdMove_WallrunJump()
	{
		// Object Offset:0x005F137B
		WallRunningPushAwaySpeedNoob = 120.0f;
		WallRunningPushAwaySpeedProAdd = 400.0f;
		WallRunningPushForwardSpeedMin = 0.10f;
		WallRunningJumpOffZHeightForward = 100.0f;
		WallRunningJumpOffZHeightMaxAddTurned = 60.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bCheckExitToFalling = true;
		bUseAbsoluteYawConstraint = true;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 75.0f,
			Medium = 75.0f,
			Hard = 75.0f,
		};
	}
}
}