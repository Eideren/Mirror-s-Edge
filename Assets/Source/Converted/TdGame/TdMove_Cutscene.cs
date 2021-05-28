namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Cutscene : TdPhysicsMove/*
		config(PawnMovement)*/{
	public Object.Vector TargetLocation;
	public Object.Rotator TargetRotation;
	
	public override /*function */bool CanDoMove()
	{
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector ToTarget = default;
		/*local */float TimeToTarget = default;
	
		base.StartMove();
		ToTarget = TargetLocation - PawnOwner.Location;
		TimeToTarget = VSize2D(ToTarget) / 250.0f;
		if(TimeToTarget > 0.40f)
		{
			SetPreciseRotation(((Rotator)(ToTarget)), 0.20f);
			SetMoveTimer(TimeToTarget - 0.30f, false, "AlignToTargetRotation");		
		}
		else
		{
			SetPreciseRotation(TargetRotation, 0.20f);
		}
		SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, 250.0f);
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
	}
	
	public virtual /*simulated function */void AlignToTargetRotation()
	{
		SetPreciseRotation(TargetRotation, 0.20f);
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
	
	}
	
	public TdMove_Cutscene()
	{
		// Object Offset:0x005B07E3
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bDisableCollision = true;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}