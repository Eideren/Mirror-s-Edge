namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineGameInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete __OnCreateOnlineGameComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete __OnDestroyOnlineGameComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete __OnFindOnlineGamesComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete __OnCancelFindOnlineGamesComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete __OnJoinOnlineGameComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnRegisterPlayerComplete __OnRegisterPlayerComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete __OnUnregisterPlayerComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnStartOnlineGameComplete __OnStartOnlineGameComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnEndOnlineGameComplete __OnEndOnlineGameComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete __OnArbitrationRegistrationComplete__Delegate{ get; }
	public /*delegate*/OnlineGameInterface.OnGameInviteAccepted __OnGameInviteAccepted__Delegate{ get; }
	
	public /*function */bool CreateOnlineGame(byte HostingPlayerNum, OnlineGameSettings NewGameSettings);
	
	public delegate void OnCreateOnlineGameComplete(bool bWasSuccessful);
	
	public /*function */void AddCreateOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete CreateOnlineGameCompleteDelegate);
	
	public /*function */void ClearCreateOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete CreateOnlineGameCompleteDelegate);
	
	public /*function */bool UpdateOnlineGame(OnlineGameSettings UpdatedGameSettings);
	
	public /*function */OnlineGameSettings GetGameSettings();
	
	public /*function */bool DestroyOnlineGame();
	
	public delegate void OnDestroyOnlineGameComplete(bool bWasSuccessful);
	
	public /*function */void AddDestroyOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete DestroyOnlineGameCompleteDelegate);
	
	public /*function */void ClearDestroyOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete DestroyOnlineGameCompleteDelegate);
	
	public /*function */bool FindOnlineGames(byte SearchingPlayerNum, OnlineGameSearch SearchSettings);
	
	public delegate void OnFindOnlineGamesComplete(bool bWasSuccessful);
	
	public /*function */void AddFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete FindOnlineGamesCompleteDelegate);
	
	public /*function */void ClearFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete FindOnlineGamesCompleteDelegate);
	
	public /*function */bool CancelFindOnlineGames();
	
	public delegate void OnCancelFindOnlineGamesComplete(bool bWasSuccessful);
	
	public /*function */void AddCancelFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete CancelFindOnlineGamesCompleteDelegate);
	
	public /*function */void ClearCancelFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete CancelFindOnlineGamesCompleteDelegate);
	
	public /*function */OnlineGameSearch GetGameSearch();
	
	public /*function */bool FreeSearchResults(/*optional */OnlineGameSearch Search = default);
	
	public /*function */bool JoinOnlineGame(byte PlayerNum, /*const */ref OnlineGameSearch.OnlineGameSearchResult DesiredGame);
	
	public delegate void OnJoinOnlineGameComplete(bool bWasSuccessful);
	
	public /*function */void AddJoinOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete JoinOnlineGameCompleteDelegate);
	
	public /*function */void ClearJoinOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete JoinOnlineGameCompleteDelegate);
	
	public /*function */bool GetResolvedConnectString(ref string ConnectInfo);
	
	public /*function */bool RegisterPlayer(OnlineSubsystem.UniqueNetId PlayerId, bool bWasInvited);
	
	public delegate void OnRegisterPlayerComplete(bool bWasSuccessful);
	
	public /*function */void AddRegisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete RegisterPlayerCompleteDelegate);
	
	public /*function */void ClearRegisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete RegisterPlayerCompleteDelegate);
	
	public /*function */bool UnregisterPlayer(OnlineSubsystem.UniqueNetId PlayerId);
	
	public delegate void OnUnregisterPlayerComplete(bool bWasSuccessful);
	
	public /*function */void AddUnregisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete UnregisterPlayerCompleteDelegate);
	
	public /*function */void ClearUnregisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete UnregisterPlayerCompleteDelegate);
	
	public /*function */bool StartOnlineGame();
	
	public delegate void OnStartOnlineGameComplete(bool bWasSuccessful);
	
	public /*function */void AddStartOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete StartOnlineGameCompleteDelegate);
	
	public /*function */void ClearStartOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete StartOnlineGameCompleteDelegate);
	
	public /*function */bool EndOnlineGame();
	
	public delegate void OnEndOnlineGameComplete(bool bWasSuccessful);
	
	public /*function */void AddEndOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete EndOnlineGameCompleteDelegate);
	
	public /*function */void ClearEndOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete EndOnlineGameCompleteDelegate);
	
	public /*function */OnlineSubsystem.EOnlineGameState GetOnlineGameState();
	
	public /*function */bool RegisterForArbitration();
	
	public delegate void OnArbitrationRegistrationComplete(bool bWasSuccessful);
	
	public /*function */void AddArbitrationRegistrationCompleteDelegate(/*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete ArbitrationRegistrationCompleteDelegate);
	
	public /*function */void ClearArbitrationRegistrationCompleteDelegate(/*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete ArbitrationRegistrationCompleteDelegate);
	
	public /*function */array<OnlineSubsystem.OnlineArbitrationRegistrant> GetArbitratedPlayers();
	
	public /*function */void AddGameInviteAcceptedDelegate(byte LocalUserNum, /*delegate*/OnlineGameInterface.OnGameInviteAccepted GameInviteAcceptedDelegate);
	
	public /*function */void ClearGameInviteAcceptedDelegate(byte LocalUserNum, /*delegate*/OnlineGameInterface.OnGameInviteAccepted GameInviteAcceptedDelegate);
	
	public delegate void OnGameInviteAccepted(OnlineGameSettings GameInviteSettings);
	
	public /*function */bool AcceptGameInvite(byte LocalUserNum);
	
	public /*function */bool RecalculateSkillRating(/*const */ref array<OnlineSubsystem.UniqueNetId> Players);
	
}
}