namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Weapon : Inventory/*
		abstract
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public enum EWeaponFireType 
	{
		EWFT_InstantHit,
		EWFT_Projectile,
		EWFT_Custom,
		EWFT_None,
		EWFT_MAX
	};
	
	public byte CurrentFireMode;
	public array<name> FiringStatesArray;
	public array<Weapon.EWeaponFireType> WeaponFireTypes;
	public array< Core.ClassT<Projectile> > WeaponProjectiles;
	public/*()*/ array<float> FireInterval;
	public/*()*/ array<float> Spread;
	public/*()*/ array<float> InstantHitDamage;
	public/*()*/ array<float> InstantHitMomentum;
	public array< Core.ClassT<DamageType> > InstantHitDamageTypes;
	public/*()*/ float EquipTime;
	public/*()*/ float PutDownTime;
	public/*()*/ Object.Vector FireOffset;
	public bool bWeaponPutDown;
	public bool bCanThrow;
	public bool bInstantHit;
	public bool bMeleeWeapon;
	public/*()*/ float WeaponRange;
	public/*()*/ float ClothImpulseRadius;
	public/*()*/ float ClothImpulseScale;
	public/*()*/ /*export editinline */MeshComponent Mesh;
	public/*()*/ float DefaultAnimSpeed;
	public /*databinding config */float Priority;
	public AIController AIController;
	public array<byte> ShouldFireOnRelease;
	public float AIRating;
	public float CachedMaxRange;
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public override /*function */void ItemRemovedFromInvManager()
	{
	
	}
	
	public virtual /*simulated function */bool IsActiveWeapon()
	{
	
		return default;
	}
	
	public virtual /*function */void HolderDied()
	{
	
	}
	
	public virtual /*simulated function */bool DoOverrideNextWeapon()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool DoOverridePrevWeapon()
	{
	
		return default;
	}
	
	public override /*function */void DropFrom(Object.Vector StartLocation, Object.Vector StartVelocity)
	{
	
	}
	
	public virtual /*simulated function */bool CanThrow()
	{
	
		return default;
	}
	
	public virtual /*reliable client simulated function */void ClientWeaponThrown()
	{
	
	}
	
	public delegate bool IsFiring_del();
	public virtual IsFiring_del IsFiring { get => bfield_IsFiring ?? Weapon_IsFiring; set => bfield_IsFiring = value; } IsFiring_del bfield_IsFiring;
	public virtual IsFiring_del global_IsFiring => Weapon_IsFiring;
	public /*simulated event */bool Weapon_IsFiring()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool DenyClientWeaponSet()
	{
	
		return default;
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*simulated function */void GetWeaponDebug(ref array<string> DebugInfo)
	{
	
	}
	
	public virtual /*simulated function */void DumpWeaponDebugToLog()
	{
	
	}
	
	public virtual /*simulated function */void WeaponLog(/*coerce */string msg, /*coerce */string FuncStr)
	{
	
	}
	
	public virtual /*function */void ConsumeAmmo(byte FireModeNum)
	{
	
	}
	
	public virtual /*function */int AddAmmo(int Amount)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool HasAmmo(byte FireModeNum, /*optional */int? _Amount = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool HasAnyAmmo()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool PendingFire(int FireMode)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void SetPendingFire(int FireMode)
	{
	
	}
	
	public virtual /*simulated function */void ClearPendingFire(int FireMode)
	{
	
	}
	
	public virtual /*function */Core.ClassT<Projectile> GetProjectileClass()
	{
	
		return default;
	}
	
	public virtual /*simulated function */Object.Rotator AddSpread(Object.Rotator BaseAim)
	{
	
		return default;
	}
	
	public virtual /*simulated function */float MaxRange()
	{
	
		return default;
	}
	
	public virtual /*function */float GetDamageRadius()
	{
	
		return default;
	}
	
	public override /*function */void GivenTo(Pawn thisPawn, /*optional */bool? _bDoNotActivate = default)
	{
	
	}
	
	public virtual /*function */float GetAIRating()
	{
	
		return default;
	}
	
	public virtual /*simulated function */float GetWeaponRating()
	{
	
		return default;
	}
	
	public virtual /*function */bool RecommendRangedAttack()
	{
	
		return default;
	}
	
	public virtual /*function */bool FocusOnLeader(bool bLeaderFiring)
	{
	
		return default;
	}
	
	public virtual /*function */bool RecommendLongRangedAttack()
	{
	
		return default;
	}
	
	public virtual /*function */float RangedAttackTime()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanAttack(Actor Other)
	{
	
		return default;
	}
	
	public virtual /*function */float SuggestAttackStyle()
	{
	
		return default;
	}
	
	public virtual /*function */float SuggestDefenseStyle()
	{
	
		return default;
	}
	
	public virtual /*function */bool FireOnRelease()
	{
	
		return default;
	}
	
	public virtual /*simulated function */AnimNodeSequence GetWeaponAnimNodeSeq()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void WeaponPlaySound(SoundCue Sound, /*optional */float? _NoiseLoudness = default)
	{
	
	}
	
	public virtual /*simulated function */void PlayWeaponAnimation(name Sequence, float fDesiredDuration, /*optional */bool? _bLoop = default, /*optional */SkeletalMeshComponent? _SkelMesh = default)
	{
	
	}
	
	public virtual /*simulated function */void StopWeaponAnimation()
	{
	
	}
	
	public virtual /*simulated function */void PlayFireEffects(byte FireModeNum, /*optional */Object.Vector? _HitLocation = default)
	{
	
	}
	
	public virtual /*simulated function */void StopFireEffects(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void PlayFiringSound()
	{
	
	}
	
	public virtual /*simulated function */float GetFireInterval(byte FireModeNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void TimeWeaponFiring(byte FireModeNum)
	{
	
	}
	
	public delegate void RefireCheckTimer_del();
	public virtual RefireCheckTimer_del RefireCheckTimer { get => bfield_RefireCheckTimer ?? Weapon_RefireCheckTimer; set => bfield_RefireCheckTimer = value; } RefireCheckTimer_del bfield_RefireCheckTimer;
	public virtual RefireCheckTimer_del global_RefireCheckTimer => Weapon_RefireCheckTimer;
	public /*simulated function */void Weapon_RefireCheckTimer()
	{
	
	}
	
	public virtual /*simulated function */void TimeWeaponPutDown()
	{
	
	}
	
	public virtual /*simulated function */void TimeWeaponEquipping()
	{
	
	}
	
	public delegate void Activate_del();
	public virtual Activate_del Activate { get => bfield_Activate ?? Weapon_Activate; set => bfield_Activate = value; } Activate_del bfield_Activate;
	public virtual Activate_del global_Activate => Weapon_Activate;
	public /*simulated function */void Weapon_Activate()
	{
	
	}
	
	public virtual /*simulated function */void PutDownWeapon()
	{
	
	}
	
	public override /*function */bool DenyPickupQuery(Core.ClassT<Inventory> ItemClass, Actor Pickup)
	{
	
		return default;
	}
	
	public delegate void WeaponEmpty_del();
	public virtual WeaponEmpty_del WeaponEmpty { get => bfield_WeaponEmpty ?? Weapon_WeaponEmpty; set => bfield_WeaponEmpty = value; } WeaponEmpty_del bfield_WeaponEmpty;
	public virtual WeaponEmpty_del global_WeaponEmpty => Weapon_WeaponEmpty;
	public /*simulated function */void Weapon_WeaponEmpty()
	{
	
	}
	
	public virtual /*simulated function */void IncrementFlashCount()
	{
	
	}
	
	public virtual /*simulated function */void ClearFlashCount()
	{
	
	}
	
	public virtual /*function */void SetFlashLocation(Object.Vector HitLocation)
	{
	
	}
	
	public virtual /*function */void ClearFlashLocation()
	{
	
	}
	
	public virtual /*simulated function */void AttachWeaponTo(SkeletalMeshComponent MeshCpnt, /*optional */name? _SocketName = default)
	{
	
	}
	
	public virtual /*simulated function */void DetachWeapon()
	{
	
	}
	
	public virtual /*simulated function */void GetViewAxes(ref Object.Vector XAxis, ref Object.Vector YAxis, ref Object.Vector ZAxis)
	{
	
	}
	
	public virtual /*simulated function */float AdjustFOVAngle(float FOVAngle)
	{
	
		return default;
	}
	
	public virtual /*reliable client simulated function */void ClientWeaponSet(bool bOptionalSet)
	{
	
	}
	
	public virtual /*simulated function */void WeaponCalcCamera(float fDeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot)
	{
	
	}
	
	public delegate void StartFire_del(byte FireModeNum);
	public virtual StartFire_del StartFire { get => bfield_StartFire ?? Weapon_StartFire; set => bfield_StartFire = value; } StartFire_del bfield_StartFire;
	public virtual StartFire_del global_StartFire => Weapon_StartFire;
	public /*simulated function */void Weapon_StartFire(byte FireModeNum)
	{
	
	}
	
	public delegate void ServerStartFire_del(byte FireModeNum);
	public virtual ServerStartFire_del ServerStartFire { get => bfield_ServerStartFire ?? Weapon_ServerStartFire; set => bfield_ServerStartFire = value; } ServerStartFire_del bfield_ServerStartFire;
	public virtual ServerStartFire_del global_ServerStartFire => Weapon_ServerStartFire;
	public /*reliable server function */void Weapon_ServerStartFire(byte FireModeNum)
	{
	
	}
	
	public delegate void BeginFire_del(byte FireModeNum);
	public virtual BeginFire_del BeginFire { get => bfield_BeginFire ?? Weapon_BeginFire; set => bfield_BeginFire = value; } BeginFire_del bfield_BeginFire;
	public virtual BeginFire_del global_BeginFire => Weapon_BeginFire;
	public /*simulated function */void Weapon_BeginFire(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void StopFire(byte FireModeNum)
	{
	
	}
	
	public delegate void ServerStopFire_del(byte FireModeNum);
	public virtual ServerStopFire_del ServerStopFire { get => bfield_ServerStopFire ?? Weapon_ServerStopFire; set => bfield_ServerStopFire = value; } ServerStopFire_del bfield_ServerStopFire;
	public virtual ServerStopFire_del global_ServerStopFire => Weapon_ServerStopFire;
	public /*reliable server function */void Weapon_ServerStopFire(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void EndFire(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void ForceEndFire()
	{
	
	}
	
	public virtual /*simulated function */void SendToFiringState(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void SetCurrentFireMode(byte FiringModeNum)
	{
	
	}
	
	public virtual /*simulated function */void FireModeUpdated(byte FiringMode, bool bViaReplication)
	{
	
	}
	
	public virtual /*simulated function */void FireAmmunition()
	{
	
	}
	
	public virtual /*simulated function */Object.Rotator GetAdjustedAim(Object.Vector StartFireLoc)
	{
	
		return default;
	}
	
	public virtual /*simulated function */float GetTraceRange()
	{
	
		return default;
	}
	
	public virtual /*simulated function */Actor GetTraceOwner()
	{
	
		return default;
	}
	
	public virtual /*simulated function */Actor.ImpactInfo CalcWeaponFire(Object.Vector StartTrace, Object.Vector EndTrace, /*optional */ref array<Actor.ImpactInfo> ImpactList/* = default*/)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool PassThroughDamage(Actor HitActor, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void InstantFire()
	{
	
	}
	
	public virtual /*simulated function */void ProcessInstantHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
	
	}
	
	public virtual /*simulated function */Projectile ProjectileFire()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void CustomFire()
	{
	
	}
	
	public virtual /*simulated event */Object.Vector GetMuzzleLoc()
	{
	
		return default;
	}
	
	public virtual /*simulated function */Object.Vector GetPhysicalFireStartLoc(/*optional */Object.Vector? _AimDir = default)
	{
	
		return default;
	}
	
	public delegate bool TryPutDown_del();
	public virtual TryPutDown_del TryPutDown { get => bfield_TryPutDown ?? Weapon_TryPutDown; set => bfield_TryPutDown = value; } TryPutDown_del bfield_TryPutDown;
	public virtual TryPutDown_del global_TryPutDown => Weapon_TryPutDown;
	public /*simulated function */bool Weapon_TryPutDown()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void HandleFinishedFiring()
	{
	
	}
	
	public virtual /*function */void NotifyWeaponFired(byte FireMode)
	{
	
	}
	
	public virtual /*function */void NotifyWeaponFinishedFiring(byte FireMode)
	{
	
	}
	
	public delegate bool ShouldRefire_del();
	public virtual ShouldRefire_del ShouldRefire { get => bfield_ShouldRefire ?? Weapon_ShouldRefire; set => bfield_ShouldRefire = value; } ShouldRefire_del bfield_ShouldRefire;
	public virtual ShouldRefire_del global_ShouldRefire => Weapon_ShouldRefire;
	public /*simulated function */bool Weapon_ShouldRefire()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool StillFiring(byte FireMode)
	{
	
		return default;
	}
	
	public delegate bool ReadyToFire_del(bool bFinished);
	public virtual ReadyToFire_del ReadyToFire { get => bfield_ReadyToFire ?? ((_)=>default); set => bfield_ReadyToFire = value; } ReadyToFire_del bfield_ReadyToFire;
	public virtual ReadyToFire_del global_ReadyToFire => (_)=>default;
	
	public delegate void WeaponEquipped_del();
	public virtual WeaponEquipped_del WeaponEquipped { get => bfield_WeaponEquipped ?? (()=>{}); set => bfield_WeaponEquipped = value; } WeaponEquipped_del bfield_WeaponEquipped;
	public virtual WeaponEquipped_del global_WeaponEquipped => ()=>{};
	
	public delegate void WeaponIsDown_del();
	public virtual WeaponIsDown_del WeaponIsDown { get => bfield_WeaponIsDown ?? (()=>{}); set => bfield_WeaponIsDown = value; } WeaponIsDown_del bfield_WeaponIsDown;
	public virtual WeaponIsDown_del global_WeaponIsDown => ()=>{};
	
	public delegate void PendingWeaponSetTimer_del();
	public virtual PendingWeaponSetTimer_del PendingWeaponSetTimer { get => bfield_PendingWeaponSetTimer ?? (()=>{}); set => bfield_PendingWeaponSetTimer = value; } PendingWeaponSetTimer_del bfield_PendingWeaponSetTimer;
	public virtual PendingWeaponSetTimer_del global_PendingWeaponSetTimer => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		IsFiring = null;
		RefireCheckTimer = null;
		Activate = null;
		WeaponEmpty = null;
		StartFire = null;
		ServerStartFire = null;
		BeginFire = null;
		ServerStopFire = null;
		TryPutDown = null;
		ShouldRefire = null;
	
	}
	
	protected /*reliable server function */void Weapon_Inactive_ServerStartFire(byte FireModeNum)// state function
	{
	
	}
	
	protected /*reliable server function */void Weapon_Inactive_ServerStopFire(byte FireModeNum)// state function
	{
	
	}
	
	protected /*simulated function */bool Weapon_Inactive_TryPutDown()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Inactive()/*auto state Inactive*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void Weapon_Active_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void Weapon_Active_BeginFire(byte FireModeNum)// state function
	{
	
	}
	
	protected /*simulated function */bool Weapon_Active_ReadyToFire(bool bFinished)// state function
	{
	
		return default;
	}
	
	protected /*simulated function */bool Weapon_Active_TryPutDown()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Active()/*simulated state Active*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */bool Weapon_WeaponFiring_IsFiring()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void Weapon_WeaponFiring_RefireCheckTimer()// state function
	{
	
	}
	
	protected /*simulated event */void Weapon_WeaponFiring_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated event */void Weapon_WeaponFiring_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponFiring()/*simulated state WeaponFiring*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void Weapon_WeaponEquipping_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated event */void Weapon_WeaponEquipping_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*simulated function */void Weapon_WeaponEquipping_WeaponEquipped()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponEquipping()/*simulated state WeaponEquipping*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void Weapon_WeaponPuttingDown_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void Weapon_WeaponPuttingDown_WeaponIsDown()// state function
	{
	
	}
	
	protected /*simulated function */bool Weapon_WeaponPuttingDown_TryPutDown()// state function
	{
	
		return default;
	}
	
	protected /*simulated event */void Weapon_WeaponPuttingDown_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponPuttingDown()/*simulated state WeaponPuttingDown*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void Weapon_PendingClientWeaponSet_PendingWeaponSetTimer()// state function
	{
	
	}
	
	protected /*simulated event */void Weapon_PendingClientWeaponSet_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated event */void Weapon_PendingClientWeaponSet_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PendingClientWeaponSet()/*state PendingClientWeaponSet*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Inactive": return Inactive();
			case "Active": return Active();
			case "WeaponFiring": return WeaponFiring();
			case "WeaponEquipping": return WeaponEquipping();
			case "WeaponPuttingDown": return WeaponPuttingDown();
			case "PendingClientWeaponSet": return PendingClientWeaponSet();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Inactive();
	}
	public Weapon()
	{
		// Object Offset:0x0045FFA2
		EquipTime = 0.330f;
		PutDownTime = 0.330f;
		bCanThrow = true;
		WeaponRange = 16384.0f;
		ClothImpulseRadius = 0.50f;
		ClothImpulseScale = 400.0f;
		DefaultAnimSpeed = 1.0f;
		Priority = -1.0f;
		AIRating = 0.50f;
		ItemName = "Weapon";
		RespawnTime = 30.0f;
		bReplicateInstigator = true;
		bOnlyDirtyReplication = false;
		Components = default;
	}
}
}