namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Vertigo : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public Object.Vector LastVertigoEdgePosition;
	public Object.Vector LastActualVertigoEdgePosition;
	public /*config */float ZoomFOV;
	public /*config */float ZoomRate;
	public /*config */float ZoomOutTime;
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector Start = default, End = default, Extent = default;
	
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		if((Dot(Normal(LastVertigoEdgePosition - PawnOwner.Location), ((Vector)(PawnOwner.Rotation)))) < 0.0f)
		{
			return false;
		}
		Start = PawnOwner.Location;
		Start.Z += (PawnOwner.GetCollisionHeight() * 0.20f);
		End = Start;
		End += ((Normal(((Vector)(PawnOwner.Rotation))) * PawnOwner.CylinderComponent.CollisionRadius) * 2.0f);
		End.Z = Start.Z;
		Extent.X = PawnOwner.CylinderComponent.CollisionRadius;
		Extent.Y = PawnOwner.CylinderComponent.CollisionRadius;
		Extent.Z = PawnOwner.CylinderComponent.CollisionHeight * 0.70f;
		if(MovementTraceForBlocking(End, Start, Extent))
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Rotator TargetRot = default;
	
		((PawnOwner.Controller) as TdPlayerController).EndZoom();
		base.StartMove();
		TargetRot = PawnOwner.Rotation;
		TargetRot.Pitch = -15000;
		SetLookAtTargetAngle(TargetRot, 0.280f, default(float?));
		SetTimer(ZoomOutTime);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, "edgedetection", 1.0f, 0.280f, 0.280f, default(bool?), default(bool?));
		((PawnOwner.Controller) as TdPlayerController).StartZoom(ZoomFOV, ZoomRate, 0.0f);
		SetMoveTimer(DisableMovementTime, false, "OnTimerEnableAiming");
	}
	
	public virtual /*simulated function */void OnTimerEnableAiming()
	{
		MovementGroup = TdMove.EMovementGroup.MG_Free/*0*/;
		AimMode = TdPawn.MoveAimMode.MAM_Default/*4*/;
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */Object.Vector DiffBetweenPawnAndEdge = default;
		/*local */Object.Rotator PawnHeading = default, EdgeHeading = default, Delta = default;
	
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		DiffBetweenPawnAndEdge = Normal(LastVertigoEdgePosition - PawnOwner.Location);
		EdgeHeading = ((Rotator)(DiffBetweenPawnAndEdge));
		PawnHeading = PawnOwner.Rotation;
		Delta = Normalize(EdgeHeading - PawnHeading);
		if(((Delta.Yaw < -8000) || Delta.Yaw > 8000))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		((PawnOwner.Controller) as TdPlayerController).UnZoom();
		AbortLookAtTarget();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.40f);
		((PawnOwner.Controller) as TdPlayerController).UnZoom();
		MovementGroup = ((TdMove.EMovementGroup)DefaultAs<TdMove>().MovementGroup);
		AimMode = ((TdPawn.MoveAimMode)DefaultAs<TdMove>().AimMode);
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		return ((int)MovementGroup) == ((int)TdMove.EMovementGroup.MG_Free/*0*/);
	}
	
	public TdMove_Vertigo()
	{
		// Object Offset:0x005E8A1E
		ZoomFOV = 84.0f;
		ZoomRate = 30.0f;
		ZoomOutTime = 1.20f;
		bUseCameraCollision = true;
		bTwoHandedFullBodyAnimations = true;
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		AimMode = TdPawn.MoveAimMode.MAM_TwoHanded;
		DisableMovementTime = 1.50f;
		DisableLookTime = 1.50f;
		RedoMoveTime = 3.0f;
	}
}
}