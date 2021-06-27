namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackFloatProp : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ /*editconst */name PropertyName;
	
	public InterpTrackFloatProp()
	{
		// Object Offset:0x00342743
		TrackInstClass = ClassT<InterpTrackInstFloatProp>()/*Ref Class'InterpTrackInstFloatProp'*/;
		TrackTitle = "Float Property";
	}
}
}