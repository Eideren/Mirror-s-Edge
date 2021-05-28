namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSoundSimpleToggleable : AmbientSoundSimple/*
		placeable
		hidecategories(Navigation,Audio)*/{
	public /*repnotify */bool bCurrentlyPlaying;
	public/*()*/ bool bFadeOnToggle;
	public/*()*/ float FadeInDuration;
	public/*()*/ float FadeInVolumeLevel;
	public/*()*/ float FadeOutDuration;
	public/*()*/ float FadeOutVolumeLevel;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bCurrentlyPlaying;
	//}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public virtual /*simulated function */void StartPlaying()
	{
	
	}
	
	public virtual /*simulated function */void StopPlaying()
	{
	
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public AmbientSoundSimpleToggleable()
	{
		// Object Offset:0x00291567
		FadeInDuration = 1.0f;
		FadeInVolumeLevel = 1.0f;
		FadeOutDuration = 1.0f;
		SoundCueInstance = LoadAsset<SoundCue>("Default__AmbientSoundSimpleToggleable.SoundCue0")/*Ref SoundCue'Default__AmbientSoundSimpleToggleable.SoundCue0'*/;
		SoundNodeInstance = new SoundNodeAmbient
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
		bAutoPlay = false;
		AudioComponent = new AudioComponent
		{
			// Object Offset:0x00465E9F
			PreviewSoundRadius = LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundSimpleToggleable.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimpleToggleable.DrawSoundRadius0'*/,
		}/* Reference: AudioComponent'Default__AmbientSoundSimpleToggleable.AudioComponent0' */;
		bStatic = false;
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__AmbientSoundSimpleToggleable.Sprite")/*Ref SpriteComponent'Default__AmbientSoundSimpleToggleable.Sprite'*/,
			//Components[1]=
			new AudioComponent
			{
				// Object Offset:0x00465E9F
				PreviewSoundRadius = LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundSimpleToggleable.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimpleToggleable.DrawSoundRadius0'*/,
			}/* Reference: AudioComponent'Default__AmbientSoundSimpleToggleable.AudioComponent0' */,
			LoadAsset<DrawSoundRadiusComponent>("Default__AmbientSoundSimpleToggleable.DrawSoundRadius0")/*Ref DrawSoundRadiusComponent'Default__AmbientSoundSimpleToggleable.DrawSoundRadius0'*/,
		};
	}
}
}