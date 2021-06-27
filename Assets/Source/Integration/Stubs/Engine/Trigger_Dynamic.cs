namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Trigger_Dynamic : Trigger/*
		placeable
		hidecategories(Navigation)*/{
	public Trigger_Dynamic()
	{
		var Default__Trigger_Dynamic_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder' */;
		var Default__Trigger_Dynamic_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Trigger_Dynamic.Sprite' */;
		// Object Offset:0x003FF732
		CylinderComponent = Default__Trigger_Dynamic_CollisionCylinder/*Ref CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Trigger_Dynamic_Sprite/*Ref SpriteComponent'Default__Trigger_Dynamic.Sprite'*/,
			Default__Trigger_Dynamic_CollisionCylinder/*Ref CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder'*/,
		};
		CollisionComponent = Default__Trigger_Dynamic_CollisionCylinder/*Ref CylinderComponent'Default__Trigger_Dynamic.CollisionCylinder'*/;
	}
}
}