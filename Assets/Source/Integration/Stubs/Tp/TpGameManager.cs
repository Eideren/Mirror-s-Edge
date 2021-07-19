namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpGameManager : TpSystemHandler/*
		abstract
		transient
		native*/{
	public/*private*/ array<NetDriver> DriverArray;
	public /*delegate*/TpGameManager.OnCreateGame __OnCreateGame__Delegate;
	public /*delegate*/TpGameManager.OnDestroyGame __OnDestroyGame__Delegate;
	public /*delegate*/TpGameManager.OnStartGame __OnStartGame__Delegate;
	public /*delegate*/TpGameManager.OnEndGame __OnEndGame__Delegate;
	public /*delegate*/TpGameManager.OnJoinGame __OnJoinGame__Delegate;
	public /*delegate*/TpGameManager.OnLeaveGame __OnLeaveGame__Delegate;
	
	// Export UTpGameManager::execNewCreateGameParams(FFrame&, void* const)
	public virtual /*native simulated function */TpCreateGameParams NewCreateGameParams()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpGameManager::execCreateGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreateGameAsync(TpCreateGameParams InParams)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpGameManager::execCreatePlayNowGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreatePlayNowGameAsync(TpGameBrowser.TpPlayNowCreateGameInfo Info)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnCreateGame(bool bInOk);
	
	// Export UTpGameManager::execDestroyGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void DestroyGameAsync()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnDestroyGame(bool bInOk);
	
	// Export UTpGameManager::execStartGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void StartGameAsync()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnStartGame(bool bInOk);
	
	// Export UTpGameManager::execEndGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void EndGameAsync()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnEndGame(bool bInOk);
	
	// Export UTpGameManager::execJoinGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void JoinGameAsync(TpGameBrowser.TpLobbyRef InLobby, TpGameBrowser.TpGameRef InGame)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpGameManager::execJoinPlayNowGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void JoinPlayNowGameAsync(TpGameBrowser.TpPlayNowJoinGameInfo Info)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnJoinGame(bool bInOk, String hostIp);
	
	// Export UTpGameManager::execLeaveGameAsync(FFrame&, void* const)
	public virtual /*native simulated function */void LeaveGameAsync()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnLeaveGame();
	
	// Export UTpGameManager::execGetGameHostIp(FFrame&, void* const)
	public virtual /*native simulated function */String GetGameHostIp()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpGameManager::execDisarmConnectionPlayerControllers(FFrame&, void* const)
	public virtual /*native simulated function */void DisarmConnectionPlayerControllers()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}