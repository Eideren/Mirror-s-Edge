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
		var Default__TdMoveNode_Sprite = new SpriteComponent
		{
			// Object Offset:0x0057E54C
			Sprite = LoadAsset<Texture2D>("TdEditorResources.JumpIcon")/*Ref Texture2D'TdEditorResources.JumpIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode.Sprite' */;
		// Object Offset:0x0057E355
		bNoAutoConnect = true;
		bIsSkippable = false;
		bNeedsVelocityToTrigger = true;
		bIsSpecialMove = true;
		bCanBePlayerNavigationPoint = false;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_Sprite;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_Sprite,
			LoadAsset<SpriteComponent>("Default__TdMoveNode.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode.Arrow")/*Ref ArrowComponent'Default__TdMoveNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode.CollisionCylinder'*/;
	}
}
}