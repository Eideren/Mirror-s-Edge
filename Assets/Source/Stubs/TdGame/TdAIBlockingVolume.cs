namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIBlockingVolume : BlockingVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdAIBlockingVolume()
	{
		var Default__TdAIBlockingVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x01AB456A
			BlockActors = false,
			BlockZeroExtent = true,
			BlockRigidBody = false,
		}/* Reference: BrushComponent'Default__TdAIBlockingVolume.BrushComponent0' */;
		// Object Offset:0x004E7DBC
		BrushComponent = Default__TdAIBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIBlockingVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAIBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIBlockingVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdAIBlockingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIBlockingVolume.BrushComponent0'*/;
	}
}
}