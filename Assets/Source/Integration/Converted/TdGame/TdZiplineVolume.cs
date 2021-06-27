namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdZiplineVolume : TdMovementVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ float LandingStrip;
	
	public override /*function */bool InUse(Pawn Ignored)
	{
		return false;
	}
	
	public override /*simulated function */void PawnUpdate(TdPawn TdP)
	{
		base.PawnUpdate(TdP);
		if(((int)TdP.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		if(((((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_ZipLine/*28*/)) || ((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_IntoZipLine/*27*/)))
		{
			return;
		}
		((TdP.Moves[27]) as TdMove_IntoZipLine).ZipLine = this;
		if(TdP.Moves[27].CanDoMove())
		{
			TdP.SetMove(TdPawn.EMovement.MOVE_IntoZipLine/*27*/, default(bool?), default(bool?));
			TdP.ActiveMovementVolume = default;		
		}
		else
		{
			((TdP.Moves[27]) as TdMove_IntoZipLine).ZipLine = default;
		}
	}
	
	public TdZiplineVolume()
	{
		var Default__TdZiplineVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdZiplineVolume.BrushComponent0' */;
		var Default__TdZiplineVolume_WallDir = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdZiplineVolume.WallDir' */;
		var Default__TdZiplineVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdZiplineVolume.MovementMesh' */;
		// Object Offset:0x006D0944
		LandingStrip = 500.0f;
		bLatent = true;
		BrushComponent = Default__TdZiplineVolume_BrushComponent0/*Ref BrushComponent'Default__TdZiplineVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdZiplineVolume_BrushComponent0/*Ref BrushComponent'Default__TdZiplineVolume.BrushComponent0'*/,
			Default__TdZiplineVolume_WallDir/*Ref ArrowComponent'Default__TdZiplineVolume.WallDir'*/,
			Default__TdZiplineVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdZiplineVolume.MovementMesh'*/,
		};
		CollisionComponent = Default__TdZiplineVolume_BrushComponent0/*Ref BrushComponent'Default__TdZiplineVolume.BrushComponent0'*/;
	}
}
}