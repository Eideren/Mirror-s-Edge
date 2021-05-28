namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticLightCollectionActor : Light/*
		native
		config(Engine)
		notplaceable
		hidecategories(Navigation)*/{
	public /*const export editinline */array</*export editinline */LightComponent> LightComponents;
	public /*config */int MaxLightComponents;
	
	public StaticLightCollectionActor()
	{
		// Object Offset:0x003ED836
		MaxLightComponents = 1000;
		Components = default;
	}
}
}