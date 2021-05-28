namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicPhysicsVolume : PhysicsVolume/*
		placeable
		hidecategories(Navigation,Object,Display)*/{
	public DynamicPhysicsVolume()
	{
		// Object Offset:0x00312355
		BrushColor = new Color
		{
			R=100,
			G=255,
			B=255,
			A=255
		};
		bColored = true;
		BrushComponent = LoadAsset<BrushComponent>("Default__DynamicPhysicsVolume.BrushComponent0")/*Ref BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0'*/;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__DynamicPhysicsVolume.BrushComponent0")/*Ref BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0'*/,
		};
		Physics = Actor.EPhysics.PHYS_Interpolating;
		CollisionComponent = LoadAsset<BrushComponent>("Default__DynamicPhysicsVolume.BrushComponent0")/*Ref BrushComponent'Default__DynamicPhysicsVolume.BrushComponent0'*/;
	}
}
}