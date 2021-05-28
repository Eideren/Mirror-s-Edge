namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DebugManager : Object/*
		transient
		native*/{
	public int FirstColoredMip;
	public bool bNoDecalCulling;
	
	public DebugManager()
	{
		// Object Offset:0x00307BFB
		FirstColoredMip = 1000;
	}
}
}