namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ActivateLOI : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ float FadeInSpeed;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_ActivateLOI()
	{
		// Object Offset:0x003B559C
		FadeInSpeed = 1.0f;
		ObjName = "Activate Level of Iteraction";
		ObjCategory = "LOI";
	}
}
}