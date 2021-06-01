namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_FlashbangGrenade : TdWeapon_Grenade/*
		config(Weapon)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_FlashbangGrenade()
	{
		// Object Offset:0x0000AF12
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		OverrideWeaponFireTypeForAI = false;
		MaxAmmo = 20;
		ReloadTime = 0.20f;
		AmmoCount = 20;
		FallOffDistance = 100.0f;
		Mesh1p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_FlashbangGrenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.FirstPersonMesh'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000145D3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			bUseAsOccluder = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.ThirdPersonMesh' */;
		WeaponProjectiles = new array< Core.ClassT<Projectile> >
		{
			ClassT<TdProj_FlashbangGrenade>(),
		};
		FireInterval = new array<float>
		{
			0.20f,
		};
		Spread = new array<float>
		{
			0.30f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			default,
		};
		EquipTime = 2.0f;
		PutDownTime = 3.0f;
		WeaponRange = 1000.0f;
		Mesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_FlashbangGrenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.FirstPersonMesh'*/;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000145D3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			bUseAsOccluder = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.ThirdPersonMesh' */;
		PickupFactoryMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_FlashbangGrenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_FlashbangGrenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.FirstPersonMesh'*/,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x000145D3
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
				bUseAsOccluder = false,
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_FlashbangGrenade.ThirdPersonMesh' */,
		};
	}
}
}