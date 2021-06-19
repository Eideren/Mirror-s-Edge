namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGuardSpot : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ float ProtectionAngle;
	
	public TdGuardSpot()
	{
		var Default__TdGuardSpot_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdGuardSpot.CollisionCylinder' */;
		var Default__TdGuardSpot_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52041
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GuardIcon")/*Ref Texture2D'TdEditorResources.GuardIcon'*/,
		}/* Reference: SpriteComponent'Default__TdGuardSpot.Sprite' */;
		var Default__TdGuardSpot_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdGuardSpot.Sprite2' */;
		var Default__TdGuardSpot_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdGuardSpot.Arrow' */;
		var Default__TdGuardSpot_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdGuardSpot.PathRenderer' */;
		var Default__TdGuardSpot_TdGuardSpotRenderer = new TdGuardSpotRenderingComponent
		{
			// Object Offset:0x03121ABE
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: TdGuardSpotRenderingComponent'Default__TdGuardSpot.TdGuardSpotRenderer' */;
		// Object Offset:0x0054FDCC
		ProtectionAngle = 180.0f;
		CylinderComponent = Default__TdGuardSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdGuardSpot.CollisionCylinder'*/;
		GoodSprite = Default__TdGuardSpot_Sprite/*Ref SpriteComponent'Default__TdGuardSpot.Sprite'*/;
		BadSprite = Default__TdGuardSpot_Sprite2/*Ref SpriteComponent'Default__TdGuardSpot.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGuardSpot_Sprite/*Ref SpriteComponent'Default__TdGuardSpot.Sprite'*/,
			Default__TdGuardSpot_Sprite2/*Ref SpriteComponent'Default__TdGuardSpot.Sprite2'*/,
			Default__TdGuardSpot_Arrow/*Ref ArrowComponent'Default__TdGuardSpot.Arrow'*/,
			Default__TdGuardSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdGuardSpot.CollisionCylinder'*/,
			Default__TdGuardSpot_PathRenderer/*Ref PathRenderingComponent'Default__TdGuardSpot.PathRenderer'*/,
			Default__TdGuardSpot_TdGuardSpotRenderer/*Ref TdGuardSpotRenderingComponent'Default__TdGuardSpot.TdGuardSpotRenderer'*/,
		};
		CollisionComponent = Default__TdGuardSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdGuardSpot.CollisionCylinder'*/;
	}
}
}