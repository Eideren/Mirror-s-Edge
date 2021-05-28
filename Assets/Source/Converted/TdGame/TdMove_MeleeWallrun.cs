namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeWallrun : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public Object.Vector WallrunNormal;
	public bool bLeft;
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		bHitDetection = true;
		bLeft = ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningLeft/*5*/);
		WallrunNormal = ((PawnOwner.Moves[((int)PawnOwner.OldMovementState)]) as TdMove_WallRun).WallNormal;
		TriggerMove();
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
		if(((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleePending/*0*/))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		bHitDetection = true;
	}
	
	public override /*simulated function */void TriggerMove()
	{
		/*local */Object.Vector ToTarget = default;
	
		base.TriggerMove();
		if(TargetPawn != default)
		{
			ToTarget = Normal((TargetPawn.Location - PawnOwner.Location) + (vect(0.0f, 0.0f, 1.0f) * TargetPawn.BaseEyeHeight));
			SetPreciseRotation(((Rotator)(ToTarget)), 0.10f);
			PawnOwner.Velocity = (ToTarget * VSize2D(PawnOwner.Velocity)) * 0.750f;		
		}
		else
		{
			SetPreciseRotation(((bLeft) ? PawnOwner.Rotation + rot(0, 6000, 0) : PawnOwner.Rotation - rot(0, 6000, 0)), 0.10f);
			PawnOwner.Velocity = ((bLeft) ? /*<<*/ShiftL(PawnOwner.Velocity, rot(0, -6000, 0)) : /*<<*/ShiftL(PawnOwner.Velocity, rot(0, 6000, 0)));
			PawnOwner.Velocity *= 1.20f;
		}
		switch(MeleeState)
		{
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/:
				ResetCameraLook(0.10f);
				HitDetectionBone = ((bLeft) ? "LeftLeg" : "RightLeg");
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((bLeft) ? "MeleeWallRunLeft" : "MeleeWallRunRight"), 1.0f, 0.10f, 0.20f, false, default(bool));
				break;
			default:
				break;
		}
	}
	
	public override /*event */void TriggerDamage(TdPawn TracePawn)
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector ToTarget = default, HitLocation = default, ImpactMomentum = default;
	
		if(TracePawn != TracePawn)
		{
			return;
		}
		ToTarget = TargetPawn.Location - PawnOwner.Location;
		if(((Dot(Normal(ToTarget), ((Vector)(PawnOwner.Rotation)))) > 0.40f) && VSize(ToTarget) < 140.0f)
		{
			HitLocation = PawnOwner.Mesh3p.GetBoneLocation(HitDetectionBone, default(int));
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone("Neck");
			Hit.BoneName = "Neck";
			Hit.HitComponent = TargetPawn.Mesh3p;
			Damage = MeleeDamage;
			ImpactMomentum = ((Vector)(PawnOwner.Rotation)) * 500.0f;
			DeliverDamage(Damage, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeWallRun>(), Hit);
			PawnOwner.Velocity.X *= -0.50f;
			PawnOwner.Velocity.Y *= -0.50f;
			bHitDetection = false;
		}
	}
	
	public TdMove_MeleeWallrun()
	{
		// Object Offset:0x005D7410
		bTargeting = false;
		TraceOffset = new Vector
		{
			X=30.0f,
			Y=0.0f,
			Z=0.0f
		};
		TraceExtent = new Vector
		{
			X=30.0f,
			Y=30.0f,
			Z=30.0f
		};
		MeleeDamage = 80.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		bConstrainLook = true;
		MinLookConstraint = new Rotator
		{
			Pitch=-3000,
			Yaw=-8000,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16000,
			Yaw=8000,
			Roll=0
		};
	}
}
}