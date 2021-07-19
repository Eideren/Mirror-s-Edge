namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdJumpNode : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	[Category("Settings")] public float ForcedSpeed;
	public bool bFallOff;
	public float MaxShortJump;
	public float MaxMediumJump;
	
	public TdJumpNode()
	{
		var Default__TdJumpNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdJumpNode.CollisionCylinder' */;
		var Default__TdJumpNode_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdJumpNode.Sprite' */;
		var Default__TdJumpNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdJumpNode.Sprite2' */;
		var Default__TdJumpNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdJumpNode.Arrow' */;
		var Default__TdJumpNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdJumpNode.PathRenderer' */;
		// Object Offset:0x0057E690
		ForcedSpeed = 720.0f;
		MaxShortJump = 480.0f;
		MaxMediumJump = 650.0f;
		MoveReachspecClass = ClassT<TdReachSpec_Jump>()/*Ref Class'TdReachSpec_Jump'*/;
		CylinderComponent = Default__TdJumpNode_CollisionCylinder/*Ref CylinderComponent'Default__TdJumpNode.CollisionCylinder'*/;
		GoodSprite = Default__TdJumpNode_Sprite/*Ref SpriteComponent'Default__TdJumpNode.Sprite'*/;
		BadSprite = Default__TdJumpNode_Sprite2/*Ref SpriteComponent'Default__TdJumpNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdJumpNode_Sprite/*Ref SpriteComponent'Default__TdJumpNode.Sprite'*/,
			Default__TdJumpNode_Sprite2/*Ref SpriteComponent'Default__TdJumpNode.Sprite2'*/,
			Default__TdJumpNode_Arrow/*Ref ArrowComponent'Default__TdJumpNode.Arrow'*/,
			Default__TdJumpNode_CollisionCylinder/*Ref CylinderComponent'Default__TdJumpNode.CollisionCylinder'*/,
			Default__TdJumpNode_PathRenderer/*Ref PathRenderingComponent'Default__TdJumpNode.PathRenderer'*/,
		};
		CollisionComponent = Default__TdJumpNode_CollisionCylinder/*Ref CylinderComponent'Default__TdJumpNode.CollisionCylinder'*/;
	}
}
}