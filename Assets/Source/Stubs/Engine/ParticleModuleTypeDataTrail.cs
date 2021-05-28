namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataTrail : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public/*(Trail)*/ bool RenderGeometry;
	public/*(Trail)*/ bool RenderLines;
	public/*(Trail)*/ bool RenderTessellation;
	public/*(Trail)*/ bool Tapered;
	public/*(Trail)*/ bool SpawnByDistance;
	public/*(Trail)*/ int TessellationFactor;
	public/*(Trail)*/ DistributionFloat.RawDistributionFloat Tension;
	public/*(Trail)*/ Object.Vector SpawnDistance;
	
	public ParticleModuleTypeDataTrail()
	{
		// Object Offset:0x003856D4
		RenderGeometry = true;
		TessellationFactor = 1;
		Tension = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataTrail.DistributionTension")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataTrail.DistributionTension'*/,
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
		SpawnDistance = new Vector
		{
			X=5.0f,
			Y=5.0f,
			Z=5.0f
		};
	}
}
}