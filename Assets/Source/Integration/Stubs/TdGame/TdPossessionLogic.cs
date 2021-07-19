namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPossessionLogic : Object, 
		TdCarriableListener{
	[transient] public/*private*/ TdMPPossessionGame MyGameInfo;
	[transient] public/*private*/ TdPossessionGRI MyGameReplicationInfo;
	[transient] public/*private*/ TdCarriable BagHandler;
	
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
	
	public virtual /*function */void OnCarried(TdCarriable Carriable)
	{
		// stub
	}
	
	public virtual /*function */void OnDropped(TdCarriable Carriable)
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