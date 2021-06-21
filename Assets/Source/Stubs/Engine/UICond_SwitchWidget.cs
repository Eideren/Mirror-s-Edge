namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UICond_SwitchWidget : SeqCond_SwitchObject/*
		hidecategories(Object)*/{
	public override /*event */bool IsValidLevelSequenceObject()
	{
		// stub
		return default;
	}
	
	public UICond_SwitchWidget()
	{
		// Object Offset:0x0041E3B1
		MetaClass = ClassT<UIScreenObject>()/*Ref Class'UIScreenObject'*/;
		ObjName = "Switch Widget";
	}
}
}