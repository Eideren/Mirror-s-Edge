namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialMelee : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public SoundCue ImpactSoundGun;
	[Category] public SoundCue ImpactSoundFist;
	[Category] public SoundCue ImpactSoundFoot;
	[Category] public ParticleSystem ImpactEffect;
	[Category] public ParticleSystem ImpactEffectHead;
	
}
}