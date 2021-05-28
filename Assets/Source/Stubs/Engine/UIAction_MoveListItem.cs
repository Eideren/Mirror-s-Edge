namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_MoveListItem : UIAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ int ElementIndex;
	public/*()*/ int MoveCount;
	
	public UIAction_MoveListItem()
	{
		// Object Offset:0x0040F09F
		ElementIndex = -1;
		bAutoTargetOwner = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Failure",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Success",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
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
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Player Index",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Gamepad Id",
				LinkVar = (name)"None",
				PropertyName = (name)"GamepadID",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Element Index",
				LinkVar = (name)"None",
				PropertyName = (name)"ElementIndex",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Count",
				LinkVar = (name)"None",
				PropertyName = (name)"MoveCount",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Move Element";
		ObjCategory = "List";
	}
}
}