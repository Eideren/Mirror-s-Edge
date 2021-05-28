namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInterpTrackDOFFocusDistance : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public TdInterpTrackDOFFocusDistance()
	{
		// Object Offset:0x0057BE58
		TrackInstClass = ClassT<TdInterpTrackInstDOFFocusDistance>()/*Ref Class'TdInterpTrackInstDOFFocusDistance'*/;
		TrackTitle = "Focus Distance";
		bOnePerGroup = true;
		bDirGroupOnly = true;
	}
}
}