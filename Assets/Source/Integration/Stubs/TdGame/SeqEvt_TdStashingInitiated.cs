namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdStashingInitiated : SeqEvt_TdStashPoint/*
		hidecategories(Object)*/{
	public SeqEvt_TdStashingInitiated()
	{
		// Object Offset:0x004A8394
		bPlayerOnly = false;
		ObjName = "On Initiated";
		ObjCategory = "Stashing";
	}
}
}