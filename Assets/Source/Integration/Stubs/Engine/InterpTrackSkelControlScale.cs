namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackSkelControlScale : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[Category] public name SkelControlName;
	
	public InterpTrackSkelControlScale()
	{
		// Object Offset:0x00343BE9
		TrackInstClass = ClassT<InterpTrackInstSkelControlScale>()/*Ref Class'InterpTrackInstSkelControlScale'*/;
		TrackTitle = "SkelControl Scale";
		bIsAnimControlTrack = true;
	}
}
}