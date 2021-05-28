namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Objective : NavigationPoint/*
		abstract
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public Objective()
	{
		// Object Offset:0x0035EDB5
		bMustBeReachable = true;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Objective.CollisionCylinder")/*Ref CylinderComponent'Default__Objective.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__Objective.Sprite")/*Ref SpriteComponent'Default__Objective.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__Objective.Sprite2")/*Ref SpriteComponent'Default__Objective.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__Objective.Sprite")/*Ref SpriteComponent'Default__Objective.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__Objective.Sprite2")/*Ref SpriteComponent'Default__Objective.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__Objective.Arrow")/*Ref ArrowComponent'Default__Objective.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__Objective.CollisionCylinder")/*Ref CylinderComponent'Default__Objective.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__Objective.PathRenderer")/*Ref PathRenderingComponent'Default__Objective.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Objective.CollisionCylinder")/*Ref CylinderComponent'Default__Objective.CollisionCylinder'*/;
	}
}
}