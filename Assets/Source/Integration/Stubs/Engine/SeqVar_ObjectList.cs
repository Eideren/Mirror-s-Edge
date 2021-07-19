namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_ObjectList : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	[Category] public array<Object> ObjList;
	
	public override /*function */Object GetObjectValue()
	{
		// stub
		return default;
	}
	
	public override /*function */void SetObjectValue(Object NewValue)
	{
		// stub
	}
	
	public SeqVar_ObjectList()
	{
		// Object Offset:0x003E0ADE
		ObjName = "Object List";
		ObjColor = new Color
		{
			R=102,
			G=0,
			B=102,
			A=255
		};
	}
}
}