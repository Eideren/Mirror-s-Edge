namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Disarmed : TdPhysicsMove/*
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */AnimNodeSequence AnimationSequence = default;
		/*local */TdPawn.CustomNodeType NodeType = default;
	
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.10f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.10f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_LowerBody/*5*/, 0.10f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.10f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
		NodeType = TdPawn.CustomNodeType.CNT_CannedUpperBody/*1*/;
		AnimationSequence = PawnOwner.GetCustomAnimation(((TdPawn.CustomNodeType)NodeType));
		if((AnimationSequence == default) || AnimationSequence.AnimSeqName != "MeleeStart")
		{
			NodeType = TdPawn.CustomNodeType.CNT_Canned/*0*/;
			AnimationSequence = PawnOwner.GetCustomAnimation(((TdPawn.CustomNodeType)NodeType));
		}
		if((AnimationSequence == default) || AnimationSequence.AnimSeqName != "MeleeStart")
		{		
		}
		else
		{
			AnimationSequence.Rate = 0.50f;
			PawnOwner.SetCustomAnimsBlendOutTime(((TdPawn.CustomNodeType)NodeType), 0.10f);
		}
		PawnOwner.StopPhysicsBodyImpact();
		base.StartMove();
	}
	
	public override /*simulated function */void StopMove()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, 0.20f);
		RootOffset = vect(0.0f, 0.0f, 0.0f);
		base.StopMove();
	}
	
	public override /*simulated function */void ReachedPreciseLocation()
	{
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
	}
	
	public virtual /*simulated function */void SetLookAtDirection(Object.Rotator LookAtDirection)
	{
		SetPreciseRotation(LookAtDirection, 0.10f);
		PawnOwner.DesiredRotation = LookAtDirection;
	}
	
	public virtual /*function */void PlayDisarmStart(name DisarmAnim, /*optional */bool? _bUseRootMotion = default, /*optional */bool? _bUseRootRotation = default)
	{
		var bUseRootMotion = _bUseRootMotion ?? false;
		var bUseRootRotation = _bUseRootRotation ?? false;
		if(PawnOwner.Weapon.IsA("TdWeapon_Shotgun_Remington870"))
		{
			SetTimer(0.80f);		
		}
		else
		{
			if(PawnOwner.Weapon.IsA("TdWeapon_Shotgun_Neostead"))
			{
				SetTimer(1.40f);
			}
		}
		PawnOwner.UseRootMotion(bUseRootMotion);
		PawnOwner.UseRootRotation(bUseRootRotation);
		((PawnOwner) as TdBotPawn).bEnableInverseKinematics = false;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, DisarmAnim, 1.0f, 0.10f, 0.0f, bUseRootMotion, bUseRootRotation);
		if(PawnOwner.Weapon != default)
		{
			PawnOwner.MyWeapon.PlayCustomWeaponAnimation(DisarmAnim);
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.DetachWeaponFromHand(PawnOwner.Weapon);
	}
	
	public override /*simulated function */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		/*local */Actor.TraceHitInfo HitInfo = default;
		/*local */Object.Vector damageMomentum = default;
		/*local */Controller Killer = default;
		/*local */TdAIController BotVictim = default;
	
		PawnOwner.Weapon.bDropOnDeath = false;
		PawnOwner.InvManager.DiscardInventory();
		damageMomentum = vect(0.0f, 0.0f, 0.0f);
		HitInfo.BoneName = "Neck";
		BotVictim = BotOwner.myController;
		if((BotVictim != default) && BotVictim.Enemy != default)
		{
			Killer = BotVictim.Enemy.Controller;
		}
		BotOwner.ActiveDeathAnimType = TdBotPawn.DeathAnimType.DAT_Ragdoll/*0*/;
		PawnOwner.TakeDamage(PawnOwner.Health, Killer, PawnOwner.Mesh3p.GetBoneLocation("Neck", default), damageMomentum, ClassT<TdDmgType_MeleeDisarm>(), HitInfo, default);
	}
	
	public virtual /*function */void AbortDisarm()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, 0.20f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);
	}
	
	public TdMove_Disarmed()
	{
		// Object Offset:0x005B3AD4
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bDisableCollision = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
	}
}
}