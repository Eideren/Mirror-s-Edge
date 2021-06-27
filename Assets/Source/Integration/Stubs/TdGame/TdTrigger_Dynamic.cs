namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTrigger_Dynamic : TdTrigger/*
		placeable
		hidecategories(Navigation)*/{
	public TdTrigger_Dynamic()
	{
		var Default__TdTrigger_Dynamic_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTrigger_Dynamic.Sprite' */;
		var Default__TdTrigger_Dynamic_ArcObject = new TdDrawArcComponent
		{
		}/* Reference: TdDrawArcComponent'Default__TdTrigger_Dynamic.ArcObject' */;
		var Default__TdTrigger_Dynamic_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder' */;
		var Default__TdTrigger_Dynamic_TriggerDir = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdTrigger_Dynamic.TriggerDir' */;
		// Object Offset:0x0067B32C
		EditorSprite = Default__TdTrigger_Dynamic_Sprite/*Ref SpriteComponent'Default__TdTrigger_Dynamic.Sprite'*/;
		ArcComponent = Default__TdTrigger_Dynamic_ArcObject/*Ref TdDrawArcComponent'Default__TdTrigger_Dynamic.ArcObject'*/;
		CylinderComponent = Default__TdTrigger_Dynamic_CollisionCylinder/*Ref CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTrigger_Dynamic_Sprite/*Ref SpriteComponent'Default__TdTrigger_Dynamic.Sprite'*/,
			Default__TdTrigger_Dynamic_CollisionCylinder/*Ref CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder'*/,
			Default__TdTrigger_Dynamic_TriggerDir/*Ref ArrowComponent'Default__TdTrigger_Dynamic.TriggerDir'*/,
			Default__TdTrigger_Dynamic_ArcObject/*Ref TdDrawArcComponent'Default__TdTrigger_Dynamic.ArcObject'*/,
		};
		CollisionComponent = Default__TdTrigger_Dynamic_CollisionCylinder/*Ref CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder'*/;
	}
}
}