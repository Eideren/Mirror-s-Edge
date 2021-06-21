namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpGameManager : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*private */array<NetDriver> DriverArray;
	public /*delegate*/TpGameManager.OnCreateGame __OnCreateGame__Delegate;
	public /*delegate*/TpGameManager.OnDestroyGame __OnDestroyGame__Delegate;
	public /*delegate*/TpGameManager.OnStartGame __OnStartGame__Delegate;
	public /*delegate*/TpGameManager.OnEndGame __OnEndGame__Delegate;
	public /*delegate*/TpGameManager.OnJoinGame __OnJoinGame__Delegate;
	public /*delegate*/TpGameManager.OnLeaveGame __OnLeaveGame__Delegate;
	
	// Export UTpGameManager::execNewCreateGameParams(FFrame&, void* const)
	public virtual /*native simulated function */TpCreateGameParams NewCreateGameParams()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTpGameManager::execCreateGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreateGameAsync(TpCreateGameParams InParams)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpGameManager::execCreatePlayNowGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreatePlayNowGameAsync(TpGameBrowser.TpPlayNowCreateGameInfo Info)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnCreateGame(bool bInOk);
	
	// Export UTpGameManager::execDestroyGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void DestroyGameAsync()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnDestroyGame(bool bInOk);
	
	// Export UTpGameManager::execStartGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void StartGameAsync()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnStartGame(bool bInOk);
	
	// Export UTpGameManager::execEndGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void EndGameAsync()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnEndGame(bool bInOk);
	
	// Export UTpGameManager::execJoinGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void JoinGameAsync(TpGameBrowser.TpLobbyRef InLobby, TpGameBrowser.TpGameRef InGame)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpGameManager::execJoinPlayNowGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void JoinPlayNowGameAsync(TpGameBrowser.TpPlayNowJoinGameInfo Info)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnJoinGame(bool bInOk, String hostIp);
	
	// Export UTpGameManager::execLeaveGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void LeaveGameAsync()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnLeaveGame();
	
	// Export UTpGameManager::execGetGameHostIp(FFrame&, void* const)
	public virtual /*native simulated function */String GetGameHostIp()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTpGameManager::execDisarmConnectionPlayerControllers(FFrame&, void* const)
	public virtual /*native simulated function */void DisarmConnectionPlayerControllers()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
}
}