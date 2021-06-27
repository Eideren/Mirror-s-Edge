namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_Destination : TdMoveNode/*
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force,TdMoveNode)*/{
	public TdMoveNode_Destination()
	{
		var Default__TdMoveNode_Destination_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder' */;
		var Default__TdMoveNode_Destination_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52249
			Sprite = LoadAsset<Texture2D>("TdEditorResources.DestinationIcon")/*Ref Texture2D'TdEditorResources.DestinationIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Destination.Sprite' */;
		var Default__TdMoveNode_Destination_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_Destination.Sprite2' */;
		var Default__TdMoveNode_Destination_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_Destination.Arrow' */;
		var Default__TdMoveNode_Destination_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_Destination.PathRenderer' */;
		// Object Offset:0x005F2A11
		bIsSkippable = true;
		bIsSpecialMove = false;
		CylinderComponent = Default__TdMoveNode_Destination_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_Destination_Sprite/*Ref SpriteComponent'Default__TdMoveNode_Destination.Sprite'*/;
		BadSprite = Default__TdMoveNode_Destination_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_Destination.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_Destination_Sprite/*Ref SpriteComponent'Default__TdMoveNode_Destination.Sprite'*/,
			Default__TdMoveNode_Destination_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_Destination.Sprite2'*/,
			Default__TdMoveNode_Destination_Arrow/*Ref ArrowComponent'Default__TdMoveNode_Destination.Arrow'*/,
			Default__TdMoveNode_Destination_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder'*/,
			Default__TdMoveNode_Destination_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_Destination.PathRenderer'*/,
		};
		CollisionComponent = Default__TdMoveNode_Destination_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder'*/;
	}
}
}