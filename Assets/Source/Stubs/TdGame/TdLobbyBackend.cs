namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLobbyBackend : Object/*
		abstract
		native*/{
	public /*protected transient */TdLobbyEventListener Listener;
	
	public virtual /*function */void SetListener(TdLobbyEventListener InListener)
	{
	
	}
	
	public virtual /*function */void Update()
	{
	
	}
	
	public virtual /*function */void Cleanup()
	{
	
	}
	
	public virtual /*function */void OnPlayerLogin(Controller C)
	{
	
	}
	
	public virtual /*function */void OnPlayerLogout(Controller C)
	{
	
	}
	
	public virtual /*function */void OnChangeTeam(Controller C)
	{
	
	}
	
	public virtual /*function */void OnChangeRole(Controller C)
	{
	
	}
	
	public virtual /*function */void OnSetReady(Controller C)
	{
	
	}
	
	public virtual /*function */void OnGameStarted()
	{
	
	}
	
	public virtual /*function */void RequestTeamChange(Controller C, int Dir)
	{
	
	}
	
	public virtual /*function */void RequestRoleChange(Controller C, int Dir)
	{
	
	}
	
	public virtual /*function */void RequestSetReady(Controller C)
	{
	
	}
	
	public virtual /*function */bool AllPlayersReady()
	{
	
		return default;
	}
	
	public virtual /*function */void StartGame(string MapName, string GameMode)
	{
	
	}
	
}
}