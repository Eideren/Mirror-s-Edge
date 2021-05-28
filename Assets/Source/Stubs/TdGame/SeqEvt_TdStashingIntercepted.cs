namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdStashingIntercepted : SeqEvt_TdStashPoint/*
		hidecategories(Object)*/{
	public SeqEvt_TdStashingIntercepted()
	{
		// Object Offset:0x004A8475
		bPlayerOnly = false;
		ObjName = "On Intercepted";
		ObjCategory = "Stashing";
	}
}
}