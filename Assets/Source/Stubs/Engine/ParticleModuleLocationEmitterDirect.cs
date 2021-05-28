namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocationEmitterDirect : ParticleModuleLocationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Location)*/ /*noclear export */name EmitterName;
	
	public ParticleModuleLocationEmitterDirect()
	{
		// Object Offset:0x0037E623
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}