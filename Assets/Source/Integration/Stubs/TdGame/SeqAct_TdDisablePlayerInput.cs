namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdDisablePlayerInput : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public bool bSetCinematicMode;
	[Category] public bool bDisableSkipCutscenes;
	[Category] public bool bDisablePlayerMoveInput;
	[Category] public bool bDisablePlayerLookInput;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdDisablePlayerInput()
	{
		// Object Offset:0x00497AD4
		bSetCinematicMode = true;
		bDisablePlayerMoveInput = true;
		bDisablePlayerLookInput = true;
		ObjName = "Disable Player Input";
		ObjCategory = "Takedown";
	}
}
}