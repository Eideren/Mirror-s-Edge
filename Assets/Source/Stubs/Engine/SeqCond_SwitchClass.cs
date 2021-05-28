namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqCond_SwitchClass : SeqCond_SwitchBase/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */SwitchClassInfo
	{
		public/*()*/ name ClassName;
		public/*()*/ byte bFallThru;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003D939F
	//		ClassName = (name)"None";
	//		bFallThru = 0;
	//	}
	};
	
	public/*()*/ array<SeqCond_SwitchClass.SwitchClassInfo> ClassArray;
	
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
	
	public SeqCond_SwitchClass()
	{
		// Object Offset:0x003D96C7
		ClassArray = new array<SeqCond_SwitchClass.SwitchClassInfo>
		{
			new SeqCond_SwitchClass.SwitchClassInfo
			{
				ClassName = (name)"Default",
				bFallThru = 0,
			},
		};
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
		ObjName = "Switch Class";
	}
}
}