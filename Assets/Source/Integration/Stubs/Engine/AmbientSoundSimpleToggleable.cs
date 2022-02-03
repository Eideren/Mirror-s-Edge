namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSoundSimpleToggleable : AmbientSoundSimple/*
		placeable
		hidecategories(Navigation,Audio)*/{
	[repnotify] public bool bCurrentlyPlaying;
	[Category] public bool bFadeOnToggle;
	[Category] public float FadeInDuration;
	[Category] public float FadeInVolumeLevel;
	[Category] public float FadeOutDuration;
	[Category] public float FadeOutVolumeLevel;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bCurrentlyPlaying;
	//}
	
	public override /*simulated event */void eventPostBeginPlay()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*simulated function */void StartPlaying()
	{
		// stub
	}
	
	public virtual /*simulated function */void StopPlaying()
	{
		// stub
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public AmbientSoundSimpleToggleable()
	{
		var Default__AmbientSoundSimpleToggleable_SoundCue0 = new SoundCue
		{
		}/* Reference: SoundCue'Default__AmbientSoundSimpleToggleable.SoundCue0' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0_DistributionMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionMinRadius' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0_DistributionMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionMaxRadius' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0_DistributionLPFMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionLPFMinRadius' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0_DistributionLPFMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionLPFMaxRadius' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0_DistributionVolume = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionVolume' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0_DistributionPitch = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionPitch' */;
		var Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0 = new SoundNodeAmbient
		{
			// Object Offset:0x004CF042
			MinRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionMinRadius'*/,
			},
			MaxRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionMaxRadius'*/,
			},
			LPFMinRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionLPFMinRadius'*/,
			},
			LPFMaxRadius = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionLPFMaxRadius'*/,
			},
			VolumeModulation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionVolume")/*Ref DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionVolume'*/,
			},
			PitchModulation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatUniform>("Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionPitch")/*Ref DistributionFloatUniform'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0.DistributionPitch'*/,
			},
		}/* Reference: SoundNodeAmbient'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0' */;
		var Default__AmbientSoundSimpleToggleable_DrawSoundRadius0 = new DrawSoundRadiusComponent
		{
		}/* Reference: DrawSoundRadiusComponent'Default__AmbientSoundSimpleToggleable.DrawSoundRadius0' */;
		var Default__AmbientSoundSimpleToggleable_AudioComponent0 = new AudioComponent
		{
			// Object Offset:0x00465E9F
			PreviewSoundRadius = Default__AmbientSoundSimpleToggleable_DrawSoundRadius0/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimpleToggleable.DrawSoundRadius0'*/,
		}/* Reference: AudioComponent'Default__AmbientSoundSimpleToggleable.AudioComponent0' */;
		var Default__AmbientSoundSimpleToggleable_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__AmbientSoundSimpleToggleable.Sprite' */;
		// Object Offset:0x00291567
		FadeInDuration = 1.0f;
		FadeInVolumeLevel = 1.0f;
		FadeOutDuration = 1.0f;
		SoundCueInstance = Default__AmbientSoundSimpleToggleable_SoundCue0/*Ref SoundCue'Default__AmbientSoundSimpleToggleable.SoundCue0'*/;
		SoundNodeInstance = Default__AmbientSoundSimpleToggleable_SoundNodeAmbient0/*Ref SoundNodeAmbient'Default__AmbientSoundSimpleToggleable.SoundNodeAmbient0'*/;
		bAutoPlay = false;
		AudioComponent = Default__AmbientSoundSimpleToggleable_AudioComponent0/*Ref AudioComponent'Default__AmbientSoundSimpleToggleable.AudioComponent0'*/;
		bStatic = false;
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__AmbientSoundSimpleToggleable_Sprite/*Ref SpriteComponent'Default__AmbientSoundSimpleToggleable.Sprite'*/,
			Default__AmbientSoundSimpleToggleable_AudioComponent0/*Ref AudioComponent'Default__AmbientSoundSimpleToggleable.AudioComponent0'*/,
			Default__AmbientSoundSimpleToggleable_DrawSoundRadius0/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimpleToggleable.DrawSoundRadius0'*/,
		};
	}
}
}