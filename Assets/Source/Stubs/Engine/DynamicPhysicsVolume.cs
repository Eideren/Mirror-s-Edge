namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicPhysicsVolume : PhysicsVolume/*
		placeable
		hidecategories(Navigation,Object,Display)*/{
	public DynamicPhysicsVolume()
	{
		var Default__DynamicPhysicsVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0' */;
		// Object Offset:0x00312355
		BrushColor = new Color
		{
			R=100,
			G=255,
			B=255,
			A=255
		};
		bColored = true;
		BrushComponent = Default__DynamicPhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0'*/;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DynamicPhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0'*/,
		};
		Physics = Actor.EPhysics.PHYS_Interpolating;
		CollisionComponent = Default__DynamicPhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0'*/;
	}
}
}