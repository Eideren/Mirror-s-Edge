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
		[Category] public name ParamName;
		[Category] public float FloatParam;
		[Category] public SoundNodeWave WaveParam;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0028E5EE
	//		ParamName = (name)"None";
	//		FloatParam = 0.0f;
	//		WaveParam = default;
	//	}
	};
	
	[Category] public SoundCue SoundCue;
	[native, Const] public SoundNode CueFirstNode;
	[Category] [editinline] public array</*editinline */AudioComponent.AudioComponentParam> InstanceParameters;
	public bool bUseOwnerLocation;
	public bool bAutoPlay;
	public bool bAutoDestroy;
	public bool bStopWhenOwnerDestroyed;
	public bool bShouldRemainActiveIfDropped;
	[transient] public bool bWasOccluded;
	[transient] public bool bSuppressSubtitles;
	[transient] public bool bWasPlaying;
	[native, Const] public bool bApplyEffects;
	[native] public bool bAlwaysPlay;
	[native] public bool bUberAlwaysPlay;
	public bool bAllowSpatialization;
	public bool bIsUISound;
	[transient] public bool bIsMusic;
	[transient] public bool bNoReverb;
	[transient] public bool bFinished;
	[transient] public bool bIgnoreForFlushing;
	[duplicatetransient, native, Const] public array<Object.Pointer> WaveInstances;
	[duplicatetransient, native, Const] public array<byte> SoundNodeData;
	[duplicatetransient, native, Const] public /*map<0,0>*/map<object, object> SoundNodeOffsetMap;
	[duplicatetransient, native, Const] public Object.MultiMap_Mirror SoundNodeResetWaveMap;
	[duplicatetransient, native, Const] public Object.Pointer Listener;
	[duplicatetransient, native, Const] public float PlaybackTime;
	[duplicatetransient, native, Const] public PortalVolume PortalVolume;
	[duplicatetransient, native] public Object.Vector Location;
	[duplicatetransient, native, Const] public Object.Vector ComponentLocation;
	[duplicatetransient, native] public Object.Vector LocationOffset;
	public bool bDebugOffset;
	[native] public float SubtitlePriority;
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
	[native, Const] public SoundNode CurrentNotifyBufferFinishedHook;
	[native, Const] public Object.Vector CurrentLocation;
	[native, Const] public float CurrentVolume;
	[native, Const] public float CurrentPitch;
	[native, Const] public float CurrentHighFrequencyGain;
	[native, Const] public int CurrentUseSpatialization;
	[native, Const] public int CurrentUseSeamlessLooping;
	[native, Const] public float CurrentVolumeMultiplier;
	[native, Const] public float CurrentPitchMultiplier;
	[native, Const] public float CurrentVoiceCenterChannelVolume;
	[native, Const] public float CurrentVoiceRadioVolume;
	[Category] public float VolumeMultiplier;
	[Category] public float PitchMultiplier;
	[native, Const] public float CurrentHighFrequencyGainMultiplier;
	[Category] public float LowPassMultiplier;
	[transient] public float AdjustLowPassStartTime;
	[transient] public float AdjustLowPassStopTime;
	[transient] public float AdjustLowPassTargetLevel;
	[transient] public float CurrAdjustLowPassLevel;
	[Category] public float OcclusionVolumeDuckLevel;
	[Category] public float OcclusionFilterDuckLevel;
	[Category] public float OcclusionFadeTime;
	[Category] public float OcclusionCheckInterval;
	[transient] public float LastOcclusionCheckTime;
	[Const, export, editinline] public DrawSoundRadiusComponent PreviewSoundRadius;
	public /*delegate*/AudioComponent.OnAudioFinished __OnAudioFinished__Delegate;
	
	// Export UAudioComponent::execPlay(FFrame&, void* const)
	public virtual /*native final function */void Play()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execStop(FFrame&, void* const)
	public virtual /*native final function */void Stop()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execIsPlaying(FFrame&, void* const)
	public virtual /*native final function */bool IsPlaying()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UAudioComponent::execFadeIn(FFrame&, void* const)
	public virtual /*native final function */void FadeIn(float FadeInDuration, float FadeVolumeLevel)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execFadeOut(FFrame&, void* const)
	public virtual /*native final function */void FadeOut(float FadeOutDuration, float FadeVolumeLevel)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execAdjustVolume(FFrame&, void* const)
	public virtual /*native final function */void AdjustVolume(float AdjustVolumeDuration, float AdjustVolumeLevel)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execAdjustLowPassFiltering(FFrame&, void* const)
	public virtual /*native final function */void AdjustLowPassFiltering(float AdjustLowPassDuration, float AdjustLowPassLevel)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execSetFloatParameter(FFrame&, void* const)
	public virtual /*native final function */void SetFloatParameter(name InName, float InFloat)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execSetWaveParameter(FFrame&, void* const)
	public virtual /*native final function */void SetWaveParameter(name InName, SoundNodeWave InWave)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAudioComponent::execResetToDefaults(FFrame&, void* const)
	public virtual /*native final function */void ResetToDefaults()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate void OnAudioFinished(AudioComponent AC);
	
	public virtual /*event */void OcclusionChanged(bool bNowOccluded)
	{
		// stub
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