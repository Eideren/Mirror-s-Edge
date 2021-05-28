// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Grenade : TdWeapon/*
		abstract
		config(Weapon)
		notplaceable
		hidecategories(Navigation)*/{
	public enum EGrenadeState 
	{
		EGS_cold,
		EGS_cocked,
		EGS_thrown,
		EGS_exploding,
		EGS_MAX
	};
	
	public float ThrowAnimLength;
	public float CockAnimLength;
	public bool bIsTapping;
	public bool bPendingEndFire;
	public TdWeapon_Grenade.EGrenadeState GrenadeState;
	
	public override /*simulated function */bool GetFireAnimName(ref name FireAnimName)
	{
	
		return default;
	}
	
	public override /*simulated function */void EndFire(byte FireModeNum)
	{
	
	}
	
	public override /*simulated function */Object.Vector GetPhysicalFireStartLoc(/*optional */Object.Vector AimDir = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void FinishedThrow()
	{
	
	}
	
	public virtual /*simulated function */void AttachNewGrenade()
	{
	
	}
	
	public delegate void GrenadeReEquipped_del();
	public virtual GrenadeReEquipped_del GrenadeReEquipped { get => bfield_GrenadeReEquipped ?? TdWeapon_Grenade_GrenadeReEquipped; set => bfield_GrenadeReEquipped = value; } GrenadeReEquipped_del bfield_GrenadeReEquipped;
	public virtual GrenadeReEquipped_del global_GrenadeReEquipped => TdWeapon_Grenade_GrenadeReEquipped;
	public /*simulated function */void TdWeapon_Grenade_GrenadeReEquipped()
	{
	
	}
	
	public virtual /*simulated function */void CockGrenade()
	{
	
	}
	
	public virtual /*simulated function */void StartGrenadeThrow()
	{
	
	}
	
	public virtual /*function */void ThrowGrenade()
	{
	
	}
	
	public virtual /*simulated function */void AnimNotifyGrenadeThrow()
	{
	
	}
	
	public override /*simulated function */Object.Vector GetMuzzleLoc()
	{
	
		return default;
	}
	
	public delegate void FinishedCocking_del();
	public virtual FinishedCocking_del FinishedCocking { get => bfield_FinishedCocking ?? (()=>{}); set => bfield_FinishedCocking = value; } FinishedCocking_del bfield_FinishedCocking;
	public virtual FinishedCocking_del global_FinishedCocking => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		GrenadeReEquipped = null;
	
	}
	
	protected /*simulated event */bool TdWeapon_Grenade_PreThrow_IsFiring()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_Grenade_PreThrow_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Grenade_PreThrow_FinishedCocking()// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Grenade_PreThrow_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PreThrow()/*simulated state PreThrow*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */bool TdWeapon_Grenade_Throw_IsFiring()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_Grenade_Throw_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Grenade_Throw_RefireCheckTimer()// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Grenade_Throw_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Throw()/*simulated state Throw*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void TdWeapon_Grenade_EquipNextGrenade_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Grenade_EquipNextGrenade_GrenadeReEquipped()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) EquipNextGrenade()/*simulated state EquipNextGrenade*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PreThrow": return PreThrow();
			case "Throw": return Throw();
			case "EquipNextGrenade": return EquipNextGrenade();
			default: return base.FindState(stateName);
		}
	}
	public TdWeapon_Grenade()
	{
		// Object Offset:0x006CE725
		WeaponPoseProfileName = (name)"Grenade";
		WeaponType = TdPawn.EWeaponType.EWT_Light;
		Mesh1p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.FirstPersonMesh'*/;
		Mesh3p = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.ThirdPersonMesh'*/;
		MaxAssistDistance = 15000;
		MaxAssistValuePitch = 0.60f;
		FiringStatesArray = new array<name>
		{
			(name)"PreThrow",
		};
		WeaponFireTypes = new array<Weapon.EWeaponFireType>
		{
			#warning weird ass EWeaponFireType value replaced with default
			//155,
			default
		};
		EquipTime = 0.450f;
		PutDownTime = 0.50f;
		bCanThrow = false;
		Mesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.FirstPersonMesh'*/;
		DroppedPickupMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.ThirdPersonMesh'*/;
		PickupFactoryMesh = LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.FirstPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.FirstPersonMesh'*/,
			LoadAsset<TdSkeletalMeshComponent>("Default__TdWeapon_Grenade.ThirdPersonMesh")/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Grenade.ThirdPersonMesh'*/,
		};
	}
}
}