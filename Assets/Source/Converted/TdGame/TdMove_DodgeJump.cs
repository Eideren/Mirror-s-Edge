namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_DodgeJump : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(DodgeJump)*/ /*config */float BaseJumpZ;
	public/*(DodgeJump)*/ /*config */float JumpAddXY;
	public/*(DodgeJump)*/ /*config */float StrafeThreshold;
	public/*(DodgeJump)*/ /*config */float DodgeJumpInertiaConservation;
	public/*(DodgeJump)*/ /*config */float JumpBlendInTime;
	public/*(DodgeJump)*/ /*config */float JumpBlendOutTime;
	public/*(DodgeJump)*/ /*config */float LookAtAIVelThreshold;
	public/*(DodgeJump)*/ /*config */float LookAtAITraceDistance;
	public/*(DodgeJump)*/ /*config */float LookAtAIRadiusThreshold;
	
	public override /*function */bool CanDoMove()
	{
		if(!PawnOwner.bMoveActionMax)
		{
			return false;
		}
		if(PawnOwner.bUncontrolledSlide)
		{
			return false;
		}
		if(!(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/)) || ((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Right/*2*/))
		{
			return false;
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector DodgeDirection = default;
	
		base.StartMove();
		if(((int)PawnOwner.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Left/*1*/))
		{
			DodgeDirection = (((float)(-1)) * JumpAddXY) * Normal(Cross(vect(0.0f, 0.0f, 1.0f), ((Vector)(PawnOwner.Rotation))));
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("dodgejumpleft")), 1.0f, JumpBlendInTime, JumpBlendOutTime, default, default);		
		}
		else
		{
			DodgeDirection = JumpAddXY * Normal(Cross(vect(0.0f, 0.0f, 1.0f), ((Vector)(PawnOwner.Rotation))));
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("dodgejumpright")), 1.0f, JumpBlendInTime, JumpBlendOutTime, default, default);
		}
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		PawnOwner.Velocity = DodgeDirection + (DodgeJumpInertiaConservation * PawnOwner.Velocity);
		PawnOwner.Velocity.Z = BaseJumpZ;
		if(((PawnOwner.Base != default) && !PawnOwner.Base.bWorldGeometry) && PawnOwner.Base.Velocity.Z > 0.0f)
		{
			PawnOwner.Velocity.Z += PawnOwner.Base.Velocity.Z;
		}
		PawnOwner.Acceleration = Normal(PawnOwner.Velocity);
		CheckForAimAssistTarget();
	}
	
	public virtual /*simulated function */void CheckForAimAssistTarget()
	{
		/*local */Object.Vector CameraLocation = default, CamRotX = default, CamRotY = default, CamRotZ = default, Aim = default, TargetLocation = default,
			DeltaAim = default;
	
		/*local */Object.Rotator CameraOrientation = default;
		/*local */float TargetHeight = default, TargetRadius = default, DistanceToTarget = default, DeltaAimDistX = default;
		/*local */TdPawn AATarget = default;
	
		if(((PawnOwner.Controller) as TdPlayerController) != default)
		{
			AATarget = ((PawnOwner.Controller) as TdPlayerController).GetAATarget(LookAtAITraceDistance);
		}
		if(AATarget == default)
		{
			return;
		}
		TargetLocation = AATarget.Location;
		AATarget.GetBoundingCylinder(ref/*probably?*/ TargetHeight, ref/*probably?*/ TargetRadius);
		PawnOwner.Controller.GetPlayerViewPoint(ref/*probably?*/ CameraLocation, ref/*probably?*/ CameraOrientation);
		GetAxes(CameraOrientation, ref/*probably?*/ CamRotX, ref/*probably?*/ CamRotY, ref/*probably?*/ CamRotZ);
		DistanceToTarget = VSize(TargetLocation - CameraLocation);
		Aim = CameraLocation + (CamRotX * DistanceToTarget);
		PointDistToLine(Aim, TargetLocation - CameraLocation, CameraLocation, ref/*probably?*/ DeltaAim);
		DeltaAim = DeltaAim - Aim;
		DeltaAim = ProjectOnTo(DeltaAim, CamRotY);
		DeltaAimDistX = VSize2D(DeltaAim);
		if(DeltaAimDistX > LookAtAIRadiusThreshold)
		{
			return;
		}
		if(((Dot(AATarget.Velocity, ((Vector)(PawnOwner.Rotation)))) < 0.0f) && VSize2D(AATarget.Velocity) > LookAtAIVelThreshold)
		{
			((PawnOwner.Controller) as TdPlayerController).TargetingPawn = AATarget;
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
	
	public TdMove_DodgeJump()
	{
		// Object Offset:0x005B528F
		BaseJumpZ = 300.0f;
		JumpAddXY = 600.0f;
		StrafeThreshold = 0.990f;
		DodgeJumpInertiaConservation = 0.30f;
		JumpBlendInTime = 0.10f;
		JumpBlendOutTime = 0.20f;
		LookAtAIVelThreshold = 200.0f;
		LookAtAITraceDistance = 250.0f;
		LookAtAIRadiusThreshold = 90.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerGrabbing";
		bCheckExitToFalling = true;
		ExitToFallingZSpeed = -190.0f;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 75.0f,
			Medium = 75.0f,
			Hard = 75.0f,
		};
		DisableMovementTime = -1.0f;
		RedoMoveTime = 0.30f;
	}
}
}