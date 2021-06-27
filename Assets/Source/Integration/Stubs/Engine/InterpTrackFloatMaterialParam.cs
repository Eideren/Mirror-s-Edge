namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackFloatMaterialParam : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ name ParamName;
	
	public InterpTrackFloatMaterialParam()
	{
		// Object Offset:0x00342563
		TrackInstClass = ClassT<InterpTrackInstFloatMaterialParam>()/*Ref Class'InterpTrackInstFloatMaterialParam'*/;
		TrackTitle = "Float Material Param";
	}
}
}