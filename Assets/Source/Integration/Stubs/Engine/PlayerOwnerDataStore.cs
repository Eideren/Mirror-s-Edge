namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerOwnerDataStore : UIDataStore_GameState/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */PlayerDataProviderTypes
	{
		public /*const */Core.ClassT<PlayerOwnerDataProvider> PlayerOwnerDataProviderClass;
		public /*const */Core.ClassT<CurrentWeaponDataProvider> CurrentWeaponDataProviderClass;
		public /*const */Core.ClassT<WeaponDataProvider> WeaponDataProviderClass;
		public /*const */Core.ClassT<PowerupDataProvider> PowerupDataProviderClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0039F120
	//		PlayerOwnerDataProviderClass = default;
	//		CurrentWeaponDataProviderClass = default;
	//		WeaponDataProviderClass = default;
	//		PowerupDataProviderClass = default;
	//	}
	};
	
	public /*const */PlayerOwnerDataStore.PlayerDataProviderTypes ProviderTypes;
	public /*protected */PlayerOwnerDataProvider PlayerData;
	public /*protected */CurrentWeaponDataProvider CurrentWeapon;
	public /*protected */array<WeaponDataProvider> WeaponList;
	public /*protected */array<PowerupDataProvider> PowerupList;
	
	public virtual /*function */void SetPlayerDataProvider(PlayerDataProvider NewPlayerData)
	{
		// stub
	}
	
	public virtual /*final function */void ClearDataProviders()
	{
		// stub
	}
	
	public override /*function */bool NotifyGameSessionEnded()
	{
		// stub
		return default;
	}
	
	public PlayerOwnerDataStore()
	{
		// Object Offset:0x0039F546
		ProviderTypes = new PlayerOwnerDataStore.PlayerDataProviderTypes
		{
			PlayerOwnerDataProviderClass = ClassT<PlayerOwnerDataProvider>()/*Ref Class'PlayerOwnerDataProvider'*/,
			CurrentWeaponDataProviderClass = ClassT<CurrentWeaponDataProvider>()/*Ref Class'CurrentWeaponDataProvider'*/,
			WeaponDataProviderClass = ClassT<WeaponDataProvider>()/*Ref Class'WeaponDataProvider'*/,
			PowerupDataProviderClass = ClassT<PowerupDataProvider>()/*Ref Class'PowerupDataProvider'*/,
		};
		Tag = (name)"PlayerOwner";
	}
}
}