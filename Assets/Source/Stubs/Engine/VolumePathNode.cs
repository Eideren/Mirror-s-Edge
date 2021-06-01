namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class VolumePathNode : PathNode/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ float StartingRadius;
	public/*()*/ float StartingHeight;
	
	public VolumePathNode()
	{
		// Object Offset:0x00459522
		StartingRadius = 2000.0f;
		StartingHeight = 2000.0f;
		bNoAutoConnect = true;
		bNotBased = true;
		bFlyingPreferred = true;
		bVehicleDestination = true;
		bCanBePlayerNavigationPoint = false;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__VolumePathNode.CollisionCylinder")/*Ref CylinderComponent'Default__VolumePathNode.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x004D076E
			Sprite = LoadAsset<Texture2D>("EngineResources.VolumePath")/*Ref Texture2D'EngineResources.VolumePath'*/,
		}/* Reference: SpriteComponent'Default__VolumePathNode.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__VolumePathNode.Sprite2")/*Ref SpriteComponent'Default__VolumePathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004D076E
				Sprite = LoadAsset<Texture2D>("EngineResources.VolumePath")/*Ref Texture2D'EngineResources.VolumePath'*/,
			}/* Reference: SpriteComponent'Default__VolumePathNode.Sprite' */,
			LoadAsset<SpriteComponent>("Default__VolumePathNode.Sprite2")/*Ref SpriteComponent'Default__VolumePathNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__VolumePathNode.Arrow")/*Ref ArrowComponent'Default__VolumePathNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__VolumePathNode.CollisionCylinder")/*Ref CylinderComponent'Default__VolumePathNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__VolumePathNode.PathRenderer")/*Ref PathRenderingComponent'Default__VolumePathNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__VolumePathNode.CollisionCylinder")/*Ref CylinderComponent'Default__VolumePathNode.CollisionCylinder'*/;
	}
}
}