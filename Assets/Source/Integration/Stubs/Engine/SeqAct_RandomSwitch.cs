namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_RandomSwitch : SeqAct_Switch/*
		native
		hidecategories(Object)*/{
	public array<int> AutoDisabledIndices;
	
	public SeqAct_RandomSwitch()
	{
		// Object Offset:0x003CB72A
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Active Link",
				LinkVar = (name)"None",
				PropertyName = (name)"Indices",
				bWriteable = true,
				bHidden = false,
				MinVars = 0,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Random";
	}
}
}