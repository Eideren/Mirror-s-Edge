namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicBlockingVolume : BlockingVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Display)*/{
	public DynamicBlockingVolume()
	{
		var Default__DynamicBlockingVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__DynamicBlockingVolume.BrushComponent0' */;
		// Object Offset:0x00311FEF
		BrushColor = new Color
		{
			R=255,
			G=255,
			B=100,
			A=255
		};
		BrushComponent = Default__DynamicBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__DynamicBlockingVolume.BrushComponent0'*/;
		bStatic = false;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DynamicBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__DynamicBlockingVolume.BrushComponent0'*/,
		};
		Physics = Actor.EPhysics.PHYS_Interpolating;
		CollisionComponent = Default__DynamicBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__DynamicBlockingVolume.BrushComponent0'*/;
	}
}
}