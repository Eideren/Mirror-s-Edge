namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PathBlockingVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public PathBlockingVolume()
	{
		var Default__PathBlockingVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x00466117
			BlockActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: BrushComponent'Default__PathBlockingVolume.BrushComponent0' */;
		// Object Offset:0x0038C014
		BrushComponent = Default__PathBlockingVolume_BrushComponent0;
		bWorldGeometry = true;
		bCollideActors = false;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PathBlockingVolume_BrushComponent0,
		};
		CollisionComponent = Default__PathBlockingVolume_BrushComponent0;
	}
}
}