namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_FinishSequence : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public String OutputLabel;
	
	public SeqAct_FinishSequence()
	{
		// Object Offset:0x003C223E
		OutputLabel = "Default Output";
		OutputLinks = default;
		VariableLinks = default;
		ObjName = "Finish Sequence";
		ObjCategory = "Misc";
	}
}
}