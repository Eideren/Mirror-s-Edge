namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TriggerStreamingLevel : Trigger/*
		placeable
		hidecategories(Navigation)*/{
	public partial struct LevelStreamingData
	{
		public/*()*/ bool bShouldBeLoaded;
		public/*()*/ bool bShouldBeVisible;
		public/*()*/ bool bShouldBlockOnLoad;
		public/*()*/ LevelStreaming Level;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FFD82
	//		bShouldBeLoaded = false;
	//		bShouldBeVisible = false;
	//		bShouldBlockOnLoad = false;
	//		Level = default;
	//	}
	};
	
	public/*()*/ /*editinline */array</*editinline */TriggerStreamingLevel.LevelStreamingData> Levels;
	
	public override Touch_del Touch { get => bfield_Touch ?? TriggerStreamingLevel_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TriggerStreamingLevel_Touch;
	public /*event */void TriggerStreamingLevel_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public TriggerStreamingLevel()
	{
		var Default__TriggerStreamingLevel_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TriggerStreamingLevel.CollisionCylinder' */;
		var Default__TriggerStreamingLevel_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TriggerStreamingLevel.Sprite' */;
		// Object Offset:0x004000B6
		CylinderComponent = Default__TriggerStreamingLevel_CollisionCylinder/*Ref CylinderComponent'Default__TriggerStreamingLevel.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TriggerStreamingLevel_Sprite/*Ref SpriteComponent'Default__TriggerStreamingLevel.Sprite'*/,
			Default__TriggerStreamingLevel_CollisionCylinder/*Ref CylinderComponent'Default__TriggerStreamingLevel.CollisionCylinder'*/,
		};
		CollisionComponent = Default__TriggerStreamingLevel_CollisionCylinder/*Ref CylinderComponent'Default__TriggerStreamingLevel.CollisionCylinder'*/;
	}
}
}