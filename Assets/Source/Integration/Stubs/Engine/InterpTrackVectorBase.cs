namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackVectorBase : InterpTrack/*
		abstract
		native
		collapsecategories
		hidecategories(Object)*/{
	public Object.InterpCurveVector VectorTrack;
	public/*()*/ float CurveTension;
	
	public InterpTrackVectorBase()
	{
		// Object Offset:0x003419C7
		TrackTitle = "Generic Vector Track";
	}
}
}