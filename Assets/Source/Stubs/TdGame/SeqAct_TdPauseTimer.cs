namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdPauseTimer : SequenceAction/*
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdPauseTimer()
	{
		// Object Offset:0x0049D9D7
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Pause",
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
				LinkDesc = "Unpause",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Pause SR Timer";
		ObjCategory = "Takedown";
	}
}
}