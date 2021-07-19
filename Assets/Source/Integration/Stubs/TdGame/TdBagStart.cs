namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagStart : PlayerStart/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force,Collision)*/{
	[Category] public int PursuitSpawnID;
	
	public TdBagStart()
	{
		var Default__TdBagStart_PlayerStartTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__TdBagStart.PlayerStartTextureResourcesObject' */;
		var Default__TdBagStart_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBagStart.CollisionCylinder' */;
		var Default__TdBagStart_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51DDD
			Sprite = LoadAsset<Texture2D>("TdEditorResources.BagSpawnIcon")/*Ref Texture2D'TdEditorResources.BagSpawnIcon'*/,
		}/* Reference: SpriteComponent'Default__TdBagStart.Sprite' */;
		var Default__TdBagStart_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdBagStart.Sprite2' */;
		var Default__TdBagStart_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBagStart.Arrow' */;
		var Default__TdBagStart_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdBagStart.PathRenderer' */;
		// Object Offset:0x0050D049
		PlayerStartTextureResources = Default__TdBagStart_PlayerStartTextureResourcesObject/*Ref RequestedTextureResources'Default__TdBagStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = Default__TdBagStart_CollisionCylinder/*Ref CylinderComponent'Default__TdBagStart.CollisionCylinder'*/;
		GoodSprite = Default__TdBagStart_Sprite/*Ref SpriteComponent'Default__TdBagStart.Sprite'*/;
		BadSprite = Default__TdBagStart_Sprite2/*Ref SpriteComponent'Default__TdBagStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBagStart_Sprite/*Ref SpriteComponent'Default__TdBagStart.Sprite'*/,
			Default__TdBagStart_Sprite2/*Ref SpriteComponent'Default__TdBagStart.Sprite2'*/,
			Default__TdBagStart_Arrow/*Ref ArrowComponent'Default__TdBagStart.Arrow'*/,
			Default__TdBagStart_CollisionCylinder/*Ref CylinderComponent'Default__TdBagStart.CollisionCylinder'*/,
			Default__TdBagStart_PathRenderer/*Ref PathRenderingComponent'Default__TdBagStart.PathRenderer'*/,
		};
		CollisionComponent = Default__TdBagStart_CollisionCylinder/*Ref CylinderComponent'Default__TdBagStart.CollisionCylinder'*/;
	}
}
}