namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PathBlockingVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public PathBlockingVolume()
	{
		// Object Offset:0x0038C014
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x00466117
			BlockActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: BrushComponent'Default__PathBlockingVolume.BrushComponent0' */;
		bWorldGeometry = true;
		bCollideActors = false;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new BrushComponent
			{
				// Object Offset:0x00466117
				BlockActors = true,
				BlockZeroExtent = true,
				BlockRigidBody = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: BrushComponent'Default__PathBlockingVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x00466117
			BlockActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: BrushComponent'Default__PathBlockingVolume.BrushComponent0' */;
	}
}
}