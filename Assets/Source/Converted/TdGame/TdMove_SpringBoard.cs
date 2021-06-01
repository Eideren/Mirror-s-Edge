namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_SpringBoard : TdPhysicsMove/*
		config(PawnMovement)*/{
	public/*(SpringBoard)*/ /*config */float SpringBoardMaxHeight;
	public/*(SpringBoard)*/ /*config */float SpringBoardMinHeight;
	public/*(SpringBoard)*/ /*config */float SpringBoardJumpZ;
	public/*(SpringBoard)*/ /*config */float SpringBoardJumpXYAdd;
	public/*(SpringBoard)*/ /*config */float SpringBoardJumpXYMin;
	public/*(SpringBoard)*/ /*config */float IntermediateFootPlantHeight;
	public/*(SpringBoard)*/ /*config */float IntermediateFootPlantDistance;
	public/*(SpringBoard)*/ /*config */float CheckDistanceTime;
	public Object.Vector IntermediateFootPlantLedgeLocation;
	public Object.Vector SpringBoardFootPlantLedgeLocation;
	public float StepTime1;
	public float StepTime2;
	public int SpringBoardState;
	public int SavedInitialSpeed;
	
	public override /*function */bool CanDoMove()
	{
		/*local */float LedgeHeight = default, DistanceBetweenObjs = default;
		/*local */Object.Vector VDistanceBetweenObjs = default;
		/*local */TdPawn.LedgeHitInfo FootPlantHit = default;
		/*local */Object.Vector Start = default, End = default, Extent = default, FootPlantNormal = default;
		/*local */float DistanceToStep = default, TimeToLedge = default;
		/*local */Object.Vector TestLocation = default;
	
		if(!base.CanDoMove() || !PawnOwner.bFoundLedge)
		{
			return false;
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		LedgeHeight = PawnOwner.MoveLedgeLocation.Z - (PawnOwner.Location.Z - PawnOwner.CylinderComponent.CollisionHeight);
		DistanceToStep = VSize2D(PawnOwner.MoveLedgeLocation - PawnOwner.Location);
		if(DistanceToStep < 20.0f)
		{
			return false;
		}
		TimeToLedge = DistanceToStep / ((float)(Max(1, ((int)(PawnOwner.GetAverageSpeed(0.250f))))));
		if(TimeToLedge > CheckDistanceTime)
		{
			return false;
		}
		if(Abs(LedgeHeight - IntermediateFootPlantHeight) >= 20.0f)
		{
			return false;
		}
		Extent = vect(4.0f, 4.0f, 8.0f);
		Extent.Z = (SpringBoardMaxHeight - SpringBoardMinHeight) * 0.50f;
		Start = PawnOwner.MoveLedgeLocation;
		Start.Z = PawnOwner.Location.Z - PawnOwner.CylinderComponent.CollisionHeight;
		Start.Z += (SpringBoardMinHeight + Extent.Z);
		End = Start + ((((Vector)(PawnOwner.Rotation)) * IntermediateFootPlantDistance) * 1.4140f);
		if(!FindLedge(ref/*probably?*/ FootPlantHit, Start, End, Extent))
		{
			return false;
		}
		TestLocation = FootPlantHit.LedgeLocation;
		TestLocation.Z += (PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight + 4.0f);
		if(!CanStand(TestLocation, default(bool?)))
		{
			return false;
		}
		if(FootPlantHit.LedgeNormal.Z < 0.80f)
		{
			return false;
		}
		if(FootPlantHit.FeetExcluded)
		{
			return false;
		}
		FootPlantNormal = FootPlantHit.MoveNormal;
		FootPlantNormal.Z = 0.0f;
		FootPlantNormal = Normal(FootPlantNormal);
		VDistanceBetweenObjs = FootPlantHit.LedgeLocation - PawnOwner.MoveLedgeLocation;
		DistanceBetweenObjs = VSize2D(ProjectOnTo(VDistanceBetweenObjs, FootPlantNormal));
		if(Abs(DistanceBetweenObjs - IntermediateFootPlantDistance) >= 20.0f)
		{
			return false;
		}
		IntermediateFootPlantLedgeLocation = PawnOwner.MoveLedgeLocation;
		SpringBoardFootPlantLedgeLocation = FootPlantHit.LedgeLocation;
		IntermediateFootPlantLedgeLocation.Z += 65.0f;
		SpringBoardFootPlantLedgeLocation.Z += 92.0f;
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector Pawn2Ledge = default;
		/*local */float LandingAmount = default;
	
		base.StartMove();
		SavedInitialSpeed = Max(200, ((int)(VSize2D(PawnOwner.Velocity))));
		SpringBoardState = 0;
		Pawn2Ledge = IntermediateFootPlantLedgeLocation - PawnOwner.Location;
		Pawn2Ledge.Z = 0.0f;
		LandingAmount = 0.850f;
		if(PawnOwner.LandNode1p != default)
		{
			PawnOwner.LandNode1p.Landed = LandingAmount;
		}
		if(PawnOwner.LandNode3p != default)
		{
			PawnOwner.LandNode3p.Landed = LandingAmount;
		}
		((PawnOwner.Mesh1p.FindAnimNode("LandingRun")) as TdAnimNodeCustomBlend).Activate(LandingAmount, 0.60f * LandingAmount, 0.150f, 0.40f);
		if(VSize2D(Pawn2Ledge) > 120.0f)
		{
			SetPreciseLocation(PawnOwner.Location + (Normal(Pawn2Ledge) * (VSize2D(Pawn2Ledge) - 120.0f)), TdMove.EPreciseLocationMode.PLM_Walk/*1*/, ((float)(SavedInitialSpeed)) * 1.20f);		
		}
		else
		{
			ReachedPreciseLocation();
		}
		PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
		PawnOwner.bCollideWorld = false;
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		switch(SpringBoardState)
		{
			case 0:
				SetPreciseLocation(IntermediateFootPlantLedgeLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, VSize2D(IntermediateFootPlantLedgeLocation - PawnOwner.Location) / StepTime1);
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((PawnOwner.IsLeftLegForward()) ? "SpringBoardRightLeg" : "SpringBoardLeftLeg"), 1.0f, 0.150f, 0.250f, false, default(bool?));
				SpringBoardState = 1;
				break;
			case 1:
				SetPreciseLocation(SpringBoardFootPlantLedgeLocation, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, VSize2D(SpringBoardFootPlantLedgeLocation - PawnOwner.Location) / StepTime2);
				SpringBoardState = 2;
				break;
			case 2:
				PawnOwner.Velocity = ((Vector)(PawnOwner.Rotation)) * FMax(SpringBoardJumpXYMin, ((float)(SavedInitialSpeed)) + SpringBoardJumpXYAdd);
				PawnOwner.Velocity.Z = SpringBoardJumpZ;
				if(((PawnOwner.Base != default) && !PawnOwner.Base.bWorldGeometry) && PawnOwner.Base.Velocity.Z > 0.0f)
				{
					PawnOwner.Velocity.Z += PawnOwner.Base.Velocity.Z;
				}
				PawnOwner.LastJumpLocation = PawnOwner.Location;
				PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
				PawnOwner.bCollideWorld = true;
				PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
				PawnOwner.StopIgnoreMoveInput();
				break;
			default:
				break;
		}
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.10f);
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		if(!CanStand(PawnOwner.Location, true))
		{
			return PawnOwner.Health - 1;		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		}
		return base.HandleDeath(Damage);
	}
	
	public TdMove_SpringBoard()
	{
		// Object Offset:0x005E0B55
		SpringBoardMaxHeight = 148.0f;
		SpringBoardMinHeight = 80.0f;
		SpringBoardJumpZ = 950.0f;
		SpringBoardJumpXYAdd = -100.0f;
		SpringBoardJumpXYMin = 400.0f;
		IntermediateFootPlantHeight = 64.0f;
		IntermediateFootPlantDistance = 112.0f;
		CheckDistanceTime = 1.0f;
		StepTime1 = 0.20f;
		StepTime2 = 0.20f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bCheckExitToFalling = true;
		bDelayTimeCheckAutoMoves = 0.70f;
		bTriggersCompliment = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.60f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 75.0f,
			Medium = 75.0f,
			Hard = 75.0f,
		};
		DisableMovementTime = -1.0f;
	}
}
}