namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdStringToName : UIAction/*
		hidecategories(Object)*/{
	public/*()*/ string TheString;
	public/*()*/ name TheName;
	
	public override /*event */void Activated()
	{
	
	}
	
	public UIAction_TdStringToName()
	{
		// Object Offset:0x006D6FF1
		bAutoTargetOwner = true;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "String",
				LinkVar = (name)"None",
				PropertyName = (name)"TheString",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Name>()/*Ref Class'SeqVar_Name'*/,
				LinkedVariables = default,
				LinkDesc = "Name",
				LinkVar = (name)"None",
				PropertyName = (name)"TheName",
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
		};
		ObjName = "TdStringToName";
		ObjCategory = "Takedown";
	}
}
}