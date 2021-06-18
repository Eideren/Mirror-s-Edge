namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGuardSpot : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ float ProtectionAngle;
	
	public TdGuardSpot()
	{
		var Default__TdGuardSpot_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52041
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GuardIcon")/*Ref Texture2D'TdEditorResources.GuardIcon'*/,
		}/* Reference: SpriteComponent'Default__TdGuardSpot.Sprite' */;
		var Default__TdGuardSpot_TdGuardSpotRenderer = new TdGuardSpotRenderingComponent
		{
			// Object Offset:0x03121ABE
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: TdGuardSpotRenderingComponent'Default__TdGuardSpot.TdGuardSpotRenderer' */;
		// Object Offset:0x0054FDCC
		ProtectionAngle = 180.0f;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdGuardSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdGuardSpot.CollisionCylinder'*/;
		GoodSprite = Default__TdGuardSpot_Sprite;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdGuardSpot.Sprite2")/*Ref SpriteComponent'Default__TdGuardSpot.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGuardSpot_Sprite,
			LoadAsset<SpriteComponent>("Default__TdGuardSpot.Sprite2")/*Ref SpriteComponent'Default__TdGuardSpot.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdGuardSpot.Arrow")/*Ref ArrowComponent'Default__TdGuardSpot.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdGuardSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdGuardSpot.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdGuardSpot.PathRenderer")/*Ref PathRenderingComponent'Default__TdGuardSpot.PathRenderer'*/,
			Default__TdGuardSpot_TdGuardSpotRenderer,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdGuardSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdGuardSpot.CollisionCylinder'*/;
	}
}
}