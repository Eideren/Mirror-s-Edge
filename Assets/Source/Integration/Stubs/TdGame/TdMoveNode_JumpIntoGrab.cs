namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_JumpIntoGrab : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	[Category("Movement")] public bool bForceSpeed;
	[Category("Movement")] public float InitialSpeed;
	
	public TdMoveNode_JumpIntoGrab()
	{
		var Default__TdMoveNode_JumpIntoGrab_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder' */;
		var Default__TdMoveNode_JumpIntoGrab_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite' */;
		var Default__TdMoveNode_JumpIntoGrab_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite2' */;
		var Default__TdMoveNode_JumpIntoGrab_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_JumpIntoGrab.Arrow' */;
		var Default__TdMoveNode_JumpIntoGrab_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_JumpIntoGrab.PathRenderer' */;
		// Object Offset:0x005F3845
		MoveReachspecClass = ClassT<TdReachSpec_JumpIntoGrab>()/*Ref Class'TdReachSpec_JumpIntoGrab'*/;
		SpecialMoveCost = 1600;
		CylinderComponent = Default__TdMoveNode_JumpIntoGrab_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_JumpIntoGrab_Sprite/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite'*/;
		BadSprite = Default__TdMoveNode_JumpIntoGrab_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_JumpIntoGrab_Sprite/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite'*/,
			Default__TdMoveNode_JumpIntoGrab_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite2'*/,
			Default__TdMoveNode_JumpIntoGrab_Arrow/*Ref ArrowComponent'Default__TdMoveNode_JumpIntoGrab.Arrow'*/,
			Default__TdMoveNode_JumpIntoGrab_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder'*/,
			Default__TdMoveNode_JumpIntoGrab_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_JumpIntoGrab.PathRenderer'*/,
		};
		CollisionComponent = Default__TdMoveNode_JumpIntoGrab_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder'*/;
	}
}
}