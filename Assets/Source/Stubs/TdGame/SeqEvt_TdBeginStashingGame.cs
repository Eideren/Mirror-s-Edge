namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdBeginStashingGame : SequenceEvent/*
		hidecategories(Object)*/{
	public SeqEvt_TdBeginStashingGame()
	{
		// Object Offset:0x004A75C6
		bPlayerOnly = false;
		ObjName = "Begin Stashing Game";
		ObjCategory = "Stashing";
	}
}
}