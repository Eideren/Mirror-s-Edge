namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AudioComponent : ActorComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object,ActorComponent)*/{
	public partial struct /*native */AudioComponentParam
	{
		public/*()*/ name ParamName;
		public/*()*/ float FloatParam;
		public/*()*/ SoundNodeWave WaveParam;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0028E5EE
	//		ParamName = (name)"None";
	//		FloatParam = 0.0f;
	//		WaveParam = default;
	//	}
	};
	
	public/*()*/ SoundCue SoundCue;
	public /*native const */SoundNode CueFirstNode;
	public/*()*/ /*editinline */array</*editinline */AudioComponent.AudioComponentParam> InstanceParameters;
	public bool bUseOwnerLocation;
	public bool bAutoPlay;
	public bool bAutoDestroy;
	public bool bStopWhenOwnerDestroyed;
	public bool bShouldRemainActiveIfDropped;
	public /*transient */bool bWasOccluded;
	public /*transient */bool bSuppressSubtitles;
	public /*transient */bool bWasPlaying;
	public /*native const */bool bApplyEffects;
	public /*native */bool bAlwaysPlay;
	public /*native */bool bUberAlwaysPlay;
	public bool bAllowSpatialization;
	public bool bIsUISound;
	public /*transient */bool bIsMusic;
	public /*transient */bool bNoReverb;
	public /*transient */bool bFinished;
	public /*transient */bool bIgnoreForFlushing;
	public /*duplicatetransient native const */array<Object.Pointer> WaveInstances;
	public /*duplicatetransient native const */array<byte> SoundNodeData;
	public /*duplicatetransient native const *//*map<0,0>*/map<object, object> SoundNodeOffsetMap;
	public /*duplicatetransient native const */Object.MultiMap_Mirror SoundNodeResetWaveMap;
	public /*duplicatetransient native const */Object.Pointer Listener;
	public /*duplicatetransient native const */float PlaybackTime;
	public /*duplicatetransient native const */PortalVolume PortalVolume;
	public /*duplicatetransient native */Object.Vector Location;
	public /*duplicatetransient native const */Object.Vector ComponentLocation;
	public /*duplicatetransient native */Object.Vector LocationOffset;
	public bool bDebugOffset;
	public /*native */float SubtitlePriority;
	public float FadeInStartTime;
	public float FadeInStopTime;
	public float FadeInTargetVolume;
	public float FadeOutStartTime;
	public float FadeOutStopTime;
	public float FadeOutTargetVolume;
	public float AdjustVolumeStartTime;
	public float AdjustVolumeStopTime;
	public float AdjustVolumeTargetVolume;
	public float CurrAdjustVolumeTargetVolume;
	public /*native const */SoundNode CurrentNotifyBufferFinishedHook;
	public /*native const */Object.Vector CurrentLocation;
	public /*native const */float CurrentVolume;
	public /*native const */float CurrentPitch;
	public /*native const */float CurrentHighFrequencyGain;
	public /*native const */int CurrentUseSpatialization;
	public /*native const */int CurrentUseSeamlessLooping;
	public /*native const */float CurrentVolumeMultiplier;
	public /*native const */float CurrentPitchMultiplier;
	public /*native const */float CurrentVoiceCenterChannelVolume;
	public /*native const */float CurrentVoiceRadioVolume;
	public/*()*/ float VolumeMultiplier;
	public/*()*/ float PitchMultiplier;
	public /*native const */float CurrentHighFrequencyGainMultiplier;
	public/*()*/ float LowPassMultiplier;
	public /*transient */float AdjustLowPassStartTime;
	public /*transient */float AdjustLowPassStopTime;
	public /*transient */float AdjustLowPassTargetLevel;
	public /*transient */float CurrAdjustLowPassLevel;
	public/*()*/ float OcclusionVolumeDuckLevel;
	public/*()*/ float OcclusionFilterDuckLevel;
	public/*()*/ float OcclusionFadeTime;
	public/*()*/ float OcclusionCheckInterval;
	public /*transient */float LastOcclusionCheckTime;
	public /*const export editinline */DrawSoundRadiusComponent PreviewSoundRadius;
	public /*delegate*/AudioComponent.OnAudioFinished __OnAudioFinished__Delegate;
	
	// Export UAudioComponent::execPlay(FFrame&, void* const)
	public virtual /*native final function */void Play()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execStop(FFrame&, void* const)
	public virtual /*native final function */void Stop()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execIsPlaying(FFrame&, void* const)
	public virtual /*native final function */bool IsPlaying()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAudioComponent::execFadeIn(FFrame&, void* const)
	public virtual /*native final function */void FadeIn(float FadeInDuration, float FadeVolumeLevel)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execFadeOut(FFrame&, void* const)
	public virtual /*native final function */void FadeOut(float FadeOutDuration, float FadeVolumeLevel)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execAdjustVolume(FFrame&, void* const)
	public virtual /*native final function */void AdjustVolume(float AdjustVolumeDuration, float AdjustVolumeLevel)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execAdjustLowPassFiltering(FFrame&, void* const)
	public virtual /*native final function */void AdjustLowPassFiltering(float AdjustLowPassDuration, float AdjustLowPassLevel)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execSetFloatParameter(FFrame&, void* const)
	public virtual /*native final function */void SetFloatParameter(name InName, float InFloat)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execSetWaveParameter(FFrame&, void* const)
	public virtual /*native final function */void SetWaveParameter(name InName, SoundNodeWave InWave)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAudioComponent::execResetToDefaults(FFrame&, void* const)
	public virtual /*native final function */void ResetToDefaults()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnAudioFinished(AudioComponent AC);
	
	public virtual /*event */void OcclusionChanged(bool bNowOccluded)
	{
	
	}
	
	public AudioComponent()
	{
		// Object Offset:0x0028EC98
		bUseOwnerLocation = true;
		bAllowSpatialization = true;
		FadeInStopTime = -1.0f;
		FadeInTargetVolume = 1.0f;
		FadeOutStopTime = -1.0f;
		FadeOutTargetVolume = 1.0f;
		AdjustVolumeStopTime = -1.0f;
		AdjustVolumeTargetVolume = 1.0f;
		CurrAdjustVolumeTargetVolume = 1.0f;
		VolumeMultiplier = 1.0f;
		PitchMultiplier = 1.0f;
		LowPassMultiplier = 1.0f;
		AdjustLowPassStartTime = -1.0f;
		AdjustLowPassStopTime = -1.0f;
		AdjustLowPassTargetLevel = 1.0f;
		CurrAdjustLowPassLevel = 1.0f;
		OcclusionVolumeDuckLevel = 0.30f;
		OcclusionFilterDuckLevel = 0.30f;
		OcclusionFadeTime = 1.0f;
	}
}
}