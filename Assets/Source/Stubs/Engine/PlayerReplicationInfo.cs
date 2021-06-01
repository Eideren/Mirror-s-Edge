namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerReplicationInfo : ReplicationInfo/*
		native
		nativereplication
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct /*native */AutomatedTestingDatum
	{
		public int NumberOfMatchesPlayed;
		public int NumMapListCyclesDone;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0039FD4B
	//		NumberOfMatchesPlayed = 0;
	//		NumMapListCyclesDone = 0;
	//	}
	};
	
	public /*databinding */float Score;
	public /*databinding */float Deaths;
	public byte Ping;
	public byte PacketLoss;
	public Actor PlayerLocationHint;
	public /*databinding */int NumLives;
	public /*repnotify databinding */String PlayerName;
	public /*repnotify databinding */String PlayerAlias;
	public String OldName;
	public int PlayerId;
	public /*repnotify */TeamInfo Team;
	public int TeamId;
	public /*databinding */bool bAdmin;
	public /*databinding */bool bIsFemale;
	public /*databinding */bool bIsSpectator;
	public /*databinding */bool bOnlySpectator;
	public /*databinding */bool bWaitingPlayer;
	public /*databinding */bool bReadyToPlay;
	public /*databinding */bool bOutOfLives;
	public /*databinding */bool bBot;
	public /*databinding */bool bHasFlag;
	public /*databinding */bool bHasBeenWelcomed;
	public /*repnotify */bool bIsInactive;
	public bool bFromPreviousLevel;
	public bool bControllerVibrationAllowed;
	public int StartTime;
	public /*const localized */String StringDead;
	public /*const localized */String StringSpectating;
	public /*const localized */String StringUnknown;
	public /*databinding */int Kills;
	public Core.ClassT<GameMessage> GameMessageClass;
	public float ExactPing;
	public String SavedNetworkAddress;
	public /*repnotify */OnlineSubsystem.UniqueNetId UniqueId;
	public PlayerReplicationInfo.AutomatedTestingDatum AutomatedTestingData;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Deaths, PlayerAlias, 
	//		PlayerLocationHint, PlayerName, 
	//		Score, StartTime, 
	//		Team, TeamId, 
	//		UniqueId, bAdmin, 
	//		bControllerVibrationAllowed, bHasFlag, 
	//		bIsFemale, bIsSpectator, 
	//		bOnlySpectator, bOutOfLives, 
	//		bReadyToPlay, bWaitingPlayer;
	//
	//	 if((bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && !bNetOwner)
	//		PacketLoss, Ping;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		PlayerId, bBot, 
	//		bIsInactive;
	//}
	
	// Export UPlayerReplicationInfo::execAreUniqueNetIdsEqual(FFrame&, void* const)
	public virtual /*native final function */bool AreUniqueNetIdsEqual(PlayerReplicationInfo OtherPRI)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerReplicationInfo::execGetPlayerAlias(FFrame&, void* const)
	public virtual /*native function */String GetPlayerAlias()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*simulated function */void ClientInitialize(Controller C)
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	// Export UPlayerReplicationInfo::execUpdatePing(FFrame&, void* const)
	public virtual /*native final function */void UpdatePing(float TimeStamp)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */bool ShouldBroadCastWelcomeMessage()
	{
	
		return default;
	}
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? PlayerReplicationInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => PlayerReplicationInfo_Reset;
	public /*function */void PlayerReplicationInfo_Reset()
	{
	
	}
	
	public override /*simulated function */String GetHumanReadableName()
	{
	
		return default;
	}
	
	public virtual /*simulated function */String GetLocationName()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdatePlayerLocation()
	{
	
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float YL, ref float YPos)
	{
	
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? PlayerReplicationInfo_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => PlayerReplicationInfo_Timer;
	public /*event */void PlayerReplicationInfo_Timer()
	{
	
	}
	
	public virtual /*event */void SetPlayerName(String S)
	{
	
	}
	
	public virtual /*function */void SetWaitingPlayer(bool B)
	{
	
	}
	
	public virtual /*function */PlayerReplicationInfo Duplicate()
	{
	
		return default;
	}
	
	public virtual /*function */void OverrideWith(PlayerReplicationInfo PRI)
	{
	
	}
	
	public virtual /*function */void CopyProperties(PlayerReplicationInfo PRI)
	{
	
	}
	
	public virtual /*function */void SeamlessTravelTo(PlayerReplicationInfo NewPRI)
	{
	
	}
	
	public virtual /*simulated function */void BindPlayerOwnerDataProvider()
	{
	
	}
	
	public virtual /*simulated function */bool IsLocalPlayerPRI()
	{
	
		return default;
	}
	
	// Export UPlayerReplicationInfo::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */bool IsInvalidName()
	{
	
		return default;
	}
	
	public virtual /*function */void SetPlayerAlias(String NewAlias)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Timer = null;
	
	}
	public PlayerReplicationInfo()
	{
		// Object Offset:0x003A1BAB
		bControllerVibrationAllowed = true;
		StringDead = "Dead";
		StringSpectating = "Spectating";
		StringUnknown = "Unknown";
		GameMessageClass = ClassT<GameMessage>()/*Ref Class'GameMessage'*/;
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
		NetUpdateFrequency = 1.0f;
	}
}
}