namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqCond_SwitchName : SeqCond_SwitchBase/*
		abstract
		native
		hidecategories(Object)*/{
	public partial struct /*native */SwitchNameCase
	{
		public/*()*/ name NameValue;
		public/*()*/ bool bFallThru;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003D99E3
	//		NameValue = (name)"None";
	//		bFallThru = false;
	//	}
	};
	
	public/*()*/ array<SeqCond_SwitchName.SwitchNameCase> SupportedValues;
	
	public override /*event */void VerifyDefaultCaseValue()
	{
	
	}
	
	public override /*event */bool IsFallThruEnabled(int ValueIndex)
	{
	
		return default;
	}
	
	public override /*event */void InsertValueEntry(int InsertIndex)
	{
	
	}
	
	public override /*event */void RemoveValueEntry(int RemoveIndex)
	{
	
	}
	
	public SeqCond_SwitchName()
	{
		// Object Offset:0x003D9D07
		SupportedValues = new array<SeqCond_SwitchName.SwitchNameCase>
		{
			new SeqCond_SwitchName.SwitchNameCase
			{
				NameValue = (name)"Default",
				bFallThru = false,
			},
		};
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Name>()/*Ref Class'SeqVar_Name'*/,
				LinkedVariables = default,
				LinkDesc = "Name Value",
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
		ObjName = "Switch Name";
	}
}
}