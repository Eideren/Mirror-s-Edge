namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PathNode : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public PathNode()
	{
		// Object Offset:0x0038C15B
		bCanBePlayerNavigationPoint = true;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__PathNode.CollisionCylinder")/*Ref CylinderComponent'Default__PathNode.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x00459436
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Pickup")/*Ref Texture2D'EngineResources.S_Pickup'*/,
		}/* Reference: SpriteComponent'Default__PathNode.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__PathNode.Sprite2")/*Ref SpriteComponent'Default__PathNode.Sprite2'*/;
		Abbrev = "PN";
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x00459436
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Pickup")/*Ref Texture2D'EngineResources.S_Pickup'*/,
			}/* Reference: SpriteComponent'Default__PathNode.Sprite' */,
			LoadAsset<SpriteComponent>("Default__PathNode.Sprite2")/*Ref SpriteComponent'Default__PathNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__PathNode.Arrow")/*Ref ArrowComponent'Default__PathNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__PathNode.CollisionCylinder")/*Ref CylinderComponent'Default__PathNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__PathNode.PathRenderer")/*Ref PathRenderingComponent'Default__PathNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__PathNode.CollisionCylinder")/*Ref CylinderComponent'Default__PathNode.CollisionCylinder'*/;
	}
}
}