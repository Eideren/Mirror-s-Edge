namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameReplicationInfo : GameReplicationInfo/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public int ServerVersion;
	public /*private repnotify */byte LobbyUpdate;
	public TdLobbyBackend LobbyBackend;
	public bool bLobbyFinalized;
	public bool bMatchIsInWarmup;
	public int RoundCount;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bMatchIsInWarmup;
	//
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		LobbyUpdate, RoundCount;
	//}
	
	public virtual /*simulated function */bool IsBagGame()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*reliable server function */int ServerGetVersion()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */bool AllowViewTargetSwitching()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCarryObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
		// stub
	}
	
	public virtual /*function */void OnDropCarriedObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
		// stub
	}
	
	public virtual /*function */void OnRespawnCarriedObject(Actor CarriedActor)
	{
		// stub
	}
	
	public virtual /*function */void OnCarriedObjectTouchedGround(Actor CarriedActor)
	{
		// stub
	}
	
	public virtual /*function */void OnStartMatchInProgress(Object GameRules)
	{
		// stub
	}
	
	public virtual /*function */void OnEndMatchInProgress(Object GameRules)
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*function */void ForceLobbyUpdate()
	{
		// stub
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? TdGameReplicationInfo_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => TdGameReplicationInfo_Timer;
	public /*simulated event */void TdGameReplicationInfo_Timer()
	{
		// stub
	}
	
	public virtual /*reliable server function */bool AllPlayersReady()
	{
		// stub
		return default;
	}
	
	public virtual /*reliable server function */void StartGame(String URL)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Timer = null;
	
	}
	public TdGameReplicationInfo()
	{
		// Object Offset:0x0050A770
		ServerVersion = 1;
	}
}
}