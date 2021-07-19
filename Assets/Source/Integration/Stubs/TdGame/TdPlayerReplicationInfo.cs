namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerReplicationInfo : PlayerReplicationInfo/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public/*private*/ int ClientVersion;
	[repnotify] public int RoleIndexInTeam;
	[repnotify] public bool bPlayerIsReady;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RoleIndexInTeam, bPlayerIsReady;
	//}
	
	public virtual /*private final simulated function */void UpdateLobbyBackend()
	{
		// stub
	}
	
	public override /*simulated event */void Destroyed()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public override /*simulated function */void ClientInitialize(Controller C)
	{
		// stub
	}
	
	public virtual /*reliable server function */void ServerSetClientVersion(int I)
	{
		// stub
	}
	
	public virtual /*function */void OnCarryObject(Actor inActor)
	{
		// stub
	}
	
	public virtual /*function */void OnDropCarriedObject(Actor inActor)
	{
		// stub
	}
	
	public virtual /*function */void OnUseCarriedObject(Actor inActor)
	{
		// stub
	}
	
	public virtual /*function */void ScorePassedCarriedObject()
	{
		// stub
	}
	
	public virtual /*function */void ScoreInterceptedCarriedObject()
	{
		// stub
	}
	
	public virtual /*reliable server function */void RequestTeamChange(int NewTeam)
	{
		// stub
	}
	
	public virtual /*reliable server function */void RequestRoleChange(int NewRoleIndex)
	{
		// stub
	}
	
	public virtual /*reliable server function */void RequestSetReady()
	{
		// stub
	}
	
	public TdPlayerReplicationInfo()
	{
		// Object Offset:0x0050CAFA
		ClientVersion = 1;
		GameMessageClass = ClassT<TdGameMessage>()/*Ref Class'TdGameMessage'*/;
	}
}
}