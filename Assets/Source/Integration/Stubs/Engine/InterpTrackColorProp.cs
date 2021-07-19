namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackColorProp : InterpTrackVectorBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[Category] [editconst] public name PropertyName;
	
	public InterpTrackColorProp()
	{
		// Object Offset:0x00341A9B
		TrackInstClass = ClassT<InterpTrackInstColorProp>()/*Ref Class'InterpTrackInstColorProp'*/;
		TrackTitle = "Color Property";
	}
}
}