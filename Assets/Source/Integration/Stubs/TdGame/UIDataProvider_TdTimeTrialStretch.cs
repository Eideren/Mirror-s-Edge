namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdTimeTrialStretch : UIDataProvider_TdStretch/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	[config] public String ImageMarkup;
	[config] public float QualifyingTime;
	[config] public float Rating1Time;
	[config] public float Rating2Time;
	[config] public float Rating3Time;
	[Const, config, localized] public String UnlockDesc;
	public String StretchFlags;
	
}
}