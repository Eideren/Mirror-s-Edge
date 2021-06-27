namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdCheckpointListener : Interface/*
		abstract*/{
	public /*function */void OnCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller);
	
}
}