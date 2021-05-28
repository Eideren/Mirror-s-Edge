namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIGameInfoSummary : UIResourceDataProvider/*
		transient
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public /*config */string ClassName;
	public /*config */string GameAcronym;
	public /*config */string MapPrefix;
	public /*config */bool bIsTeamGame;
	public /*config */bool bIsDisabled;
	public /*const config localized */string GameName;
	public /*const config localized */string Description;
	
	public override /*event */bool IsProviderDisabled()
	{
	
		return default;
	}
	
}
}