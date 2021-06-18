namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberLTISIVCLIL : ParticleModuleUberBase/*
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
	
	public ParticleModuleUberLTISIVCLIL()
	{
		var Default__ParticleModuleUberLTISIVCLIL_DistributionLifetime = new DistributionFloatUniform
		{
			// Object Offset:0x004676A7
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionLifetime' */;
		var Default__ParticleModuleUberLTISIVCLIL_DistributionStartSize = new DistributionVectorUniform
		{
			// Object Offset:0x0046868B
			Max = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			Min = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionStartSize' */;
		var Default__ParticleModuleUberLTISIVCLIL_DistributionStartVelocity = new DistributionVectorUniform
		{
			// Object Offset:0x004686FB
			Max = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=10.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionStartVelocity' */;
		var Default__ParticleModuleUberLTISIVCLIL_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x00467077
			Constant = 255.90f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberLTISIVCLIL.DistributionAlphaOverLife' */;
		// Object Offset:0x00386730
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCLIL.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionLifetime'*/,
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
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCLIL.DistributionStartSize")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionStartSize'*/,
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
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCLIL.DistributionStartVelocity")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionStartVelocity'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCLIL.DistributionStartVelocityRadial")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionStartVelocityRadial'*/,
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
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleUberLTISIVCLIL.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleUberLTISIVCLIL.DistributionColorOverLife'*/,
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberLTISIVCLIL.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleUberLTISIVCLIL.DistributionAlphaOverLife'*/,
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
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCLIL.DistributionStartLocation")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLIL.DistributionStartLocation'*/,
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
		RequiredModules = new array<name>
		{
			(name)"ParticleModuleLifetime",
			(name)"ParticleModuleSize",
			(name)"ParticleModuleVelocity",
			(name)"ParticleModuleColorOverLife",
			(name)"ParticleModuleLocation",
		};
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}