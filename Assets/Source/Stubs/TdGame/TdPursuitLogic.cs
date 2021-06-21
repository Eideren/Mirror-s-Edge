namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitLogic : Object, 
		TdStashpointListener,TdCarriableListener{
	public /*private transient */TdStashpointManager StashpointManager;
	public /*private transient */TdMPTeamPursuitGame MyGameInfo;
	public /*private transient */TdPursuitGRI MyGameReplicationInfo;
	public /*private transient */TdCarriable BagHandler;
	public /*transient */int ActiveStashpointID;
	public /*private transient */Core.ClassT<TdLocalMessage> TdPursuitMessageClass;
	
	public virtual /*function */Actor GetBagActor()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Initialize(TdGameInfo InGameInfo)
	{
		// stub
	}
	
	public virtual /*function */void OnStartMatchInProgress()
	{
		// stub
	}
	
	public virtual /*function */void OnEndMatchInProgress()
	{
		// stub
	}
	
	public virtual /*function */void OnStashingInitiated(TdStashpoint Stashpoint)
	{
		// stub
	}
	
	public virtual /*function */void OnStashingIntercepted(TdStashpoint Stashpoint)
	{
		// stub
	}
	
	public virtual /*function */void OnStashingCompleted(TdStashpoint Stashpoint)
	{
		// stub
	}
	
	public virtual /*function */void OnStashingProgressed(TdStashpoint Stashpoint, float TimeUntilCompletion)
	{
		// stub
	}
	
	public virtual /*function */void OnCarried(TdCarriable Carriable)
	{
		// stub
	}
	
	public virtual /*function */void OnDropped(TdCarriable Carriable)
	{
		// stub
	}
	
	public virtual /*function */void OnBeginBagSearch(Object.Vector StashLocation, TdPlayerReplicationInfo PRI)
	{
		// stub
	}
	
	public virtual /*function */void OnResurrected(TdCarriable Carriable)
	{
		// stub
	}
	
	public virtual /*function */void OnTouchedGround(TdCarriable Carriable)
	{
		// stub
	}
	
}
}