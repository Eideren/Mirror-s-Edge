namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_IntoZipLine : TdPhysicsMove/*
		config(PawnMovement)*/{
	public TdZiplineVolume ZipLine;
	[Category("ZipLine")] public Object.Vector HangOffset;
	[Category("ZipLine")] [config] public float ZVelocityFallLimit;
	[Category("ZipLine")] [config] public float IntoZiplineBlendInTime;
	[Category("ZipLine")] [config] public float IntoZiplineBlendOutTime;
	public float EnterZipLineParam;
	public Object.Vector SavedInitial2DVelocity;
	public/*private*/ TdAnimNodeSequence ZipLineIdleAnimation1p;
	public/*private*/ TdAnimNodeSequence ZipLineIdleAnimation3p;
	public/*private*/ name LastZipLineVolumeName;
	public/*private*/ float SameZipLineRedoMoveTime;
	
	public override /*function */bool CanDoMove()
	{
		/*local */TdMove_ZipLine ZipLineMove = default;
	
		if(ZipLine == default)
		{
			return false;
		}
		if(((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_ZipLine/*28*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_IntoZipLine/*27*/)))
		{
			return false;
		}
		if((Dot(ZipLine.MoveDirection, ((Vector)(PawnOwner.Rotation)))) <= ((float)(0)))
		{
			return false;
		}
		if(((((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Crouch/*15*/))) || ((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Slide/*16*/)))
		{
			return false;
		}
		if(VSize2D(PawnOwner.Location - ZipLine.SplineLocations[ZipLine.SplineLocations.Length - 1]) < ZipLine.LandingStrip)
		{
			return false;
		}
		ZipLineMove = ((PawnOwner.Moves[28]) as TdMove_ZipLine);
		if((SameZipLineRedoMoveTime > (PawnOwner.WorldInfo.TimeSeconds - ZipLineMove.LastStopMoveTime)) && ZipLine.Name == LastZipLineVolumeName)
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */float IntoClimbSpeed = default;
		/*local */Object.Vector DestinationToReach = default;
		/*local */Object.Rotator WantedRotation = default;
		/*local */float TimeToDestination = default;
	
		base.StartMove();
		ZipLine.FindClosestPointOnDSpline(PawnOwner.Location, ref/*probably?*/ DestinationToReach, ref/*probably?*/ EnterZipLineParam, default(int));
		ZipLine.FindClosestPointOnDSpline(DestinationToReach + (ZipLine.MoveDirection * ((float)(100))), ref/*probably?*/ DestinationToReach, ref/*probably?*/ EnterZipLineParam, default(int));
		DestinationToReach.Z += HangOffset.Z;
		LastZipLineVolumeName = ZipLine.Name;
		IntoClimbSpeed = FMax(VSize2D(PawnOwner.Velocity), 400.0f);
		WantedRotation = ((Rotator)(ZipLine.GetSlopeOnSpline(EnterZipLineParam / ((float)(ZipLine.SplineLocations.Length - 1)))));
		WantedRotation.Roll = 0;
		WantedRotation.Pitch = 0;
		TimeToDestination = VSize(DestinationToReach - PawnOwner.Location) / IntoClimbSpeed;
		SetPreciseRotation(WantedRotation, TimeToDestination);
		SavedInitial2DVelocity.X = PawnOwner.Velocity.X;
		SavedInitial2DVelocity.Y = PawnOwner.Velocity.Y;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("ZiplineStart")), FClamp(0.30f / TimeToDestination, 0.20f, 2.0f), 0.20f, 0.40f, default(bool?), default(bool?));
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_IntoZipLine/*27*/, 0.20f);
		if(PawnOwner.Velocity.Z < ((float)(0)))
		{
			SetPreciseLocation(DestinationToReach, TdMove.EPreciseLocationMode.PLM_Fly/*0*/, IntoClimbSpeed);		
		}
		else
		{
			SetPreciseLocation(DestinationToReach, TdMove.EPreciseLocationMode.PLM_Jump/*2*/, IntoClimbSpeed);
		}
		PawnOwner.SetIgnoreMoveInput(-1.0f);
	}
	
	public override /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		base.HitWall(HitNormal, Wall);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		ZipLine = default;
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float?));
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		return PawnOwner.Health - 1;
	}
	
	public virtual /*simulated function */void SetIdleAnimationReference1p(TdAnimNodeSequence AnimNode)
	{
		ZipLineIdleAnimation1p = AnimNode;
	}
	
	public virtual /*simulated function */void SetIdleAnimationReference3p(TdAnimNodeSequence AnimNode)
	{
		ZipLineIdleAnimation3p = AnimNode;
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		/*local */Object.Rotator PawnTargetRotation = default;
		/*local */Object.Vector ZipLineDir = default, ZipLineDir2D = default, PawnDir2D = default;
		/*local */bool bEnterFromLeft = default;
		/*local */float NormalizedStartPosition = default;
	
		PawnOwner.StopIgnoreMoveInput();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float?));
		if(PawnOwner.Moves[28].CanDoMove())
		{
			((PawnOwner.Moves[28]) as TdMove_ZipLine).ZipLine = ZipLine;
			ZipLineDir = ZipLine.GetSlopeOnSpline(EnterZipLineParam / ((float)(ZipLine.SplineLocations.Length - 1)));
			ZipLineDir2D = Normal(ZipLineDir);
			ZipLineDir2D.Z = 0.0f;
			PawnDir2D = Normal(((Vector)(PawnOwner.Rotation)));
			bEnterFromLeft = Cross(ZipLineDir2D, PawnDir2D).Z > 0.0f;
			PawnTargetRotation = ((Rotator)(ZipLineDir));
			PawnTargetRotation.Pitch = 0;
			PawnTargetRotation.Roll = 0;
			PawnOwner.SetRotation(PawnTargetRotation);
			if(PawnOwner.Velocity.Z < ZVelocityFallLimit)
			{
				SavedInitial2DVelocity = vect(0.0f, 0.0f, 0.0f);
			}
			PawnOwner.Velocity = ZipLineDir * (VSize2D(SavedInitial2DVelocity) * FMax(Dot(ZipLineDir, Normal(SavedInitial2DVelocity)), 0.0f));
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_ZipLine/*28*/, default(bool?), default(bool?));
			NormalizedStartPosition = ((bEnterFromLeft) ? 0.50f : 0.0f);
			ZipLineIdleAnimation1p.NormalizedStartPosition = NormalizedStartPosition;
			ZipLineIdleAnimation3p.NormalizedStartPosition = NormalizedStartPosition;		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_IntoZipLine()
	{
		// Object Offset:0x005C56AA
		HangOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-90.0f
		};
		ZVelocityFallLimit = -600.0f;
		IntoZiplineBlendInTime = 0.30f;
		IntoZiplineBlendOutTime = 0.20f;
		SameZipLineRedoMoveTime = 3.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerWalking";
		bConstrainLook = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		RedoMoveTime = 0.50f;
		MinLookConstraint = new Rotator
		{
			Pitch=-2500,
			Yaw=-7000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=32768,
			Yaw=7000,
			Roll=32768
		};
	}
}
}