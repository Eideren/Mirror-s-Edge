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
	
	public /*transient */TdCheckpointListener Listener;
	public /*private transient */array<TdPlaceableCheckpointManager.CheckpointTrack> Tracks;
	public /*private transient */array<TdPlaceableCheckpoint> ActiveTrack;
	public /*private transient */array<TdPlaceableCheckpoint> AllCheckPoints;
	
	public virtual /*final function */void Initialize(Core.ClassT<TdPlaceableCheckpoint> CheckpointClass, TdCheckpointListener InListener)
	{
	
	}
	
	public virtual /*private final function */void InsertCheckpointIntoTrack(TdPlaceableCheckpoint CheckpointToInsert, int CheckpointOrderIndex, int TrackArrayIndex)
	{
	
	}
	
	public virtual /*private final function */void ListCheckpoints()
	{
	
	}
	
	public virtual /*private final simulated function */void ComputeDirectionHints()
	{
	
	}
	
	public virtual /*private final simulated function */void ClearAllTracks()
	{
	
	}
	
	public virtual /*final simulated function */void ShowTrack(int TrackIndex, bool bShow)
	{
	
	}
	
	public virtual /*private final simulated function */void DeactivateAllCheckpoints()
	{
	
	}
	
	public virtual /*final function */bool CanFindTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*final function */bool ActivateTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */int GetTrackSize()
	{
	
		return default;
	}
	
	public virtual /*function */TdPlaceableCheckpointManager.TrackData GetTrackData(int TrackIndex, /*optional */PlayerStart? _SeperateStartSpot = default)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */int GetTrackSizeForIndex(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */array<TdPlaceableCheckpoint> GetTrackForIndex(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */float GetTrackDistance(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetFirstCheckpoint()
	{
	
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetFinalCheckpoint()
	{
	
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetNextCheckpoint(TdPlaceableCheckpoint Checkpoint)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetPreviousCheckpoint(TdPlaceableCheckpoint Checkpoint)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */TdPlaceableCheckpoint GetCheckpointPointAtIndex(int Index)
	{
	
		return default;
	}
	
	public virtual /*private final simulated function */int GetIndexOfCheckPoint(TdPlaceableCheckpoint Checkpoint)
	{
	
		return default;
	}
	
}
}