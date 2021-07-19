namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamModifier : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum BeamModifierType 
	{
		PEB2MT_Source,
		PEB2MT_Target,
		PEB2MT_MAX
	};
	
	public partial struct /*native */BeamModifierOptions
	{
		[Category] public bool bModify;
		[Category] public bool bScale;
		[Category] public bool bLock;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0037A127
	//		bModify = false;
	//		bScale = false;
	//		bLock = false;
	//	}
	};
	
	[Category("Modifier")] public ParticleModuleBeamModifier.BeamModifierType ModifierType;
	[Category("Position")] public ParticleModuleBeamModifier.BeamModifierOptions PositionOptions;
	[Category("Position")] public DistributionVector.RawDistributionVector Position;
	[Category("Tangent")] public ParticleModuleBeamModifier.BeamModifierOptions TangentOptions;
	[Category("Tangent")] public DistributionVector.RawDistributionVector Tangent;
	[Category("Tangent")] public bool bAbsoluteTangent;
	[Category("Strength")] public ParticleModuleBeamModifier.BeamModifierOptions StrengthOptions;
	[Category("Strength")] public DistributionFloat.RawDistributionFloat Strength;
	
	public ParticleModuleBeamModifier()
	{
		var Default__ParticleModuleBeamModifier_DistributionPosition = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamModifier.DistributionPosition' */;
		var Default__ParticleModuleBeamModifier_DistributionTangent = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamModifier.DistributionTangent' */;
		var Default__ParticleModuleBeamModifier_DistributionStrength = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleBeamModifier.DistributionStrength' */;
		// Object Offset:0x0037A1B3
		Position = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamModifier.DistributionPosition")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamModifier.DistributionPosition'*/,
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
		Tangent = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamModifier.DistributionTangent")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamModifier.DistributionTangent'*/,
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
		Strength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleBeamModifier.DistributionStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleBeamModifier.DistributionStrength'*/,
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
	}
}
}