namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicTriggerVolume : TriggerVolume/*
		placeable
		hidecategories(Navigation,Object,Display)*/{
	public DynamicTriggerVolume()
	{
		// Object Offset:0x0031356D
		BrushColor = new Color
		{
			R=100,
			G=255,
			B=255,
			A=255
		};
		BrushComponent = LoadAsset<BrushComponent>("Default__DynamicTriggerVolume.BrushComponent0")/*Ref BrushComponent'Default__DynamicTriggerVolume.BrushComponent0'*/;
		bStatic = false;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__DynamicTriggerVolume.BrushComponent0")/*Ref BrushComponent'Default__DynamicTriggerVolume.BrushComponent0'*/,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__DynamicTriggerVolume.BrushComponent0")/*Ref BrushComponent'Default__DynamicTriggerVolume.BrushComponent0'*/;
	}
}
}