namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackFade : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[Category] public bool bPersistFade;
	
	public InterpTrackFade()
	{
		// Object Offset:0x0034244B
		TrackInstClass = ClassT<InterpTrackInstFade>()/*Ref Class'InterpTrackInstFade'*/;
		TrackTitle = "Fade";
		bOnePerGroup = true;
		bDirGroupOnly = true;
	}
}
}