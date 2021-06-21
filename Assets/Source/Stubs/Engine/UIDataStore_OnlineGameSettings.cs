namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_OnlineGameSettings : UIDataStore_Settings/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */GameSettingsCfg
	{
		public Core.ClassT<OnlineGameSettings> GameSettingsClass;
		public UIDataProvider_Settings Provider;
		public OnlineGameSettings GameSettings;
		public name SettingsName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0042A018
	//		GameSettingsClass = default;
	//		Provider = default;
	//		GameSettings = default;
	//		SettingsName = (name)"None";
	//	}
	};
	
	public /*const */array<UIDataStore_OnlineGameSettings.GameSettingsCfg> GameSettingsCfgList;
	public int SelectedIndex;
	
	public virtual /*event */bool CreateGame(byte ControllerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*event */OnlineGameSettings GetCurrentGameSettings()
	{
		// stub
		return default;
	}
	
	public virtual /*event */UIDataProvider_Settings GetCurrentProvider()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void SetCurrentByIndex(int NewIndex)
	{
		// stub
	}
	
	public virtual /*event */void SetCurrentByName(name SettingsName)
	{
		// stub
	}
	
	public virtual /*event */void MoveToNext()
	{
		// stub
	}
	
	public virtual /*event */void MoveToPrevious()
	{
		// stub
	}
	
	public UIDataStore_OnlineGameSettings()
	{
		// Object Offset:0x0042A65A
		Tag = (name)"OnlineGameSettings";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}