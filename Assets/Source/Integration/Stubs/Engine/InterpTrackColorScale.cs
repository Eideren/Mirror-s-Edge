namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackColorScale : InterpTrackVectorBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public InterpTrackColorScale()
	{
		// Object Offset:0x00341B59
		TrackInstClass = ClassT<InterpTrackInstColorScale>()/*Ref Class'InterpTrackInstColorScale'*/;
		TrackTitle = "Color Scale";
		bOnePerGroup = true;
		bDirGroupOnly = true;
	}
}
}