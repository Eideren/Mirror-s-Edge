namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundCue : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native export */SoundNodeEditorData
	{
		public /*native const */int NodePosX;
		public /*native const */int NodePosY;
	};
	
	public name SoundGroup;
	public SoundNode FirstNode;
	public /*native const *//*map<0,0>*/map<object, object> EditorData;
	public /*transient */float MaxAudibleDistance;
	public/*()*/ float VolumeMultiplier;
	public/*()*/ float PitchMultiplier;
	public float Duration;
	public/*()*/ FaceFXAnimSet FaceFXAnimSetRef;
	public/*()*/ string FaceFXGroupName;
	public/*()*/ string FaceFXAnimName;
	public/*()*/ int MaxConcurrentPlayCount;
	public/*()*/ float timeToLive;
	public/*()*/ int AbsoluteMaxConcurrentPlayCount;
	public /*duplicatetransient native const transient *//*map<0,0>*/map<object, object> CurrentPlayInstances;
	
	// Export USoundCue::execGetCueDuration(FFrame&, void* const)
	public virtual /*native function */float GetCueDuration()
	{
		#warning NATIVE FUNCTION !
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