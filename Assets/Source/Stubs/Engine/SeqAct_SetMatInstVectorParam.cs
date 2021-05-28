namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetMatInstVectorParam : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ MaterialInstanceConstant MatInst;
	public/*()*/ name ParamName;
	public/*()*/ Object.LinearColor VectorValue;
	
	public SeqAct_SetMatInstVectorParam()
	{
		// Object Offset:0x003CE02C
		VectorValue = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		VariableLinks = default;
		ObjName = "Set VectorParam";
		ObjCategory = "Material Instance";
	}
}
}