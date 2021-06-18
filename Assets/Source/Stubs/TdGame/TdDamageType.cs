namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDamageType : DamageType/*
		abstract*/{
	public /*editinline */array</*editinline */name> PhysicsImpactSpringList;
	public /*editinline */array</*editinline */name> PhysicsBodyImpactBoneList;
	public float PhysicsHitReactionBlendOutTime;
	public float PhysicsHitReactionDuration;
	public Object.Vector2D PhysHitReactionMotorStrength;
	public Object.Vector2D PhysHitReactionSpringStrength;
	public bool bCausePhysicalHitReaction;
	
	public TdDamageType()
	{
		var Default__TdDamageType_ForceFeedbackWaveform0 = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6BDAE
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 50,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Noise,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdDamageType.ForceFeedbackWaveform0' */;
		var Default__TdDamageType_ForceFeedbackWaveform1 = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6BE7C
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 50,
					RightAmplitude = 50,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.750f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdDamageType.ForceFeedbackWaveform1' */;
		// Object Offset:0x0053EC76
		PhysicsBodyImpactBoneList = new array</*editinline */name>
		{
			(name)"Spine",
			(name)"Spine1",
			(name)"Spine2",
			(name)"Neck",
			(name)"LeftShoulder",
			(name)"LeftArm",
			(name)"LeftForeArm",
			(name)"LeftHand",
			(name)"RightShoulder",
			(name)"RightArm",
			(name)"RightForeArm",
			(name)"RightHand",
		};
		PhysicsHitReactionBlendOutTime = 0.30f;
		PhysicsHitReactionDuration = 0.40f;
		PhysHitReactionMotorStrength = new Vector2D
		{
			X=20000.0f,
			Y=20000.0f
		};
		bCausePhysicalHitReaction = true;
		bNeverGibs = true;
		KDamageImpulse = 50000.0f;
		KDeathUpKick = 50.0f;
		KImpulseRadius = 0.0f;
		DamagedFFWaveform = Default__TdDamageType_ForceFeedbackWaveform0;
		KilledFFWaveform = Default__TdDamageType_ForceFeedbackWaveform1;
	}
}
}