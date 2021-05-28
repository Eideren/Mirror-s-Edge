namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLandingNode : TdMoveNode/*
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdLandingNode()
	{
		// Object Offset:0x00583BCE
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdLandingNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdLandingNode.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdLandingNode.Sprite")/*Ref SpriteComponent'Default__TdLandingNode.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdLandingNode.Sprite2")/*Ref SpriteComponent'Default__TdLandingNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdLandingNode.Sprite")/*Ref SpriteComponent'Default__TdLandingNode.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdLandingNode.Sprite2")/*Ref SpriteComponent'Default__TdLandingNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdLandingNode.Arrow")/*Ref ArrowComponent'Default__TdLandingNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdLandingNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdLandingNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdLandingNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdLandingNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdLandingNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdLandingNode.CollisionCylinder'*/;
	}
}
}