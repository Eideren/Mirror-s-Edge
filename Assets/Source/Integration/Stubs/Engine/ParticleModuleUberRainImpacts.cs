namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberRainImpacts : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	[Category("Lifetime")] public DistributionFloat.RawDistributionFloat Lifetime;
	[Category("Size")] public DistributionVector.RawDistributionVector StartSize;
	[Category("Rotation")] public DistributionVector.RawDistributionVector StartRotation;
	[Category("Rotation")] public bool bInheritParent;
	[Category("Size")] public bool MultiplyX;
	[Category("Size")] public bool MultiplyY;
	[Category("Size")] public bool MultiplyZ;
	[Category("Location")] public bool bIsUsingCylinder;
	[Category("Location")] public bool bPositive_X;
	[Category("Location")] public bool bPositive_Y;
	[Category("Location")] public bool bPositive_Z;
	[Category("Location")] public bool bNegative_X;
	[Category("Location")] public bool bNegative_Y;
	[Category("Location")] public bool bNegative_Z;
	[Category("Location")] public bool bSurfaceOnly;
	[Category("Location")] public bool bVelocity;
	[Category("Location")] public bool bRadialVelocity;
	[Category("Size")] public DistributionVector.RawDistributionVector LifeMultiplier;
	[Category("Location")] public DistributionFloat.RawDistributionFloat PC_VelocityScale;
	[Category("Location")] public DistributionVector.RawDistributionVector PC_StartLocation;
	[Category("Location")] public DistributionFloat.RawDistributionFloat PC_StartRadius;
	[Category("Location")] public DistributionFloat.RawDistributionFloat PC_StartHeight;
	[Category("Location")] public ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis PC_HeightAxis;
	[Category("Color")] public DistributionVector.RawDistributionVector ColorOverLife;
	[Category("Color")] public DistributionFloat.RawDistributionFloat AlphaOverLife;
	
	public ParticleModuleUberRainImpacts()
	{
		var Default__ParticleModuleUberRainImpacts_DistributionLifetime = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberRainImpacts.DistributionLifetime' */;
		var Default__ParticleModuleUberRainImpacts_DistributionStartSize = new DistributionVectorUniform
		{
			// Object Offset:0x0046884F
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
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberRainImpacts.DistributionStartSize' */;
		var Default__ParticleModuleUberRainImpacts_DistributionStartRotation = new DistributionVectorUniform
		{
			// Object Offset:0x0046880B
			Max = new Vector
			{
				X=360.0f,
				Y=360.0f,
				Z=360.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberRainImpacts.DistributionStartRotation' */;
		var Default__ParticleModuleUberRainImpacts_DistributionLifeMultiplier = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleUberRainImpacts.DistributionLifeMultiplier' */;
		var Default__ParticleModuleUberRainImpacts_DistributionPC_VelocityScale = new DistributionFloatConstant
		{
			// Object Offset:0x00467193
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_VelocityScale' */;
		var Default__ParticleModuleUberRainImpacts_DistributionPC_StartLocation = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_StartLocation' */;
		var Default__ParticleModuleUberRainImpacts_DistributionPC_StartRadius = new DistributionFloatConstant
		{
			// Object Offset:0x0046715F
			Constant = 50.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_StartRadius' */;
		var Default__ParticleModuleUberRainImpacts_DistributionPC_StartHeight = new DistributionFloatConstant
		{
			// Object Offset:0x0046712B
			Constant = 50.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_StartHeight' */;
		var Default__ParticleModuleUberRainImpacts_DistributionColorOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleUberRainImpacts.DistributionColorOverLife' */;
		var Default__ParticleModuleUberRainImpacts_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x004670F7
			Constant = 255.90f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionAlphaOverLife' */;
		// Object Offset:0x00388C69
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberRainImpacts.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleUberRainImpacts.DistributionLifetime'*/,
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
		StartSize = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberRainImpacts.DistributionStartSize")/*Ref DistributionVectorUniform'Default__ParticleModuleUberRainImpacts.DistributionStartSize'*/,
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
		StartRotation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberRainImpacts.DistributionStartRotation")/*Ref DistributionVectorUniform'Default__ParticleModuleUberRainImpacts.DistributionStartRotation'*/,
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
		MultiplyX = true;
		MultiplyY = true;
		MultiplyZ = true;
		bIsUsingCylinder = true;
		bPositive_X = true;
		bPositive_Y = true;
		bPositive_Z = true;
		bNegative_X = true;
		bNegative_Y = true;
		bNegative_Z = true;
		bRadialVelocity = true;
		LifeMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleUberRainImpacts.DistributionLifeMultiplier")/*Ref DistributionVectorConstant'Default__ParticleModuleUberRainImpacts.DistributionLifeMultiplier'*/,
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
		PC_VelocityScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainImpacts.DistributionPC_VelocityScale")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_VelocityScale'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		PC_StartLocation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleUberRainImpacts.DistributionPC_StartLocation")/*Ref DistributionVectorConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_StartLocation'*/,
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
		PC_StartRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainImpacts.DistributionPC_StartRadius")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_StartRadius'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				50.0f,
				50.0f,
				50.0f,
				50.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		PC_StartHeight = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainImpacts.DistributionPC_StartHeight")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionPC_StartHeight'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				50.0f,
				50.0f,
				50.0f,
				50.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		PC_HeightAxis = ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis.PMLPC_HEIGHTAXIS_Z;
		ColorOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleUberRainImpacts.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleUberRainImpacts.DistributionColorOverLife'*/,
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainImpacts.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainImpacts.DistributionAlphaOverLife'*/,
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
		bSpawnModule = true;
		bUpdateModule = true;
		bSupported3DDrawMode = true;
	}
}
}