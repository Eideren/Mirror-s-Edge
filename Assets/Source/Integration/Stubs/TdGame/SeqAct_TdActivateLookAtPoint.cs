namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdActivateLookAtPoint : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ float LookAtInterpolationTime;
	public/*()*/ float LookAtDuration;
	
	public SeqAct_TdActivateLookAtPoint()
	{
		// Object Offset:0x0049273D
		LookAtInterpolationTime = 1.0f;
		LookAtDuration = 1.0f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Activate",
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
				LinkDesc = "Deactivate",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Activate LookAtPoint";
		ObjCategory = "TakeDown";
	}
}
}