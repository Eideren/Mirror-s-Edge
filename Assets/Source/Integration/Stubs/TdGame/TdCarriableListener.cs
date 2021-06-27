namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdCarriableListener : Interface/*
		abstract*/{
	public /*function */void OnCarried(TdCarriable Carriable);
	
	public /*function */void OnDropped(TdCarriable Carriable);
	
	public /*function */void OnTouchedGround(TdCarriable Carriable);
	
	public /*function */void OnResurrected(TdCarriable Carriable);
	
}
}