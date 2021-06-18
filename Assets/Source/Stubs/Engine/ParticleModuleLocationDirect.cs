namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocationDirect : ParticleModuleLocationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Location)*/ DistributionVector.RawDistributionVector Location;
	public/*(Location)*/ DistributionVector.RawDistributionVector LocationOffset;
	public/*(Location)*/ DistributionVector.RawDistributionVector ScaleFactor;
	public/*(Location)*/ DistributionVector.RawDistributionVector Direction;
	
	public ParticleModuleLocationDirect()
	{
		var Default__ParticleModuleLocationDirect_DistributionScaleFactor = new DistributionVectorConstant
		{
			// Object Offset:0x00467FEF
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleLocationDirect.DistributionScaleFactor' */;
		// Object Offset:0x0037DE51
		Location = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleLocationDirect.DistributionLocation")/*Ref DistributionVectorUniform'Default__ParticleModuleLocationDirect.DistributionLocation'*/,
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
		LocationOffset = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleLocationDirect.DistributionLocationOffset")/*Ref DistributionVectorConstant'Default__ParticleModuleLocationDirect.DistributionLocationOffset'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
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
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		ScaleFactor = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleLocationDirect.DistributionScaleFactor")/*Ref DistributionVectorConstant'Default__ParticleModuleLocationDirect.DistributionScaleFactor'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		Direction = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleLocationDirect.DistributionDirection")/*Ref DistributionVectorUniform'Default__ParticleModuleLocationDirect.DistributionDirection'*/,
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
		bUpdateModule = true;
	}
}
}