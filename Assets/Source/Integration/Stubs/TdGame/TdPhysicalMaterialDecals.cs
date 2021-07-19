namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialDecals : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] [export, editinline] public array</*export editinline */DecalComponent> Heavy_Weapon_Impact;
	[Category] [export, editinline] public array</*export editinline */DecalComponent> Heavy_Weapon_Ricochet;
	[Category] [export, editinline] public array</*export editinline */DecalComponent> Light_Weapon_Impact;
	[Category] [export, editinline] public array</*export editinline */DecalComponent> Light_Weapon_Ricochet;
	[Category] [export, editinline] public array</*export editinline */DecalComponent> ShotGun_Impact;
	[Category] [export, editinline] public array</*export editinline */DecalComponent> ShotGun_Ricochet;
	[Category] public float CriticalAngle;
	
	public TdPhysicalMaterialDecals()
	{
		// Object Offset:0x0060ADCF
		CriticalAngle = 45.0f;
	}
}
}