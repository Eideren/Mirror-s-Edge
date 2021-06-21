namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAttackPathNode : TdConfinedVolumePathNode/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(NavigationPoint)*/ float AttackVolumeHeight;
	public/*(NavigationPoint)*/ float AttackVolumeAngle;
	public/*(NavigationPoint)*/ float AttackVolumeRadius;
	
	// Export UTdAttackPathNode::execPointInside(FFrame&, void* const)
	public virtual /*native function */bool PointInside(Object.Vector Point)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public TdAttackPathNode()
	{
		var Default__TdAttackPathNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdAttackPathNode.CollisionCylinder' */;
		var Default__TdAttackPathNode_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAttackPathNode.Sprite' */;
		var Default__TdAttackPathNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAttackPathNode.Sprite2' */;
		var Default__TdAttackPathNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdAttackPathNode.Arrow' */;
		var Default__TdAttackPathNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdAttackPathNode.PathRenderer' */;
		var Default__TdAttackPathNode_VolumeRenderer = new TdAttackPathNodeRenderingComponent
		{
		}/* Reference: TdAttackPathNodeRenderingComponent'Default__TdAttackPathNode.VolumeRenderer' */;
		// Object Offset:0x00509ABA
		AttackVolumeHeight = 2000.0f;
		AttackVolumeAngle = 45.0f;
		AttackVolumeRadius = 3000.0f;
		CylinderComponent = Default__TdAttackPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdAttackPathNode.CollisionCylinder'*/;
		GoodSprite = Default__TdAttackPathNode_Sprite/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite'*/;
		BadSprite = Default__TdAttackPathNode_Sprite2/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAttackPathNode_Sprite/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite'*/,
			Default__TdAttackPathNode_Sprite2/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite2'*/,
			Default__TdAttackPathNode_Arrow/*Ref ArrowComponent'Default__TdAttackPathNode.Arrow'*/,
			Default__TdAttackPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdAttackPathNode.CollisionCylinder'*/,
			Default__TdAttackPathNode_PathRenderer/*Ref PathRenderingComponent'Default__TdAttackPathNode.PathRenderer'*/,
			Default__TdAttackPathNode_VolumeRenderer/*Ref TdAttackPathNodeRenderingComponent'Default__TdAttackPathNode.VolumeRenderer'*/,
		};
		CollisionComponent = Default__TdAttackPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdAttackPathNode.CollisionCylinder'*/;
	}
}
}