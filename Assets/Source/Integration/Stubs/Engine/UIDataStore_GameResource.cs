namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_GameResource : UIDataStore, 
		UIListElementProvider/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */GameResourceDataProvider
	{
		[config] public name ProviderTag;
		[config] public String ProviderClassName;
		[transient] public Core.ClassT<UIResourceDataProvider> ProviderClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00428448
	//		ProviderTag = (name)"None";
	//		ProviderClassName = "";
	//		ProviderClass = default;
	//	}
	};
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementProvider;
	[config] public array</*config */UIDataStore_GameResource.GameResourceDataProvider> ElementProviderTypes;
	[native, Const, transient] public/*private*/ Object.MultiMap_Mirror ListElementProviders;
	
	public UIDataStore_GameResource()
	{
		// Object Offset:0x004284D8
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"GameTypes",
				ProviderClassName = "Engine.UIGameInfoSummary",
				ProviderClass = default,
			},
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"KeyBindings",
				ProviderClassName = "TdGame.UIDataProvider_TdKeyBinding",
				ProviderClass = default,
			},
		};
		Tag = (name)"GameResources";
	}
}
}