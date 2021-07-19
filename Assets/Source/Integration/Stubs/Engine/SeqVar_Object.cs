namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Object : SequenceVariable/*
		native
		hidecategories(Object)*/{
	[Category] public/*protected*/ Object ObjValue;
	[Const] public array< Class > SupportedClasses;
	
	public virtual /*function */Object GetObjectValue()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetObjectValue(Object NewValue)
	{
		// stub
	}
	
	public SeqVar_Object()
	{
		// Object Offset:0x003E0068
		SupportedClasses = new array< Class >
		{
			ClassT<Object>(),
		};
		ObjName = "Object";
		ObjCategory = "Object";
		ObjColor = new Color
		{
			R=255,
			G=0,
			B=255,
			A=255
		};
	}
}
}