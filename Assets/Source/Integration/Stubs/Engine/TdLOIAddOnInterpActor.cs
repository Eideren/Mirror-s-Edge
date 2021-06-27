namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLOIAddOnInterpActor : TdLOIAddOnObject/* within InterpActor*//*
		config(LOI)*/{
	public new InterpActor Outer => base.Outer as InterpActor;
	
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