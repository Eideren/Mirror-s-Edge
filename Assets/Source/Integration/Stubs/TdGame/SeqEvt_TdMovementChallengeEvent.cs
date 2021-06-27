namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdMovementChallengeEvent : SequenceEvent/*
		abstract
		hidecategories(Object)*/{
	public/*(MovementChallenge)*/ TdSPTutorialGame.EMovementChallenge MovementChallenge;
	
	public SeqEvt_TdMovementChallengeEvent()
	{
		// Object Offset:0x004A7C3D
		MaxTriggerCount = 0;
		bPlayerOnly = false;
		ObjCategory = "Tutorial Challenge";
	}
}
}