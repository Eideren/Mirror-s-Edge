namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdActivateRopeburnDisarm : SequenceAction/*
		hidecategories(Object)*/{
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdActivateRopeburnDisarm()
	{
		// Object Offset:0x004932C0
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Activate",
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
				LinkDesc = "Deactivate",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "PlayerPawn",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Activate Ropeburn Disarm";
		ObjCategory = "TakeDown";
	}
}
}