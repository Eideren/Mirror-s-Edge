namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocationPrimitiveBase : ParticleModuleLocationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Location")] public bool Positive_X;
	[Category("Location")] public bool Positive_Y;
	[Category("Location")] public bool Positive_Z;
	[Category("Location")] public bool Negative_X;
	[Category("Location")] public bool Negative_Y;
	[Category("Location")] public bool Negative_Z;
	[Category("Location")] public bool SurfaceOnly;
	[Category("Location")] public bool Velocity;
	[Category("Location")] public DistributionFloat.RawDistributionFloat VelocityScale;
	[Category("Location")] public DistributionVector.RawDistributionVector StartLocation;
	
	public ParticleModuleLocationPrimitiveBase()
	{
		var Default__ParticleModuleLocationPrimitiveBase_DistributionVelocityScale = new DistributionFloatConstant
		{
			// Object Offset:0x0037EC2D
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveBase.DistributionVelocityScale' */;
		var Default__ParticleModuleLocationPrimitiveBase_DistributionStartLocation = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleLocationPrimitiveBase.DistributionStartLocation' */;
		// Object Offset:0x0037E8A2
		Positive_X = true;
		Positive_Y = true;
		Positive_Z = true;
		Negative_X = true;
		Negative_Y = true;
		Negative_Z = true;
		VelocityScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleLocationPrimitiveBase.DistributionVelocityScale")/*Ref DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveBase.DistributionVelocityScale'*/,
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
		StartLocation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleLocationPrimitiveBase.DistributionStartLocation")/*Ref DistributionVectorConstant'Default__ParticleModuleLocationPrimitiveBase.DistributionStartLocation'*/,
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
		bSpawnModule = true;
	}
}
}