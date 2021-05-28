namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SavedMove : Object/*
		native*/{
	public SavedMove NextMove;
	public float TimeStamp;
	public float Delta;
	public bool bRun;
	public bool bDuck;
	public bool bPressedJump;
	public bool bDoubleJump;
	public bool bPreciseDestination;
	public bool bForceRMVelocity;
	public Actor.EDoubleClickDir DoubleClickMove;
	public Actor.EPhysics SavedPhysics;
	public Object.Vector StartLocation;
	public Object.Vector StartRelativeLocation;
	public Object.Vector StartVelocity;
	public Object.Vector StartFloor;
	public Object.Vector SavedLocation;
	public Object.Vector SavedVelocity;
	public Object.Vector SavedRelativeLocation;
	public Object.Vector RMVelocity;
	public Object.Vector Acceleration;
	public Object.Rotator Rotation;
	public Actor StartBase;
	public Actor EndBase;
	public float CustomTimeDilation;
	public float AccelDotThreshold;
	
	public virtual /*function */void Clear()
	{
		TimeStamp = 0.0f;
		Delta = 0.0f;
		DoubleClickMove = Actor.EDoubleClickDir.DCLICK_None/*0*/;
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		StartVelocity = vect(0.0f, 0.0f, 0.0f);
		bRun = false;
		bDuck = false;
		bPressedJump = false;
		bDoubleJump = false;
		bPreciseDestination = false;
		bForceRMVelocity = false;
		CustomTimeDilation = 1.0f;
	}
	
	public virtual /*function */void PostUpdate(PlayerController P)
	{
		bDoubleJump = P.bDoubleJump || bDoubleJump;
		if(P.Pawn != default)
		{
			RMVelocity = P.Pawn.RMVelocity;
			SavedLocation = P.Pawn.Location;
			SavedVelocity = P.Pawn.Velocity;
			EndBase = P.Pawn.Base;
			if((EndBase != default) && !EndBase.bWorldGeometry)
			{
				SavedRelativeLocation = P.Pawn.Location - EndBase.Location;
			}
		}
		Rotation = P.Rotation;
	}
	
	public virtual /*function */bool IsImportantMove(Object.Vector CompareAccel)
	{
		/*local */Object.Vector AccelNorm = default;
	
		if((bPressedJump || bDoubleJump) || ((((int)DoubleClickMove) != ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/)) && ((int)DoubleClickMove) != ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/)) && ((int)DoubleClickMove) != ((int)Actor.EDoubleClickDir.DCLICK_Done/*6*/))
		{
			return true;
		}
		AccelNorm = Normal(Acceleration);
		return (CompareAccel != AccelNorm) && (Dot(CompareAccel, AccelNorm)) < AccelDotThreshold;
	}
	
	public virtual /*function */Object.Vector GetStartLocation()
	{
		if((StartBase != default) && !StartBase.bWorldGeometry)
		{
			return StartBase.Location + StartRelativeLocation;
		}
		return StartLocation;
	}
	
	public virtual /*function */void SetInitialPosition(Pawn P)
	{
		SavedPhysics = ((Actor.EPhysics)P.Physics);
		StartLocation = P.Location;
		StartVelocity = P.Velocity;
		StartBase = P.Base;
		StartFloor = P.Floor;
		CustomTimeDilation = P.CustomTimeDilation;
		if((StartBase != default) && !StartBase.bWorldGeometry)
		{
			StartRelativeLocation = P.Location - StartBase.Location;
		}
	}
	
	public virtual /*function */bool CanCombineWith(SavedMove NewMove, Pawn inPawn, float MaxDelta)
	{
		if(inPawn == default)
		{
			return false;
		}
		if(NewMove.Acceleration == vect(0.0f, 0.0f, 0.0f))
		{
			return ((((((((((((((Acceleration == vect(0.0f, 0.0f, 0.0f)) && StartVelocity == vect(0.0f, 0.0f, 0.0f)) && NewMove.StartVelocity == vect(0.0f, 0.0f, 0.0f)) && ((int)SavedPhysics) == ((int)inPawn.Physics)) && !bPressedJump) && !NewMove.bPressedJump) && bRun == NewMove.bRun) && bDuck == NewMove.bDuck) && bPreciseDestination == NewMove.bPreciseDestination) && bDoubleJump == NewMove.bDoubleJump) && (((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/)) || ((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/)) && ((int)NewMove.DoubleClickMove) == ((int)DoubleClickMove)) && !bForceRMVelocity) && !NewMove.bForceRMVelocity) && CustomTimeDilation == NewMove.CustomTimeDilation;		
		}
		else
		{
			return ((((((((((((((inPawn != default) && (NewMove.Delta + Delta) < MaxDelta) && ((int)SavedPhysics) == ((int)inPawn.Physics)) && !bPressedJump) && !NewMove.bPressedJump) && bRun == NewMove.bRun) && bDuck == NewMove.bDuck) && bDoubleJump == NewMove.bDoubleJump) && bPreciseDestination == NewMove.bPreciseDestination) && (((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/)) || ((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/)) && ((int)NewMove.DoubleClickMove) == ((int)DoubleClickMove)) && (Dot(Normal(Acceleration), Normal(NewMove.Acceleration))) > 0.990f) && !bForceRMVelocity) && !NewMove.bForceRMVelocity) && CustomTimeDilation == NewMove.CustomTimeDilation;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*function */void SetMoveFor(PlayerController P, float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir InDoubleClick)
	{
		Delta = DeltaTime;
		if(VSize(newAccel) > ((float)(26214)))
		{
			newAccel = ((float)(26214)) * Normal(newAccel);
		}
		if(P.Pawn != default)
		{
			SetInitialPosition(P.Pawn);
		}
		Acceleration = newAccel;
		DoubleClickMove = ((Actor.EDoubleClickDir)InDoubleClick);
		bRun = ((int)P.bRun) > ((int)0);
		bDuck = ((int)P.bDuck) > ((int)0);
		bPressedJump = P.bPressedJump;
		bDoubleJump = P.bDoubleJump;
		bPreciseDestination = P.bPreciseDestination;
		bForceRMVelocity = P.bPreciseDestination || ((P.Pawn != default) && P.Pawn.Mesh != default) && (((int)P.Pawn.Mesh.RootMotionMode) == ((int)SkeletalMeshComponent.ERootMotionMode.RMM_Accel/*3*/)) || ((int)P.Pawn.Mesh.RootMotionMode) == ((int)SkeletalMeshComponent.ERootMotionMode.RMM_Velocity/*1*/);
		TimeStamp = P.WorldInfo.TimeSeconds;
	}
	
	public virtual /*function */byte CompressedFlags()
	{
		/*local */byte Result = default;
	
		Result = (byte)DoubleClickMove;
		if(bRun)
		{
			Result += 8;
		}
		if(bDuck)
		{
			Result += 16;
		}
		if(bPressedJump)
		{
			Result += 32;
		}
		if(bDoubleJump)
		{
			Result += 64;
		}
		if(bPreciseDestination)
		{
			Result += 128;
		}
		return Result;
	}
	
	public /*function */static Actor.EDoubleClickDir SetFlags(byte Flags, PlayerController PC)
	{
		if((((int)Flags) & ((int)8)) != 0)
		{
			PC.bRun = (byte)1;		
		}
		else
		{
			PC.bRun = (byte)0;
		}
		if((((int)Flags) & ((int)16)) != 0)
		{
			PC.bDuck = (byte)1;		
		}
		else
		{
			PC.bDuck = (byte)0;
		}
		PC.bPreciseDestination = (((int)Flags) & ((int)128)) != 0;
		PC.bDoubleJump = (((int)Flags) & ((int)64)) != 0;
		PC.bPressedJump = (((int)Flags) & ((int)32)) != 0;
		switch(((int)Flags) & ((int)7))
		{
			case 0:
				return Actor.EDoubleClickDir.DCLICK_None/*0*/;
				break;
			case 1:
				return Actor.EDoubleClickDir.DCLICK_Left/*1*/;
				break;
			case 2:
				return Actor.EDoubleClickDir.DCLICK_Right/*2*/;
				break;
			case 3:
				return Actor.EDoubleClickDir.DCLICK_Forward/*3*/;
				break;
			case 4:
				return Actor.EDoubleClickDir.DCLICK_Back/*4*/;
				break;
			default:
				break;
		}
		return Actor.EDoubleClickDir.DCLICK_None/*0*/;
	}
	
	public SavedMove()
	{
		// Object Offset:0x003B1BCB
		AccelDotThreshold = 0.90f;
	}
}
}