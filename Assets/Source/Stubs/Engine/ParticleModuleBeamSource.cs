namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamSource : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Source)*/ ParticleModuleBeamBase.Beam2SourceTargetMethod SourceMethod;
	public/*(Source)*/ ParticleModuleBeamBase.Beam2SourceTargetTangentMethod SourceTangentMethod;
	public/*(Source)*/ name SourceName;
	public/*(Source)*/ bool bSourceAbsolute;
	public/*(Source)*/ bool bLockSource;
	public/*(Source)*/ bool bLockSourceTangent;
	public/*(Source)*/ bool bLockSourceStength;
	public/*(Source)*/ DistributionVector.RawDistributionVector Source;
	public/*(Source)*/ DistributionVector.RawDistributionVector SourceTangent;
	public/*(Source)*/ DistributionFloat.RawDistributionFloat SourceStrength;
	
	public ParticleModuleBeamSource()
	{
		// Object Offset:0x0037B165
		Source = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamSource.DistributionSource")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamSource.DistributionSource'*/,
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
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamSource.DistributionSourceTangent")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamSource.DistributionSourceTangent'*/,
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleBeamSource.DistributionSourceStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleBeamSource.DistributionSourceStrength'*/,
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