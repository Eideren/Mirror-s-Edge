// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Barge : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public partial struct /*native */BargeHitInfo
	{
		public Actor BargeActor;
		public Object.Vector HitNormal;
		public Object.Vector HitLocation;
		public PhysicalMaterial HitPhysMaterial;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0059A20B
	//		BargeActor = default;
	//		HitNormal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HitLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HitPhysMaterial = default;
	//	}
	};
	
	public partial struct /*native */BargeDebugInfo
	{
		public Object.Vector BargeNormal;
		[transient] public Object.Vector BargeLocation;
		public float TimeToTarget;
		public Object.Vector BargeStartLocation;
		public Object.Vector BargeEndLocation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0059A3BF
	//		BargeNormal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		BargeLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		TimeToTarget = 0.0f;
	//		BargeStartLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		BargeEndLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public/*protected*/ bool bHasDealtDamage;
	public/*protected*/ bool bBargeWithHands;
	[transient] public/*protected*/ array<TdMove_Barge.BargeHitInfo> BargeActorList;
	[Const] public/*protected*/ float BargeAnimTime;
	[config] public/*protected*/ float BargeMinTraceDistance;
	[config] public/*protected*/ float BargeTraceTime;
	[config] public/*protected*/ float BargeAddOnSpeed;
	[config] public/*protected*/ float BargeMaxSpeed;
	[config] public/*protected*/ float BargeKickThresholdSpeed;
	public/*protected*/ ForceFeedbackWaveform BargeWaveform;
	[transient] public/*protected*/ TdMove_Barge.BargeDebugInfo AnimDebugInfo;
	
	// Export UTdMove_Barge::execFindAdditionalTargets(FFrame&, void* const)
	//public virtual /*native function */void FindAdditionalTargets(Object.Vector StartTrace, Object.Vector EndTrace, Actor IgnoreActor, ref array<TdMove_Barge.BargeHitInfo> ImpactList)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	public virtual /*simulated function */void CalcBargeDamage(Object.Vector StartTrace, Object.Vector EndTrace, ref array<TdMove_Barge.BargeHitInfo> ImpactList)
	{
		/*local */Actor BargableActor = default;
		/*local */TdMove_Barge.BargeHitInfo BargeHit = default;
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */Object.Vector HitL = default, HitN = default;
	
		BargableActor = PawnOwner.Trace(ref/*probably?*/ HitL, ref/*probably?*/ HitN, EndTrace, StartTrace, true, default(Object.Vector?), ref/*probably?*/ Hit, 1);
		if(BargableActor == default)
		{
			return;
		}
		if(BargableActor.bInteractable)
		{
			BargeHit.BargeActor = BargableActor;
			BargeHit.HitNormal = HitN;
			BargeHit.HitNormal.Z = 0.0f;
			BargeHit.HitNormal = Normal(BargeHit.HitNormal);
			BargeHit.HitLocation = HitL;
			BargeHit.HitPhysMaterial = Hit.PhysMaterial;
			ImpactList[ImpactList.Length] = BargeHit;
			FindAdditionalTargets(StartTrace, EndTrace, BargableActor, ref/*probably?*/ ImpactList);		
		}
		else
		{
			if(PassThroughDamage(BargableActor))
			{
				BargableActor.bProjTarget = false;
				CalcBargeDamage(StartTrace, EndTrace, ref/*probably?*/ ImpactList);
				BargableActor.bProjTarget = true;
			}
		}
	}
	
	public virtual /*simulated function */bool PassThroughDamage(Actor HitActor)
	{
		return !HitActor.bBlockActors && (HitActor.IsA("Trigger") || HitActor.IsA("TriggerVolume"));
	}
	
	public override /*function */bool CanDoMove()
	{
		/*local */float BargeTraceDistance = default;
		/*local */Object.Vector TraceStart = default, TraceEnd = default;
		/*local */float BargeSpeed = default;
		/*local */bool bHasForwardVelocity = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		if((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && VSize2D(PawnOwner.Velocity) > BargeKickThresholdSpeed)
		{
			return false;
		}
		BargeSpeed = FMin(BargeMaxSpeed, VSize2D(PawnOwner.Velocity) + BargeAddOnSpeed);
		bHasForwardVelocity = (Dot(((Vector)(PawnOwner.Rotation)), Normal(PawnOwner.Velocity))) > 0.7070f;
		BargeTraceDistance = ((bHasForwardVelocity) ? FMax(BargeMinTraceDistance, BargeSpeed * BargeTraceTime) : BargeMinTraceDistance);
		TraceStart = PawnOwner.Location;
		TraceEnd = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * BargeTraceDistance);
		BargeActorList.Remove(0, BargeActorList.Length);
		CalcBargeDamage(TraceStart, TraceEnd, ref/*probably?*/ BargeActorList);
		if(BargeActorList.Length <= 0)
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		bHasDealtDamage = false;
		bBargeWithHands = false;
		StartBargin();
	}
	
	public virtual /*simulated function */void StartBargin()
	{
		/*local */float AnimPlayRate = default, BargeSpeed = default, PlayerSpeed = default;
		/*local */bool bHasForwardVelocity = default;
		/*local */float TimeToDoor = default;
		/*local */int Idx = default;
	
		PlayerSpeed = VSize2D(PawnOwner.Velocity);
		bHasForwardVelocity = (Dot(((Vector)(PawnOwner.Rotation)), Normal(PawnOwner.Velocity))) > 0.7070f;
		if((PlayerSpeed > BargeKickThresholdSpeed) && bHasForwardVelocity)
		{
			ResetCameraLook(0.30f);
			bBargeWithHands = true;
			BargeSpeed = FMin(BargeMaxSpeed, PlayerSpeed + BargeAddOnSpeed);
			PawnOwner.Velocity = Normal(PawnOwner.Velocity) * BargeSpeed;
			SetPreciseLocation(PawnOwner.Location + (BargeTraceTime * PawnOwner.Velocity), TdMove.EPreciseLocationMode.PLM_Walk/*1*/, BargeSpeed);
			AnimPlayRate = 1.0f;
			Idx = 0;
			J0x101:{}
			if(Idx < BargeActorList.Length)
			{
				if(BargeActorList[Idx].BargeActor.bInteractable)
				{
					TimeToDoor = VSize2D(BargeActorList[Idx].HitLocation - PawnOwner.Location) / BargeSpeed;
					AnimPlayRate = BargeAnimTime / TimeToDoor;
					AnimPlayRate = FClamp(AnimPlayRate, 0.70f, 1.30f);
				}
				++ Idx;
				goto J0x101;
			}
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((name)("BargeInLeft")), AnimPlayRate, 0.20f, 0.0f, false, default(bool?));		
		}
		else
		{
			ResetCameraLook(0.20f);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("MeleeKickObject")), 1.0f, 0.10f, 0.10f, false, default(bool?));
			PawnOwner.SetIgnoreMoveInput(0.60f);
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.20f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.20f);
		BargeActorList.Remove(0, BargeActorList.Length);
	}
	
	public virtual /*simulated event */void AbortBarge()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.50f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public virtual /*simulated function */void BargeHitNotify()
	{
		/*local */int Idx = default;
	
		if(bHasDealtDamage)
		{
			return;
		}
		bHasDealtDamage = true;
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(BargeWaveform);
		Idx = 0;
		J0x3E:{}
		if(Idx < BargeActorList.Length)
		{
			HitObject(BargeActorList[Idx].BargeActor, BargeActorList[Idx].HitLocation, BargeActorList[Idx].HitNormal, ClassT<TdDmgType_Barge>());
			++ Idx;
			goto J0x3E;
		}
	}
	
	public override /*simulated function */void Bump(Object.Vector HitNormal, Actor BumpedActor)
	{
		TryGiveBargeDamage(HitNormal, BumpedActor);
	}
	
	public override /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		TryGiveBargeDamage(HitNormal, Wall);
	}
	
	public virtual /*simulated function */void TryGiveBargeDamage(Object.Vector HitNormal, Actor BargeActor)
	{
		/*local */int Idx = default;
	
		if(bBargeWithHands)
		{
			if(((BargeActor == default) || bHasDealtDamage))
			{
				return;
			}
			bHasDealtDamage = true;
			SetPreciseLocation(PawnOwner.Location, TdMove.EPreciseLocationMode.PLM_Walk/*1*/, VSize2D(PawnOwner.Velocity));
			((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(BargeWaveform);
			Idx = 0;
			J0x80:{}
			if(Idx < BargeActorList.Length)
			{
				HitObject(BargeActorList[Idx].BargeActor, BargeActorList[Idx].HitLocation, BargeActorList[Idx].HitNormal, ClassT<TdDmgType_Barge>());
				++ Idx;
				goto J0x80;
			}
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, ((name)("BargeOutLeft")), 1.0f, 0.0f, 0.20f, false, default(bool?));
		}
	}
	
	public virtual /*simulated function */void HitObject(Actor Victim, Object.Vector HitLocation, Object.Vector HitNormal, Core.ClassT<DamageType> inDamageType)
	{
		/*local */KActor RBActor = default;
	
		Victim.TakeDamage(100, PawnOwner.Controller, HitLocation, -HitNormal, inDamageType, default(Actor.TraceHitInfo?), default(Actor));
		RBActor = ((Victim) as KActor);
		if(RBActor != default)
		{
			RBActor.ApplyImpulse(-HitNormal, inDamageType.DefaultAs<DamageType>().KDamageImpulse, HitLocation, default(Actor.TraceHitInfo?));
		}
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_Barge()
	{
		var Default__TdMove_Barge_BargeWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C282
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 50,
					RightAmplitude = 30,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.20f,
				},
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 30,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.30f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_Barge.BargeWaveformObj' */;
		// Object Offset:0x0059B951
		BargeAnimTime = 0.30f;
		BargeMinTraceDistance = 90.0f;
		BargeTraceTime = 0.50f;
		BargeAddOnSpeed = 200.0f;
		BargeMaxSpeed = 500.0f;
		BargeKickThresholdSpeed = 250.0f;
		BargeWaveform = Default__TdMove_Barge_BargeWaveformObj/*Ref ForceFeedbackWaveform'Default__TdMove_Barge.BargeWaveformObj'*/;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bTwoHandedFullBodyAnimations = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		RedoMoveTime = 0.10f;
		MinLookConstraint = new Rotator
		{
			Pitch=-14000,
			Yaw=-5000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16384,
			Yaw=5000,
			Roll=32768
		};
	}
}
}