namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundCue : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native export */SoundNodeEditorData
	{
		[native, Const] public int NodePosX;
		[native, Const] public int NodePosY;
	};
	
	public name SoundGroup;
	public SoundNode FirstNode;
	[native, Const] public /*map<0,0>*/map<object, object> EditorData;
	[transient] public float MaxAudibleDistance;
	[Category] public float VolumeMultiplier;
	[Category] public float PitchMultiplier;
	public float Duration;
	[Category] public FaceFXAnimSet FaceFXAnimSetRef;
	[Category] public String FaceFXGroupName;
	[Category] public String FaceFXAnimName;
	[Category] public int MaxConcurrentPlayCount;
	[Category] public float timeToLive;
	[Category] public int AbsoluteMaxConcurrentPlayCount;
	[duplicatetransient, native, Const, transient] public /*map<0,0>*/map<object, object> CurrentPlayInstances;
	
	// Export USoundCue::execGetCueDuration(FFrame&, void* const)
	public virtual /*native function */float GetCueDuration()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public SoundCue()
	{
		// Object Offset:0x0028F871
		VolumeMultiplier = 0.750f;
		PitchMultiplier = 1.0f;
		MaxConcurrentPlayCount = 16;
		timeToLive = 0.50f;
		AbsoluteMaxConcurrentPlayCount = 20;
	}
}
}