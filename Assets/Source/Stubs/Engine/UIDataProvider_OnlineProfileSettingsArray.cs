namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineProfileSettingsArray : UIDataProvider, 
		UIListElementProvider,UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementProvider;
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public OnlineProfileSettings ProfileSettings;
	public int ProfileSettingId;
	public name ProfileSettingsName;
	public /*const */String ColumnHeaderText;
	public array<name> Values;
	
	public UIDataProvider_OnlineProfileSettingsArray()
	{
		// Object Offset:0x00427C79
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}