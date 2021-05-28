namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleOrbit : ParticleModuleOrbitBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object,Orbit)*/{
	public enum EOrbitChainMode 
	{
		EOChainMode_Add,
		EOChainMode_Scale,
		EOChainMode_Link,
		EOChainMode_MAX
	};
	
	public partial struct /*native */OrbitOptions
	{
		public/*()*/ bool bProcessDuringSpawn;
		public/*()*/ bool bProcessDuringUpdate;
		public/*()*/ bool bUseEmitterTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003800EE
	//		bProcessDuringSpawn = true;
	//		bProcessDuringUpdate = false;
	//		bUseEmitterTime = false;
	//	}
	};
	
	public/*(Chaining)*/ ParticleModuleOrbit.EOrbitChainMode ChainMode;
	public/*(Offset)*/ DistributionVector.RawDistributionVector OffsetAmount;
	public/*(Offset)*/ ParticleModuleOrbit.OrbitOptions OffsetOptions;
	public/*(Rotation)*/ DistributionVector.RawDistributionVector RotationAmount;
	public/*(Rotation)*/ ParticleModuleOrbit.OrbitOptions RotationOptions;
	public/*(RotationRate)*/ DistributionVector.RawDistributionVector RotationRateAmount;
	public/*(RotationRate)*/ ParticleModuleOrbit.OrbitOptions RotationRateOptions;
	
	public ParticleModuleOrbit()
	{
		// Object Offset:0x0038017A
		ChainMode = ParticleModuleOrbit.EOrbitChainMode.EOChainMode_Link;
		OffsetAmount = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleOrbit.DistributionOffsetAmount")/*Ref DistributionVectorUniform'Default__ParticleModuleOrbit.DistributionOffsetAmount'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				50.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				50.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				50.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		OffsetOptions = new ParticleModuleOrbit.OrbitOptions
		{
			bProcessDuringSpawn = true,
			bProcessDuringUpdate = false,
			bUseEmitterTime = false,
		};
		RotationAmount = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleOrbit.DistributionRotationAmount")/*Ref DistributionVectorUniform'Default__ParticleModuleOrbit.DistributionRotationAmount'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				1.0f,
				0.0f,
				0.0f,
				0.0f,
				1.0f,
				1.0f,
				1.0f,
				0.0f,
				0.0f,
				0.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		RotationOptions = new ParticleModuleOrbit.OrbitOptions
		{
			bProcessDuringSpawn = true,
			bProcessDuringUpdate = false,
			bUseEmitterTime = false,
		};
		RotationRateAmount = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleOrbit.DistributionRotationRateAmount")/*Ref DistributionVectorUniform'Default__ParticleModuleOrbit.DistributionRotationRateAmount'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				1.0f,
				0.0f,
				0.0f,
				0.0f,
				1.0f,
				1.0f,
				1.0f,
				0.0f,
				0.0f,
				0.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		RotationRateOptions = new ParticleModuleOrbit.OrbitOptions
		{
			bProcessDuringSpawn = true,
			bProcessDuringUpdate = false,
			bUseEmitterTime = false,
		};
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}