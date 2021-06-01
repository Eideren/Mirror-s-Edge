namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSuppressionSpot : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public bool Occupied;
	
	public TdSuppressionSpot()
	{
		// Object Offset:0x006733A3
		Cost = 300;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdSuppressionSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E52655
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SuppressIcon")/*Ref Texture2D'TdEditorResources.SuppressIcon'*/,
		}/* Reference: SpriteComponent'Default__TdSuppressionSpot.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdSuppressionSpot.Sprite2")/*Ref SpriteComponent'Default__TdSuppressionSpot.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E52655
				Sprite = LoadAsset<Texture2D>("TdEditorResources.SuppressIcon")/*Ref Texture2D'TdEditorResources.SuppressIcon'*/,
			}/* Reference: SpriteComponent'Default__TdSuppressionSpot.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdSuppressionSpot.Sprite2")/*Ref SpriteComponent'Default__TdSuppressionSpot.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdSuppressionSpot.Arrow")/*Ref ArrowComponent'Default__TdSuppressionSpot.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdSuppressionSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdSuppressionSpot.PathRenderer")/*Ref PathRenderingComponent'Default__TdSuppressionSpot.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdSuppressionSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder'*/;
	}
}
}