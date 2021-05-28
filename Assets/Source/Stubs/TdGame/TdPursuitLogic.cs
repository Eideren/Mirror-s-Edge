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
	
		return default;
	}
	
	public virtual /*function */void Initialize(TdGameInfo InGameInfo)
	{
	
	}
	
	public virtual /*function */void OnStartMatchInProgress()
	{
	
	}
	
	public virtual /*function */void OnEndMatchInProgress()
	{
	
	}
	
	public virtual /*function */void OnStashingInitiated(TdStashpoint Stashpoint)
	{
	
	}
	
	public virtual /*function */void OnStashingIntercepted(TdStashpoint Stashpoint)
	{
	
	}
	
	public virtual /*function */void OnStashingCompleted(TdStashpoint Stashpoint)
	{
	
	}
	
	public virtual /*function */void OnStashingProgressed(TdStashpoint Stashpoint, float TimeUntilCompletion)
	{
	
	}
	
	public virtual /*function */void OnCarried(TdCarriable Carriable)
	{
	
	}
	
	public virtual /*function */void OnDropped(TdCarriable Carriable)
	{
	
	}
	
	public virtual /*function */void OnBeginBagSearch(Object.Vector StashLocation, TdPlayerReplicationInfo PRI)
	{
	
	}
	
	public virtual /*function */void OnResurrected(TdCarriable Carriable)
	{
	
	}
	
	public virtual /*function */void OnTouchedGround(TdCarriable Carriable)
	{
	
	}
	
}
}