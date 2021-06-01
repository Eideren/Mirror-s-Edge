namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdReverbVolume : ReverbVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public enum VolumeType 
	{
		EVT_Small___1,
		EVT_Medium__2,
		EVT_Large___3,
		EVT_Mute____4,
		EVT_MAX
	};
	
	public partial struct /*native */StereoAmbientStruct
	{
		public/*()*/ SoundCue AmbientSound;
		public/*()*/ float Volume;
		public/*()*/ float FadeInTime;
		public/*()*/ float FadeOutTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00654A22
	//		AmbientSound = default;
	//		Volume = 0.50f;
	//		FadeInTime = 0.50f;
	//		FadeOutTime = 2.0f;
	//	}
	};
	
	public/*()*/ TdReverbVolume.StereoAmbientStruct StereoAmbient;
	public/*()*/ TdReverbVolume.VolumeType vType;
	public /*export editinline */AudioComponent AmbientSoundComponent;
	
	public TdReverbVolume()
	{
		// Object Offset:0x00654B9A
		StereoAmbient = new TdReverbVolume.StereoAmbientStruct
		{
			AmbientSound = default,
			Volume = 0.50f,
			FadeInTime = 0.50f,
			FadeOutTime = 2.0f,
		};
		AmbientSoundComponent = new AudioComponent
		{
			// Object Offset:0x01AB4502
			bShouldRemainActiveIfDropped = true,
			bAllowSpatialization = false,
		}/* Reference: AudioComponent'Default__TdReverbVolume.StereoAmbientComponent' */;
		BrushComponent = LoadAsset<BrushComponent>("Default__TdReverbVolume.BrushComponent0")/*Ref BrushComponent'Default__TdReverbVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__TdReverbVolume.BrushComponent0")/*Ref BrushComponent'Default__TdReverbVolume.BrushComponent0'*/,
			new AudioComponent
			{
				// Object Offset:0x01AB4502
				bShouldRemainActiveIfDropped = true,
				bAllowSpatialization = false,
			}/* Reference: AudioComponent'Default__TdReverbVolume.StereoAmbientComponent' */,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__TdReverbVolume.BrushComponent0")/*Ref BrushComponent'Default__TdReverbVolume.BrushComponent0'*/;
	}
}
}