namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_Slide : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdMoveNode_Slide()
	{
		var Default__TdMoveNode_Slide_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_Slide.CollisionCylinder' */;
		var Default__TdMoveNode_Slide_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52415
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SpeedVaultIcon")/*Ref Texture2D'TdEditorResources.SpeedVaultIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Slide.Sprite' */;
		var Default__TdMoveNode_Slide_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_Slide.Sprite2' */;
		var Default__TdMoveNode_Slide_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_Slide.Arrow' */;
		var Default__TdMoveNode_Slide_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_Slide.PathRenderer' */;
		// Object Offset:0x005F39E8
		MoveReachspecClass = ClassT<TdReachSpec_Slide>()/*Ref Class'TdReachSpec_Slide'*/;
		SpecialMoveCost = 400;
		CylinderComponent = Default__TdMoveNode_Slide_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Slide.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_Slide_Sprite/*Ref SpriteComponent'Default__TdMoveNode_Slide.Sprite'*/;
		BadSprite = Default__TdMoveNode_Slide_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_Slide.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_Slide_Sprite/*Ref SpriteComponent'Default__TdMoveNode_Slide.Sprite'*/,
			Default__TdMoveNode_Slide_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_Slide.Sprite2'*/,
			Default__TdMoveNode_Slide_Arrow/*Ref ArrowComponent'Default__TdMoveNode_Slide.Arrow'*/,
			Default__TdMoveNode_Slide_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Slide.CollisionCylinder'*/,
			Default__TdMoveNode_Slide_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_Slide.PathRenderer'*/,
		};
		CollisionComponent = Default__TdMoveNode_Slide_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Slide.CollisionCylinder'*/;
	}
}
}