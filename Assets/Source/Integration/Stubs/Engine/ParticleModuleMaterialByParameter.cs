namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleMaterialByParameter : ParticleModuleMaterialBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category] public array<name> MaterialParameters;
	[Category] [editfixedsize] public array<MaterialInterface> DefaultMaterials;
	
	public ParticleModuleMaterialByParameter()
	{
		// Object Offset:0x0037F4F2
		bUpdateModule = true;
	}
}
}