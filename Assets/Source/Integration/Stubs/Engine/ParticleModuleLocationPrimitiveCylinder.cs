namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocationPrimitiveCylinder : ParticleModuleLocationPrimitiveBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object,Object)*/{
	public enum CylinderHeightAxis 
	{
		PMLPC_HEIGHTAXIS_X,
		PMLPC_HEIGHTAXIS_Y,
		PMLPC_HEIGHTAXIS_Z,
		PMLPC_HEIGHTAXIS_MAX
	};
	
	[Category("Location")] public bool RadialVelocity;
	[Category("Location")] public DistributionFloat.RawDistributionFloat StartRadius;
	[Category("Location")] public DistributionFloat.RawDistributionFloat StartHeight;
	[Category("Location")] public ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis HeightAxis;
	
	public ParticleModuleLocationPrimitiveCylinder()
	{
		var Default__ParticleModuleLocationPrimitiveCylinder_DistributionStartRadius = new DistributionFloatConstant
		{
			// Object Offset:0x00466D2F
			Constant = 50.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionStartRadius' */;
		var Default__ParticleModuleLocationPrimitiveCylinder_DistributionStartHeight = new DistributionFloatConstant
		{
			// Object Offset:0x00466CFB
			Constant = 50.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionStartHeight' */;
		var Default__ParticleModuleLocationPrimitiveCylinder_DistributionVelocityScale = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionVelocityScale' */;
		var Default__ParticleModuleLocationPrimitiveCylinder_DistributionStartLocation = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionStartLocation' */;
		// Object Offset:0x0037ED6D
		RadialVelocity = true;
		StartRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleLocationPrimitiveCylinder_DistributionStartRadius/*Ref DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionStartRadius'*/,
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
		StartHeight = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleLocationPrimitiveCylinder_DistributionStartHeight/*Ref DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionStartHeight'*/,
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
		HeightAxis = ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis.PMLPC_HEIGHTAXIS_Z;
		VelocityScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleLocationPrimitiveCylinder_DistributionVelocityScale/*Ref DistributionFloatConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionVelocityScale'*/,
		};
		StartLocation = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleLocationPrimitiveCylinder_DistributionStartLocation/*Ref DistributionVectorConstant'Default__ParticleModuleLocationPrimitiveCylinder.DistributionStartLocation'*/,
		};
		bSupported3DDrawMode = true;
	}
}
}