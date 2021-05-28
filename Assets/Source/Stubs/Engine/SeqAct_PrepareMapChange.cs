namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_PrepareMapChange : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public/*()*/ name MainLevelName;
	public/*()*/ array<name> InitiallyLoadedSecondaryLevelNames;
	public/*()*/ bool bIsHighPriority;
	public /*transient */bool bStatusIsOk;
	
	public SeqAct_PrepareMapChange()
	{
		// Object Offset:0x003CAE56
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "PrepareLoad",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Finished",
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
		ObjName = "Prepare Map Change";
		ObjCategory = "Level";
	}
}
}