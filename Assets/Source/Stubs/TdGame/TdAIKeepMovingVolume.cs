namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIKeepMovingVolume : PhysicsVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdAIKeepMovingVolume()
	{
		// Object Offset:0x004EA6C8
		BrushComponent = LoadAsset<BrushComponent>("Default__TdAIKeepMovingVolume.BrushComponent0")/*Ref BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__TdAIKeepMovingVolume.BrushComponent0")/*Ref BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0'*/,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__TdAIKeepMovingVolume.BrushComponent0")/*Ref BrushComponent'Default__TdAIKeepMovingVolume.BrushComponent0'*/;
	}
}
}