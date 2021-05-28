namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdStretch : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public /*const config localized */string FriendlyName;
	public /*const config localized */string Description;
	public /*config */string MapFileName;
	public /*config */name StretchNameId;
	
}
}