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
		[Category] public SoundCue AmbientSound;
		[Category] public float Volume;
		[Category] public float FadeInTime;
		[Category] public float FadeOutTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00654A22
	//		AmbientSound = default;
	//		Volume = 0.50f;
	//		FadeInTime = 0.50f;
	//		FadeOutTime = 2.0f;
	//	}
	};
	
	[Category] public TdReverbVolume.StereoAmbientStruct StereoAmbient;
	[Category] public TdReverbVolume.VolumeType vType;
	[export, editinline] public AudioComponent AmbientSoundComponent;
	
	public TdReverbVolume()
	{
		var Default__TdReverbVolume_StereoAmbientComponent = new AudioComponent
		{
			// Object Offset:0x01AB4502
			bShouldRemainActiveIfDropped = true,
			bAllowSpatialization = false,
		}/* Reference: AudioComponent'Default__TdReverbVolume.StereoAmbientComponent' */;
		var Default__TdReverbVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdReverbVolume.BrushComponent0' */;
		// Object Offset:0x00654B9A
		StereoAmbient = new TdReverbVolume.StereoAmbientStruct
		{
			AmbientSound = default,
			Volume = 0.50f,
			FadeInTime = 0.50f,
			FadeOutTime = 2.0f,
		};
		AmbientSoundComponent = Default__TdReverbVolume_StereoAmbientComponent/*Ref AudioComponent'Default__TdReverbVolume.StereoAmbientComponent'*/;
		BrushComponent = Default__TdReverbVolume_BrushComponent0/*Ref BrushComponent'Default__TdReverbVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdReverbVolume_BrushComponent0/*Ref BrushComponent'Default__TdReverbVolume.BrushComponent0'*/,
			Default__TdReverbVolume_StereoAmbientComponent/*Ref AudioComponent'Default__TdReverbVolume.StereoAmbientComponent'*/,
		};
		CollisionComponent = Default__TdReverbVolume_BrushComponent0/*Ref BrushComponent'Default__TdReverbVolume.BrushComponent0'*/;
	}
}
}