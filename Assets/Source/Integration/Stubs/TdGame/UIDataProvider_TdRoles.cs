namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdRoles : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	[config] public int RoleId;
	[config] public String RoleClass;
	[config] public String RoleName;
	[config] public String RoleImageMarkup;
	[config] public String Description;
	
	public override /*event */bool IsProviderDisabled()
	{
		// stub
		return default;
	}
	
}
}