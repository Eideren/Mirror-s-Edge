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
	
	}
	
	public override /*simulated function */void Cleanup()
	{
	
	}
	
	public override /*simulated function */void Update()
	{
	
	}
	
	public virtual /*function */TdLobbyGameInfo.LobbyPlayerStruct InitPlayerData(PlayerReplicationInfo PRI)
	{
	
		return default;
	}
	
	public override /*function */void OnPlayerLogin(Controller C)
	{
	
	}
	
	public override /*function */void OnPlayerLogout(Controller C)
	{
	
	}
	
	public override /*function */void OnChangeTeam(Controller C)
	{
	
	}
	
	public override /*function */void OnChangeRole(Controller C)
	{
	
	}
	
	public override /*function */void OnSetReady(Controller C)
	{
	
	}
	
	public override /*function */void OnGameStarted()
	{
	
	}
	
	public override /*function */void RequestTeamChange(Controller C, int Dir)
	{
	
	}
	
	public override /*function */void RequestRoleChange(Controller C, int Dir)
	{
	
	}
	
	public override /*function */void RequestSetReady(Controller C)
	{
	
	}
	
	public override /*function */bool AllPlayersReady()
	{
	
		return default;
	}
	
	public override /*function */void StartGame(String MapName, String GameMode)
	{
	
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