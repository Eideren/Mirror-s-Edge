namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCheckpoint : Checkpoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(Checkpoint)*/ bool DefaultCheckpoint;
	public/*(Checkpoint)*/ String CheckpointName;
	public/*(Checkpoint)*/ int CheckpointWeight;
	public/*(Checkpoint)*/ /*editconst */array</*editconst */LevelStreaming> StreamingLevels;
	
	public virtual /*function */void OnTdCheckpoint(SeqAct_TdCheckpoint CheckpointAction)
	{
	
	}
	
	public virtual /*function */bool ShouldDoCheckpoint(TdPlayerController PC)
	{
	
		return default;
	}
	
	public virtual /*simulated event */void HandlePawnTeleport(TdPawn Pawn, TdPlayerController PlayerController)
	{
	
	}
	
	public TdCheckpoint()
	{
		var Default__TdCheckpoint_CheckpointTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__TdCheckpoint.CheckpointTextureResourcesObject' */;
		var Default__TdCheckpoint_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdCheckpoint.CollisionCylinder' */;
		var Default__TdCheckpoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51E29
			Sprite = LoadAsset<Texture2D>("EngineResources.Corpse")/*Ref Texture2D'EngineResources.Corpse'*/,
		}/* Reference: SpriteComponent'Default__TdCheckpoint.Sprite' */;
		var Default__TdCheckpoint_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdCheckpoint.Sprite2' */;
		var Default__TdCheckpoint_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdCheckpoint.Arrow' */;
		var Default__TdCheckpoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdCheckpoint.PathRenderer' */;
		// Object Offset:0x0053419C
		CheckpointTextureResources = Default__TdCheckpoint_CheckpointTextureResourcesObject/*Ref RequestedTextureResources'Default__TdCheckpoint.CheckpointTextureResourcesObject'*/;
		CylinderComponent = Default__TdCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdCheckpoint.CollisionCylinder'*/;
		GoodSprite = Default__TdCheckpoint_Sprite/*Ref SpriteComponent'Default__TdCheckpoint.Sprite'*/;
		BadSprite = Default__TdCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdCheckpoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdCheckpoint_Sprite/*Ref SpriteComponent'Default__TdCheckpoint.Sprite'*/,
			Default__TdCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdCheckpoint.Sprite2'*/,
			Default__TdCheckpoint_Arrow/*Ref ArrowComponent'Default__TdCheckpoint.Arrow'*/,
			Default__TdCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdCheckpoint.CollisionCylinder'*/,
			Default__TdCheckpoint_PathRenderer/*Ref PathRenderingComponent'Default__TdCheckpoint.PathRenderer'*/,
		};
		CollisionComponent = Default__TdCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdCheckpoint.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvt_TdCheckpointActivated>(),
			ClassT<SeqEvt_TdCheckpointLoaded>(),
		};
	}
}
}