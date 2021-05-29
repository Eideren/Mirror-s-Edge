namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Walking : TdPhysicsMove/*
		config(PawnMovement)*/{
	public partial struct IdleAnimStruct
	{
		public name AnimName;
		public TdPawn.CustomNodeType NodeType;
		public bool bResetCameraLook;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005E8E5D
	//		AnimName = (name)"None";
	//		NodeType = TdPawn.CustomNodeType.CNT_Canned;
	//		bResetCameraLook = false;
	//	}
	};
	
	public /*private transient */bool bIsPlayingIdleAnim;
	public/*()*/ /*config */float TriggerIdleAnimMinTime;
	public/*()*/ /*config */float TriggerIdleAnimMaxTime;
	public /*config */array</*config */TdMove_Walking.IdleAnimStruct> UnarmedIdleAnims;
	public /*config */array</*config */TdMove_Walking.IdleAnimStruct> LightIdleAnims;
	public /*config */array</*config */TdMove_Walking.IdleAnimStruct> HeavyIdleAnims;
	public /*private transient */TdMove_Walking.IdleAnimStruct CurrentIdleAnim;
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector Extent = default, Start = default, End = default;
		/*local */float CrouchCollisionSize = default;
	
		CrouchCollisionSize = 122.0f;
		if(!base.CanDoMove())
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Crouch/*15*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Slide/*16*/))
		{
			Start = PawnOwner.Location;
			End = Start;
			End.Z += ((PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight * 2.0f) - CrouchCollisionSize);
			Extent = PawnOwner.GetCollisionExtent();
			if(MovementTraceForBlocking(End, Start, Extent))
			{
				return false;
			}
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */float IdleTime = default;
	
		base.StartMove();
		PawnOwner.bIllegalLedgeTimer = 0.0f;
		if((PawnOwner.Controller != default) && PawnOwner.Controller.IsA("PlayerController"))
		{
			IdleTime = GetNewIdleTriggerTime();
			SetMoveTimer(IdleTime, false, "OnIdleTimer");
		}
		if((PawnOwner.IsA("TdPlayerPawn") && ((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && ((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_Landing/*20*/))
		{
			PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, "JumpLand", 1.0f, 0.20f, 0.10f, false, true, false, default);
			SetMoveTimer(0.20f, false, "OnBlendOutJumpLandTimer");
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		/*local */TdAnimNodeSequence AnimSeq1p = default;
	
		base.StopMove();
		PawnOwner.SetHipsOffset(vect(0.0f, 0.0f, 0.0f), default, default);
		if(bIsPlayingIdleAnim)
		{
			StopIdle(default);
		}
		if(((((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && PawnOwner.CustomWeaponNode1p != default) && ((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_Slide/*16*/))
		{
			AnimSeq1p = ((PawnOwner.CustomWeaponNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			if((AnimSeq1p != default) && AnimSeq1p.AnimSeqName == "JumpLand")
			{
				PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
			}
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */Object.Vector HipsOffset = default;
		/*local */TdPlayerController TdPC = default;
		/*local */bool bMovingView = default;
	
		if((((int)PawnOwner.CurrentWalkingState) > ((int)TdPawn.WalkingState.WAS_Walk/*2*/)) && PawnOwner.SwanNeck1p != default)
		{
			HipsOffset.X = -FMin(PawnOwner.SwanNeck1p.Translation.Y, 5.0f) * 4.0f;		
		}
		else
		{
			HipsOffset.X = 0.0f;
		}
		PawnOwner.SetHipsOffset(HipsOffset, default, default);
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		TdPC = ((PawnOwner.Controller) as TdPlayerController);
		if(TdPC != default)
		{
			UpdateMeleeAutoLockOn(TdPC, DeltaTime, out_Rotation, ref/*probably?*/ DeltaRot);
		}
		bMovingView = (((DeltaRot.Yaw > 0) || DeltaRot.Yaw < 0) || DeltaRot.Pitch > 0) || DeltaRot.Pitch < 0;
		if((((int)PawnOwner.CurrentWalkingState) > ((int)TdPawn.WalkingState.WAS_Idle/*0*/)) || bMovingView)
		{
			if(bIsPlayingIdleAnim)
			{
				StopIdle(default);
			}
			SetMoveTimer(GetNewIdleTriggerTime(), false, "OnIdleTimer");
		}
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		if(((int)Action) != ((int)TdPawn.EMovementAction.MA_None/*0*/))
		{
			if(bIsPlayingIdleAnim)
			{
				StopIdle(default);
			}
			SetMoveTimer(GetNewIdleTriggerTime(), false, "OnIdleTimer");
		}
	}
	
	public virtual /*simulated function */void OnBlendOutJumpLandTimer()
	{
		/*local */TdAnimNodeSequence AnimSeq1p = default;
	
		AnimSeq1p = ((PawnOwner.CustomWeaponNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		if(AnimSeq1p.AnimSeqName == "JumpLand")
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.30f);
		}
	}
	
	public virtual /*simulated function */float GetNewIdleTriggerTime()
	{
		/*local */float TimeVariation = default;
	
		TimeVariation = FMax(TriggerIdleAnimMaxTime - TriggerIdleAnimMinTime, 0.0f);
		return TriggerIdleAnimMinTime + (FRand() * TimeVariation);
	}
	
	public virtual /*simulated function */void OnIdleTimer()
	{
		PlayIdle();
	}
	
	public virtual /*simulated function */bool CanPlayIdle()
	{
		if(((PawnOwner.Controller) as PlayerController).bCinematicMode)
		{
			return false;
		}
		if(((int)PawnOwner.AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/))
		{
			return false;
		}
		return true;
	}
	
	public virtual /*simulated function */void PlayIdle()
	{
		/*local */TdPawn.EWeaponType CurrentWeaponType = default;
	
		if(!CanPlayIdle())
		{
			SetMoveTimer(GetNewIdleTriggerTime(), false, "OnIdleTimer");
			return;
		}
		CurrentWeaponType = ((TdPawn.EWeaponType)PawnOwner.GetWeaponType());
		if((((int)CurrentWeaponType) == ((int)TdPawn.EWeaponType.EWT_None/*0*/)) && UnarmedIdleAnims.Length > 0)
		{
			CurrentIdleAnim = UnarmedIdleAnims[Rand(UnarmedIdleAnims.Length)];		
		}
		else
		{
			if((((int)CurrentWeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/)) && LightIdleAnims.Length > 0)
			{
				CurrentIdleAnim = LightIdleAnims[Rand(LightIdleAnims.Length)];			
			}
			else
			{
				if((((int)CurrentWeaponType) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && HeavyIdleAnims.Length > 0)
				{
					CurrentIdleAnim = HeavyIdleAnims[Rand(HeavyIdleAnims.Length)];				
				}
				else
				{
					CurrentIdleAnim.AnimName = "None";
					CurrentIdleAnim.bResetCameraLook = false;
				}
			}
		}
		if(CurrentIdleAnim.bResetCameraLook)
		{
			ResetCameraLook(0.60f);
		}
		if(CurrentIdleAnim.AnimName != "None")
		{
			PlayMoveAnim(((TdPawn.CustomNodeType)CurrentIdleAnim.NodeType), CurrentIdleAnim.AnimName, 1.0f, 0.40f, 0.40f, default, default);
			bIsPlayingIdleAnim = true;		
		}
		else
		{
			SetMoveTimer(GetNewIdleTriggerTime(), false, "OnIdleTimer");
			return;
		}
	}
	
	public virtual /*simulated function */bool IsPlayingIdleAnim()
	{
		return bIsPlayingIdleAnim;
	}
	
	public virtual /*simulated function */void StopIdle(/*optional */float? _BlendOutTime = default)
	{
		var BlendOutTime = _BlendOutTime ?? 0.40f;
		PawnOwner.StopCustomAnim(((TdPawn.CustomNodeType)CurrentIdleAnim.NodeType), BlendOutTime);
		if(CurrentIdleAnim.bResetCameraLook)
		{
			bResetCameraLook = false;
		}
		bIsPlayingIdleAnim = false;
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		SetMoveTimer(GetNewIdleTriggerTime(), false, "OnIdleTimer");
		bIsPlayingIdleAnim = false;
	}
	
	public override /*function */void CheckForCameraCollision(Object.Vector CameraLocation, Object.Rotator CameraRotation)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default, TraceEnd = default, TraceStart = default, TraceExtent = default;
	
		/*local */float HitTime = default;
	
		base.CheckForCameraCollision(CameraLocation, CameraRotation);
		if(((int)PawnOwner.AgainstWallState) == ((int)TdPawn.EAgainstWallState.AW_None/*0*/))
		{
			TraceStart = CameraLocation - (((Vector)(PawnOwner.Controller.Rotation)) * 5.0f);
			TraceEnd = CameraLocation + (((Vector)(PawnOwner.Controller.Rotation)) * 15.0f);
			TraceExtent = vect(2.0f, 2.0f, 2.0f);
			if(MovementTraceForBlockingEx(TraceEnd, TraceStart, TraceExtent, ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal))
			{
				HitTime = VSize(HitLocation - TraceStart) / VSize(TraceEnd - TraceStart);
				if((MaxLookConstraint.Pitch < 14000) || HitTime < 0.80f)
				{
					MinLookConstraint.Pitch = ((int)(((float)(Normalize(CameraRotation).Pitch)) * HitTime));				
				}
				else
				{
					MinLookConstraint.Pitch = Normalize(CameraRotation).Pitch;
				}
				MaxLookConstraint.Pitch = 32768;
				bConstrainLook = true;			
			}
			else
			{
				bConstrainLook = false;
			}
		}
	}
	
	public TdMove_Walking()
	{
		// Object Offset:0x005EA1B7
		TriggerIdleAnimMinTime = 30.0f;
		TriggerIdleAnimMaxTime = 40.0f;
		UnarmedIdleAnims = new array</*config */TdMove_Walking.IdleAnimStruct>
		{
			new TdMove_Walking.IdleAnimStruct
			{
				AnimName = (name)"standidle1",
				NodeType = TdPawn.CustomNodeType.CNT_Canned,
				bResetCameraLook = true,
			},
			new TdMove_Walking.IdleAnimStruct
			{
				AnimName = (name)"standidle2",
				NodeType = TdPawn.CustomNodeType.CNT_Canned,
				bResetCameraLook = true,
			},
			new TdMove_Walking.IdleAnimStruct
			{
				AnimName = (name)"standidle3",
				NodeType = TdPawn.CustomNodeType.CNT_Canned,
				bResetCameraLook = true,
			},
		};
		ControllerState = (name)"PlayerWalking";
		bShouldUnzoom = false;
		bUseCameraCollision = true;
		bEnableFootPlacement = true;
		bEnableAgainstWall = true;
		bAllowPickup = true;
	}
}
}