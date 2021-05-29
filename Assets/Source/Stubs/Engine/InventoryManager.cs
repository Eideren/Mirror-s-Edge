namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InventoryManager : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public Inventory InventoryChain;
	public Weapon PendingWeapon;
	public Weapon LastAttemptedSwitchToWeapon;
	public bool bMustHoldWeapon;
	public array<int> PendingFire;
	
	//replication
	//{
	//	 if((((!bSkipActorPropertyReplication || bNetInitial) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty) && bNetOwner)
	//		InventoryChain;
	//}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	// Export UInventoryManager::execInventoryActors(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Inventory/* Inv*/> InventoryActors(Core.ClassT<Inventory> BaseClass)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	public virtual /*simulated exec function */void DumpWeaponStats()
	{
	
	}
	
	public virtual /*function */void SetupFor(Pawn P)
	{
	
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public virtual /*function */bool HandlePickupQuery(Core.ClassT<Inventory> ItemClass, Actor Pickup)
	{
	
		return default;
	}
	
	public virtual /*simulated event */Inventory FindInventoryType(Core.ClassT<Inventory> DesiredClass, /*optional */bool? _bAllowSubclass = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */Inventory CreateInventory(Core.ClassT<Inventory> NewInventoryItemClass, /*optional */bool? _bDoNotActivate = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool AddInventory(Inventory NewItem, /*optional */bool? _bDoNotActivate = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void RemoveFromInventory(Inventory ItemToRemove)
	{
	
	}
	
	public virtual /*simulated event */void DiscardInventory()
	{
	
	}
	
	public virtual /*function */int ModifyDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void OwnerEvent(name EventName)
	{
	
	}
	
	public virtual /*simulated function */void DrawHUD(HUD H)
	{
	
	}
	
	public virtual /*simulated function */void StartFire(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void StopFire(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */bool IsActiveWeapon(Weapon ThisWeapon)
	{
	
		return default;
	}
	
	public virtual /*simulated function */float GetWeaponRatingFor(Weapon W)
	{
	
		return default;
	}
	
	public virtual /*simulated function */Weapon GetBestWeapon(/*optional */bool? _bForceADifferentWeapon = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void SwitchToBestWeapon(/*optional */bool? _bForceADifferentWeapon = default)
	{
	
	}
	
	public virtual /*simulated function */void PrevWeapon()
	{
	
	}
	
	public virtual /*simulated function */void NextWeapon()
	{
	
	}
	
	public virtual /*reliable client simulated function */void SetCurrentWeapon(Weapon DesiredWeapon)
	{
	
	}
	
	public virtual /*simulated function */void SetPendingWeapon(Weapon DesiredWeapon)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSetCurrentWeapon(Weapon DesiredWeapon)
	{
	
	}
	
	public virtual /*simulated function */bool CancelWeaponChange()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void ChangedWeapon()
	{
	
	}
	
	public virtual /*simulated function */void ClientWeaponSet(Weapon NewWeapon, bool bOptionalSet)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientSyncWeapon(Weapon NewWeapon)
	{
	
	}
	
	public InventoryManager()
	{
		// Object Offset:0x00347CC9
		bHidden = true;
		bOnlyRelevantToOwner = true;
		bReplicateInstigator = true;
		bReplicateMovement = false;
		bOnlyDirtyReplication = true;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
		NetPriority = 1.40f;
	}
}
}