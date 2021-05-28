namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ToggleCinematicMode : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ bool bDisableMovement;
	public/*()*/ bool bDisableTurning;
	public/*()*/ bool bHidePlayer;
	public/*()*/ bool bDisableInput;
	public/*()*/ bool bHideHUD;
	public/*()*/ bool bSwitchSoundMode;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
		return default;
	}
	
	public SeqAct_ToggleCinematicMode()
	{
		// Object Offset:0x003D2441
		bDisableMovement = true;
		bDisableTurning = true;
		bHidePlayer = true;
		bDisableInput = true;
		bHideHUD = true;
		bSwitchSoundMode = true;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Enable",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Disable",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Toggle",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Toggle Cinematic Mode";
		ObjCategory = "Toggle";
	}
}
}