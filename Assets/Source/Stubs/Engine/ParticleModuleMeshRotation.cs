namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleMeshRotation : ParticleModuleRotationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Rotation)*/ DistributionVector.RawDistributionVector StartRotation;
	public/*(Rotation)*/ bool bInheritParent;
	
	public ParticleModuleMeshRotation()
	{
		// Object Offset:0x0037F78F
		StartRotation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleMeshRotation.DistributionStartRotation")/*Ref DistributionVectorUniform'Default__ParticleModuleMeshRotation.DistributionStartRotation'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				360.0f,
				0.0f,
				0.0f,
				0.0f,
				360.0f,
				360.0f,
				360.0f,
				0.0f,
				0.0f,
				0.0f,
				360.0f,
				360.0f,
				360.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpawnModule = true;
	}
}
}