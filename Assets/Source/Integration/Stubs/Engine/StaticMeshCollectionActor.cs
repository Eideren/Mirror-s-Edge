namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticMeshCollectionActor : StaticMeshActorBase/*
		native
		config(Engine)
		notplaceable
		hidecategories(Navigation)*/{
	[Const, export, editinline] public array</*export editinline */StaticMeshComponent> StaticMeshComponents;
	[config] public int MaxStaticMeshComponents;
	
	public StaticMeshCollectionActor()
	{
		// Object Offset:0x003EE381
		MaxStaticMeshComponents = 1000;
	}
}
}