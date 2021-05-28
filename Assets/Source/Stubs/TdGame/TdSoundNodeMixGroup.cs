namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeMixGroup : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ bool bModulateVolume;
	public/*()*/ bool bModulatePitch;
	public/*()*/ bool bModulateLowPass;
	public /*transient */bool bFirstRun;
	public/*(MixGroups)*/ array<name> MixGroups;
	public array<int> MixGroupIDs;
	
	public TdSoundNodeMixGroup()
	{
		// Object Offset:0x0065B342
		bModulateVolume = true;
		bModulatePitch = true;
		bModulateLowPass = true;
		bFirstRun = true;
		MixGroups = new array<name>
		{
			(name)"Default",
		};
	}
}
}