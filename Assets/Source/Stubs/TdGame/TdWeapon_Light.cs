namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Light : TdWeapon/*
		abstract
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated function */void ProcessInstantHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
	
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffect(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffectPhysX(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public TdWeapon_Light()
	{
		// Object Offset:0x006CF0A3
		WeaponPoseProfileName = (name)"Light";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("WeaponEffects.P_WP_Enforcers_Muzzleflash")/*Ref ParticleSystem'WeaponEffects.P_WP_Enforcers_Muzzleflash'*/;
		PassThroughLimit = 2;
		MovementRecoilWhenFire = 100.0f;
		WeaponCollisionSnd = LoadAsset<SoundCue>("A_WP_Drops.1Handed.1HandedDrop")/*Ref SoundCue'A_WP_Drops.1Handed.1HandedDrop'*/;
		WeaponClickSnd = LoadAsset<SoundCue>("A_WP_Handling.1Handed.DryFire")/*Ref SoundCue'A_WP_Handling.1Handed.DryFire'*/;
		WeaponType = TdPawn.EWeaponType.EWT_Light;
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_Light;
		Mesh1p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/;
		Mesh3p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh'*/;
		FiringStatesArray = new array<name>
		{
			(name)"WeaponFiring",
		};
		Mesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/;
		DefaultInventorySlot = Inventory.EInventorySlot.EISlot_LightWeapon;
		PickupSound = LoadAsset<SoundCue>("A_WP_Handling.1Handed.1HandedHandling")/*Ref SoundCue'A_WP_Handling.1Handed.1HandedHandling'*/;
		DroppedPickupMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh'*/;
		PickupFactoryMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.FirstPersonMesh'*/,
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Light.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Light.ThirdPersonMesh'*/,
		};
	}
}
}