namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdParticleModuleCollision : ParticleModuleCollision/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object,Object)*/{
	public enum ECollisionParticleType 
	{
		ECPT_BulletShellLight,
		ECPT_BulletShellHeavy,
		ECPT_BulletShellShotgun,
		ECPT_GlasShatterSmall,
		ECPT_GlasShatterMedium,
		ECPT_GlasShatterLarge,
		ECPT_MAX
	};
	
	[Category("Audio")] public bool bPlaySoundOnCollision;
	[Category("Audio")] public TdParticleModuleCollision.ECollisionParticleType ParticleType;
	public PhysicalMaterial DefaultImpactMaterial;
	
	public TdParticleModuleCollision()
	{
		var Default__TdParticleModuleCollision_DistributionDampingFactor = new DistributionVectorUniform
		{
		}/* Reference: DistributionVectorUniform'Default__TdParticleModuleCollision.DistributionDampingFactor' */;
		var Default__TdParticleModuleCollision_DistributionDampingFactorRotation = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__TdParticleModuleCollision.DistributionDampingFactorRotation' */;
		var Default__TdParticleModuleCollision_DistributionMaxCollisions = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__TdParticleModuleCollision.DistributionMaxCollisions' */;
		var Default__TdParticleModuleCollision_DistributionParticleMass = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__TdParticleModuleCollision.DistributionParticleMass' */;
		var Default__TdParticleModuleCollision_DistributionDelayAmount = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__TdParticleModuleCollision.DistributionDelayAmount' */;
		// Object Offset:0x00609DDC
		DefaultImpactMaterial = LoadAsset<PhysicalMaterial>("TDPhysicalMaterials.PM_Default")/*Ref PhysicalMaterial'TDPhysicalMaterials.PM_Default'*/;
		DampingFactor = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__TdParticleModuleCollision_DistributionDampingFactor/*Ref DistributionVectorUniform'Default__TdParticleModuleCollision.DistributionDampingFactor'*/,
		};
		DampingFactorRotation = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__TdParticleModuleCollision_DistributionDampingFactorRotation/*Ref DistributionVectorConstant'Default__TdParticleModuleCollision.DistributionDampingFactorRotation'*/,
		};
		MaxCollisions = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdParticleModuleCollision_DistributionMaxCollisions/*Ref DistributionFloatUniform'Default__TdParticleModuleCollision.DistributionMaxCollisions'*/,
		};
		ParticleMass = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdParticleModuleCollision_DistributionParticleMass/*Ref DistributionFloatConstant'Default__TdParticleModuleCollision.DistributionParticleMass'*/,
		};
		DelayAmount = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdParticleModuleCollision_DistributionDelayAmount/*Ref DistributionFloatConstant'Default__TdParticleModuleCollision.DistributionDelayAmount'*/,
		};
	}
}
}