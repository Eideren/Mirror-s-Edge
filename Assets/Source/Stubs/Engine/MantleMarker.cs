namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MantleMarker : NavigationPoint/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ /*editconst */CoverLink.CoverInfo OwningSlot;
	
	public MantleMarker()
	{
		// Object Offset:0x00355648
		bSpecialMove = true;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x0046664B
			CollisionHeight = 40.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__MantleMarker.CollisionCylinder' */;
		GoodSprite = LoadAsset<SpriteComponent>("Default__MantleMarker.Sprite")/*Ref SpriteComponent'Default__MantleMarker.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__MantleMarker.Sprite2")/*Ref SpriteComponent'Default__MantleMarker.Sprite2'*/;
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new CylinderComponent
			{
				// Object Offset:0x0046664B
				CollisionHeight = 40.0f,
				CollisionRadius = 40.0f,
			}/* Reference: CylinderComponent'Default__MantleMarker.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__MantleMarker.PathRenderer")/*Ref PathRenderingComponent'Default__MantleMarker.PathRenderer'*/,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x0046664B
			CollisionHeight = 40.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__MantleMarker.CollisionCylinder' */;
	}
}
}