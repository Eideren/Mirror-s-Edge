namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackSlomo : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public InterpTrackSlomo()
	{
		// Object Offset:0x00343CC6
		TrackInstClass = ClassT<InterpTrackInstSlomo>()/*Ref Class'InterpTrackInstSlomo'*/;
		TrackTitle = "Slomo";
		bOnePerGroup = true;
		bDirGroupOnly = true;
	}
}
}