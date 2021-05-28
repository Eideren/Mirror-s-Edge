namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetVector : SeqAct_SetSequenceVariable/*
		hidecategories(Object)*/{
	public/*()*/ Object.Vector DefaultValue;
	
	public override /*event */void Activated()
	{
	
	}
	
	public SeqAct_SetVector()
	{
		// Object Offset:0x003CFC9C
		bCallHandler = false;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Vector>()/*Ref Class'SeqVar_Vector'*/,
				LinkedVariables = default,
				LinkDesc = "Target",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Vector>()/*Ref Class'SeqVar_Vector'*/,
				LinkedVariables = default,
				LinkDesc = "Value",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Vector";
	}
}
}