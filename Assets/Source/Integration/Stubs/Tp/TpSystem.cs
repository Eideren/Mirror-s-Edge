namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpSystem : TpSystemBase/*
		transient*/{
	[transient] public/*private*/ TpConnection Connection;
	[transient] public/*private*/ TpAssociationManager AssociationManager;
	[transient] public/*private*/ TpPresenceManager PresenceManager;
	[transient] public/*private*/ TpUserManager UserManager;
	[transient] public/*private*/ TpGameBrowser GameBrowser;
	[transient] public/*private*/ TpGameManager GameManager;
	[transient] public/*private*/ TpMessageService MessageService;
	[transient] public/*private*/ TpPlayGroupManager PlayGroupManager;
	[transient] public/*private*/ TpAchievementManager AchievementManager;
	[transient] public/*private*/ TpRankingService RankingService;
	[transient] public/*private*/ TpFileLockerService FileLockerService;
	[transient] public/*private*/ TpProtoHTTP ProtoHTTP;
	[transient] public/*private*/ TpUoSystem UoSystem;
	[transient] public/*private*/ TpUoPlayer UoPlayer;
	[transient] public/*private*/ TpUoGame UoGame;
	[transient] public/*private*/ TpUoPlayGroup UoPlayGroup;
	[transient] public/*private*/ TpUoPlayerEx UoPlayerEx;
	[transient] public/*private*/ TpUoStats UoStats;
	[transient] public/*private*/ TpUoFileLocker UoFileLocker;
	[transient] public/*private*/ TsSystem SaveSystem;
	
	public override /*simulated event */bool Init()
	{
		// stub
		return default;
	}
	
	
	protected /*simulated event */TpConnection TpSystem___SharedBase_GetConnection()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpAchievementManager TpSystem___SharedBase_GetAchievementManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpProtoHTTP TpSystem___SharedBase_GetProtoHTTP()// state function
	{
		// stub
		return default;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) __SharedBase()/*simulated state __SharedBase*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void TpSystem___Disconnected_BeginState(name InPrevious)// state function
	{
		// stub
	}
	
	protected /*protected simulated event */void TpSystem___Disconnected_ImpelConnected()// state function
	{
		// stub
	}
	
	protected /*simulated event */TpAssociationManager TpSystem___Disconnected_GetAssociationManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpMessageService TpSystem___Disconnected_GetMessageService()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpPresenceManager TpSystem___Disconnected_GetPresenceManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpUserManager TpSystem___Disconnected_GetUserManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpPlayGroupManager TpSystem___Disconnected_GetPlayGroupManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpRankingService TpSystem___Disconnected_GetRankingService()// state function
	{
		// stub
		return default;
	}
	
	protected /*protected simulated event */void TpSystem___Disconnected_ProcessTick(float DeltaSeconds)// state function
	{
		// stub
	}
	
	protected /*simulated event */TpFileLockerService TpSystem___Disconnected_GetFileLockerService()// state function
	{
		// stub
		return default;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) __Disconnected()/*simulated state __Disconnected extends __SharedBase*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*protected simulated event */void TpSystem___ConnectedShared_ImpelDisconnected()// state function
	{
		// stub
	}
	
	protected /*simulated event */TpPresenceManager TpSystem___ConnectedShared_GetPresenceManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpUserManager TpSystem___ConnectedShared_GetUserManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*protected simulated event */void TpSystem___ConnectedShared_ProcessTick(float DeltaSeconds)// state function
	{
		// stub
	}
	
	protected /*simulated event */TpPlayGroupManager TpSystem___ConnectedShared_GetPlayGroupManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpRankingService TpSystem___ConnectedShared_GetRankingService()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpAssociationManager TpSystem___ConnectedShared_GetAssociationManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpMessageService TpSystem___ConnectedShared_GetMessageService()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpFileLockerService TpSystem___ConnectedShared_GetFileLockerService()// state function
	{
		// stub
		return default;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) __ConnectedShared()/*simulated state __ConnectedShared extends __SharedBase*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */void TpSystem___Connected_PushedState()// state function
	{
		// stub
	}
	
	protected /*simulated event */void TpSystem___Connected_PoppedState()// state function
	{
		// stub
	}
	
	protected /*simulated event */TpGameBrowser TpSystem___Connected_GetGameBrowser()// state function
	{
		// stub
		return default;
	}
	
	protected /*simulated event */TpGameManager TpSystem___Connected_GetGameManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*protected simulated event */void TpSystem___Connected_ImpelGameCreated()// state function
	{
		// stub
	}
	
	protected /*protected simulated event */void TpSystem___Connected_ImpelGameJoined()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) __Connected()/*simulated state __Connected extends __ConnectedShared*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */TpGameManager TpSystem___HostingGameShared_GetGameManager()// state function
	{
		// stub
		return default;
	}
	
	protected /*protected simulated event */void TpSystem___HostingGameShared_ImpelGameDestroyed()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) __HostingGameShared()/*simulated state __HostingGameShared extends __ConnectedShared*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	(System.Action<name>, StateFlow, System.Action<name>) __WaitForPlayers()/*simulated state __WaitForPlayers extends __HostingGameShared*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	(System.Action<name>, StateFlow, System.Action<name>) __WaitGameStart()/*simulated state __WaitGameStart extends __ConnectedShared*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "__SharedBase": return __SharedBase();
			case "__Disconnected": return __Disconnected();
			case "__ConnectedShared": return __ConnectedShared();
			case "__Connected": return __Connected();
			case "__HostingGameShared": return __HostingGameShared();
			case "__WaitForPlayers": return __WaitForPlayers();
			case "__WaitGameStart": return __WaitGameStart();
			default: return base.FindState(stateName);
		}
	}
}
}