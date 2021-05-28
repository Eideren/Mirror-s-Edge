namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticMeshActorBase : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public StaticMeshActorBase()
	{
		// Object Offset:0x003ED8F1
		bStatic = true;
		bWorldGeometry = true;
		bRouteBeginPlayEvenIfStatic = false;
		bGameRelevant = true;
		bMovable = false;
		bCollideActors = true;
		bBlockActors = true;
		bEdShouldSnap = true;
	}
}
}