namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdTutorialCompleted : SequenceAction/*
		native
		hidecategories(Object)*/{
	public /*transient */bool bFinished;
	
	public override /*event */void Activated()
	{
	
	}
	
	public virtual /*function */void OnStayInTutorial(bool bStayInTutorial)
	{
	
	}
	
	public SeqAct_TdTutorialCompleted()
	{
		// Object Offset:0x004A3787
		bLatentExecution = true;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "StayInTutorial",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		VariableLinks = default;
		ObjName = "Tutorial Completed";
		ObjCategory = "TdTutorial";
	}
}
}