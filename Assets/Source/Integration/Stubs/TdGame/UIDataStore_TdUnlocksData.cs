namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdUnlocksData : UIDataStore_TdGameResource/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public virtual /*event */bool IsElementEnabled(name FieldName, int CollectionIndex)
	{
		// stub
		return default;
	}
	
	public UIDataStore_TdUnlocksData()
	{
		// Object Offset:0x006EC66B
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdArtworkUnlocks",
				ProviderClassName = "TdGame.UIDataProvider_ArtworkUnlocks",
				ProviderClass = default,
			},
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdVideoUnlocks",
				ProviderClassName = "TdGame.UIDataProvider_VideosUnlocks",
				ProviderClass = default,
			},
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdMusicUnlocks",
				ProviderClassName = "TdGame.UIDataProvider_MusicUnlocks",
				ProviderClass = default,
			},
		};
		Tag = (name)"TdUnlocksData";
	}
}
}