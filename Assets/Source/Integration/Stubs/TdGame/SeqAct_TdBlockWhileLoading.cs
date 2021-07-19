namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdBlockWhileLoading : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public bool bOnlyInSpeedrun;
	
	public SeqAct_TdBlockWhileLoading()
	{
		// Object Offset:0x00496B40
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
		};
		OutputLinks = default;
		ObjClassVersion = 2;
		ObjName = "BlockWhileLoading";
		ObjCategory = "Takedown";
	}
}
}