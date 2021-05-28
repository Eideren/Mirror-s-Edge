namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Trigger_LOS : Trigger/*
		placeable
		hidecategories(Navigation)*/{
	public override Tick_del Tick { get => bfield_Tick ?? Trigger_LOS_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => Trigger_LOS_Tick;
	public /*simulated event */void Trigger_LOS_Tick(float DeltaTime)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public Trigger_LOS()
	{
		// Object Offset:0x003FFB87
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Trigger_LOS.CollisionCylinder")/*Ref CylinderComponent'Default__Trigger_LOS.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__Trigger_LOS.Sprite")/*Ref SpriteComponent'Default__Trigger_LOS.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__Trigger_LOS.CollisionCylinder")/*Ref CylinderComponent'Default__Trigger_LOS.CollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Trigger_LOS.CollisionCylinder")/*Ref CylinderComponent'Default__Trigger_LOS.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_LOS>(),
		};
	}
}
}