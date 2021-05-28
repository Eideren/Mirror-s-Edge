namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamTarget : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Target)*/ ParticleModuleBeamBase.Beam2SourceTargetMethod TargetMethod;
	public/*(Target)*/ ParticleModuleBeamBase.Beam2SourceTargetTangentMethod TargetTangentMethod;
	public/*(Target)*/ name TargetName;
	public/*(Target)*/ DistributionVector.RawDistributionVector Target;
	public/*(Target)*/ bool bTargetAbsolute;
	public/*(Target)*/ bool bLockTarget;
	public/*(Target)*/ bool bLockTargetTangent;
	public/*(Target)*/ bool bLockTargetStength;
	public/*(Target)*/ DistributionVector.RawDistributionVector TargetTangent;
	public/*(Target)*/ DistributionFloat.RawDistributionFloat TargetStrength;
	public/*(Target)*/ float LockRadius;
	
	public ParticleModuleBeamTarget()
	{
		// Object Offset:0x0037B74C
		Target = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamTarget.DistributionTarget")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamTarget.DistributionTarget'*/,
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
		TargetTangent = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamTarget.DistributionTargetTangent")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamTarget.DistributionTargetTangent'*/,
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
		TargetStrength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleBeamTarget.DistributionTargetStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleBeamTarget.DistributionTargetStrength'*/,
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
		LockRadius = 10.0f;
	}
}
}