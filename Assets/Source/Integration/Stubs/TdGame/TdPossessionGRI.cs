namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPossessionGRI : TdBagGRI/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	[config] public float BagPossessionLimit;
	public TdPlayerReplicationInfo Leader;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Leader;
	//}
	
	public override Timer_del Timer { get => bfield_Timer ?? TdPossessionGRI_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => TdPossessionGRI_Timer;
	public /*simulated event */void TdPossessionGRI_Timer()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Timer = null;
	
	}
}
}