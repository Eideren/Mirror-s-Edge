namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdMenuItems : UIDataStore_TdGameResource/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	// Export UUIDataStore_TdMenuItems::execGetAllResourceDataProviders(FFrame&, void* const)
	public /*native final function */static void GetAllResourceDataProviders(Core.ClassT<UIResourceDataProvider> ProviderClass, ref array<UIResourceDataProvider> Providers)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public UIDataStore_TdMenuItems()
	{
		// Object Offset:0x006DE821
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdMainMenuItems_Singleplayer",
				ProviderClassName = "TdGame.UIDataProvider_TdMainMenuItems_Singleplayer",
				ProviderClass = default,
			},
		};
		Tag = (name)"TdMenuItems";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}