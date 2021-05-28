namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeBase : TdPhysicsMove/*
		abstract
		native
		config(PawnMovement)*/{
	public enum EMeleeState 
	{
		MS_MeleePending,
		MS_MeleeAttackNormal,
		MS_MeleeAttackFinishing,
		MS_MeleeHitNormal,
		MS_MeleeHitFinishing,
		MS_MeleeMissNormal,
		MS_MeleeMissFinishing,
		MS_MAX
	};
	
	public TdMove_MeleeBase.EMeleeState MeleeState;
	public bool bTargeting;
	public bool bHitDetection;
	public float TargetingRotationSpeed;
	public TdPawn TargetPawn;
	public float TargetingMaxDistance;
	public Object.Vector HitDetectionStart;
	public Object.Vector HitDetectionLastStart;
	public name HitDetectionBone;
	public Object.Vector TraceOffset;
	public Object.Vector TraceExtent;
	public/*(MeleeCombat)*/ /*config */float MeleeDamage;
	public/*(MeleeCombat)*/ /*config */float MaxMeleeDistance;
	public/*(MeleeCombat)*/ /*config */float MaxMeleeAngle;
	public float CanDoMoveTaserLimit;
	public /*protected */ForceFeedbackWaveform MeleeWaveform;
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		if(PawnOwner.GetMobilityMultiplier() < CanDoMoveTaserLimit)
		{
			return false;
		}
		if((((int)PawnOwner.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Reload/*3*/)) || ((int)PawnOwner.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/))
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */TdPlayerController PC = default;
	
		base.StartMove();
		PC = ((PawnOwner.Controller) as TdPlayerController);
		if(PC != default)
		{
			TargetPawn = PC.GetMeleeTarget(TargetingMaxDistance * 3.0f);
		}
		MeleeState = TdMove_MeleeBase.EMeleeState.MS_MeleeAttackNormal/*1*/;
		PawnOwner.OnTutorialEvent(14);
	}
	
	public override /*simulated function */void StopMove()
	{
		/*local */TdPlayerController PC = default;
	
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, 0.150f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.150f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.150f);
		if((TargetPawn != default) && PawnOwner.Controller.IsA("TdPlayerController"))
		{
			PC = ((PawnOwner.Controller) as TdPlayerController);
			PC.TargetingPawn = TargetPawn;
			PC.TargetingPawnInterp = 0.0f;
		}
	}
	
	public virtual /*event */void TriggerDamage(TdPawn TracePawn)
	{
	
	}
	
	public virtual /*simulated function */void DeliverDamage(float Damage, Object.Vector HitLocation, Object.Vector ImpactMomentum, Core.ClassT<TdDamageType> DamageType, Actor.TraceHitInfo Hit)
	{
		TargetPawn.TakeDamage(((int)(Damage)), PawnOwner.Controller, HitLocation, ImpactMomentum, DamageType, Hit, default(Actor));
		if(PawnOwner.Controller.IsA("TdPlayerController"))
		{
			((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(MeleeWaveform);
		}
	}
	
	public virtual /*simulated function */void TriggerMove()
	{
		if((((int)PawnOwner.WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/)) && PawnOwner.IsLocallyControlled())
		{
			PawnOwner.ServerTriggerMelee(TdPawn.EMeleeServerAction.MSA_TriggerMove/*0*/, (byte)MeleeState);
		}
	}
	
	public virtual /*simulated function */void TriggerHit()
	{
		if((((int)PawnOwner.WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/)) && PawnOwner.IsLocallyControlled())
		{
			PawnOwner.ServerTriggerMelee(TdPawn.EMeleeServerAction.MSA_TriggerHit/*1*/, (byte)MeleeState);
		}
	}
	
	public virtual /*simulated function */void TriggerMiss()
	{
		if((((int)PawnOwner.WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/)) && PawnOwner.IsLocallyControlled())
		{
			PawnOwner.ServerTriggerMelee(TdPawn.EMeleeServerAction.MSA_TriggerMiss/*2*/, (byte)MeleeState);
		}
	}
	
	public virtual /*simulated function */void SetMeleeState(byte NewState)
	{
		MeleeState = ((TdMove_MeleeBase.EMeleeState)NewState);
	}
	
	public virtual /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		return default;
	}
	
	public virtual /*simulated function */void UpdateTargetPawn()
	{
		if(TargetPawn != default)
		{
			TargetPawn.PrepareForMeleeAttack(GetDamageType());
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if(PawnOwner.Controller.IsA("TdPlayerController"))
		{
			UpdateMeleeAutoLockOn(((PawnOwner.Controller) as TdPlayerController), DeltaTime, out_Rotation, ref/*probably?*/ DeltaRot);
		}
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_MeleeBase()
	{
		// Object Offset:0x005CC498
		bTargeting = true;
		TargetingRotationSpeed = 10.0f;
		TargetingMaxDistance = 300.0f;
		TraceExtent = new Vector
		{
			X=5.0f,
			Y=5.0f,
			Z=5.0f
		};
		MeleeDamage = 50.0f;
		MaxMeleeDistance = 180.0f;
		MaxMeleeAngle = 0.50f;
		CanDoMoveTaserLimit = 0.80f;
		MeleeWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C960
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 40,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_MeleeBase.MeleeWaveformObj' */;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
	}
}
}