namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_DE05 : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_Pistol_DE05()
	{
		// Object Offset:0x0000CB08
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		MaxAmmo = 12;
		ReloadTime = 1.233330f;
		AmmoCount = 12;
		InstantHitDamageMP = new array<float>
		{
			90.0f,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014BAB
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014C03
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/,
			},
			bUseAsOccluder = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.ThirdPersonMesh' */;
		FireInterval = new array<float>
		{
			0.230f,
		};
		InstantHitDamage = new array<float>
		{
			90.0f,
		};
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014BAB
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.FirstPersonMesh' */;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014C03
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/,
			},
			bUseAsOccluder = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014BAB
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00014BAB
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.FirstPersonMesh' */,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00014C03
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/,
				},
				bUseAsOccluder = false,
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_DE05.ThirdPersonMesh' */,
		};
	}
}
}