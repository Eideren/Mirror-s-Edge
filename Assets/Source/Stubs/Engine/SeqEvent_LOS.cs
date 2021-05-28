namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_LOS : SequenceEvent/*
		hidecategories(Object)*/{
	public/*()*/ float ScreenCenterDistance;
	public/*()*/ float TriggerDistance;
	public/*()*/ bool bCheckForObstructions;
	
	public SeqEvent_LOS()
	{
		// Object Offset:0x003DB231
		ScreenCenterDistance = 50.0f;
		TriggerDistance = 2048.0f;
		bCheckForObstructions = true;
		ObjName = "Line Of Sight";
		ObjCategory = "Pawn";
	}
}
}