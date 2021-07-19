namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Union : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public array< Core.ClassT<SequenceVariable> > SupportedVariableClasses;
	[Category] public int IntValue;
	[Category] public int BoolValue;
	[Category] public float FloatValue;
	[Category] public String StringValue;
	[Category] public Object ObjectValue;
	
	public SeqVar_Union()
	{
		// Object Offset:0x003E164A
		SupportedVariableClasses = new array< Core.ClassT<SequenceVariable> >
		{
			ClassT<SeqVar_Bool>(),
			ClassT<SeqVar_Int>(),
			ClassT<SeqVar_Object>(),
			ClassT<SeqVar_String>(),
			ClassT<SeqVar_Float>(),
		};
		ObjName = "Union";
		ObjColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
	}
}
}