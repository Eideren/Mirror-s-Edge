namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdLobbyEventListener : Interface/*
		abstract*/{
	public /*function */void UpdatePlayers(array<PlayerReplicationInfo> pris);
	
	public /*function */void OnPlayerJoin(Controller Player);
	
	public /*function */void OnPlayerLeave(Controller Player);
	
	public /*function */void OnPlayerSwitchTeam(Controller Player);
	
	public /*function */void OnPlayerSwitchRole(Controller Player);
	
	public /*function */void OnPlayerSetReady(Controller Player);
	
	public /*function */void OnGameStarted();
	
}
}