namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_SessionSettings : UIDataStore_Settings/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	[Const, config] public array</*config */String> SessionSettingsProviderClassNames;
	[Const, transient] public array< Core.ClassT<SessionSettingsProvider> > SessionSettingsProviderClasses;
	[transient] public array<SessionSettingsProvider> SessionSettings;
	
	public virtual /*final function */void ClearDataProviders()
	{
		// stub
	}
	
	public override /*function */bool NotifyGameSessionEnded()
	{
		// stub
		return default;
	}
	
	public UIDataStore_SessionSettings()
	{
		// Object Offset:0x0042CAD1
		Tag = (name)"GameSettings";
	}
}
}