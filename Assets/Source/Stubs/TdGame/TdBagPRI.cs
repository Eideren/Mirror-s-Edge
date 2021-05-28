namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagPRI : TdPlayerReplicationInfo/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public /*repnotify */bool bHasBag;
	public /*transient */float LastBagCarrierDamageTime;
	public /*protected transient */Core.ClassT<TdLocalMessage> TdBagMessageClass;
	
	//replication
	//{
	//	 if((bNetDirty && bNetOwner) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bHasBag;
	//}
	
	public override /*simulated event */void PreBeginPlay()
	{
	
	}
	
	public override /*function */void OnCarryObject(Actor inActor)
	{
	
	}
	
	public override /*function */void OnDropCarriedObject(Actor inActor)
	{
	
	}
	
	public virtual /*simulated function */void AnnounceYouHaveTheBag()
	{
	
	}
	
}
}