namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialImpactEffects : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public ParticleSystem LightAmmo;
	[Category] public ParticleSystem HeavyAmmo;
	[Category] public ParticleSystem HeliAmmo;
	[Category] public ParticleSystem ShotgunPellet;
	[Category] [export, editinline] public ParticleSystemComponent LightAmmoPhysX;
	[Category] [export, editinline] public ParticleSystemComponent HeavyAmmoPhysX;
	[Category] [export, editinline] public ParticleSystemComponent HeliAmmoPhysX;
	[Category] [export, editinline] public ParticleSystemComponent ShotgunPelletPhysX;
	
}
}