namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_GrabTransfer : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(GrabTransfer)*/ /*config */float Allowed2DTransferDistance;
	public/*(GrabTransfer)*/ /*config */float AllowedZTransferDistance;
	public Object.Vector TransferLocation;
	public Object.Vector TransferNormal;
	public Object.Vector TransferLookAtLocation;
	public Object.Vector TransferLedgeNormal;
	public /*private */TdPawn.EMoveActionHint TransferHint;
	public TdPawn.EMovement TransferMove;
	public TdLadderVolume Ladder;
	public TdLadderVolume TransferLadder;
	public float TransferSpeed;
	public float TransferDistance;
	public /*transient */bool bFitForGrab;
	
	// Export UTdMove_GrabTransfer::execCheckContextMove(FFrame&, void* const)
	public virtual /*native function */bool CheckContextMove(ref Object.Vector out_MoveLocation, ref Object.Vector out_MoveNormal, /*optional */ref Object.Vector out_LedgeLocation/* = default*/, /*optional */ref Object.Vector out_LedgeNormal/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		/*local */bool bContextMove = default, bTransferToVault = default;
		/*local */Object.Vector Extent = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		bContextMove = CheckContextMove(ref/*probably?*/ TransferLocation, ref/*probably?*/ TransferNormal, ref/*probably?*/ TransferLookAtLocation, ref/*probably?*/ TransferLedgeNormal);
		if(!bContextMove)
		{
			return false;
		}
		Extent = PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius * vect(1.0f, 1.0f, 0.0f);
		Extent.Z = PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight;
		bFitForGrab = !MovementTraceForBlocking(TransferLocation, PawnOwner.Location, Extent);
		if(((int)TransferHint) == ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
		{
			bTransferToVault = CheckReachableVaultOver();
			if(!bFitForGrab)
			{
				return bTransferToVault;
			}
		}
		if(!bFitForGrab)
		{
			return false;
		}
		return (((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Climb/*21*/);
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		if(!bFitForGrab && ((int)TransferMove) == ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/))
		{
			PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
			PawnOwner.bCollideWorld = false;
		}
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.10f);
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		bDisableFaceRotation = true;
		TransferDistance = VSize(TransferLocation - PawnOwner.Location);
		PawnOwner.MoveLocation = TransferLocation;
		PawnOwner.MoveNormal = TransferNormal;
		PawnOwner.MoveLedgeLocation = TransferLookAtLocation;
		PawnOwner.MoveLedgeNormal = TransferLedgeNormal;
		TransferSpeed = FMax(TransferDistance / 0.550f, 200.0f);
		PawnOwner.SetAnimationMovementState(((TdPawn.EMovement)PawnOwner.OldMovementState), default(float?));
		if(((int)TransferHint) != ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
		{
			SetLookAtTargetLocation(TransferLookAtLocation, 0.20f, default(float?));
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)TransferHint) == ((int)TdPawn.EMoveActionHint.MAH_Right/*2*/)) ? "HangTurnRightStart" : "HangTurnLeftStart"), 1.0f, 0.20f, 0.10f, default(bool?), default(bool?));
			SetTimer(0.20f);		
		}
		else
		{
			OnTimer();
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		PawnOwner.GravityModifier = 1.0f;
		base.StopMove();
		Ladder = default;
	}
	
	public virtual /*simulated function */bool CheckReachableVaultOver()
	{
		/*local */Object.Vector LedgeLocation = default, StartTraceLocation = default, EndTraceLocation = default;
		/*local */bool bReturnValue = default;
	
		LedgeLocation = PawnOwner.MoveLedgeLocation;
		PawnOwner.MoveLedgeLocation = TransferLookAtLocation;
		bReturnValue = false;
		StartTraceLocation = PawnOwner.Location;
		EndTraceLocation = StartTraceLocation;
		EndTraceLocation.Z = PawnOwner.MoveLedgeLocation.Z + PawnOwner.CylinderComponent.CollisionHeight;
		if(!MovementTraceForBlocking(StartTraceLocation, EndTraceLocation, PawnOwner.GetCollisionExtent()))
		{
			if(((PawnOwner.Moves[9]) as TdMove_VaultOver).CanDoMove())
			{
				TransferMove = TdPawn.EMovement.MOVE_VaultOver/*9*/;
				bReturnValue = true;			
			}
			else
			{
				PawnOwner.MoveLedgeLocation = LedgeLocation;
				bReturnValue = false;
			}		
		}
		return bReturnValue;
	}
	
	public virtual /*simulated function */void PlayTransferAnimation()
	{
		PawnOwner.GravityModifier = 0.850f;
		if(((int)TransferHint) == ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
		{
			if(((PawnOwner.Moves[3]) as TdMove_Grab).IsHangingFree())
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("hangfreetransferup")), 1.0f, 0.10f, 0.10f, default(bool?), default(bool?));			
			}
			else
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("hangtransferup")), 1.0f, 0.10f, 0.10f, default(bool?), default(bool?));
			}		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("HangTurnJump")), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.SetLocation(TransferLocation);
		if(((int)TransferMove) == ((int)TdPawn.EMovement.MOVE_IntoClimb/*22*/))
		{
			((PawnOwner.Moves[22]) as TdMove_IntoClimb).Ladder = TransferLadder;
			((PawnOwner.Moves[21]) as TdMove_Climb).Ladder = TransferLadder;
			if(PawnOwner.Moves[22].CanDoMove())
			{
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_IntoClimb/*22*/, default(bool?), default(bool?));
				PawnOwner.ActiveMovementVolume = default;			
			}
			else
			{
				((PawnOwner.Moves[22]) as TdMove_IntoClimb).Ladder = default;
				((PawnOwner.Moves[21]) as TdMove_Climb).Ladder = default;
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
			}		
		}
		else
		{
			PawnOwner.SetMove(((TdPawn.EMovement)TransferMove), default(bool?), default(bool?));
		}
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnTimer()
	{
		SetPreciseLocation(TransferLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, TransferSpeed);
		PawnOwner.FaceRotationTimeLeft = 0.50f;
		PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
		PlayTransferAnimation();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_GrabTransfer/*31*/, default(float?));
		if(((int)TransferMove) != ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/))
		{
			SetLookAtTargetLocation(TransferLookAtLocation, 0.80f, default(float?));		
		}
		else
		{
			ResetCameraLook(0.20f);
		}
		bDisableFaceRotation = false;
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_GrabTransfer()
	{
		// Object Offset:0x005BF413
		Allowed2DTransferDistance = 260.0f;
		AllowedZTransferDistance = 140.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerWalking";
		bShouldHolsterWeapon = true;
		bDisableFaceRotation = true;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 75.0f,
			Medium = 75.0f,
			Hard = 75.0f,
		};
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}