namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdReachSpec_Jump : TdMoveReachSpec/*
		native
		config(PathfindingCosts)*/{
	[Category] public float LandingHeightDifference;
	public float SoftLandingHeight;
	public float HardLandingHeight;
	public float SlowHardLandingHeight;
	
	public TdReachSpec_Jump()
	{
		// Object Offset:0x0065441E
		SoftLandingHeight = 320.0f;
		HardLandingHeight = 512.0f;
		SlowHardLandingHeight = 780.0f;
	}
}
}