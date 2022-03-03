namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamSource : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Source")] public ParticleModuleBeamBase.Beam2SourceTargetMethod SourceMethod;
	[Category("Source")] public ParticleModuleBeamBase.Beam2SourceTargetTangentMethod SourceTangentMethod;
	[Category("Source")] public name SourceName;
	[Category("Source")] public bool bSourceAbsolute;
	[Category("Source")] public bool bLockSource;
	[Category("Source")] public bool bLockSourceTangent;
	[Category("Source")] public bool bLockSourceStength;
	[Category("Source")] public DistributionVector.RawDistributionVector Source;
	[Category("Source")] public DistributionVector.RawDistributionVector SourceTangent;
	[Category("Source")] public DistributionFloat.RawDistributionFloat SourceStrength;
	
	public ParticleModuleBeamSource()
	{
		var Default__ParticleModuleBeamSource_DistributionSource = new DistributionVectorConstant
		{
			// Object Offset:0x00467E3B
			Constant = new Vector
			{
				X=50.0f,
				Y=50.0f,
				Z=50.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamSource.DistributionSource' */;
		var Default__ParticleModuleBeamSource_DistributionSourceTangent = new DistributionVectorConstant
		{
			// Object Offset:0x00467E7F
			Constant = new Vector
			{
				X=1.0f,
				Y=0.0f,
				Z=0.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamSource.DistributionSourceTangent' */;
		var Default__ParticleModuleBeamSource_DistributionSourceStrength = new DistributionFloatConstant
		{
			// Object Offset:0x00466B93
			Constant = 25.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleBeamSource.DistributionSourceStrength' */;
		// Object Offset:0x0037B165
		Source = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleBeamSource_DistributionSource/*Ref DistributionVectorConstant'Default__ParticleModuleBeamSource.DistributionSource'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		SourceTangent = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleBeamSource_DistributionSourceTangent/*Ref DistributionVectorConstant'Default__ParticleModuleBeamSource.DistributionSourceTangent'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				0.0f,
				1.0f,
				1.0f,
				0.0f,
				0.0f,
				1.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		SourceStrength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleBeamSource_DistributionSourceStrength/*Ref DistributionFloatConstant'Default__ParticleModuleBeamSource.DistributionSourceStrength'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				25.0f,
				25.0f,
				25.0f,
				25.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}