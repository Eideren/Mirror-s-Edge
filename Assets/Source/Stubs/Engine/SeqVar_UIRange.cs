namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_UIRange : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public/*()*/ UIRoot.UIRangeData RangeValue;
	
	public override /*event */bool IsValidLevelSequenceObject()
	{
	
		return default;
	}
	
	public SeqVar_UIRange()
	{
		// Object Offset:0x003E141B
		ObjName = "UI Range";
		ObjCategory = "UI";
		ObjColor = new Color
		{
			R=128,
			G=128,
			B=192,
			A=255
		};
	}
}
}