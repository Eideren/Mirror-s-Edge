namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeSlide : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public bool bInMove;
	public /*protected const */float BargeTraceDistance;
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		bHitDetection = false;
		bInMove = false;
		ClearTimer();
		if(((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/)) && PawnOwner.Weapon != default) && ((PawnOwner.Weapon) as TdWeapon_Heavy) != default)
		{
			MeleeState = TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/;
		}
		if(((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("CrouchSlideToCrouch")), 1.0f, 0.10f, 0.10f, default, default);
			MeleeState = TdMove_MeleeBase.EMeleeState.MS_MeleePending/*0*/;		
		}
		else
		{
			TriggerMove();
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default);
	}
	
	public virtual /*simulated function */void FindBargeTarget()
	{
		/*local */Object.Vector StartTrace = default, EndTrace = default;
		/*local */TdMove_Barge BargeMove = default;
		/*local */array<TdMove_Barge.BargeHitInfo> BargeImpactList = default;
		/*local */int Idx = default;
	
		BargeMove = ((PawnOwner.Moves[19]) as TdMove_Barge);
		if(BargeMove == default)
		{
			return;
		}
		StartTrace = PawnOwner.Location;
		EndTrace = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * BargeTraceDistance);
		BargeMove.CalcBargeDamage(StartTrace, EndTrace, ref/*probably?*/ BargeImpactList);
		Idx = 0;
		J0x98:{}
		if(Idx < BargeImpactList.Length)
		{
			if(BargeImpactList[Idx].BargeActor.bInteractable)
			{
				BargeObject(BargeImpactList[Idx]);
			}
			++ Idx;
			goto J0x98;
		}
	}
	
	public virtual /*simulated function */void BargeObject(TdMove_Barge.BargeHitInfo HitInfo)
	{
		/*local */KActor RBActor = default;
	
		HitInfo.BargeActor.TakeDamage(100, PawnOwner.Controller, HitInfo.HitLocation, -HitInfo.HitNormal, ClassT<TdDmgType_Barge>(), default, default);
		RBActor = ((HitInfo.BargeActor) as KActor);
		if(RBActor != default)
		{
			RBActor.ApplyImpulse(-HitInfo.HitNormal, ClassT<TdDmgType_Barge>().DefaultAs<DamageType>().KDamageImpulse, HitInfo.HitLocation, default);
		}
	}
	
	public virtual /*simulated function */void HitObject(Actor Victim, Object.Vector HitLocation, Object.Vector HitNormal, Core.ClassT<DamageType> inDamageType)
	{
		/*local */KActor RBActor = default;
	
		Victim.TakeDamage(100, PawnOwner.Controller, HitLocation, -HitNormal, inDamageType, default, default);
		RBActor = ((Victim) as KActor);
		if(RBActor != default)
		{
			RBActor.ApplyImpulse(-HitNormal, inDamageType.DefaultAs<DamageType>().KDamageImpulse, HitLocation, default);
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		switch(MeleeState)
		{
			case TdMove_MeleeBase.EMeleeState.MS_MeleePending/*0*/:
				MeleeState = TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/;
				TriggerMove();
				break;
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeHitFinishing/*4*/:
			case TdMove_MeleeBase.EMeleeState.MS_MeleeMissFinishing/*6*/:
				if(CanStand(PawnOwner.Location, default))
				{
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);				
				}
				else
				{
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default, default);
				}
				break;
			default:
				break;
		}
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		return ((((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/)) ? ClassT<TdDmgType_Melee>() : ClassT<TdDmgType_MeleeSlide>());
	}
	
	public override /*simulated function */void TriggerMove()
	{
		if(((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeSlideHard", 1.0f, 0.10f, 0.10f, default, default);
			HitDetectionBone = "LeftHand";
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default);		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeSlide", 1.0f, 0.10f, 0.10f, default, default);
			HitDetectionBone = "RightFoot";
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Slide/*16*/, default);
		}
		bInMove = true;
		SetTimer(0.25420f);
		SetMoveTimer(0.330f, false, "OnFindBargeTargetTimer");
		UpdateTargetPawn();
	}
	
	public override /*simulated function */void OnTimer()
	{
		bHitDetection = true;
	}
	
	public virtual /*simulated function */void OnFindBargeTargetTimer()
	{
		if(TargetPawn == default)
		{
			FindBargeTarget();
		}
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
		if(((TargetPawn) as TdBotPawn) != default)
		{
			((TargetPawn) as TdBotPawn).ActiveDeathAnimType = TdBotPawn.DeathAnimType.DAT_RagdollHard/*1*/;
		}
		if(((Dot(Normal(ToTarget), ((Vector)(PawnOwner.Rotation)))) > 0.40f) && VSize(ToTarget) < 140.0f)
		{
			HitBoneName = "LeftLeg";
			HitLocation = PawnOwner.Mesh3p.GetBoneLocation("RightFoot", default);
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone(HitBoneName);
			Hit.BoneName = HitBoneName;
			Hit.HitComponent = TargetPawn.Mesh3p;
			ImpactMomentum = (((Vector)(PawnOwner.Rotation)) * VSize2D(PawnOwner.Velocity)) * 1.60f;
			Damage = MeleeDamage;
			DeliverDamage(Damage, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeSlide>(), Hit);
			bHitDetection = false;
		}
	}
	
	public TdMove_MeleeSlide()
	{
		// Object Offset:0x005D5F12
		BargeTraceDistance = 90.0f;
		TraceExtent = new Vector
		{
			X=40.0f,
			Y=40.0f,
			Z=40.0f
		};
		MeleeDamage = 60.0f;
		FrictionModifier = 0.10f;
		bUseCustomCollision = true;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}