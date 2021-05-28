namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineProfileSettings : UIDataProvider_OnlinePlayerDataBase/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */ProfileSettingsArrayProvider
	{
		public int ProfileSettingsId;
		public name ProfileSettingsName;
		public UIDataProvider_OnlineProfileSettingsArray Provider;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00427278
	//		ProfileSettingsId = 0;
	//		ProfileSettingsName = (name)"None";
	//		Provider = default;
	//	}
	};
	
	public OnlineProfileSettings Profile;
	public /*const */name ProviderName;
	public bool bWasErrorLastRead;
	public array<UIDataProvider_OnlineProfileSettings.ProfileSettingsArrayProvider> ProfileSettingsArrayProviders;
	
	public override /*event */void OnRegister(LocalPlayer InPlayer)
	{
	
	}
	
	public override /*event */void OnUnregister()
	{
	
	}
	
	public virtual /*function */void OnReadProfileComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */void OnLoginChange()
	{
	
	}
	
	public virtual /*event */bool SaveProfileData()
	{
	
		return default;
	}
	
	public UIDataProvider_OnlineProfileSettings()
	{
		// Object Offset:0x00427A0E
		ProviderName = (name)"ProfileData";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}