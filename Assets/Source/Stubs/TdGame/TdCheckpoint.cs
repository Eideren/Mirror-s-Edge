namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCheckpoint : Checkpoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(Checkpoint)*/ bool DefaultCheckpoint;
	public/*(Checkpoint)*/ string CheckpointName;
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
		// Object Offset:0x0053419C
		CheckpointTextureResources = LoadAsset<RequestedTextureResources>("Default__TdCheckpoint.CheckpointTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdCheckpoint.CheckpointTextureResourcesObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdCheckpoint.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E51E29
			Sprite = LoadAsset<Texture2D>("EngineResources.Corpse")/*Ref Texture2D'EngineResources.Corpse'*/,
		}/* Reference: SpriteComponent'Default__TdCheckpoint.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdCheckpoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x02E51E29
				Sprite = LoadAsset<Texture2D>("EngineResources.Corpse")/*Ref Texture2D'EngineResources.Corpse'*/,
			}/* Reference: SpriteComponent'Default__TdCheckpoint.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdCheckpoint.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdCheckpoint.Arrow")/*Ref ArrowComponent'Default__TdCheckpoint.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdCheckpoint.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdCheckpoint.PathRenderer")/*Ref PathRenderingComponent'Default__TdCheckpoint.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdCheckpoint.CollisionCylinder'*/;
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