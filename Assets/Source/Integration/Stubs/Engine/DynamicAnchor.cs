namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicAnchor : NavigationPoint/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public Controller CurrentUser;
	
	public DynamicAnchor()
	{
		var Default__DynamicAnchor_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__DynamicAnchor.CollisionCylinder' */;
		var Default__DynamicAnchor_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__DynamicAnchor.Sprite' */;
		var Default__DynamicAnchor_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__DynamicAnchor.Sprite2' */;
		var Default__DynamicAnchor_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__DynamicAnchor.Arrow' */;
		var Default__DynamicAnchor_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__DynamicAnchor.PathRenderer' */;
		// Object Offset:0x00311DDC
		CylinderComponent = Default__DynamicAnchor_CollisionCylinder/*Ref CylinderComponent'Default__DynamicAnchor.CollisionCylinder'*/;
		GoodSprite = Default__DynamicAnchor_Sprite/*Ref SpriteComponent'Default__DynamicAnchor.Sprite'*/;
		BadSprite = Default__DynamicAnchor_Sprite2/*Ref SpriteComponent'Default__DynamicAnchor.Sprite2'*/;
		bStatic = false;
		bNoDelete = false;
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DynamicAnchor_Sprite/*Ref SpriteComponent'Default__DynamicAnchor.Sprite'*/,
			Default__DynamicAnchor_Sprite2/*Ref SpriteComponent'Default__DynamicAnchor.Sprite2'*/,
			Default__DynamicAnchor_Arrow/*Ref ArrowComponent'Default__DynamicAnchor.Arrow'*/,
			Default__DynamicAnchor_CollisionCylinder/*Ref CylinderComponent'Default__DynamicAnchor.CollisionCylinder'*/,
			Default__DynamicAnchor_PathRenderer/*Ref PathRenderingComponent'Default__DynamicAnchor.PathRenderer'*/,
		};
		CollisionComponent = Default__DynamicAnchor_CollisionCylinder/*Ref CylinderComponent'Default__DynamicAnchor.CollisionCylinder'*/;
	}
}
}