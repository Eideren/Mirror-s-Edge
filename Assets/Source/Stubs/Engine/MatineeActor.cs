namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MatineeActor : Actor/*
		native
		nativereplication
		notplaceable
		hidecategories(Navigation)*/{
	public /*const */SeqAct_Interp InterpAction;
	public bool bIsPlaying;
	public bool bReversePlayback;
	public bool bPaused;
	public float PlayRate;
	public float Position;
	
	//replication
	//{
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		InterpAction;
	//
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		PlayRate, Position, 
	//		bIsPlaying, bPaused, 
	//		bReversePlayback;
	//}
	
	public virtual /*event */void Update()
	{
	
	}
	
	public MatineeActor()
	{
		// Object Offset:0x0035C21E
		PlayRate = 1.0f;
		Position = -1.0f;
		bAlwaysRelevant = true;
		bReplicateMovement = false;
		bSkipActorPropertyReplication = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004CFDE6
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__MatineeActor.Sprite' */,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 1.0f;
		NetPriority = 2.70f;
	}
}
}