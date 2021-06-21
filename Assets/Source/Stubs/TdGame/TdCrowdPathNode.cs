namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCrowdPathNode : PathNode/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	// Export UTdCrowdPathNode::execHasVisibilityTo(FFrame&, void* const)
	public override /*native function */bool HasVisibilityTo(Object.Vector Offset, NavigationPoint Other, Object.Vector otherOffset)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdCrowdPathNode::execCanBeSeenFrom(FFrame&, void* const)
	public override /*native function */bool CanBeSeenFrom(Object.Vector Offset, NavigationPoint Other, Object.Vector otherOffset)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public TdCrowdPathNode()
	{
		var Default__TdCrowdPathNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder' */;
		var Default__TdCrowdPathNode_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51EF9
			Sprite = LoadAsset<Texture2D>("TdEditorResources.CrowdPathIcon")/*Ref Texture2D'TdEditorResources.CrowdPathIcon'*/,
		}/* Reference: SpriteComponent'Default__TdCrowdPathNode.Sprite' */;
		var Default__TdCrowdPathNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdCrowdPathNode.Sprite2' */;
		var Default__TdCrowdPathNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdCrowdPathNode.Arrow' */;
		var Default__TdCrowdPathNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdCrowdPathNode.PathRenderer' */;
		// Object Offset:0x0053E8B0
		bNoAutoConnect = true;
		bCanBePlayerNavigationPoint = false;
		CylinderComponent = Default__TdCrowdPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder'*/;
		GoodSprite = Default__TdCrowdPathNode_Sprite/*Ref SpriteComponent'Default__TdCrowdPathNode.Sprite'*/;
		BadSprite = Default__TdCrowdPathNode_Sprite2/*Ref SpriteComponent'Default__TdCrowdPathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdCrowdPathNode_Sprite/*Ref SpriteComponent'Default__TdCrowdPathNode.Sprite'*/,
			Default__TdCrowdPathNode_Sprite2/*Ref SpriteComponent'Default__TdCrowdPathNode.Sprite2'*/,
			Default__TdCrowdPathNode_Arrow/*Ref ArrowComponent'Default__TdCrowdPathNode.Arrow'*/,
			Default__TdCrowdPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder'*/,
			Default__TdCrowdPathNode_PathRenderer/*Ref PathRenderingComponent'Default__TdCrowdPathNode.PathRenderer'*/,
		};
		CollisionComponent = Default__TdCrowdPathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder'*/;
	}
}
}