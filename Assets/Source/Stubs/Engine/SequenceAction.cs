namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceAction : SequenceOp/*
		abstract
		native
		hidecategories(Object)*/{
	public name HandlerName;
	public bool bCallHandler;
	public/*()*/ array<Object> Targets;
	
	public SequenceAction()
	{
		// Object Offset:0x003B5286
		bCallHandler = true;
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
		};
		ObjName = "Unknown Action";
		ObjColor = new Color
		{
			R=255,
			G=0,
			B=255,
			A=255
		};
	}
}
}