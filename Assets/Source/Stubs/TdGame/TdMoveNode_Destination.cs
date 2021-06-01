namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_Destination : TdMoveNode/*
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force,TdMoveNode)*/{
	public TdMoveNode_Destination()
	{
		// Object Offset:0x005F2A11
		bIsSkippable = true;
		bIsSpecialMove = false;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_Destination.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E52249
			Sprite = LoadAsset<Texture2D>("TdEditorResources.DestinationIcon")/*Ref Texture2D'TdEditorResources.DestinationIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Destination.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_Destination.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_Destination.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E52249
				Sprite = LoadAsset<Texture2D>("TdEditorResources.DestinationIcon")/*Ref Texture2D'TdEditorResources.DestinationIcon'*/,
			}/* Reference: SpriteComponent'Default__TdMoveNode_Destination.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_Destination.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_Destination.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_Destination.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_Destination.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_Destination.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_Destination.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_Destination.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_Destination.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_Destination.CollisionCylinder'*/;
	}
}
}