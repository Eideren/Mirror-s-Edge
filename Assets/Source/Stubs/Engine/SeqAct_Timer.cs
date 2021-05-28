namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_Timer : SequenceAction/*
		native
		hidecategories(Object)*/{
	public /*transient */float ActivationTime;
	public/*()*/ float Time;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
		return default;
	}
	
	public SeqAct_Timer()
	{
		// Object Offset:0x003D1235
		bLatentExecution = true;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Start",
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
				LinkDesc = "Stop",
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
				ExpectedType = ClassT<SeqVar_Float>()/*Ref Class'SeqVar_Float'*/,
				LinkedVariables = default,
				LinkDesc = "Time",
				LinkVar = (name)"None",
				PropertyName = (name)"Time",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Timer";
		ObjCategory = "Misc";
	}
}
}