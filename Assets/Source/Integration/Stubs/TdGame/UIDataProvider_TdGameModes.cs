namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdGameModes : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */TdGameModes_RoleIdStruct
	{
		public int RoleId;
		public int Team;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006D85B3
	//		RoleId = 0;
	//		Team = 0;
	//	}
	};
	
	[config] public String GameModeClass;
	[Const, config, localized] public String FriendlyName;
	[Const, config, localized] public String Description;
	[config] public/*private*/ array</*config */UIDataProvider_TdGameModes.TdGameModes_RoleIdStruct> Roles;
	
	public override /*event */bool IsProviderDisabled()
	{
		// stub
		return default;
	}
	
}
}