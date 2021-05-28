namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleCollision : ParticleModuleCollisionBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Collision)*/ DistributionVector.RawDistributionVector DampingFactor;
	public/*(Collision)*/ DistributionVector.RawDistributionVector DampingFactorRotation;
	public/*(Collision)*/ DistributionFloat.RawDistributionFloat MaxCollisions;
	public/*(Collision)*/ ParticleModuleCollisionBase.EParticleCollisionComplete CollisionCompletionOption;
	public/*(Collision)*/ bool bApplyPhysics;
	public/*(Collision)*/ bool bPawnsDoNotDecrementCount;
	public/*(Collision)*/ bool bOnlyVerticalNormalsDecrementCount;
	public/*(Performance)*/ bool bDropDetail;
	public/*(Collision)*/ DistributionFloat.RawDistributionFloat ParticleMass;
	public/*(Collision)*/ float DirScalar;
	public/*(Collision)*/ float VerticalFudgeFactor;
	public/*(Collision)*/ DistributionFloat.RawDistributionFloat DelayAmount;
	
	public ParticleModuleCollision()
	{
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