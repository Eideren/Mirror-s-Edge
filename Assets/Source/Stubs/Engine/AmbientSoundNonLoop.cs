namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSoundNonLoop : AmbientSoundSimple/*
		native
		placeable
		hidecategories(Navigation,Audio)*/{
	public AmbientSoundNonLoop()
	{
		var Default__AmbientSoundNonLoop_SoundCue0 = new SoundCue
		{
		}/* Reference: SoundCue'Default__AmbientSoundNonLoop.SoundCue0' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionDelayTime = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionDelayTime' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionMinRadius' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionMaxRadius' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionLPFMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionLPFMinRadius' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionLPFMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionLPFMaxRadius' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionVolume = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionVolume' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0_DistributionPitch = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0.DistributionPitch' */;
		var Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0 = new SoundNodeAmbientNonLoop
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
		var Default__AmbientSoundNonLoop_DrawSoundRadius0 = new DrawSoundRadiusComponent
		{
			// Object Offset:0x00468C6B
			SphereColor = new Color
			{
				R=240,
				G=50,
				B=50,
				A=255
			},
		}/* Reference: DrawSoundRadiusComponent'Default__AmbientSoundNonLoop.DrawSoundRadius0' */;
		var Default__AmbientSoundNonLoop_AudioComponent0 = new AudioComponent
		{
			// Object Offset:0x00465E6B
			PreviewSoundRadius = Default__AmbientSoundNonLoop_DrawSoundRadius0/*Ref DrawSoundRadiusComponent'Default__AmbientSoundNonLoop.DrawSoundRadius0'*/,
		}/* Reference: AudioComponent'Default__AmbientSoundNonLoop.AudioComponent0' */;
		var Default__AmbientSoundNonLoop_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__AmbientSoundNonLoop.Sprite' */;
		// Object Offset:0x00290EB3
		SoundCueInstance = Default__AmbientSoundNonLoop_SoundCue0/*Ref SoundCue'Default__AmbientSoundNonLoop.SoundCue0'*/;
		SoundNodeInstance = Default__AmbientSoundNonLoop_SoundNodeAmbientNonLoop0/*Ref SoundNodeAmbientNonLoop'Default__AmbientSoundNonLoop.SoundNodeAmbientNonLoop0'*/;
		AudioComponent = Default__AmbientSoundNonLoop_AudioComponent0/*Ref AudioComponent'Default__AmbientSoundNonLoop.AudioComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__AmbientSoundNonLoop_Sprite/*Ref SpriteComponent'Default__AmbientSoundNonLoop.Sprite'*/,
			Default__AmbientSoundNonLoop_AudioComponent0/*Ref AudioComponent'Default__AmbientSoundNonLoop.AudioComponent0'*/,
			Default__AmbientSoundNonLoop_DrawSoundRadius0/*Ref DrawSoundRadiusComponent'Default__AmbientSoundNonLoop.DrawSoundRadius0'*/,
		};
	}
}
}