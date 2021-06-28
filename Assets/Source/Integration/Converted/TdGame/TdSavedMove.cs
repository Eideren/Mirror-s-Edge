// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSavedMove : SavedMove{
	public bool bReleasedJump;
	public TdPawn.EMoveActionHint MoveActionHint;
	
	public override /*function */void Clear()
	{
		TimeStamp = 0.0f;
		Delta = 0.0f;
		DoubleClickMove = Actor.EDoubleClickDir.DCLICK_None/*0*/;
		MoveActionHint = TdPawn.EMoveActionHint.MAH_None/*0*/;
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		StartVelocity = vect(0.0f, 0.0f, 0.0f);
		bRun = false;
		bDuck = false;
		bPressedJump = false;
		bReleasedJump = false;
		bDoubleJump = false;
		bPreciseDestination = false;
		bForceRMVelocity = false;
	}
	
	public override /*function */void SetMoveFor(PlayerController P, float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir InDoubleClick)
	{
		/*local */TdPlayerController TdPC = default;
	
		TdPC = ((P) as TdPlayerController);
		Delta = DeltaTime;
		if(VSize(newAccel) > ((float)(26214)))
		{
			newAccel = ((float)(26214)) * Normal(newAccel);
		}
		if(TdPC.myPawn != default)
		{
			SetInitialPosition(TdPC.myPawn);
			MoveActionHint = ((TdPawn.EMoveActionHint)TdPC.myPawn.MoveActionHint);
			bRun = TdPC.myPawn.bMoveActionMax;
		}
		Acceleration = newAccel;
		DoubleClickMove = ((Actor.EDoubleClickDir)InDoubleClick);
		bDuck = ((int)TdPC.bDuck) > ((int)0);
		bPressedJump = TdPC.bPressedJump;
		bReleasedJump = TdPC.bReleasedJump;
		bDoubleJump = TdPC.bDoubleJump;
		bPreciseDestination = TdPC.bPreciseDestination;
		bForceRMVelocity = ((TdPC.Pawn != default) && TdPC.Pawn.Mesh != default) && ((((int)TdPC.Pawn.Mesh.RootMotionMode) == ((int)SkeletalMeshComponent.ERootMotionMode.RMM_Accel/*3*/)) || ((int)TdPC.Pawn.Mesh.RootMotionMode) == ((int)SkeletalMeshComponent.ERootMotionMode.RMM_Velocity/*1*/));
		TimeStamp = P.WorldInfo.TimeSeconds;
	}
	
	public override /*function */byte CompressedFlags()
	{
		/*local */byte Result = default;
	
		Result = (byte)MoveActionHint;
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
		if(bReleasedJump)
		{
			Result += 64;
		}
		if(bPreciseDestination)
		{
			Result += 128;
		}
		return Result;
	}
	
	public override /*function */bool IsImportantMove(Object.Vector CompareAccel)
	{
		/*local */Object.Vector AccelNorm = default, CompareAccelNorm = default;
	
		if((bPressedJump || bReleasedJump))
		{
			return true;
		}
		AccelNorm = Normal(Acceleration);
		CompareAccelNorm = Normal(CompareAccel);
		return (((CompareAccel != AccelNorm) && (Dot(CompareAccelNorm, AccelNorm)) < AccelDotThreshold) || VSizeSq2D(Acceleration) > ((float)(16000000)));
	}
	
	public override /*function */bool CanCombineWith(SavedMove NewMove, Pawn inPawn, float MaxDelta)
	{
		/*local */TdSavedMove NewTdMove = default;
	
		NewTdMove = ((NewMove) as TdSavedMove);
		if(inPawn == default)
		{
			return false;
		}
		if(NewMove.Acceleration == vect(0.0f, 0.0f, 0.0f))
		{
			return ((((((((((((((((Acceleration == vect(0.0f, 0.0f, 0.0f)) && StartVelocity == vect(0.0f, 0.0f, 0.0f)) && NewMove.StartVelocity == vect(0.0f, 0.0f, 0.0f)) && ((int)SavedPhysics) == ((int)inPawn.Physics)) && !bPressedJump) && !NewMove.bPressedJump) && !bReleasedJump) && !NewTdMove.bReleasedJump) && bRun == NewMove.bRun) && bDuck == NewMove.bDuck) && bPreciseDestination == NewMove.bPreciseDestination) && bDoubleJump == NewMove.bDoubleJump) && ((((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/)) || ((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/))) && ((int)NewMove.DoubleClickMove) == ((int)DoubleClickMove)) && !bForceRMVelocity) && !NewMove.bForceRMVelocity) && ((int)MoveActionHint) == ((int)NewTdMove.MoveActionHint);		
		}
		else
		{
			return ((((((((((((((((inPawn != default) && (NewMove.Delta + Delta) < MaxDelta) && ((int)SavedPhysics) == ((int)inPawn.Physics)) && !bPressedJump) && !NewMove.bPressedJump) && !bReleasedJump) && !NewTdMove.bReleasedJump) && bRun == NewMove.bRun) && bDuck == NewMove.bDuck) && bDoubleJump == NewMove.bDoubleJump) && bPreciseDestination == NewMove.bPreciseDestination) && ((((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/)) || ((int)DoubleClickMove) == ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/))) && ((int)NewMove.DoubleClickMove) == ((int)DoubleClickMove)) && (Dot(Normal(Acceleration), Normal(NewMove.Acceleration))) > 0.990f) && !bForceRMVelocity) && !NewMove.bForceRMVelocity) && ((int)MoveActionHint) == ((int)NewTdMove.MoveActionHint);
		}
	}
	
	public /*function */static Actor.EDoubleClickDir SetFlags(byte Flags, PlayerController PC)
	{
		/*local */TdPlayerController TdPC = default;
		/*local */TdPawn TdP = default;
	
		TdPC = ((PC) as TdPlayerController);
		TdP = ((TdPC.Pawn) as TdPawn);
		if((((int)Flags) & ((int)16)) != 0)
		{
			TdPC.bDuck = (byte)1;		
		}
		else
		{
			TdPC.bDuck = (byte)0;
		}
		TdPC.bPreciseDestination = (((int)Flags) & ((int)128)) != 0;
		TdPC.bReleasedJump = (((int)Flags) & ((int)64)) != 0;
		TdPC.bPressedJump = (((int)Flags) & ((int)32)) != 0;
		if(TdP != default)
		{
			if((((int)Flags) & ((int)8)) != 0)
			{
				TdP.bMoveActionMax = true;			
			}
			else
			{
				TdP.bMoveActionMax = false;
			}
			switch(((int)Flags) & ((int)7))
			{
				case 0:
					TdP.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_None/*0*/, default(bool?));
					break;
				case 1:
					TdP.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_Left/*1*/, default(bool?));
					break;
				case 2:
					TdP.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_Right/*2*/, default(bool?));
					break;
				case 3:
					TdP.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_Up/*3*/, default(bool?));
					break;
				case 4:
					TdP.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_Down/*4*/, default(bool?));
					break;
				default:
					break;
			}
		}
		else
		{
			return Actor.EDoubleClickDir.DCLICK_None/*0*/;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public TdSavedMove()
	{
		// Object Offset:0x00655EE6
		AccelDotThreshold = 0.10f;
	}
}
}