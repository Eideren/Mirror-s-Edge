namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleMeshMaterial : ParticleModuleMaterialBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(MeshMaterials)*/ array<MaterialInterface> MeshMaterials;
	
	public ParticleModuleMeshMaterial()
	{
		// Object Offset:0x0037F5F5
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}