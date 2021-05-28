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
	
	public/*(Audio)*/ bool bPlaySoundOnCollision;
	public/*(Audio)*/ TdParticleModuleCollision.ECollisionParticleType ParticleType;
	public PhysicalMaterial DefaultImpactMaterial;
	
	public TdParticleModuleCollision()
	{
		// Object Offset:0x00609DDC
		DefaultImpactMaterial = LoadAsset<PhysicalMaterial>("TDPhysicalMaterials.PM_Default")/*Ref PhysicalMaterial'TDPhysicalMaterials.PM_Default'*/;
		DampingFactor = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__TdParticleModuleCollision.DistributionDampingFactor")/*Ref DistributionVectorUniform'Default__TdParticleModuleCollision.DistributionDampingFactor'*/,
		};
		DampingFactorRotation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__TdParticleModuleCollision.DistributionDampingFactorRotation")/*Ref DistributionVectorConstant'Default__TdParticleModuleCollision.DistributionDampingFactorRotation'*/,
		};
		MaxCollisions = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdParticleModuleCollision.DistributionMaxCollisions")/*Ref DistributionFloatUniform'Default__TdParticleModuleCollision.DistributionMaxCollisions'*/,
		};
		ParticleMass = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__TdParticleModuleCollision.DistributionParticleMass")/*Ref DistributionFloatConstant'Default__TdParticleModuleCollision.DistributionParticleMass'*/,
		};
		DelayAmount = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__TdParticleModuleCollision.DistributionDelayAmount")/*Ref DistributionFloatConstant'Default__TdParticleModuleCollision.DistributionDelayAmount'*/,
		};
	}
}
}