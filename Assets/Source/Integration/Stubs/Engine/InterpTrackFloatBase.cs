namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackFloatBase : InterpTrack/*
		abstract
		native
		collapsecategories
		hidecategories(Object)*/{
	public Object.InterpCurveFloat FloatTrack;
	public/*()*/ float CurveTension;
	
	public InterpTrackFloatBase()
	{
		// Object Offset:0x003414D4
		TrackTitle = "Generic Float Track";
	}
}
}