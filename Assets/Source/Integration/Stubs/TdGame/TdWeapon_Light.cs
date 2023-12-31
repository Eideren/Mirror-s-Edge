namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Light : TdWeapon/*
		abstract
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated function */void ProcessInstantHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
		// stub
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffect(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
		// stub
		return default;
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffectPhysX(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
		// stub
		return default;
	}
	
	public TdWeapon_Light()
	{
		var Default__TdWeapon_Light_FirstPersonMesh = new TdSkeletalMeshComponent
		{
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh' */;
		var Default__TdWeapon_Light_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh' */;
		// Object Offset:0x006CF0A3
		WeaponPoseProfileName = (name)"Light";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("WeaponEffects.P_WP_Enforcers_Muzzleflash")/*Ref ParticleSystem'WeaponEffects.P_WP_Enforcers_Muzzleflash'*/;
		PassThroughLimit = 2;
		MovementRecoilWhenFire = 100.0f;
		WeaponCollisionSnd = LoadAsset<SoundCue>("A_WP_Drops.1Handed.1HandedDrop")/*Ref SoundCue'A_WP_Drops.1Handed.1HandedDrop'*/;
		WeaponClickSnd = LoadAsset<SoundCue>("A_WP_Handling.1Handed.DryFire")/*Ref SoundCue'A_WP_Handling.1Handed.DryFire'*/;
		WeaponType = TdPawn.EWeaponType.EWT_Light;
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_Light;
		Mesh1p = Default__TdWeapon_Light_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Light_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh'*/;
		FiringStatesArray = new array<name>
		{
			(name)"WeaponFiring",
		};
		Mesh = Default__TdWeapon_Light_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/;
		DefaultInventorySlot = Inventory.EInventorySlot.EISlot_LightWeapon;
		PickupSound = LoadAsset<SoundCue>("A_WP_Handling.1Handed.1HandedHandling")/*Ref SoundCue'A_WP_Handling.1Handed.1HandedHandling'*/;
		DroppedPickupMesh = Default__TdWeapon_Light_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Light_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Light_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/,
			Default__TdWeapon_Light_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh'*/,
		};
	}
}
}