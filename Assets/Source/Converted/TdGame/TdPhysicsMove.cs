namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicsMove : TdMove/*
		abstract
		native
		config(PawnMovement)*/{
	public /*const */Actor.EPhysics PawnPhysics;
	public /*const */name ControllerState;
	public/*(Gameplay)*/ /*config */float HandPlantExtentCheckHeight;
	public/*(Gameplay)*/ /*config */float HandPlantExtentCheckWidth;
	public/*(Gameplay)*/ /*config */float HandPlantCheckDistance;
	public/*(Gameplay)*/ /*config */float HandPlantCheckHeight;
	public/*(Gameplay)*/ /*config */float ContextMoveDistanceMultiplier;
	public /*config */bool bCheckForGrab;
	public /*config */bool bCheckForVaultOver;
	public /*config */bool bCheckForWallClimb;
	public /*config */bool bCheckForEdgeInVelDir;
	public bool bCheckExitToFalling;
	public bool bCheckExitToUncontrolledFalling;
	public bool bCheckForSoftLanding;
	public /*const */float bDelayTimeCheckAutoMoves;
	public float ExitToFallingZSpeed;
	public float SoftLandingZSpeedThreshold;
	public float TimeToSoftLandingThreshold;
	
	public virtual /*simulated event */void FoundReachableHandPlant()
	{
	
	}
	
	public virtual /*simulated function */bool CanHeaveOverLedgeFullyExtented(float ForwardCheckDepth, Object.Vector DestinationFloorPosition, float HighestLedgeLocation)
	{
		return CanHeaveOverLedge(ForwardCheckDepth, DestinationFloorPosition, PawnOwner.CylinderComponent.CollisionHeight, HighestLedgeLocation);
	}
	
	public virtual /*simulated function */bool CanHeaveOverLedgeCrouched(float ForwardCheckDepth, Object.Vector DestinationFloorPosition, float HighestLedgeLocation)
	{
		/*local */float CollisionSize = default;
	
		CollisionSize = 122.0f * 0.50f;
		return CanHeaveOverLedge(ForwardCheckDepth, DestinationFloorPosition, CollisionSize, HighestLedgeLocation);
	}
	
	public virtual /*private final simulated function */bool CanHeaveOverLedge(float ForwardCheckDepth, Object.Vector DestinationFloorPosition, float CollisionHeight, float HighestLedgeLocation)
	{
		/*local */Object.Vector Start = default, End = default, Extent = default;
	
		Start = PawnOwner.Location;
		End = Start;
		End.Z = PawnOwner.MoveLedgeLocation.Z;
		End.Z += CollisionHeight;
		Extent = PawnOwner.GetCollisionExtent();
		Extent.Z = CollisionHeight;
		if(MovementTraceForBlocking(End, Start, Extent))
		{
			return false;
		}
		Start = PawnOwner.Location;
		Start.Z = (((float)(Max(((int)(DestinationFloorPosition.Z)), ((int)(HighestLedgeLocation))))) + CollisionHeight) + 2.0f;
		End = Start;
		End -= (PawnOwner.MoveNormal * ForwardCheckDepth);
		Extent = PawnOwner.GetCollisionExtent();
		Extent.Z = CollisionHeight - 2.0f;
		if(MovementTraceForBlocking(End, Start, Extent))
		{
			return false;
		}
		return true;
	}
	
	public virtual /*simulated function */bool FindFloorOverLedge(float ForwardCheckDepth, ref Object.Vector FloorPosition, float CollisionHeight)
	{
		/*local */Object.Vector Start = default, End = default, Extent = default, HitLocation = default, HitNormal = default;
	
		/*local */float SafeFactor = default;
	
		SafeFactor = 4.0f;
		Start = PawnOwner.Location;
		Start -= (PawnOwner.MoveNormal * ForwardCheckDepth);
		Start.Z = PawnOwner.MoveLedgeLocation.Z + (PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius * 1.4140f);
		Start.Z += SafeFactor;
		End = PawnOwner.Location;
		End -= (PawnOwner.MoveNormal * ForwardCheckDepth);
		End.Z = PawnOwner.MoveLedgeLocation.Z - (PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius * 1.4140f);
		End.Z -= (CollisionHeight * 2.0f);
		Extent = PawnOwner.GetCollisionExtent();
		Extent.X -= 5.0f;
		Extent.Y -= 5.0f;
		Extent.Z = 0.0f;
		if(MovementTrace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, End, Start, Extent, true))
		{
			FloorPosition = HitLocation;
			FloorPosition.Z -= Extent.Z;
			return true;
		}
		return false;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		if(((int)PawnOwner.Physics) != ((int)PawnPhysics))
		{
			PawnOwner.SetPhysics(((Actor.EPhysics)PawnPhysics));
		}
		if(ControllerState != "None")
		{
			ChangeMovementState(ControllerState);
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(ControllerState != "None")
		{
			ChangeMovementState("PlayerWalking");
		}
	}
	
	public virtual /*function */void ChangeMovementState(name NewState)
	{
		/*local */TdController C = default;
	
		C = ((PawnOwner.Controller) as TdController);
		if(NotEqual_InterfaceInterface(C, (default(TdController))))
		{
			C.OnMovementStateChange(NewState);
		}
	}
	
	public TdPhysicsMove()
	{
		// Object Offset:0x00599415
		PawnPhysics = Actor.EPhysics.PHYS_Walking;
		HandPlantExtentCheckHeight = 80.0f;
		HandPlantExtentCheckWidth = 10.0f;
		HandPlantCheckDistance = 200.0f;
		HandPlantCheckHeight = 112.0f;
		ContextMoveDistanceMultiplier = 1.80f;
		bDelayTimeCheckAutoMoves = -1.0f;
		ExitToFallingZSpeed = -400.0f;
		SoftLandingZSpeedThreshold = -400.0f;
		TimeToSoftLandingThreshold = 5.0f;
	}
}
}