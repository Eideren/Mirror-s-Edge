namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataBeam : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public enum EBeamMethod 
	{
		PEBM_Distance,
		PEBM_EndPoints,
		PEBM_EndPoints_Interpolated,
		PEBM_UserSet_EndPoints,
		PEBM_UserSet_EndPoints_Interpolated,
		PEBM_MAX
	};
	
	public enum EBeamEndPointMethod 
	{
		PEBEPM_Calculated,
		PEBEPM_Distribution,
		PEBEPM_Distribution_Constant,
		PEBEPM_MAX
	};
	
	public/*(Beam)*/ ParticleModuleTypeDataBeam.EBeamMethod BeamMethod;
	public/*(Beam)*/ ParticleModuleTypeDataBeam.EBeamEndPointMethod EndPointMethod;
	public/*(Beam)*/ DistributionFloat.RawDistributionFloat Distance;
	public/*(Beam)*/ DistributionVector.RawDistributionVector EndPoint;
	public/*(Beam)*/ int TessellationFactor;
	public/*(Beam)*/ DistributionFloat.RawDistributionFloat EmitterStrength;
	public/*(Beam)*/ DistributionFloat.RawDistributionFloat TargetStrength;
	public/*(Beam)*/ DistributionVector.RawDistributionVector EndPointDirection;
	public/*(Beam)*/ int TextureTile;
	public/*(Beam)*/ bool RenderGeometry;
	public/*(Beam)*/ bool RenderDirectLine;
	public/*(Beam)*/ bool RenderLines;
	public/*(Beam)*/ bool RenderTessellation;
	
	public ParticleModuleTypeDataBeam()
	{
		var Default__ParticleModuleTypeDataBeam_DistributionDistance = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataBeam.DistributionDistance' */;
		var Default__ParticleModuleTypeDataBeam_DistributionEndPoint = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleTypeDataBeam.DistributionEndPoint' */;
		var Default__ParticleModuleTypeDataBeam_DistributionEmitterStrength = new DistributionFloatConstant
		{
			// Object Offset:0x00466FC3
			Constant = 1000.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataBeam.DistributionEmitterStrength' */;
		var Default__ParticleModuleTypeDataBeam_DistributionTargetStrength = new DistributionFloatConstant
		{
			// Object Offset:0x00466FF7
			Constant = 1000.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTypeDataBeam.DistributionTargetStrength' */;
		var Default__ParticleModuleTypeDataBeam_DistributionEndPointDirection = new DistributionVectorConstant
		{
			// Object Offset:0x00468167
			Constant = new Vector
			{
				X=1.0f,
				Y=0.0f,
				Z=0.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleTypeDataBeam.DistributionEndPointDirection' */;
		// Object Offset:0x00383F1D
		Distance = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataBeam.DistributionDistance")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataBeam.DistributionDistance'*/,
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
		EndPoint = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleTypeDataBeam.DistributionEndPoint")/*Ref DistributionVectorConstant'Default__ParticleModuleTypeDataBeam.DistributionEndPoint'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
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
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		TessellationFactor = 1;
		EmitterStrength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataBeam.DistributionEmitterStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataBeam.DistributionEmitterStrength'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1000.0f,
				1000.0f,
				1000.0f,
				1000.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		TargetStrength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTypeDataBeam.DistributionTargetStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleTypeDataBeam.DistributionTargetStrength'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1000.0f,
				1000.0f,
				1000.0f,
				1000.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		EndPointDirection = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleTypeDataBeam.DistributionEndPointDirection")/*Ref DistributionVectorConstant'Default__ParticleModuleTypeDataBeam.DistributionEndPointDirection'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				0.0f,
				1.0f,
				1.0f,
				0.0f,
				0.0f,
				1.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		RenderGeometry = true;
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}