namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberLTISIVCL : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	[Category("Lifetime")] [noclear, export] public DistributionFloat.RawDistributionFloat Lifetime;
	[Category("Size")] [noclear, export] public DistributionVector.RawDistributionVector StartSize;
	[Category("Velocity")] [noclear, export] public DistributionVector.RawDistributionVector StartVelocity;
	[Category("Velocity")] [noclear, export] public DistributionFloat.RawDistributionFloat StartVelocityRadial;
	[Category("Color")] [noclear, export] public DistributionVector.RawDistributionVector ColorOverLife;
	[Category("Color")] [noclear, export] public DistributionFloat.RawDistributionFloat AlphaOverLife;
	
	public ParticleModuleUberLTISIVCL()
	{
		var Default__ParticleModuleUberLTISIVCL_DistributionLifetime = new DistributionFloatUniform
		{
			// Object Offset:0x0046763F
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberLTISIVCL.DistributionLifetime' */;
		var Default__ParticleModuleUberLTISIVCL_DistributionStartSize = new DistributionVectorUniform
		{
			// Object Offset:0x004685BF
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
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCL.DistributionStartSize' */;
		var Default__ParticleModuleUberLTISIVCL_DistributionStartVelocity = new DistributionVectorUniform
		{
			// Object Offset:0x0046862F
			Max = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=10.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCL.DistributionStartVelocity' */;
		var Default__ParticleModuleUberLTISIVCL_DistributionStartVelocityRadial = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberLTISIVCL.DistributionStartVelocityRadial' */;
		var Default__ParticleModuleUberLTISIVCL_DistributionColorOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleUberLTISIVCL.DistributionColorOverLife' */;
		var Default__ParticleModuleUberLTISIVCL_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x00467043
			Constant = 255.90f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberLTISIVCL.DistributionAlphaOverLife' */;
		// Object Offset:0x00385DE5
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCL.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCL.DistributionLifetime'*/,
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
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCL.DistributionStartSize")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCL.DistributionStartSize'*/,
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
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberLTISIVCL.DistributionStartVelocity")/*Ref DistributionVectorUniform'Default__ParticleModuleUberLTISIVCL.DistributionStartVelocity'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberLTISIVCL.DistributionStartVelocityRadial")/*Ref DistributionFloatUniform'Default__ParticleModuleUberLTISIVCL.DistributionStartVelocityRadial'*/,
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
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleUberLTISIVCL.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleUberLTISIVCL.DistributionColorOverLife'*/,
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberLTISIVCL.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleUberLTISIVCL.DistributionAlphaOverLife'*/,
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
		RequiredModules = new array<name>
		{
			(name)"ParticleModuleLifetime",
			(name)"ParticleModuleSize",
			(name)"ParticleModuleVelocity",
			(name)"ParticleModuleColorOverLife",
		};
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}