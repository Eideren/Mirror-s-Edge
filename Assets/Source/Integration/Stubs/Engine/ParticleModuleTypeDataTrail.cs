namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataTrail : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	[Category("Trail")] public bool RenderGeometry;
	[Category("Trail")] public bool RenderLines;
	[Category("Trail")] public bool RenderTessellation;
	[Category("Trail")] public bool Tapered;
	[Category("Trail")] public bool SpawnByDistance;
	[Category("Trail")] public int TessellationFactor;
	[Category("Trail")] public DistributionFloat.RawDistributionFloat Tension;
	[Category("Trail")] public Object.Vector SpawnDistance;
	
	public ParticleModuleTypeDataTrail()
	{
		var Default__ParticleModuleTypeDataTrail_DistributionTension = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataTrail.DistributionTension' */;
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