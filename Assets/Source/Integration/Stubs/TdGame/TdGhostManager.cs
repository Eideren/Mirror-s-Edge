namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGhostManager : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public Subsystem GhostRecordDriver;
	public Subsystem GhostPlaybackDriver;
	public Object GhostNetworkNotify;
	[init] public array</*init */byte> RecordData;
	[init] public array</*init */byte> PlaybackData;
	
	// Export UTdGhostManager::execRecordGhost(FFrame&, void* const)
	public virtual /*native function */void RecordGhost(TdPawn P)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdGhostManager::execStopGhostRecording(FFrame&, void* const)
	public virtual /*native function */void StopGhostRecording(TdPawn P)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdGhostManager::execGetRecordedGhost(FFrame&, void* const)
	public virtual /*native function */void GetRecordedGhost(ref array<byte> GhostData)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdGhostManager::execSetPlaybackGhost(FFrame&, void* const)
	public virtual /*native function */void SetPlaybackGhost(ref array<byte> GhostData)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdGhostManager::execPlaybackGhost(FFrame&, void* const)
	public virtual /*native function */void PlaybackGhost()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdGhostManager::execStopGhostPlayback(FFrame&, void* const)
	public virtual /*native function */void StopGhostPlayback()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}