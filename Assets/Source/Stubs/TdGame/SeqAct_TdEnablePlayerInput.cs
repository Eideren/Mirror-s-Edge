namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdEnablePlayerInput : SequenceAction/*
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
	
		return default;
	}
	
	public SeqAct_TdEnablePlayerInput()
	{
		// Object Offset:0x0049930D
		ObjName = "Enable Player Input";
		ObjCategory = "Takedown";
	}
}
}