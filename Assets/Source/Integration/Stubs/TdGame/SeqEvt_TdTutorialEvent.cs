namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdTutorialEvent : SeqEvt_TdMovementChallengeEvent/*
		hidecategories(Object)*/{
	[Category] public array<TdSPTutorialGame.ETutorialEvents> TutorialEvents;
	
	public SeqEvt_TdTutorialEvent()
	{
		// Object Offset:0x004A86B2
		ObjName = "Tutorial Event";
	}
}
}