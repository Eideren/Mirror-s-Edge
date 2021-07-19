namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataBeam2 : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum EBeam2Method 
	{
		PEB2M_Distance,
		PEB2M_Target,
		PEB2M_Branch,
		PEB2M_MAX
	};
	
	public enum EBeamTaperMethod 
	{
		PEBTM_None,
		PEBTM_Full,
		PEBTM_Partial,
		PEBTM_MAX
	};
	
	public partial struct BeamTargetData
	{
		[Category] public name TargetName;
		[Category] public float TargetPercentage;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0038493C
	//		TargetName = (name)"None";
	//		TargetPercentage = 0.0f;
	//	}
	};
	
	[Category("Beam")] public ParticleModuleTypeDataBeam2.EBeam2Method BeamMethod;
	[Category("Taper")] public ParticleModuleTypeDataBeam2.EBeamTaperMethod TaperMethod;
	[Category("Beam")] public int TextureTile;
	[Category("Beam")] public float TextureTileDistance;
	[Category("Beam")] public int Sheets;
	[Category("Beam")] public int MaxBeamCount;
	[Category("Beam")] public float Speed;
	[Category("Beam")] public int InterpolationPoints;
	[Category("Beam")] public bool bAlwaysOn;
	[Category("Rendering")] public bool RenderGeometry;
	[Category("Rendering")] public bool RenderDirectLine;
	[Category("Rendering")] public bool RenderLines;
	[Category("Rendering")] public bool RenderTessellation;
	[Category("Branching")] public name BranchParentName;
	[Category("Distance")] public DistributionFloat.RawDistributionFloat Distance;
	[Category("Taper")] public DistributionFloat.RawDistributionFloat TaperFactor;
	[Category("Taper")] public DistributionFloat.RawDistributionFloat TaperScale;
	
	public ParticleModuleTypeDataBeam2()
	{
		var Default__ParticleModuleTypeDataBeam2_DistributionDistance = new DistributionFloatConstant
		{
			// Object Offset:0x00466F0F
			Constant = 25.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataBeam2.DistributionDistance' */;
		var Default__ParticleModuleTypeDataBeam2_DistributionTaperFactor = new DistributionFloatConstant
		{
			// Object Offset:0x00466F43
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataBeam2.DistributionTaperFactor' */;
		var Default__ParticleModuleTypeDataBeam2_DistributionTaperScale = new DistributionFloatConstant
		{
			// Object Offset:0x00466F77
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataBeam2.DistributionTaperScale' */;
		// Object Offset:0x003849E8
		BeamMethod = ParticleModuleTypeDataBeam2.EBeam2Method.PEB2M_Target;
		TextureTile = 1;
		Sheets = 1;
		Speed = 10.0f;
		RenderGeometry = true;
		Distance = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataBeam2.DistributionDistance")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataBeam2.DistributionDistance'*/,
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
		TaperFactor = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataBeam2.DistributionTaperFactor")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataBeam2.DistributionTaperFactor'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		TaperScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataBeam2.DistributionTaperScale")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataBeam2.DistributionTaperScale'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}