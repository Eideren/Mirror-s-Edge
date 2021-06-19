namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GravityVolume : PhysicsVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ float GravityZ;
	
	public GravityVolume()
	{
		var Default__GravityVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__GravityVolume.BrushComponent0' */;
		// Object Offset:0x0033D81D
		GravityZ = -520.0f;
		BrushComponent = Default__GravityVolume_BrushComponent0/*Ref BrushComponent'Default__GravityVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__GravityVolume_BrushComponent0/*Ref BrushComponent'Default__GravityVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__GravityVolume_BrushComponent0/*Ref BrushComponent'Default__GravityVolume.BrushComponent0'*/;
	}
}
}