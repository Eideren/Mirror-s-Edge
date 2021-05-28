namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_JumpIntoGrab : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(Movement)*/ bool bForceSpeed;
	public/*(Movement)*/ float InitialSpeed;
	
	public TdMoveNode_JumpIntoGrab()
	{
		// Object Offset:0x005F3845
		MoveReachspecClass = ClassT<TdReachSpec_JumpIntoGrab>()/*Ref Class'TdReachSpec_JumpIntoGrab'*/;
		SpecialMoveCost = 1600;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_JumpIntoGrab.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_JumpIntoGrab.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_JumpIntoGrab.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdMoveNode_JumpIntoGrab.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_JumpIntoGrab.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_JumpIntoGrab.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_JumpIntoGrab.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_JumpIntoGrab.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_JumpIntoGrab.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_JumpIntoGrab.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_JumpIntoGrab.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_JumpIntoGrab.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_JumpIntoGrab.CollisionCylinder'*/;
	}
}
}