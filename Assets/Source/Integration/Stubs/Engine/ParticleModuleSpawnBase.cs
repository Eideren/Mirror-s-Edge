namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSpawnBase : ParticleModule/*
		abstract
		native
		editinlinenew
		hidecategories(Object,Object)*/{
	public/*(Spawn)*/ bool bProcessSpawnRate;
	public/*(Burst)*/ bool bProcessBurstList;
	
	public ParticleModuleSpawnBase()
	{
		// Object Offset:0x00382539
		bProcessSpawnRate = true;
		bProcessBurstList = true;
	}
}
}