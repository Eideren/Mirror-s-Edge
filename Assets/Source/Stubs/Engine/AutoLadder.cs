namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AutoLadder : Ladder/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public AutoLadder()
	{
		// Object Offset:0x002B045B
		CylinderComponent = LoadAsset<CylinderComponent>("Default__AutoLadder.CollisionCylinder")/*Ref CylinderComponent'Default__AutoLadder.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__AutoLadder.Sprite")/*Ref SpriteComponent'Default__AutoLadder.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__AutoLadder.Sprite2")/*Ref SpriteComponent'Default__AutoLadder.Sprite2'*/;
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__AutoLadder.Sprite")/*Ref SpriteComponent'Default__AutoLadder.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__AutoLadder.Sprite2")/*Ref SpriteComponent'Default__AutoLadder.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__AutoLadder.Arrow")/*Ref ArrowComponent'Default__AutoLadder.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__AutoLadder.CollisionCylinder")/*Ref CylinderComponent'Default__AutoLadder.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__AutoLadder.PathRenderer")/*Ref PathRenderingComponent'Default__AutoLadder.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__AutoLadder.CollisionCylinder")/*Ref CylinderComponent'Default__AutoLadder.CollisionCylinder'*/;
	}
}
}