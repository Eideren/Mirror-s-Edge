namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetMotionBlurParams : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public/*()*/ float MotionBlurAmount;
	public/*()*/ float InterpolateSeconds;
	public float InterpolateElapsed;
	public float OldMotionBlurAmount;
	
	public SeqAct_SetMotionBlurParams()
	{
		// Object Offset:0x003CE1F9
		MotionBlurAmount = 0.10f;
		InterpolateSeconds = 2.0f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Enable",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Disable",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Motion Blur";
		ObjCategory = "Camera";
	}
}
}