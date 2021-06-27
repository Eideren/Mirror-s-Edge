namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIGameInfoSummary : UIResourceDataProvider/*
		transient
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public /*config */String ClassName;
	public /*config */String GameAcronym;
	public /*config */String MapPrefix;
	public /*config */bool bIsTeamGame;
	public /*config */bool bIsDisabled;
	public /*const config localized */String GameName;
	public /*const config localized */String Description;
	
	public override /*event */bool IsProviderDisabled()
	{
		// stub
		return default;
	}
	
}
}