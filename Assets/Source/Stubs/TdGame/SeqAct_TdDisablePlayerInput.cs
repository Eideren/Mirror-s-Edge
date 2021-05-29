namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdDisablePlayerInput : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ bool bSetCinematicMode;
	public/*()*/ bool bDisableSkipCutscenes;
	public/*()*/ bool bDisablePlayerMoveInput;
	public/*()*/ bool bDisablePlayerLookInput;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
	
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