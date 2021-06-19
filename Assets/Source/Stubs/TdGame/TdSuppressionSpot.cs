namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSuppressionSpot : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public bool Occupied;
	
	public TdSuppressionSpot()
	{
		var Default__TdSuppressionSpot_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder' */;
		var Default__TdSuppressionSpot_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52655
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SuppressIcon")/*Ref Texture2D'TdEditorResources.SuppressIcon'*/,
		}/* Reference: SpriteComponent'Default__TdSuppressionSpot.Sprite' */;
		var Default__TdSuppressionSpot_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdSuppressionSpot.Sprite2' */;
		var Default__TdSuppressionSpot_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdSuppressionSpot.Arrow' */;
		var Default__TdSuppressionSpot_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdSuppressionSpot.PathRenderer' */;
		// Object Offset:0x006733A3
		Cost = 300;
		CylinderComponent = Default__TdSuppressionSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder'*/;
		GoodSprite = Default__TdSuppressionSpot_Sprite/*Ref SpriteComponent'Default__TdSuppressionSpot.Sprite'*/;
		BadSprite = Default__TdSuppressionSpot_Sprite2/*Ref SpriteComponent'Default__TdSuppressionSpot.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdSuppressionSpot_Sprite/*Ref SpriteComponent'Default__TdSuppressionSpot.Sprite'*/,
			Default__TdSuppressionSpot_Sprite2/*Ref SpriteComponent'Default__TdSuppressionSpot.Sprite2'*/,
			Default__TdSuppressionSpot_Arrow/*Ref ArrowComponent'Default__TdSuppressionSpot.Arrow'*/,
			Default__TdSuppressionSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder'*/,
			Default__TdSuppressionSpot_PathRenderer/*Ref PathRenderingComponent'Default__TdSuppressionSpot.PathRenderer'*/,
		};
		CollisionComponent = Default__TdSuppressionSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdSuppressionSpot.CollisionCylinder'*/;
	}
}
}