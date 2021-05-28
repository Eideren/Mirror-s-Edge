namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdGiveFullReactionEnergy : SequenceAction/*
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
		return default;
	}
	
	public SeqAct_TdGiveFullReactionEnergy()
	{
		// Object Offset:0x0049B519
		ObjName = "Give Full Reaction Time energy";
		ObjCategory = "Takedown";
	}
}
}