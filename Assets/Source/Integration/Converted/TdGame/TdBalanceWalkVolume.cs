namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBalanceWalkVolume : TdMovementVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public override /*simulated event */void PawnLeavingVolume(Pawn P)
	{
		/*local */TdPawn TdP = default;
	
		base.PawnLeavingVolume(P);
		if(((int)P.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		TdP = ((P) as TdPawn);
		if((((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_Balance/*29*/)) && ((TdP.Moves[29]) as TdMove_Balance) != default)
		{
			if(!((TdP.Moves[29]) as TdMove_Balance).bHasFallen)
			{
				TdP.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
			}
		}
	}
	
	public override /*simulated function */void PawnUpdate(TdPawn TdP)
	{
		base.PawnUpdate(TdP);
		if(((int)TdP.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		((TdP.Moves[29]) as TdMove_Balance).Volume = this;
		if(TdP.Moves[29].CanDoMove())
		{
			TdP.SetMove(TdPawn.EMovement.MOVE_Balance/*29*/, default(bool?), default(bool?));
		}
	}
	
	public TdBalanceWalkVolume()
	{
		var Default__TdBalanceWalkVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x002B234A
			bAcceptsLights = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				bInitialized = true,
				Dynamic = true,
			},
			CollideActors = true,
			BlockNonZeroExtent = true,
			AlwaysLoadOnClient = true,
			AlwaysLoadOnServer = true,
			// Object Offset:0x0030CA5E
			BlockZeroExtent = true,
		}/* Reference: BrushComponent'Default__TdMovementVolume.BrushComponent0' */;
		var Default__TdBalanceWalkVolume_WallDir = new ArrowComponent
		{
			// Object Offset:0x0050E0F3
			ArrowColor = new Color
			{
				R=150,
				G=100,
				B=150,
				A=255
			},
			ArrowSize = 5.0f,
		}/* Reference: ArrowComponent'Default__TdMovementVolume.WallDir' */;
		var Default__TdBalanceWalkVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
			// Object Offset:0x0050E14B
			bUseAsOccluder = false,
			bUsePrecomputedShadows = false,
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdMovementVolume.MovementMesh' */;
		// Object Offset:0x0050E3E0
		bLatent = true;
		BrushComponent = Default__TdBalanceWalkVolume_BrushComponent0/*Ref BrushComponent'Default__TdBalanceWalkVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBalanceWalkVolume_BrushComponent0/*Ref BrushComponent'Default__TdBalanceWalkVolume.BrushComponent0'*/,
			Default__TdBalanceWalkVolume_WallDir/*Ref ArrowComponent'Default__TdBalanceWalkVolume.WallDir'*/,
			Default__TdBalanceWalkVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdBalanceWalkVolume.MovementMesh'*/,
		};
		CollisionComponent = Default__TdBalanceWalkVolume_BrushComponent0/*Ref BrushComponent'Default__TdBalanceWalkVolume.BrushComponent0'*/;
	}
}
}