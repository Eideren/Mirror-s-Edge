namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialMelee : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ SoundCue ImpactSoundGun;
	public/*()*/ SoundCue ImpactSoundFist;
	public/*()*/ SoundCue ImpactSoundFoot;
	public/*()*/ ParticleSystem ImpactEffect;
	public/*()*/ ParticleSystem ImpactEffectHead;
	
}
}