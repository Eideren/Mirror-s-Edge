namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagStart : PlayerStart/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force,Collision)*/{
	public/*()*/ int PursuitSpawnID;
	
	public TdBagStart()
	{
		// Object Offset:0x0050D049
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__TdBagStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdBagStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBagStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdBagStart.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E51DDD
			Sprite = LoadAsset<Texture2D>("TdEditorResources.BagSpawnIcon")/*Ref Texture2D'TdEditorResources.BagSpawnIcon'*/,
		}/* Reference: SpriteComponent'Default__TdBagStart.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdBagStart.Sprite2")/*Ref SpriteComponent'Default__TdBagStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E51DDD
				Sprite = LoadAsset<Texture2D>("TdEditorResources.BagSpawnIcon")/*Ref Texture2D'TdEditorResources.BagSpawnIcon'*/,
			}/* Reference: SpriteComponent'Default__TdBagStart.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdBagStart.Sprite2")/*Ref SpriteComponent'Default__TdBagStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdBagStart.Arrow")/*Ref ArrowComponent'Default__TdBagStart.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdBagStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdBagStart.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdBagStart.PathRenderer")/*Ref PathRenderingComponent'Default__TdBagStart.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBagStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdBagStart.CollisionCylinder'*/;
	}
}
}