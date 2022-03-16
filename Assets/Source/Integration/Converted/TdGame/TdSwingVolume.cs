namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSwingVolume : TdMovementVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,AI,Interaction,PhysicsVolume,Volume)*/{
	[Category] public bool bSnapToCenter;
	[Category] public bool bThickGrip;
	
	public override /*simulated function */void PawnUpdate(TdPawn TdP)
	{
		base.PawnUpdate(TdP);
		if(((int)TdP.Role) < ((int)Actor.ENetRole.ROLE_AutonomousProxy/*2*/))
		{
			return;
		}
		if(((int)TdP.MovementState) == ((int)TdPawn.EMovement.MOVE_Swing/*60*/))
		{
			return;
		}
		((TdP.Moves[60]) as TdMove_Swing).Volume = this;
		if(TdP.Moves[60].CanDoMove())
		{
			TdP.SetMove(TdPawn.EMovement.MOVE_Swing/*60*/, default(bool?), default(bool?));
			TdP.ActiveMovementVolume = default;		
		}
		else
		{
			((TdP.Moves[60]) as TdMove_Swing).Volume = default;
		}
	}
	
	public TdSwingVolume()
	{
		var Default__TdSwingVolume_BrushComponent0 = new BrushComponent
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
		}/* Reference: BrushComponent'Default__TdSwingVolume.BrushComponent0' */;
		var Default__TdSwingVolume_WallDir = new ArrowComponent
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
		}/* Reference: ArrowComponent'Default__TdSwingVolume.WallDir' */;
		var Default__TdSwingVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
			// Object Offset:0x0050E14B
			bUseAsOccluder = false,
			bUsePrecomputedShadows = false,
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdSwingVolume.MovementMesh' */;
		// Object Offset:0x006740FD
		bThickGrip = true;
		bLatent = true;
		BrushComponent = Default__TdSwingVolume_BrushComponent0/*Ref BrushComponent'Default__TdSwingVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdSwingVolume_BrushComponent0/*Ref BrushComponent'Default__TdSwingVolume.BrushComponent0'*/,
			Default__TdSwingVolume_WallDir/*Ref ArrowComponent'Default__TdSwingVolume.WallDir'*/,
			Default__TdSwingVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdSwingVolume.MovementMesh'*/,
		};
		CollisionComponent = Default__TdSwingVolume_BrushComponent0/*Ref BrushComponent'Default__TdSwingVolume.BrushComponent0'*/;
	}
}
}