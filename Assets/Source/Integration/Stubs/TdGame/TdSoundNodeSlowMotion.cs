namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeSlowMotion : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod PitchInterpolationMethod;
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod VolumeInterpolationMethod;
	[Category] public bool bModulatePitch;
	[Category] public bool bModulateVolume;
	
	public TdSoundNodeSlowMotion()
	{
		// Object Offset:0x0065B943
		bModulatePitch = true;
	}
}
}