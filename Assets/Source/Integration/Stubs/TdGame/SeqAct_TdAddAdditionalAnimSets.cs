namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdAddAdditionalAnimSets : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ bool bIsFirstPerson;
	public/*()*/ bool bRemoveAdditionalAnimSets;
	public/*()*/ array<AnimSet> AnimationSets;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdAddAdditionalAnimSets()
	{
		// Object Offset:0x004956EC
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Completed",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Additional AnimSets";
		ObjCategory = "Takedown";
	}
}
}