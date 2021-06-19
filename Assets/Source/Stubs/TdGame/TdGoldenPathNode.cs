namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGoldenPathNode : PathNode/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdGoldenPathNode()
	{
		var Default__TdGoldenPathNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder' */;
		var Default__TdGoldenPathNode_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51FF5
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GoldenApple")/*Ref Texture2D'TdEditorResources.GoldenApple'*/,
		}/* Reference: SpriteComponent'Default__TdGoldenPathNode.Sprite' */;
		var Default__TdGoldenPathNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdGoldenPathNode.Sprite2' */;
		var Default__TdGoldenPathNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdGoldenPathNode.Arrow' */;
		var Default__TdGoldenPathNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdGoldenPathNode.PathRenderer' */;
		// Object Offset:0x0054FBAA
		CylinderComponent = Default__TdGoldenPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder'*/;
		GoodSprite = Default__TdGoldenPathNode_Sprite/*Ref SpriteComponent'Default__TdGoldenPathNode.Sprite'*/;
		BadSprite = Default__TdGoldenPathNode_Sprite2/*Ref SpriteComponent'Default__TdGoldenPathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGoldenPathNode_Sprite/*Ref SpriteComponent'Default__TdGoldenPathNode.Sprite'*/,
			Default__TdGoldenPathNode_Sprite2/*Ref SpriteComponent'Default__TdGoldenPathNode.Sprite2'*/,
			Default__TdGoldenPathNode_Arrow/*Ref ArrowComponent'Default__TdGoldenPathNode.Arrow'*/,
			Default__TdGoldenPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder'*/,
			Default__TdGoldenPathNode_PathRenderer/*Ref PathRenderingComponent'Default__TdGoldenPathNode.PathRenderer'*/,
		};
		CollisionComponent = Default__TdGoldenPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder'*/;
	}
}
}