namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInventoryManager : InventoryManager/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public/*(Inventory)*/ /*config */float WeaponPickupTime;
	public /*transient */Inventory.EInventorySlot LastActiveGunSlot;
	
	public virtual /*simulated function */void SwitchGun()
	{
	
	}
	
	public virtual /*simulated function */void SwitchToSpecificWeapon(int Index)
	{
	
	}
	
	public override /*simulated function */void SwitchToBestWeapon(/*optional */bool? _bForceADifferentWeapon = default)
	{
	
	}
	
	public virtual /*private final simulated function */bool SwitchToWeaponInSlot(Inventory.EInventorySlot Slot)
	{
	
		return default;
	}
	
	public virtual /*private final simulated function */TdWeapon GetWeaponFromSlot(Inventory.EInventorySlot Slot)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void PressedSwitchWeapon()
	{
	
	}
	
	public virtual /*simulated function */void TryToPickUpWeapon()
	{
	
	}
	
	public virtual /*final simulated function */TdPickup FindNearbyPickup()
	{
	
		return default;
	}
	
	public virtual /*simulated function */Inventory.EInventorySlot FindFreeSlotForWeaponClass(Core.ClassT<TdWeapon> WeaponClass)
	{
	
		return default;
	}
	
	public override /*simulated function */void NextWeapon()
	{
	
	}
	
	public override /*simulated function */void PrevWeapon()
	{
	
	}
	
	public override /*reliable client simulated function */void SetCurrentWeapon(Weapon DesiredWeapon)
	{
	
	}
	
	public override /*simulated function */float GetWeaponRatingFor(Weapon W)
	{
	
		return default;
	}
	
	public override /*simulated function */void ChangedWeapon()
	{
	
	}
	
	public override /*simulated function */void RemoveFromInventory(Inventory ItemToRemove)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientSwitchToBestWeaponAfterDrop()
	{
	
	}
	
	public virtual /*simulated function */void ListInventory()
	{
	
	}
	
	public TdInventoryManager()
	{
		// Object Offset:0x0057E0E2
		WeaponPickupTime = 0.20f;
	}
}
}