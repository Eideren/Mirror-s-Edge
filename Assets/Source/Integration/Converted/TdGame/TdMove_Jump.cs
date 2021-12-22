// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Jump : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	[Category("Jump")] [config] public float BaseJumpZ;
	[Category("Jump")] [config] public float BaseJumpZHeavy;
	[Category("Jump")] [config] public float JumpAddXY;
	[Category("Jump")] [config] public float LongJumpSlowThreshold;
	[Category("Jump")] [config] public float LongJumpNormalThreshold;
	[Category("Jump")] [config] public float LongJumpFastThreshold;
	[Category("Jump")] [config] public float JumpBlendInTime;
	[Category("Jump")] [config] public float JumpBlendOutTime;
	[Category("Jump")] [config] public float JumpStillBlendOutTime;
	public float PreJumpMomentum;
	public Object.Vector WantedJumpVelocity;
	public float CanDoMoveTaserLimit;
	
	// Export UTdMove_Jump::execIsOkToJump(FFrame&, void* const)
	//public virtual /*native final function */bool IsOkToJump()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		if(PawnOwner.bUncontrolledSlide && ((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_RumpSlide/*38*/))
		{
			return false;
		}
		if(PawnOwner.GetMobilityMultiplier() < CanDoMoveTaserLimit)
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */float ZDistanceToLedge = default, TimeToLedge2D = default, ZDistanceWith2DTime = default;
		/*local */Object.Vector PawnLocationLedgeZ = default, WantedJumpLocation = default, Start = default, MoveNormal2D = default;
		/*local */TdPawn.EWeaponType CurrentWeaponType = default;
	
		if(IsOkToJump())
		{
			PawnOwner.NotifyJump();
		}
		PawnOwner.LastJumpLocation = PawnOwner.Location;
		WantedJumpVelocity = PawnOwner.Velocity;
		PreJumpMomentum = VSize2D(WantedJumpVelocity);
		CurrentWeaponType = ((TdPawn.EWeaponType)PawnOwner.GetWeaponType());
		if(((Dot(((Vector)(PawnOwner.Rotation)), PawnOwner.Velocity)) > 10.0f) && ((int)CurrentWeaponType) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			WantedJumpVelocity += (JumpAddXY * ((Vector)(PawnOwner.Rotation)));
		}
		WantedJumpVelocity.Z = ((((int)CurrentWeaponType) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) ? BaseJumpZHeavy : BaseJumpZ) * PawnOwner.GetMobilityMultiplier();
		if((PawnOwner.Base != default) && !PawnOwner.Base.bWorldGeometry)
		{
			WantedJumpVelocity += PawnOwner.Base.Velocity;
		}
		base.StartMove();
		if((!PawnOwner.bFoundLedge || ((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)))
		{
			StartJump();		
		}
		else
		{
			ZDistanceToLedge = PawnOwner.MoveLedgeLocation.Z - (PawnOwner.Location.Z - PawnOwner.CylinderComponent.CollisionHeight);
			MoveNormal2D = -PawnOwner.MoveNormal;
			MoveNormal2D.Z = 0.0f;
			MoveNormal2D = Normal(MoveNormal2D);
			if((ZDistanceToLedge < 112.0f) && (Dot(MoveNormal2D, Normal(PawnOwner.Velocity))) > 0.70710f)
			{
				PawnLocationLedgeZ = PawnOwner.Location;
				PawnLocationLedgeZ.Z = PawnOwner.MoveLedgeLocation.Z;
				TimeToLedge2D = VSize2D(ProjectOnTo(PawnOwner.MoveLedgeLocation - PawnLocationLedgeZ, MoveNormal2D));
				TimeToLedge2D -= (PawnOwner.CylinderComponent.CollisionRadius / FMax(Abs(MoveNormal2D.X), Abs(MoveNormal2D.Y)));
				TimeToLedge2D -= 8.0f;
				TimeToLedge2D = FMax(TimeToLedge2D, 0.0f);
				TimeToLedge2D /= VSize2D(ProjectOnTo(WantedJumpVelocity, -MoveNormal2D));
				ZDistanceWith2DTime = (WantedJumpVelocity.Z * TimeToLedge2D) - (((TimeToLedge2D * TimeToLedge2D) * Abs(PawnOwner.GetGravityZ())) * 0.50f);
				if(ZDistanceWith2DTime < ZDistanceToLedge)
				{
					WantedJumpLocation = PawnOwner.MoveLedgeLocation;
					WantedJumpLocation.Z += (PawnOwner.CylinderComponent.CollisionHeight + 2.0f);
					Start = PawnOwner.Location;
					Start.Z = WantedJumpLocation.Z;
					if(!MovementTraceForBlocking(WantedJumpLocation, Start, PawnOwner.GetCollisionExtent()))
					{
						PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
						PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
						PawnOwner.bCollideWorld = false;
						SetPreciseLocation(WantedJumpLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, VSize(WantedJumpVelocity));
						return;
					}
				}
			}
			StartJump();
		}
		PawnOwner.OnTutorialEvent(11);
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return true;
	}
	
	public override /*simulated function */void StopReplicatedMove()
	{
		base.StopReplicatedMove();
		if((((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_Falling/*2*/)) && ((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(!PawnOwner.bCollideWorld)
		{
			PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
			PawnOwner.bCollideWorld = true;
			PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		}
		if((((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_Falling/*2*/)) && ((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_VaultOver/*9*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, 0.20f);
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */TdPlayerController TdPC = default;
	
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		TdPC = ((PawnOwner.Controller) as TdPlayerController);
		if(TdPC != default)
		{
			UpdateMeleeAutoLockOn(TdPC, DeltaTime, out_Rotation, ref/*probably?*/ DeltaRot);
		}
	}
	
	public virtual /*simulated function */void StartJump()
	{
		/*local */float ExpectedJumpLength = default;
		/*local */Object.Vector ExpectedLandLocation = default;
		/*local */float ForwardVelocity = default;
	
		ForwardVelocity = Dot(((Vector)(PawnOwner.Rotation)), PawnOwner.Velocity);
		if(ForwardVelocity < ((float)(5)))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpStill")), 1.0f, 0.150f, 0.150f, default(bool?), default(bool?));		
		}
		else
		{
			if(ForwardVelocity < LongJumpNormalThreshold)
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpSlow")), 1.0f, JumpBlendInTime, JumpBlendOutTime, default(bool?), default(bool?));			
			}
			else
			{
				ExpectedJumpLength = ForwardVelocity * 1.10f;
				ExpectedLandLocation = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * ExpectedJumpLength);
				if(MovementTraceForBlocking(ExpectedLandLocation - vect(0.0f, 0.0f, 200.0f), ExpectedLandLocation, PawnOwner.GetCollisionExtent()))
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpSlow")), 1.0f, JumpBlendInTime, JumpBlendOutTime, default(bool?), default(bool?));				
				}
				else
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, ((name)("JumpFast")), 1.0f, JumpBlendInTime, JumpBlendOutTime, default(bool?), default(bool?));
				}
			}
		}
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		PawnOwner.Velocity = WantedJumpVelocity;
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
		StartJump();
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		if(!PawnOwner.bCollideWorld)
		{
			return PawnOwner.Health - 1;
		}
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float?));
		return base.HandleDeath(Damage);
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_Jump()
	{
		// Object Offset:0x005C6ACB
		BaseJumpZ = 630.0f;
		BaseJumpZHeavy = 430.0f;
		JumpAddXY = 100.0f;
		LongJumpSlowThreshold = 400.0f;
		LongJumpNormalThreshold = 500.0f;
		LongJumpFastThreshold = 700.0f;
		JumpBlendInTime = 0.10f;
		JumpBlendOutTime = 0.20f;
		JumpStillBlendOutTime = 0.20f;
		CanDoMoveTaserLimit = 0.50f;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bCheckExitToFalling = true;
		bUseCameraCollision = true;
		bTwoHandedFullBodyAnimations = true;
		bAllowPickup = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.70f,
			Medium = 0.80f,
		};
	}
}
}