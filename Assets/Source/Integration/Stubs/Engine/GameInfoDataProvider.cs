namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameInfoDataProvider : UIDynamicDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public GameReplicationInfo GameDataSource;
	
	public override /*event */void ProviderInstanceBound(Object DataSourceInstance)
	{
		// stub
	}
	
	public GameInfoDataProvider()
	{
		// Object Offset:0x0033196B
		DataClass = ClassT<GameReplicationInfo>()/*Ref Class'GameReplicationInfo'*/;
	}
}
}