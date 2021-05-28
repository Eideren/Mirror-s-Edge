namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PortalMarker : NavigationPoint/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public PortalTeleporter MyPortal;
	
	// Export UPortalMarker::execCanTeleport(FFrame&, void* const)
	public override /*native function */bool CanTeleport(Actor A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public PortalMarker()
	{
		// Object Offset:0x003A309E
		CylinderComponent = LoadAsset<CylinderComponent>("Default__PortalMarker.CollisionCylinder")/*Ref CylinderComponent'Default__PortalMarker.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__PortalMarker.Sprite")/*Ref SpriteComponent'Default__PortalMarker.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__PortalMarker.Sprite2")/*Ref SpriteComponent'Default__PortalMarker.Sprite2'*/;
		bCollideWhenPlacing = false;
		bHiddenEd = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__PortalMarker.Sprite")/*Ref SpriteComponent'Default__PortalMarker.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__PortalMarker.Sprite2")/*Ref SpriteComponent'Default__PortalMarker.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__PortalMarker.Arrow")/*Ref ArrowComponent'Default__PortalMarker.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__PortalMarker.CollisionCylinder")/*Ref CylinderComponent'Default__PortalMarker.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__PortalMarker.PathRenderer")/*Ref PathRenderingComponent'Default__PortalMarker.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__PortalMarker.CollisionCylinder")/*Ref CylinderComponent'Default__PortalMarker.CollisionCylinder'*/;
	}
}
}