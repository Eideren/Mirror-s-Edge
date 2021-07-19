namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlaceableCheckpointManager : Actor/*
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct CheckpointTrack
	{
		public int TrackIndex;
		public array<TdPlaceableCheckpoint> Checkpoints;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0060E7EB
	//		TrackIndex = 0;
	//		Checkpoints = default;
	//	}
	};
	
	public partial struct TrackData
	{
		public float TotalDistance;
		public array<float> IntermediateDistance;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0060E8E3
	//		TotalDistance = 0.0f;
	//		IntermediateDistance = default;
	//	}
	};
	
	[transient] public TdCheckpointListener Listener;
	[transient] public/*private*/ array<TdPlaceableCheckpointManager.CheckpointTrack> Tracks;
	[transient] public/*private*/ array<TdPlaceableCheckpoint> ActiveTrack;
	[transient] public/*private*/ array<TdPlaceableCheckpoint> AllCheckPoints;
	
	public virtual /*final function */void Initialize(Core.ClassT<TdPlaceableCheckpoint> CheckpointClass, TdCheckpointListener InListener)
	{
		// stub
	}
	
	public virtual /*private final function */void InsertCheckpointIntoTrack(TdPlaceableCheckpoint CheckpointToInsert, int CheckpointOrderIndex, int TrackArrayIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ListCheckpoints()
	{
		// stub
	}
	
	public virtual /*private final simulated function */void ComputeDirectionHints()
	{
		// stub
	}
	
	public virtual /*private final simulated function */void ClearAllTracks()
	{
		// stub
	}
	
	public virtual /*final simulated function */void ShowTrack(int TrackIndex, bool bShow)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void DeactivateAllCheckpoints()
	{
		// stub
	}
	
	public virtual /*final function */bool CanFindTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool ActivateTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */int GetTrackSize()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdPlaceableCheckpointManager.TrackData GetTrackData(int TrackIndex, /*optional */PlayerStart _SeperateStartSpot = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */int GetTrackSizeForIndex(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */array<TdPlaceableCheckpoint> GetTrackForIndex(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */float GetTrackDistance(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetFirstCheckpoint()
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetFinalCheckpoint()
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetNextCheckpoint(TdPlaceableCheckpoint Checkpoint)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetPreviousCheckpoint(TdPlaceableCheckpoint Checkpoint)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetCheckpointPointAtIndex(int Index)
	{
		// stub
		return default;
	}
	
	public virtual /*private final simulated function */int GetIndexOfCheckPoint(TdPlaceableCheckpoint Checkpoint)
	{
		// stub
		return default;
	}
	
}
}