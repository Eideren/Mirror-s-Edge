namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLOIAddOnSkeletalMeshActor : TdLOIAddOnObject/* within SkeletalMeshActor*//*
		config(LOI)*/{
	public new SkeletalMeshActor Outer => base.Outer as SkeletalMeshActor;
	
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