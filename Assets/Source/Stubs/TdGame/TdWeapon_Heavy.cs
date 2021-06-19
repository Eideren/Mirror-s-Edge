namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Heavy : TdWeapon/*
		abstract
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */ParticleSystem GetSpecificImpactEffect(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffectPhysX(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public TdWeapon_Heavy()
	{
		var Default__TdWeapon_Heavy_FiringWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6D0C2
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 20,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Heavy.FiringWaveformObj' */;
		var Default__TdWeapon_Heavy_FirstPersonMesh = new TdSkeletalMeshComponent
		{
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Heavy.FirstPersonMesh' */;
		var Default__TdWeapon_Heavy_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Heavy.ThirdPersonMesh' */;
		// Object Offset:0x006CEBE4
		WeaponPoseProfileName = (name)"Heavy";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("WeaponEffects.P_WP_Enforcers_Muzzleflash")/*Ref ParticleSystem'WeaponEffects.P_WP_Enforcers_Muzzleflash'*/;
		FiringWaveform = Default__TdWeapon_Heavy_FiringWaveformObj/*Ref ForceFeedbackWaveform'Default__TdWeapon_Heavy.FiringWaveformObj'*/;
		MovementRecoilWhenFire = 200.0f;
		WeaponCollisionSnd = LoadAsset<SoundCue>("A_WP_Drops.2Handed.2HandedDrop")/*Ref SoundCue'A_WP_Drops.2Handed.2HandedDrop'*/;
		WeaponClickSnd = LoadAsset<SoundCue>("A_WP_Handling.2Handed.DryFire")/*Ref SoundCue'A_WP_Handling.2Handed.DryFire'*/;
		WeaponType = TdPawn.EWeaponType.EWT_Heavy;
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_Heavy;
		Mesh1p = Default__TdWeapon_Heavy_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Heavy_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.ThirdPersonMesh'*/;
		FiringStatesArray = new array<name>
		{
			(name)"WeaponFiring",
		};
		Mesh = Default__TdWeapon_Heavy_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.FirstPersonMesh'*/;
		DefaultInventorySlot = Inventory.EInventorySlot.EISlot_HeavyWeapon;
		PickupSound = LoadAsset<SoundCue>("A_WP_Handling.2Handed.2HandedHandling")/*Ref SoundCue'A_WP_Handling.2Handed.2HandedHandling'*/;
		DroppedPickupMesh = Default__TdWeapon_Heavy_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Heavy_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Heavy_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.FirstPersonMesh'*/,
			Default__TdWeapon_Heavy_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Heavy.ThirdPersonMesh'*/,
		};
	}
}
}