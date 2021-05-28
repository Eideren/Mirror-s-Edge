namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_Settings : UIDynamicDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */SettingsArrayProvider
	{
		public int SettingsId;
		public name SettingsName;
		public UIDataProvider_SettingsArray Provider;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00427E6C
	//		SettingsId = 0;
	//		SettingsName = (name)"None";
	//		Provider = default;
	//	}
	};
	
	public Settings Settings;
	public array<UIDataProvider_Settings.SettingsArrayProvider> SettingsArrayProviders;
	public bool bIsAListRow;
	
	public UIDataProvider_Settings()
	{
		// Object Offset:0x00427EFC
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}