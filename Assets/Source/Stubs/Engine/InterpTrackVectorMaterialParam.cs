namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackVectorMaterialParam : InterpTrackVectorBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ name ParamName;
	
	public InterpTrackVectorMaterialParam()
	{
		// Object Offset:0x00344302
		TrackInstClass = ClassT<InterpTrackInstVectorMaterialParam>()/*Ref Class'InterpTrackInstVectorMaterialParam'*/;
		TrackTitle = "Vector Material Param";
	}
}
}