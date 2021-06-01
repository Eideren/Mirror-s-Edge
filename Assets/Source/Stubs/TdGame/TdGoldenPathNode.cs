namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGoldenPathNode : PathNode/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdGoldenPathNode()
	{
		// Object Offset:0x0054FBAA
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdGoldenPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E51FF5
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GoldenApple")/*Ref Texture2D'TdEditorResources.GoldenApple'*/,
		}/* Reference: SpriteComponent'Default__TdGoldenPathNode.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdGoldenPathNode.Sprite2")/*Ref SpriteComponent'Default__TdGoldenPathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E51FF5
				Sprite = LoadAsset<Texture2D>("TdEditorResources.GoldenApple")/*Ref Texture2D'TdEditorResources.GoldenApple'*/,
			}/* Reference: SpriteComponent'Default__TdGoldenPathNode.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdGoldenPathNode.Sprite2")/*Ref SpriteComponent'Default__TdGoldenPathNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdGoldenPathNode.Arrow")/*Ref ArrowComponent'Default__TdGoldenPathNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdGoldenPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdGoldenPathNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdGoldenPathNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdGoldenPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdGoldenPathNode.CollisionCylinder'*/;
	}
}
}