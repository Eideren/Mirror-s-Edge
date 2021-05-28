namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicAnchor : NavigationPoint/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public Controller CurrentUser;
	
	public DynamicAnchor()
	{
		// Object Offset:0x00311DDC
		CylinderComponent = LoadAsset<CylinderComponent>("Default__DynamicAnchor.CollisionCylinder")/*Ref CylinderComponent'Default__DynamicAnchor.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__DynamicAnchor.Sprite")/*Ref SpriteComponent'Default__DynamicAnchor.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__DynamicAnchor.Sprite2")/*Ref SpriteComponent'Default__DynamicAnchor.Sprite2'*/;
		bStatic = false;
		bNoDelete = false;
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__DynamicAnchor.Sprite")/*Ref SpriteComponent'Default__DynamicAnchor.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__DynamicAnchor.Sprite2")/*Ref SpriteComponent'Default__DynamicAnchor.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__DynamicAnchor.Arrow")/*Ref ArrowComponent'Default__DynamicAnchor.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__DynamicAnchor.CollisionCylinder")/*Ref CylinderComponent'Default__DynamicAnchor.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__DynamicAnchor.PathRenderer")/*Ref PathRenderingComponent'Default__DynamicAnchor.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__DynamicAnchor.CollisionCylinder")/*Ref CylinderComponent'Default__DynamicAnchor.CollisionCylinder'*/;
	}
}
}