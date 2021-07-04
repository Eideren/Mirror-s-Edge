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
	//	 if(((((!bSkipActorPropertyReplication || bNetInitial)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty) && bNetOwner)
	//		InventoryChain;
	//}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	// Export UInventoryManager::execInventoryActors(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Inventory/* Inv*/> InventoryActors(Core.ClassT<Inventory> BaseClass)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		yield break;
	}
	
	public virtual /*simulated exec function */void DumpWeaponStats()
	{
		// stub
	}
	
	public virtual /*function */void SetupFor(Pawn P)
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*function */bool HandlePickupQuery(Core.ClassT<Inventory> ItemClass, Actor Pickup)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated event */Inventory FindInventoryType(Core.ClassT<Inventory> DesiredClass, /*optional */bool? _bAllowSubclass = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Inventory CreateInventory(Core.ClassT<Inventory> NewInventoryItemClass, /*optional */bool? _bDoNotActivate = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool AddInventory(Inventory NewItem, /*optional */bool? _bDoNotActivate = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void RemoveFromInventory(Inventory ItemToRemove)
	{
		// stub
	}
	
	public virtual /*simulated event */void DiscardInventory()
	{
		// stub
	}
	
	public virtual /*function */int ModifyDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void OwnerEvent(name EventName)
	{
		// stub
	}
	
	public virtual /*simulated function */void DrawHUD(HUD H)
	{
		// stub
	}
	
	public virtual /*simulated function */void StartFire(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */void StopFire(byte FireModeNum)
	{
		// stub
	}
	
	public virtual /*simulated function */bool IsActiveWeapon(Weapon ThisWeapon)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */float GetWeaponRatingFor(Weapon W)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Weapon GetBestWeapon(/*optional */bool? _bForceADifferentWeapon = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void SwitchToBestWeapon(/*optional */bool? _bForceADifferentWeapon = default)
	{
		// stub
	}
	
	public virtual /*simulated function */void PrevWeapon()
	{
		// stub
	}
	
	public virtual /*simulated function */void NextWeapon()
	{
		// stub
	}
	
	public virtual /*reliable client simulated function */void SetCurrentWeapon(Weapon DesiredWeapon)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetPendingWeapon(Weapon DesiredWeapon)
	{
		// stub
	}
	
	public virtual /*reliable server function */void ServerSetCurrentWeapon(Weapon DesiredWeapon)
	{
		// stub
	}
	
	public virtual /*simulated function */bool CancelWeaponChange()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void ChangedWeapon()
	{
		// stub
	}
	
	public virtual /*simulated function */void ClientWeaponSet(Weapon NewWeapon, bool bOptionalSet)
	{
		// stub
	}
	
	public virtual /*reliable client simulated function */void ClientSyncWeapon(Weapon NewWeapon)
	{
		// stub
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