namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLobbyListenServerBackend : TdLobbyBackend/*
		native*/{
	public /*private native const noexport */Object.Pointer VfTable_FTickableObject;
	public /*protected transient */TdGameReplicationInfo GRI;
	public UIDataStore_TdGameData TdGameData;
	public UIDataStore_TdMPData TdMPData;
	public/*()*/ name ResourceDataStoreName;
	public/*()*/ name SettingsDataStoreName;
	public /*protected transient */float TimeAccumulator;
	public /*protected transient */float TickTrigger;
	
	public virtual /*event */void CheckGRI(WorldInfo InInfo)
	{
		// stub
	}
	
	public override /*simulated function */void Cleanup()
	{
		// stub
	}
	
	public override /*simulated function */void Update()
	{
		// stub
	}
	
	public virtual /*function */TdLobbyGameInfo.LobbyPlayerStruct InitPlayerData(PlayerReplicationInfo PRI)
	{
		// stub
		return default;
	}
	
	public override /*function */void OnPlayerLogin(Controller C)
	{
		// stub
	}
	
	public override /*function */void OnPlayerLogout(Controller C)
	{
		// stub
	}
	
	public override /*function */void OnChangeTeam(Controller C)
	{
		// stub
	}
	
	public override /*function */void OnChangeRole(Controller C)
	{
		// stub
	}
	
	public override /*function */void OnSetReady(Controller C)
	{
		// stub
	}
	
	public override /*function */void OnGameStarted()
	{
		// stub
	}
	
	public override /*function */void RequestTeamChange(Controller C, int Dir)
	{
		// stub
	}
	
	public override /*function */void RequestRoleChange(Controller C, int Dir)
	{
		// stub
	}
	
	public override /*function */void RequestSetReady(Controller C)
	{
		// stub
	}
	
	public override /*function */bool AllPlayersReady()
	{
		// stub
		return default;
	}
	
	public override /*function */void StartGame(String MapName, String GameMode)
	{
		// stub
	}
	
	public TdLobbyListenServerBackend()
	{
		// Object Offset:0x0058BEC0
		ResourceDataStoreName = (name)"TdGameData";
		SettingsDataStoreName = (name)"TdMPGameSettings";
		TickTrigger = 0.50f;
	}
}
}