namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdRoles : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public /*config */int RoleId;
	public /*config */string RoleClass;
	public /*config */string RoleName;
	public /*config */string RoleImageMarkup;
	public /*config */string Description;
	
	public override /*event */bool IsProviderDisabled()
	{
	
		return default;
	}
	
}
}