namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LightVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public LightVolume()
	{
		var Default__LightVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x004660C3
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__LightVolume.BrushComponent0' */;
		// Object Offset:0x00351B08
		BrushComponent = Default__LightVolume_BrushComponent0/*Ref BrushComponent'Default__LightVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LightVolume_BrushComponent0/*Ref BrushComponent'Default__LightVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__LightVolume_BrushComponent0/*Ref BrushComponent'Default__LightVolume.BrushComponent0'*/;
		SupportedEvents = default;
	}
}
}