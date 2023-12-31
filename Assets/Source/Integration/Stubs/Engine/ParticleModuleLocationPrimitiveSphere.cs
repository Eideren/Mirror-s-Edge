namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocationPrimitiveSphere : ParticleModuleLocationPrimitiveBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object,Object)*/{
	[Category("Location")] public DistributionFloat.RawDistributionFloat StartRadius;
	
	public ParticleModuleLocationPrimitiveSphere()
	{
		var Default__ParticleModuleLocationPrimitiveSphere_DistributionStartRadius = new DistributionFloatConstant
		{
			// Object Offset:0x00466D7B
			Constant = 50.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveSphere.DistributionStartRadius' */;
		var Default__ParticleModuleLocationPrimitiveSphere_DistributionVelocityScale = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveSphere.DistributionVelocityScale' */;
		var Default__ParticleModuleLocationPrimitiveSphere_DistributionStartLocation = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleLocationPrimitiveSphere.DistributionStartLocation' */;
		// Object Offset:0x0037F154
		StartRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleLocationPrimitiveSphere_DistributionStartRadius/*Ref DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveSphere.DistributionStartRadius'*/,
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
		VelocityScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleLocationPrimitiveSphere_DistributionVelocityScale/*Ref DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveSphere.DistributionVelocityScale'*/,
		};
		StartLocation = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleLocationPrimitiveSphere_DistributionStartLocation/*Ref DistributionVectorConstant'Default__ParticleModuleLocationPrimitiveSphere.DistributionStartLocation'*/,
		};
		bSupported3DDrawMode = true;
	}
}
}