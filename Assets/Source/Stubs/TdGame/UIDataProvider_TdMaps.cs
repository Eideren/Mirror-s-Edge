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
		public /*const config localized */String CheckpointFriendlyName;
		public /*const config localized */String CheckpointDescription;
		public /*config */String CheckpointName;
		public /*config */String CheckpointImageMarkup;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006D8CEA
	//		CheckpointFriendlyName = "";
	//		CheckpointDescription = "";
	//		CheckpointName = "";
	//		CheckpointImageMarkup = "";
	//	}
	};
	
	public /*config */String Filename;
	public /*const config localized */String MapName;
	public /*const config localized */String Description;
	public /*config */String LevelImageMarkup;
	public /*config */bool bIsTutorialMap;
	public /*config */String LevelEvent;
	public /*config */String GameMode;
	public /*config */array</*config */UIDataProvider_TdMaps.TdMapCheckpoint> Checkpoints;
	
	public override /*event */bool IsProviderDisabled()
	{
	
		return default;
	}
	
}
}