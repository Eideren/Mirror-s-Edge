namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLedgeWalkVolume : TdMovementVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public enum ELedgeWalkType 
	{
		LWT_Ledge,
		LWT_NarrowSpace,
		LWT_MAX
	};
	
	public/*()*/ TdLedgeWalkVolume.ELedgeWalkType LedgeWalkType;
	
	public override /*simulated event */void PawnEnteredVolume(Pawn P)
	{
		/*local */TdPawn TdP = default;
	
		base.PawnEnteredVolume(P);
		if(((int)P.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		TdP = ((P) as TdPawn);
		if(TdP != default)
		{
			((TdP.Moves[30]) as TdMove_LedgeWalk).Volume = this;
			((TdP.Moves[30]) as TdMove_LedgeWalk).NotifyEnteringVolume();
			if(((int)TdP.MovementState) != ((int)TdPawn.EMovement.MOVE_LedgeWalk/*30*/))
			{
				if(TdP.Moves[30].CanDoMove())
				{
					TdP.SetMove(TdPawn.EMovement.MOVE_LedgeWalk/*30*/, default(bool?), default(bool?));				
				}
				else
				{
					((TdP.Moves[30]) as TdMove_LedgeWalk).Volume = default;
				}
			}
		}
	}
	
	public override /*simulated event */void PawnLeavingVolume(Pawn P)
	{
		/*local */TdPawn TdP = default;
	
		base.PawnLeavingVolume(P);
		if(((int)P.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		TdP = ((P) as TdPawn);
		if(((TdP != default) && ((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_LedgeWalk/*30*/)) && ((TdP.Moves[30]) as TdMove_LedgeWalk) != default)
		{
			((TdP.Moves[30]) as TdMove_LedgeWalk).NotifyLeavingVolume();
		}
	}
	
	public override /*simulated function */void PawnUpdate(TdPawn TdP)
	{
		base.PawnUpdate(TdP);
		if((((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_LedgeWalk/*30*/)) || ((int)TdP.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		((TdP.Moves[30]) as TdMove_LedgeWalk).Volume = this;
		if(TdP.Moves[30].CanDoMove())
		{
			TdP.SetMove(TdPawn.EMovement.MOVE_LedgeWalk/*30*/, default(bool?), default(bool?));
		}
	}
	
	public TdLedgeWalkVolume()
	{
		var Default__TdLedgeWalkVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdLedgeWalkVolume.BrushComponent0' */;
		var Default__TdLedgeWalkVolume_WallDir = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdLedgeWalkVolume.WallDir' */;
		var Default__TdLedgeWalkVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdLedgeWalkVolume.MovementMesh' */;
		// Object Offset:0x00586B44
		bLatent = true;
		BrushComponent = Default__TdLedgeWalkVolume_BrushComponent0/*Ref BrushComponent'Default__TdLedgeWalkVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdLedgeWalkVolume_BrushComponent0/*Ref BrushComponent'Default__TdLedgeWalkVolume.BrushComponent0'*/,
			Default__TdLedgeWalkVolume_WallDir/*Ref ArrowComponent'Default__TdLedgeWalkVolume.WallDir'*/,
			Default__TdLedgeWalkVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdLedgeWalkVolume.MovementMesh'*/,
		};
		CollisionComponent = Default__TdLedgeWalkVolume_BrushComponent0/*Ref BrushComponent'Default__TdLedgeWalkVolume.BrushComponent0'*/;
	}
}
}