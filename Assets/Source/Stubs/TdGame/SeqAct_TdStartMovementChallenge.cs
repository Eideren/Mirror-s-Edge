namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdStartMovementChallenge : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ TdSPTutorialGame.EMovementChallenge MovementChallege;
	
	public override /*event */void Activated()
	{
	
	}
	
	public SeqAct_TdStartMovementChallenge()
	{
		// Object Offset:0x004A1023
		VariableLinks = default;
		ObjName = "Start MovementChallenge";
		ObjCategory = "Takedown";
	}
}
}