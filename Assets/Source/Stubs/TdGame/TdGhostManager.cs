namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGhostManager : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public Subsystem GhostRecordDriver;
	public Subsystem GhostPlaybackDriver;
	public Object GhostNetworkNotify;
	public /*init */array</*init */byte> RecordData;
	public /*init */array</*init */byte> PlaybackData;
	
	// Export UTdGhostManager::execRecordGhost(FFrame&, void* const)
	public virtual /*native function */void RecordGhost(TdPawn P)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdGhostManager::execStopGhostRecording(FFrame&, void* const)
	public virtual /*native function */void StopGhostRecording(TdPawn P)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdGhostManager::execGetRecordedGhost(FFrame&, void* const)
	public virtual /*native function */void GetRecordedGhost(ref array<byte> GhostData)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdGhostManager::execSetPlaybackGhost(FFrame&, void* const)
	public virtual /*native function */void SetPlaybackGhost(ref array<byte> GhostData)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdGhostManager::execPlaybackGhost(FFrame&, void* const)
	public virtual /*native function */void PlaybackGhost()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdGhostManager::execStopGhostPlayback(FFrame&, void* const)
	public virtual /*native function */void StopGhostPlayback()
	{
		#warning NATIVE FUNCTION !
	}
	
}
}