namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdLoginData : UIDataStore_TdGameResource/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public Core.ClassT<TdLoginSettings> LoginSettingsClass;
	public TdLoginSettings LoginSettings;
	public UIDataProvider_Settings LoginSettingsProvider;
	[config] public String PersonaProviderClassName;
	public Core.ClassT<UIDataProvider_TdPersonaProvider> PersonaProviderClass;
	public UIDataProvider_TdPersonaProvider PersonaProvider;
	[config] public String AccountProviderClassName;
	public Core.ClassT<UIDataProvider_TdAccountProvider> AccountProviderClass;
	public UIDataProvider_TdAccountProvider AccountProvider;
	
	public virtual /*event */void OnRegister(LocalPlayer InPlayer)
	{
		// stub
	}
	
	public virtual /*event */void OnUnregister()
	{
		// stub
	}
	
	public UIDataStore_TdLoginData()
	{
		// Object Offset:0x006DE5CB
		LoginSettingsClass = ClassT<TdLoginSettings>()/*Ref Class'TdLoginSettings'*/;
		PersonaProviderClassName = "TdGame.UIDataProvider_TdPersonaProvider";
		AccountProviderClassName = "TdGame.UIDataProvider_TdAccountProvider";
		Tag = (name)"TdLoginData";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}