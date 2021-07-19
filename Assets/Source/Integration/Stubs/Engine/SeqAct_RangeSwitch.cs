namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_RangeSwitch : SequenceAction/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */SwitchRange
	{
		[Category] public int Min;
		[Category] public int Max;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003CB9B8
	//		Min = 0;
	//		Max = 0;
	//	}
	};
	
	[Category] [editinline] public array</*editinline */SeqAct_RangeSwitch.SwitchRange> Ranges;
	
	public SeqAct_RangeSwitch()
	{
		// Object Offset:0x003CBA58
		OutputLinks = default;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Index",
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
		ObjName = "Ranged";
		ObjCategory = "Switch";
	}
}
}