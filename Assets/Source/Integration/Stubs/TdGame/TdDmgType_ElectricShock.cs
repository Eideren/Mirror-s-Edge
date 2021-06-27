namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDmgType_ElectricShock : TdDamageType{
	public float DamageImpulse;
	public float DamageZDirection;
	
	public TdDmgType_ElectricShock()
	{
		var Default__TdDmgType_ElectricShock_ForceFeedbackWaveform0 = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6BF4A
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
		}/* Reference: ForceFeedbackWaveform'Default__TdDmgType_ElectricShock.ForceFeedbackWaveform0' */;
		var Default__TdDmgType_ElectricShock_ForceFeedbackWaveform1 = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6C018
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
		}/* Reference: ForceFeedbackWaveform'Default__TdDmgType_ElectricShock.ForceFeedbackWaveform1' */;
		// Object Offset:0x005426A8
		DamageImpulse = 300.0f;
		DamageZDirection = 0.20f;
		bCausePhysicalHitReaction = false;
		bExtraMomentumZ = false;
		DamagedFFWaveform = Default__TdDmgType_ElectricShock_ForceFeedbackWaveform0/*Ref ForceFeedbackWaveform'Default__TdDmgType_ElectricShock.ForceFeedbackWaveform0'*/;
		KilledFFWaveform = Default__TdDmgType_ElectricShock_ForceFeedbackWaveform1/*Ref ForceFeedbackWaveform'Default__TdDmgType_ElectricShock.ForceFeedbackWaveform1'*/;
	}
}
}