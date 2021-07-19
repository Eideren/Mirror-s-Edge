namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIGameInfoSummary : UIResourceDataProvider/*
		transient
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	[config] public String ClassName;
	[config] public String GameAcronym;
	[config] public String MapPrefix;
	[config] public bool bIsTeamGame;
	[config] public bool bIsDisabled;
	[Const, config, localized] public String GameName;
	[Const, config, localized] public String Description;
	
	public override /*event */bool IsProviderDisabled()
	{
		// stub
		return default;
	}
	
}
}