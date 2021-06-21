namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameReplicationInfo : ReplicationInfo/*
		native
		nativereplication
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public Core.ClassT<GameInfo> GameClass;
	public /*private */CurrentGameDataStore CurrentGameData;
	public bool bStopCountDown;
	public /*repnotify */bool bMatchHasBegun;
	public /*repnotify */bool bMatchIsOver;
	public bool bNeedsOnlineCleanup;
	public bool bIsArbitrated;
	public bool bTrackStats;
	public /*databinding */int RemainingTime;
	public /*databinding */int ElapsedTime;
	public /*databinding */int RemainingMinute;
	public /*databinding */float SecondCount;
	public /*databinding */int GoalScore;
	public /*databinding */int TimeLimit;
	public /*databinding */int MaxLives;
	public /*databinding */array<TeamInfo> Teams;
	public/*()*/ /*databinding globalconfig */String ServerName;
	public/*()*/ /*databinding globalconfig */String ShortName;
	public/*()*/ /*databinding globalconfig */String AdminName;
	public/*()*/ /*databinding globalconfig */String AdminEmail;
	public/*()*/ /*databinding globalconfig */int ServerRegion;
	public/*()*/ /*databinding globalconfig */String MessageOfTheDay;
	public /*databinding */Actor Winner;
	public array<PlayerReplicationInfo> PRIArray;
	public array<PlayerReplicationInfo> InactivePRIArray;
	public int MatchID;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		MatchID, Winner, 
	//		bMatchHasBegun, bMatchIsOver, 
	//		bStopCountDown;
	//
	//	 if((!bNetInitial && bNetDirty) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RemainingMinute;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		AdminEmail, AdminName, 
	//		ElapsedTime, GameClass, 
	//		GoalScore, MaxLives, 
	//		MessageOfTheDay, RemainingTime, 
	//		ServerName, ServerRegion, 
	//		ShortName, TimeLimit, 
	//		bIsArbitrated, bTrackStats;
	//}
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? GameReplicationInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => GameReplicationInfo_Reset;
	public /*function */void GameReplicationInfo_Reset()
	{
		// stub
	}
	
	public override /*simulated event */void Destroyed()
	{
		// stub
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? GameReplicationInfo_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => GameReplicationInfo_Timer;
	public /*simulated event */void GameReplicationInfo_Timer()
	{
		// stub
	}
	
	// Export UGameReplicationInfo::execOnSameTeam(FFrame&, void* const)
	public virtual /*native simulated function */bool OnSameTeam(Actor A, Actor B)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*simulated function */PlayerReplicationInfo FindPlayerByID(int PlayerId)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void AddPRI(PlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*simulated function */void RemovePRI(PlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetTeam(int Index, TeamInfo TI)
	{
		// stub
	}
	
	public virtual /*simulated function */void GetPRIArray(ref array<PlayerReplicationInfo> pris)
	{
		// stub
	}
	
	public virtual /*simulated function */bool InOrder(PlayerReplicationInfo P1, PlayerReplicationInfo P2)
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void SortPRIArray()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*simulated function */void InitializeGameDataStore()
	{
		// stub
	}
	
	public virtual /*simulated function */void CleanupGameDataStore()
	{
		// stub
	}
	
	public virtual /*simulated function */void StartMatch()
	{
		// stub
	}
	
	public virtual /*simulated function */void EndGame()
	{
		// stub
	}
	
	public virtual /*simulated function */OnlineGameInterface GetOnlineGameInterface()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated event */void OnlineSession_StartMatch()
	{
		// stub
	}
	
	public virtual /*simulated event */void OnlineSession_EndMatch()
	{
		// stub
	}
	
	public virtual /*simulated event */void OnlineSession_EndSession(bool bForced)
	{
		// stub
	}
	
	public virtual /*simulated function */bool IsMultiplayerGame()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool AllowViewTargetSwitching()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool IsCoopMultiplayerGame()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool PreventPause()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool ShouldShowGore()
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Timer = null;
	
	}
	public GameReplicationInfo()
	{
		// Object Offset:0x00334224
		bStopCountDown = true;
		ServerName = "Mirror's Edge Server";
		ShortName = "ME Server";
		MessageOfTheDay = "Welcome to Mirror's Edge!";
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}