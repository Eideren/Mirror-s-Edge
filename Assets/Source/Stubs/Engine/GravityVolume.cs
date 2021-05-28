namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GravityVolume : PhysicsVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ float GravityZ;
	
	public GravityVolume()
	{
		// Object Offset:0x0033D81D
		GravityZ = -520.0f;
		BrushComponent = LoadAsset<BrushComponent>("Default__GravityVolume.BrushComponent0")/*Ref BrushComponent'Default__GravityVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__GravityVolume.BrushComponent0")/*Ref BrushComponent'Default__GravityVolume.BrushComponent0'*/,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__GravityVolume.BrushComponent0")/*Ref BrushComponent'Default__GravityVolume.BrushComponent0'*/;
	}
}
}