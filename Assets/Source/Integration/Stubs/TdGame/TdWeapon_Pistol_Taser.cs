namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_Taser : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	[Category] public ParticleSystem ImpactMissPSCTemplate;
	[Category] public ParticleSystem ImpactHitPSCTemplate;
	[transient] public bool bIsFirstFire;
	[Category("Sounds")] public SoundCue WeaponFireSndLoop;
	[export, editinline, transient] public AudioComponent LoopingSoundComponent;
	[Category("Sounds")] public SoundCue WeaponNotBodyImpactSnd;
	[Category("Sounds")] public SoundCue WeaponBodyImpactSnd;
	
	public override /*simulated function */void CustomFire()
	{
		// stub
	}
	
	public override /*simulated function */void PlayFiringSound()
	{
		// stub
	}
	
	public override /*simulated function */void PlayReverbSound()
	{
		// stub
	}
	
	public override /*simulated function */void SpawnImpactSounds(Actor.ImpactInfo Impact)
	{
		// stub
	}
	
	public override /*simulated function */void CauseMuzzleFlash()
	{
		// stub
	}
	
	public override /*function */void SetFlashLocation(Object.Vector HitLocation)
	{
		// stub
	}
	
	public virtual /*simulated function */void ProcessTaserHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
		// stub
	}
	
	public override /*simulated function */void SpawnImpactEffects(Actor.ImpactInfo Impact)
	{
		// stub
	}
	
	public override /*simulated function */void SpawnTracerEffect(Object.Vector HitLocation)
	{
		// stub
	}
	
	
	protected /*simulated function */bool TdWeapon_Pistol_Taser_WeaponFiring_ShouldRefire()// state function
	{
		// stub
		return default;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponFiring()/*simulated state WeaponFiring*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void TdWeapon_Pistol_Taser_WeaponPuttingDown_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponPuttingDown()/*simulated state WeaponPuttingDown*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "WeaponFiring": return WeaponFiring();
			case "WeaponPuttingDown": return WeaponPuttingDown();
			default: return base.FindState(stateName);
		}
	}
	public TdWeapon_Pistol_Taser()
	{
		var Default__TdWeapon_Pistol_Taser_FirstPersonMesh = new TdSkeletalMeshComponent
		{
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh' */;
		var Default__TdWeapon_Pistol_Taser_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh' */;
		// Object Offset:0x006D01EE
		bIsFirstFire = true;
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		WeaponPoseProfileName = (name)"OneHanded-Taser";
		Mesh1p = Default__TdWeapon_Pistol_Taser_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Pistol_Taser_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh'*/;
		Mesh = Default__TdWeapon_Pistol_Taser_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/;
		DroppedPickupMesh = Default__TdWeapon_Pistol_Taser_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Pistol_Taser_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Pistol_Taser_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/,
			Default__TdWeapon_Pistol_Taser_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh'*/,
		};
	}
}
}