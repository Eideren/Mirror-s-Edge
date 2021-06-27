namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqCond_SwitchObject : SeqCond_SwitchBase/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */SwitchObjectCase
	{
		public/*()*/ Object ObjectValue;
		public/*()*/ bool bFallThru;
		public/*()*/ bool bDefaultValue;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003DA059
	//		ObjectValue = default;
	//		bFallThru = false;
	//		bDefaultValue = false;
	//	}
	};
	
	public/*()*/ array<SeqCond_SwitchObject.SwitchObjectCase> SupportedValues;
	public/*()*/ Class MetaClass;
	
	public override /*event */void VerifyDefaultCaseValue()
	{
		// stub
	}
	
	public override /*event */bool IsFallThruEnabled(int ValueIndex)
	{
		// stub
		return default;
	}
	
	public override /*event */void InsertValueEntry(int InsertIndex)
	{
		// stub
	}
	
	public override /*event */void RemoveValueEntry(int RemoveIndex)
	{
		// stub
	}
	
	public SeqCond_SwitchObject()
	{
		// Object Offset:0x003DA447
		SupportedValues = new array<SeqCond_SwitchObject.SwitchObjectCase>
		{
			new SeqCond_SwitchObject.SwitchObjectCase
			{
				ObjectValue = default,
				bFallThru = false,
				bDefaultValue = true,
			},
		};
		MetaClass = ClassT<Object>()/*Ref Class'Object'*/;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Object",
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
		ObjName = "Switch Object";
	}
}
}