namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticMeshComponentFactory : MeshComponentFactory/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public StaticMesh StaticMesh;
	
	public StaticMeshComponentFactory()
	{
		// Object Offset:0x003EE444
		CollideActors = true;
		BlockActors = true;
		BlockZeroExtent = true;
		BlockNonZeroExtent = true;
		BlockRigidBody = true;
	}
}
}