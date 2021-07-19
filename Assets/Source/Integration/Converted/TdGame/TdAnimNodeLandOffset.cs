namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeLandOffset : AnimNodeAimOffset/*
		native
		hidecategories(Object,Object,Object)*/{
	[Category] public float Landed;
	public bool IsLanding;
	public float LandTimer;
	[Category] public float LandInto;
	[Category] public float LandOut;
	[Category] public float LandOverlap;
	[Category] public float OverlapSize;
	
	public TdAnimNodeLandOffset()
	{
		// Object Offset:0x00504B87
		LandInto = 0.20f;
		LandOut = 0.50f;
		LandOverlap = 0.30f;
		OverlapSize = 0.20f;
	}
}
}