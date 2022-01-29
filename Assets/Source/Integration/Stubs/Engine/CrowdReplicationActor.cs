namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CrowdReplicationActor : Actor/*
		native
		nativereplication
		notplaceable
		hidecategories(Navigation)*/{
	[repnotify] public SeqAct_CrowdSpawner Spawner;
	[repnotify] public bool bSpawningActive;
	[repnotify] public int DestroyAllCount;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		DestroyAllCount, Spawner, 
	//		bSpawningActive;
	//}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? CrowdReplicationActor_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => CrowdReplicationActor_Tick;
	public /*simulated event */void CrowdReplicationActor_Tick(float DeltaTime)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
	
	}
	public CrowdReplicationActor()
	{
		// Object Offset:0x002F4B66
		bAlwaysRelevant = true;
		bReplicateMovement = false;
		bSkipActorPropertyReplication = true;
		bOnlyDirtyReplication = true;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 1.0f;
		NetPriority = 2.70f;
	}
}
}