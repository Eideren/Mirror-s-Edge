namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIKeepMovingVolume : PhysicsVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdAIKeepMovingVolume()
	{
		var Default__TdAIKeepMovingVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0' */;
		// Object Offset:0x004EA6C8
		BrushComponent = Default__TdAIKeepMovingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAIKeepMovingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdAIKeepMovingVolume_BrushComponent0/*Ref BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0'*/;
	}
}
}