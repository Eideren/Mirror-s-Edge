namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AutoLadder : Ladder/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public AutoLadder()
	{
		var Default__AutoLadder_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__AutoLadder.CollisionCylinder' */;
		var Default__AutoLadder_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__AutoLadder.Sprite' */;
		var Default__AutoLadder_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__AutoLadder.Sprite2' */;
		var Default__AutoLadder_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__AutoLadder.Arrow' */;
		var Default__AutoLadder_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__AutoLadder.PathRenderer' */;
		// Object Offset:0x002B045B
		CylinderComponent = Default__AutoLadder_CollisionCylinder/*Ref CylinderComponent'Default__AutoLadder.CollisionCylinder'*/;
		GoodSprite = Default__AutoLadder_Sprite/*Ref SpriteComponent'Default__AutoLadder.Sprite'*/;
		BadSprite = Default__AutoLadder_Sprite2/*Ref SpriteComponent'Default__AutoLadder.Sprite2'*/;
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__AutoLadder_Sprite/*Ref SpriteComponent'Default__AutoLadder.Sprite'*/,
			Default__AutoLadder_Sprite2/*Ref SpriteComponent'Default__AutoLadder.Sprite2'*/,
			Default__AutoLadder_Arrow/*Ref ArrowComponent'Default__AutoLadder.Arrow'*/,
			Default__AutoLadder_CollisionCylinder/*Ref CylinderComponent'Default__AutoLadder.CollisionCylinder'*/,
			Default__AutoLadder_PathRenderer/*Ref PathRenderingComponent'Default__AutoLadder.PathRenderer'*/,
		};
		CollisionComponent = Default__AutoLadder_CollisionCylinder/*Ref CylinderComponent'Default__AutoLadder.CollisionCylinder'*/;
	}
}
}