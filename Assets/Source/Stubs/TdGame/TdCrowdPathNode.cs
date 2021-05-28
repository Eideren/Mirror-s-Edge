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
		return default;
	}
	
	// Export UTdCrowdPathNode::execCanBeSeenFrom(FFrame&, void* const)
	public override /*native function */bool CanBeSeenFrom(Object.Vector Offset, NavigationPoint Other, Object.Vector otherOffset)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdCrowdPathNode()
	{
		// Object Offset:0x0053E8B0
		bNoAutoConnect = true;
		bCanBePlayerNavigationPoint = false;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdCrowdPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E51EF9
			Sprite = LoadAsset<Texture2D>("TdEditorResources.CrowdPathIcon")/*Ref Texture2D'TdEditorResources.CrowdPathIcon'*/,
		}/* Reference: SpriteComponent'Default__TdCrowdPathNode.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdCrowdPathNode.Sprite2")/*Ref SpriteComponent'Default__TdCrowdPathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x02E51EF9
				Sprite = LoadAsset<Texture2D>("TdEditorResources.CrowdPathIcon")/*Ref Texture2D'TdEditorResources.CrowdPathIcon'*/,
			}/* Reference: SpriteComponent'Default__TdCrowdPathNode.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdCrowdPathNode.Sprite2")/*Ref SpriteComponent'Default__TdCrowdPathNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdCrowdPathNode.Arrow")/*Ref ArrowComponent'Default__TdCrowdPathNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdCrowdPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdCrowdPathNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdCrowdPathNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdCrowdPathNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdCrowdPathNode.CollisionCylinder'*/;
	}
}
}