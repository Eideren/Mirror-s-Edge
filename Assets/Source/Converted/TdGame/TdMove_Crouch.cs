namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Crouch : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
		return ((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Crouch/*15*/);
	}
	
	public override /*simulated function */void StopReplicatedMove()
	{
		base.StopReplicatedMove();
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		base.StartReplicatedMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, AnimBlendTime);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_LowerBody/*5*/, AnimBlendTime);
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			((PawnOwner) as TdPlayerPawn).EnableFootPlacement(0.10f);
			PawnOwner.SetRootOffset(vect(0.0f, 0.0f, 15.0f), 0.10f, default);
			SetMoveTimer(0.150f, false, "DisableRootOffset");
			PawnOwner.SetTimer(0.20f, false, "DisableFootPlacement", default);
		}
		PawnOwner.OnTutorialEvent(12);
	}
	
	public virtual /*simulated function */void DisableRootOffset()
	{
		PawnOwner.SetRootOffset(vect(0.0f, 0.0f, 0.0f), 0.10f, default);
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(((int)PawnOwner.PendingMovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			((PawnOwner) as TdPlayerPawn).EnableFootPlacement(0.0f);
			PawnOwner.SetTimer(0.20f, false, "DisableFootPlacement", default);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_Camera/*6*/, "CrouchIntoStand", 1.0f, 0.20f, 0.20f, false, default);
		}
		PawnOwner.bAvoidLedges = true;
		PawnOwner.SetHipsOffset(vect(0.0f, 0.0f, 0.0f), default, default);
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		PawnOwner.bAvoidLedges = ((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/);
	}
	
	public virtual /*simulated event */void StopMovingToCrouchSit()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
	}
	
	public override /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default;
	
		PawnRootLocation = PawnOwner.Location;
		PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		return PawnRootLocation + vect(0.0f, 0.0f, 85.0f);
	}
	
	public override /*function */void CheckForCameraCollision(Object.Vector CameraLocation, Object.Rotator CameraRotation)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default, TraceEnd = default, TraceStart = default, TraceExtent = default, MeshOffset = default;
	
		if(MoveActiveTime < 0.20f)
		{
			TraceStart = CameraLocation - (((Vector)(PawnOwner.Rotation)) * 5.0f);
			TraceEnd = CameraLocation + (((Vector)(PawnOwner.Rotation)) * 15.0f);
			TraceEnd.Z += 5.0f;
			TraceExtent = vect(2.0f, 2.0f, 2.0f);
			if(MovementTraceForBlockingEx(TraceEnd, TraceStart, TraceExtent, ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal))
			{
				MeshOffset.X = -VSize2D(TraceEnd - HitLocation) - 1.0f;
				PawnOwner.OffsetMeshXY(MeshOffset, false);
			}		
		}
		else
		{
			base.CheckForCameraCollision(CameraLocation, CameraRotation);
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */int RotYawDiff = default;
		/*local */Object.Vector HipsOffset = default;
	
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if((((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Slide/*16*/)) && MoveActiveTime < 0.30f)
		{
			PawnOwner.SetHipsOffset(vect(0.0f, 0.0f, 0.0f), default, default);		
		}
		else
		{
			RotYawDiff = NormalizeRotAxis(PawnOwner.Controller.Rotation.Yaw) - PawnOwner.LegRotation;
			RotYawDiff = NormalizeRotAxis(RotYawDiff);
			HipsOffset.X = 25.0f * (Abs(((float)(RotYawDiff))) / 16384.0f);
			HipsOffset.Y = 30.0f * (((float)(RotYawDiff)) / 16384.0f);
			HipsOffset.Z = 0.0f;
			PawnOwner.SetHipsOffset(HipsOffset, 0.30f, true);
		}
	}
	
	public TdMove_Crouch()
	{
		// Object Offset:0x005B01D2
		SpeedModifier = 0.20f;
		bShouldUnzoom = false;
		bConstrainLook = true;
		bUseCustomCollision = true;
		bUseCameraCollision = true;
		bEnableFootPlacement = true;
		bEnableAgainstWall = true;
		bAllowPickup = true;
		MinLookConstraint = new Rotator
		{
			Pitch=-14000,
			Yaw=-32768,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=14000,
			Yaw=32768,
			Roll=32768
		};
		AnimBlendTime = 0.250f;
	}
}
}