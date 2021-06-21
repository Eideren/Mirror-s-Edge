namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_Toggle : SequenceAction/*
		native
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_Toggle()
	{
		// Object Offset:0x003D1714
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Turn On",
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
				LinkDesc = "Turn Off",
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
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Target",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Bool>()/*Ref Class'SeqVar_Bool'*/,
				LinkedVariables = default,
				LinkDesc = "Bool",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 0,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		EventLinks = new array<SequenceOp.SeqEventLink>
		{
			new SequenceOp.SeqEventLink
			{
				ExpectedType = ClassT<SequenceEvent>()/*Ref Class'SequenceEvent'*/,
				LinkedEvents = default,
				LinkDesc = "Event",
				DrawX = 0,
				bHidden = false,
			},
		};
		ObjName = "Toggle";
		ObjCategory = "Toggle";
	}
}
}