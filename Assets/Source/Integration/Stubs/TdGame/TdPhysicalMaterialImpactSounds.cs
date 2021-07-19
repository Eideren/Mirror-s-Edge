namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialImpactSounds : TdPhysicalMaterialBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public SoundCue LightAmmo;
	[Category] public SoundCue HeavyAmmo;
	[Category] public SoundCue ShotgunPellet;
	[Category] public SoundCue LightShell;
	[Category] public SoundCue HeavyShell;
	[Category] public SoundCue ShotgunShell;
	[Category] public SoundCue SmallGlasShatter;
	[Category] public SoundCue MediumGlasShatter;
	[Category] public SoundCue LargeGlasShatter;
	
}
}