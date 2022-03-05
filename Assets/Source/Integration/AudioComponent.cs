namespace MEdge.Engine
{
	using System.Collections.Generic;
	using Core;

	// This is a huge stub, nothing is as it is in the source

	public partial class AudioComponent
	{
		public event System.Action _Play, _Stop;
		public event System.Action<float, float> _FadeIn, _FadeOut, _AdjustVolume;
		
		// Export UAudioComponent::execPlay(FFrame&, void* const)
		public virtual /*native final function */void Play()
		{
			_Play();
			// stub
		}
	
		// Export UAudioComponent::execStop(FFrame&, void* const)
		public virtual /*native final function */void Stop()
		{
			_Stop();
			// stub
		}
	
		// Export UAudioComponent::execFadeIn(FFrame&, void* const)
		public virtual /*native final function */void FadeIn(float FadeInDuration, float FadeVolumeLevel)
		{
			_FadeIn(FadeInDuration, FadeVolumeLevel);
			// stub
		}
	
		// Export UAudioComponent::execFadeOut(FFrame&, void* const)
		public virtual /*native final function */void FadeOut(float FadeOutDuration, float FadeVolumeLevel)
		{
			_FadeOut(FadeOutDuration, FadeVolumeLevel);
			// stub
		}
	
		// Export UAudioComponent::execAdjustVolume(FFrame&, void* const)
		public virtual /*native final function */void AdjustVolume(float AdjustVolumeDuration, float AdjustVolumeLevel)
		{
			_AdjustVolume(AdjustVolumeDuration, AdjustVolumeLevel);
			// stub
		}
	}
}