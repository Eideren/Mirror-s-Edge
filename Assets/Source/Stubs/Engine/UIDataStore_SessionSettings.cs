namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_SessionSettings : UIDataStore_Settings/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public /*const config */array</*config */String> SessionSettingsProviderClassNames;
	public /*const transient */array< Core.ClassT<SessionSettingsProvider> > SessionSettingsProviderClasses;
	public /*transient */array<SessionSettingsProvider> SessionSettings;
	
	public virtual /*final function */void ClearDataProviders()
	{
	
	}
	
	public override /*function */bool NotifyGameSessionEnded()
	{
	
		return default;
	}
	
	public UIDataStore_SessionSettings()
	{
		// Object Offset:0x0042CAD1
		Tag = (name)"GameSettings";
	}
}
}