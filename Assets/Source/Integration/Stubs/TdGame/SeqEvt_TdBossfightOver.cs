namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdBossfightOver : SequenceEvent/*
		hidecategories(Object)*/{
	public SeqEvt_TdBossfightOver()
	{
		// Object Offset:0x004A76AE
		bPlayerOnly = false;
		ObjName = "Boss fight Over";
		ObjCategory = "AI";
	}
}
}