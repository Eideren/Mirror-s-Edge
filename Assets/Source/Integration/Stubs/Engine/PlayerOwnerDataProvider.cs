namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerOwnerDataProvider : PlayerDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[transient] public PlayerDataProvider PlayerData;
	
	public virtual /*function */void SetPlayerDataProvider(PlayerDataProvider NewPlayerData)
	{
		// stub
	}
	
	public override /*function */bool CleanupDataProvider()
	{
		// stub
		return default;
	}
	
}
}