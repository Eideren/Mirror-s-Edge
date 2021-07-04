namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove : Object/*
		abstract
		native
		config(PawnMovement)*/{
	public enum EMovementGroup 
	{
		MG_Free,
		MG_OneHandBusy,
		MG_TwoHandsBusy,
		MG_NonInteractive,
		MG_MAX
	};
	
	public enum EPreciseLocationMode 
	{
		PLM_Fly,
		PLM_Walk,
		PLM_Jump,
		PLM_SimJump,
		PLM_Fall,
		PLM_MAX
	};
	
	public partial struct /*native */AIAimingModifierSettings
	{
		public float Easy;
		public float Medium;
		public float Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005922D6
	//		Easy = 0.0f;
	//		Medium = 0.0f;
	//		Hard = 0.0f;
	//	}
	};
	
	public TdPawn PawnOwner;
	public TdBotPawn BotOwner;
	public/*()*/ /*const config */float SpeedModifier;
	public/*()*/ /*const config */float FrictionModifier;
	public/*()*/ bool bDebugMove;
	public/*()*/ /*const config */bool bTriggersCompliment;
	public /*const */bool bDisableCollision;
	public /*const */bool bShouldHolsterWeapon;
	public /*const */bool bShouldUnzoom;
	public /*const */bool bIsTimedMove;
	public bool bConstrainLook;
	public bool bUseAbsoluteYawConstraint;
	public /*const */bool bDisableActorCollision;
	public bool bLookAtTargetLocation;
	public bool bLookAtTargetAngle;
	public bool bDisableFaceRotation;
	public bool bDisableControllerFacingPawnYawRotation;
	public /*const */bool bAvoidLedges;
	public /*transient */bool bUsePreciseLocation;
	public /*transient */bool bReachedPreciseLocation;
	public/*()*/ bool bDebugPreciseLocation;
	public /*transient */bool bUsePreciseRotation;
	public /*transient */bool bReachedPreciseRotation;
	public /*transient */bool bDelayRotationAndLocationCallback;
	public bool bResetCameraLook;
	public bool bUseCustomCollision;
	public bool bUseCameraCollision;
	public/*()*/ bool bTwoHandedFullBodyAnimations;
	public/*(StickyAim)*/ /*config */bool bStickyAim;
	public bool bStopAfterMove;
	public bool bEnableFootPlacement;
	public bool bEnableAgainstWall;
	public bool bAllowPickup;
	public/*()*/ /*private const config */TdMove.AIAimingModifierSettings AiAimPenalties;
	public/*()*/ /*private const config */TdMove.AIAimingModifierSettings AiAimOneShotPenalties;
	public /*transient */float AiAimPenalty;
	public /*transient */float AiAimOneShotPenalty;
	public TdMove.EMovementGroup MovementGroup;
	public Scene.ESceneDepthPriorityGroup FirstPersonDPG;
	public Scene.ESceneDepthPriorityGroup FirstPersonLowerBodyDPG;
	public TdMove.EPreciseLocationMode PreciseLocationInterpMode;
	public TdPawn.MoveAimMode AimMode;
	public /*const */float DisableMovementTime;
	public /*const */float DisableLookTime;
	public /*transient */float LastCanDoMoveTime;
	public float LastStopMoveTime;
	public /*transient */float MoveActiveTime;
	public /*const config */float RedoMoveTime;
	public float PreciseLocationSpeed;
	public /*transient */Object.Vector PreciseLocation;
	public float PreciseRotationInterpolationTime;
	public /*transient */Object.Rotator PreciseRotation;
	public /*transient */Object.Vector LookAtTargetLocation;
	public /*transient */Object.Rotator LookAtTargetAngle;
	public float LookAtTargetInterpolationTime;
	public float LookAtTargetDuration;
	public float CancelResetCameraLookTime;
	public float ResetCameraLookTime;
	public Object.Rotator MinLookConstraint;
	public Object.Rotator MaxLookConstraint;
	public float CustomCollisionRadius;
	public float CustomCollisionHeight;
	public int WeaponInactivePitchAimingLimit;
	public Object.Vector RootMotionScale;
	public/*()*/ Object.Vector RootOffset;
	public/*()*/ int SwanNeckEnableAtPitch;
	public/*()*/ float SwanNeckForward;
	public/*()*/ float SwanNeckDown;
	public name CurrentCustomAnimName;
	public AnimNodeSequence CurrentCustomAnimNode;
	public /*config */name FireAnimSeqName;
	public /*config */name ReloadAnimSeqName;
	public float AnimBlendTime;
	public/*(StickyAim)*/ /*config */int StickyAngle;
	public/*(StickyAim)*/ /*config */float StickyAimedModifier;
	public float Timer;
	public array<name> TimerFunctions;
	
	public virtual /*simulated function */bool IsThisMoveStringable()
	{
		return false;
	}
	
	// Export UTdMove::execGetMovementExclusionVolume(FFrame&, void* const)
	public virtual /*native final function */TdMovementExclusionVolume GetMovementExclusionVolume(Object.Vector Loc)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove::execFindLedgeInFrontOfPlayer(FFrame&, void* const)
	public virtual /*native final function */bool FindLedgeInFrontOfPlayer(ref Object.Vector out_LedgeLocation, ref Object.Vector out_LedgeNormal, ref Object.Vector out_MoveNormal)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove::execFindLedge(FFrame&, void* const)
	public virtual /*native final function */bool FindLedge(ref TdPawn.LedgeHitInfo out_LedgeHit, Object.Vector Start, Object.Vector End, Object.Vector Extent)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove::execFindLedgeEx(FFrame&, void* const)
	public virtual /*native final function */int FindLedgeEx(ref TdPawn.LedgeHitInfo out_LedgeHit, Object.Vector Start, Object.Vector End, Object.Vector Extent)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*final simulated event */void SetPreciseLocation(Object.Vector PreciseLocationToReach, TdMove.EPreciseLocationMode InterpMode, /*optional */float? _PreciseLocationSpeedToUse = default)
	{
		var PreciseLocationSpeedToUse = _PreciseLocationSpeedToUse ?? -1.0f;
		PreciseLocationSpeed = ((PreciseLocationSpeedToUse < 0.0f) ? PawnOwner.GroundSpeed : PreciseLocationSpeedToUse);
		PreciseLocationInterpMode = ((TdMove.EPreciseLocationMode)InterpMode);
		PreciseLocation = PreciseLocationToReach;
		bUsePreciseLocation = true;
		bReachedPreciseLocation = false;
		if(((int)PawnOwner.Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			PawnOwner.ClientAdjustPreciseLocation(PreciseLocationToReach, ((TdPawn.EMovement)PawnOwner.MovementState));
		}
	}
	
	public virtual /*final simulated event */void SetPreciseRotation(Object.Rotator PreciseRotationToReach, float PreciseRotationTimeToUse)
	{
		PreciseRotation = PreciseRotationToReach;
		PreciseRotationInterpolationTime = PreciseRotationTimeToUse;
		bUsePreciseRotation = true;
		bReachedPreciseRotation = false;
	}
	
	// Export UTdMove::execCalculateRelativeExtent(FFrame&, void* const)
	public virtual /*native final simulated function */float CalculateRelativeExtent(float BaseExtent)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*simulated event */void ReachedPreciseRotation()
	{
	
	}
	
	public virtual /*simulated event */void ReachedPreciseLocation()
	{
	
	}
	
	public virtual /*simulated event */void FailedToReachPreciseLocation()
	{
	
	}
	
	public virtual /*simulated event */void ReachedPreciseLocationAndRotation()
	{
	
	}
	
	public virtual /*simulated event */void FailedToReachPreciseLocationAndRotation()
	{
	
	}
	
	public virtual /*simulated function */void TouchedFallHeightVolume()
	{
	
	}
	
	// Export UTdMove::execMovementTrace(FFrame&, void* const)
	public virtual /*native final simulated function */bool MovementTrace(ref Object.Vector HitLocation, ref Object.Vector HitNormal, Object.Vector End, Object.Vector Start, Object.Vector Extent, /*optional */bool? _FindClosest = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove::execMovementTraceForBlocking(FFrame&, void* const)
	public virtual /*native final simulated function */bool MovementTraceForBlocking(Object.Vector End, Object.Vector Start, Object.Vector Extent)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove::execMovementTraceForBlockingEx(FFrame&, void* const)
	public virtual /*native final simulated function */bool MovementTraceForBlockingEx(Object.Vector End, Object.Vector Start, Object.Vector Extent, ref Object.Vector HitLocation, ref Object.Vector HitNormal)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMove::execGetLastMovementTraceInfoStatic(FFrame&, void* const)
	public virtual /*native final simulated function */void GetLastMovementTraceInfoStatic(ref Actor HitActor, ref int ExcludeHandMoves, ref int ExcludeFootMoves)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdMove::execMovementTraceForBlockingBetweenActors(FFrame&, void* const)
	public virtual /*native final simulated function */bool MovementTraceForBlockingBetweenActors(Object.Vector End, Object.Vector Start)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*final simulated function */void SetCustomCollisionSize(float CollisionRadius, float CollisionHeight)
	{
		PawnOwner.SetCollisionSize(CollisionRadius, CollisionHeight);
		CustomCollisionRadius = CollisionRadius;
		CustomCollisionHeight = CollisionHeight;
	}
	
	public virtual /*final simulated function */void SetLookAtTargetLocation(Object.Vector Target, float InterpolationTime, /*optional */float? _Duration = default)
	{
		var Duration = _Duration ?? -1.0f;
		bLookAtTargetLocation = true;
		LookAtTargetInterpolationTime = InterpolationTime;
		LookAtTargetDuration = ((Duration == -1.0f) ? Duration : MoveActiveTime + Duration);
		LookAtTargetLocation = Target;
	}
	
	public virtual /*final simulated function */void SetLookAtTargetAngle(Object.Rotator Target, float InterpolationTime, /*optional */float? _Duration = default)
	{
		var Duration = _Duration ?? -1.0f;
		bLookAtTargetAngle = true;
		LookAtTargetInterpolationTime = InterpolationTime;
		LookAtTargetDuration = ((Duration == -1.0f) ? Duration : MoveActiveTime + Duration);
		LookAtTargetAngle = Target;
	}
	
	public virtual /*final simulated function */void ResetCameraLook(float InterpolationTime)
	{
		bResetCameraLook = true;
		CancelResetCameraLookTime = PawnOwner.WorldInfo.TimeSeconds + InterpolationTime;
		ResetCameraLookTime = InterpolationTime;
	}
	
	public virtual /*final simulated function */void AbortLookAtTarget()
	{
		bLookAtTargetLocation = false;
		bLookAtTargetAngle = false;
		LookAtTargetDuration = -1.0f;
	}
	
	public virtual /*final simulated function */void SetCameraPitchConstraints(int MinPitch, int maxPitch)
	{
		MinLookConstraint.Pitch = MinPitch;
		MaxLookConstraint.Pitch = maxPitch;
	}
	
	public virtual /*final simulated function */void SetCameraYawConstraints(int MinYaw, int MaxYaw)
	{
		MinLookConstraint.Yaw = MinYaw;
		MaxLookConstraint.Yaw = MaxYaw;
	}
	
	public virtual /*simulated function */int GetMinLookConstrainYaw()
	{
		return MinLookConstraint.Yaw;
	}
	
	public virtual /*simulated function */int GetMaxLookConstrainYaw()
	{
		return MaxLookConstraint.Yaw;
	}
	
	public virtual /*simulated function */int GetMinLookConstrainPitch()
	{
		return MinLookConstraint.Pitch;
	}
	
	public virtual /*simulated function */int GetMaxLookConstrainPitch()
	{
		return MaxLookConstraint.Pitch;
	}
	
	public virtual /*final function */void SetDifficulty(int Level)
	{
		switch(Level)
		{
			case 0:
				AiAimPenalty = AiAimPenalties.Easy;
				AiAimOneShotPenalty = AiAimOneShotPenalties.Easy;
				break;
			case 1:
				AiAimPenalty = AiAimPenalties.Medium;
				AiAimOneShotPenalty = AiAimOneShotPenalties.Medium;
				break;
			case 2:
				AiAimPenalty = AiAimPenalties.Hard;
				AiAimOneShotPenalty = AiAimOneShotPenalties.Hard;
				goto default;// UnrealScript fallthrough
			default:
				break;
		}
	}
	
	public virtual /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*simulated function */void DrawSimulatedProxyAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */Canvas Canvas = default;
	
		Canvas = HUD.Canvas;
		Canvas.Font = Engine.GetTinyFont();
		out_YL = 12.0f;
		out_YPos += 50.0f;
		out_YPos += out_YL;
		Canvas.SetPos(5.0f, out_YPos);
		Canvas.SetDrawColor(255, 255, 255, 255);
		Canvas.DrawText("=== Ghost ===", default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(5.0f, out_YPos);
		Canvas.DrawText("WeaponAnimState: " + ((PawnOwner.WeaponAnimState)).ToString(), default(bool?), default(float?), default(float?));
	}
	
	public virtual /*function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */Canvas Canvas = default;
	
		out_YPos += (out_YL + ((float)(10)));
		Canvas = HUD.Canvas;
		Canvas.SetDrawColor(255, 255, 255, 255);
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("MoveActiveTime: " + ((MoveActiveTime)).ToString(), default(bool?), default(float?), default(float?));
	}
	
	public virtual /*event */void TimeStopMove()
	{
	
	}
	
	public virtual /*function */bool CanDoMove()
	{
		if(PawnOwner == default)
		{
			return false;
		}
		if((LastStopMoveTime > 0.0f) && RedoMoveTime > (PawnOwner.WorldInfo.TimeSeconds - LastStopMoveTime))
		{
			return false;
		}
		if(PawnOwner.IsInState("Dying", default(bool?)))
		{
			return false;
		}
		LastCanDoMoveTime = PawnOwner.WorldInfo.TimeSeconds;
		return true;
	}
	
	public virtual /*event */bool OnCanDoMove()
	{
		return CanDoMove();
	}
	
	public virtual /*function */bool CanStopMove()
	{
		return true;
	}
	
	public virtual /*simulated function */void StartMove()
	{
		/*local */TdPlayerController PC = default;
		/*local */TdPlayerPawn PlayerPawn = default;
	
		MoveActiveTime = 0.0f;
		PlayerPawn = ((PawnOwner) as TdPlayerPawn);
		if(PlayerPawn != default)
		{
			PlayerPawn.SetFirstPersonDPG(((Scene.ESceneDepthPriorityGroup)FirstPersonDPG));
			PlayerPawn.SetFirstPersonLowerBodyDPG(((Scene.ESceneDepthPriorityGroup)FirstPersonLowerBodyDPG));
			if(IsThisMoveStringable())
			{
				PlayerPawn.StartStringableMove(Class);			
			}
			else
			{
				PlayerPawn.StartUnStringableMove();
			}
		}
		PC = ((PawnOwner.Controller) as TdPlayerController);
		PawnOwner.SetIgnoreMoveInput(DisableMovementTime);
		PawnOwner.SetIgnoreLookInput(DisableLookTime);
		if(((PC != default) && PawnOwner.Weapon != default) && ((PawnOwner.Weapon.IsA("TdWeapon_Light") && ((int)MovementGroup) >= ((int)TdMove.EMovementGroup.MG_TwoHandsBusy/*2*/)) || PawnOwner.Weapon.IsA("TdWeapon_Heavy") && ((int)MovementGroup) >= ((int)TdMove.EMovementGroup.MG_OneHandBusy/*1*/)))
		{
			PC.StopFire((byte)default(byte?));
		}
		if(((PC != default) && PawnOwner.Weapon != default) && bShouldUnzoom)
		{
			PC.UnZoom();
		}
		if(((((int)AimMode) == ((int)TdPawn.MoveAimMode.MAM_NoHands/*3*/)) && bShouldHolsterWeapon) && PawnOwner.Weapon != default)
		{
			PawnOwner.SetUnarmed();
		}
		if(bDisableActorCollision)
		{
			PawnOwner.SetCollision(true, false, default(bool?));
		}
		if(bDisableCollision)
		{
			PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
			PawnOwner.bCollideWorld = false;
		}
		if(bUseCustomCollision && !PawnOwner.Moves[((int)PawnOwner.OldMovementState)].bUseCustomCollision)
		{
			ShrinkCollision();
		}
		PawnOwner.SetRootOffset(RootOffset, 0.30f, default(SkelControlBase.EBoneControlSpace?));
		SetSwanNeckConstraints(SwanNeckEnableAtPitch, SwanNeckForward, SwanNeckDown);
		if(BotOwner != default)
		{
			BotOwner.UseLegRotation(true);
		}
		if((PC != default) && !CanUseLookAtHint())
		{
			PC.LookAtRelease();
		}
	}
	
	public virtual /*simulated function */void ResetMove()
	{
		LastCanDoMoveTime = DefaultAs<TdMove>().LastCanDoMoveTime;
		LastStopMoveTime = DefaultAs<TdMove>().LastStopMoveTime;
		MoveActiveTime = DefaultAs<TdMove>().MoveActiveTime;
	}
	
	public virtual /*simulated function */void SetSwanNeckConstraints(int TriggerAtPitchThreshold, float ForwardMotion, float DownwardMotion)
	{
		if(PawnOwner.SwanNeck1p != default)
		{
			PawnOwner.SwanNeck1p.StartTranslateAtDegree = ((float)(TriggerAtPitchThreshold));
			PawnOwner.SwanNeck1p.QuadraticForwardTranslation = ForwardMotion;
			PawnOwner.SwanNeck1p.QuadraticDownwardTranslation = DownwardMotion;
		}
	}
	
	public virtual /*function */void CheckForCameraCollision(Object.Vector CameraLocation, Object.Rotator CameraRotation)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default, TraceEnd = default, TraceStart = default, TraceExtent = default, MeshOffset = default;
	
		TraceStart = CameraLocation - (((Vector)(PawnOwner.Rotation)) * 5.0f);
		TraceEnd = CameraLocation + (((Vector)(PawnOwner.Rotation)) * 11.0f);
		TraceExtent = vect(2.0f, 2.0f, 2.0f);
		if(MovementTraceForBlockingEx(TraceEnd, TraceStart, TraceExtent, ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal))
		{
			MeshOffset.X = -VSize2D(TraceEnd - HitLocation);
			PawnOwner.OffsetMeshXY(MeshOffset, false);
		}
	}
	
	public virtual /*simulated function */void StopMove()
	{
		/*local */name FuncName = default;
	
		PawnOwner.StopIgnoreLookInput();
		PawnOwner.StopIgnoreMoveInput();
		if(bDisableCollision)
		{
			PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
			PawnOwner.bCollideWorld = true;
		}
		if(bDisableActorCollision)
		{
			PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		}
		if(bUseCustomCollision && !PawnOwner.Moves[((int)PawnOwner.PendingMovementState)].bUseCustomCollision)
		{
			EnlargeCollision();
		}
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		bUsePreciseLocation = false;
		bUsePreciseRotation = false;
		LastStopMoveTime = PawnOwner.WorldInfo.TimeSeconds;
		if((((int)AimMode) == ((int)TdPawn.MoveAimMode.MAM_NoHands/*3*/)) && PawnOwner.Weapon != default)
		{
			PawnOwner.SetArmed();
		}
		if(bTwoHandedFullBodyAnimations && ((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
		}
		if((bLookAtTargetAngle || bLookAtTargetLocation))
		{
			AbortLookAtTarget();
		}
		bResetCameraLook = false;
		RootOffset = DefaultAs<TdMove>().RootOffset;
		PawnOwner.SetRootOffset(vect(0.0f, 0.0f, 0.0f), 0.30f, default(SkelControlBase.EBoneControlSpace?));
		PawnOwner.ClearAnimationMovementState(default(float?));
		ClearTimer();
		using var v = TimerFunctions.GetEnumerator();while(v.MoveNext() && (FuncName = (name)v.Current) == FuncName)
		{
			PawnOwner.ClearTimer(FuncName, this);		
		}	
		TimerFunctions.Remove(0, TimerFunctions.Length);
		SetSwanNeckConstraints(ClassT<TdMove>().DefaultAs<TdMove>().SwanNeckEnableAtPitch, ClassT<TdMove>().DefaultAs<TdMove>().SwanNeckForward, ClassT<TdMove>().DefaultAs<TdMove>().SwanNeckDown);
		CurrentCustomAnimName = "None";
		CurrentCustomAnimNode = default;
	}
	
	public virtual /*simulated function */void PostStopMove()
	{
	
	}
	
	public virtual /*simulated function */void StopReplicatedMove()
	{
		if(bUseCustomCollision && !PawnOwner.Moves[((int)PawnOwner.PendingMovementState)].bUseCustomCollision)
		{
			EnlargeCollision();
		}
		if(bShouldHolsterWeapon)
		{
			PawnOwner.AttachWeaponToHand(PawnOwner.Weapon);
		}
		RootOffset = DefaultAs<TdMove>().RootOffset;
		PawnOwner.SetRootOffset(vect(0.0f, 0.0f, 0.0f), 0.30f, default(SkelControlBase.EBoneControlSpace?));
	}
	
	public virtual /*simulated function */void StartReplicatedMove()
	{
		if(bShouldHolsterWeapon)
		{
			PawnOwner.DetachWeaponFromHand(PawnOwner.Weapon);
		}
		if(bUseCustomCollision && !PawnOwner.Moves[((int)PawnOwner.OldMovementState)].bUseCustomCollision)
		{
			ShrinkCollision();
		}
		PawnOwner.SetRootOffset(RootOffset, 0.30f, default(SkelControlBase.EBoneControlSpace?));
	}
	
	public virtual /*simulated function */void ConstrainAxis(int Angle, int MinAngle, int MaxAngle, float InterpolateSpeed, ref int DeltaAngle)
	{
		/*local */int TargetAngle = default;
		/*local */float Dampening = default;
	
		TargetAngle = Angle + DeltaAngle;
		if(Angle < MinAngle)
		{
			DeltaAngle = Max(((int)(((float)(MinAngle - Angle)) * InterpolateSpeed)), DeltaAngle);		
		}
		else
		{
			if(Angle > MaxAngle)
			{
				DeltaAngle = Min(((int)(((float)(MaxAngle - Angle)) * InterpolateSpeed)), DeltaAngle);			
			}
			else
			{
				if(TargetAngle < MinAngle)
				{
					DeltaAngle -= (TargetAngle - MinAngle);				
				}
				else
				{
					if(TargetAngle > MaxAngle)
					{
						DeltaAngle -= (TargetAngle - MaxAngle);
					}
				}
				TargetAngle = Angle + DeltaAngle;
				if(((float)(TargetAngle)) < (((float)(MinAngle)) * 0.60f))
				{
					Dampening = Abs(((float)(MinAngle - Angle)) / (((float)(MinAngle)) * 0.40f));
					DeltaAngle = Max(DeltaAngle, ((int)(((float)(DeltaAngle)) * Dampening)));				
				}
				else
				{
					if(((float)(TargetAngle)) > (((float)(MaxAngle)) * 0.60f))
					{
						Dampening = Abs(((float)(MaxAngle - Angle)) / (((float)(MaxAngle)) * 0.40f));
						DeltaAngle = Min(DeltaAngle, ((int)(((float)(DeltaAngle)) * Dampening)));
					}
				}
			}
		}
	}
	
	public virtual /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */Object.Rotator WantedRotation = default, HeadRot = default;
		/*local */Object.Vector WantedLookDir = default, HeadPos = default;
		/*local */Object.Rotator Delta = default, ControllerDelta = default;
		/*local */int MinYaw = default, MaxYaw = default, MinPitch = default, maxPitch = default;
	
		if(bLookAtTargetLocation)
		{
			if(((LookAtTargetDuration == -1.0f) || LookAtTargetDuration >= MoveActiveTime))
			{
				PawnOwner.GetActorEyesViewPoint(ref/*probably?*/ HeadPos, ref/*probably?*/ HeadRot);
				WantedLookDir = LookAtTargetLocation - HeadPos;
				WantedRotation = Normalize(((Rotator)(WantedLookDir)));
				HeadRot = Normalize(out_Rotation);
				Delta = Normalize(WantedRotation - HeadRot);
				out_Rotation += (Delta * FMin(1.0f, DeltaTime / LookAtTargetInterpolationTime));			
			}
			else
			{
				AbortLookAtTarget();
			}		
		}
		else
		{
			if(bLookAtTargetAngle)
			{
				if(((LookAtTargetDuration == -1.0f) || LookAtTargetDuration >= MoveActiveTime))
				{
					WantedRotation = LookAtTargetAngle;
					HeadRot = Normalize(out_Rotation);
					Delta = Normalize(WantedRotation - HeadRot);
					out_Rotation += (Delta * FMin(1.0f, DeltaTime / LookAtTargetInterpolationTime));				
				}
				else
				{
					AbortLookAtTarget();
				}
			}
		}
		if((bConstrainLook || PawnOwner.bConstrainLook))
		{
			ControllerDelta = Normalize(Normalize(out_Rotation) - Normalize(PawnOwner.Rotation));
			if(bUseAbsoluteYawConstraint)
			{
				MinYaw = NormalizeRotAxis((GetMinLookConstrainYaw()) - PawnOwner.Rotation.Yaw);
				MaxYaw = NormalizeRotAxis((GetMaxLookConstrainYaw()) - PawnOwner.Rotation.Yaw);			
			}
			else
			{
				MinYaw = Max(GetMinLookConstrainYaw(), PawnOwner.MinLookConstraint.Yaw);
				MaxYaw = Min(GetMaxLookConstrainYaw(), PawnOwner.MaxLookConstraint.Yaw);
			}
			MinPitch = Max(GetMinLookConstrainPitch(), PawnOwner.MinLookConstraint.Pitch);
			maxPitch = Min(GetMaxLookConstrainPitch(), PawnOwner.MaxLookConstraint.Pitch);
			Delta = DeltaRot;
			ConstrainAxis(ControllerDelta.Yaw, MinYaw, MaxYaw, DeltaTime / 0.20f, ref/*probably?*/ DeltaRot.Yaw);
			ConstrainAxis(ControllerDelta.Pitch, MinPitch, maxPitch, DeltaTime / 0.20f, ref/*probably?*/ DeltaRot.Pitch);
			Delta -= DeltaRot;
			PostConstrainCamera(Delta, ref/*probably?*/ DeltaRot);
			DeltaRot = Normalize(DeltaRot);
		}
		if(bResetCameraLook)
		{
			if(CancelResetCameraLookTime > PawnOwner.WorldInfo.TimeSeconds)
			{
				WantedRotation = PawnOwner.Rotation;
				WantedRotation.Pitch = 0;
				WantedRotation = Normalize(WantedRotation);
				HeadRot = Normalize(out_Rotation);
				Delta = Normalize(WantedRotation - HeadRot);
				out_Rotation += (Delta / FMax(1.0f, (CancelResetCameraLookTime - PawnOwner.WorldInfo.TimeSeconds) / DeltaTime));			
			}
			else
			{
				out_Rotation.Pitch = 0;
				bResetCameraLook = false;
			}
		}
	}
	
	public virtual /*simulated function */void UpdateMeleeAutoLockOn(TdPlayerController TdPC, float DeltaTime, Object.Rotator ViewRotation, ref Object.Rotator out_DeltaRotation)
	{
		/*local */Object.Rotator TargetRot = default, ToTargetRot = default, FocusRotation = default;
		/*local */float ToTargetDelta = default;
		/*local */bool bPositiveOnJoyIsTowardsEnemy = default, bPerformingDisarm = default;
	
		if(TdPC.TargetingPawn == default)
		{
			TdPC.TargetingPawn = TdPC.GetHumanTarget(90.0f, TdPC.CloseCombatMaxAngle);
		}
		if(TdPC.TargetingPawn != default)
		{
			bPerformingDisarm = ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Snatch/*18*/);
			if((TdPC.TargetingPawn.SoftLockStrength == 0.0f) && !bPerformingDisarm)
			{
				TdPC.TargetingPawn = default;
				return;
			}
			if(!bPerformingDisarm && ((((((VSize(TdPC.TargetingPawn.Location - PawnOwner.Location) > 350.0f) || Abs(TdPC.TargetingPawn.Location.Z - PawnOwner.Location.Z) > 150.0f)) || TdPC.TargetingPawn.Health <= 0)) || (PawnOwner.WorldInfo.TimeSeconds - TdPC.TargetingPawn.LastRenderTime) > 2.0f))
			{
				TdPC.TargetingPawn = default;
				TdPC.TargetingPawnInterp = 0.0f;
				return;
			}
			ToTargetRot = Normalize(((Rotator)(TdPC.TargetingPawn.Location - PawnOwner.Location)));
			ToTargetDelta = ((float)(Normalize(ToTargetRot - Normalize(TdPC.Rotation)).Yaw));
			bPositiveOnJoyIsTowardsEnemy = ToTargetDelta > ((float)(0));
			if(!bPerformingDisarm && (((TdPC.PlayerInput.RawJoyRight > 0.70f) && TdPC.PlayerInput.RawJoyLookRight < -0.70f) || (TdPC.PlayerInput.RawJoyRight < -0.70f) && TdPC.PlayerInput.RawJoyLookRight > 0.70f))
			{
				TdPC.TargetingPawnInterp = 0.0f;
				if(Abs(ToTargetDelta) > TdPC.TargetingCutoffAngle)
				{
					TdPC.TargetingPawnInterp = 0.0f;
					TdPC.TargetingPawn = default;
				}
				return;			
			}
			else
			{
				if(!bPerformingDisarm && (((((TdPC.PlayerInput.RawJoyLookRight < 0.0f) && bPositiveOnJoyIsTowardsEnemy) || (TdPC.PlayerInput.RawJoyLookRight > 0.0f) && !bPositiveOnJoyIsTowardsEnemy)) || Abs(ToTargetDelta) < ((float)(100))))
				{
					TdPC.TargetingPawnInterp = 0.0f;
					if(Abs(ToTargetDelta) > TdPC.TargetingCutoffAngle)
					{
						TdPC.TargetingPawnInterp = 0.0f;
						TdPC.TargetingPawn = default;
						return;
					}
					out_DeltaRotation.Yaw = /*initially 'intX *= floatY' */IntFloat_Mult(out_DeltaRotation.Yaw, FClamp(Exponentiation((Abs(ToTargetDelta) / TdPC.TargetingCutoffAngle), TdPC.TargetingPawn.SoftLockStrength), 0.10f, 1.0f));
					return;				
				}
				else
				{
					TdPC.TargetingPawnInterp = FMin(1.0f, TdPC.TargetingPawnInterp + (2.0f * DeltaTime));
				}
			}
			if(((int)TdPC.TargetingPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_BotMeleeDodge/*69*/))
			{
				FocusRotation = ((Rotator)(TdPC.TargetingPawn.Mesh.GetBoneLocation("Hips", default(int?)) - PawnOwner.Location));			
			}
			else
			{
				FocusRotation = ((Rotator)(TdPC.TargetingPawn.Location - PawnOwner.Location));
			}
			if(TdPC.TargetingPawnInterp == 1.0f)
			{
				TargetRot = FocusRotation;			
			}
			else
			{
				TargetRot = RLerp(Normalize(PawnOwner.Controller.Rotation), FocusRotation, TdPC.TargetingPawnInterp, true);
			}
			out_DeltaRotation.Yaw = NormalizeRotAxis(TargetRot.Yaw - ViewRotation.Yaw);
		}
	}
	
	public virtual /*simulated function */void PostConstrainCamera(Object.Rotator ConstrainAmount, ref Object.Rotator DeltaRot)
	{
	
	}
	
	public virtual /*simulated function */name PlayFireAnimation()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.0f);
		PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, FireAnimSeqName, 1.0f, 0.10f, 0.10f, false, true, false, false);
		return FireAnimSeqName;
	}
	
	public virtual /*simulated function */name PlayReloadAnimation()
	{
		PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, ReloadAnimSeqName, 1.0f, 0.20f, 0.20f, false, true, false, false);
		return ReloadAnimSeqName;
	}
	
	public virtual /*simulated function */void Landed(Object.Vector aNormal, Actor anActor)
	{
		if(PawnOwner.Moves[20].CanDoMove())
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Landing/*20*/, default(bool?), default(bool?));
		}
	}
	
	public virtual /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*simulated event */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
	
	}
	
	public virtual /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
	
	}
	
	public virtual /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
	
	}
	
	public virtual /*simulated function */void Bump(Object.Vector HitNormal, Actor BumpedActor)
	{
	
	}
	
	public virtual /*simulated function */void ReachedWall()
	{
	
	}
	
	public virtual /*simulated function */void MeleeAttackNotify()
	{
	
	}
	
	public virtual /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
	
	}
	
	public virtual /*simulated function */void EnableRootMotionNotify()
	{
		PawnOwner.UseRootMotion(true);
	}
	
	public virtual /*simulated function */void RootRotationCompletedNotify()
	{
	
	}
	
	public virtual /*simulated function */void DisarmCompleted()
	{
	
	}
	
	public virtual /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
	
	}
	
	public virtual /*simulated function */int HandleDeath(int Damage)
	{
		return Damage;
	}
	
	public virtual /*simulated function */void SetTimer(float Time)
	{
		if(Time > 0.0f)
		{
			Timer = Time;		
		}
		else
		{
			OnTimer();
			ClearTimer();
		}
	}
	
	public virtual /*simulated function */void SetMoveTimer(float Time, bool bLooping, name FuncName)
	{
		TimerFunctions.AddItem(FuncName);
		PawnOwner.SetTimer(Time, bLooping, FuncName, this);
	}
	
	public virtual /*simulated event */void OnMoveTimer()
	{
		OnTimer();
	}
	
	public virtual /*simulated function */void OnTimer()
	{
	
	}
	
	public virtual /*simulated function */void ClearMoveTimer(name FuncName)
	{
		PawnOwner.ClearTimer(FuncName, this);
	}
	
	public virtual /*simulated function */void ClearTimer()
	{
		Timer = 0.0f;
	}
	
	// Export UTdMove::execGetAimMode(FFrame&, void* const)
	public virtual /*native simulated function */TdPawn.MoveAimMode GetAimMode(bool bAimingOnly)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default;
	
		PawnRootLocation = PawnOwner.Location;
		PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		return PawnRootLocation + vect(0.0f, 0.0f, 150.0f);
	}
	
	public virtual /*final simulated function */void PlayMoveAnim(TdPawn.CustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, /*optional */bool? _bRootMotion = default, /*optional */bool? _bRootRotation = default)
	{
		var bRootMotion = _bRootMotion ?? false;
		var bRootRotation = _bRootRotation ?? false;
		PawnOwner.PlayCustomAnim(((TdPawn.CustomNodeType)Type), AnimName, Rate, BlendInTime, BlendOutTime, false, true, bRootMotion, bRootRotation);
		CurrentCustomAnimName = AnimName;
		CurrentCustomAnimNode = PawnOwner.GetCustomAnimation(((TdPawn.CustomNodeType)Type));
		if((CurrentCustomAnimNode != default) && !CurrentCustomAnimNode.bPlaying)
		{
			CurrentCustomAnimNode = default;
		}
	}
	
	public virtual /*simulated function */void ShrinkCollision()
	{
		/*local */float CrouchCollisionHeight = default;
		/*local */Object.Vector PawnDeltaLocation = default;
		/*local */float CollisionSize = default;
	
		CollisionSize = 122.0f;
		CrouchCollisionHeight = 0.50f * CollisionSize;
		SetCustomCollisionSize(PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius, CrouchCollisionHeight);
		PawnDeltaLocation.Z = PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight - CrouchCollisionHeight;
		PawnOwner.Move(-PawnDeltaLocation);
		PawnOwner.SetTargetMeshZ(PawnDeltaLocation.Z, true);
	}
	
	public virtual /*simulated function */void EnlargeCollision()
	{
		/*local */float CrouchCollisionHeight = default;
		/*local */Object.Vector PawnDeltaLocation = default;
		/*local */float CollisionSize = default;
		/*local */bool bIsOnGround = default;
	
		bIsOnGround = ((int)PawnOwner.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/);
		CollisionSize = 122.0f;
		CrouchCollisionHeight = 0.50f * CollisionSize;
		SetCustomCollisionSize(PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius, PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight);
		PawnDeltaLocation.Z = PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight - CrouchCollisionHeight;
		if(bIsOnGround)
		{
			PawnDeltaLocation.Z += 2.0f;
		}
		if(!PawnOwner.Move(PawnDeltaLocation))
		{
			PawnOwner.SetLocation(PawnOwner.Location + PawnDeltaLocation);
		}
		PawnOwner.SetTargetMeshZ(0.0f, true);
		if(bIsOnGround)
		{
			PawnOwner.Move(-PawnOwner.Floor * PawnOwner.MaxStepHeight);
		}
	}
	
	public virtual /*function */bool CanStand(Object.Vector Location, /*optional */bool? _bFromAbove = default)
	{
		/*local */Object.Vector Extent = default, Start = default, End = default;
	
		var bFromAbove = _bFromAbove ?? false;
		Extent.X = PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius;
		Extent.Y = PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius;
		Extent.Z = 8.0f;
		Start = Location;
		Start.Z -= (PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight - Extent.Z);
		End = Location;
		End.Z += (PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight - Extent.Z);
		return !MovementTraceForBlocking(((bFromAbove) ? Start : End), ((bFromAbove) ? End : Start), Extent);
	}
	
	public virtual /*simulated function */void MoveRumbleNotify()
	{
	
	}
	
	public virtual /*simulated function */bool CanUseLookAtHint()
	{
		return true;
	}
	
	// Export UTdMove::execTestCanUnCrouch(FFrame&, void* const)
	public virtual /*native final simulated function */bool TestCanUnCrouch()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public TdMove()
	{
		// Object Offset:0x00597677
		SpeedModifier = 1.0f;
		FrictionModifier = 1.0f;
		bShouldUnzoom = true;
		bAvoidLedges = true;
		bStickyAim = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 1.0f,
			Medium = 1.0f,
			Hard = 1.0f,
		};
		FirstPersonDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate;
		AimMode = TdPawn.MoveAimMode.MAM_Default;
		LastStopMoveTime = -10.0f;
		PreciseLocationSpeed = 400.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-32768,
			Yaw=-32768,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=32768,
			Yaw=32768,
			Roll=32768
		};
		WeaponInactivePitchAimingLimit = 8000;
		RootMotionScale = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		SwanNeckEnableAtPitch = 15;
		SwanNeckForward = 35.0f;
		SwanNeckDown = 30.0f;
		FireAnimSeqName = (name)"standfire";
		ReloadAnimSeqName = (name)"Reload";
		StickyAngle = 800;
	}
}
}