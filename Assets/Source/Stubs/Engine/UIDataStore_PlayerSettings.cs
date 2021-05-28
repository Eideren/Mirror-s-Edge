namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_PlayerSettings : UIDataStore_Settings/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public /*const config */array</*config */string> PlayerSettingsProviderClassNames;
	public /*const transient */array< Core.ClassT<PlayerSettingsProvider> > PlayerSettingsProviderClasses;
	public /*transient */array<PlayerSettingsProvider> PlayerSettings;
	public /*const transient */int PlayerIndex;
	
	// Export UUIDataStore_PlayerSettings::execGetPlayerOwner(FFrame&, void* const)
	public virtual /*native final function */LocalPlayer GetPlayerOwner()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */void ClearDataProviders()
	{
	
	}
	
	public override /*function */bool NotifyGameSessionEnded()
	{
	
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