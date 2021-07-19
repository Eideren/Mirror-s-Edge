namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeRelease : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod ReleaseInterpolationMethod;
	[Category] public DistributionFloat.RawDistributionFloat Release;
	[Category] public float ReleaseToDistanceFactor;
	[Category] public bool bReleaseToDistance;
	[Category] public bool bModulatePitch;
	[Category] public bool bModulateVolume;
	
	public TdSoundNodeRelease()
	{
		var Default__TdSoundNodeRelease_DistributionRelease = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeRelease.DistributionRelease' */;
		// Object Offset:0x0065B6B4
		Release = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeRelease.DistributionRelease")/*Ref DistributionFloatUniform'Default__TdSoundNodeRelease.DistributionRelease'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
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
		ReleaseToDistanceFactor = 100.0f;
		bModulateVolume = true;
	}
}
}