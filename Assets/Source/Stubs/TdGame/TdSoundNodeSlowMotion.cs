namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeSlowMotion : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ TdSoundNodeADSR.SoundInterpolationMethod PitchInterpolationMethod;
	public/*()*/ TdSoundNodeADSR.SoundInterpolationMethod VolumeInterpolationMethod;
	public/*()*/ bool bModulatePitch;
	public/*()*/ bool bModulateVolume;
	
	public TdSoundNodeSlowMotion()
	{
		// Object Offset:0x0065B943
		bModulatePitch = true;
	}
}
}