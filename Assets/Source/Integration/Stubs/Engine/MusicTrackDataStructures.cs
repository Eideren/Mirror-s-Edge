namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MusicTrackDataStructures : Object/*
		native*/{
	public partial struct /*native */MusicTrackParamStruct
	{
		[Category] public float FadeInTime;
		[Category] public float FadeInVolumeLevel;
		[Category] public float DelayBetweenOldAndNewTrack;
		[Category] public float FadeOutTime;
		[Category] public float FadeOutVolumeLevel;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00287EFB
	//		FadeInTime = 5.0f;
	//		FadeInVolumeLevel = 1.0f;
	//		DelayBetweenOldAndNewTrack = 0.0f;
	//		FadeOutTime = 5.0f;
	//		FadeOutVolumeLevel = 0.0f;
	//	}
	};
	
	public partial struct /*native */MusicTrackStruct
	{
		[Category] public MusicTrackDataStructures.MusicTrackParamStruct Params;
		[Category] public name TrackType;
		[Category] public SoundCue TheSoundCue;
		[Category] public bool bAutoPlay;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00288077
	//		Params = new MusicTrackDataStructures.MusicTrackParamStruct
	//		{
	//			FadeInTime = 5.0f,
	//			FadeInVolumeLevel = 1.0f,
	//			DelayBetweenOldAndNewTrack = 0.0f,
	//			FadeOutTime = 5.0f,
	//			FadeOutVolumeLevel = 0.0f,
	//		};
	//		TrackType = (name)"None";
	//		TheSoundCue = default;
	//		bAutoPlay = false;
	//	}
	};
	
}
}