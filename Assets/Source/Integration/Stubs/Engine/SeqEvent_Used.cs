namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_Used : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public/*()*/ bool bAimToInteract;
	public/*()*/ float InteractDistance;
	public/*()*/ String InteractText;
	public/*()*/ Texture2D InteractIcon;
	
	public SeqEvent_Used()
	{
		// Object Offset:0x003DEC35
		bAimToInteract = true;
		InteractDistance = 128.0f;
		InteractText = "Use";
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Instigator",
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
				ExpectedType = ClassT<SeqVar_Float>()/*Ref Class'SeqVar_Float'*/,
				LinkedVariables = default,
				LinkDesc = "Distance",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Used";
	}
}
}