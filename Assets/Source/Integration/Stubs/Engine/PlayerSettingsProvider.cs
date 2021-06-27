namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerSettingsProvider : UISettingsProvider/* within UIDataStore_PlayerSettings*//*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new UIDataStore_PlayerSettings Outer => base.Outer as UIDataStore_PlayerSettings;
	
	public virtual /*event */void OnRegister(LocalPlayer InPlayer)
	{
		// stub
	}
	
	public virtual /*event */void OnUnregister()
	{
		// stub
	}
	
	public PlayerSettingsProvider()
	{
		// Object Offset:0x003A22A9
		ProviderTag = (name)"PlayerSettingsProvider";
	}
}
}