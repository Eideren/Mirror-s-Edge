namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpGroupInst : Object/*
		native*/{
	public InterpGroup Group;
	public Actor GroupActor;
	public array<InterpTrackInst> TrackInst;
	
}
}