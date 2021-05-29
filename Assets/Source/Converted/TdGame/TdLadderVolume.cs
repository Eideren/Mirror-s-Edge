namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLadderVolume : TdMovementVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public enum ELadderType 
	{
		LT_Ladder,
		LT_Pipe,
		LT_MAX
	};
	
	public/*()*/ float StepHeight;
	public float ZOffsetLadder;
	public float ZOffsetPipe;
	public float XYOffsetLadder;
	public float XYOffsetPipe;
	public array<Object.Vector> PawnLadderLocations;
	public array<Object.Vector> LadderSteps;
	public/*()*/ TdLadderVolume.ELadderType LadderType;
	public/*()*/ bool bCanExitAtTop;
	
	// Export UTdLadderVolume::execGetLadderLocation(FFrame&, void* const)
	public virtual /*native simulated function */Object.Vector GetLadderLocation(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdLadderVolume::execGetClosestStep(FFrame&, void* const)
	public virtual /*native simulated function */int GetClosestStep(float LocationZ)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdLadderVolume::execGetClosestStepUp(FFrame&, void* const)
	public virtual /*native simulated function */int GetClosestStepUp(float LocationZ)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdLadderVolume::execGetClosestStepDown(FFrame&, void* const)
	public virtual /*native simulated function */int GetClosestStepDown(float LocationZ)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdLadderVolume::execGetLastStep(FFrame&, void* const)
	public virtual /*native simulated function */int GetLastStep()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool InUse(Pawn Ignored)
	{
		/*local */TdPawn ClimbingPawn = default;
	
		
		// foreach TouchingActors(ClassT<TdPawn>(), ref/*probably?*/ ClimbingPawn)
		using var e0 = TouchingActors(ClassT<TdPawn>()).GetEnumerator();
		while(e0.MoveNext() && (ClimbingPawn = (TdPawn)e0.Current) == ClimbingPawn)
		{
			if((ClimbingPawn != Ignored) && ClimbingPawn.IsInMove(TdPawn.EMovement.MOVE_Climb/*21*/))
			{			
				return true;
			}		
		}	
		return false;
	}
	
	public override /*simulated function */void PawnUpdate(TdPawn TdP)
	{
		base.PawnUpdate(TdP);
		if(((int)TdP.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		if((((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_Climb/*21*/)) || ((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_IntoClimb/*22*/))
		{
			return;
		}
		((TdP.Moves[22]) as TdMove_IntoClimb).Ladder = this;
		((TdP.Moves[21]) as TdMove_Climb).Ladder = this;
		if(TdP.Moves[22].CanDoMove())
		{
			TdP.SetMove(TdPawn.EMovement.MOVE_IntoClimb/*22*/, default, default);
			TdP.ActiveMovementVolume = default;		
		}
		else
		{
			((TdP.Moves[22]) as TdMove_IntoClimb).Ladder = default;
			((TdP.Moves[21]) as TdMove_Climb).Ladder = default;
		}
	}
	
	public TdLadderVolume()
	{
		// Object Offset:0x005839BF
		StepHeight = 32.0f;
		ZOffsetPipe = -5.0f;
		XYOffsetLadder = -50.0f;
		XYOffsetPipe = -62.0f;
		bCanExitAtTop = true;
		bLatent = true;
		BrushComponent = LoadAsset<BrushComponent>("Default__TdLadderVolume.BrushComponent0")/*Ref BrushComponent'Default__TdLadderVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__TdLadderVolume.BrushComponent0")/*Ref BrushComponent'Default__TdLadderVolume.BrushComponent0'*/,
			LoadAsset<ArrowComponent>("Default__TdLadderVolume.WallDir")/*Ref ArrowComponent'Default__TdLadderVolume.WallDir'*/,
			LoadAsset<TdMoveVolumeRenderComponent>("Default__TdLadderVolume.MovementMesh")/*Ref TdMoveVolumeRenderComponent'Default__TdLadderVolume.MovementMesh'*/,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__TdLadderVolume.BrushComponent0")/*Ref BrushComponent'Default__TdLadderVolume.BrushComponent0'*/;
	}
}
}