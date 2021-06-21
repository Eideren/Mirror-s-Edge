namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdEnableReactionTime : SequenceAction/*
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdEnableReactionTime()
	{
		// Object Offset:0x00499486
		ObjName = "Enable Reaction Time";
		ObjCategory = "Takedown";
	}
}
}