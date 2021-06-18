namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class BlockingVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ bool bClampFluid;
	
	public BlockingVolume()
	{
		var Default__BlockingVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x00311F9B
			BlockActors = true,
			BlockRigidBody = true,
		}/* Reference: BrushComponent'Default__BlockingVolume.BrushComponent0' */;
		// Object Offset:0x002B247E
		bClampFluid = true;
		BrushComponent = Default__BlockingVolume_BrushComponent0;
		bExludeHandMoves = true;
		bExludeFootMoves = true;
		bWorldGeometry = true;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__BlockingVolume_BrushComponent0,
		};
		CollisionComponent = Default__BlockingVolume_BrushComponent0;
	}
}
}