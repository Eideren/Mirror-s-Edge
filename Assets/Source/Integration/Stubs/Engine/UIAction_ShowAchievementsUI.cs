namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowAchievementsUI : UIAction/*
		hidecategories(Object)*/{
	public UIAction_ShowAchievementsUI()
	{
		// Object Offset:0x0041633B
		bAutoTargetOwner = true;
		ObjName = "Show Achievements UI";
		ObjCategory = "Online";
	}
}
}