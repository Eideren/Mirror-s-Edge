namespace MEdge.IpDrv{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineGameInterfaceImpl : Object, 
		OnlineGameInterface/* within OnlineSubsystemCommonImpl*//*
		native
		config(Engine)*/{
	public new OnlineSubsystemCommonImpl Outer => base.Outer as OnlineSubsystemCommonImpl;
	
	public OnlineSubsystemCommonImpl OwningSubsystem;
	public /*const */OnlineGameSettings GameSettings;
	public /*const */OnlineGameSearch GameSearch;
	public /*const */OnlineSubsystem.EOnlineGameState CurrentGameState;
	public /*const */OnlineSubsystem.ELanBeaconState LanBeaconState;
	public /*const */StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ LanNonce;
	public array< /*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete > CreateOnlineGameCompleteDelegates;
	public array< /*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete > DestroyOnlineGameCompleteDelegates;
	public array< /*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete > JoinOnlineGameCompleteDelegates;
	public array< /*delegate*/OnlineGameInterface.OnStartOnlineGameComplete > StartOnlineGameCompleteDelegates;
	public array< /*delegate*/OnlineGameInterface.OnEndOnlineGameComplete > EndOnlineGameCompleteDelegates;
	public array< /*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete > FindOnlineGamesCompleteDelegates;
	public array< /*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete > CancelFindOnlineGamesCompleteDelegates;
	public /*const config */int LanAnnouncePort;
	public /*const config */int LanGameUniqueId;
	public /*const config */int LanPacketPlatformMask;
	public float LanQueryTimeLeft;
	public /*config */float LanQueryTimeout;
	public /*native const transient */Object.Pointer LanBeacon;
	public /*private native const transient */Object.Pointer SessionInfo;
	public /*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete __OnFindOnlineGamesComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete __OnCreateOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete __OnDestroyOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete __OnCancelFindOnlineGamesComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete __OnJoinOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnRegisterPlayerComplete __OnRegisterPlayerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete __OnUnregisterPlayerComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnStartOnlineGameComplete __OnStartOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnEndOnlineGameComplete __OnEndOnlineGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete __OnArbitrationRegistrationComplete__Delegate{ get; set; }
	public /*delegate*/OnlineGameInterface.OnGameInviteAccepted __OnGameInviteAccepted__Delegate{ get; set; }
	
	public virtual /*function */OnlineSubsystem.EOnlineGameState GetOnlineGameState()
	{
	
		return default;
	}
	
	public virtual /*function */OnlineGameSettings GetGameSettings()
	{
	
		return default;
	}
	
	public virtual /*function */OnlineGameSearch GetGameSearch()
	{
	
		return default;
	}
	
	// Export UOnlineGameInterfaceImpl::execCreateOnlineGame(FFrame&, void* const)
	public virtual /*native function */bool CreateOnlineGame(byte HostingPlayerNum, OnlineGameSettings NewGameSettings)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddCreateOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete CreateOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearCreateOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnCreateOnlineGameComplete CreateOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */bool UpdateOnlineGame(OnlineGameSettings UpdatedGameSettings)
	{
	
		return default;
	}
	
	// Export UOnlineGameInterfaceImpl::execDestroyOnlineGame(FFrame&, void* const)
	public virtual /*native function */bool DestroyOnlineGame()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddDestroyOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete DestroyOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearDestroyOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnDestroyOnlineGameComplete DestroyOnlineGameCompleteDelegate)
	{
	
	}
	
	// Export UOnlineGameInterfaceImpl::execFindOnlineGames(FFrame&, void* const)
	public virtual /*native function */bool FindOnlineGames(byte SearchingPlayerNum, OnlineGameSearch SearchSettings)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete FindOnlineGamesCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnFindOnlineGamesComplete FindOnlineGamesCompleteDelegate)
	{
	
	}
	
	// Export UOnlineGameInterfaceImpl::execCancelFindOnlineGames(FFrame&, void* const)
	public virtual /*native function */bool CancelFindOnlineGames()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddCancelFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete CancelFindOnlineGamesCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearCancelFindOnlineGamesCompleteDelegate(/*delegate*/OnlineGameInterface.OnCancelFindOnlineGamesComplete CancelFindOnlineGamesCompleteDelegate)
	{
	
	}
	
	// Export UOnlineGameInterfaceImpl::execFreeSearchResults(FFrame&, void* const)
	public virtual /*native function */bool FreeSearchResults(OnlineGameSearch Search)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UOnlineGameInterfaceImpl::execJoinOnlineGame(FFrame&, void* const)
	public virtual /*native function */bool JoinOnlineGame(byte PlayerNum, /*const */ref OnlineGameSearch.OnlineGameSearchResult DesiredGame)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddJoinOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete JoinOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearJoinOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnJoinOnlineGameComplete JoinOnlineGameCompleteDelegate)
	{
	
	}
	
	// Export UOnlineGameInterfaceImpl::execGetResolvedConnectString(FFrame&, void* const)
	public virtual /*native function */bool GetResolvedConnectString(ref string ConnectInfo)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool RegisterPlayer(OnlineSubsystem.UniqueNetId PlayerId, bool bWasInvited)
	{
	
		return default;
	}
	
	public virtual /*function */void AddRegisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete RegisterPlayerCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearRegisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnRegisterPlayerComplete RegisterPlayerCompleteDelegate)
	{
	
	}
	
	public virtual /*function */bool UnregisterPlayer(OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	public virtual /*function */void AddUnregisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete UnregisterPlayerCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearUnregisterPlayerCompleteDelegate(/*delegate*/OnlineGameInterface.OnUnregisterPlayerComplete UnregisterPlayerCompleteDelegate)
	{
	
	}
	
	// Export UOnlineGameInterfaceImpl::execStartOnlineGame(FFrame&, void* const)
	public virtual /*native function */bool StartOnlineGame()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddStartOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete StartOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearStartOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnStartOnlineGameComplete StartOnlineGameCompleteDelegate)
	{
	
	}
	
	// Export UOnlineGameInterfaceImpl::execEndOnlineGame(FFrame&, void* const)
	public virtual /*native function */bool EndOnlineGame()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddEndOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete EndOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearEndOnlineGameCompleteDelegate(/*delegate*/OnlineGameInterface.OnEndOnlineGameComplete EndOnlineGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */bool RegisterForArbitration()
	{
	
		return default;
	}
	
	public virtual /*function */void AddArbitrationRegistrationCompleteDelegate(/*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete ArbitrationRegistrationCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearArbitrationRegistrationCompleteDelegate(/*delegate*/OnlineGameInterface.OnArbitrationRegistrationComplete ArbitrationRegistrationCompleteDelegate)
	{
	
	}
	
	public virtual /*function */array<OnlineSubsystem.OnlineArbitrationRegistrant> GetArbitratedPlayers()
	{
	
		return default;
	}
	
	public virtual /*function */void AddGameInviteAcceptedDelegate(byte LocalUserNum, /*delegate*/OnlineGameInterface.OnGameInviteAccepted GameInviteAcceptedDelegate)
	{
	
	}
	
	public virtual /*function */void ClearGameInviteAcceptedDelegate(byte LocalUserNum, /*delegate*/OnlineGameInterface.OnGameInviteAccepted GameInviteAcceptedDelegate)
	{
	
	}
	
	public virtual /*function */bool AcceptGameInvite(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*function */bool RecalculateSkillRating(/*const */ref array<OnlineSubsystem.UniqueNetId> Players)
	{
	
		return default;
	}
	
	public OnlineGameInterfaceImpl()
	{
		// Object Offset:0x00007365
		LanAnnouncePort = 14001;
		LanQueryTimeout = 5.0f;
	}
}
}