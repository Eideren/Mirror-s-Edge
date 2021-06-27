namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoGame : TpSystemHandler, 
		OnlineGameInterface/*
		transient*/{
	public /*private transient */OnlineGameSearch GameSearch;
	public /*private transient */OnlineSubsystem.EOnlineGameState GameState;
	public /*private */array< /*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete > __OnCreateOnlineGameComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete > __OnDestroyOnlineGameComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete > __OnFindOnlineGamesComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete > __OnJoinOnlineGameComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnRegisterPlayerComplete > __OnRegisterPlayerComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete > __OnUnregisterPlayerComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnStartOnlineGameComplete > __OnStartOnlineGameComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnEndOnlineGameComplete > __OnEndOnlineGameComplete__Multicaster;
	public /*private */array< /*delegate*/OnlineGameInterface.OnGameInviteAccepted > __OnGameInviteAccepted__Multicaster;
	public /*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete __OnCreateOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete __OnDestroyOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete __OnFindOnlineGamesComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete __OnCancelFindOnlineGamesComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete __OnJoinOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnRegisterPlayerComplete __OnRegisterPlayerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete __OnUnregisterPlayerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnStartOnlineGameComplete __OnStartOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnEndOnlineGameComplete __OnEndOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete __OnArbitrationRegistrationComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnGameInviteAccepted __OnGameInviteAccepted__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	public virtual /*simulated function */bool CreateOnlineGame(byte HostingPlayerNum, OnlineGameSettings NewGameSettings)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnCreateOnlineGameComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnCreateOnlineGameComplete_Add(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnCreateOnlineGameComplete_Remove(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddCreateOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete CreateOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearCreateOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete CreateOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool UpdateOnlineGame(OnlineGameSettings UpdatedGameSettings)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */OnlineGameSettings GetGameSettings()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool DestroyOnlineGame()
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnDestroyOnlineGameComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnDestroyOnlineGameComplete_Add(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnDestroyOnlineGameComplete_Remove(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddDestroyOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete DestroyOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearDestroyOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete DestroyOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool FindOnlineGames(byte SearchingPlayerNum, OnlineGameSearch SearchSettings)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnFindOnlineGamesComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnFindOnlineGamesComplete_Add(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnFindOnlineGamesComplete_Remove(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete FindOnlineGamesCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete FindOnlineGamesCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool CancelFindOnlineGames()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddCancelFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete CancelFindOnlineGamesCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */OnlineGameSearch GetGameSearch()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ClearCancelFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete CancelFindOnlineGamesCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool FreeSearchResults(/*optional */OnlineGameSearch? _Search = default)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool JoinOnlineGame(byte PlayerNum, /*const */ref OnlineGameSearch.OnlineGameSearchResult DesiredGame)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnJoinOnlineGameComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnJoinOnlineGameComplete_Add(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnJoinOnlineGameComplete_Remove(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddJoinOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete JoinOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearJoinOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete JoinOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool GetResolvedConnectString(ref String ConnectInfo)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool RegisterPlayer(OnlineSubsystem.UniqueNetId PlayerId, bool bWasInvited)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnRegisterPlayerComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnRegisterPlayerComplete_Add(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnRegisterPlayerComplete_Remove(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddRegisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete RegisterPlayerCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearRegisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete RegisterPlayerCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool UnregisterPlayer(OnlineSubsystem.UniqueNetId PlayerId)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnUnregisterPlayerComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnUnregisterPlayerComplete_Add(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnUnregisterPlayerComplete_Remove(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddUnregisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete UnregisterPlayerCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearUnregisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete UnregisterPlayerCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool StartOnlineGame()
	{
		// stub
		return default;
	}
	
	public virtual /*private final simulated function */void OnStartOnlineGame(bool bOk)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnStartOnlineGameComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnStartOnlineGameComplete_Add(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnStartOnlineGameComplete_Remove(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddStartOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete StartOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearStartOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete StartOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */bool EndOnlineGame()
	{
		// stub
		return default;
	}
	
	public virtual /*private final simulated function */void OnEndOnlineGame(bool bOk)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnEndOnlineGameComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnEndOnlineGameComplete_Add(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnEndOnlineGameComplete_Remove(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete D)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddEndOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete EndOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearEndOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete EndOnlineGameCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */OnlineSubsystem.EOnlineGameState GetOnlineGameState()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool RegisterForArbitration()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddArbitrationRegistrationCompleteDelegate(/*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete ArbitrationRegistrationCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearArbitrationRegistrationCompleteDelegate(/*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete ArbitrationRegistrationCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */array<OnlineSubsystem.OnlineArbitrationRegistrant> GetArbitratedPlayers()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void AddGameInviteAcceptedDelegate(byte LocalUserNum, /*delegate*/OnlineGameInterface.OnGameInviteAccepted GameInviteAcceptedDelegate)
	{
		// stub
	}
	
	public virtual /*simulated function */void ClearGameInviteAcceptedDelegate(byte LocalUserNum, /*delegate*/OnlineGameInterface.OnGameInviteAccepted GameInviteAcceptedDelegate)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnGameInviteAccepted_Invoke(OnlineGameSettings GameInviteSettings)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnGameInviteAccepted_Add(/*delegate*/OnlineGameInterface.OnGameInviteAccepted D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnGameInviteAccepted_Remove(/*delegate*/OnlineGameInterface.OnGameInviteAccepted D)
	{
		// stub
	}
	
	public virtual /*simulated function */bool AcceptGameInvite(byte LocalUserNum)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool RecalculateSkillRating(/*const */ref array<OnlineSubsystem.UniqueNetId> Players)
	{
		// stub
		return default;
	}
	
}
}