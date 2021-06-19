namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PathNode : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public PathNode()
	{
		var Default__PathNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__PathNode.CollisionCylinder' */;
		var Default__PathNode_Sprite = new SpriteComponent
		{
			// Object Offset:0x00459436
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Pickup")/*Ref Texture2D'EngineResources.S_Pickup'*/,
		}/* Reference: SpriteComponent'Default__PathNode.Sprite' */;
		var Default__PathNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PathNode.Sprite2' */;
		var Default__PathNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__PathNode.Arrow' */;
		var Default__PathNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__PathNode.PathRenderer' */;
		// Object Offset:0x0038C15B
		bCanBePlayerNavigationPoint = true;
		CylinderComponent = Default__PathNode_CollisionCylinder/*Ref CylinderComponent'Default__PathNode.CollisionCylinder'*/;
		GoodSprite = Default__PathNode_Sprite/*Ref SpriteComponent'Default__PathNode.Sprite'*/;
		BadSprite = Default__PathNode_Sprite2/*Ref SpriteComponent'Default__PathNode.Sprite2'*/;
		Abbrev = "PN";
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PathNode_Sprite/*Ref SpriteComponent'Default__PathNode.Sprite'*/,
			Default__PathNode_Sprite2/*Ref SpriteComponent'Default__PathNode.Sprite2'*/,
			Default__PathNode_Arrow/*Ref ArrowComponent'Default__PathNode.Arrow'*/,
			Default__PathNode_CollisionCylinder/*Ref CylinderComponent'Default__PathNode.CollisionCylinder'*/,
			Default__PathNode_PathRenderer/*Ref PathRenderingComponent'Default__PathNode.PathRenderer'*/,
		};
		CollisionComponent = Default__PathNode_CollisionCylinder/*Ref CylinderComponent'Default__PathNode.CollisionCylinder'*/;
	}
}
}