namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Trigger_Dynamic : Trigger/*
		placeable
		hidecategories(Navigation)*/{
	public Trigger_Dynamic()
	{
		// Object Offset:0x003FF732
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Trigger_Dynamic.CollisionCylinder")/*Ref CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__Trigger_Dynamic.Sprite")/*Ref SpriteComponent'Default__Trigger_Dynamic.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__Trigger_Dynamic.CollisionCylinder")/*Ref CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Trigger_Dynamic.CollisionCylinder")/*Ref CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder'*/;
	}
}
}