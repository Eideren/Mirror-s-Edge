namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DefaultPhysicsVolume : PhysicsVolume/*
		transient
		native
		notplaceable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public DefaultPhysicsVolume()
	{
		var Default__DefaultPhysicsVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__DefaultPhysicsVolume.BrushComponent0' */;
		// Object Offset:0x0030CAD9
		BrushComponent = Default__DefaultPhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__DefaultPhysicsVolume.BrushComponent0'*/;
		bStatic = false;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DefaultPhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__DefaultPhysicsVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__DefaultPhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__DefaultPhysicsVolume.BrushComponent0'*/;
	}
}
}