namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagGRI : TdGameReplicationInfo/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public bool bBagIsOnGround;
	public TdPlayerReplicationInfo LastBagHolderPRI;
	public TdPlayerReplicationInfo BagHolderPRI;
	public Actor Bag;
	public /*config */float UnreachableBagDetectionTimeout;
	public /*private transient */Core.ClassT<TdLocalMessage> TdBagMessageClass;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Bag, BagHolderPRI;
	//}
	
	public override /*simulated event */void PreBeginPlay()
	{
	
	}
	
	public override /*simulated function */bool IsBagGame()
	{
	
		return default;
	}
	
	public virtual /*function */Object.Vector FindBestBagStart()
	{
	
		return default;
	}
	
	public override /*function */void OnCarryObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
	
	}
	
	public override /*function */void OnDropCarriedObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
	
	}
	
	public override /*function */void OnRespawnCarriedObject(Actor CarriedActor)
	{
	
	}
	
	public override /*function */void OnCarriedObjectTouchedGround(Actor CarriedActor)
	{
	
	}
	
}
}