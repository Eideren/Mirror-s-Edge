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
	[config] public float UnreachableBagDetectionTimeout;
	[transient] public/*private*/ Core.ClassT<TdLocalMessage> TdBagMessageClass;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Bag, BagHolderPRI;
	//}
	
	public override /*simulated event */void PreBeginPlay()
	{
		// stub
	}
	
	public override /*simulated function */bool IsBagGame()
	{
		// stub
		return default;
	}
	
	public virtual /*function */Object.Vector FindBestBagStart()
	{
		// stub
		return default;
	}
	
	public override /*function */void OnCarryObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
		// stub
	}
	
	public override /*function */void OnDropCarriedObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
		// stub
	}
	
	public override /*function */void OnRespawnCarriedObject(Actor CarriedActor)
	{
		// stub
	}
	
	public override /*function */void OnCarriedObjectTouchedGround(Actor CarriedActor)
	{
		// stub
	}
	
}
}