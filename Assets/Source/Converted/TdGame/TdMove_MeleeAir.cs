namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeAir : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public enum EMeleeAirType 
	{
		MAT_FromJump,
		MAT_FromJumpStill,
		MAT_FromJumpHigh,
		MAT_MAX
	};
	
	public TdMove_MeleeAir.EMeleeAirType MeleeType;
	public Object.Vector ImpactMomentum;
	public Object.Rotator LookAtAngle;
	public bool bHasRecievedLandedEvent;
	public /*config */float MeleeAirAboveMinAngle;
	public /*config */float MeleeAirAboveMinSeparation;
	public /*config */float MeleeAirAboveMaxSeparation;
	
	public override /*function */bool CanDoMove()
	{
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Jump/*11*/)) && PawnOwner.Moves[11].MoveActiveTime < 0.10f)
		{
			return false;
		}
		if((PawnOwner.Weapon != default) && ((PawnOwner.Weapon) as TdWeapon_Heavy) != default)
		{
			return false;
		}
		switch(PawnOwner.MovementState)
		{
			case TdPawn.EMovement.MOVE_IntoGrab/*14*/:
			case TdPawn.EMovement.MOVE_Jump/*11*/:
			case TdPawn.EMovement.MOVE_Falling/*2*/:
			case TdPawn.EMovement.MOVE_WallRunJump/*12*/:
			case TdPawn.EMovement.MOVE_GrabJump/*13*/:
				MeleeType = ((TdMove_MeleeAir.EMeleeAirType)((VSize2D(PawnOwner.Velocity) > 200.0f) ? 0 : 1));
				break;
			default:
				return false;
				break;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector ToTarget = default;
		/*local */float TargetZSeparation = default;
		/*local */TdBotPawn TargetBot = default;
	
		base.StartMove();
		bHasRecievedLandedEvent = false;
		if((((int)MeleeType) == ((int)TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/)) && TargetPawn != default)
		{
			ToTarget = TargetPawn.Location - PawnOwner.Location;
			if(((Dot(Normal(ToTarget), vect(0.0f, 0.0f, 1.0f))) < -0.60f) && PawnOwner.Velocity.Z < 0.0f)
			{
				MeleeType = TdMove_MeleeAir.EMeleeAirType.MAT_FromJumpHigh/*2*/;
			}
			TargetZSeparation = PawnOwner.Location.Z - TargetPawn.Location.Z;
			if(((((Dot(Normal(ToTarget), vect(0.0f, 0.0f, 1.0f))) < -MeleeAirAboveMinAngle) && TargetZSeparation > MeleeAirAboveMinSeparation) && TargetZSeparation < MeleeAirAboveMaxSeparation) && PawnOwner.Velocity.Z < 0.0f)
			{
				TargetBot = ((TargetPawn) as TdBotPawn);
				if((TargetBot != default) && !TargetBot.CanDoMove(TdPawn.EMovement.MOVE_MeleeAirAbove/*82*/))
				{
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
					return;
				}
				((PawnOwner.Moves[82]) as TdMove_MeleeBase).TargetPawn = TargetPawn;
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_MeleeAirAbove/*82*/, default(bool?), default(bool?));
				return;
			}
		}
		TriggerMove();
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		PawnOwner.Moves[2].ResetCameraLook(0.60f);
	}
	
	public override /*simulated function */void Bump(Object.Vector HitNormal, Actor BumpedActor)
	{
		if(!BumpedActor.bInteractable)
		{
			return;
		}
		HitObject(BumpedActor, BumpedActor.Location, -HitNormal, ClassT<TdDmgType_Barge>());
		bHitDetection = false;
	}
	
	public virtual /*simulated function */void HitObject(Actor Victim, Object.Vector HitLocation, Object.Vector HitNormal, Core.ClassT<DamageType> inDamageType)
	{
		/*local */KActor RBActor = default;
	
		Victim.TakeDamage(100, PawnOwner.Controller, HitLocation, -HitNormal, inDamageType, default(Actor.TraceHitInfo?), default(Actor?));
		RBActor = ((Victim) as KActor);
		if(RBActor != default)
		{
			RBActor.ApplyImpulse(-HitNormal, inDamageType.DefaultAs<DamageType>().KDamageImpulse, HitLocation, default(Actor.TraceHitInfo?));
		}
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		return ClassT<TdDmgType_MeleeAir>();
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
		/*local */float FallHeight = default;
	
		bHasRecievedLandedEvent = true;
		switch(MeleeType)
		{
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/:
				FallHeight = PawnOwner.EnterFallingHeight - PawnOwner.Location.Z;
				if(bHitDetection && FallHeight < ((PawnOwner.Moves[20]) as TdMove_Landing).HardLandingHeight)
				{
					base.Landed(aNormal, anActor);
					PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
					PawnOwner.Moves[1].ResetCameraLook(0.40f);
					PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.30f);
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeInAirLand2", 1.0f, 0.30f, 0.30f, default(bool?), default(bool?));
					PawnOwner.PlayFootStepSound(((PawnOwner.Velocity.Z < -1000.0f) ? 9 : 8));
					bHitDetection = false;				
				}
				else
				{
					if(bHitDetection && FallHeight >= ((PawnOwner.Moves[20]) as TdMove_Landing).HardLandingHeight)
					{
						bHitDetection = false;
						base.Landed(aNormal, anActor);					
					}
					else
					{
						PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeInAirLand", 1.0f, 0.10f, 0.10f, default(bool?), default(bool?));
						PawnOwner.Moves[1].ResetCameraLook(0.20f);
					}
				}
				break;
			default:
				break;
		}
	}
	
	public override /*simulated function */void TriggerMove()
	{
		base.TriggerMove();
		switch(MeleeType)
		{
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/:
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJumpStill/*1*/:
				if(((int)MeleeType) == ((int)TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/))
				{
					if(TargetPawn != default)
					{
						SetLookAtTargetLocation(TargetPawn.GetEyeLocation(TargetPawn.Location) - vect(0.0f, 0.0f, 20.0f), 0.20f, default(float?));					
					}
					else
					{
						SetLookAtTargetAngle(PawnOwner.Rotation + LookAtAngle, 0.20f, default(float?));
					}
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeInAir", 1.0f, 0.10f, 0.20f, false, default(bool?));
					HitDetectionBone = "RightFoot";
					bHitDetection = true;
					ImpactMomentum = PawnOwner.Velocity * 1.60f;				
				}
				else
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeInAirStill", 1.0f, 0.10f, 0.20f, false, default(bool?));
					HitDetectionBone = "RightFoot";
					SetTimer(0.250f);
					PawnOwner.Velocity.Z = 0.0f;
					ImpactMomentum = PawnOwner.Velocity * 1.60f;
				}
				if(((TargetPawn) as TdBotPawn) != default)
				{
					((TargetPawn) as TdBotPawn).ActiveDeathAnimType = TdBotPawn.DeathAnimType.DAT_RagdollHard/*1*/;
				}
				break;
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJumpHigh/*2*/:
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeFromAbove", 1.0f, 0.10f, 0.10f, false, default(bool?));
				HitDetectionBone = "LeftFoot";
				SetTimer(0.150f);
				ImpactMomentum = PawnOwner.Velocity * 1.60f;
				break;
			default:
				break;
		}
		UpdateTargetPawn();
	}
	
	public override /*simulated function */void OnTimer()
	{
		bHitDetection = true;
	}
	
	public override /*event */void TriggerDamage(TdPawn Victim)
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector ToTarget = default, HitLocation = default;
		/*local */bool bVerifyHit = default;
		/*local */Core.ClassT<TdDamageType> MeleeDamageType = default;
	
		if(TargetPawn != Victim)
		{
			return;
		}
		ToTarget = TargetPawn.Location - PawnOwner.Location;
		switch(MeleeType)
		{
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/:
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJumpStill/*1*/:
				MeleeDamageType = ClassT<TdDmgType_MeleeAir>();
				bVerifyHit = ((Dot(Normal(ToTarget), ((Vector)(PawnOwner.Rotation)))) > 0.40f) && VSize(ToTarget) < 140.0f;
				break;
			case TdMove_MeleeAir.EMeleeAirType.MAT_FromJumpHigh/*2*/:
				MeleeDamageType = ClassT<TdDmgType_MeleeAir>();
				bVerifyHit = true;
				break;
			default:
				MeleeDamageType = ClassT<TdDmgType_MeleeAir>();
				break;
		}
		if(bVerifyHit)
		{
			HitLocation = PawnOwner.Mesh3p.GetBoneLocation("RightFoot", default(int?));
			Hit.Material = default;
			Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone("Neck");
			Hit.BoneName = "Neck";
			Hit.HitComponent = TargetPawn.Mesh3p;
			Damage = MeleeDamage * FClamp(PawnOwner.GetAverageSpeed(0.250f) / 650.0f, 0.60f, 1.0f);
			DeliverDamage(Damage, HitLocation, ImpactMomentum, MeleeDamageType, Hit);
			if((((int)MeleeType) == ((int)TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/)) && ((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/))
			{
				PawnOwner.SetCustomAnimsBlendOutTime(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.10f);
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MeleeInAirHit", 1.0f, 0.10f, 0.20f, default(bool?), default(bool?));
			}
			if(((((int)MeleeType) == ((int)TdMove_MeleeAir.EMeleeAirType.MAT_FromJumpHigh/*2*/)) || ((int)MeleeType) == ((int)TdMove_MeleeAir.EMeleeAirType.MAT_FromJump/*0*/)))
			{
				PawnOwner.Velocity = Normal(PawnOwner.Location - TargetPawn.Location) * 500.0f;
				PawnOwner.Velocity.Z = 50.0f;
				PawnOwner.Acceleration = Normal(PawnOwner.Velocity);
				PawnOwner.SetIgnoreMoveInput(default(float?));
			}
			if(((int)MeleeState) == ((int)TdMove_MeleeBase.EMeleeState.MS_MeleeAttackFinishing/*2*/))
			{
				ResetCameraLook(0.20f);
			}
			bHitDetection = false;
		}
	}
	
	public TdMove_MeleeAir()
	{
		// Object Offset:0x005D2C0F
		LookAtAngle = new Rotator
		{
			Pitch=-6000,
			Yaw=0,
			Roll=0
		};
		MeleeAirAboveMinAngle = 0.80f;
		MeleeAirAboveMinSeparation = 150.0f;
		MeleeAirAboveMaxSeparation = 500.0f;
		TargetingMaxDistance = 800.0f;
		TraceExtent = new Vector
		{
			X=60.0f,
			Y=60.0f,
			Z=160.0f
		};
		MeleeDamage = 100.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		DisableMovementTime = -1.0f;
		RedoMoveTime = 0.30f;
	}
}
}