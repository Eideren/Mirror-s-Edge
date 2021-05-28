namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitGRI : TdBagGRI/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdStashpoint StashpointList;
	public TdStashpoint EngagedRunnerStashpoint;
	public TdStashpoint EngagedCopStashpoint;
	public int TimeToBagSearchCompletion;
	public int TimeToNewRunnerStahspoint;
	public int SyncRunnerStahspointTimer;
	public TdPlayerReplicationInfo RunnerStashAssistPRI;
	public Object.Vector LastBagDropLocation;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		EngagedRunnerStashpoint;
	//
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		StashpointList, SyncRunnerStahspointTimer, 
	//		TimeToBagSearchCompletion;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		TimeToNewRunnerStahspoint;
	//}
	
	public override Timer_del Timer { get => bfield_Timer ?? TdPursuitGRI_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => TdPursuitGRI_Timer;
	public /*simulated event */void TdPursuitGRI_Timer()
	{
	
	}
	
	public override /*function */Object.Vector FindBestBagStart()
	{
	
		return default;
	}
	
	public virtual /*function */float RateBagStart(TdBagStart Bs, TdMPTeamPursuitGame MyGameMode)
	{
	
		return default;
	}
	
	public override /*function */void OnCarriedObjectTouchedGround(Actor CarriedActor)
	{
	
	}
	
	public override /*function */void OnDropCarriedObject(TdPlayerReplicationInfo PRI, Actor CarriedActor)
	{
	
	}
	
	public virtual /*function */void OnStashingCompleted(TdStashpoint Stashpoint)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Timer = null;
	
	}
	public TdPursuitGRI()
	{
		// Object Offset:0x00650508
		TimeToBagSearchCompletion = -1;
	}
}
}