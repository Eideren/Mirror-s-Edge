namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_SpeedVault : TdPhysicsMove/*
		config(PawnMovement)*/{
	public partial struct VaultType
	{
		public name AnimName;
		public name AnimNameVariation;
		public bool bVaultOnto;
		public float MinHeight;
		public float MaxHeight;
		public float MinSpeedZ;
		public float MaxSpeedZ;
		public float MinMomentum;
		public float MaxMomentum;
		public float MaxDistanceTime;
		public float ClampSpeedMin;
		public float ClampSpeedMax;
		public float SpeedAddition;
		public float VaultTimeUp;
		public float VaultTimeOver;
		public float VaultTimeDown;
		public float OverObstacleTime;
		public Object.Vector HandplantOffset;
		public Object.Vector HandIKOffset;
		public Object.Vector LedgeOffset;
		public bool bLeftHandIK;
		public bool bRightHandIK;
		public bool bMeleePossible;
		public bool bResetCamera;
		public bool bIsStringable;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005DAD70
	//		AnimName = (name)"None";
	//		AnimNameVariation = (name)"None";
	//		bVaultOnto = true;
	//		MinHeight = 0.0f;
	//		MaxHeight = 0.0f;
	//		MinSpeedZ = 0.0f;
	//		MaxSpeedZ = 0.0f;
	//		MinMomentum = -1.0f;
	//		MaxMomentum = -1.0f;
	//		MaxDistanceTime = 0.0f;
	//		ClampSpeedMin = 0.0f;
	//		ClampSpeedMax = 0.0f;
	//		SpeedAddition = 0.0f;
	//		VaultTimeUp = 0.0f;
	//		VaultTimeOver = 0.20f;
	//		VaultTimeDown = 0.20f;
	//		OverObstacleTime = 0.20f;
	//		HandplantOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HandIKOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LedgeOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		bLeftHandIK = false;
	//		bRightHandIK = false;
	//		bMeleePossible = true;
	//		bResetCamera = false;
	//		bIsStringable = false;
	//	}
	};
	
	public/*(SpeedVault)*/ /*config */float VaultClearObjectHeight;
	public/*(SpeedVault)*/ /*config */float MaxTimeToLedge;
	public int ActiveVaultType;
	public /*config */array</*config */TdMove_SpeedVault.VaultType> VaultTypes;
	public Object.Vector VaultEndPosition;
	public Object.Vector OverEndLocation;
	public Object.Vector OntoEndLocation;
	public Object.Vector SavedVelocity;
	public Object.Vector StartToHandplant;
	public int VaultState;
	public Object.Vector MoveDirection;
	public Object.Vector HandLocation;
	public Object.Vector TargetLocation;
	public bool bVaultOnto;
	public bool bEndMoveFalling;
	public bool bEndMoveInMelee;
	public float VaultSpeed;
	public float HandplantHeight;
	public Object.Vector CameraCollisionDirection;
	
	public virtual /*function */int UpdateActiveVaultType(float TimeToHandPlant)
	{
		/*local */int Idx = default;
		/*local */float Momentum = default;
	
		Momentum = VSize2D(PawnOwner.Velocity);
		if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/))
		{
			return 3;
		}
		Idx = 0;
		J0x3F:{}
		if(Idx < VaultTypes.Length)
		{
			if((HandplantHeight < VaultTypes[Idx].MinHeight) || HandplantHeight > VaultTypes[Idx].MaxHeight)
			{
				goto J0x22D;
			}
			if((VaultTypes[Idx].bVaultOnto != bVaultOnto) && Idx != 0)
			{
				goto J0x22D;
			}
			if((VaultTypes[Idx].MinMomentum != -1.0f) && Momentum < VaultTypes[Idx].MinMomentum)
			{
				goto J0x22D;
			}
			if((VaultTypes[Idx].MaxMomentum != -1.0f) && Momentum > VaultTypes[Idx].MaxMomentum)
			{
				goto J0x22D;
			}
			if((VaultTypes[Idx].MinSpeedZ != -1.0f) && PawnOwner.Velocity.Z < VaultTypes[Idx].MinSpeedZ)
			{
				goto J0x22D;
			}
			if((VaultTypes[Idx].MaxSpeedZ != -1.0f) && PawnOwner.Velocity.Z > VaultTypes[Idx].MaxSpeedZ)
			{
				goto J0x22D;
			}
			if(TimeToHandPlant > VaultTypes[Idx].MaxDistanceTime)
			{
				goto J0x22D;
			}
			return Idx;
			J0x22D:{}
			++ Idx;
			goto J0x3F;
		}
		return -1;
	}
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector RefPawnLocation = default;
		/*local */float TimeToHandPlant = default, FloorVelocity = default, EndLocationZ = default;
	
		bVaultOnto = false;
		bEndMoveFalling = false;
		if((!base.CanDoMove() || !PawnOwner.bFoundLedge) || ((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_SpeedVaulting/*8*/))
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_WallClimbing/*6*/)) && ((PawnOwner.Moves[6]) as TdMove_WallClimb).bPerformedDoubleJump)
		{
			return false;
		}
		RefPawnLocation = ((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/)) ? ((PawnOwner.Moves[31]) as TdMove_GrabTransfer).TransferLocation : PawnOwner.Location);
		if(PawnOwner.bFoundLedgeExcludesHandMoves || (PawnOwner.MovementActor != default) && PawnOwner.MovementActor.bExludeHandMoves)
		{
			return false;
		}
		if((PawnOwner.MovementExclusionVolume != default) && PawnOwner.MovementExclusionVolume.bExcludeHandMoves)
		{
			return false;
		}
		if((((int)PawnOwner.MoveActionHint) != ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/)) && ((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/))
		{
			return false;
		}
		if(PawnOwner.MoveLedgeNormal.Z < 0.30f)
		{
			return false;
		}
		if((Dot(((Vector)(PawnOwner.Controller.Rotation)), PawnOwner.MoveNormal)) > -0.20f)
		{
			return false;
		}
		StartToHandplant = PawnOwner.MoveLedgeLocation - RefPawnLocation;
		HandplantHeight = (PawnOwner.MoveLedgeLocation.Z - RefPawnLocation.Z) + PawnOwner.CylinderComponent.CollisionHeight;
		bVaultOnto = false;
		SavedVelocity = PawnOwner.Velocity;
		SavedVelocity.Z = 0.0f;
		FloorVelocity = VSize2D(SavedVelocity);
		TimeToHandPlant = VSize2D(StartToHandplant) / ((float)(Max(((int)(FloorVelocity)), 300)));
		if(TimeToHandPlant > MaxTimeToLedge)
		{
			return false;
		}
		HandLocation = PawnOwner.MoveLedgeLocation - ((Cross(PawnOwner.MoveNormal, PawnOwner.MoveLedgeNormal)) * 20.0f);
		MoveDirection = StartToHandplant;
		MoveDirection.Z = 0.0f;
		MoveDirection = Normal(MoveDirection);
		VaultEndPosition = PawnOwner.MoveLedgeLocation + (MoveDirection * ((float)(Max(48, ((int)(FloorVelocity * 0.30f))))));
		VaultEndPosition.Z = RefPawnLocation.Z;
		if(!CheckCollision(PawnOwner.MoveLedgeLocation, RefPawnLocation, FloorVelocity))
		{
			return false;
		}
		ActiveVaultType = UpdateActiveVaultType(TimeToHandPlant);
		if(ActiveVaultType == -1)
		{
			return false;
		}
		if(!bVaultOnto && VaultTypes[ActiveVaultType].bVaultOnto)
		{
			VaultEndPosition = OntoEndLocation;
			bVaultOnto = VaultTypes[ActiveVaultType].bVaultOnto;
		}
		FloorVelocity = ((float)(Clamp(((int)(FloorVelocity + VaultTypes[ActiveVaultType].SpeedAddition)), ((int)(VaultTypes[ActiveVaultType].ClampSpeedMin)), ((int)(VaultTypes[ActiveVaultType].ClampSpeedMax)))));
		SavedVelocity = Normal(SavedVelocity) * FloorVelocity;
		if(bVaultOnto)
		{
			EndLocationZ = VaultEndPosition.Z;
			VaultEndPosition = PawnOwner.MoveLedgeLocation + (MoveDirection * ((float)(Min(((int)(VSize2D(VaultEndPosition - PawnOwner.MoveLedgeLocation))), Max(48, ((int)(FloorVelocity * VaultTypes[ActiveVaultType].VaultTimeDown)))))));
			VaultEndPosition.Z = EndLocationZ;
		}
		if((((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/)) && (PawnOwner.Velocity.Z < VaultTypes[ActiveVaultType].MinSpeedZ) || PawnOwner.Velocity.Z > VaultTypes[ActiveVaultType].MaxSpeedZ)
		{
			return false;
		}
		return true;
	}
	
	public virtual /*function */bool FindValidOntoEndLocation(Object.Vector NewMoveLedgeLocation)
	{
		/*local */Object.Vector TraceStart = default, TraceEnd = default, Extent = default, HitLocation = default, HitNormal = default;
	
		/*local */float LedgeWidth = default;
	
		Extent.X = PawnOwner.CylinderComponent.CollisionRadius * 1.40f;
		Extent.Y = PawnOwner.CylinderComponent.CollisionRadius * 1.40f;
		Extent.Z = PawnOwner.CylinderComponent.CollisionHeight * 0.50f;
		TraceStart = NewMoveLedgeLocation;
		TraceStart.Z = (NewMoveLedgeLocation.Z + VaultClearObjectHeight) + Extent.Z;
		TraceEnd = VaultEndPosition;
		TraceEnd.Z = TraceStart.Z;
		OntoEndLocation = TraceEnd;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, Extent, true))
		{
			HitLocation += (MoveDirection * Extent.X);
			LedgeWidth = Dot((HitLocation - NewMoveLedgeLocation), MoveDirection);
			if(LedgeWidth <= (Extent.X + ((float)(1))))
			{
				MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, vect(10.0f, 10.0f, 10.0f), true);
				HitLocation += (MoveDirection * ((float)(10)));
				LedgeWidth = Dot((HitLocation - NewMoveLedgeLocation), MoveDirection);
			}
			if(LedgeWidth < ((HandplantHeight <= 48.0f) ? 32.0f : 64.0f))
			{
				return false;
			}
			OntoEndLocation = HitLocation - (MoveDirection * PawnOwner.CylinderComponent.CollisionRadius);
		}
		OntoEndLocation.Z = NewMoveLedgeLocation.Z + PawnOwner.CylinderComponent.CollisionHeight;
		return true;
	}
	
	public virtual /*function */int FindValidOverEndLocation(Object.Vector NewMoveLedgeLocation, float MaxLedgeWidth)
	{
		/*local */Object.Vector TraceStart = default, TraceEnd = default, Extent = default, HitLocation = default, HitNormal = default;
	
		/*local */float AxisAlignVal = default;
	
		Extent = PawnOwner.GetCollisionExtent();
		Extent.Z = 48.0f;
		TraceStart = VaultEndPosition;
		TraceStart.Z = NewMoveLedgeLocation.Z - Extent.Z;
		TraceEnd = NewMoveLedgeLocation;
		TraceEnd.Z = TraceStart.Z;
		OverEndLocation = TraceStart;
		if(!MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, Extent, true))
		{
			return 1;
		}
		if(VSize2D(HitLocation - NewMoveLedgeLocation) < MaxLedgeWidth)
		{
			OverEndLocation = VaultEndPosition;
			return 0;
		}
		OverEndLocation = HitLocation;
		if(MaxLedgeWidth < 80.0f)
		{
			return 2;
		}
		AxisAlignVal = (Acos(Abs(Dot(PawnOwner.MoveNormal, vect(1.0f, 0.0f, 0.0f)))) * 4.0f) / 3.1415930f;
		AxisAlignVal = 1.0f + (AxisAlignVal * 0.4140f);
		TraceStart = HitLocation - (((AxisAlignVal * Extent.X) + 48.0f) * MoveDirection);
		if(!MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, Extent, true))
		{
			return 2;
		}
		TraceEnd = VaultEndPosition;
		TraceStart = HitLocation;
		TraceEnd.Z = TraceStart.Z;
		if(!MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, Extent, true))
		{
			return 2;
		}
		OverEndLocation = HitLocation - (MoveDirection * 16.0f);
		return 0;
	}
	
	public virtual /*function */bool FindVaultFloor(Object.Vector NewMoveLedgeLocation, Object.Vector WantedEndLocation, ref float VaultFloorZ)
	{
		/*local */Object.Vector TraceStart = default, TraceEnd = default, Extent = default, HitLocation = default, HitNormal = default;
	
		Extent = PawnOwner.GetCollisionExtent();
		Extent.Z = 8.0f;
		TraceStart = WantedEndLocation;
		TraceStart.Z = NewMoveLedgeLocation.Z + 32.0f;
		TraceEnd = WantedEndLocation;
		TraceEnd.Z = NewMoveLedgeLocation.Z - ((bVaultOnto) ? 32.0f : 240.0f);
		if(!MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceEnd, TraceStart, Extent, true))
		{
			return false;
		}
		VaultFloorZ = HitLocation.Z - Extent.Z;
		return true;
	}
	
	public virtual /*function */bool CheckCollision(Object.Vector LedgeLocation, Object.Vector PawnRefLocation, float FloorVelocity)
	{
		/*local */float MaxLedgeWidth = default, VaultFloorZ = default, TempZ = default;
		/*local */int VaultOverTestResult = default;
	
		if(!FindValidOntoEndLocation(LedgeLocation))
		{
			return false;
		}
		TempZ = VaultEndPosition.Z;
		VaultEndPosition = OntoEndLocation;
		VaultEndPosition.Z = TempZ;
		TempZ = OntoEndLocation.Z;
		OntoEndLocation = LedgeLocation + (MoveDirection * ((float)(Min(((int)(VSize2D(OntoEndLocation - LedgeLocation))), 160))));
		OntoEndLocation.Z = TempZ;
		MaxLedgeWidth = FClamp(FloorVelocity * 0.20f, 60.0f, 180.0f);
		VaultOverTestResult = FindValidOverEndLocation(LedgeLocation, MaxLedgeWidth);
		if(VaultOverTestResult != 0)
		{
			bVaultOnto = true;
		}
		VaultEndPosition = ((bVaultOnto) ? OntoEndLocation : OverEndLocation);
		if(FindVaultFloor(LedgeLocation, VaultEndPosition, ref/*probably?*/ VaultFloorZ))
		{
			bVaultOnto = VaultFloorZ > (LedgeLocation.Z - 64.0f);
			VaultEndPosition.Z = VaultFloorZ + PawnOwner.CylinderComponent.CollisionHeight;		
		}
		else
		{
			bEndMoveFalling = !bVaultOnto;
		}
		if(!CanStand(VaultEndPosition, default(bool?)))
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartReplicatedMove()
	{
		base.StartReplicatedMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */name AnimToPlay = default;
	
		bDisableFaceRotation = true;
		bEndMoveInMelee = false;
		base.StartMove();
		CameraCollisionDirection = Cross(PawnOwner.MoveNormal, vect(0.0f, 0.0f, -1.0f));
		if(PawnOwner.Weapon != default)
		{
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
		}
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		if(VaultTypes[ActiveVaultType].bResetCamera)
		{
			ResetCameraLook(0.20f);
		}
		VaultState = ((VaultTypes[ActiveVaultType].VaultTimeUp > 0.0f) ? 0 : 1);
		TargetLocation = PawnOwner.Location;
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
		if(ActiveVaultType == 3)
		{
			PawnOwner.OnTutorialEvent(21);
		}
		if(VaultTypes[ActiveVaultType].AnimNameVariation == "None")
		{
			AnimToPlay = VaultTypes[ActiveVaultType].AnimName;		
		}
		else
		{
			if((Rand(2) == 1) && PawnOwner.Weapon == default)
			{
				AnimToPlay = VaultTypes[ActiveVaultType].AnimNameVariation;			
			}
			else
			{
				AnimToPlay = VaultTypes[ActiveVaultType].AnimName;
			}
		}
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, AnimToPlay, 1.0f, 0.150f, 0.20f, default(bool?), default(bool?));
		UpdateVaultMovement();
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return VaultTypes[ActiveVaultType].bIsStringable;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		DisableVaultIK(0.10f);
	}
	
	public virtual /*simulated event */void EnableVaultIK(float BlendInTime)
	{
		/*local */Object.Vector NewHandLocation = default, Right = default;
	
		Right = Cross(PawnOwner.MoveNormal, PawnOwner.MoveLedgeNormal);
		if(VaultTypes[ActiveVaultType].bLeftHandIK)
		{
			NewHandLocation = HandLocation;
			NewHandLocation.Z += VaultTypes[ActiveVaultType].HandIKOffset.Z;
			NewHandLocation += (MoveDirection * VaultTypes[ActiveVaultType].HandIKOffset.Y);
			NewHandLocation -= (Right * 6.0f);
			PawnOwner.LeftHandWorldIKController.SetSkelControlStrength(1.0f, BlendInTime);
			PawnOwner.LeftHandWorldIKController.EffectorLocation = NewHandLocation;
			PawnOwner.LeftHandWorldIKController.EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_WorldSpace/*0*/;
		}
		if(VaultTypes[ActiveVaultType].bRightHandIK)
		{
			NewHandLocation = PawnOwner.MoveLedgeLocation;
			NewHandLocation.Z += VaultTypes[ActiveVaultType].HandIKOffset.Z;
			NewHandLocation += (MoveDirection * VaultTypes[ActiveVaultType].HandIKOffset.Y);
			NewHandLocation += (Right * 10.0f);
			PawnOwner.RightHandWorldIKController.SetSkelControlStrength(1.0f, BlendInTime);
			PawnOwner.RightHandWorldIKController.EffectorLocation = NewHandLocation;
			PawnOwner.RightHandWorldIKController.EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_WorldSpace/*0*/;
		}
	}
	
	public virtual /*simulated event */void DisableVaultIK(float BlendOutTime)
	{
		PawnOwner.LeftHandWorldIKController.SetSkelControlStrength(0.0f, BlendOutTime);
		PawnOwner.RightHandWorldIKController.SetSkelControlStrength(0.0f, BlendOutTime);
	}
	
	public override /*simulated function */void OnTimer()
	{
		UpdateVaultMovement();
	}
	
	public virtual /*simulated event */void UpdateVaultMovement()
	{
		if(VaultState == 0)
		{
			TargetLocation = PawnOwner.MoveLedgeLocation;
			TargetLocation.Z += VaultTypes[ActiveVaultType].HandplantOffset.Z;
			TargetLocation += (MoveDirection * VaultTypes[ActiveVaultType].HandplantOffset.Y);
			VaultSpeed = VSize(TargetLocation - PawnOwner.Location) / VaultTypes[ActiveVaultType].VaultTimeUp;
			SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, VaultSpeed);
			SetTimer(VaultTypes[ActiveVaultType].VaultTimeUp);
			VaultState = 1;		
		}
		else
		{
			if(VaultState == 1)
			{
				PawnOwner.SetLocation(TargetLocation);
				PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
				TargetLocation = PawnOwner.MoveLedgeLocation;
				TargetLocation.Z += VaultTypes[ActiveVaultType].LedgeOffset.Z;
				TargetLocation += (MoveDirection * VaultTypes[ActiveVaultType].LedgeOffset.Y);
				VaultSpeed = VSize2D(TargetLocation - PawnOwner.Location) / VaultTypes[ActiveVaultType].VaultTimeOver;
				SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Jump/*2*/, VaultSpeed);
				PawnOwner.CustomFullBodyNode1p.GetCustomAnimNodeSeq().SetPosition(VaultTypes[ActiveVaultType].VaultTimeUp - PawnOwner.WorldInfo.DeltaSeconds, false);
				EnableVaultIK(0.10f);
				PawnOwner.StopIgnoreLookInput();
				SetTimer(VaultTypes[ActiveVaultType].VaultTimeOver);
				VaultState = 2;			
			}
			else
			{
				if(VaultState == 2)
				{
					PawnOwner.SetLocation(TargetLocation);
					PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
					if(bEndMoveFalling)
					{
						PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
					}
					SetPreciseLocation(VaultEndPosition, ((TdMove.EPreciseLocationMode)((bEndMoveFalling) ? 4 : 2)), VSize2D(VaultEndPosition - PawnOwner.Location) / VaultTypes[ActiveVaultType].VaultTimeDown);
					VaultState = 3;
					SavedVelocity = MoveDirection * (VSize2D(VaultEndPosition - PawnOwner.Location) / VaultTypes[ActiveVaultType].VaultTimeDown);
					bDisableFaceRotation = false;
					PawnOwner.FaceRotationTimeLeft = 0.40f;
					PawnOwner.LegRotation = PawnOwner.Controller.Rotation.Yaw;
					SetTimer(VaultTypes[ActiveVaultType].VaultTimeDown);
					DisableVaultIK(0.10f);				
				}
				else
				{
					if(PawnOwner.Weapon != default)
					{
						PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
					}
					bUsePreciseLocation = false;
					if(bVaultOnto || !bEndMoveFalling)
					{
						PawnOwner.SetMove(((TdPawn.EMovement)((bVaultOnto) ? 1 : 20)), default(bool?), default(bool?));
						SavedVelocity.Z = FMax(0.0f, PawnOwner.Velocity.Z);
						PawnOwner.Velocity = SavedVelocity;
						PawnOwner.Acceleration = Normal(SavedVelocity);
						((PawnOwner.Controller) as TdPlayerController).AccelerationTime = 0.20f;					
					}
					else
					{
						PawnOwner.Velocity = Normal(PawnOwner.Velocity) * VSize2D(SavedVelocity);
						PawnOwner.Acceleration = Normal(SavedVelocity);
						((PawnOwner.Controller) as TdPlayerController).AccelerationTime = 0.20f;
						PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
					}
				}
			}
		}
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		if(VaultState == 3)
		{
			UpdateVaultMovement();
		}
		base.FailedToReachPreciseLocation();
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/)) && VaultTypes[ActiveVaultType].bMeleePossible)
		{
			bEndMoveInMelee = true;
		}
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		if(!CanStand(PawnOwner.Location, true))
		{
			return PawnOwner.Health - 1;
		}
		return base.HandleDeath(Damage);
	}
	
	public override /*function */void CheckForCameraCollision(Object.Vector CameraLocation, Object.Rotator CameraRotation)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default, TraceEnd = default, TraceStart = default, TraceExtent = default;
	
		TraceStart = CameraLocation - (CameraCollisionDirection * 5.0f);
		TraceEnd = CameraLocation + (CameraCollisionDirection * 15.0f);
		TraceExtent = vect(2.0f, 2.0f, 2.0f);
		if(MovementTraceForBlockingEx(TraceEnd, TraceStart, TraceExtent, ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal))
		{
			PawnOwner.OffsetMeshXY(HitLocation - TraceEnd, true);
		}
	}
	
	public TdMove_SpeedVault()
	{
		// Object Offset:0x005DDA86
		VaultClearObjectHeight = 35.0f;
		MaxTimeToLedge = 0.40f;
		VaultTypes = new array</*config */TdMove_SpeedVault.VaultType>
		{
			new TdMove_SpeedVault.VaultType
			{
				AnimName = (name)"autostepuprightleg",
				AnimNameVariation = (name)"None",
				bVaultOnto = true,
				MinHeight = 0.0f,
				MaxHeight = 48.0f,
				MinSpeedZ = -600.0f,
				MaxSpeedZ = 0.0f,
				MinMomentum = -1.0f,
				MaxMomentum = -1.0f,
				MaxDistanceTime = 0.20f,
				ClampSpeedMin = 100.0f,
				ClampSpeedMax = 300.0f,
				SpeedAddition = 0.0f,
				VaultTimeUp = 0.0f,
				VaultTimeOver = 0.30f,
				VaultTimeDown = 0.20f,
				OverObstacleTime = 0.20f,
				HandplantOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=5.0f
				},
				HandIKOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				LedgeOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=90.0f
				},
				bLeftHandIK = false,
				bRightHandIK = false,
				bMeleePossible = true,
				bResetCamera = false,
				bIsStringable = false,
			},
			new TdMove_SpeedVault.VaultType
			{
				AnimName = (name)"stepuprightleg88",
				AnimNameVariation = (name)"None",
				bVaultOnto = true,
				MinHeight = 48.0f,
				MaxHeight = 148.0f,
				MinSpeedZ = 0.0f,
				MaxSpeedZ = 700.0f,
				MinMomentum = -1.0f,
				MaxMomentum = 200.0f,
				MaxDistanceTime = 0.40f,
				ClampSpeedMin = 200.0f,
				ClampSpeedMax = 700.0f,
				SpeedAddition = 0.0f,
				VaultTimeUp = 0.0f,
				VaultTimeOver = 0.40f,
				VaultTimeDown = 0.250f,
				OverObstacleTime = 0.20f,
				HandplantOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				HandIKOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				LedgeOffset = new Vector
				{
					X=0.0f,
					Y=-20.0f,
					Z=60.0f
				},
				bLeftHandIK = false,
				bRightHandIK = false,
				bMeleePossible = true,
				bResetCamera = false,
				bIsStringable = false,
			},
			new TdMove_SpeedVault.VaultType
			{
				AnimName = (name)"VaultOnto",
				AnimNameVariation = (name)"None",
				bVaultOnto = true,
				MinHeight = 64.0f,
				MaxHeight = 148.0f,
				MinSpeedZ = 0.0f,
				MaxSpeedZ = 10000.0f,
				MinMomentum = -1.0f,
				MaxMomentum = -1.0f,
				MaxDistanceTime = 0.40f,
				ClampSpeedMin = 400.0f,
				ClampSpeedMax = 720.0f,
				SpeedAddition = 80.0f,
				VaultTimeUp = 0.0f,
				VaultTimeOver = 0.350f,
				VaultTimeDown = 0.30f,
				OverObstacleTime = 0.20f,
				HandplantOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=5.0f
				},
				HandIKOffset = new Vector
				{
					X=0.0f,
					Y=-7.0f,
					Z=0.0f
				},
				LedgeOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=25.0f
				},
				bLeftHandIK = true,
				bRightHandIK = false,
				bMeleePossible = true,
				bResetCamera = false,
				bIsStringable = true,
			},
			new TdMove_SpeedVault.VaultType
			{
				AnimName = (name)"VaultOver",
				AnimNameVariation = (name)"None",
				bVaultOnto = false,
				MinHeight = 64.0f,
				MaxHeight = 148.0f,
				MinSpeedZ = 0.0f,
				MaxSpeedZ = 10000.0f,
				MinMomentum = -1.0f,
				MaxMomentum = -1.0f,
				MaxDistanceTime = 0.40f,
				ClampSpeedMin = 400.0f,
				ClampSpeedMax = 720.0f,
				SpeedAddition = 80.0f,
				VaultTimeUp = 0.0f,
				VaultTimeOver = 0.350f,
				VaultTimeDown = 0.30f,
				OverObstacleTime = 0.20f,
				HandplantOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=5.0f
				},
				HandIKOffset = new Vector
				{
					X=0.0f,
					Y=-7.0f,
					Z=0.0f
				},
				LedgeOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=25.0f
				},
				bLeftHandIK = true,
				bRightHandIK = false,
				bMeleePossible = true,
				bResetCamera = false,
				bIsStringable = true,
			},
			new TdMove_SpeedVault.VaultType
			{
				AnimName = (name)"VaultOverHigh",
				AnimNameVariation = (name)"None",
				bVaultOnto = false,
				MinHeight = 145.0f,
				MaxHeight = 192.0f,
				MinSpeedZ = 50.0f,
				MaxSpeedZ = 10000.0f,
				MinMomentum = -1.0f,
				MaxMomentum = -1.0f,
				MaxDistanceTime = 0.40f,
				ClampSpeedMin = 200.0f,
				ClampSpeedMax = 400.0f,
				SpeedAddition = 0.0f,
				VaultTimeUp = 0.280f,
				VaultTimeOver = 0.30f,
				VaultTimeDown = 0.450f,
				OverObstacleTime = 0.350f,
				HandplantOffset = new Vector
				{
					X=0.0f,
					Y=-40.0f,
					Z=-69.0f
				},
				HandIKOffset = new Vector
				{
					X=0.0f,
					Y=-7.0f,
					Z=0.0f
				},
				LedgeOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=5.0f
				},
				bLeftHandIK = false,
				bRightHandIK = false,
				bMeleePossible = true,
				bResetCamera = true,
				bIsStringable = false,
			},
			new TdMove_SpeedVault.VaultType
			{
				AnimName = (name)"VaultOntoHigh",
				AnimNameVariation = (name)"None",
				bVaultOnto = true,
				MinHeight = 145.0f,
				MaxHeight = 192.0f,
				MinSpeedZ = 50.0f,
				MaxSpeedZ = 10000.0f,
				MinMomentum = -1.0f,
				MaxMomentum = -1.0f,
				MaxDistanceTime = 0.40f,
				ClampSpeedMin = 200.0f,
				ClampSpeedMax = 400.0f,
				SpeedAddition = 0.0f,
				VaultTimeUp = 0.270f,
				VaultTimeOver = 0.30f,
				VaultTimeDown = 0.60f,
				OverObstacleTime = 0.350f,
				HandplantOffset = new Vector
				{
					X=0.0f,
					Y=-65.0f,
					Z=-15.0f
				},
				HandIKOffset = new Vector
				{
					X=0.0f,
					Y=-7.0f,
					Z=0.0f
				},
				LedgeOffset = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=35.0f
				},
				bLeftHandIK = true,
				bRightHandIK = true,
				bMeleePossible = true,
				bResetCamera = true,
				bIsStringable = false,
			},
		};
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bDisableCollision = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bAvoidLedges = false;
		bUseCameraCollision = true;
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 50.0f,
			Medium = 50.0f,
			Hard = 50.0f,
		};
		MovementGroup = TdMove.EMovementGroup.MG_OneHandBusy;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-3000,
			Yaw=-8000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=6000,
			Yaw=8000,
			Roll=32768
		};
	}
}
}