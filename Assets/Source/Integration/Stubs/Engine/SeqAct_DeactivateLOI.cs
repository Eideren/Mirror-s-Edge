namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_DeactivateLOI : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ float FadeOutSpeed;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_DeactivateLOI()
	{
		// Object Offset:0x003C05B3
		FadeOutSpeed = 4.0f;
		ObjName = "Deactivate Level of Iteraction";
		ObjCategory = "LOI";
	}
}
}