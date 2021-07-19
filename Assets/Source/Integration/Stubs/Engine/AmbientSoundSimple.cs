namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSoundSimple : AmbientSound/*
		native
		placeable
		hidecategories(Navigation,Audio)*/{
	[Category] [editconst, editinline] public SoundNodeAmbient AmbientProperties;
	[Const, export, editinline] public SoundCue SoundCueInstance;
	[Const, export, editinline] public SoundNodeAmbient SoundNodeInstance;
	
	public AmbientSoundSimple()
	{
		var Default__AmbientSoundSimple_SoundCue0 = new SoundCue
		{
			// Object Offset:0x00290730
			SoundGroup = (name)"Ambient",
		}/* Reference: SoundCue'Default__AmbientSoundSimple.SoundCue0' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0_DistributionMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionMinRadius' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0_DistributionMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionMaxRadius' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0_DistributionLPFMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionLPFMinRadius' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0_DistributionLPFMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionLPFMaxRadius' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0_DistributionVolume = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionVolume' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0_DistributionPitch = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimple.SoundNodeAmbient0.DistributionPitch' */;
		var Default__AmbientSoundSimple_SoundNodeAmbient0 = new SoundNodeAmbient
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
		var Default__AmbientSoundSimple_DrawSoundRadius0 = new DrawSoundRadiusComponent
		{
		}/* Reference: DrawSoundRadiusComponent'Default__AmbientSoundSimple.DrawSoundRadius0' */;
		var Default__AmbientSoundSimple_AudioComponent0 = new AudioComponent
		{
			// Object Offset:0x002906E4
			PreviewSoundRadius = Default__AmbientSoundSimple_DrawSoundRadius0/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimple.DrawSoundRadius0'*/,
		}/* Reference: AudioComponent'Default__AmbientSoundSimple.AudioComponent0' */;
		var Default__AmbientSoundSimple_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__AmbientSoundSimple.Sprite' */;
		// Object Offset:0x002905AD
		SoundCueInstance = Default__AmbientSoundSimple_SoundCue0/*Ref SoundCue'Default__AmbientSoundSimple.SoundCue0'*/;
		SoundNodeInstance = Default__AmbientSoundSimple_SoundNodeAmbient0/*Ref SoundNodeAmbient'Default__AmbientSoundSimple.SoundNodeAmbient0'*/;
		AudioComponent = Default__AmbientSoundSimple_AudioComponent0/*Ref AudioComponent'Default__AmbientSoundSimple.AudioComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__AmbientSoundSimple_Sprite/*Ref SpriteComponent'Default__AmbientSoundSimple.Sprite'*/,
			Default__AmbientSoundSimple_AudioComponent0/*Ref AudioComponent'Default__AmbientSoundSimple.AudioComponent0'*/,
			Default__AmbientSoundSimple_DrawSoundRadius0/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimple.DrawSoundRadius0'*/,
		};
	}
}
}