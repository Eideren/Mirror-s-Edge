namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerDataProvider : UIDynamicDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public PlayerDataProvider()
	{
		// Object Offset:0x0039ECAD
		DataClass = ClassT<PlayerReplicationInfo>()/*Ref Class'PlayerReplicationInfo'*/;
	}
}
}