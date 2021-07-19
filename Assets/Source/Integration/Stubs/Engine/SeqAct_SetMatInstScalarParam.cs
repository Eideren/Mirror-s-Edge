namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetMatInstScalarParam : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public MaterialInstanceConstant MatInst;
	[Category] public name ParamName;
	[Category] public float ScalarValue;
	
	public SeqAct_SetMatInstScalarParam()
	{
		// Object Offset:0x003CDBE9
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Float>()/*Ref Class'SeqVar_Float'*/,
				LinkedVariables = default,
				LinkDesc = "ScalarValue",
				LinkVar = (name)"None",
				PropertyName = (name)"ScalarValue",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Set ScalarParam";
		ObjCategory = "Material Instance";
	}
}
}