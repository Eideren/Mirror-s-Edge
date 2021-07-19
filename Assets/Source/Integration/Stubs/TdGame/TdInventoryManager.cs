namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInventoryManager : InventoryManager/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	[Category("Inventory")] [config] public float WeaponPickupTime;
	[transient] public Inventory.EInventorySlot LastActiveGunSlot;
	
	public virtual /*simulated function */void SwitchGun()
	{
		// stub
	}
	
	public virtual /*simulated function */void SwitchToSpecificWeapon(int Index)
	{
		// stub
	}
	
	public override /*simulated function */void SwitchToBestWeapon(/*optional */bool? _bForceADifferentWeapon = default)
	{
		// stub
	}
	
	public virtual /*private final simulated function */bool SwitchToWeaponInSlot(Inventory.EInventorySlot Slot)
	{
		// stub
		return default;
	}
	
	public virtual /*private final simulated function */TdWeapon GetWeaponFromSlot(Inventory.EInventorySlot Slot)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void PressedSwitchWeapon()
	{
		// stub
	}
	
	public virtual /*simulated function */void TryToPickUpWeapon()
	{
		// stub
	}
	
	public virtual /*final simulated function */TdPickup FindNearbyPickup()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Inventory.EInventorySlot FindFreeSlotForWeaponClass(Core.ClassT<TdWeapon> WeaponClass)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void NextWeapon()
	{
		// stub
	}
	
	public override /*simulated function */void PrevWeapon()
	{
		// stub
	}
	
	public override /*reliable client simulated function */void SetCurrentWeapon(Weapon DesiredWeapon)
	{
		// stub
	}
	
	public override /*simulated function */float GetWeaponRatingFor(Weapon W)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void ChangedWeapon()
	{
		// stub
	}
	
	public override /*simulated function */void RemoveFromInventory(Inventory ItemToRemove)
	{
		// stub
	}
	
	public virtual /*reliable client simulated function */void ClientSwitchToBestWeaponAfterDrop()
	{
		// stub
	}
	
	public virtual /*simulated function */void ListInventory()
	{
		// stub
	}
	
	public TdInventoryManager()
	{
		// Object Offset:0x0057E0E2
		WeaponPickupTime = 0.20f;
	}
}
}