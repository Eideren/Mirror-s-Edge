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
		// stub
	}
	
	public override /*function */void ItemRemovedFromInvManager()
	{
		// stub
	}
	
	public virtual /*simulated function */bool IsActiveWeapon()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void HolderDied()
	{
		// stub
	}
	
	public virtual /*simulated function */bool DoOverrideNextWeapon()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool DoOverridePrevWeapon()
	{
		// stub
		return default;
	}
	
	public override /*function */void DropFrom(Object.Vector StartLocation, Object.Vector StartVelocity)
	{
		// stub
	}
	
	public virtual /*simulated function */bool CanThrow()
	{
		// stub
		return default;
	}
	
	public virtual /*reliable client simulated function */void ClientWeaponThrown()
	{
		// stub
	}
	
	public delegate bool IsFiring_del();
	public virtual IsFiring_del IsFiring { get => bfield_IsFiring ?? Weapon_IsFiring; set => bfield_IsFiring = value; } IsFiring_del bfield_IsFiring;
	public virtual IsFiring_del global_IsFiring => Weapon_IsFiring;
	public /*simulated event */bool Weapon_IsFiring()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool DenyClientWeaponSet()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		// stub
	}
	
	public virtual /*simulated function */void GetWeaponDebug(ref array<String> DebugInfo)
	{
		// stub
	}
	
	public virtual /*simulated function */void DumpWeaponDebugToLog()
	{
		// stub
	}
	
	public virtual /*simulated function */void WeaponLog(/*coerce */String msg, /*coerce */String FuncStr)
	{
		// stub
	}
	
	public virtual /*function */void ConsumeAmmo(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*function */int AddAmmo(int Amount)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool HasAmmo(byte FireModeNum, /*optional */int? _Amount = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool HasAnyAmmo()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool PendingFire(int FireMode)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void SetPendingFire(int FireMode)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearPendingFire(int FireMode)
	{
		// stub
	}
	
	public virtual /*function */Core.ClassT<Projectile> GetProjectileClass()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Object.Rotator AddSpread(Object.Rotator BaseAim)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */float MaxRange()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetDamageRadius()
	{
		// stub
		return default;
	}
	
	public override /*function */void GivenTo(Pawn thisPawn, /*optional */bool? _bDoNotActivate = default)
	{
		// stub
	}
	
	public virtual /*function */float GetAIRating()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */float GetWeaponRating()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool RecommendRangedAttack()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool FocusOnLeader(bool bLeaderFiring)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool RecommendLongRangedAttack()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float RangedAttackTime()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanAttack(Actor Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */float SuggestAttackStyle()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float SuggestDefenseStyle()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool FireOnRelease()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */AnimNodeSequence GetWeaponAnimNodeSeq()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void WeaponPlaySound(SoundCue Sound, /*optional */float? _NoiseLoudness = default)
	{
		// stub
	}
	
	public virtual /*simulated function */void PlayWeaponAnimation(name Sequence, float fDesiredDuration, /*optional */bool? _bLoop = default, /*optional */SkeletalMeshComponent _SkelMesh = default)
	{
		// stub
	}
	
	public virtual /*simulated function */void StopWeaponAnimation()
	{
		// stub
	}
	
	public virtual /*simulated function */void PlayFireEffects(byte FireModeNum, /*optional */Object.Vector? _HitLocation = default)
	{
		// stub
	}
	
	public virtual /*simulated function */void StopFireEffects(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void PlayFiringSound()
	{
		// stub
	}
	
	public virtual /*simulated function */float GetFireInterval(byte FireModeNum)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void TimeWeaponFiring(byte FireModeNum)
	{
		// stub
	}
	
	public delegate void RefireCheckTimer_del();
	public virtual RefireCheckTimer_del RefireCheckTimer { get => bfield_RefireCheckTimer ?? Weapon_RefireCheckTimer; set => bfield_RefireCheckTimer = value; } RefireCheckTimer_del bfield_RefireCheckTimer;
	public virtual RefireCheckTimer_del global_RefireCheckTimer => Weapon_RefireCheckTimer;
	public /*simulated function */void Weapon_RefireCheckTimer()
	{
		// stub
	}
	
	public virtual /*simulated function */void TimeWeaponPutDown()
	{
		// stub
	}
	
	public virtual /*simulated function */void TimeWeaponEquipping()
	{
		// stub
	}
	
	public delegate void Activate_del();
	public virtual Activate_del Activate { get => bfield_Activate ?? Weapon_Activate; set => bfield_Activate = value; } Activate_del bfield_Activate;
	public virtual Activate_del global_Activate => Weapon_Activate;
	public /*simulated function */void Weapon_Activate()
	{
		// stub
	}
	
	public virtual /*simulated function */void PutDownWeapon()
	{
		// stub
	}
	
	public override /*function */bool DenyPickupQuery(Core.ClassT<Inventory> ItemClass, Actor Pickup)
	{
		// stub
		return default;
	}
	
	public delegate void WeaponEmpty_del();
	public virtual WeaponEmpty_del WeaponEmpty { get => bfield_WeaponEmpty ?? Weapon_WeaponEmpty; set => bfield_WeaponEmpty = value; } WeaponEmpty_del bfield_WeaponEmpty;
	public virtual WeaponEmpty_del global_WeaponEmpty => Weapon_WeaponEmpty;
	public /*simulated function */void Weapon_WeaponEmpty()
	{
		// stub
	}
	
	public virtual /*simulated function */void IncrementFlashCount()
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearFlashCount()
	{
		// stub
	}
	
	public virtual /*function */void SetFlashLocation(Object.Vector HitLocation)
	{
		// stub
	}
	
	public virtual /*function */void ClearFlashLocation()
	{
		// stub
	}
	
	public virtual /*simulated function */void AttachWeaponTo(SkeletalMeshComponent MeshCpnt, /*optional */name? _SocketName = default)
	{
		// stub
	}
	
	public virtual /*simulated function */void DetachWeapon()
	{
		// stub
	}
	
	public virtual /*simulated function */void GetViewAxes(ref Object.Vector XAxis, ref Object.Vector YAxis, ref Object.Vector ZAxis)
	{
		// stub
	}
	
	public virtual /*simulated function */float AdjustFOVAngle(float FOVAngle)
	{
		// stub
		return default;
	}
	
	public virtual /*reliable client simulated function */void ClientWeaponSet(bool bOptionalSet)
	{
		// stub
	}
	
	public virtual /*simulated function */void WeaponCalcCamera(float fDeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot)
	{
		// stub
	}
	
	public delegate void StartFire_del(byte FireModeNum);
	public virtual StartFire_del StartFire { get => bfield_StartFire ?? Weapon_StartFire; set => bfield_StartFire = value; } StartFire_del bfield_StartFire;
	public virtual StartFire_del global_StartFire => Weapon_StartFire;
	public /*simulated function */void Weapon_StartFire(byte FireModeNum)
	{
		// stub
	}
	
	public delegate void ServerStartFire_del(byte FireModeNum);
	public virtual ServerStartFire_del ServerStartFire { get => bfield_ServerStartFire ?? Weapon_ServerStartFire; set => bfield_ServerStartFire = value; } ServerStartFire_del bfield_ServerStartFire;
	public virtual ServerStartFire_del global_ServerStartFire => Weapon_ServerStartFire;
	public /*reliable server function */void Weapon_ServerStartFire(byte FireModeNum)
	{
		// stub
	}
	
	public delegate void BeginFire_del(byte FireModeNum);
	public virtual BeginFire_del BeginFire { get => bfield_BeginFire ?? Weapon_BeginFire; set => bfield_BeginFire = value; } BeginFire_del bfield_BeginFire;
	public virtual BeginFire_del global_BeginFire => Weapon_BeginFire;
	public /*simulated function */void Weapon_BeginFire(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void StopFire(byte FireModeNum)
	{
		// stub
	}
	
	public delegate void ServerStopFire_del(byte FireModeNum);
	public virtual ServerStopFire_del ServerStopFire { get => bfield_ServerStopFire ?? Weapon_ServerStopFire; set => bfield_ServerStopFire = value; } ServerStopFire_del bfield_ServerStopFire;
	public virtual ServerStopFire_del global_ServerStopFire => Weapon_ServerStopFire;
	public /*reliable server function */void Weapon_ServerStopFire(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void EndFire(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void ForceEndFire()
	{
		// stub
	}
	
	public virtual /*simulated function */void SendToFiringState(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetCurrentFireMode(byte FiringModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void FireModeUpdated(byte FiringMode, bool bViaReplication)
	{
		// stub
	}
	
	public virtual /*simulated function */void FireAmmunition()
	{
		// stub
	}
	
	public virtual /*simulated function */Object.Rotator GetAdjustedAim(Object.Vector StartFireLoc)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */float GetTraceRange()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Actor GetTraceOwner()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Actor.ImpactInfo CalcWeaponFire(Object.Vector StartTrace, Object.Vector EndTrace, /*optional */ref array<Actor.ImpactInfo> ImpactList/* = default*/)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool PassThroughDamage(Actor HitActor, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void InstantFire()
	{
		// stub
	}
	
	public virtual /*simulated function */void ProcessInstantHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
		// stub
	}
	
	public virtual /*simulated function */Projectile ProjectileFire()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void CustomFire()
	{
		// stub
	}
	
	public virtual /*simulated event */Object.Vector GetMuzzleLoc()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Object.Vector GetPhysicalFireStartLoc(/*optional */Object.Vector? _AimDir = default)
	{
		// stub
		return default;
	}
	
	public delegate bool TryPutDown_del();
	public virtual TryPutDown_del TryPutDown { get => bfield_TryPutDown ?? Weapon_TryPutDown; set => bfield_TryPutDown = value; } TryPutDown_del bfield_TryPutDown;
	public virtual TryPutDown_del global_TryPutDown => Weapon_TryPutDown;
	public /*simulated function */bool Weapon_TryPutDown()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void HandleFinishedFiring()
	{
		// stub
	}
	
	public virtual /*function */void NotifyWeaponFired(byte FireMode)
	{
		// stub
	}
	
	public virtual /*function */void NotifyWeaponFinishedFiring(byte FireMode)
	{
		// stub
	}
	
	public delegate bool ShouldRefire_del();
	public virtual ShouldRefire_del ShouldRefire { get => bfield_ShouldRefire ?? Weapon_ShouldRefire; set => bfield_ShouldRefire = value; } ShouldRefire_del bfield_ShouldRefire;
	public virtual ShouldRefire_del global_ShouldRefire => Weapon_ShouldRefire;
	public /*simulated function */bool Weapon_ShouldRefire()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool StillFiring(byte FireMode)
	{
		// stub
		return default;
	}
	
	public delegate bool ReadyToFire_del(bool bFinished);
	public virtual ReadyToFire_del ReadyToFire { get => bfield_ReadyToFire ?? ((_a)=>default); set => bfield_ReadyToFire = value; } ReadyToFire_del bfield_ReadyToFire;
	public virtual ReadyToFire_del global_ReadyToFire => (_a)=>default;
	
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
		// stub
	}
	
	protected /*reliable server function */void Weapon_Inactive_ServerStopFire(byte FireModeNum)// state function
	{
		// stub
	}
	
	protected /*simulated function */bool Weapon_Inactive_TryPutDown()// state function
	{
		// stub
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Inactive()/*auto state Inactive*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void Weapon_Active_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*simulated function */void Weapon_Active_BeginFire(byte FireModeNum)// state function
	{
		// stub
	}
	
	protected /*simulated function */bool Weapon_Active_ReadyToFire(bool bFinished)// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated function */bool Weapon_Active_TryPutDown()// state function
	{
		// stub
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Active()/*simulated state Active*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */bool Weapon_WeaponFiring_IsFiring()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated function */void Weapon_WeaponFiring_RefireCheckTimer()// state function
	{
		// stub
	}
	
	protected /*simulated event */void Weapon_WeaponFiring_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*simulated event */void Weapon_WeaponFiring_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponFiring()/*simulated state WeaponFiring*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void Weapon_WeaponEquipping_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*simulated event */void Weapon_WeaponEquipping_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected /*simulated function */void Weapon_WeaponEquipping_WeaponEquipped()// state function
	{
		// stub
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponEquipping()/*simulated state WeaponEquipping*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void Weapon_WeaponPuttingDown_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*simulated function */void Weapon_WeaponPuttingDown_WeaponIsDown()// state function
	{
		// stub
	}
	
	protected /*simulated function */bool Weapon_WeaponPuttingDown_TryPutDown()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */void Weapon_WeaponPuttingDown_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponPuttingDown()/*simulated state WeaponPuttingDown*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void Weapon_PendingClientWeaponSet_PendingWeaponSetTimer()// state function
	{
		// stub
	}
	
	protected /*simulated event */void Weapon_PendingClientWeaponSet_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*simulated event */void Weapon_PendingClientWeaponSet_EndState(name NextStateName)// state function
	{
		// stub
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