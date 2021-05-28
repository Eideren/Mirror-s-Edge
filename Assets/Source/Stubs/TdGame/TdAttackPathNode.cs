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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdAttackPathNode()
	{
		// Object Offset:0x00509ABA
		AttackVolumeHeight = 2000.0f;
		AttackVolumeAngle = 45.0f;
		AttackVolumeRadius = 3000.0f;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdAttackPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdAttackPathNode.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdAttackPathNode.Sprite")/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdAttackPathNode.Sprite2")/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAttackPathNode.Sprite")/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdAttackPathNode.Sprite2")/*Ref SpriteComponent'Default__TdAttackPathNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdAttackPathNode.Arrow")/*Ref ArrowComponent'Default__TdAttackPathNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdAttackPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdAttackPathNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdAttackPathNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdAttackPathNode.PathRenderer'*/,
			LoadAsset<TdAttackPathNodeRenderingComponent>("Default__TdAttackPathNode.VolumeRenderer")/*Ref TdAttackPathNodeRenderingComponent'Default__TdAttackPathNode.VolumeRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdAttackPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdAttackPathNode.CollisionCylinder'*/;
	}
}
}