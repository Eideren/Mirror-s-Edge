namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_MusicTrack : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	[Category] public MusicTrackDataStructures.MusicTrackStruct MusicTrack;
	
	public SeqVar_MusicTrack()
	{
		// Object Offset:0x003E0409
		MusicTrack = new MusicTrackDataStructures.MusicTrackStruct
		{
			Params = new MusicTrackDataStructures.MusicTrackParamStruct
			{
				FadeInTime = 5.0f,
				FadeInVolumeLevel = 1.0f,
				DelayBetweenOldAndNewTrack = 0.0f,
				FadeOutTime = 5.0f,
				FadeOutVolumeLevel = 0.0f,
			},
			TrackType = (name)"None",
			TheSoundCue = default,
			bAutoPlay = false,
		};
		SupportedClasses = default;
		ObjName = "Music Track";
		ObjCategory = "Sound";
	}
}
}