namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_WallRun : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public Object.Vector StartLocation;
	public Object.Vector EndLocation;
	public float ForcedSpeed;
	public float WallDistance;
	public float MinWallHeight;
	public float MaxWallHeight;
	
	public TdMoveNode_WallRun()
	{
		var Default__TdMoveNode_WallRun_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder' */;
		var Default__TdMoveNode_WallRun_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_WallRun.Sprite' */;
		var Default__TdMoveNode_WallRun_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_WallRun.Sprite2' */;
		var Default__TdMoveNode_WallRun_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_WallRun.Arrow' */;
		var Default__TdMoveNode_WallRun_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_WallRun.PathRenderer' */;
		// Object Offset:0x005F3E5E
		ForcedSpeed = 720.0f;
		WallDistance = 210.0f;
		MinWallHeight = 250.0f;
		MaxWallHeight = 600.0f;
		MoveReachspecClass = ClassT<TdReachSpec_Wallrun>()/*Ref Class'TdReachSpec_Wallrun'*/;
		SpecialMoveCost = 2000;
		CylinderComponent = Default__TdMoveNode_WallRun_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_WallRun_Sprite/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite'*/;
		BadSprite = Default__TdMoveNode_WallRun_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_WallRun_Sprite/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite'*/,
			Default__TdMoveNode_WallRun_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite2'*/,
			Default__TdMoveNode_WallRun_Arrow/*Ref ArrowComponent'Default__TdMoveNode_WallRun.Arrow'*/,
			Default__TdMoveNode_WallRun_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder'*/,
			Default__TdMoveNode_WallRun_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_WallRun.PathRenderer'*/,
		};
		CollisionComponent = Default__TdMoveNode_WallRun_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder'*/;
	}
}
}