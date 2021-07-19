namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_PlayerSettings : UIDataStore_Settings/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	[Const, config] public array</*config */String> PlayerSettingsProviderClassNames;
	[Const, transient] public array< Core.ClassT<PlayerSettingsProvider> > PlayerSettingsProviderClasses;
	[transient] public array<PlayerSettingsProvider> PlayerSettings;
	[Const, transient] public int PlayerIndex;
	
	// Export UUIDataStore_PlayerSettings::execGetPlayerOwner(FFrame&, void* const)
	public virtual /*native final function */LocalPlayer GetPlayerOwner()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
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
	
	public UIDataStore_PlayerSettings()
	{
		// Object Offset:0x0042C637
		PlayerIndex = -1;
		Tag = (name)"PlayerSettings";
	}
}
}