namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ForceFeedbackWaveform : Object/*
		native
		editinlinenew
		noexport*/{
	public enum EWaveformFunction 
	{
		WF_Constant,
		WF_LinearIncreasing,
		WF_LinearDecreasing,
		WF_Sin0to90,
		WF_Sin90to180,
		WF_Sin0to180,
		WF_Noise,
		WF_MAX
	};
	
	public partial struct /*native */WaveformSample
	{
		public/*()*/ byte LeftAmplitude;
		public/*()*/ byte RightAmplitude;
		public/*()*/ ForceFeedbackWaveform.EWaveformFunction LeftFunction;
		public/*()*/ ForceFeedbackWaveform.EWaveformFunction RightFunction;
		public/*()*/ float Duration;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003202A6
	//		LeftAmplitude = 0;
	//		RightAmplitude = 0;
	//		LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant;
	//		RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant;
	//		Duration = 0.0f;
	//	}
	};
	
	public/*()*/ bool bIsLooping;
	public/*()*/ array<ForceFeedbackWaveform.WaveformSample> Samples;
	
}
}