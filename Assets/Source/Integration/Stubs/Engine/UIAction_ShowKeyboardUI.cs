namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowKeyboardUI : UIAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ String TitleText;
	public/*()*/ String DefaultText;
	public/*()*/ String DescriptionText;
	public/*()*/ bool bShouldValidate;
	public/*()*/ bool bIsPassword;
	public bool bIsDone;
	public String StringReturnValue;
	public String TempStringReturnValue;
	
	public virtual /*event */void ReadKeyboardInput()
	{
		// stub
	}
	
	public virtual /*function */void OnKeyboardInputDone(bool bWasSuccessful)
	{
		// stub
	}
	
	public UIAction_ShowKeyboardUI()
	{
		// Object Offset:0x00417C0A
		bShouldValidate = true;
		bLatentExecution = true;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Out",
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
				LinkDesc = "Finished",
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
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "Title Text",
				LinkVar = (name)"None",
				PropertyName = (name)"TitleText",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "Description Text",
				LinkVar = (name)"None",
				PropertyName = (name)"DescriptionText",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "Default Text",
				LinkVar = (name)"None",
				PropertyName = (name)"DefaultText",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Bool>()/*Ref Class'SeqVar_Bool'*/,
				LinkedVariables = default,
				LinkDesc = "Needs Validation",
				LinkVar = (name)"None",
				PropertyName = (name)"bShouldValidate",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "String Return Value",
				LinkVar = (name)"None",
				PropertyName = (name)"StringReturnValue",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 2;
		ObjName = "Get Keyboard Input";
		ObjCategory = "Online";
	}
}
}