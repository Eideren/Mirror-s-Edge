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
		var Default__VolumePathNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__VolumePathNode.CollisionCylinder' */;
		var Default__VolumePathNode_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D076E
			Sprite = LoadAsset<Texture2D>("EngineResources.VolumePath")/*Ref Texture2D'EngineResources.VolumePath'*/,
		}/* Reference: SpriteComponent'Default__VolumePathNode.Sprite' */;
		var Default__VolumePathNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__VolumePathNode.Sprite2' */;
		var Default__VolumePathNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__VolumePathNode.Arrow' */;
		var Default__VolumePathNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__VolumePathNode.PathRenderer' */;
		// Object Offset:0x00459522
		StartingRadius = 2000.0f;
		StartingHeight = 2000.0f;
		bNoAutoConnect = true;
		bNotBased = true;
		bFlyingPreferred = true;
		bVehicleDestination = true;
		bCanBePlayerNavigationPoint = false;
		CylinderComponent = Default__VolumePathNode_CollisionCylinder/*Ref CylinderComponent'Default__VolumePathNode.CollisionCylinder'*/;
		GoodSprite = Default__VolumePathNode_Sprite/*Ref SpriteComponent'Default__VolumePathNode.Sprite'*/;
		BadSprite = Default__VolumePathNode_Sprite2/*Ref SpriteComponent'Default__VolumePathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__VolumePathNode_Sprite/*Ref SpriteComponent'Default__VolumePathNode.Sprite'*/,
			Default__VolumePathNode_Sprite2/*Ref SpriteComponent'Default__VolumePathNode.Sprite2'*/,
			Default__VolumePathNode_Arrow/*Ref ArrowComponent'Default__VolumePathNode.Arrow'*/,
			Default__VolumePathNode_CollisionCylinder/*Ref CylinderComponent'Default__VolumePathNode.CollisionCylinder'*/,
			Default__VolumePathNode_PathRenderer/*Ref PathRenderingComponent'Default__VolumePathNode.PathRenderer'*/,
		};
		CollisionComponent = Default__VolumePathNode_CollisionCylinder/*Ref CylinderComponent'Default__VolumePathNode.CollisionCylinder'*/;
	}
}
}