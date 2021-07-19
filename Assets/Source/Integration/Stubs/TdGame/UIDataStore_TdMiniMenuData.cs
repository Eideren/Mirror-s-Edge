namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdMiniMenuData : UIDataStore_TdGameResource, 
		UIListElementCellProvider/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	public TdUIScene_MiniMenu MenuScene;
	
	public virtual /*final function */void Initialize(TdUIScene_MiniMenu InMenuScene)
	{
		// stub
	}
	
	public virtual /*final function */void Clean()
	{
		// stub
	}
	
	public UIDataStore_TdMiniMenuData()
	{
		// Object Offset:0x006DEAB9
		Tag = (name)"TdMiniMenuData";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}