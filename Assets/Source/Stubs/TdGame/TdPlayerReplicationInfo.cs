namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerReplicationInfo : PlayerReplicationInfo/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public /*private */int ClientVersion;
	public /*repnotify */int RoleIndexInTeam;
	public /*repnotify */bool bPlayerIsReady;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RoleIndexInTeam, bPlayerIsReady;
	//}
	
	public virtual /*private final simulated function */void UpdateLobbyBackend()
	{
	
	}
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public override /*simulated function */void ClientInitialize(Controller C)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSetClientVersion(int I)
	{
	
	}
	
	public virtual /*function */void OnCarryObject(Actor inActor)
	{
	
	}
	
	public virtual /*function */void OnDropCarriedObject(Actor inActor)
	{
	
	}
	
	public virtual /*function */void OnUseCarriedObject(Actor inActor)
	{
	
	}
	
	public virtual /*function */void ScorePassedCarriedObject()
	{
	
	}
	
	public virtual /*function */void ScoreInterceptedCarriedObject()
	{
	
	}
	
	public virtual /*reliable server function */void RequestTeamChange(int NewTeam)
	{
	
	}
	
	public virtual /*reliable server function */void RequestRoleChange(int NewRoleIndex)
	{
	
	}
	
	public virtual /*reliable server function */void RequestSetReady()
	{
	
	}
	
	public TdPlayerReplicationInfo()
	{
		// Object Offset:0x0050CAFA
		ClientVersion = 1;
		GameMessageClass = ClassT<TdGameMessage>()/*Ref Class'TdGameMessage'*/;
	}
}
}