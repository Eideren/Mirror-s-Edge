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
		public/*()*/ name TargetName;
		public/*()*/ float TargetPercentage;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0038493C
	//		TargetName = (name)"None";
	//		TargetPercentage = 0.0f;
	//	}
	};
	
	public/*(Beam)*/ ParticleModuleTypeDataBeam2.EBeam2Method BeamMethod;
	public/*(Taper)*/ ParticleModuleTypeDataBeam2.EBeamTaperMethod TaperMethod;
	public/*(Beam)*/ int TextureTile;
	public/*(Beam)*/ float TextureTileDistance;
	public/*(Beam)*/ int Sheets;
	public/*(Beam)*/ int MaxBeamCount;
	public/*(Beam)*/ float Speed;
	public/*(Beam)*/ int InterpolationPoints;
	public/*(Beam)*/ bool bAlwaysOn;
	public/*(Rendering)*/ bool RenderGeometry;
	public/*(Rendering)*/ bool RenderDirectLine;
	public/*(Rendering)*/ bool RenderLines;
	public/*(Rendering)*/ bool RenderTessellation;
	public/*(Branching)*/ name BranchParentName;
	public/*(Distance)*/ DistributionFloat.RawDistributionFloat Distance;
	public/*(Taper)*/ DistributionFloat.RawDistributionFloat TaperFactor;
	public/*(Taper)*/ DistributionFloat.RawDistributionFloat TaperScale;
	
	public ParticleModuleTypeDataBeam2()
	{
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