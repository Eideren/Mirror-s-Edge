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
		// Object Offset:0x005F3E5E
		ForcedSpeed = 720.0f;
		WallDistance = 210.0f;
		MinWallHeight = 250.0f;
		MaxWallHeight = 600.0f;
		MoveReachspecClass = ClassT<TdReachSpec_Wallrun>()/*Ref Class'TdReachSpec_Wallrun'*/;
		SpecialMoveCost = 2000;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_WallRun.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_WallRun.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_WallRun.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdMoveNode_WallRun.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_WallRun.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_WallRun.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_WallRun.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_WallRun.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_WallRun.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_WallRun.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_WallRun.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_WallRun.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_WallRun.CollisionCylinder'*/;
	}
}
}