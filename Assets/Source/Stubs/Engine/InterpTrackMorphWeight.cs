namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackMorphWeight : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ name MorphNodeName;
	
	public InterpTrackMorphWeight()
	{
		// Object Offset:0x00343599
		TrackInstClass = ClassT<InterpTrackInstMorphWeight>()/*Ref Class'InterpTrackInstMorphWeight'*/;
		TrackTitle = "Morph Weight";
		bIsAnimControlTrack = true;
	}
}
}