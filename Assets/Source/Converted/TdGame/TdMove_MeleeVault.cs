namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeVault : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public Object.Vector ImpactMomentum;
	public Object.Rotator LookAtAngle;
	public float VaultTimeDown;
	public Object.Vector VaultEndPosition;
	public Object.Vector SavedVelocity;
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		SetPreciseLocation(VaultEndPosition, TdMove.EPreciseLocationMode.PLM_Jump/*2*/, VSize2D(VaultEndPosition - PawnOwner.Location) / VaultTimeDown);
		SetTimer(0.30f);
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		SetStoredVelocity();
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		SetStoredVelocity();
	}
	
	public virtual /*function */void SetStoredVelocity()
	{
		if(bHitDetection)
		{
			PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
			SavedVelocity.Z = FMax(0.0f, PawnOwner.Velocity.Z);
			PawnOwner.Velocity = SavedVelocity;
			PawnOwner.Acceleration = Normal(SavedVelocity);
			((PawnOwner.Controller) as TdPlayerController).AccelerationTime = 0.20f;
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);
		PawnOwner.Moves[1].ResetCameraLook(0.60f);
	}
	
	public virtual /*function */void SetVaultProperties(Object.Vector InVaultEndPosition, float InVaultTimeDown, Object.Vector InSavedVelocity)
	{
		VaultEndPosition = InVaultEndPosition;
		VaultTimeDown = InVaultTimeDown;
		SavedVelocity = InSavedVelocity;
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		return ClassT<TdDmgType_MeleeVaultKick>();
	}
	
	public override /*simulated function */void TriggerMove()
	{
		base.TriggerMove();
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeVaultOver", 1.0f, 0.10f, 0.10f, false, default);
		HitDetectionBone = "RightFoot";
		bHitDetection = true;
		ImpactMomentum = ((Vector)(PawnOwner.Rotation)) * ((float)(200));
		UpdateTargetPawn();
	}
	
	public override /*simulated function */void OnTimer()
	{
		TriggerMove();
	}
	
	public override /*event */void TriggerDamage(TdPawn Victim)
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector ToTarget = default, HitLocation = default;
		/*local */bool bVerifyHit = default;
	
		if(TargetPawn != Victim)
		{
			return;
		}
		ToTarget = TargetPawn.Location - PawnOwner.Location;
		bVerifyHit = ((Dot(Normal(ToTarget), ((Vector)(PawnOwner.Rotation)))) > 0.40f) && VSize(ToTarget) < 140.0f;
		if(bVerifyHit)
		{
			HitLocation = PawnOwner.Mesh3p.GetBoneLocation("RightFoot", default);
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone("Neck");
			Hit.BoneName = "Neck";
			Hit.HitComponent = TargetPawn.Mesh3p;
			Damage = MeleeDamage;
			DeliverDamage(Damage, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeVaultKick>(), Hit);
			bHitDetection = false;
		}
	}
	
	public TdMove_MeleeVault()
	{
		// Object Offset:0x005D69B3
		TargetingMaxDistance = 800.0f;
		TraceExtent = new Vector
		{
			X=60.0f,
			Y=60.0f,
			Z=160.0f
		};
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		MovementGroup = TdMove.EMovementGroup.MG_OneHandBusy;
		DisableLookTime = -1.0f;
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