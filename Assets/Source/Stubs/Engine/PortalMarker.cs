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
		var Default__PortalMarker_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__PortalMarker.CollisionCylinder' */;
		var Default__PortalMarker_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PortalMarker.Sprite' */;
		var Default__PortalMarker_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PortalMarker.Sprite2' */;
		var Default__PortalMarker_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__PortalMarker.Arrow' */;
		var Default__PortalMarker_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__PortalMarker.PathRenderer' */;
		// Object Offset:0x003A309E
		CylinderComponent = Default__PortalMarker_CollisionCylinder/*Ref CylinderComponent'Default__PortalMarker.CollisionCylinder'*/;
		GoodSprite = Default__PortalMarker_Sprite/*Ref SpriteComponent'Default__PortalMarker.Sprite'*/;
		BadSprite = Default__PortalMarker_Sprite2/*Ref SpriteComponent'Default__PortalMarker.Sprite2'*/;
		bCollideWhenPlacing = false;
		bHiddenEd = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PortalMarker_Sprite/*Ref SpriteComponent'Default__PortalMarker.Sprite'*/,
			Default__PortalMarker_Sprite2/*Ref SpriteComponent'Default__PortalMarker.Sprite2'*/,
			Default__PortalMarker_Arrow/*Ref ArrowComponent'Default__PortalMarker.Arrow'*/,
			Default__PortalMarker_CollisionCylinder/*Ref CylinderComponent'Default__PortalMarker.CollisionCylinder'*/,
			Default__PortalMarker_PathRenderer/*Ref PathRenderingComponent'Default__PortalMarker.PathRenderer'*/,
		};
		CollisionComponent = Default__PortalMarker_CollisionCylinder/*Ref CylinderComponent'Default__PortalMarker.CollisionCylinder'*/;
	}
}
}