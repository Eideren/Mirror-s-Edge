// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Grab : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public enum EGrabType 
	{
		GT_LegsOnWall,
		GT_LegsFree,
		GT_MAX
	};
	
	public enum EShimmyType 
	{
		Shimmy,
		ShimmyLong,
		ShimmyAroundCorner,
		NoShimmy,
		EShimmyType_MAX
	};
	
	public enum EGrabFoldedType 
	{
		GFT_None,
		GFT_Start,
		GFT_End,
		GFT_MAX
	};
	
	[Category("Grab")] [config] public Object.Vector GrabDesiredLedgeOffset;
	[Category("Grab")] [config] public float GrabMaxAngle;
	[Category("Grab")] [config] public float GrabMinGrabableZNormal;
	[Category("Grab")] [config] public float HangFreeZDistanceCheck;
	public float RelativeExtent;
	public float DistanceToWallFromFeet;
	public TdMove_GrabTransfer TransferMove;
	[config] public float StartTurningAngle;
	public bool bIsWithinForwardView;
	public bool bIsTurnedRight;
	public bool bSlopedLedge;
	public/*private*/ bool bClimpUpFoldedActionReceived;
	public/*private*/ bool bRequestDropDown;
	public/*private*/ bool bHangFreeVertigoEffect;
	public/*private*/ bool bGrabFromVerticalWallrun;
	public bool bGrabFromHighZSpeed;
	public name PendingShimmyCornerAnimation;
	public TdMove_Grab.EGrabType GrabType;
	public TdMove_Grab.EGrabType PreviousGrabType;
	public TdMove_Grab.EShimmyType CurrentShimmyMove;
	public TdMove_Grab.EGrabFoldedType CurrentFoldedType;
	public Object.Rotator HangFreeMinLookContraint;
	public Object.Rotator HangFreeMaxLookContraint;
	public Object.Rotator SlopeMinLookContraint;
	public Object.Rotator SlopeMaxLookContraint;
	public Object.Rotator ShimmyAroundCornerMinLookContraint;
	public Object.Rotator ShimmyAroundCornerMaxLookContraint;
	public Object.Rotator ShimmyAroundCornerFreeMinLookContraint;
	public Object.Rotator ShimmyAroundCornerFreeMaxLookContraint;
	public int TargetYaw;
	public Object.Vector TargetLocation;
	public float ShimmyVelocity;
	public float ShimmyTime;
	public float LastShimmyTimeSeconds;
	public float DisableShimmyTime;
	public TdAnimNodeSequence CustomAnimNode;
	public float StartLookingAtLedgeTime;
	public float StopLookingAtLedgeTime;
	
	// Export UTdMove_Grab::execCheckWallLegPlacement(FFrame&, void* const)
	//public virtual /*native function */TdMove_Grab.EGrabType CheckWallLegPlacement()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public override /*function */bool CanDoMove()
	{
		if(((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_IntoGrab/*14*/))
		{
			return false;
		}
		if(!IsFacingLedge())
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */TdPlayerPawn PlayerPawn = default;
	
		PlayerPawn = ((PawnOwner) as TdPlayerPawn);
		PlayerPawn.SetAmbientShadowDirection(PawnOwner.MoveNormal, true);
		bSlopedLedge = PawnOwner.MoveLedgeNormal.Z < 0.9990f;
		RelativeExtent = CalculateRelativeExtent(PawnOwner.CylinderComponent.CollisionRadius);
		RootOffset.X += (RelativeExtent + ((IsHangingFree()) ? 0.0f : 1.0f));
		if(bSlopedLedge && IsHangingFree())
		{
			RootOffset.Z += 3.0f;
		}
		base.StartMove();
		SetMoveTimer(0.20f, false, "SetDPG");
		if(PawnOwner.Weapon != default)
		{
			if(((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
			{
				PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);			
			}
			else
			{
				PawnOwner.SetUnarmed();
			}
		}
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		TargetYaw = -1;
		TransferMove = ((PawnOwner.Moves[31]) as TdMove_GrabTransfer);
		CurrentShimmyMove = TdMove_Grab.EShimmyType.NoShimmy/*3*/;
		PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_None/*0*/;
		UpdateViewConstraints();
		bHangFreeVertigoEffect = false;
		bClimpUpFoldedActionReceived = false;
		bRequestDropDown = false;
		LastShimmyTimeSeconds = PawnOwner.WorldInfo.TimeSeconds;
		if(bSlopedLedge)
		{
			EnableGrabIK();
		}
		if(PlayerPawn.bTakeFallDamage)
		{
			PlayerPawn.TakeFallingDamage();
			PlayerPawn.EnterFallingHeight = PlayerPawn.Location.Z;
		}
	}
	
	public virtual /*function */void SetDPG()
	{
		/*local */TdPlayerPawn Pawn = default;
	
		Pawn = ((PawnOwner) as TdPlayerPawn);
		if(Pawn != default)
		{
			Pawn.SetFirstPersonDPG(Scene.ESceneDepthPriorityGroup.SDPG_Intermediate/*2*/);
			Pawn.Mesh3p.bCullModulatedShadowOnBackfaces = false;
			Pawn.SetShadowType(Pawn.Mesh1p, LightComponent.ELightShadowMode.LightShadow_Normal/*0*/);
			Pawn.SetShadowType(Pawn.Mesh3p, LightComponent.ELightShadowMode.LightShadow_ModulateBetter/*2*/);
		}
	}
	
	public virtual /*simulated function */void EnableGrabIK()
	{
		/*local */Object.Vector LeftHandLocation = default, RightHandLocation = default, Right = default;
	
		Right = Cross(PawnOwner.MoveNormal, PawnOwner.MoveLedgeNormal);
		LeftHandLocation = PawnOwner.MoveLedgeLocation - (Right * 20.0f);
		RightHandLocation = PawnOwner.MoveLedgeLocation + (Right * 20.0f);
		LeftHandLocation.Z -= 11.0f;
		RightHandLocation.Z -= 11.0f;
		LeftHandLocation += (PawnOwner.MoveNormal * 3.0f);
		RightHandLocation += (PawnOwner.MoveNormal * 3.0f);
		PawnOwner.LeftHandWorldIKController.SetSkelControlStrength(1.0f, 0.10f);
		PawnOwner.LeftHandWorldIKController.EffectorLocation = LeftHandLocation;
		PawnOwner.LeftHandWorldIKController.EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_WorldSpace/*0*/;
		PawnOwner.RightHandWorldIKController.SetSkelControlStrength(1.0f, 0.10f);
		PawnOwner.RightHandWorldIKController.EffectorLocation = RightHandLocation;
		PawnOwner.RightHandWorldIKController.EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_WorldSpace/*0*/;
	}
	
	public override /*simulated function */void StopMove()
	{
		/*local */TdPlayerPawn PlayerPawn = default;
	
		PlayerPawn = ((PawnOwner) as TdPlayerPawn);
		PlayerPawn.ResetAmbientShadowDirection(true);
		base.StopMove();
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.FaceRotationTimeLeft = 0.50f;
		PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
		TransferMove = default;
		if((((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_GrabPullUp/*10*/)) && !bRequestDropDown)
		{
			PawnOwner.DisableHandsWorldIK(default(float?));
		}
		if(((int)CurrentFoldedType) != ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		}
		PlayerPawn.Mesh3p.bCullModulatedShadowOnBackfaces = true;
		PlayerPawn.SetShadowType(PlayerPawn.Mesh1p, LightComponent.ELightShadowMode.LightShadow_Modulate/*1*/);
		PlayerPawn.SetShadowType(PlayerPawn.Mesh3p, LightComponent.ELightShadowMode.LightShadow_Modulate/*1*/);
		RootOffset = DefaultAs<TdMove>().RootOffset;
		bHangFreeVertigoEffect = false;
		bGrabFromVerticalWallrun = false;
		bRequestDropDown = false;
		bConstrainLook = true;
		bGrabFromHighZSpeed = false;
	}
	
	// Export UTdMove_Grab::execIsHangingFree(FFrame&, void* const)
	//public virtual /*native simulated function */bool IsHangingFree()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public virtual /*simulated function */bool IsFacingLedge()
	{
		/*local */float DotProduct = default;
	
		DotProduct = Dot(-PawnOwner.MoveNormal, ((Vector)(PawnOwner.Rotation)));
		if(DotProduct < Cos((GrabMaxAngle * 3.1415930f) / 180.0f))
		{
			return false;
		}
		return true;
	}
	
	public virtual /*simulated event */void UpdateGrabType(bool bMovingLeft)
	{
		/*local */TdAnimNodeSequence AnimNodeSeq1pPrev = default, AnimNodeSeq3pPrev = default, AnimNodeSeq1p = default, AnimNodeSeq3p = default;
		/*local */float PrevNormalizedPosition = default;
	
		UpdateViewConstraints();
		if(PawnOwner.GrabAnimNode1p != default)
		{
			PawnOwner.GrabAnimNode1p.SetActiveMove(((((int)GrabType) == ((int)TdMove_Grab.EGrabType.GT_LegsOnWall/*0*/)) ? 0 : 1), default(bool?));
		}
		if(PawnOwner.GrabAnimNode3p != default)
		{
			PawnOwner.GrabAnimNode3p.SetActiveMove(((((int)GrabType) == ((int)TdMove_Grab.EGrabType.GT_LegsOnWall/*0*/)) ? 0 : 1), default(bool?));
		}
		AnimNodeSeq1pPrev = ((PawnOwner.CustomFullBodyNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		AnimNodeSeq3pPrev = ((PawnOwner.CustomFullBodyNode3p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		PawnOwner.CustomFullBodyNode1p.SetBlendOutTime(-1.0f);
		PawnOwner.CustomFullBodyNode3p.SetBlendOutTime(-1.0f);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((IsHangingFree()) ? ((bMovingLeft) ? "HangFreeStrafeLeft" : "HangFreeStrafe") : ((bMovingLeft) ? "HangStrafeLeft" : "HangStrafeRight")), 1.0f, 0.20f, 0.0f, default(bool?), default(bool?));
		PrevNormalizedPosition = AnimNodeSeq1pPrev.GetNormalizedPosition();
		AnimNodeSeq1p = ((PawnOwner.CustomFullBodyNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		AnimNodeSeq3p = ((PawnOwner.CustomFullBodyNode3p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		AnimNodeSeq1p.SetPosition(PrevNormalizedPosition * AnimNodeSeq1pPrev.GetAnimPlaybackLength(), false);
		AnimNodeSeq3p.SetPosition(PrevNormalizedPosition * AnimNodeSeq3pPrev.GetAnimPlaybackLength(), false);
		AnimNodeSeq1p.bResetOnBecomeRelevant = false;
		AnimNodeSeq3p.bResetOnBecomeRelevant = false;
		RootOffset.X += ((IsHangingFree()) ? -1.0f : 1.0f);
		PawnOwner.SetRootOffset(RootOffset, 0.30f, default(SkelControlBase.EBoneControlSpace));
	}
	
	public virtual /*simulated function */void SetGrabType(TdMove_Grab.EGrabType NewGrabType)
	{
		PreviousGrabType = ((TdMove_Grab.EGrabType)GrabType);
		GrabType = ((TdMove_Grab.EGrabType)NewGrabType);
	}
	
	public virtual /*simulated function */TdMove_Grab.EGrabType GetGrabType()
	{
		return ((TdMove_Grab.EGrabType)GrabType);
	}
	
	public virtual /*simulated function */void SetGrabFromVerticalWallrun(bool bNewValue)
	{
		bGrabFromVerticalWallrun = bNewValue;
	}
	
	public virtual /*simulated function */void EnableFoldedHang()
	{
		CurrentFoldedType = TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("HangFoldedStart")), 1.0f, 0.20f, 0.0f, default(bool?), default(bool?));
		bConstrainLook = false;
	}
	
	public virtual /*simulated function */TdMove_Grab.EGrabFoldedType GetCurrentFoldedType()
	{
		return ((TdMove_Grab.EGrabFoldedType)CurrentFoldedType);
	}
	
	public virtual /*simulated function */void SetCurrentFoldedType(TdMove_Grab.EGrabFoldedType NewFoldedType)
	{
		CurrentFoldedType = ((TdMove_Grab.EGrabFoldedType)NewFoldedType);
	}
	
	public virtual /*private final simulated function */bool CanDropDown()
	{
		if(bHangFreeVertigoEffect)
		{
			return false;
		}
		if(bRequestDropDown)
		{
			return false;
		}
		return ((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_None/*0*/);
	}
	
	public virtual /*simulated function */bool CanPullUp()
	{
		if(bHangFreeVertigoEffect)
		{
			return false;
		}
		if(bGrabFromVerticalWallrun && MoveActiveTime < 1.0f)
		{
			return false;
		}
		if(((int)GetCurrentFoldedType()) == ((int)TdMove_Grab.EGrabFoldedType.GFT_End/*2*/))
		{
			return false;
		}
		if(bRequestDropDown)
		{
			return false;
		}
		if(bGrabFromHighZSpeed && MoveActiveTime < 1.0f)
		{
			return false;
		}
		return true;
	}
	
	public virtual /*simulated function */void RequestDropDown()
	{
		if(CanDropDown())
		{
			if(((((int)CurrentShimmyMove) != ((int)TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/)) && ((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_None/*0*/)) && (!bGrabFromVerticalWallrun || bGrabFromVerticalWallrun && MoveActiveTime > 1.0f))
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((IsHangingFree()) ? "HangFreeEnd" : "HangEnd"), 1.0f, 0.10f, 0.20f, default(bool?), default(bool?));
				PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Falling/*2*/, 0.20f);
				SetMoveTimer(0.20f, false, "OnChangeDPGTimer");			
			}
			else
			{
				DropDown();
			}
			bRequestDropDown = true;
			PawnOwner.DisableHandsWorldIK(0.30f);
		}
	}
	
	public virtual /*simulated function */void OnChangeDPGTimer()
	{
		/*local */TdPlayerPawn PlayerPawn = default;
	
		PlayerPawn = ((PawnOwner) as TdPlayerPawn);
		if(PlayerPawn != default)
		{
			PlayerPawn.SetFirstPersonDPG(Scene.ESceneDepthPriorityGroup.SDPG_Foreground/*3*/);
		}
	}
	
	public virtual /*private final simulated function */void DropDown()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */bool bShouldTriggerHangFreeTurn = default;
		/*local */Object.Rotator ControllerDeltaRot = default, LookAtAfterVertigo = default;
		/*local */int HangFreeTurnConstraintAngleDelta = default;
	
		if((bHangFreeVertigoEffect || ((int)CurrentFoldedType) != ((int)TdMove_Grab.EGrabFoldedType.GFT_None/*0*/)))
		{
			DeltaRot.Pitch = 0;
			DeltaRot.Yaw = 0;
		}
		if(((((DeltaRot.Yaw > 0) || DeltaRot.Yaw < 0)) || ((DeltaRot.Pitch > 0) || DeltaRot.Pitch < 0)))
		{
			AbortLookAtTarget();
		}
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		ControllerDeltaRot = Normalize(out_Rotation) - Normalize(PawnOwner.Rotation);
		ControllerDeltaRot = Normalize(ControllerDeltaRot);
		bIsWithinForwardView = (((float)(ControllerDeltaRot.Yaw)) < StartTurningAngle) && ((float)(ControllerDeltaRot.Yaw)) > -StartTurningAngle;
		bIsTurnedRight = ControllerDeltaRot.Yaw >= 0;
		HangFreeTurnConstraintAngleDelta = 750;
		bShouldTriggerHangFreeTurn = ((IsHangingFree()) && ((ControllerDeltaRot.Yaw >= (HangFreeMaxLookContraint.Yaw - HangFreeTurnConstraintAngleDelta)) || ControllerDeltaRot.Yaw <= (HangFreeMinLookContraint.Yaw + HangFreeTurnConstraintAngleDelta))) && !bHangFreeVertigoEffect;
		if(!IsHangingFree())
		{
			if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_None/*0*/))
			{
				if(((float)(ControllerDeltaRot.Yaw)) > StartTurningAngle)
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "HangTurnRightStart", 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
					PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_Start/*1*/;
					SetTimer(0.20f);				
				}
				else
				{
					if(((float)(ControllerDeltaRot.Yaw)) < -StartTurningAngle)
					{
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "HangTurnLeftStart", 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
						PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_Start/*1*/;
						SetTimer(0.20f);					
					}
					else
					{
						if(MoveActiveTime > 1.0f)
						{
							ClearTimer();
						}
					}
				}			
			}
			else
			{
				if(bIsWithinForwardView)
				{
					if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_Idle/*3*/))
					{
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((bIsTurnedRight) ? "HangTurnRightEnd" : "HangTurnLeftEnd"), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
						PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_End/*2*/;
						SetTimer(0.60f);					
					}
					else
					{
						if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_Start/*1*/))
						{
							PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
							PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_None/*0*/;
						}
					}
				}
			}		
		}
		else
		{
			PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_None/*0*/;
		}
		if((((MoveActiveTime > StartLookingAtLedgeTime) && MoveActiveTime < StopLookingAtLedgeTime) && ((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_None/*0*/)) && !bGrabFromVerticalWallrun)
		{
			SetLookAtTargetLocation(PawnOwner.MoveLedgeLocation, 0.30f, 0.250f);
		}
		if(bShouldTriggerHangFreeTurn)
		{
			bHangFreeVertigoEffect = true;
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((bIsTurnedRight) ? "HangFreeTurnRight" : "HangFreeTurnLeft"), 1.0f, 0.20f, 0.20f, default(bool?), default(bool?));
			LookAtAfterVertigo = PawnOwner.Rotation;
			LookAtAfterVertigo.Pitch = 0;
			SetLookAtTargetAngle(LookAtAfterVertigo, 0.20f, 0.20f);
			bConstrainLook = false;
			SetTimer(1.750f);
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		/*local */Object.Rotator LookAtAngle = default;
	
		if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_End/*2*/))
		{
			PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_None/*0*/;		
		}
		else
		{
			if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_Start/*1*/))
			{
				PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_Idle/*3*/;			
			}
			else
			{
				AbortLookAtTarget();
				LookAtAngle = PawnOwner.Rotation;
				LookAtAngle.Pitch += 9000;
				SetLookAtTargetAngle(LookAtAngle, 0.20f, 0.50f);
			}
		}
	}
	
	public virtual /*simulated function */void UpdateViewConstraints()
	{
		if(bSlopedLedge)
		{
			MinLookConstraint = SlopeMinLookContraint;
			MaxLookConstraint = SlopeMaxLookContraint;
			if(IsHangingFree())
			{
				MinLookConstraint.Pitch = HangFreeMinLookContraint.Pitch;
				MaxLookConstraint.Pitch = HangFreeMaxLookContraint.Pitch;
			}		
		}
		else
		{
			if(((int)CurrentShimmyMove) == ((int)TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/))
			{
				MinLookConstraint = ((IsHangingFree()) ? ShimmyAroundCornerFreeMinLookContraint : ShimmyAroundCornerMinLookContraint);
				MaxLookConstraint = ((IsHangingFree()) ? ShimmyAroundCornerFreeMaxLookContraint : ShimmyAroundCornerMaxLookContraint);			
			}
			else
			{
				MinLookConstraint = ((IsHangingFree()) ? HangFreeMinLookContraint : ClassT<TdMove_Grab>().DefaultAs<TdMove>().MinLookConstraint);
				MaxLookConstraint = ((IsHangingFree()) ? HangFreeMaxLookContraint : ClassT<TdMove_Grab>().DefaultAs<TdMove>().MaxLookConstraint);
			}
		}
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		/*local */bool MoveLeft = default, MoveRight = default;
		/*local */Object.Rotator LookAtAngle = default;
	
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		bClimpUpFoldedActionReceived = ((int)Action) == ((int)TdPawn.EMovementAction.MA_ClimbUp/*7*/);
		if((((int)CurrentShimmyMove) == ((int)TdMove_Grab.EShimmyType.Shimmy/*0*/)) && ((int)Action) == ((int)TdPawn.EMovementAction.MA_None/*0*/))
		{
			AbortShimmy(default(bool?));
			return;
		}
		if(((((((int)CurrentShimmyMove) == ((int)TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/)) || bHangFreeVertigoEffect)) || ((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/)))
		{
			return;
		}
		MoveLeft = (((((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) || ((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/))) && MoveActiveTime > DisableShimmyTime;
		MoveRight = (((((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyRight/*14*/)) || ((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyRightLong/*15*/))) && MoveActiveTime > DisableShimmyTime;
		if(bSlopedLedge)
		{
			return;
		}
		if(bRequestDropDown)
		{
			return;
		}
		if(((MoveLeft || MoveRight)) && !bIsWithinForwardView && !IsHangingFree())
		{
			return;
		}
		if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/)) && ((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_None/*0*/))
		{
			StopLookingAtLedgeTime = 0.0f;
			LookAtAngle = PawnOwner.Rotation;
			LookAtAngle.Yaw += ((bIsTurnedRight) ? MaxLookConstraint.Yaw : MinLookConstraint.Yaw);
			AbortLookAtTarget();
			SetLookAtTargetAngle(Normalize(LookAtAngle), 0.20f, default(float?));
		}
		if(((MoveLeft || MoveRight)) && (PawnOwner.WorldInfo.TimeSeconds - LastShimmyTimeSeconds) > 0.50f)
		{
			if(CanShimmy(((TdPawn.EMovementAction)Action)))
			{
				StartShimmy(((TdPawn.EMovementAction)Action));			
			}
			else
			{
				AbortShimmy(default(bool?));
			}
		}
	}
	
	public virtual /*simulated event */bool CanShimmy(TdPawn.EMovementAction ShimmyAction)
	{
		/*local */Object.Vector Start = default, End = default, Extent = default, Direction = default, X = default, Y = default,
			Z = default;
	
		/*local */float DistanceCheck = default;
	
		if(((int)PawnOwner.CurrentGrabTurnType) != ((int)TdPawn.EGrabTurnType.GTT_None/*0*/))
		{
			return false;
		}
		PawnOwner.GetAxes(PawnOwner.Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		Direction = ((((((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) || ((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/))) ? -Y : Y);
		Direction = Normal(Direction);
		Direction.Z = 0.0f;
		DistanceCheck = 35.0f;
		Start = PawnOwner.MoveLedgeLocation + (PawnOwner.MoveNormal * (GrabDesiredLedgeOffset.X + RelativeExtent));
		Start.Z -= GrabDesiredLedgeOffset.Z;
		End = Start + (Direction * DistanceCheck);
		Extent = PawnOwner.GetCollisionExtent();
		if(!MovementTraceForBlocking(End, Start, Extent))
		{
			return true;
		}
		return false;
	}
	
	public virtual /*simulated event */bool CanShimmyAroundCorner(TdPawn.EMovementAction ShimmyAction)
	{
		/*local */Object.Vector Start = default, End = default, Extent = default, Direction = default, X = default, Y = default,
			Z = default;
	
		/*local */float Distance = default;
		/*local */bool MoveLeft = default;
	
		PawnOwner.GetAxes(PawnOwner.Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		MoveLeft = ((((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) || ((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/));
		Direction = ((MoveLeft) ? -Y : Y);
		Direction = Normal(Direction);
		Direction.Z = 0.0f;
		Distance = ((GrabDesiredLedgeOffset.X * 2.0f) + RelativeExtent) + 4.0f;
		Start = PawnOwner.MoveLedgeLocation + (PawnOwner.MoveNormal * (GrabDesiredLedgeOffset.X + RelativeExtent));
		Start.Z -= GrabDesiredLedgeOffset.Z;
		End = Start + (Direction * Distance);
		Extent = PawnOwner.GetCollisionExtent();
		if(!MovementTraceForBlocking(End, Start, Extent))
		{
			Start = End;
			End = Start - (PawnOwner.MoveNormal * Distance);
			if(!MovementTraceForBlocking(End, Start, Extent))
			{
				TargetLocation = End;
				TargetYaw = PawnOwner.Rotation.Yaw + ((MoveLeft) ? 16384 : -16384);
				return true;			
			}
			else
			{
				return false;
			}		
		}
		else
		{
			return false;
		}
	}
	
	public virtual /*simulated event */void StartShimmy(TdPawn.EMovementAction ShimmyAction)
	{
		/*local */bool MoveLeft = default;
	
		MoveLeft = ((((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) || ((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/));
		if(((int)CurrentShimmyMove) != ((int)TdMove_Grab.EShimmyType.Shimmy/*0*/))
		{
			AbortLookAtTarget();
			CurrentShimmyMove = TdMove_Grab.EShimmyType.Shimmy/*0*/;
			ShimmyVelocity = 60.0f * ((MoveLeft) ? -1.0f : 1.0f);
			ShimmyTime = 1.0f;
			LastShimmyTimeSeconds = PawnOwner.WorldInfo.TimeSeconds;
			PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((IsHangingFree()) ? ((MoveLeft) ? "HangFreeStrafeLeft" : "HangFreeStrafe") : ((MoveLeft) ? "HangStrafeLeft" : "HangStrafeRight")), 1.0f, 0.20f, 0.0f, default(bool?), default(bool?));
			CustomAnimNode = ((PawnOwner.GetCustomAnimation(TdPawn.CustomNodeType.CNT_FullBody/*2*/)) as TdAnimNodeSequence);
			if( CustomAnimNode == null )
			{
				// This occured a couple of time, need to look at why
				System.Diagnostics.Debugger.Break();
			}
		}
	}
	
	public virtual /*simulated event */void StartShimmyAroundCorner(TdPawn.EMovementAction ShimmyAction)
	{
		/*local */bool MoveLeft = default;
		/*local */Object.Vector X = default, Y = default, Z = default;
	
		MoveLeft = ((((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) || ((int)ShimmyAction) == ((int)TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/));
		PawnOwner.GetAxes(PawnOwner.Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		PawnOwner.UseRootMotion(true);
		SetMoveTimer(0.10f, false, "StartRootRotation");
		if(MoveLeft)
		{
			PawnOwner.SetLocation((TargetLocation - (X * 63.8580f)) + (Y * 60.7530f));		
		}
		else
		{
			PawnOwner.SetLocation((TargetLocation - (X * 63.8580f)) - (Y * 60.7530f));
		}
		AbortLookAtTarget();
		ResetCameraLook(0.10f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		if(MoveLeft)
		{
			PendingShimmyCornerAnimation = ((IsHangingFree()) ? "HangFreeCornerOutSideLeft" : "HangCornerOutSideLeft");		
		}
		else
		{
			PendingShimmyCornerAnimation = ((IsHangingFree()) ? "HangFreeCornerOutSideRight" : "HangCornerOutSideRight");
		}
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
		CurrentShimmyMove = TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/;
		UpdateViewConstraints();
	}
	
	public virtual /*function */void StartRootRotation()
	{
		PawnOwner.UseRootRotation(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, PendingShimmyCornerAnimation, 1.0f, 0.150f, 0.150f, true, true);
	}
	
	public virtual /*simulated event */void AbortShimmy(/*optional */bool? _bForceVelStop = default)
	{
		/*local */float NormalizedPosition = default;
		/*local */Object.Vector ZeroSpeed = default;
	
		var bForceVelStop = _bForceVelStop ?? false;
		if(((int)CurrentShimmyMove) != ((int)TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/))
		{
			if(bForceVelStop)
			{
				ZeroSpeed = vect(0.0f, 0.0f, 0.0f);
				PawnOwner.Velocity = ZeroSpeed;
				PawnOwner.Acceleration = ZeroSpeed;
				PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
				CurrentShimmyMove = TdMove_Grab.EShimmyType.NoShimmy/*3*/;
				ShimmyTime = 0.0f;			
			}
			else
			{
				NormalizedPosition = CustomAnimNode.GetNormalizedPosition();
				if((((NormalizedPosition > 0.10f) && NormalizedPosition < 0.250f) || NormalizedPosition > 0.80f))
				{
					PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.40f);
					CurrentShimmyMove = TdMove_Grab.EShimmyType.NoShimmy/*3*/;
					ShimmyTime = 0.0f;
				}
			}
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		/*local */Object.Rotator NewRotation = default;
	
		if(((int)CurrentShimmyMove) == ((int)TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/))
		{
			if((SeqNode.AnimSeqName == PendingShimmyCornerAnimation) && TargetYaw != -1)
			{
				NewRotation = PawnOwner.Rotation;
				NewRotation.Yaw = TargetYaw;
				PawnOwner.SetRotation(NewRotation);
				PawnOwner.SetLocation(TargetLocation);
				TargetYaw = -1;
				ShimmyTime = 0.0f;
				RelativeExtent = CalculateRelativeExtent(PawnOwner.CylinderComponent.CollisionRadius);
				RootOffset.X = (DefaultAs<TdMove>().RootOffset.X + RelativeExtent) + ((IsHangingFree()) ? 0.0f : 1.0f);			
			}
			else
			{
				return;
			}
		}
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		CurrentShimmyMove = TdMove_Grab.EShimmyType.NoShimmy/*3*/;
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		UpdateViewConstraints();
		if(((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
		{
			if(PawnOwner.Weapon != default)
			{
				PawnOwner.SetUnarmed();
			}
			if(bClimpUpFoldedActionReceived && PawnOwner.Moves[10].CanDoMove())
			{
				bClimpUpFoldedActionReceived = false;
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_GrabPullUp/*10*/, default(bool?), default(bool?));			
			}
			else
			{
				if(IsHangingFree())
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("HangFreeFoldedEndHangFree")), 1.0f, 0.0f, 0.20f, default(bool?), default(bool?));
					SetTimer(1.50f);				
				}
				else
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("HangFoldedEndHang")), 1.0f, 0.0f, 0.20f, default(bool?), default(bool?));
				}
				CurrentFoldedType = TdMove_Grab.EGrabFoldedType.GFT_End/*2*/;
				bConstrainLook = false;
			}		
		}
		else
		{
			if(((int)CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_End/*2*/))
			{
				CurrentFoldedType = TdMove_Grab.EGrabFoldedType.GFT_None/*0*/;
				bConstrainLook = true;
			}
		}
		if(bHangFreeVertigoEffect)
		{
			bHangFreeVertigoEffect = false;
			bConstrainLook = true;
		}
		if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_Start/*1*/))
		{
			PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_Idle/*3*/;		
		}
		else
		{
			if(((int)PawnOwner.CurrentGrabTurnType) == ((int)TdPawn.EGrabTurnType.GTT_End/*2*/))
			{
				PawnOwner.CurrentGrabTurnType = TdPawn.EGrabTurnType.GTT_None/*0*/;
			}
		}
		if(bRequestDropDown)
		{
			DropDown();
		}
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		RootOffset.X += CalculateRelativeExtent(PawnOwner.CylinderComponent.CollisionRadius);
		base.StartReplicatedMove();
		SetGrabType(((TdMove_Grab.EGrabType)CheckWallLegPlacement()));
		UpdateViewConstraints();
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public override /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
		if(PawnOwner.Moves[2].CanDoMove())
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		if(((int)CurrentShimmyMove) == ((int)TdMove_Grab.EShimmyType.ShimmyAroundCorner/*2*/))
		{
			return PawnOwner.Health - 1;		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float?));
		}
		return base.HandleDeath(Damage);
	}
	
	public override /*simulated function */int GetMinLookConstrainYaw()
	{
		if(((int)CurrentShimmyMove) != ((int)TdMove_Grab.EShimmyType.NoShimmy/*3*/))
		{
			return -5000;
		}
		return base.GetMinLookConstrainYaw();
	}
	
	public override /*simulated function */int GetMaxLookConstrainYaw()
	{
		if(((int)CurrentShimmyMove) != ((int)TdMove_Grab.EShimmyType.NoShimmy/*3*/))
		{
			return 5000;
		}
		return base.GetMaxLookConstrainYaw();
	}
	
	public override /*simulated function */int GetMinLookConstrainPitch()
	{
		if(((int)CurrentShimmyMove) != ((int)TdMove_Grab.EShimmyType.NoShimmy/*3*/))
		{
			return 0;
		}
		return base.GetMinLookConstrainPitch();
	}
	
	public TdMove_Grab()
	{
		// Object Offset:0x005BB312
		GrabDesiredLedgeOffset = new Vector
		{
			X=30.0f,
			Y=0.0f,
			Z=92.80f
		};
		GrabMaxAngle = 40.0f;
		HangFreeZDistanceCheck = 128.0f;
		StartTurningAngle = 16384.0f;
		bIsWithinForwardView = true;
		CurrentShimmyMove = TdMove_Grab.EShimmyType.NoShimmy;
		HangFreeMinLookContraint = new Rotator
		{
			Pitch=8300,
			Yaw=-16384,
			Roll=0
		};
		HangFreeMaxLookContraint = new Rotator
		{
			Pitch=16000,
			Yaw=16384,
			Roll=0
		};
		SlopeMinLookContraint = new Rotator
		{
			Pitch=-3200,
			Yaw=-8192,
			Roll=0
		};
		SlopeMaxLookContraint = new Rotator
		{
			Pitch=8300,
			Yaw=8192,
			Roll=0
		};
		ShimmyAroundCornerMinLookContraint = new Rotator
		{
			Pitch=3200,
			Yaw=-32768,
			Roll=0
		};
		ShimmyAroundCornerMaxLookContraint = new Rotator
		{
			Pitch=16000,
			Yaw=32768,
			Roll=0
		};
		ShimmyAroundCornerFreeMinLookContraint = new Rotator
		{
			Pitch=11000,
			Yaw=-32768,
			Roll=0
		};
		ShimmyAroundCornerFreeMaxLookContraint = new Rotator
		{
			Pitch=16000,
			Yaw=32768,
			Roll=0
		};
		DisableShimmyTime = 0.60f;
		PawnPhysics = Actor.EPhysics.PHYS_None;
		ControllerState = (name)"PlayerGrabbing";
		bDisableCollision = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableLookTime = 0.80f;
		RedoMoveTime = 0.150f;
		MinLookConstraint = new Rotator
		{
			Pitch=-3200,
			Yaw=-32768,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16000,
			Yaw=32768,
			Roll=0
		};
		SwanNeckEnableAtPitch = 0;
		SwanNeckForward = 70.0f;
		AnimBlendTime = 0.10f;
	}
}
}