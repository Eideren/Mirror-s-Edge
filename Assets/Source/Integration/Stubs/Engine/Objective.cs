namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Objective : NavigationPoint/*
		abstract
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public Objective()
	{
		var Default__Objective_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Objective.CollisionCylinder' */;
		var Default__Objective_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Objective.Sprite' */;
		var Default__Objective_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Objective.Sprite2' */;
		var Default__Objective_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Objective.Arrow' */;
		var Default__Objective_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__Objective.PathRenderer' */;
		// Object Offset:0x0035EDB5
		bMustBeReachable = true;
		CylinderComponent = Default__Objective_CollisionCylinder/*Ref CylinderComponent'Default__Objective.CollisionCylinder'*/;
		GoodSprite = Default__Objective_Sprite/*Ref SpriteComponent'Default__Objective.Sprite'*/;
		BadSprite = Default__Objective_Sprite2/*Ref SpriteComponent'Default__Objective.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Objective_Sprite/*Ref SpriteComponent'Default__Objective.Sprite'*/,
			Default__Objective_Sprite2/*Ref SpriteComponent'Default__Objective.Sprite2'*/,
			Default__Objective_Arrow/*Ref ArrowComponent'Default__Objective.Arrow'*/,
			Default__Objective_CollisionCylinder/*Ref CylinderComponent'Default__Objective.CollisionCylinder'*/,
			Default__Objective_PathRenderer/*Ref PathRenderingComponent'Default__Objective.PathRenderer'*/,
		};
		CollisionComponent = Default__Objective_CollisionCylinder/*Ref CylinderComponent'Default__Objective.CollisionCylinder'*/;
	}
}
}