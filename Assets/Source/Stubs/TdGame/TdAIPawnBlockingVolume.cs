namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIPawnBlockingVolume : BlockingVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdAIPawnBlockingVolume()
	{
		// Object Offset:0x004F1D3B
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x01AB45F6
			BlockRigidBody = false,
		}/* Reference: BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0' */;
		bWorldGeometry = false;
		Components = new array</*export editinline */ActorComponent>
		{
			new BrushComponent
			{
				// Object Offset:0x01AB45F6
				BlockRigidBody = false,
			}/* Reference: BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x01AB45F6
			BlockRigidBody = false,
		}/* Reference: BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0' */;
	}
}
}