namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MusicTrackDataStructures : Object/*
		native*/{
	public partial struct /*native */MusicTrackParamStruct
	{
		public/*()*/ float FadeInTime;
		public/*()*/ float FadeInVolumeLevel;
		public/*()*/ float DelayBetweenOldAndNewTrack;
		public/*()*/ float FadeOutTime;
		public/*()*/ float FadeOutVolumeLevel;
	
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
		public/*()*/ MusicTrackDataStructures.MusicTrackParamStruct Params;
		public/*()*/ name TrackType;
		public/*()*/ SoundCue TheSoundCue;
		public/*()*/ bool bAutoPlay;
	
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