namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialImpactEffects : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ ParticleSystem LightAmmo;
	public/*()*/ ParticleSystem HeavyAmmo;
	public/*()*/ ParticleSystem HeliAmmo;
	public/*()*/ ParticleSystem ShotgunPellet;
	public/*()*/ /*export editinline */ParticleSystemComponent LightAmmoPhysX;
	public/*()*/ /*export editinline */ParticleSystemComponent HeavyAmmoPhysX;
	public/*()*/ /*export editinline */ParticleSystemComponent HeliAmmoPhysX;
	public/*()*/ /*export editinline */ParticleSystemComponent ShotgunPelletPhysX;
	
}
}