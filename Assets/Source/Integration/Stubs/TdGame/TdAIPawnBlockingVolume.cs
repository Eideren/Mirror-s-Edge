namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIPawnBlockingVolume : BlockingVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdAIPawnBlockingVolume()
	{
		var Default__TdAIPawnBlockingVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x01AB45F6
			BlockRigidBody = false,
		}/* Reference: BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0' */;
		// Object Offset:0x004F1D3B
		BrushComponent = Default__TdAIPawnBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0'*/;
		bWorldGeometry = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAIPawnBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdAIPawnBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIPawnBlockingVolume.BrushComponent0'*/;
	}
}
}