namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackSound : InterpTrackVectorBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */SoundTrackKey
	{
		public float Time;
		public float Volume;
		public float Pitch;
		[Category] public SoundCue Sound;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00343E97
	//		Time = 0.0f;
	//		Volume = 1.0f;
	//		Pitch = 1.0f;
	//		Sound = default;
	//	}
	};
	
	public array<InterpTrackSound.SoundTrackKey> Sounds;
	[Category] public bool bContinueSoundOnMatineeEnd;
	[Category] public bool bSuppressSubtitles;
	
	public InterpTrackSound()
	{
		// Object Offset:0x00343FC7
		TrackInstClass = ClassT<InterpTrackInstSound>()/*Ref Class'InterpTrackInstSound'*/;
		TrackTitle = "Sound";
	}
}
}