namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTrigger_Dynamic : TdTrigger/*
		placeable
		hidecategories(Navigation)*/{
	public TdTrigger_Dynamic()
	{
		// Object Offset:0x0067B32C
		EditorSprite = LoadAsset<SpriteComponent>("Default__TdTrigger_Dynamic.Sprite")/*Ref SpriteComponent'Default__TdTrigger_Dynamic.Sprite'*/;
		ArcComponent = LoadAsset<TdDrawArcComponent>("Default__TdTrigger_Dynamic.ArcObject")/*Ref TdDrawArcComponent'Default__TdTrigger_Dynamic.ArcObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTrigger_Dynamic.CollisionCylinder")/*Ref CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdTrigger_Dynamic.Sprite")/*Ref SpriteComponent'Default__TdTrigger_Dynamic.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__TdTrigger_Dynamic.CollisionCylinder")/*Ref CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdTrigger_Dynamic.TriggerDir")/*Ref ArrowComponent'Default__TdTrigger_Dynamic.TriggerDir'*/,
			LoadAsset<TdDrawArcComponent>("Default__TdTrigger_Dynamic.ArcObject")/*Ref TdDrawArcComponent'Default__TdTrigger_Dynamic.ArcObject'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTrigger_Dynamic.CollisionCylinder")/*Ref CylinderComponent'Default__TdTrigger_Dynamic.CollisionCylinder'*/;
	}
}
}