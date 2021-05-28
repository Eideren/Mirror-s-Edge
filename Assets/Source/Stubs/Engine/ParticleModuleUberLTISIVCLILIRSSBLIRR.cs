namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberLTISIVCLILIRSSBLIRR : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public/*(Lifetime)*/ /*noclear export */DistributionFloat.RawDistributionFloat Lifetime;
	public/*(Size)*/ /*noclear export */DistributionVector.RawDistributionVector StartSize;
	public/*(Velocity)*/ /*noclear export */DistributionVector.RawDistributionVector StartVelocity;
	public/*(Velocity)*/ /*noclear export */DistributionFloat.RawDistributionFloat StartVelocityRadial;
	public/*(Color)*/ /*noclear export */DistributionVector.RawDistributionVector ColorOverLife;
	public/*(Color)*/ /*noclear export */DistributionFloat.RawDistributionFloat AlphaOverLife;
	public/*(Location)*/ /*noclear export */DistributionVector.RawDistributionVector StartLocation;
	public/*(Rotation)*/ /*noclear export */DistributionFloat.RawDistributionFloat StartRotation;
	public/*(Size)*/ /*noclear export */DistributionVector.RawDistributionVector SizeLifeMultiplier;
	public/*(Size)*/ bool SizeMultiplyX;
	public/*(Size)*/ bool SizeMultiplyY;
	public/*(Size)*/ bool SizeMultiplyZ;
	public/*(Rotation)*/ /*noclear export */DistributionFloat.RawDistributionFloat StartRotationRate;
	
	public ParticleModuleUberLTISIVCLILIRSSBLIRR()
	{
		// Object Offset:0x003872D7
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionLifetime'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
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
		StartSize = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartSize")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartSize'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
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
		StartVelocity = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartVelocity")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartVelocity'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				10.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				10.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				10.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		StartVelocityRadial = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartVelocityRadial")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartVelocityRadial'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
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
		ColorOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionColorOverLife'*/,
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
		AlphaOverLife = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionAlphaOverLife'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				255.90f,
				255.90f,
				255.90f,
				255.90f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		StartLocation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartLocation")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartLocation'*/,
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
		StartRotation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartRotation")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartRotation'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				0.0f,
				1.0f,
				0.0f,
				1.0f,
				0.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		SizeLifeMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionLifeMultiplier")/*Ref DistributionVectorConstant'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionLifeMultiplier'*/,
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
		SizeMultiplyX = true;
		SizeMultiplyY = true;
		SizeMultiplyZ = true;
		StartRotationRate = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartRotationRate")/*Ref DistributionFloatConstant'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartRotationRate'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		RequiredModules = new array<name>
		{
			(name)"ParticleModuleLifetime",
			(name)"ParticleModuleSize",
			(name)"ParticleModuleVelocity",
			(name)"ParticleModuleColorOverLife",
			(name)"ParticleModuleLocation",
			(name)"ParticleModuleRotation",
			(name)"ParticleModuleSizeMultiplyLife",
			(name)"ParticleModuleRotationRate",
		};
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}