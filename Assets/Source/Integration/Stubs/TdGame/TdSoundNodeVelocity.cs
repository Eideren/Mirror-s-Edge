namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeVelocity : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public enum SpeedType 
	{
		SPEEDTYPE_Source,
		SPEEDTYPE_Listener,
		SPEEDTYPE_Relative,
		SPEEDTYPE_Custom,
		SPEEDTYPE_MAX
	};
	
	[Category] public bool bModulateVolume;
	[Category] public bool bModulatePitch;
	[Category] public float MinSpeed;
	[Category] public float MaxSpeed;
	[Category] public float VolumeAtMinSpeed;
	[Category] public float VolumeAtMaxSpeed;
	[Category] public float PitchAtMinSpeed;
	[Category] public float PitchAtMaxSpeed;
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod InterpolationMethod;
	[Category] public TdSoundNodeVelocity.SpeedType TypeOfSpeed;
	[Category] public float FadeInTimeFilter;
	[Category] public float FadeOutTimeFilter;
	
	public TdSoundNodeVelocity()
	{
		// Object Offset:0x0065BC36
		bModulateVolume = true;
		bModulatePitch = true;
		VolumeAtMaxSpeed = 1.0f;
		PitchAtMinSpeed = 1.0f;
		PitchAtMaxSpeed = 1.20f;
		InterpolationMethod = TdSoundNodeADSR.SoundInterpolationMethod.INTERPOLATION_Square;
		TypeOfSpeed = TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Relative;
	}
}
}