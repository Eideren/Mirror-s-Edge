namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_AttachToEvent : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ bool bPreferController;
	
	public SeqAct_AttachToEvent()
	{
		// Object Offset:0x003B8FC7
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Attachee",
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
		ObjName = "Attach To Event";
		ObjCategory = "Event";
	}
}
}