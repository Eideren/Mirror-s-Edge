namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdCarriableMediator : Interface/*
		abstract*/{
	public /*function */void OnTouched(TdPlayerPawn CarrierPawn);
	
	public /*function */void OnTouchedGround();
	
	public /*function */void OnResurrected();
	
	public /*function */bool IsCarried();
	
	public /*function */void HintUnreachable();
	
}
}