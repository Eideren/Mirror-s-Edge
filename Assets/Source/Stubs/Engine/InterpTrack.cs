namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrack : Object/*
		abstract
		native
		collapsecategories
		noexport
		hidecategories(Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_FInterpEdInputInterface;
	public /*private native noexport */Object.Pointer CurveEdVTable;
	public Core.ClassT<InterpTrackInst> TrackInstClass;
	public String TrackTitle;
	public bool bOnePerGroup;
	public bool bDirGroupOnly;
	public bool bDisableTrack;
	public bool bIsAnimControlTrack;
	
	public InterpTrack()
	{
		// Object Offset:0x003413C3
		TrackInstClass = ClassT<InterpTrackInst>()/*Ref Class'InterpTrackInst'*/;
		TrackTitle = "Track";
	}
}
}