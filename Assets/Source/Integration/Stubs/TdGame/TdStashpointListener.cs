namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdStashpointListener : Interface/*
		abstract*/{
	public /*function */void OnStashingInitiated(TdStashpoint Stashpoint);
	
	public /*function */void OnStashingIntercepted(TdStashpoint Stashpoint);
	
	public /*function */void OnStashingCompleted(TdStashpoint Stashpoint);
	
	public /*function */void OnStashingProgressed(TdStashpoint Stashpoint, float Completed);
	
}
}