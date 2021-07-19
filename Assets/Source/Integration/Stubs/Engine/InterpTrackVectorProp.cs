namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackVectorProp : InterpTrackVectorBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[Category] [editconst] public name PropertyName;
	
	public InterpTrackVectorProp()
	{
		// Object Offset:0x003443F3
		TrackInstClass = ClassT<InterpTrackInstVectorProp>()/*Ref Class'InterpTrackInstVectorProp'*/;
		TrackTitle = "Vector Property";
	}
}
}