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
		[Category] public bool bProcessDuringSpawn;
		[Category] public bool bProcessDuringUpdate;
		[Category] public bool bUseEmitterTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003800EE
	//		bProcessDuringSpawn = true;
	//		bProcessDuringUpdate = false;
	//		bUseEmitterTime = false;
	//	}
	};
	
	[Category("Chaining")] public ParticleModuleOrbit.EOrbitChainMode ChainMode;
	[Category("Offset")] public DistributionVector.RawDistributionVector OffsetAmount;
	[Category("Offset")] public ParticleModuleOrbit.OrbitOptions OffsetOptions;
	[Category("Rotation")] public DistributionVector.RawDistributionVector RotationAmount;
	[Category("Rotation")] public ParticleModuleOrbit.OrbitOptions RotationOptions;
	[Category("RotationRate")] public DistributionVector.RawDistributionVector RotationRateAmount;
	[Category("RotationRate")] public ParticleModuleOrbit.OrbitOptions RotationRateOptions;
	
	public ParticleModuleOrbit()
	{
		var Default__ParticleModuleOrbit_DistributionOffsetAmount = new DistributionVectorUniform
		{
			// Object Offset:0x00468483
			Max = new Vector
			{
				X=0.0f,
				Y=50.0f,
				Z=0.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleOrbit.DistributionOffsetAmount' */;
		var Default__ParticleModuleOrbit_DistributionRotationAmount = new DistributionVectorUniform
		{
			// Object Offset:0x004684C7
			Max = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleOrbit.DistributionRotationAmount' */;
		var Default__ParticleModuleOrbit_DistributionRotationRateAmount = new DistributionVectorUniform
		{
			// Object Offset:0x0046850B
			Max = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleOrbit.DistributionRotationRateAmount' */;
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