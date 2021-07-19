namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticLightCollectionActor : Light/*
		native
		config(Engine)
		notplaceable
		hidecategories(Navigation)*/{
	[Const, export, editinline] public array</*export editinline */LightComponent> LightComponents;
	[config] public int MaxLightComponents;
	
	public StaticLightCollectionActor()
	{
		// Object Offset:0x003ED836
		MaxLightComponents = 1000;
		Components = default;
	}
}
}