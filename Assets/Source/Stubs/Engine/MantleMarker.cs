namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MantleMarker : NavigationPoint/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ /*editconst */CoverLink.CoverInfo OwningSlot;
	
	public MantleMarker()
	{
		var Default__MantleMarker_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x0046664B
			CollisionHeight = 40.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__MantleMarker.CollisionCylinder' */;
		// Object Offset:0x00355648
		bSpecialMove = true;
		CylinderComponent = Default__MantleMarker_CollisionCylinder;
		GoodSprite = LoadAsset<SpriteComponent>("Default__MantleMarker.Sprite")/*Ref SpriteComponent'Default__MantleMarker.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__MantleMarker.Sprite2")/*Ref SpriteComponent'Default__MantleMarker.Sprite2'*/;
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__MantleMarker_CollisionCylinder,
			LoadAsset<PathRenderingComponent>("Default__MantleMarker.PathRenderer")/*Ref PathRenderingComponent'Default__MantleMarker.PathRenderer'*/,
		};
		CollisionComponent = Default__MantleMarker_CollisionCylinder;
	}
}
}