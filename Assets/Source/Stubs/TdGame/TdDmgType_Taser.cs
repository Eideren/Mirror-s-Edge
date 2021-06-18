namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDmgType_Taser : TdDamageType{
	public float ContiniousTaserDamage;
	public float InitialTaserDamage;
	
	public TdDmgType_Taser()
	{
		var Default__TdDmgType_Taser_ForceFeedbackWaveform0 = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C0E6
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 100,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Noise,
					Duration = 1.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdDmgType_Taser.ForceFeedbackWaveform0' */;
		var Default__TdDmgType_Taser_ForceFeedbackWaveform1 = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C1B4
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 100,
					RightAmplitude = 50,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Noise,
					Duration = 1.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdDmgType_Taser.ForceFeedbackWaveform1' */;
		// Object Offset:0x0054325A
		ContiniousTaserDamage = 7.50f;
		InitialTaserDamage = 30.0f;
		bCausesBlood = false;
		KDamageImpulse = 1000.0f;
		KImpulseRadius = 20.0f;
		DamagedFFWaveform = Default__TdDmgType_Taser_ForceFeedbackWaveform0;
		KilledFFWaveform = Default__TdDmgType_Taser_ForceFeedbackWaveform1;
	}
}
}