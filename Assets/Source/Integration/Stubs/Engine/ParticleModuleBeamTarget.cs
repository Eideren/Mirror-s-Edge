namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamTarget : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Target")] public ParticleModuleBeamBase.Beam2SourceTargetMethod TargetMethod;
	[Category("Target")] public ParticleModuleBeamBase.Beam2SourceTargetTangentMethod TargetTangentMethod;
	[Category("Target")] public name TargetName;
	[Category("Target")] public DistributionVector.RawDistributionVector Target;
	[Category("Target")] public bool bTargetAbsolute;
	[Category("Target")] public bool bLockTarget;
	[Category("Target")] public bool bLockTargetTangent;
	[Category("Target")] public bool bLockTargetStength;
	[Category("Target")] public DistributionVector.RawDistributionVector TargetTangent;
	[Category("Target")] public DistributionFloat.RawDistributionFloat TargetStrength;
	[Category("Target")] public float LockRadius;
	
	public ParticleModuleBeamTarget()
	{
		var Default__ParticleModuleBeamTarget_DistributionTarget = new DistributionVectorConstant
		{
			// Object Offset:0x00467EC3
			Constant = new Vector
			{
				X=50.0f,
				Y=50.0f,
				Z=50.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamTarget.DistributionTarget' */;
		var Default__ParticleModuleBeamTarget_DistributionTargetTangent = new DistributionVectorConstant
		{
			// Object Offset:0x00467F07
			Constant = new Vector
			{
				X=1.0f,
				Y=0.0f,
				Z=0.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamTarget.DistributionTargetTangent' */;
		var Default__ParticleModuleBeamTarget_DistributionTargetStrength = new DistributionFloatConstant
		{
			// Object Offset:0x00466BC7
			Constant = 25.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleBeamTarget.DistributionTargetStrength' */;
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