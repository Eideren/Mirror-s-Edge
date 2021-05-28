namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Checkpoint : NavigationPoint/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public /*const export editinline */RequestedTextureResources CheckpointTextureResources;
	
	public Checkpoint()
	{
		// Object Offset:0x002BC650
		CheckpointTextureResources = LoadAsset<RequestedTextureResources>("Default__Checkpoint.CheckpointTextureResourcesObject")/*Ref RequestedTextureResources'Default__Checkpoint.CheckpointTextureResourcesObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Checkpoint.CollisionCylinder")/*Ref CylinderComponent'Default__Checkpoint.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__Checkpoint.Sprite")/*Ref SpriteComponent'Default__Checkpoint.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__Checkpoint.Sprite2")/*Ref SpriteComponent'Default__Checkpoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__Checkpoint.Sprite")/*Ref SpriteComponent'Default__Checkpoint.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__Checkpoint.Sprite2")/*Ref SpriteComponent'Default__Checkpoint.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__Checkpoint.Arrow")/*Ref ArrowComponent'Default__Checkpoint.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__Checkpoint.CollisionCylinder")/*Ref CylinderComponent'Default__Checkpoint.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__Checkpoint.PathRenderer")/*Ref PathRenderingComponent'Default__Checkpoint.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Checkpoint.CollisionCylinder")/*Ref CylinderComponent'Default__Checkpoint.CollisionCylinder'*/;
	}
}
}