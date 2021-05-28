namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeCrouch : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public /*protected const */float BargeTraceDistance;
	public array<TdMove_Barge.BargeHitInfo> BargeImpactList;
	
	public override /*function */bool CanDoMove()
	{
		if((PawnOwner.Weapon != default) && ((PawnOwner.Weapon) as TdWeapon_Heavy) != default)
		{
			return false;
		}
		if(!base.CanDoMove())
		{
			return false;
		}
		if(((int)PawnOwner.AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/))
		{
			FindBargeTarget();
			if(BargeImpactList.Length == 0)
			{
				return false;
			}
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		bHitDetection = false;
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Crouch/*15*/, default(float));
		SetCameraPitchConstraints(-2000, 2000);
		TriggerMove();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.20f);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float));
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		switch(MeleeState)
		{
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/:
				if(PawnOwner.IsLocallyControlled())
				{
					if(TestHit())
					{
						TriggerHit();					
					}
					else
					{
						TriggerMiss();
					}
				}
				break;
			case TdMove_MeleeBase.EMeleeState.MS_MeleeHitFinishing/*4*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeMissFinishing/*6*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeMissNormal/*5*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeHitNormal/*3*/:
				if(CanStand(PawnOwner.Location + vect(0.0f, 0.0f, 30.0f), default(bool)))
				{
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));				
				}
				else
				{
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default(bool), default(bool));
				}
				break;
			default:
				break;
		}
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		return ClassT<TdDmgType_MeleeCrouch>();
	}
	
	public override /*simulated function */void TriggerMove()
	{
		if(((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeCrouchStartUpperCut", 1.0f, 0.10f, 1.0f, default(bool), default(bool));
			HitDetectionBone = "LeftHand";
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default(float));		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, "MeleeCrouchStart", 1.0f, 0.10f, -1.0f, default(bool), default(bool));
			HitDetectionBone = "RightHand";
		}
		UpdateTargetPawn();
	}
	
	public override /*simulated function */void TriggerHit()
	{
		base.TriggerHit();
		switch(MeleeState)
		{
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeCrouchHitUppercut", 1.0f, 0.10f, 0.10f, default(bool), default(bool));
				break;
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, "MeleeCrouchHit", 1.0f, 0.10f, 0.20f, default(bool), default(bool));
				break;
			default:
				break;
		}
		MeleeState = ((TdMove_MeleeBase.EMeleeState)((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/)) ? 4 : 3));
	}
	
	public override /*simulated function */void TriggerMiss()
	{
		base.TriggerMiss();
		switch(MeleeState)
		{
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeCrouchHitUppercut", 1.0f, 0.10f, 0.10f, default(bool), default(bool));
				break;
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, "MeleeCrouchHit", 1.0f, 0.10f, 0.20f, default(bool), default(bool));
				break;
			default:
				break;
		}
		MeleeState = ((TdMove_MeleeBase.EMeleeState)((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/)) ? 6 : 5));
	}
	
	public override /*event */void TriggerDamage(TdPawn TracePawn)
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector ToTarget = default, HitLocation = default, ImpactMomentum = default;
		/*local */name HitBoneName = default;
	
		if(TargetPawn != TracePawn)
		{
			return;
		}
		ToTarget = TargetPawn.Location - PawnOwner.Location;
		if(((Dot(Normal(ToTarget), ((Vector)(PawnOwner.Rotation)))) > 0.40f) && VSize(ToTarget) < 170.0f)
		{
			HitBoneName = ((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/)) ? "Neck" : "LeftLeg");
			HitLocation = PawnOwner.Mesh3p.GetBoneLocation("RightFoot", default(int));
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone(HitBoneName);
			Hit.BoneName = HitBoneName;
			Hit.HitComponent = TargetPawn.Mesh3p;
			Damage = MeleeDamage;
			ImpactMomentum = (Cross(((Vector)(PawnOwner.Rotation)), vect(0.0f, 0.0f, 1.0f))) * 700.0f;
			PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
			DeliverDamage(Damage, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeCrouch>(), Hit);
			bHitDetection = false;
		}
	}
	
	public virtual /*function */bool TestHit()
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector ToTarget = default, HitLocation = default, ImpactMomentum = default;
		/*local */int Idx = default;
	
		if(TargetPawn == default)
		{
			FindBargeTarget();
			Idx = 0;
			J0x1C:{}
			if(Idx < BargeImpactList.Length)
			{
				if(BargeImpactList[Idx].BargeActor.bInteractable)
				{
					HitObject(BargeImpactList[Idx]);
				}
				++ Idx;
				goto J0x1C;
			}
			return false;
		}
		ToTarget = TargetPawn.Location - PawnOwner.Location;
		if(((Dot(Normal(ToTarget), ((Vector)(PawnOwner.Rotation)))) > 0.80f) && VSize(ToTarget) < 110.0f)
		{
			HitLocation = PawnOwner.Mesh3p.GetBoneLocation("LeftHand", default(int));
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone("Neck");
			Hit.BoneName = "Neck";
			Hit.HitComponent = TargetPawn.Mesh3p;
			ImpactMomentum = ((Vector)(PawnOwner.Rotation)) * 800.0f;
			Damage = MeleeDamage;
			DeliverDamage(Damage, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeCrouch>(), Hit);
			return true;
		}
		return false;
	}
	
	public virtual /*simulated function */void FindBargeTarget()
	{
		/*local */Object.Vector StartTrace = default, EndTrace = default;
		/*local */TdMove_Barge BargeMove = default;
	
		BargeMove = ((PawnOwner.Moves[19]) as TdMove_Barge);
		if(BargeMove == default)
		{
			return;
		}
		BargeImpactList.Remove(0, BargeImpactList.Length);
		StartTrace = PawnOwner.Location;
		EndTrace = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * BargeTraceDistance);
		BargeMove.CalcBargeDamage(StartTrace, EndTrace, ref/*probably?*/ BargeImpactList);
	}
	
	public virtual /*simulated function */void HitObject(TdMove_Barge.BargeHitInfo HitInfo)
	{
		/*local */KActor RBActor = default;
	
		HitInfo.BargeActor.TakeDamage(100, PawnOwner.Controller, HitInfo.HitLocation, -HitInfo.HitNormal, ClassT<TdDmgType_Barge>(), default(Actor.TraceHitInfo), default(Actor));
		RBActor = ((HitInfo.BargeActor) as KActor);
		if(RBActor != default)
		{
			RBActor.ApplyImpulse(-HitInfo.HitNormal, ClassT<TdDmgType_Barge>().DefaultAs<DamageType>().KDamageImpulse, HitInfo.HitLocation, default(Actor.TraceHitInfo));
		}
	}
	
	public override /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default;
	
		PawnRootLocation = PawnOwner.Location;
		PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		return PawnRootLocation + vect(0.0f, 0.0f, 85.0f);
	}
	
	public TdMove_MeleeCrouch()
	{
		// Object Offset:0x005D4E66
		BargeTraceDistance = 120.0f;
		TraceExtent = new Vector
		{
			X=30.0f,
			Y=30.0f,
			Z=30.0f
		};
		MeleeDamage = 33.50f;
		SpeedModifier = 0.20f;
		bUseCustomCollision = true;
		AimMode = TdPawn.MoveAimMode.MAM_TwoHanded;
	}
}
}