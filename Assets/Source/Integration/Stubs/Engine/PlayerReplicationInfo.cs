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
	
	[databinding] public float Score;
	[databinding] public float Deaths;
	public byte Ping;
	public byte PacketLoss;
	public Actor PlayerLocationHint;
	[databinding] public int NumLives;
	[repnotify, databinding] public String PlayerName;
	[repnotify, databinding] public String PlayerAlias;
	public String OldName;
	public int PlayerId;
	[repnotify] public TeamInfo Team;
	public int TeamId;
	[databinding] public bool bAdmin;
	[databinding] public bool bIsFemale;
	[databinding] public bool bIsSpectator;
	[databinding] public bool bOnlySpectator;
	[databinding] public bool bWaitingPlayer;
	[databinding] public bool bReadyToPlay;
	[databinding] public bool bOutOfLives;
	[databinding] public bool bBot;
	[databinding] public bool bHasFlag;
	[databinding] public bool bHasBeenWelcomed;
	[repnotify] public bool bIsInactive;
	public bool bFromPreviousLevel;
	public bool bControllerVibrationAllowed;
	public int StartTime;
	[Const, localized] public String StringDead;
	[Const, localized] public String StringSpectating;
	[Const, localized] public String StringUnknown;
	[databinding] public int Kills;
	public Core.ClassT<GameMessage> GameMessageClass;
	public float ExactPing;
	public String SavedNetworkAddress;
	[repnotify] public OnlineSubsystem.UniqueNetId UniqueId;
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
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UPlayerReplicationInfo::execGetPlayerAlias(FFrame&, void* const)
	public virtual /*native function */String GetPlayerAlias()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*simulated event */void eventPostBeginPlay()
	{
		// stub
	}
	
	public virtual /*simulated function */void ClientInitialize(Controller C)
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	// Export UPlayerReplicationInfo::execUpdatePing(FFrame&, void* const)
	public virtual /*native final function */void UpdatePing(float TimeStamp)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*simulated function */bool ShouldBroadCastWelcomeMessage()
	{
		// stub
		return default;
	}
	
	public override /*simulated event */void Destroyed()
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? PlayerReplicationInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => PlayerReplicationInfo_Reset;
	public /*function */void PlayerReplicationInfo_Reset()
	{
		// stub
	}
	
	public override /*simulated function */String GetHumanReadableName()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */String GetLocationName()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void UpdatePlayerLocation()
	{
		// stub
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float YL, ref float YPos)
	{
		// stub
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? PlayerReplicationInfo_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => PlayerReplicationInfo_Timer;
	public /*event */void PlayerReplicationInfo_Timer()
	{
		// stub
	}
	
	public virtual /*event */void SetPlayerName(String S)
	{
		// stub
	}
	
	public virtual /*function */void SetWaitingPlayer(bool B)
	{
		// stub
	}
	
	public virtual /*function */PlayerReplicationInfo Duplicate()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OverrideWith(PlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*function */void CopyProperties(PlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*function */void SeamlessTravelTo(PlayerReplicationInfo NewPRI)
	{
		// stub
	}
	
	public virtual /*simulated function */void BindPlayerOwnerDataProvider()
	{
		// stub
	}
	
	public virtual /*simulated function */bool IsLocalPlayerPRI()
	{
		// stub
		return default;
	}
	
	// Export UPlayerReplicationInfo::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool IsInvalidName()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetPlayerAlias(String NewAlias)
	{
		// stub
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