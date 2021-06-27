namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLOIAddOnStaticMeshActor : TdLOIAddOnObject/* within StaticMeshActor*//*
		config(LOI)*/{
	public new StaticMeshActor Outer => base.Outer as StaticMeshActor;
	
	public override /*event */void ActivateLOI()
	{
		// stub
	}
	
	public override /*function */void InitLOI(Actor Player)
	{
		// stub
	}
	
	public override /*function */void InitLOIMtrlInstances()
	{
		// stub
	}
	
}
}