namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdCameraShake : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public float Duration;
	[Category] public float Amplitude;
	[Category] public float Frequency;
	[Category] public float BlendIn;
	[Category] public float BlendOut;
	[transient] public TdPlayerPawn PlayerPawn;
	
	public SeqAct_TdCameraShake()
	{
		// Object Offset:0x00496F96
		Duration = -1.0f;
		Amplitude = 1000.0f;
		Frequency = 0.010f;
		BlendIn = 0.10f;
		BlendOut = 0.10f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Start",
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
				LinkDesc = "Stop",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Camera Shake";
		ObjCategory = "Takedown";
	}
}
}