namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_Taser : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ ParticleSystem ImpactMissPSCTemplate;
	public/*()*/ ParticleSystem ImpactHitPSCTemplate;
	public /*transient */bool bIsFirstFire;
	public/*(Sounds)*/ SoundCue WeaponFireSndLoop;
	public /*export editinline transient */AudioComponent LoopingSoundComponent;
	public/*(Sounds)*/ SoundCue WeaponNotBodyImpactSnd;
	public/*(Sounds)*/ SoundCue WeaponBodyImpactSnd;
	
	public override /*simulated function */void CustomFire()
	{
	
	}
	
	public override /*simulated function */void PlayFiringSound()
	{
	
	}
	
	public override /*simulated function */void PlayReverbSound()
	{
	
	}
	
	public override /*simulated function */void SpawnImpactSounds(Actor.ImpactInfo Impact)
	{
	
	}
	
	public override /*simulated function */void CauseMuzzleFlash()
	{
	
	}
	
	public override /*function */void SetFlashLocation(Object.Vector HitLocation)
	{
	
	}
	
	public virtual /*simulated function */void ProcessTaserHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
	
	}
	
	public override /*simulated function */void SpawnImpactEffects(Actor.ImpactInfo Impact)
	{
	
	}
	
	public override /*simulated function */void SpawnTracerEffect(Object.Vector HitLocation)
	{
	
	}
	
	
	protected /*simulated function */bool TdWeapon_Pistol_Taser_WeaponFiring_ShouldRefire()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponFiring()/*simulated state WeaponFiring*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void TdWeapon_Pistol_Taser_WeaponPuttingDown_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponPuttingDown()/*simulated state WeaponPuttingDown*/
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
		// Object Offset:0x006D01EE
		bIsFirstFire = true;
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		WeaponPoseProfileName = (name)"OneHanded-Taser";
		Mesh1p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/;
		Mesh3p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh'*/;
		Mesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/;
		DroppedPickupMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh'*/;
		PickupFactoryMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.FirstPersonMesh'*/,
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Pistol_Taser.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Taser.ThirdPersonMesh'*/,
		};
	}
}
}