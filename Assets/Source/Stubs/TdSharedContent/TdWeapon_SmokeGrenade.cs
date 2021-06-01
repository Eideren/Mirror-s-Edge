namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_SmokeGrenade : TdWeapon_Grenade/*
		config(Weapon)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_SmokeGrenade()
	{
		// Object Offset:0x0001037E
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
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001569F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000156F7
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
			},
			bUseAsOccluder = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.ThirdPersonMesh' */;
		WeaponProjectiles = new array< Core.ClassT<Projectile> >
		{
			ClassT<TdProj_SmokeGrenade>(),
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
			ClassT<TdDmgType_Explosion>(),
		};
		EquipTime = 2.0f;
		PutDownTime = 3.0f;
		WeaponRange = 1000.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001569F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.FirstPersonMesh' */;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000156F7
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
			},
			bUseAsOccluder = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001569F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0001569F
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.FirstPersonMesh' */,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x000156F7
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				},
				bUseAsOccluder = false,
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SmokeGrenade.ThirdPersonMesh' */,
		};
	}
}
}