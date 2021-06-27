namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode : PathNode/*
		abstract
		native
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(MoveSettings)*/ bool bStopAfterMove;
	public/*(MoveSettings)*/ bool bForceWalkToStartNode;
	public/*(MoveSettings)*/ bool bForceNewPath;
	public Core.ClassT<TdMoveReachSpec> MoveReachspecClass;
	public/*(TakedownMoveConnection)*/ NavigationPoint Destination;
	public /*config */int SpecialMoveCost;
	
	public TdMoveNode()
	{
		var Default__TdMoveNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode.CollisionCylinder' */;
		var Default__TdMoveNode_Sprite = new SpriteComponent
		{
			// Object Offset:0x0057E54C
			Sprite = LoadAsset<Texture2D>("TdEditorResources.JumpIcon")/*Ref Texture2D'TdEditorResources.JumpIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode.Sprite' */;
		var Default__TdMoveNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode.Sprite2' */;
		var Default__TdMoveNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode.Arrow' */;
		var Default__TdMoveNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode.PathRenderer' */;
		// Object Offset:0x0057E355
		bNoAutoConnect = true;
		bIsSkippable = false;
		bNeedsVelocityToTrigger = true;
		bIsSpecialMove = true;
		bCanBePlayerNavigationPoint = false;
		CylinderComponent = Default__TdMoveNode_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_Sprite/*Ref SpriteComponent'Default__TdMoveNode.Sprite'*/;
		BadSprite = Default__TdMoveNode_Sprite2/*Ref SpriteComponent'Default__TdMoveNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_Sprite/*Ref SpriteComponent'Default__TdMoveNode.Sprite'*/,
			Default__TdMoveNode_Sprite2/*Ref SpriteComponent'Default__TdMoveNode.Sprite2'*/,
			Default__TdMoveNode_Arrow/*Ref ArrowComponent'Default__TdMoveNode.Arrow'*/,
			Default__TdMoveNode_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode.CollisionCylinder'*/,
			Default__TdMoveNode_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode.PathRenderer'*/,
		};
		CollisionComponent = Default__TdMoveNode_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode.CollisionCylinder'*/;
	}
}
}