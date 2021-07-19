namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLobbyBackend : Object/*
		abstract
		native*/{
	[transient] public/*protected*/ TdLobbyEventListener Listener;
	
	public virtual /*function */void SetListener(TdLobbyEventListener InListener)
	{
		// stub
	}
	
	public virtual /*function */void Update()
	{
		// stub
	}
	
	public virtual /*function */void Cleanup()
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerLogin(Controller C)
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerLogout(Controller C)
	{
		// stub
	}
	
	public virtual /*function */void OnChangeTeam(Controller C)
	{
		// stub
	}
	
	public virtual /*function */void OnChangeRole(Controller C)
	{
		// stub
	}
	
	public virtual /*function */void OnSetReady(Controller C)
	{
		// stub
	}
	
	public virtual /*function */void OnGameStarted()
	{
		// stub
	}
	
	public virtual /*function */void RequestTeamChange(Controller C, int Dir)
	{
		// stub
	}
	
	public virtual /*function */void RequestRoleChange(Controller C, int Dir)
	{
		// stub
	}
	
	public virtual /*function */void RequestSetReady(Controller C)
	{
		// stub
	}
	
	public virtual /*function */bool AllPlayersReady()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void StartGame(String MapName, String GameMode)
	{
		// stub
	}
	
}
}