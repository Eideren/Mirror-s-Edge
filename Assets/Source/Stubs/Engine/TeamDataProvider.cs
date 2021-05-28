namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TeamDataProvider : UIDynamicDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public TeamDataProvider()
	{
		// Object Offset:0x003F8B40
		DataClass = ClassT<TeamInfo>()/*Ref Class'TeamInfo'*/;
	}
}
}