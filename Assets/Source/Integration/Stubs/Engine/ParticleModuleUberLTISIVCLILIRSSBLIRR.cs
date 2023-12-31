namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberLTISIVCLILIRSSBLIRR : ParticleModuleUberBase/*
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
	[Category("Location")] [noclear, export] public DistributionVector.RawDistributionVector StartLocation;
	[Category("Rotation")] [noclear, export] public DistributionFloat.RawDistributionFloat StartRotation;
	[Category("Size")] [noclear, export] public DistributionVector.RawDistributionVector SizeLifeMultiplier;
	[Category("Size")] public bool SizeMultiplyX;
	[Category("Size")] public bool SizeMultiplyY;
	[Category("Size")] public bool SizeMultiplyZ;
	[Category("Rotation")] [noclear, export] public DistributionFloat.RawDistributionFloat StartRotationRate;
	
	public ParticleModuleUberLTISIVCLILIRSSBLIRR()
	{
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionLifetime = new DistributionFloatUniform
		{
			// Object Offset:0x0046770F
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionLifetime' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionStartSize = new DistributionVectorUniform
		{
			// Object Offset:0x00468757
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
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartSize' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionStartVelocity = new DistributionVectorUniform
		{
			// Object Offset:0x004687C7
			Max = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=10.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartVelocity' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionStartVelocityRadial = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartVelocityRadial' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionColorOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionColorOverLife' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x004670AB
			Constant = 255.90f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionAlphaOverLife' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionStartLocation = new DistributionVectorUniform
		{
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartLocation' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionStartRotation = new DistributionFloatUniform
		{
			// Object Offset:0x0046775F
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartRotation' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionLifeMultiplier = new DistributionVectorConstant
		{
			// Object Offset:0x004681AB
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionLifeMultiplier' */;
		var Default__ParticleModuleUberLTISIVCLILIRSSBLIRR_DistributionStartRotationRate = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberLTISIVCLILIRSSBLIRR.DistributionStartRotationRate' */;
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