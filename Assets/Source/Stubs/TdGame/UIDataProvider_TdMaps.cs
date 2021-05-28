namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdMaps : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */TdMapCheckpoint
	{
		public /*const config localized */string CheckpointFriendlyName;
		public /*const config localized */string CheckpointDescription;
		public /*config */string CheckpointName;
		public /*config */string CheckpointImageMarkup;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006D8CEA
	//		CheckpointFriendlyName = "";
	//		CheckpointDescription = "";
	//		CheckpointName = "";
	//		CheckpointImageMarkup = "";
	//	}
	};
	
	public /*config */string Filename;
	public /*const config localized */string MapName;
	public /*const config localized */string Description;
	public /*config */string LevelImageMarkup;
	public /*config */bool bIsTutorialMap;
	public /*config */string LevelEvent;
	public /*config */string GameMode;
	public /*config */array</*config */UIDataProvider_TdMaps.TdMapCheckpoint> Checkpoints;
	
	public override /*event */bool IsProviderDisabled()
	{
	
		return default;
	}
	
}
}