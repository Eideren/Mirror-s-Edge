namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleCollision : ParticleModuleCollisionBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Collision")] public DistributionVector.RawDistributionVector DampingFactor;
	[Category("Collision")] public DistributionVector.RawDistributionVector DampingFactorRotation;
	[Category("Collision")] public DistributionFloat.RawDistributionFloat MaxCollisions;
	[Category("Collision")] public ParticleModuleCollisionBase.EParticleCollisionComplete CollisionCompletionOption;
	[Category("Collision")] public bool bApplyPhysics;
	[Category("Collision")] public bool bPawnsDoNotDecrementCount;
	[Category("Collision")] public bool bOnlyVerticalNormalsDecrementCount;
	[Category("Performance")] public bool bDropDetail;
	[Category("Collision")] public DistributionFloat.RawDistributionFloat ParticleMass;
	[Category("Collision")] public float DirScalar;
	[Category("Collision")] public float VerticalFudgeFactor;
	[Category("Collision")] public DistributionFloat.RawDistributionFloat DelayAmount;
	
	public ParticleModuleCollision()
	{
		var Default__ParticleModuleCollision_DistributionDampingFactor = new DistributionVectorUniform
		{
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleCollision.DistributionDampingFactor' */;
		var Default__ParticleModuleCollision_DistributionDampingFactorRotation = new DistributionVectorConstant
		{
			// Object Offset:0x00467F4B
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleCollision.DistributionDampingFactorRotation' */;
		var Default__ParticleModuleCollision_DistributionMaxCollisions = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleCollision.DistributionMaxCollisions' */;
		var Default__ParticleModuleCollision_DistributionParticleMass = new DistributionFloatConstant
		{
			// Object Offset:0x00466C13
			Constant = 0.10f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleCollision.DistributionParticleMass' */;
		var Default__ParticleModuleCollision_DistributionDelayAmount = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleCollision.DistributionDelayAmount' */;
		// Object Offset:0x0037BE4E
		DampingFactor = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleCollision.DistributionDampingFactor")/*Ref DistributionVectorUniform'Default__ParticleModuleCollision.DistributionDampingFactor'*/,
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
		DampingFactorRotation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleCollision.DistributionDampingFactorRotation")/*Ref DistributionVectorConstant'Default__ParticleModuleCollision.DistributionDampingFactorRotation'*/,
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
		MaxCollisions = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleCollision.DistributionMaxCollisions")/*Ref DistributionFloatUniform'Default__ParticleModuleCollision.DistributionMaxCollisions'*/,
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
		bDropDetail = true;
		ParticleMass = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleCollision.DistributionParticleMass")/*Ref DistributionFloatConstant'Default__ParticleModuleCollision.DistributionParticleMass'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				0.10f,
				0.10f,
				0.10f,
				0.10f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		DirScalar = 3.50f;
		VerticalFudgeFactor = 0.10f;
		DelayAmount = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleCollision.DistributionDelayAmount")/*Ref DistributionFloatConstant'Default__ParticleModuleCollision.DistributionDelayAmount'*/,
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
		bSpawnModule = true;
		bUpdateModule = true;
		LODDuplicate = false;
	}
}
}