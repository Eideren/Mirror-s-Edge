namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StepUp : TdPhysicsMove/*
		config(PawnMovement)*/{
	public enum EStepUpType 
	{
		ESUT_Low,
		ESUT_Medium,
		ESUT_High,
		ESUT_Long,
		ESUT_MAX
	};
	
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
	public TdMove_StepUp.EStepUpType StepUpType;
	public float StartDistance;
	public Object.Vector SavedVelocity;
	
	public override /*function */bool CanDoMove()
	{
		/*local */float HandplantHeight = default, DistanceToLedge = default, TimeToLedge = default, EndPositionOffset = default;
		/*local */Object.Vector TraceStart = default, TraceEnd = default, ToLedge2D = default, CollisionExtent = default;
	
		if((!base.CanDoMove() || !PawnOwner.bFoundLedge))
		{
			return false;
		}
		if((PawnOwner.bFoundLedgeExcludesFootMoves || (PawnOwner.MovementActor != default) && PawnOwner.MovementActor.bExludeFootMoves))
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
		if(TimeToLedge > 0.450f)
		{
			return false;
		}
		if(PawnOwner.MoveLedgeNormal.Z < 0.710f)
		{
			return false;
		}
		HandplantHeight = (PawnOwner.MoveLedgeLocation.Z - PawnOwner.Location.Z) + PawnOwner.CylinderComponent.CollisionHeight;
		if(((HandplantHeight > StepUpHighMaxHeight) || HandplantHeight < StepUpLowMinHeight))
		{
			return false;
		}
		StartDistance = FMin(120.0f, VSize2D(PawnOwner.MoveLedgeLocation - PawnOwner.Location));
		EndPositionOffset = 80.0f;
		StepUpType = TdMove_StepUp.EStepUpType.ESUT_Long/*3*/;
		if((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && ((int)StepUpType) >= ((int)TdMove_StepUp.EStepUpType.ESUT_High/*2*/))
		{
			return false;
		}
		if((((int)StepUpType) <= ((int)TdMove_StepUp.EStepUpType.ESUT_Medium/*1*/)) && TimeToLedge > 0.30f)
		{
			return false;
		}
		SavedVelocity = PawnOwner.Velocity;
		EndPosition = PawnOwner.MoveLedgeLocation;
		EndPosition += (((Vector)(PawnOwner.Rotation)) * EndPositionOffset);
		EndPosition.Z += (PawnOwner.CylinderComponent.CollisionHeight + 2.0f);
		CollisionExtent = PawnOwner.GetCollisionExtent();
		CollisionExtent.Z = 64.0f - 2.0f;
		TraceEnd = EndPosition;
		TraceEnd.Z = (PawnOwner.MoveLedgeLocation.Z + CollisionExtent.Z) + 2.0f;
		TraceStart = PawnOwner.Location;
		TraceStart.Z = TraceEnd.Z;
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
		/*local */Object.Vector TargetLocation = default, ToLegde2D = default;
	
		base.StartMove();
		ToLegde2D = PawnOwner.MoveLedgeLocation - PawnOwner.Location;
		ToLegde2D.Z = 0.0f;
		TargetLocation = PawnOwner.MoveLedgeLocation - (Normal(ToLegde2D) * StartDistance);
		TargetLocation.Z = PawnOwner.Location.Z;
		if(((int)StepUpType) == ((int)TdMove_StepUp.EStepUpType.ESUT_Long/*3*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("vaultonto")), 1.0f, 0.150f, 0.250f, false, default(bool?));
			SetPreciseLocation(EndPosition, TdMove.EPreciseLocationMode.PLM_Jump/*2*/, ((float)(Max(200, ((int)(VSize2D(SavedVelocity)))))));		
		}
		else
		{
			SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Walk/*1*/, ((float)(Max(200, ((int)(VSize2D(SavedVelocity)))))));
		}
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		if(((int)StepUpType) == ((int)TdMove_StepUp.EStepUpType.ESUT_Long/*3*/))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
			return;
		}
		PawnOwner.UseRootMotion(true);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		if(((int)StepUpType) == ((int)TdMove_StepUp.EStepUpType.ESUT_Low/*0*/))
		{
			RootMotionScale.Z = (EndPosition.Z - PawnOwner.Location.Z) / StepUpOptimalLowHeight;
			if(PawnOwner.IsLeftLegForward())
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("stepupleftleg48")), 1.0f, 0.150f, 0.10f, true, default(bool?));			
			}
			else
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("stepuprightleg48")), 1.0f, 0.150f, 0.10f, true, default(bool?));
			}		
		}
		else
		{
			if(((int)StepUpType) == ((int)TdMove_StepUp.EStepUpType.ESUT_Medium/*1*/))
			{
				RootMotionScale.Z = (EndPosition.Z - PawnOwner.Location.Z) / StepUpOptimalMediumHeight;
				if(PawnOwner.IsLeftLegForward())
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("stepupleftleg88")), 1.20f, 0.150f, 0.10f, true, default(bool?));				
				}
				else
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("stepuprightleg88")), 1.20f, 0.150f, 0.10f, true, default(bool?));
				}			
			}
			else
			{
				if(((int)StepUpType) == ((int)TdMove_StepUp.EStepUpType.ESUT_High/*2*/))
				{
					RootMotionScale.Z = (EndPosition.Z - PawnOwner.Location.Z) / StepUpOptimalHighHeight;
					ResetCameraLook(0.150f);
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("stepup144")), 1.0f, 0.150f, 0.10f, true, default(bool?));
				}
			}
		}
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		PawnOwner.UseRootMotion(false);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(((int)StepUpType) == ((int)TdMove_StepUp.EStepUpType.ESUT_Long/*3*/))
		{
			PawnOwner.Velocity = SavedVelocity;
			PawnOwner.Acceleration = Normal(SavedVelocity);		
		}
		else
		{
			PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		}
		PawnOwner.FaceRotationTimeLeft = 0.30f;
		((PawnOwner.Controller) as TdPlayerController).AccelerationTime = 0.20f;
	}
	
	public TdMove_StepUp()
	{
		// Object Offset:0x005E2F47
		StepUpDistanceLimit = 60.0f;
		StepUpSpeedLimit = 300.0f;
		StepUpLowMinHeight = 33.0f;
		StepUpMediumMinHeight = 68.0f;
		StepUpHighMinHeight = 112.0f;
		StepUpHighMaxHeight = 148.0f;
		StepUpOptimalLowHeight = 48.0f;
		StepUpOptimalMediumHeight = 88.0f;
		StepUpOptimalHighHeight = 144.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bDisableCollision = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bAvoidLedges = false;
		DisableMovementTime = -1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-3000,
			Yaw=-8000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=6000,
			Yaw=8000,
			Roll=32768
		};
	}
}
}