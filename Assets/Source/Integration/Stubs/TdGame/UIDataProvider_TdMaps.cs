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
		[Const, config, localized] public String CheckpointFriendlyName;
		[Const, config, localized] public String CheckpointDescription;
		[config] public String CheckpointName;
		[config] public String CheckpointImageMarkup;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006D8CEA
	//		CheckpointFriendlyName = "";
	//		CheckpointDescription = "";
	//		CheckpointName = "";
	//		CheckpointImageMarkup = "";
	//	}
	};
	
	[config] public String Filename;
	[Const, config, localized] public String MapName;
	[Const, config, localized] public String Description;
	[config] public String LevelImageMarkup;
	[config] public bool bIsTutorialMap;
	[config] public String LevelEvent;
	[config] public String GameMode;
	[config] public array</*config */UIDataProvider_TdMaps.TdMapCheckpoint> Checkpoints;
	
	public override /*event */bool IsProviderDisabled()
	{
		// stub
		return default;
	}
	
}
}