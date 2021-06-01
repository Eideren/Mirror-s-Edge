namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdConfinedVolumePathNode : VolumePathNode/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(NavigationPoint)*/ float MaxRadius;
	public/*(NavigationPoint)*/ float MaxHeight;
	public String name2;
	public float CalculatedRadius;
	public float CalculatedHeight;
	
	public TdConfinedVolumePathNode()
	{
		// Object Offset:0x0050969E
		MaxRadius = 1000.0f;
		MaxHeight = 1000.0f;
		CalculatedRadius = 1000.0f;
		CalculatedHeight = 1000.0f;
		bNoAutoConnect = false;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdConfinedVolumePathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdConfinedVolumePathNode.Sprite")/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdConfinedVolumePathNode.Sprite2")/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdConfinedVolumePathNode.Sprite")/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdConfinedVolumePathNode.Sprite2")/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdConfinedVolumePathNode.Arrow")/*Ref ArrowComponent'Default__TdConfinedVolumePathNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdConfinedVolumePathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdConfinedVolumePathNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdConfinedVolumePathNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdConfinedVolumePathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder'*/;
	}
}
}