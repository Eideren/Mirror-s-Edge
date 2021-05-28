namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSoundSimple : AmbientSound/*
		native
		placeable
		hidecategories(Navigation,Audio)*/{
	public/*()*/ /*editconst editinline */SoundNodeAmbient AmbientProperties;
	public /*const export editinline */SoundCue SoundCueInstance;
	public /*const export editinline */SoundNodeAmbient SoundNodeInstance;
	
	public AmbientSoundSimple()
	{
		// Object Offset:0x002905AD
		SoundCueInstance = new SoundCue
		{
			// Object Offset:0x00290730
			SoundGroup = (name)"Ambient",
		}/* Reference: SoundCue'Default__AmbientSoundSimple.SoundCue0' */;
		SoundNodeInstance = new SoundNodeAmbient
		{
			// Object Offset:0x00290FD2
			MinRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionMinRadius'*/,
			},
			MaxRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionMaxRadius'*/,
			},
			LPFMinRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionLPFMinRadius'*/,
			},
			LPFMaxRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionLPFMaxRadius'*/,
			},
			VolumeModulation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionVolume")/*Ref DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionVolume'*/,
			},
			PitchModulation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionPitch")/*Ref DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionPitch'*/,
			},
		}/* Reference: SoundNodeAmbient'Default__AmbientSoundSimple.SoundNodeAmbient0' */;
		AudioComponent = new AudioComponent
		{
			// Object Offset:0x002906E4
			PreviewSoundRadius = LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundSimple.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimple.DrawSoundRadius0'*/,
		}/* Reference: AudioComponent'Default__AmbientSoundSimple.AudioComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__AmbientSoundSimple.Sprite")/*Ref SpriteComponent'Default__AmbientSoundSimple.Sprite'*/,
			//Components[1]=
			new AudioComponent
			{
				// Object Offset:0x002906E4
				PreviewSoundRadius = LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundSimple.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimple.DrawSoundRadius0'*/,
			}/* Reference: AudioComponent'Default__AmbientSoundSimple.AudioComponent0' */,
			LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundSimple.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimple.DrawSoundRadius0'*/,
		};
	}
}
}