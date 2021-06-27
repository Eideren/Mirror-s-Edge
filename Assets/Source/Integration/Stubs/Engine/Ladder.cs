namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Ladder : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public LadderVolume MyLadder;
	public Ladder LadderList;
	
	public override /*event */bool SuggestMovePreparation(Pawn Other)
	{
		// stub
		return default;
	}
	
	public Ladder()
	{
		var Default__Ladder_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x002B03F3
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__Ladder.CollisionCylinder' */;
		var Default__Ladder_Sprite = new SpriteComponent
		{
			// Object Offset:0x002B038F
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Ladder")/*Ref Texture2D'EngineResources.S_Ladder'*/,
		}/* Reference: SpriteComponent'Default__Ladder.Sprite' */;
		var Default__Ladder_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Ladder.Sprite2' */;
		var Default__Ladder_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Ladder.Arrow' */;
		var Default__Ladder_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__Ladder.PathRenderer' */;
		// Object Offset:0x002B01E0
		bSpecialMove = true;
		bNotBased = true;
		CylinderComponent = Default__Ladder_CollisionCylinder/*Ref CylinderComponent'Default__Ladder.CollisionCylinder'*/;
		GoodSprite = Default__Ladder_Sprite/*Ref SpriteComponent'Default__Ladder.Sprite'*/;
		BadSprite = Default__Ladder_Sprite2/*Ref SpriteComponent'Default__Ladder.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Ladder_Sprite/*Ref SpriteComponent'Default__Ladder.Sprite'*/,
			Default__Ladder_Sprite2/*Ref SpriteComponent'Default__Ladder.Sprite2'*/,
			Default__Ladder_Arrow/*Ref ArrowComponent'Default__Ladder.Arrow'*/,
			Default__Ladder_CollisionCylinder/*Ref CylinderComponent'Default__Ladder.CollisionCylinder'*/,
			Default__Ladder_PathRenderer/*Ref PathRenderingComponent'Default__Ladder.PathRenderer'*/,
		};
		CollisionComponent = Default__Ladder_CollisionCylinder/*Ref CylinderComponent'Default__Ladder.CollisionCylinder'*/;
	}
}
}