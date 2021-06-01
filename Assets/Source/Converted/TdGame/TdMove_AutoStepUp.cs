namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_AutoStepUp : TdPhysicsMove/*
		config(PawnMovement)*/{
	public/*(StepUp)*/ /*config */float StepUpDistanceLimit;
	public/*(StepUp)*/ /*config */float StepUpSpeedLimit;
	public/*(StepUp)*/ /*config */float StepUpLowMinHeight;
	public/*(StepUp)*/ /*config */float StepUpMediumMinHeight;
	public/*(StepUp)*/ /*config */float StepUpHighMinHeight;
	public/*(StepUp)*/ /*config */float StepUpHighMaxHeight;
	public/*(StepUp)*/ /*config */float StepUpOptimalLowHeight;
	public/*(StepUp)*/ /*config */float StepUpOptimalMediumHeight;
	public/*(StepUp)*/ /*config */float StepUpOptimalHighHeight;
	public Object.Vector EndPosition;
	public float StartDistance;
	public Object.Vector SavedVelocity;
	
	public override /*function */bool CanDoMove()
	{
		/*local */float HandplantHeight = default, DistanceToLedge = default, TimeToLedge = default, EndPositionOffset = default, LedgeAngle = default;
	
		/*local */Object.Vector TraceStart = default, TraceEnd = default, ToLedge2D = default, CollisionExtent = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		return false;
		if(PawnOwner.bFoundLedgeExcludesFootMoves || (PawnOwner.MovementActor != default) && PawnOwner.MovementActor.bExludeFootMoves)
		{
			return false;
		}
		if((PawnOwner.MovementExclusionVolume != default) && PawnOwner.MovementExclusionVolume.bExcludeFootMoves)
		{
			return false;
		}
		ToLedge2D = PawnOwner.MoveLedgeLocation - PawnOwner.Location;
		ToLedge2D.Z = 0.0f;
		DistanceToLedge = VSize2D(ToLedge2D);
		TimeToLedge = DistanceToLedge / ((float)(Max(150, ((int)(VSize2D(PawnOwner.Velocity))))));
		if((TimeToLedge > 0.350f) || DistanceToLedge > 100.0f)
		{
			return false;
		}
		if(((int)PawnOwner.MoveActionHint) != ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
		{
			return false;
		}
		if((PawnOwner.Velocity.Z < -600.0f) || PawnOwner.Velocity.Z > 0.0f)
		{
			return false;
		}
		HandplantHeight = (PawnOwner.MoveLedgeLocation.Z - PawnOwner.Location.Z) + PawnOwner.CylinderComponent.CollisionHeight;
		if((HandplantHeight > StepUpHighMaxHeight) || HandplantHeight < StepUpHighMinHeight)
		{
			return false;
		}
		if((Dot(PawnOwner.Velocity, PawnOwner.MoveNormal)) > 0.0f)
		{
			return false;
		}
		StartDistance = FMin(120.0f, VSize2D(PawnOwner.MoveLedgeLocation - PawnOwner.Location));
		EndPositionOffset = 40.0f;
		SavedVelocity = PawnOwner.Velocity * 0.50f;
		EndPosition = PawnOwner.MoveLedgeLocation;
		EndPosition += (((Vector)(PawnOwner.Rotation)) * EndPositionOffset);
		EndPosition.Z += (PawnOwner.CylinderComponent.CollisionHeight + 2.0f);
		CollisionExtent = PawnOwner.GetCollisionExtent();
		CollisionExtent.Z = 64.0f - 2.0f;
		TraceEnd = EndPosition;
		TraceEnd.Z = (PawnOwner.MoveLedgeLocation.Z + CollisionExtent.Z) + 2.0f;
		TraceStart = PawnOwner.Location;
		TraceStart.Z = TraceEnd.Z;
		LedgeAngle = FMin(1.0f, Acos(PawnOwner.MoveLedgeNormal.Z) / (3.1415930f / 4.0f)) * 30.0f;
		TraceEnd.Z += LedgeAngle;
		TraceStart.Z += LedgeAngle;
		EndPosition.Z += LedgeAngle;
		if(MovementTraceForBlocking(TraceEnd, TraceStart, CollisionExtent))
		{
			return false;
		}
		if(MovementTraceForBlocking(EndPosition, TraceEnd, CollisionExtent))
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("autostepuprightleg")), 0.80f, 0.150f, 0.250f, false, default(bool?));
		SetPreciseLocation(EndPosition, TdMove.EPreciseLocationMode.PLM_Jump/*2*/, ((float)(Max(200, ((int)(VSize2D(SavedVelocity)))))));
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		return;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.Velocity = SavedVelocity;
		PawnOwner.Acceleration = Normal(SavedVelocity);
		((PawnOwner.Controller) as TdPlayerController).AccelerationTime = 0.20f;
	}
	
	public TdMove_AutoStepUp()
	{
		// Object Offset:0x0059E080
		StepUpDistanceLimit = 60.0f;
		StepUpSpeedLimit = 300.0f;
		StepUpLowMinHeight = 33.0f;
		StepUpMediumMinHeight = 68.0f;
		StepUpHighMinHeight = 8.0f;
		StepUpHighMaxHeight = 48.0f;
		StepUpOptimalLowHeight = 48.0f;
		StepUpOptimalMediumHeight = 88.0f;
		StepUpOptimalHighHeight = 144.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bDisableCollision = true;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}