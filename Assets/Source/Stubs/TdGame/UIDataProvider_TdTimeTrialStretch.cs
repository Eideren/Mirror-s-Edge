namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdTimeTrialStretch : UIDataProvider_TdStretch/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public /*config */string ImageMarkup;
	public /*config */float QualifyingTime;
	public /*config */float Rating1Time;
	public /*config */float Rating2Time;
	public /*config */float Rating3Time;
	public /*const config localized */string UnlockDesc;
	public string StretchFlags;
	
}
}