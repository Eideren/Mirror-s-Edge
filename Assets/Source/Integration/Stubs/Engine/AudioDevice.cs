namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AudioDevice : Subsystem/*
		transient
		native
		config(Engine)*/{
	public enum ESoundMode 
	{
		SOUNDMODE_NORMAL,
		SOUNDMODE_INGAME_CUTSCENES,
		SOUNDMODE_INGAME_VO,
		SOUNDMODE_REACTION_TIME,
		SOUNDMODE_PAUSE,
		SOUNDMODE_ALL_OFF,
		SOUNDMODE_FALLING_TO_DEATH,
		SOUNDMODE_CUSTOM_TRACK_INGAME_CUTSCENES,
		SOUNDMODE_DEATH_BY_FALLING,
		SOUNDMODE_GENERIC_DEATH,
		SOUNDMODE_END_CREDIT,
		SOUNDMODE_MAX
	};
	
	public partial struct /*native */Listener
	{
		[Const] public PortalVolume PortalVolume;
		public Object.Vector Location;
		public Object.Vector Up;
		public Object.Vector Right;
		public Object.Vector Front;
		public Object.Vector Velocity;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A238E
	//		PortalVolume = default;
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Up = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Right = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Front = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Velocity = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native */ModeSettings
	{
		public AudioDevice.ESoundMode Mode;
		public float FadeTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A2592
	//		Mode = AudioDevice.ESoundMode.SOUNDMODE_NORMAL;
	//		FadeTime = 0.10f;
	//	}
	};
	
	public partial struct /*native */SoundGroupProperties
	{
		[Category] public float Volume;
		[Category] public float Pitch;
		[Category] public float LowPass;
		[Category] public float MaxUpdateDistance;
		[Category] public float VoiceCenterChannelVolume;
		[Category] public float VoiceRadioVolume;
		[Category] public bool bApplyEffects;
		[Category] public bool bAlwaysPlay;
		[Category] public bool bUberAlwaysPlay;
		[Category] public bool bIsUISound;
		[Category] public bool bIsMusic;
		[Category] public bool bNoReverb;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A2816
	//		Volume = 1.0f;
	//		Pitch = 1.0f;
	//		LowPass = 1.0f;
	//		MaxUpdateDistance = 0.0f;
	//		VoiceCenterChannelVolume = 0.0f;
	//		VoiceRadioVolume = 0.0f;
	//		bApplyEffects = false;
	//		bAlwaysPlay = false;
	//		bUberAlwaysPlay = false;
	//		bIsUISound = false;
	//		bIsMusic = false;
	//		bNoReverb = false;
	//	}
	};
	
	public partial struct /*native */SoundGroup
	{
		[Category] public AudioDevice.SoundGroupProperties Properties;
		[Category] public name GroupName;
		[Category] public array<name> ChildGroupNames;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A2A56
	//		Properties = new AudioDevice.SoundGroupProperties
	//		{
	//			Volume = 1.0f,
	//			Pitch = 1.0f,
	//			LowPass = 1.0f,
	//			MaxUpdateDistance = 0.0f,
	//			VoiceCenterChannelVolume = 0.0f,
	//			VoiceRadioVolume = 0.0f,
	//			bApplyEffects = false,
	//			bAlwaysPlay = false,
	//			bUberAlwaysPlay = false,
	//			bIsUISound = false,
	//			bIsMusic = false,
	//			bNoReverb = false,
	//		};
	//		GroupName = (name)"None";
	//		ChildGroupNames = default;
	//	}
	};
	
	public partial struct /*native */SoundGroupAdjuster
	{
		public name GroupName;
		public float VolumeAdjuster;
		public float PitchAdjuster;
		public float LowPassAdjuster;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A2CF2
	//		GroupName = (name)"Master";
	//		VolumeAdjuster = 1.0f;
	//		PitchAdjuster = 1.0f;
	//		LowPassAdjuster = 1.0f;
	//	}
	};
	
	public partial struct /*native */MixGroupInfo
	{
		[Category] public name GroupName;
		[Category] public float Volume;
		[Category] public float Pitch;
		[Category] public float LowPass;
		[Category] public bool SloMo;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A2E7A
	//		GroupName = (name)"None";
	//		Volume = 1.0f;
	//		Pitch = 1.0f;
	//		LowPass = 1.0f;
	//		SloMo = true;
	//	}
	};
	
	public partial struct /*native */SoundGroupEffect
	{
		public array<AudioDevice.SoundGroupAdjuster> GroupEffect;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A2FA2
	//		GroupEffect = default;
	//	}
	};
	
	[Const, config] public int MaxChannels;
	[Const, config] public bool UseEffectsProcessing;
	[native, Const] public bool bGameWasTicking;
	[native, Const] public bool bTestLowPassFilter;
	[native, Const] public bool bTestEQFilter;
	[Const, export, editinline, transient] public array</*export editinline */AudioComponent> AudioComponents;
	[native, Const] public array<Object.Pointer> Sources;
	[native, Const] public array<Object.Pointer> FreeSources;
	[native, Const] public Object.Map_Mirror WaveInstanceSourceMap;
	[native, Const] public array<AudioDevice.Listener> Listeners;
	[native, Const] public Object.QWord CurrentTick;
	[native, Const] public Object.Map_Mirror NameToSoundGroupIndexMap;
	[native, Const] public array<AudioDevice.SoundGroup> SourceSoundGroups;
	[native, Const] public array<AudioDevice.SoundGroup> CurrentSoundGroups;
	[native, Const] public array<AudioDevice.SoundGroup> DestinationSoundGroups;
	[Category] [config] public array</*config */AudioDevice.SoundGroup> SoundGroups;
	[Category] [config] public array</*config */AudioDevice.SoundGroupEffect> SoundGroupEffects;
	[Category] [config] public array</*config */AudioDevice.MixGroupInfo> MixGroups;
	[native, Const] public Object.Pointer Effects;
	[native, Const] public AudioDevice.ESoundMode CurrentMode;
	[native, Const] public Object.Double SoundModeStartTime;
	[native, Const] public Object.Double SoundModeEndTime;
	[native, Const] public Object.Pointer TextToSpeech;
	[transient] public float TransientMasterVolume;
	
	public AudioDevice()
	{
		// Object Offset:0x002A345E
		SoundGroups = new array</*config */AudioDevice.SoundGroup>
		{
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"Master",
				ChildGroupNames = new array<name>
				{
					(name)"Music",
					(name)"SFX",
					(name)"VO",
				},
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = true,
					bNoReverb = false,
				},
				GroupName = (name)"Music",
				ChildGroupNames = new array<name>
				{
					(name)"HudMusic",
					(name)"CutSceneMusic",
					(name)"InGameMusic",
					(name)"TimeTrialMusic",
				},
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"SFX",
				ChildGroupNames = new array<name>
				{
					(name)"AmbientPropSounds",
					(name)"HudSFX",
					(name)"Dead",
					(name)"InGameSFX",
					(name)"BigLooped",
					(name)"Weapons1p",
					(name)"Weapons3p",
					(name)"FaithBreath",
					(name)"FaithVocal",
					(name)"Helicopter",
					(name)"Convoy",
				},
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"VO",
				ChildGroupNames = new array<name>
				{
					(name)"VOMain",
					(name)"DialogueAI",
				},
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 0.90f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"VOMain",
				ChildGroupNames = new array<name>
				{
					(name)"DialogueRadio",
					(name)"DialogueFaith",
					(name)"DialogueOther",
					(name)"DialogueHUD",
				},
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"AmbientPropSounds",
				ChildGroupNames = new array<name>
				{
					(name)"StereoAmbient",
					(name)"IndoorAmbient",
					(name)"IndoorAmbientProps",
					(name)"OutdoorAmbient",
					(name)"OutdoorAmbientProps",
				},
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 1.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = true,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = true,
				},
				GroupName = (name)"DialogueRadio",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 1.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = true,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"DialogueFaith",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 1.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = true,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"DialogueOther",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.40f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"DialogueAI",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 1.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = false,
					bIsUISound = true,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"DialogueHUD",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"InGameSFX",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"Weapons1p",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 0.750f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"Weapons3p",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"FaithVocal",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"FaithBreath",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"Dead",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 0.90f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"StereoAmbient",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"BigLooped",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.20f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 2000.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"IndoorAmbientProps",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"IndoorAmbient",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.30f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 3000.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"OutdoorAmbientProps",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"OutdoorAmbient",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"Helicopter",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = true,
					bIsUISound = false,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"Convoy",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 0.80f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = true,
					bIsMusic = true,
					bNoReverb = false,
				},
				GroupName = (name)"HudMusic",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = false,
					bIsUISound = false,
					bIsMusic = true,
					bNoReverb = false,
				},
				GroupName = (name)"CutSceneMusic",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.20f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = false,
					bIsUISound = true,
					bIsMusic = true,
					bNoReverb = false,
				},
				GroupName = (name)"InGameMusic",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = true,
					bUberAlwaysPlay = false,
					bIsUISound = true,
					bIsMusic = true,
					bNoReverb = false,
				},
				GroupName = (name)"TimeTrialMusic",
				ChildGroupNames = default,
			},
			new AudioDevice.SoundGroup
			{
				Properties = new AudioDevice.SoundGroupProperties
				{
					Volume = 1.0f,
					Pitch = 1.0f,
					LowPass = 1.0f,
					MaxUpdateDistance = 0.0f,
					VoiceCenterChannelVolume = 0.0f,
					VoiceRadioVolume = 0.0f,
					bApplyEffects = false,
					bAlwaysPlay = false,
					bUberAlwaysPlay = false,
					bIsUISound = true,
					bIsMusic = false,
					bNoReverb = false,
				},
				GroupName = (name)"HudSFX",
				ChildGroupNames = default,
			},
		};
		SoundGroupEffects = new array</*config */AudioDevice.SoundGroupEffect>
		{
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = default,
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Convoy",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.50f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.60f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.70f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.50f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.70f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.50f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.70f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.50f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.40f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 0.10f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"TimeTrialMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.70f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.40f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.70f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.50f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.20f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.40f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.30f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.30f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.20f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 1.50f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Master",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.60f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.60f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.40f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.40f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Dead",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Dead",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.10f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.0010f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 0.0010f,
					},
				},
			},
			new AudioDevice.SoundGroupEffect
			{
				GroupEffect = new array<AudioDevice.SoundGroupAdjuster>
				{
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Music",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"SFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VO",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"CutSceneMusic",
						VolumeAdjuster = 1.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameMusic",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"AmbientPropSounds",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"HudSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"InGameSFX",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"BigLooped",
						VolumeAdjuster = 0.30f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"VOMain",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueAI",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbient",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueRadio",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueFaith",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"DialogueOther",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"IndoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"OutdoorAmbientProps",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Helicopter",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons3p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"Weapons1p",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithBreath",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
					new AudioDevice.SoundGroupAdjuster
					{
						GroupName = (name)"FaithVocal",
						VolumeAdjuster = 0.0f,
						PitchAdjuster = 1.0f,
						LowPassAdjuster = 1.0f,
					},
				},
			},
		};
		MixGroups = new array</*config */AudioDevice.MixGroupInfo>
		{
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"Default",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"WeaponSounds",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"CharacterSounds",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"AmbientSounds",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"Reverb",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"AIVO",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"AmbientPropSounds",
				Volume = 0.90f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"SlowMotionSounds",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = false,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"Outdoor",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = false,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"Indoor",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = false,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"Helicopter",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = false,
			},
			new AudioDevice.MixGroupInfo
			{
				GroupName = (name)"Breathing",
				Volume = 1.0f,
				Pitch = 1.0f,
				LowPass = 1.0f,
				SloMo = true,
			},
		};
		TransientMasterVolume = 1.0f;
	}
}
}