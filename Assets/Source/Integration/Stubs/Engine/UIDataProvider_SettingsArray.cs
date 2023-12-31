namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_SettingsArray : UIDataProvider, 
		UIListElementProvider,UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementProvider;
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	public Settings Settings;
	public int SettingsId;
	public name SettingsName;
	[Const] public String ColumnHeaderText;
	public array<Settings.IdToStringMapping> Values;
	
	public UIDataProvider_SettingsArray()
	{
		// Object Offset:0x0042810F
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}