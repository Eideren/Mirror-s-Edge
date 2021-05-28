namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSoundNonLoop : AmbientSoundSimple/*
		native
		placeable
		hidecategories(Navigation,Audio)*/{
	public AmbientSoundNonLoop()
	{
		// Object Offset:0x00290EB3
		SoundCueInstance = LoadAsset<SoundCue>("Default__AmbientSoundNonLoop.SoundCue0")/*Ref SoundCue'Default__AmbientSoundNonLoop.SoundCue0'*/;
		SoundNodeInstance = new SoundNodeAmbientNonLoop
		{
			// Object Offset:0x004CF1E6
			DelayTime = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionDelayTime")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionDelayTime'*/,
			},
			MinRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionMinRadius'*/,
			},
			MaxRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionMaxRadius'*/,
			},
			LPFMinRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionLPFMinRadius'*/,
			},
			LPFMaxRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionLPFMaxRadius'*/,
			},
			VolumeModulation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionVolume")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionVolume'*/,
			},
			PitchModulation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionPitch")/*Ref DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionPitch'*/,
			},
		}/* Reference: SoundNodeAmbientNonLoop'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0' */;
		AudioComponent = new AudioComponent
		{
			// Object Offset:0x00465E6B
			PreviewSoundRadius = LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundNonLoop.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundNonLoop.DrawSoundRadius0'*/,
		}/* Reference: AudioComponent'Default__AmbientSoundNonLoop.AudioComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__AmbientSoundNonLoop.Sprite")/*Ref SpriteComponent'Default__AmbientSoundNonLoop.Sprite'*/,
			//Components[1]=
			new AudioComponent
			{
				// Object Offset:0x00465E6B
				PreviewSoundRadius = LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundNonLoop.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundNonLoop.DrawSoundRadius0'*/,
			}/* Reference: AudioComponent'Default__AmbientSoundNonLoop.AudioComponent0' */,
			//Components[2]=
			new DrawSoundRadiusComponent
			{
				// Object Offset:0x00468C6B
				SphereColor = new Color
				{
					R=240,
					G=50,
					B=50,
					A=255
				},
			}/* Reference: DrawSoundRadiusComponent'Default__AmbientSoundNonLoop.DrawSoundRadius0' */,
		};
	}
}
}