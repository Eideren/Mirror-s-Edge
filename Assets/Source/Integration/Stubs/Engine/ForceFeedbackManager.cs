namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ForceFeedbackManager : Object/* within PlayerController*//*
		abstract
		transient
		native*/{
	public new PlayerController Outer => base.Outer as PlayerController;
	
	public bool bAllowsForceFeedback;
	public bool bIsPaused;
	public ForceFeedbackWaveform FFWaveform;
	public int CurrentSample;
	public float ElapsedTime;
	public float ScaleAllWaveformsBy;
	
	public virtual /*simulated function */void PlayForceFeedbackWaveform(ForceFeedbackWaveform Waveform)
	{
		// stub
	}
	
	public virtual /*simulated function */void StopForceFeedbackWaveform(/*optional */ForceFeedbackWaveform _Waveform = default)
	{
		// stub
	}
	
	public virtual /*simulated function */void PauseWaveform(/*optional */bool? _bPause = default)
	{
		// stub
	}
	
	public ForceFeedbackManager()
	{
		// Object Offset:0x00320067
		bAllowsForceFeedback = true;
		ScaleAllWaveformsBy = 1.0f;
	}
}
}