namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_AirBarge : TdMove_Barge/*
		native
		config(PawnMovement)*/{
	public /*config */float HeightBoostDuration;
	public /*config */float TotalHeightBoost;
	public /*protected */float HeightBoostLeft;
	public /*protected */Object.Vector PreCollisionVelocity;
	public /*protected */bool bUseAirBargeAnim;
	public /*protected */bool bIsLanding;
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float?));
	}
	
	public override /*simulated function */void StartBargin()
	{
		/*local */int Idx = default;
		/*local */TdPhysicalMaterialProperty TdPhysMatProp = default;
	
		HeightBoostLeft = TotalHeightBoost;
		bIsLanding = false;
		ResetCameraLook(0.30f);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Crouch/*15*/, default(float?));
		bUseAirBargeAnim = false;
		Idx = 0;
		J0x44:{}
		if(Idx < BargeActorList.Length)
		{
			if(BargeActorList[Idx].BargeActor.bInteractable)
			{
				if(BargeActorList[Idx].HitPhysMaterial == default)
				{
					BargeActorList[Idx].HitPhysMaterial = FindPhysicalMaterial(BargeActorList[Idx].BargeActor);
				}
				if(BargeActorList[Idx].HitPhysMaterial != default)
				{
					TdPhysMatProp = ((BargeActorList[Idx].HitPhysMaterial.GetPhysicalMaterialProperty(ClassT<TdPhysicalMaterialProperty>())) as TdPhysicalMaterialProperty);
					if((TdPhysMatProp != default) && TdPhysMatProp.bShouldAirBarge)
					{
						bUseAirBargeAnim = true;					
					}
				}
			}
			++ Idx;
			goto J0x44;
		}
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((bUseAirBargeAnim) ? "AirBargeIdle" : "MeleeInAir"), 1.0f, 0.150f, 0.150f, default(bool?), default(bool?));
	}
	
	public virtual /*function */PhysicalMaterial FindPhysicalMaterial(Actor A)
	{
		/*local *//*editinline */MeshComponent MeshComp = default;
		/*local */MaterialInterface Mat = default;
		/*local */PhysicalMaterial PhysMat = default;
	
		
		// foreach A.ComponentList(ClassT<MeshComponent>(), ref/*probably?*/ MeshComp)
		using var e0 = A.ComponentList(ClassT<MeshComponent>()).GetEnumerator();
		while(e0.MoveNext() && (MeshComp = (MeshComponent)e0.Current) == MeshComp)
		{
			if(MeshComp.PhysMaterialOverride != default)
			{			
				return MeshComp.PhysMaterialOverride;
			}
			using var v = MeshComp.Materials.GetEnumerator();while(v.MoveNext() && (Mat = (MaterialInterface)v.Current) == Mat)
			{
				PhysMat = Mat.GetPhysicalMaterial();
				if(PhysMat != default)
				{
					break;				
					return PhysMat;
				}			
			}				
		}	
		return default;
	}
	
	public override /*simulated function */void Bump(Object.Vector HitNormal, Actor BumpedActor)
	{
		TryGiveBargeDamage(HitNormal, BumpedActor);
	}
	
	public override /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		TryGiveBargeDamage(HitNormal, Wall);
	}
	
	public override /*simulated function */void TryGiveBargeDamage(Object.Vector HitNormal, Actor BargeActor)
	{
		/*local */int Idx = default;
	
		if((bIsLanding || bHasDealtDamage))
		{
			return;
		}
		bHasDealtDamage = true;
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(BargeWaveform);
		Idx = 0;
		J0x49:{}
		if(Idx < BargeActorList.Length)
		{
			if(BargeActorList[Idx].BargeActor.bInteractable)
			{
				HitObject(BargeActorList[Idx].BargeActor, BargeActor.Location, HitNormal, ClassT<TdDmgType_Barge>());
				PreCollisionVelocity = PawnOwner.Velocity;
			}
			++ Idx;
			goto J0x49;
		}
		if(bUseAirBargeAnim)
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.0f);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "AirBargeImpact", 1.0f, 0.0f, 0.10f, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
		PlayLanded();
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		if(SeqNode.AnimSeqName == "AirBargeLand")
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));		
		}
		else
		{
			if(SeqNode.AnimSeqName == "AirBargeImpact")
			{
				PlayLanded();			
			}
			else
			{
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
			}
		}
	}
	
	public virtual /*simulated function */void PlayLanded()
	{
		bIsLanding = true;
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Walking/*1*/, default(float?));
		PawnOwner.UseRootMotion(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "AirBargeLand", 1.0f, 0.10f, 0.10f, true, default(bool?));
	}
	
	public override /*simulated event */void AbortBarge()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.50f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public TdMove_AirBarge()
	{
		// Object Offset:0x0059C7DB
		HeightBoostDuration = 0.250f;
		TotalHeightBoost = 60.0f;
		BargeMinTraceDistance = 300.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckExitToUncontrolledFalling = true;
		bUseCustomCollision = true;
		DisableLookTime = -1.0f;
	}
}
}