namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLandingNode : TdMoveNode/*
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdLandingNode()
	{
		var Default__TdLandingNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdLandingNode.CollisionCylinder' */;
		var Default__TdLandingNode_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdLandingNode.Sprite' */;
		var Default__TdLandingNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdLandingNode.Sprite2' */;
		var Default__TdLandingNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdLandingNode.Arrow' */;
		var Default__TdLandingNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdLandingNode.PathRenderer' */;
		// Object Offset:0x00583BCE
		CylinderComponent = Default__TdLandingNode_CollisionCylinder/*Ref CylinderComponent'Default__TdLandingNode.CollisionCylinder'*/;
		GoodSprite = Default__TdLandingNode_Sprite/*Ref SpriteComponent'Default__TdLandingNode.Sprite'*/;
		BadSprite = Default__TdLandingNode_Sprite2/*Ref SpriteComponent'Default__TdLandingNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdLandingNode_Sprite/*Ref SpriteComponent'Default__TdLandingNode.Sprite'*/,
			Default__TdLandingNode_Sprite2/*Ref SpriteComponent'Default__TdLandingNode.Sprite2'*/,
			Default__TdLandingNode_Arrow/*Ref ArrowComponent'Default__TdLandingNode.Arrow'*/,
			Default__TdLandingNode_CollisionCylinder/*Ref CylinderComponent'Default__TdLandingNode.CollisionCylinder'*/,
			Default__TdLandingNode_PathRenderer/*Ref PathRenderingComponent'Default__TdLandingNode.PathRenderer'*/,
		};
		CollisionComponent = Default__TdLandingNode_CollisionCylinder/*Ref CylinderComponent'Default__TdLandingNode.CollisionCylinder'*/;
	}
}
}