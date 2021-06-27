namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ActivateRemoteEvent : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ Actor Instigator;
	public/*()*/ name EventName;
	public /*transient */bool bStatusIsOk;
	
	public SeqAct_ActivateRemoteEvent()
	{
		// Object Offset:0x003B571C
		EventName = (name)"DefaultEvent";
		OutputLinks = default;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Instigator",
				LinkVar = (name)"None",
				PropertyName = (name)"Instigator",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 2;
		ObjName = "Activate Remote Event";
		ObjCategory = "Event";
	}
}
}