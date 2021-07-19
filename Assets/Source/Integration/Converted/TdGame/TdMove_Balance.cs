namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Balance : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public TdBalanceWalkVolume Volume;
	public float CurrentParamOnCurve;
	public bool bIsFacingForward;
	public bool bIsInDangerMode;
	public bool bHasFallen;
	public float BalanceFactor;
	public float CounterTimer;
	public Object.Rotator CurrentMoveDirection;
	public float ExternalForce;
	[config] public float TimeToCounter;
	[config] public float GravityInfluence;
	[config] public float ControlInfluence;
	[config] public float SpeedInfluence;
	[config] public float CameraInfluence;
	
	public override /*function */bool CanDoMove()
	{
		if(((((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) && ((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Crouch/*15*/)) && ((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Slide/*16*/))
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector PointOnSpline = default, SplineDirection = default;
		/*local */float NormalizedParam = default, Forwardness = default;
	
		base.StartMove();
		Volume.FindClosestPointOnDSpline(PawnOwner.Location, ref/*probably?*/ PointOnSpline, ref/*probably?*/ CurrentParamOnCurve, default(int?));
		NormalizedParam = CurrentParamOnCurve / ((float)(Volume.NumSplineSegments));
		SplineDirection = Volume.GetSlopeOnSpline(NormalizedParam);
		Forwardness = Dot(((Vector)(PawnOwner.Rotation)), Normal(SplineDirection));
		bIsFacingForward = Forwardness > 0.0f;
		SetPreciseRotation(((Rotator)(SplineDirection * ((bIsFacingForward) ? 1.0f : -1.0f))), 0.20f);
		BalanceFactor = Dot((((bIsFacingForward) ? -0.20f : 0.20f) * ((Vector)(PawnOwner.Rotation))), (Cross(SplineDirection, vect(0.0f, 0.0f, 1.0f))));
		ExternalForce = 0.0f;
		bHasFallen = false;
		bIsInDangerMode = false;
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			ResetCameraLook(0.50f);
			PawnOwner.DropWeapon();
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		PawnOwner.UseRootMotion(false);
		base.StopMove();
		PawnOwner.FaceRotationTimeLeft = 0.40f;
	}
	
	public override /*simulated function */int GetMinLookConstrainYaw()
	{
		return ((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) ? -2000 : MinLookConstraint.Yaw);
	}
	
	public override /*simulated function */int GetMaxLookConstrainYaw()
	{
		return ((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) ? 2000 : MaxLookConstraint.Yaw);
	}
	
	public override /*simulated function */int GetMinLookConstrainPitch()
	{
		return ((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) ? -2000 : MinLookConstraint.Pitch);
	}
	
	public override /*simulated function */int GetMaxLookConstrainPitch()
	{
		return ((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) ? 2000 : MaxLookConstraint.Pitch);
	}
	
	public virtual /*simulated event */void Falloff()
	{
		bHasFallen = true;
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		if(BalanceFactor < 0.0f)
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("walkbalancefalloffleft")), 1.0f, 0.30f, 0.30f, true, default(bool?));		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("walkbalancefalloffright")), 1.0f, 0.30f, 0.30f, true, default(bool?));
		}
		PawnOwner.UseRootMotion(true);
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		SetMoveTimer(0.10f, false, "GoIntoFalling");
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Falling/*2*/, default(float?));
	}
	
	public virtual /*simulated function */void GoIntoFalling()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public override /*simulated event */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.10f);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Landing/*20*/, default(bool?), default(bool?));
	}
	
	public TdMove_Balance()
	{
		// Object Offset:0x0059EDBE
		TimeToCounter = 0.80f;
		GravityInfluence = 0.30f;
		ControlInfluence = 1.50f;
		SpeedInfluence = 2.50f;
		CameraInfluence = 0.30f;
		ControllerState = (name)"PlayerBalanceWalk";
		SpeedModifier = 0.340f;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bDisableControllerFacingPawnYawRotation = true;
		bAvoidLedges = false;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 50.0f,
			Medium = 50.0f,
			Hard = 50.0f,
		};
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		RedoMoveTime = 0.50f;
		MinLookConstraint = new Rotator
		{
			Pitch=-13000,
			Yaw=-6000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=25000,
			Yaw=6000,
			Roll=32768
		};
		AnimBlendTime = 0.40f;
	}
}
}