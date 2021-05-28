namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdInterceptStashing : SequenceAction/*
		hidecategories(Object)*/{
	public TdStashpoint Stashpoint;
	
	public override /*event */void Activated()
	{
	
	}
	
	public SeqAct_TdInterceptStashing()
	{
		// Object Offset:0x0049C9C1
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Stashpoint",
				LinkVar = (name)"None",
				PropertyName = (name)"Stashpoint",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Intercept Stashing";
		ObjCategory = "Stashing";
	}
}
}