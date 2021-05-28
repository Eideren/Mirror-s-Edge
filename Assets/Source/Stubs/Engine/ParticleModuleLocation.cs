namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocation : ParticleModuleLocationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Location)*/ DistributionVector.RawDistributionVector StartLocation;
	
	public ParticleModuleLocation()
	{
		// Object Offset:0x0037DB92
		StartLocation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleLocation.DistributionStartLocation")/*Ref DistributionVectorUniform'Default__ParticleModuleLocation.DistributionStartLocation'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpawnModule = true;
		bSupported3DDrawMode = true;
	}
}
}