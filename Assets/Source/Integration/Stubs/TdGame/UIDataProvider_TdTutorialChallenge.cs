namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdTutorialChallenge : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	[config] public int ChallengeId;
	[Const, config, localized] public String FriendlyName;
	[Const, config, localized] public String Description;
	[config] public String ImageMarkup;
	[config] public array</*config */float> GradeTimeSeconds;
	
}
}