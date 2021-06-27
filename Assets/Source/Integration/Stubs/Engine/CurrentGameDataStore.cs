namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurrentGameDataStore : UIDataStore_GameState/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */GameDataProviderTypes
	{
		public /*const */Core.ClassT<GameInfoDataProvider> GameDataProviderClass;
		public /*const */Core.ClassT<PlayerDataProvider> PlayerDataProviderClass;
		public /*const */Core.ClassT<TeamDataProvider> TeamDataProviderClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002F671C
	//		GameDataProviderClass = default;
	//		PlayerDataProviderClass = default;
	//		TeamDataProviderClass = default;
	//	}
	};
	
	public /*const */CurrentGameDataStore.GameDataProviderTypes ProviderTypes;
	public /*protected */GameInfoDataProvider GameData;
	public /*protected */array<PlayerDataProvider> PlayerData;
	public /*protected */array<TeamDataProvider> TeamData;
	
	public virtual /*final function */void CreateGameDataProvider(GameReplicationInfo GRI)
	{
		// stub
	}
	
	public virtual /*final function */void AddPlayerDataProvider(PlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*final function */void RemovePlayerDataProvider(PlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*final function */void AddTeamDataProvider(TeamInfo TI)
	{
		// stub
	}
	
	public virtual /*final function */void RemoveTeamDataProvider(TeamInfo TI)
	{
		// stub
	}
	
	public virtual /*final function */int FindPlayerDataProviderIndex(PlayerReplicationInfo PRI)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */int FindTeamDataProviderIndex(TeamInfo TI)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */PlayerDataProvider GetPlayerDataProvider(PlayerReplicationInfo PRI)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */TeamDataProvider GetTeamDataProvider(TeamInfo TI)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void ClearDataProviders()
	{
		// stub
	}
	
	public override /*function */bool NotifyGameSessionEnded()
	{
		// stub
		return default;
	}
	
	public CurrentGameDataStore()
	{
		// Object Offset:0x002F7440
		ProviderTypes = new CurrentGameDataStore.GameDataProviderTypes
		{
			GameDataProviderClass = ClassT<GameInfoDataProvider>()/*Ref Class'GameInfoDataProvider'*/,
			PlayerDataProviderClass = ClassT<PlayerDataProvider>()/*Ref Class'PlayerDataProvider'*/,
			TeamDataProviderClass = ClassT<TeamDataProvider>()/*Ref Class'TeamDataProvider'*/,
		};
		Tag = (name)"CurrentGame";
	}
}
}