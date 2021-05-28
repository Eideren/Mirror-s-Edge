namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPossessionLogic : Object, 
		TdCarriableListener{
	public /*private transient */TdMPPossessionGame MyGameInfo;
	public /*private transient */TdPossessionGRI MyGameReplicationInfo;
	public /*private transient */TdCarriable BagHandler;
	
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
	
	public virtual /*function */void OnCarried(TdCarriable Carriable)
	{
	
	}
	
	public virtual /*function */void OnDropped(TdCarriable Carriable)
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